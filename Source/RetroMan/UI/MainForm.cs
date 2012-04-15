using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Newtonsoft.Json;
using RetroMan.Core;
using RetroMan.Database;
using RetroMan.Properties;

namespace RetroMan.UI
{
    public partial class MainForm : Form
    {
        private List<RetroDeviceInfo> deviceList;

        public MainForm()
        {
            InitializeComponent();

            // Load the Icon From the Resource
            Icon = Resources.retroman;

            // Prepare the Image List
            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(20, 20);
            imgList.Images.Add(Resources.device);
            imgList.Images.Add(Resources.game);
            imgList.Images.Add(Resources.bios);
            imgList.Images.Add(Resources.video);
            imgList.Images.Add(Resources.application);
            imgList.Images.Add(Resources.education);
            OverviewList.SmallImageList = imgList;

            OverviewList.CanExpandGetter = delegate(object x)
            {
                if (x is RetroDeviceInfo)
                {
                    return ((RetroDeviceInfo)x).FileCount > 0;
                }
                return false;
            };
            OverviewList.ChildrenGetter = delegate(object x)
            {
                if (x is RetroDeviceInfo)
                {
                    return ((RetroDeviceInfo)x).Files;
                }
                return null;
            };

            olvColumn1.AspectGetter = delegate(object x)
            {
                if (x is RetroDeviceInfo)
                {
                    RetroDeviceInfo dev = (RetroDeviceInfo)x;
                    return string.Format("{0} ({1} files)", dev.Name, dev.FileCount);
                }
                RetroFileInfo file = (RetroFileInfo)x;
                return file.Name;
            };

            olvColumn1.ImageGetter = delegate(object x)
            {
                if (x is RetroDeviceInfo)
                {
                    return 0;
                }
                RetroFileInfo file = (RetroFileInfo)x;
                switch (file.FileType)
                {
                    case FileType.Game:
                        return 1;
                    case FileType.BIOS:
                        return 2;
                    case FileType.Video:
                        return 3;
                    case FileType.App:
                        return 4;
                    case FileType.Edu:
                        return 5;
                }
                return 1;
            };

            olvColumn2.Renderer = new BarRenderer(0, 2);
            olvColumn2.AspectGetter = delegate(object x)
            {
                return 1;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Setup the Logger
            Logger.Instance.OnLog += new Action<LogEntry>(Instance_OnLog);

            // Initialize Settings
            Logger.Instance.Add(LogType.Debug, "Loading Settings");
            RetroSettings.Instance = RetroSettings.Load();
            if (string.IsNullOrWhiteSpace(RetroSettings.Instance.SevenZipPath))
            {
                RetroSettings.Instance.SevenZipPath = SearchForSevenZip();
                RetroSettings.Instance.Save();
            }

            // Process the DataFiles
            Logger.Instance.Add(LogType.Debug, "Found {0} Datafile(s)", RetroSettings.Instance.DataFiles.Count);
            deviceList = new List<RetroDeviceInfo>();
            foreach (DataFileSetting dataFile in RetroSettings.Instance.DataFiles)
            {
                deviceList.Add(new RetroDeviceInfo(dataFile));
            }
            // Assign the Model to the View
            OverviewList.SetObjects(deviceList);
        }

        private void Instance_OnLog(LogEntry logEntry)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<LogEntry>(Instance_OnLog), logEntry);
            }
            else
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Text = logEntry.Time.ToString();
                newItem.SubItems.Add(logEntry.Type.ToString());
                newItem.SubItems.Add(logEntry.Message);
                LogList.Items.Insert(0, newItem);
            }
        }

        private string SearchForSevenZip()
        {
            string sevenZipFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "7-Zip");
            if (!Directory.Exists(sevenZipFolderPath))
            {
                // Try the x86 Folder in case we're on a 64-Bit System
                sevenZipFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "7-Zip");
                if (!Directory.Exists(sevenZipFolderPath))
                {
                    MessageBox.Show("No 7-Zip Installation found, please install it or set the Path in the Settings", "No 7-Zip found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
            return sevenZipFolderPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm dlg = new SettingsForm())
            {
                dlg.InitializeSettings(RetroSettings.Instance);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    RetroSettings.Instance = dlg.GetSettings();
                    RetroSettings.Instance.Save();
                }
            }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GenerateForm dlg = new GenerateForm())
            {
                dlg.ShowDialog();
            }
        }

        private void AddDataFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a Data File";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DataFileSetting dataFile = new DataFileSetting() { Name = "ToDo", DataFilePath = dlg.FileName };
                    // Load the Info
                    RetroDeviceInfo info = new RetroDeviceInfo(dataFile);
                    // Assign the Name
                    dataFile.Name = info.Name;
                    // Add the Device to the Settings
                    RetroSettings.Instance.DataFiles.Add(dataFile);
                    RetroSettings.Instance.Save();
                    // Add the Objects to the Manager
                    deviceList.Add(info);
                    // Assign the Model to the View
                    OverviewList.SetObjects(deviceList);
                }
            }
        }

        private void treeListView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListView treeList = (TreeListView)sender;
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo hitTest = treeList.HitTest(e.X, e.Y);
                OLVListItem item = treeList.GetItem(hitTest.Item.Index);
                object rowItem = item.RowObject;
                if (rowItem is RetroDeviceInfo)
                {
                    // Show the Context Menu
                    DeviceCtx.Tag = rowItem;
                    DeviceCtx.Show(treeList, e.Location);
                }
            }
        }

        private void treeListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            var file = e.Model as RetroFileInfo;
            if (file != null)
            {
                e.Item.ForeColor = file.IsAvailable ? Color.Black : Color.Gray;
            }
        }

        private void setRomPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the Objects
            RetroDeviceInfo deviceInfo = (RetroDeviceInfo)DeviceCtx.Tag;
            DataFileSetting dataFile = deviceInfo.DataFileSetting;

            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = dataFile.RomFolderPath;
                dlg.Description = "Choose the Rom Folder for: " + deviceInfo.Name;
                dlg.ShowNewFolderButton = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dataFile.RomFolderPath = dlg.SelectedPath;
                    RetroSettings.Instance.Save();
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetroDeviceInfo deviceInfo = (RetroDeviceInfo)DeviceCtx.Tag;
            DataFileSetting dataFile = deviceInfo.DataFileSetting;
            RetroSettings.Instance.DataFiles.Remove(dataFile);
            RetroSettings.Instance.Save();
            deviceList.Remove(deviceInfo);
            OverviewList.SetObjects(deviceList);
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the Objects
            RetroDeviceInfo deviceInfo = (RetroDeviceInfo)DeviceCtx.Tag;
            int unknownFilesCount = deviceInfo.CheckFiles();
            MessageBox.Show(string.Format("You have {0} unknown Files in this Rom Folder", unknownFilesCount));
            OverviewList.Refresh();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using RetroMan.Core;
using RetroMan.Database;
using RetroMan.Models;
using RetroMan.Properties;

namespace RetroMan.UI
{
    public partial class MainForm : Form
    {
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
            treeListView1.SmallImageList = imgList;

            //"C:\Program Files\7-Zip\7z.exe" l -slt "Madden NFL 06 (U).7z"

            treeListView1.CanExpandGetter = delegate(object x)
            {
                if (x is DeviceModel)
                {
                    return ((DeviceModel)x).ChildCount > 0;
                }
                return false;
            };
            treeListView1.ChildrenGetter = delegate(object x)
            {
                if (x is DeviceModel)
                {
                    return ((DeviceModel)x).Children;
                }
                return null;
            };
            olvColumn1.ImageGetter = delegate(object x)
            {
                if (x is DeviceModel)
                {
                    return 0;
                }
                FileModel file = (FileModel)x;
                switch (file.FileType)
                {
                    case FileType.Game:
                        return 1;
                    case FileType.BIOS:
                        return 2;
                    case FileType.Video:
                        return 3;
                }
                return 1;
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialize Settings
            RetroSettings.Instance = RetroSettings.Load();
            if (string.IsNullOrWhiteSpace(RetroSettings.Instance.SevenZipPath))
            {
                RetroSettings.Instance.SevenZipPath = SearchForSevenZip();
                RetroSettings.Instance.Save();
            }


            // Load the Data Files
            List<DeviceModel> deviceList = new List<DeviceModel>();
            foreach (string dataFilePath in RetroSettings.Instance.DataFileList)
            {
                DeviceObject devObj = JsonConvert.DeserializeObject<DeviceObject>(File.ReadAllText(dataFilePath));
                DeviceModel devModel = new DeviceModel { Label = devObj.Name };
                foreach (FileObject fileObj in devObj.Files)
                {
                    devModel.Children.Add(new FileModel { Label = fileObj.Name, FileType = fileObj.FileType });
                }
                deviceList.Add(devModel);
            }

            // Process the Rom Files
            foreach (string romDirectory in RetroSettings.Instance.RomPathList)
            {
                // TODO
            }

            // Set the Objects to Display
            treeListView1.SetObjects(deviceList);
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
    }
}

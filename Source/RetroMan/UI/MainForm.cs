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
        private RetroSettings _settings;

        public MainForm()
        {
            InitializeComponent();

            // Load the Icon From the Resource
            Icon = Resources.retroman;

            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(20, 20);
            imgList.Images.Add(Resources.device);
            imgList.Images.Add(Resources.game);
            imgList.Images.Add(Resources.bios);
            imgList.Images.Add(Resources.video);
            treeListView1.SmallImageList = imgList;

            //"C:\Program Files\7-Zip\7z.exe" l -slt "Madden NFL 06 (U).7z"

            DeviceObject dev = new DeviceObject() { Name = "Nintendo Game Boy Advance", Version = "1.0" };
            dev.Files.Add(new FileObject() { FileSize = 1111, Name = "asdasf", FileType = FileType.Game });
            dev.Files.Add(new FileObject() { FileSize = 11131, Name = "Other", FileType = FileType.Game });
            string output = JsonConvert.SerializeObject(dev, Formatting.Indented);
            File.WriteAllText("db.txt", output);

            dev = JsonConvert.DeserializeObject<DeviceObject>(File.ReadAllText("db.txt"));

            /*string archivePath = @"C:\Users\Roman\Downloads\7zIntf15.zip";

            string sevenZipLibPath = Path.Combine(@"C:\Program Files\7-Zip", "7z.dll");
            using (SevenZipFormat format = new SevenZipFormat(sevenZipLibPath))
            {
                IInArchive archive = format.CreateInArchive(SevenZipFormat.GetClassIdFromKnownFormat(KnownSevenZipFormat.Zip));

                using (InStreamWrapper archiveStream = new InStreamWrapper(File.OpenRead(archivePath)))
                {
                    ulong checkPos = 32 * 1024;
                    archive.Open(archiveStream, ref checkPos, null);

                    uint count = archive.GetNumberOfItems();
                    for (uint i = 0; i < count; i++)
                    {
                        PropVariant name = new PropVariant();
                        archive.GetProperty(i, ItemPropId.kpidCRC, ref name);
                        Console.Write(i);
                        Console.Write(' ');
                        Console.WriteLine(name.GetObject());
                    }
                }
            }*/

            List<DeviceModel> deviceList = new List<DeviceModel>();
            deviceList.Add(new DeviceModel { Label = "N64" });
            deviceList[0].Children.Add(new FileModel { Label = "SomeGame", FileType = FileType.Game });
            deviceList.Add(new DeviceModel { Label = "GBA" });
            deviceList[1].Children.Add(new FileModel { Label = "SomeVideo", FileType = FileType.Video });
            deviceList[1].Children.Add(new FileModel { Label = "SomeBios", FileType = FileType.BIOS });

            treeListView1.SetObjects(deviceList);
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
            _settings = RetroSettings.Load();
            if (string.IsNullOrWhiteSpace(_settings.SevenZipPath))
            {
                _settings.SevenZipPath = SearchForSevenZip();
                _settings.Save();
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
                dlg.InitializeSettings(_settings);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _settings = dlg.GetSettings();
                    _settings.Save();
                }
            }
        }
    }
}

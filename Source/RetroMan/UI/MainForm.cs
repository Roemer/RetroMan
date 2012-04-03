using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nomad.Archive.SevenZip;
using RetroMan.Properties;
using System.IO;
using System.Reflection;
using System.Resources;
using RetroMan.Models;
using RetroMan.Database;
using Newtonsoft.Json;

namespace RetroMan.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Load the Icon From the Resource
            Icon = Resources.Games_Blue_Folder;

            //"C:\Program Files\7-Zip\7z.exe" l -slt "Madden NFL 06 (U).7z"

            DeviceObject dev = new DeviceObject() { Name = "Nintendo Game Boy Advance", Version = "1.0" };
            dev.Files.Add(new FileObject() { FileSize = 1111, Name = "asdasf", FileType = FileType.Game });
            dev.Files.Add(new FileObject() { FileSize = 11131, Name = "Other", FileType = FileType.Game });
            string output = JsonConvert.SerializeObject(dev, Formatting.Indented);
            File.WriteAllText("db.txt", output);

            dev = JsonConvert.DeserializeObject<DeviceObject>(File.ReadAllText("db.txt"));

            string archivePath = @"C:\Users\Roman\Downloads\7zIntf15.zip";

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
            }

            List<DeviceModel> deviceList = new List<DeviceModel>();
            deviceList.Add(new DeviceModel { Label = "N64" });
            deviceList[0].Children.Add(new FileModel { Label = "SomeGame" });
            deviceList.Add(new DeviceModel { Label = "GBA" });

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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

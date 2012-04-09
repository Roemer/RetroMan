using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using RetroMan.Core;
using RetroMan.Database;
using RetroMan.Tools;

namespace RetroMan.UI
{
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select the Files to Scan";
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in dlg.FileNames)
                    {
                        ProcessPath(fileName);
                    }
                }
            }
        }

        private void DropFilesLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
                DropFilesLabel.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DropFilesLabel_DragLeave(object sender, EventArgs e)
        {
            DropFilesLabel.BorderStyle = BorderStyle.None;
        }

        private void DropFilesLabel_DragDrop(object sender, DragEventArgs e)
        {
            DropFilesLabel.BorderStyle = BorderStyle.None;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string fileName in files)
            {
                ProcessPath(fileName);
            }
        }

        private void ProcessPath(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // Process Sub-Directories
                foreach (string innerPath in Directory.GetDirectories(path))
                {
                    ProcessPath(innerPath);
                }
                // Process Files in the Directory
                foreach (string innerPath in Directory.GetFiles(path))
                {
                    ProcessPath(innerPath);
                }
            }
            else
            {
                // Process File
                if (Path.GetExtension(path).Equals(".7z") || Path.GetExtension(path).Equals(".zip") || Path.GetExtension(path).Equals(".rar"))
                {
                    string tempFolder = SevenZipTool.ExtractToTemp(path);
                    // Process Sub-Directories
                    foreach (string innerPath in Directory.GetDirectories(tempFolder))
                    {
                        ProcessPath(innerPath);
                    }
                    // Process Files in the Directory
                    foreach (string innerPath in Directory.GetFiles(tempFolder))
                    {
                        ProcessPath(innerPath);
                    }
                    // Delete the Temp Folder
                    Directory.Delete(tempFolder, true);
                }
                else
                {
                    FileDataObject fo = ConvertFile(path);
                    AddFileObject(fo);
                }
            }
        }

        private FileDataObject ConvertFile(string filePath)
        {
            FileDataObject fo = new FileDataObject();
            fo.Name = Path.GetFileNameWithoutExtension(filePath);
            fo.FileName = Path.GetFileName(filePath);
            fo.FileSize = HashTool.GetFileSize(filePath);
            fo.CRC = HashTool.GetCRC(filePath);
            fo.MD5 = HashTool.GetMD5(filePath);
            fo.SHA1 = HashTool.GetSHA1(filePath);
            fo.FileType = FileType.Game;
            return fo;
        }

        private void AddFileObject(FileDataObject fo)
        {
            OutputText.Text += JsonConvert.SerializeObject(fo, Formatting.Indented) + "," + Environment.NewLine;
        }

        private void SortDataFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select the File to sort";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Load the Data File
                    DeviceDataObject dataObj = JsonConvert.DeserializeObject<DeviceDataObject>(File.ReadAllText(dlg.FileName));
                    // Sort it
                    dataObj.Files.Sort((x, y) => x.FileName.CompareTo(y.FileName));
                    // Save it
                    File.WriteAllText(dlg.FileName, JsonConvert.SerializeObject(dataObj, Formatting.Indented));
                    MessageBox.Show("Finished");
                }
            }
        }
    }
}

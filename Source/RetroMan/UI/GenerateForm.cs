using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using RetroMan.Core;
using RetroMan.Database;
using RetroMan.Tools;

namespace RetroMan.UI
{
    public partial class GenerateForm : Form
    {
        private class ProgressState
        {
            public int FoldersFound { get; set; }
            public int ArchivesFound { get; set; }
            public int FilesFound { get; set; }
        }

        private BackgroundWorker _generateBackgroundWorker;

        public GenerateForm()
        {
            InitializeComponent();

            _generateBackgroundWorker = new BackgroundWorker();
            _generateBackgroundWorker.WorkerReportsProgress = true;
            _generateBackgroundWorker.DoWork += new DoWorkEventHandler(_generateBackgroundWorker_DoWork);
            _generateBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_generateBackgroundWorker_ProgressChanged);
            _generateBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_generateBackgroundWorker_RunWorkerCompleted);
        }

        private void _generateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressState progress = new ProgressState();
            List<FileDataObject> resultList = new List<FileDataObject>();
            string[] files = (string[])e.Argument;
            foreach (string fileName in files)
            {
                ProcessPath(fileName, resultList, progress);
            }
            e.Result = resultList;
        }

        private void _generateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressState progress = (ProgressState)e.UserState;
            ProgressLabel.Text = string.Format("Folder: {0}, Archives: {1}, Files: {2}", progress.FoldersFound, progress.ArchivesFound, progress.FilesFound);
        }

        private void _generateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<FileDataObject> resultList = (List<FileDataObject>)e.Result;
            StringBuilder sb = new StringBuilder();
            foreach (FileDataObject fo in resultList)
            {
                sb.AppendLine(JsonConvert.SerializeObject(fo, Formatting.Indented) + ",");
            }

            OutputText.Text += sb.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select the Files to Scan";
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    StartProcessing(dlg.FileNames);
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
            StartProcessing(files);
        }

        private void StartProcessing(string[] files)
        {
            _generateBackgroundWorker.RunWorkerAsync(files);
        }

        private void ProcessPath(string path, List<FileDataObject> objList, ProgressState progress)
        {
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                progress.FoldersFound++;
                // Process Sub-Directories
                foreach (string innerPath in Directory.GetDirectories(path))
                {
                    ProcessPath(innerPath, objList, progress);
                }
                // Process Files in the Directory
                foreach (string innerPath in Directory.GetFiles(path))
                {
                    ProcessPath(innerPath, objList, progress);
                }
            }
            else
            {
                // Process File
                if (Path.GetExtension(path).Equals(".7z") || Path.GetExtension(path).Equals(".zip") || Path.GetExtension(path).Equals(".rar"))
                {
                    progress.ArchivesFound++;
                    string tempFolder = SevenZipTool.ExtractToTemp(path);
                    // Process Sub-Directories
                    foreach (string innerPath in Directory.GetDirectories(tempFolder))
                    {
                        ProcessPath(innerPath, objList, progress);
                    }
                    // Process Files in the Directory
                    foreach (string innerPath in Directory.GetFiles(tempFolder))
                    {
                        ProcessPath(innerPath, objList, progress);
                    }
                    // Delete the Temp Folder
                    Directory.Delete(tempFolder, true);
                }
                else
                {
                    FileDataObject fo = ConvertFile(path);
                    objList.Add(fo);
                    progress.FilesFound++;
                }
            }
            _generateBackgroundWorker.ReportProgress(0, progress);
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

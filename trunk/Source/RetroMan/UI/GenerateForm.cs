using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
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
                        if (Path.GetExtension(fileName).Equals(".7z") || Path.GetExtension(fileName).Equals(".zip") || Path.GetExtension(fileName).Equals(".rar"))
                        {
                            string tempFolder = SevenZipTool.ExtractToTemp(fileName);
                            foreach (string subFile in Directory.GetFiles(tempFolder))
                            {
                                FileObject fo = ConvertFile(subFile);
                                AddFileObject(fo);
                            }

                            Directory.Delete(tempFolder, true);
                        }
                        else
                        {
                            FileObject fo = ConvertFile(fileName);
                            AddFileObject(fo);
                        }
                    }
                }
            }
        }

        private void AddFileObject(FileObject fo)
        {
            OutputText.Text += JsonConvert.SerializeObject(fo, Formatting.Indented) + Environment.NewLine;
        }

        private FileObject ConvertFile(string filePath)
        {
            FileObject fo = new FileObject();
            fo.Name = Path.GetFileName(filePath);
            fo.FileSize = HashTool.GetFileSize(filePath);
            fo.CRC = HashTool.GetCRC(filePath);
            fo.MD5 = HashTool.GetMD5(filePath);
            fo.SHA1 = HashTool.GetSHA1(filePath);
            fo.FileType = FileType.Game;
            return fo;
        }
    }
}

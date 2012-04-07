using System.IO;
using System.Windows.Forms;
using RetroMan.Core;
using RetroMan.Properties;

namespace RetroMan.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            Icon = Resources.settings;
        }

        public void InitializeSettings(RetroSettings initialSettings)
        {
            SevenZipPathText.Text = initialSettings.SevenZipPath;
            if (initialSettings.RomPathList != null && initialSettings.RomPathList.Count > 0)
            {
                foreach (string path in initialSettings.RomPathList)
                {
                    RomFoldersListBox.Items.Add(path);
                }
            }
            if (initialSettings.DataFileList != null && initialSettings.DataFileList.Count > 0)
            {
                foreach (string path in initialSettings.DataFileList)
                {
                    DataFilesListBox.Items.Add(path);
                }
            }
        }

        public RetroSettings GetSettings()
        {
            RetroSettings newSettings = new RetroSettings();
            newSettings.SevenZipPath = SevenZipPathText.Text;
            foreach (string item in RomFoldersListBox.Items)
            {
                newSettings.RomPathList.Add(item);
            }
            foreach (string item in DataFilesListBox.Items)
            {
                newSettings.DataFileList.Add(item);
            }
            return newSettings;
        }

        private void SevenZipBrowseBtn_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Choose 7-Zip Program Folder";
                dlg.SelectedPath = SevenZipPathText.Text;
                dlg.ShowNewFolderButton = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SevenZipPathText.Text = dlg.SelectedPath;
                }
            }
        }

        private void RomFoldersListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void RomFoldersListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string fileName in files)
            {
                FileAttributes attr = File.GetAttributes(fileName);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    lb.Items.Add(fileName);
                }
            }
        }

        private void DataFilesListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DataFilesListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string fileName in files)
            {
                FileAttributes attr = File.GetAttributes(fileName);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    lb.Items.Add(fileName);
                }
            }
        }

        private void RomFoldersListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                RemoveSelectedFromListBox((ListBox)sender);
            }
        }

        private void DataFilesListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                RemoveSelectedFromListBox((ListBox)sender);
            }
        }

        private void RemoveSelectedFromListBox(ListBox listbox)
        {
            while (listbox.SelectedIndices.Count > 0)
            {
                listbox.Items.RemoveAt(listbox.SelectedIndices[0]);
            }
        }
    }
}

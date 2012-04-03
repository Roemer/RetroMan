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
        }

        public RetroSettings GetSettings()
        {
            RetroSettings newSettings = new RetroSettings();
            newSettings.SevenZipPath = SevenZipPathText.Text;
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
    }
}

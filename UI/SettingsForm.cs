using DomainSorgula.Settings;
using System;
using System.Windows.Forms;

namespace DomainSorgula.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TxtPath.Text = Setting.SavePath;
            CmbSaveSetting.SelectedIndex = Convert.ToInt32(Setting.SaveSetting);
            NumConcurrent.Value = Setting.ConcurrentCount;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Setting.SavePath = TxtPath.Text;
            Setting.ConcurrentCount = (int)NumConcurrent.Value;
            switch (CmbSaveSetting.SelectedIndex)
            {
                case 0:
                    Setting.SaveSetting = SaveSetting.Both;
                    break;
                case 1:
                    Setting.SaveSetting = SaveSetting.OnlyAvailable;
                    break;
                case 2:
                    Setting.SaveSetting = SaveSetting.OnlyTaken;
                    break;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.Desktop;
            if (DialogResult.OK == folder.ShowDialog())
                TxtPath.Text = folder.SelectedPath + @"\Sonuçlar.txt";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

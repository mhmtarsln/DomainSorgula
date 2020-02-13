using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using DomainSorgula.Helpers;
using DomainSorgula.Settings;
using DomainSorgula.Services.Base;
using DomainSorgula.Services.Checker;

namespace DomainSorgula.UI
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        CancellationTokenSource cancelToken;
        SynchronizationContext synCtx;
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetDGSettings();
            AvailabilityChecker.OnStatusChanged += DomainChecker_OnStatusChanged;
            synCtx = SynchronizationContext.Current;
        }

        private void SetDGSettings()
        {
            DGDomains.DataSource = CheckService.DomainList;
            DGDomains.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGDomains.Columns[0].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            DGDomains.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGDomains.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void DomainChecker_OnStatusChanged(Status status, int index)
        {
            switch (status)
            {
                case Status.Taken:
                    synCtx.Post((o) => DGDomains.Rows[index].DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.DarkOrange }, null);
                    break;
                case Status.Available:
                    synCtx.Post((o) => DGDomains.Rows[index].DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.YellowGreen }, null);
                    break;
                case Status.Blocked:
                    synCtx.Post((o) => DGDomains.Rows[index].DefaultCellStyle = new DataGridViewCellStyle() { BackColor = Color.DarkRed }, null);
                    break;
            }
        }

        private void AddDomainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new AddDomainForm().ShowDialog())
                MessageBox.Show("Domainler başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ClearDomainListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Listeyi temizlemek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                CheckService.DomainList.Clear();
        }

        private void BtnStartCheck_Click(object sender, EventArgs e)
        {
            if (CheckService.DomainList.Count > 0)
            {
                BtnStartCheck.Enabled = false;
                BtnStopCheck.Enabled = true;
                cancelToken = new CancellationTokenSource();

                new Thread(async () =>
                {
                    try
                    {
                        await AvailabilityChecker.CheckAll(cancelToken.Token);
                        IOHelper.WriteToDomains(Setting.SavePath);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + (ex.InnerException != null ? "\nAyrıntılar: " + ex.InnerException.Message : ""), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        synCtx.Send(delegate
                        {
                            BtnStartCheck.Enabled = true;
                            BtnStopCheck.Enabled = false;
                        }, null);
                    }

                })
                {

                    IsBackground = true
                }.Start();

            }
            else
            {
                MessageBox.Show("Domain eklemediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt|*.txt";
            file.Title = "Txt dosyası seçin";
            file.CheckFileExists = true;
            file.CheckPathExists = true;
            file.Multiselect = false;
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (DialogResult.OK == file.ShowDialog())
            {
                this.Enabled = false;
                IOHelper.ReadFromTxt(file.FileName);
                this.Enabled = true;
            }

        }

        private void BtnStopCheck_Click(object sender, EventArgs e)
        {

            cancelToken.Cancel(); 
            BtnStopCheck.Enabled = false;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new SettingsForm().ShowDialog())
                MessageBox.Show("Ayarlar başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Toplu domain sorgu v1.0\n• Multi thread\n• Çoklu sorgu kaynağı (3)\n• Txt çıktı sonucu\n\nMahmut Arslan tarafından geliştirilmiştir.\nİletişim: mail@mahmutarslan.com", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Environment.Exit(0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (DialogResult.Yes == MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Environment.Exit(0);
        }

    }
}

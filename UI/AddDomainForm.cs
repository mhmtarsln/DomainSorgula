using DomainSorgula.Services;
using DomainSorgula.Helpers;
using DomainSorgula.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainSorgula.Services.Base;

namespace DomainSorgula.UI
{
    public partial class AddDomainForm : Form
    {
        public AddDomainForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (var line in TxtDomains.Lines)
            {
                string domain = line.Trim();
                if (!string.IsNullOrEmpty(domain) && RegexHelper.IsValidDomain(domain))
                    CheckService.DomainList.Add(new Domain() { Index = CheckService.DomainList.Count + 1, Name = domain, Status = "Bekleniyor" });
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

namespace DomainSorgula.UI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumConcurrent = new System.Windows.Forms.NumericUpDown();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.BtnChoose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbSaveSetting = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumConcurrent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NumConcurrent);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eş zamanlı kontrol (thread) sayısı:";
            // 
            // NumConcurrent
            // 
            this.NumConcurrent.Location = new System.Drawing.Point(15, 22);
            this.NumConcurrent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumConcurrent.Name = "NumConcurrent";
            this.NumConcurrent.Size = new System.Drawing.Size(317, 23);
            this.NumConcurrent.TabIndex = 0;
            this.NumConcurrent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 218);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(82, 29);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Kaydet";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(278, 218);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(82, 29);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Kapat";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtPath);
            this.groupBox2.Controls.Add(this.BtnChoose);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 59);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sonuç txt kayıt konumu:";
            // 
            // TxtPath
            // 
            this.TxtPath.Location = new System.Drawing.Point(15, 22);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(282, 23);
            this.TxtPath.TabIndex = 0;
            // 
            // BtnChoose
            // 
            this.BtnChoose.Location = new System.Drawing.Point(303, 22);
            this.BtnChoose.Name = "BtnChoose";
            this.BtnChoose.Size = new System.Drawing.Size(29, 23);
            this.BtnChoose.TabIndex = 1;
            this.BtnChoose.Text = "..";
            this.BtnChoose.UseVisualStyleBackColor = true;
            this.BtnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbSaveSetting);
            this.groupBox3.Location = new System.Drawing.Point(12, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 59);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Domain kayıt ayarı:";
            // 
            // CmbSaveSetting
            // 
            this.CmbSaveSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSaveSetting.FormattingEnabled = true;
            this.CmbSaveSetting.Items.AddRange(new object[] {
            "Hepsini kaydet",
            "Sadece müsaitleri kaydet",
            "Sadece alınmışları kaydet"});
            this.CmbSaveSetting.Location = new System.Drawing.Point(15, 22);
            this.CmbSaveSetting.Name = "CmbSaveSetting";
            this.CmbSaveSetting.Size = new System.Drawing.Size(317, 23);
            this.CmbSaveSetting.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 258);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumConcurrent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NumConcurrent;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button BtnChoose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbSaveSetting;
    }
}
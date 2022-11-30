
namespace _160421072_VincentKurniawan
{
    partial class FormUtama
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
            this.labelNama = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelKode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.akunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penggunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karyawanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jenisTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.Location = new System.Drawing.Point(1066, 11);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(102, 17);
            this.labelNama.TabIndex = 8;
            this.labelNama.Text = "Nama Pegawai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "-";
            // 
            // labelKode
            // 
            this.labelKode.AutoSize = true;
            this.labelKode.Location = new System.Drawing.Point(934, 11);
            this.labelKode.Name = "labelKode";
            this.labelKode.Size = new System.Drawing.Size(41, 17);
            this.labelKode.TabIndex = 6;
            this.labelKode.Text = "Kode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(774, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Anda login sebagai :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akunToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.keluarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // akunToolStripMenuItem
            // 
            this.akunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penggunaToolStripMenuItem,
            this.karyawanToolStripMenuItem,
            this.inboxToolStripMenuItem});
            this.akunToolStripMenuItem.Name = "akunToolStripMenuItem";
            this.akunToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.akunToolStripMenuItem.Text = "Akun";
            // 
            // penggunaToolStripMenuItem
            // 
            this.penggunaToolStripMenuItem.Name = "penggunaToolStripMenuItem";
            this.penggunaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.penggunaToolStripMenuItem.Text = "Pengguna";
            this.penggunaToolStripMenuItem.Click += new System.EventHandler(this.penggunaToolStripMenuItem_Click);
            // 
            // karyawanToolStripMenuItem
            // 
            this.karyawanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posisiToolStripMenuItem});
            this.karyawanToolStripMenuItem.Name = "karyawanToolStripMenuItem";
            this.karyawanToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.karyawanToolStripMenuItem.Text = "Karyawan";
            // 
            // posisiToolStripMenuItem
            // 
            this.posisiToolStripMenuItem.Name = "posisiToolStripMenuItem";
            this.posisiToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.posisiToolStripMenuItem.Text = "Posisi";
            this.posisiToolStripMenuItem.Click += new System.EventHandler(this.posisiToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jenisTransaksiToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // jenisTransaksiToolStripMenuItem
            // 
            this.jenisTransaksiToolStripMenuItem.Name = "jenisTransaksiToolStripMenuItem";
            this.jenisTransaksiToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.jenisTransaksiToolStripMenuItem.Text = "Jenis Transaksi";
            this.jenisTransaksiToolStripMenuItem.Click += new System.EventHandler(this.jenisTransaksiToolStripMenuItem_Click);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.inboxToolStripMenuItem.Text = "Inbox";
            this.inboxToolStripMenuItem.Click += new System.EventHandler(this.inboxToolStripMenuItem_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 477);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelKode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormUtama";
            this.Text = "Bank DiBa";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelKode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem akunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penggunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karyawanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jenisTransaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
    }
}


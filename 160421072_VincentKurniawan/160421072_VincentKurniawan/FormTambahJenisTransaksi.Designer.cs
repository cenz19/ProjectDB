
namespace _160421072_VincentKurniawan
{
    partial class FormTambahJenisTransaksi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.labelNama = new System.Windows.Forms.Label();
            this.labelKode = new System.Windows.Forms.Label();
            this.back_Btn = new System.Windows.Forms.Button();
            this.clr_Btn = new System.Windows.Forms.Button();
            this.save_Btn = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxKode = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 100);
            this.panel1.TabIndex = 29;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(95, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(524, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Tambah Tipe Transaksi";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(223, 268);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(324, 22);
            this.textBoxNama.TabIndex = 35;
            // 
            // labelNama
            // 
            this.labelNama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNama.AutoSize = true;
            this.labelNama.BackColor = System.Drawing.Color.Transparent;
            this.labelNama.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNama.Location = new System.Drawing.Point(26, 268);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(190, 23);
            this.labelNama.TabIndex = 33;
            this.labelNama.Text = "Nama Transaksi:";
            this.labelNama.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelKode
            // 
            this.labelKode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKode.AutoSize = true;
            this.labelKode.BackColor = System.Drawing.Color.Transparent;
            this.labelKode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelKode.Location = new System.Drawing.Point(26, 204);
            this.labelKode.Name = "labelKode";
            this.labelKode.Size = new System.Drawing.Size(70, 23);
            this.labelKode.TabIndex = 28;
            this.labelKode.Text = "Kode:";
            this.labelKode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // back_Btn
            // 
            this.back_Btn.BackColor = System.Drawing.Color.Red;
            this.back_Btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_Btn.ForeColor = System.Drawing.SystemColors.Menu;
            this.back_Btn.Location = new System.Drawing.Point(581, 381);
            this.back_Btn.Name = "back_Btn";
            this.back_Btn.Size = new System.Drawing.Size(87, 32);
            this.back_Btn.TabIndex = 32;
            this.back_Btn.Text = "&BACK";
            this.back_Btn.UseVisualStyleBackColor = false;
            this.back_Btn.Click += new System.EventHandler(this.back_Btn_Click);
            // 
            // clr_Btn
            // 
            this.clr_Btn.BackColor = System.Drawing.Color.Gold;
            this.clr_Btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr_Btn.Location = new System.Drawing.Point(132, 381);
            this.clr_Btn.Name = "clr_Btn";
            this.clr_Btn.Size = new System.Drawing.Size(87, 32);
            this.clr_Btn.TabIndex = 31;
            this.clr_Btn.Text = "&CLEAR";
            this.clr_Btn.UseVisualStyleBackColor = false;
            this.clr_Btn.Click += new System.EventHandler(this.clr_Btn_Click);
            // 
            // save_Btn
            // 
            this.save_Btn.BackColor = System.Drawing.Color.Chartreuse;
            this.save_Btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_Btn.Location = new System.Drawing.Point(19, 381);
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(87, 32);
            this.save_Btn.TabIndex = 30;
            this.save_Btn.Text = "&SAVE";
            this.save_Btn.UseVisualStyleBackColor = false;
            this.save_Btn.Click += new System.EventHandler(this.save_Btn_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(223, 150);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(324, 22);
            this.textBoxId.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(26, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "Id:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxKode
            // 
            this.comboBoxKode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKode.FormattingEnabled = true;
            this.comboBoxKode.Items.AddRange(new object[] {
            "DBT",
            "CRT",
            "TAX",
            "ITR"});
            this.comboBoxKode.Location = new System.Drawing.Point(223, 204);
            this.comboBoxKode.Name = "comboBoxKode";
            this.comboBoxKode.Size = new System.Drawing.Size(324, 24);
            this.comboBoxKode.TabIndex = 38;
            // 
            // FormTambahJenisTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(681, 423);
            this.Controls.Add(this.comboBoxKode);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxNama);
            this.Controls.Add(this.labelNama);
            this.Controls.Add(this.labelKode);
            this.Controls.Add(this.back_Btn);
            this.Controls.Add(this.clr_Btn);
            this.Controls.Add(this.save_Btn);
            this.Name = "FormTambahJenisTransaksi";
            this.Text = "FormTambahJenisTransaksi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.Label labelKode;
        private System.Windows.Forms.Button back_Btn;
        private System.Windows.Forms.Button clr_Btn;
        private System.Windows.Forms.Button save_Btn;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxKode;
    }
}
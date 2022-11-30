
namespace _160421072_VincentKurniawan
{
    partial class FormDaftarJenisPosisi
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxCari = new System.Windows.Forms.TextBox();
            this.comboBoxCari = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.back_Btn = new System.Windows.Forms.Button();
            this.save_Btn = new System.Windows.Forms.Button();
            this.dataGridViewKategori = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKategori)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Location = new System.Drawing.Point(23, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 100);
            this.panel1.TabIndex = 19;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(210, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(332, 46);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "POSITION TYPE";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.textBoxCari);
            this.panel2.Controls.Add(this.comboBoxCari);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(23, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 74);
            this.panel2.TabIndex = 20;
            // 
            // textBoxCari
            // 
            this.textBoxCari.Location = new System.Drawing.Point(347, 26);
            this.textBoxCari.Name = "textBoxCari";
            this.textBoxCari.Size = new System.Drawing.Size(380, 22);
            this.textBoxCari.TabIndex = 4;
            this.textBoxCari.TextChanged += new System.EventHandler(this.textBoxCari_TextChanged);
            // 
            // comboBoxCari
            // 
            this.comboBoxCari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCari.FormattingEnabled = true;
            this.comboBoxCari.Items.AddRange(new object[] {
            "id",
            "nama",
            "keterangan"});
            this.comboBoxCari.Location = new System.Drawing.Point(170, 25);
            this.comboBoxCari.Name = "comboBoxCari";
            this.comboBoxCari.Size = new System.Drawing.Size(171, 24);
            this.comboBoxCari.TabIndex = 3;
            this.comboBoxCari.SelectedIndexChanged += new System.EventHandler(this.comboBoxCari_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cari Berdasarkan:";
            // 
            // back_Btn
            // 
            this.back_Btn.BackColor = System.Drawing.Color.Red;
            this.back_Btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_Btn.ForeColor = System.Drawing.SystemColors.Menu;
            this.back_Btn.Location = new System.Drawing.Point(690, 622);
            this.back_Btn.Name = "back_Btn";
            this.back_Btn.Size = new System.Drawing.Size(87, 32);
            this.back_Btn.TabIndex = 24;
            this.back_Btn.Text = "&BACK";
            this.back_Btn.UseVisualStyleBackColor = false;
            // 
            // save_Btn
            // 
            this.save_Btn.BackColor = System.Drawing.Color.Chartreuse;
            this.save_Btn.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_Btn.Location = new System.Drawing.Point(23, 622);
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(87, 32);
            this.save_Btn.TabIndex = 22;
            this.save_Btn.Text = "&ADD";
            this.save_Btn.UseVisualStyleBackColor = false;
            this.save_Btn.Click += new System.EventHandler(this.save_Btn_Click);
            // 
            // dataGridViewKategori
            // 
            this.dataGridViewKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKategori.Location = new System.Drawing.Point(23, 228);
            this.dataGridViewKategori.Name = "dataGridViewKategori";
            this.dataGridViewKategori.RowHeadersWidth = 51;
            this.dataGridViewKategori.RowTemplate.Height = 24;
            this.dataGridViewKategori.Size = new System.Drawing.Size(754, 363);
            this.dataGridViewKategori.TabIndex = 21;
            this.dataGridViewKategori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKategori_CellContentClick);
            // 
            // FormDaftarJenisPosisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.back_Btn);
            this.Controls.Add(this.save_Btn);
            this.Controls.Add(this.dataGridViewKategori);
            this.Name = "FormDaftarJenisPosisi";
            this.Text = "FormDaftarJenisPosisi";
            this.Load += new System.EventHandler(this.FormDaftarJenisPosisi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKategori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxCari;
        private System.Windows.Forms.ComboBox comboBoxCari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button back_Btn;
        private System.Windows.Forms.Button save_Btn;
        private System.Windows.Forms.DataGridView dataGridViewKategori;
    }
}
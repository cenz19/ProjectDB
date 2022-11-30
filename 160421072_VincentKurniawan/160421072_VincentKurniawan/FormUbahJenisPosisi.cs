using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankDiba_LIB;

namespace _160421072_VincentKurniawan
{
    public partial class FormUbahJenisPosisi : Form
    {
        public FormUbahJenisPosisi()
        {
            InitializeComponent();
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Positions p = new Positions(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxKeterangan.Text);
                Positions.UbahData(p);

                MessageBox.Show("Data berhasil diubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clr_Btn_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNama.Text = "";
            textBoxKeterangan.Text = "";
            textBoxKode.Focus();
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            FormDaftarJenisPosisi frm = (FormDaftarJenisPosisi)this.Owner;
            frm.FormDaftarJenisPosisi_Load(sender, e);
            this.Close();
        }
    }
}

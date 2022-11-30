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
    public partial class FormTambahJenisPosisi : Form
    {
        public FormTambahJenisPosisi()
        {
            InitializeComponent();
        }

        private void FormTambahJenisPosisi_Load(object sender, EventArgs e)
        {

        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Positions p = new Positions(int.Parse(textBoxKode.Text), textBoxNama.Text, textBoxKeterangan.Text);
                Boolean status = Positions.TambahData(p);

                if (status == true)
                {
                    MessageBox.Show("Data berhasil disimpan");
                }
                else
                {
                    MessageBox.Show("Data gagal disimpan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            FormDaftarJenisPosisi frm = (FormDaftarJenisPosisi)this.Owner;
            frm.FormDaftarJenisPosisi_Load(sender, e);
            this.Close();
        }

        private void clr_Btn_Click(object sender, EventArgs e)
        {
            textBoxKode.Text = "";
            textBoxNama.Text = "";
            textBoxKeterangan.Text = "";
            textBoxKode.Focus();
        }
    }
}

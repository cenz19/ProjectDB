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
    public partial class FormTambahJenisTransaksi : Form
    {
        public FormTambahJenisTransaksi()
        {
            InitializeComponent();
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                JenisTransaksi j = new JenisTransaksi(int.Parse(textBoxId.Text), comboBoxKode.SelectedItem.ToString(), textBoxNama.Text);
                bool hasil = JenisTransaksi.TambahData(j);

                MessageBox.Show("Data berhasil ditambah");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            FormDaftarJenisTransaksi frm = (FormDaftarJenisTransaksi)this.Owner;
            frm.FormDaftarJenisTransaksi_Load(sender, e);
            this.Close();
        }

        private void clr_Btn_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            comboBoxKode.SelectedIndex = -1;
            textBoxNama.Text = "";
            textBoxId.Focus();

        }
    }
}

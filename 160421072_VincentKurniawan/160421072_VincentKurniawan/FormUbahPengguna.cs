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
    public partial class FormUbahPengguna : Form
    {
        public FormUbahPengguna()
        {
            InitializeComponent();
        }

        public void FormUbahPengguna_Load(object sender, EventArgs e)
        {
          
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                SecurityQuestion selectedQuestion = (SecurityQuestion)comboBoxSecurityQuestion.SelectedItem;
                Pengguna p = new Pengguna(textBoxNik.Text, textBoxNamaDepan.Text, textBoxNamaBelakang.Text, textBoxAlamat.Text
                    , textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, textBoxPin.Text, DateTime.Now, DateTime.Now, selectedQuestion,
                    textBoxAnswer.Text);
                Pengguna.UbahData(p);

                MessageBox.Show("Pengguna berhasil ditambahkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            FormDaftarPengguna frm = (FormDaftarPengguna)this.Owner;
            frm.FormDaftarPengguna_Load(sender, e);
            this.Close();
        }

        private void clr_Btn_Click(object sender, EventArgs e)
        {
            textBoxNik.Text = "";
            textBoxNamaDepan.Text = "";
            textBoxNamaBelakang.Text = "";
            textBoxAlamat.Text = "";
            textBoxEmail.Text = "";
            textBoxNomorTelepon.Text = "";
            textBoxPassword.Text = "";
            textBoxPin.Text = "";
            comboBoxSecurityQuestion.SelectedIndex = -1;
            textBoxAnswer.Text = "";
            textBoxNik.Focus();
        }
    }
}

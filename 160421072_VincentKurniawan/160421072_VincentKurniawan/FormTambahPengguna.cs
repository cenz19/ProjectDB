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
    public partial class FormTambahPengguna : Form
    {
        public List<SecurityQuestion> listQuestion = new List<SecurityQuestion>();
        public FormTambahPengguna()
        {
            InitializeComponent();
        }

        private void FormTambahPengguna_Load(object sender, EventArgs e)
        {
            listQuestion = SecurityQuestion.BacaData("", "");

            comboBoxSecurityQuestion.DataSource = listQuestion;
            comboBoxSecurityQuestion.DisplayMember = "question";
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                SecurityQuestion selectedQuestion = (SecurityQuestion)comboBoxSecurityQuestion.SelectedItem;
                Pengguna p = new Pengguna(textBoxNik.Text, textBoxNamaDepan.Text, textBoxNamaBelakang.Text, textBoxAlamat.Text
                    , textBoxEmail.Text, textBoxNomorTelepon.Text, textBoxPassword.Text, textBoxPin.Text, DateTime.Now, DateTime.Now, selectedQuestion,
                    textBoxAnswer.Text);
                Boolean status = Pengguna.TambahData(p);

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
                MessageBox.Show( ex.Message);
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

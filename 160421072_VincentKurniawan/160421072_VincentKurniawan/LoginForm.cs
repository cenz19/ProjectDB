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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();

                Pengguna p = Pengguna.CekLogin(textBoxUsername.Text, textBoxPassword.Text);

                if (!(p is null))
                {
                    FormUtama frm = (FormUtama)this.Owner;
                    frm.pengguna = p;

                    MessageBox.Show("Koneksi berhasil. Selamat menggunakan aplikasi.", "Informasi");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Username tidak ditemukan atau password salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gaga;. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

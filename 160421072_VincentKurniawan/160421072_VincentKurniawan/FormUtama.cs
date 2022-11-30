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
    public partial class FormUtama : Form
    {
        public Pengguna pengguna;
        public FormUtama()
        {
            InitializeComponent();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            //ubah form ini (FormUtama) menjadi fullscreen (maximized)
            this.WindowState = FormWindowState.Maximized;
            //ubah FormUtama menjadi MdiParent (MdiContainer)
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi();
                LoginForm frmLogin = new LoginForm();
                frmLogin.Owner = this;
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    labelKode.Text = pengguna.Nik;
                    labelNama.Text = pengguna.NamaDepan;
                }
                else
                {
                    MessageBox.Show("Gagal Login");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal. Pesan Kesalahan : " + ex.Message);
            }


        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jenisTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJenisTransaksi"];
            if (form == null)
            {
                FormDaftarJenisTransaksi frm = new FormDaftarJenisTransaksi();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void posisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJenisPosisi"];
            if (form == null)
            {
                FormDaftarJenisPosisi frm = new FormDaftarJenisPosisi();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPengguna"];
            if (form == null)
            {
                FormDaftarPengguna frm = new FormDaftarPengguna();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}

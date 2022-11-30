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
    public partial class FormDaftarPengguna : Form
    {
        public List<Pengguna> listPengguna;

        public FormDaftarPengguna()
        {
            InitializeComponent();
        }

        public void FormDaftarPengguna_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            listPengguna = Pengguna.BacaData("", "");
            if (listPengguna.Count > 0)
            {
                dataGridViewInfo.DataSource = listPengguna;
                if (dataGridViewInfo.ColumnCount < 13)
                {
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Ubah";
                    bcol.Name = "btnUbahGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewInfo.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol2.HeaderText = "Aksi";
                    bcol2.Text = "Hapus";
                    bcol2.Name = "btnHapusGrid";
                    bcol2.UseColumnTextForButtonValue = true;
                    dataGridViewInfo.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewInfo.DataSource = null;
            }
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (listPengguna.Count > 0)
            {
                dataGridViewInfo.DataSource = listPengguna;
                if(dataGridViewInfo.ColumnCount < 13)
                {
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Ubah";
                    bcol.Name = "btnUbahGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewInfo.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Hapus";
                    bcol.Name = "btnHapusGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewInfo.Columns.Add(bcol2);
                }
            }
            else
            {
                dataGridViewInfo.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            /*nik
            nama depan
            nama keluarga
            email
            alamat
            nomor telepon*/
            if (comboBoxCari.Text == "nik")
            {
                listPengguna = Pengguna.BacaData("nik", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "nama depan")
            {
                listPengguna = Pengguna.BacaData("nama_depan", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "nama keluarga")
            {
                listPengguna = Pengguna.BacaData("nama_keluarga", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "email")
            {
                listPengguna = Pengguna.BacaData("email", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "nomor telepon")
            {
                listPengguna = Pengguna.BacaData("no_telepon", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "alamat")
            {
                listPengguna = Pengguna.BacaData("alamat", textBoxCari.Text);
            }

            if (listPengguna.Count > 0)
            {
                dataGridViewInfo.DataSource = listPengguna;
            }
            else
            {
                dataGridViewInfo.DataSource = null;
            }
        }

        private void dataGridViewInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInfo.Columns["btnHapusGrid"].Index && e.RowIndex >= 0)
            {
                string kode = dataGridViewInfo.CurrentRow.Cells["Nik"].Value.ToString();
                string nama = dataGridViewInfo.CurrentRow.Cells["NamaDepan"].Value.ToString();
                DialogResult hasil = MessageBox.Show(this, "Anda yakin ingin menghapus " + kode + " - " + nama + "?",
                    "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        Pengguna k = new Pengguna(kode);
                        Boolean hapus = Pengguna.HapusData(k);
                        if (hapus == true)
                        {
                            MessageBox.Show("Penghapusan data berhasil");
                            FormDaftarPengguna_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Penghapusan data gagal");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                FormUbahPengguna frm = new FormUbahPengguna();
                frm.Owner = this;
                frm.textBoxNik.Text= dataGridViewInfo.CurrentRow.Cells["Nik"].Value.ToString();
                frm.textBoxNamaDepan.Text = dataGridViewInfo.CurrentRow.Cells["NamaDepan"].Value.ToString();
                frm.textBoxNamaBelakang.Text = dataGridViewInfo.CurrentRow.Cells["NamaKeluarga"].Value.ToString();
                frm.Show();
            }
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            FormTambahPengguna frm = new FormTambahPengguna();
            frm.Owner = this;
            frm.Show();
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class FormDaftarJenisTransaksi : Form
    {
        List<JenisTransaksi> listJenisTransaksi = new List<JenisTransaksi>();
        public FormDaftarJenisTransaksi()
        {
            InitializeComponent();
        }

        private void dataGridViewKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewKategori.Columns["btnHapusGrid"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dataGridViewKategori.CurrentRow.Cells["Id"].Value.ToString());
                string kode = dataGridViewKategori.CurrentRow.Cells["Kode"].Value.ToString();
                string nama = dataGridViewKategori.CurrentRow.Cells["Nama"].Value.ToString();
                DialogResult hasil = MessageBox.Show(this, "Anda yakin ingin menghapus " + kode + " - " + nama + "?",
                    "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        JenisTransaksi j = new JenisTransaksi(id, kode, nama);
                        Boolean hapus = JenisTransaksi.HapusData(j);
                        if (hapus == true)
                        {
                            MessageBox.Show("Penghapusan data berhasil");
                            FormDaftarJenisTransaksi_Load(sender, e);
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
                FormUbahJenisTransaksi frm = new FormUbahJenisTransaksi();
                frm.Owner = this;
                frm.textBoxId.Text = dataGridViewKategori.CurrentRow.Cells["id"].Value.ToString();
                frm.Show();
            }
        }

        public void FormDaftarJenisTransaksi_Load(object sender, EventArgs e)
        {
            listJenisTransaksi = JenisTransaksi.BacaData("", "");
            if (listJenisTransaksi.Count > 0)
            {
                dataGridViewKategori.DataSource = listJenisTransaksi;
                if (dataGridViewKategori.ColumnCount < 4)
                {
                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.HeaderText = "Aksi";
                    bcol.Text = "Ubah";
                    bcol.Name = "btnUbahGrid";
                    bcol.UseColumnTextForButtonValue = true;
                    dataGridViewKategori.Columns.Add(bcol);

                    DataGridViewButtonColumn bco2 = new DataGridViewButtonColumn();
                    bco2.HeaderText = "Aksi";
                    bco2.Text = "Hapus";
                    bco2.Name = "btnHapusGrid";
                    bco2.UseColumnTextForButtonValue = true;
                    dataGridViewKategori.Columns.Add(bco2);
                }
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            FormTambahJenisTransaksi frm = new FormTambahJenisTransaksi();
            frm.Owner = this;
            frm.Show();
           
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "Id")
            {
                listJenisTransaksi = JenisTransaksi.BacaData("Id", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Kode")
            {
                listJenisTransaksi = JenisTransaksi.BacaData("Kode", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama")
            {
                listJenisTransaksi = JenisTransaksi.BacaData("Nama", textBoxCari.Text);
            }

            if (listJenisTransaksi.Count > 0)
            {
                dataGridViewKategori.DataSource = listJenisTransaksi;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

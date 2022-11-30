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
    public partial class FormDaftarJenisPosisi : Form
    {
        public List<Positions> listPosition;
        public FormDaftarJenisPosisi()
        {
            InitializeComponent();
        }

        private void dataGridViewKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewKategori.Columns["btnHapusGrid"].Index && e.RowIndex >= 0)
            {
                string kode = dataGridViewKategori.CurrentRow.Cells["id"].Value.ToString();
                string nama = dataGridViewKategori.CurrentRow.Cells["nama"].Value.ToString();
                DialogResult hasil = MessageBox.Show(this, "Anda yakin ingin menghapus " + kode + " - " + nama + "?",
                    "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        Positions p = new Positions(int.Parse(kode));
                        Boolean hapus = Positions.HapusData(p);
                        if (hapus == true)
                        {
                            MessageBox.Show("Penghapusan data berhasil");
                            FormDaftarJenisPosisi_Load(sender, e);
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
                FormUbahJenisPosisi frm = new FormUbahJenisPosisi();
                frm.Owner = this;
                frm.textBoxKode.Text = dataGridViewKategori.CurrentRow.Cells["id"].Value.ToString();
                frm.textBoxNama.Text = dataGridViewKategori.CurrentRow.Cells["nama"].Value.ToString();
                frm.textBoxKeterangan.Text = dataGridViewKategori.CurrentRow.Cells["keterangan"].Value.ToString();
                frm.Show();
            }
        }

        private void comboBoxCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*id
            nama
            keterangan*/
            if (comboBoxCari.Text == "id")
            {
                listPosition = Positions.BacaData("id", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "nama")
            {
                listPosition = Positions.BacaData("nama", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "keterangan")
            {
                listPosition = Positions.BacaData("keterangan", textBoxCari.Text);
            }

            
        }

        public void FormDaftarJenisPosisi_Load(object sender, EventArgs e)
        {
            listPosition = Positions.BacaData("", "");
            if (listPosition.Count > 0)
            {
                dataGridViewKategori.DataSource = listPosition;
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
            FormTambahJenisPosisi frm = new FormTambahJenisPosisi();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            /*id
            nama
            keterangan*/
            if (comboBoxCari.Text == "id")
            {
                listPosition = Positions.BacaData("id", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "nama")
            {
                listPosition = Positions.BacaData("nama", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "keterangan")
            {
                listPosition = Positions.BacaData("keterangan", textBoxCari.Text);
            }

            if(listPosition.Count > 0)
            {
                dataGridViewKategori.DataSource = listPosition;
            }
            else
            {
                dataGridViewKategori.DataSource = null;
            }
        }
    }
}

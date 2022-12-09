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
    public partial class FormDaftarDeposito : Form
    {
        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        List<Deposito> listDeposito = new List<Deposito>();
        private void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            listDeposito = Deposito.BacaData("", "");
            if (listDeposito.Count > 0)
            {
                dataGridViewInfo.DataSource = listDeposito;
                if (dataGridViewInfo.ColumnCount < 11)
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

        private void dataGridViewInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

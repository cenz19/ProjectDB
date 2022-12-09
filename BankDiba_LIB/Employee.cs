using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankDiba_LIB
{
    public class Employee
    {
        #region DataMembers
        private int id;
        private string namaDepan;
        private string namaKeluarga;
        private Positions positions;
        private string nik;
        private string email;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        #endregion

        #region Constructors
        public Employee(int id, string namaDepan, string namaKeluarga, Positions Positions, 
            string nik, string email, string password, DateTime tglBuat, DateTime tglPerubahan)
        {
            this.id = id;
            this.namaDepan = namaDepan;
            this.namaKeluarga = namaKeluarga;
            this.positions = Positions;
            this.nik = nik;
            this.email = email;
            this.password = password;
            this.tglBuat = tglBuat;
            this.tglPerubahan = tglPerubahan;
        }
        #endregion
        #region Properties
        public int Id { get => id; set => id = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public Positions Positions { get => positions; set => positions = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region Methods
        public static List<Employee> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = $"select E.KodeEmployee, E.Nama, E.TglLahir, E.Alamat, E.Gaji, E.Username, E.Password" +
                      $"P.id, P.nama AS Positions from Employee E inner join Positions P on E.position_id = P.id";
            }
            else
            {
                sql = $"select E.KodeEmployee, E.Nama, E.TglLahir, E.Alamat, E.Gaji, E.Username, E.Password" +
                      $"P.id, P.nama AS Positions from Employee E inner join Positions P on E.position_id = P.id" +
                      $"where {kriteria} LIKE '%{nilaiKriteria}%'";
            }
            // ------
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Employee> listEmployee = new List<Employee>();
            while (hasil.Read() == true)
            {
                Positions P = new Positions((int)hasil.GetValue(0), hasil.GetString(1), hasil.GetString(2));
                Employee E = new Employee(int.Parse(hasil.GetString(0)), hasil.GetString(1), hasil.GetString(2),
                                           P,                 hasil.GetString(4), hasil.GetString(5), 
                                           hasil.GetString(6), hasil.GetDateTime(7), hasil.GetDateTime(8));
                listEmployee.Add(E);
            }
            return listEmployee;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}

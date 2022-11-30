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
                sql = $"select E.id, E.nama_depan, E.nama_keluarga, E.position_id, E.nik, E.email, E.password, E.tgl_buat, E.tgl_perubahan" +
                      $", P.id, P.nama AS Positions from Employee E inner join Positions P on E.position_id = P.id";
            }
            else
            {
                sql = $"select E.id, E.nama_depan, E.nama_keluarga, E.position_id, E.nik, E.email, E.password, E.tgl_buat, E.tgl_perubahan" +
                      $", P.id, P.nama AS Positions from Employee E inner join Positions P on E.position_id = P.id" +
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
        public static Employee CekLogin(string user, string passwd)
        {
            string sql = "";
            sql = $"select E.id, E.nama_depan, E.nama_keluarga, E.position_id, E.nik, E.email, E.password, E.tgl_buat, E.tgl_perubahan" +
                  $", P.id, P.nama AS Positions from Employee E inner join Positions P on E.position_id = P.id" +
                  $"where email='{user}' AND password=SHA2('{passwd}', 512)";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Positions p = new Positions((int)hasil.GetValue(0), hasil.GetString(1), hasil.GetString(2));
                Employee e = new Employee(int.Parse(hasil.GetString(0)), hasil.GetString(1), hasil.GetString(2),
                                           p, hasil.GetString(4), hasil.GetString(5),
                                           hasil.GetString(6), hasil.GetDateTime(7), hasil.GetDateTime(8));
                return e;
            }
            return null;
        }
        public static void TambahData(Employee e)
        {
            string sql = $"INSERT INTO employee (nama_depan, nama_keluarga, position_id, nik, email, password, tgl_buat, tgl_perubahan) " +
                $"values ('{e.NamaDepan.Replace("'", "\\'")}', '{e.NamaKeluarga.Replace("'", "\\'")}', " +
                $"'{e.Positions.Id}', '{e.Nik}', '{e.Email}', SHA2('{e.Password}', 512), " +
                $"'{e.TglBuat.ToString("yyyy-MM-dd")}', '{e.TglPerubahan.ToString("yyyy-MM-dd")}')";
            Koneksi.JalankanPerintahDML(sql);
        }
        public static Boolean UbahData(Employee e)
        {
            string sql = $"update employee set nama_depan ='{e.NamaDepan.Replace("'", "\\'")}, nama_keluarga='{e.NamaKeluarga.Replace("'", "\\")}'"+
                $",position_id='{e.Positions.Id}'"+
                $",nik=' {e.Nik} '"+
                $",email=' {e.Email} '"+
                $",password=SHA2('{e.Password}', 512)" +
                $",tgl_buat='{e.TglBuat}'" +
                $",tgl_perubahan='{e.TglPerubahan}'" +
                $"where id='{e.Id}'";
            int jumlahDataBerubah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDataBerubah == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Boolean HapusData(Employee e)
        {
            string sql = "delete from employee where id = '" +
                e.Id+ "'";
            int jumlahDataBerubah = Koneksi.JalankanPerintahDML(sql);
            if (jumlahDataBerubah == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GenerateKode() // generate id
        {
            //dapatkan kode pegawai terakhir (kode terbesar)
            string sql = "select max(id) from employee";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                int kodeTerbaru = int.Parse(hasil.GetString(0)) + 1;
                hasilKode = kodeTerbaru.ToString();
            }
            else
            {
                //jika belum ada data maka kode pegawai diset 1
                hasilKode = "1";
            }
            return hasilKode;
        }
        #endregion
    }
}

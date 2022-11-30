using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BankDiba_LIB
{
    public class Pengguna
    {
        #region DataMembers
        private string nik;
        private string namaDepan;
        private string namaKeluarga;
        private string alamat;
        private string email;
        private string noTelepon;
        private string password;
        private string pin;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private SecurityQuestion id;
        private string answer;
        #endregion

        #region Constructors
        public Pengguna(string nik, string namaDepan, string namaKeluarga, string alamat, string email, string noTelepon, string password, string pin, 
            DateTime tglBuat, DateTime tglPerubahan, SecurityQuestion id, string answer)
        {
            Nik = nik;
            NamaDepan = namaDepan;
            NamaKeluarga = namaKeluarga;
            Alamat = alamat;
            Email = email;
            NoTelepon = noTelepon;
            Password = password;
            Pin = pin;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            Id = id;
            Answer = answer;
        }
        public Pengguna(string nik)
        {
            Nik = nik;
        }
        #endregion

        #region Properties
        public string Nik { get => nik; set => nik = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelepon { get => noTelepon; set => noTelepon = value; }
        public string Password { get => password; set => password = value; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public SecurityQuestion Id { get => id; set => id = value; }
        public string Answer { get => answer; set => answer = value; }
        #endregion

        #region Methods
        public static List<Pengguna> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, p.pin, p.tgl_buat, p.tgl_perubahan," +
                    " s.id as question_id, p.security_answer from pengguna p left join security_question as s on p.security_question_id = s.id";
            }
            else
            {
                sql = "select p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, p.pin, p.tgl_buat, p.tgl_perubahan," +
                    " s.id as question_id, p.security_answer from pengguna p left join security_question as s on p.security_question_id = s.id" +
                    " where p." + kriteria + " like '%" + nilai + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Pengguna> listPengguna = new List<Pengguna>();

            while (hasil.Read())
            {
                SecurityQuestion s = new SecurityQuestion(hasil.GetInt16(10));
                Pengguna p = new Pengguna(hasil.GetString(0), hasil.GetString(1), hasil.GetString(2), hasil.GetString(3), hasil.GetString(4), hasil.GetString(5), 
                    hasil.GetString(6), hasil.GetString(7), hasil.GetDateTime(8), hasil.GetDateTime(9), s, hasil.GetString(11));
                listPengguna.Add(p);
            }
            return listPengguna;
        }

        public static bool TambahData(Pengguna p)
        {
            string sql = "insert into pengguna(nik, nama_depan, nama_keluarga, alamat, email, no_telepon, password, pin, tgl_buat, tgl_perubahan, security_question_id, security_answer)" +
                "values('" + p.Nik + "','" + p.NamaDepan + "','" + p.NamaKeluarga + "','" + p.Alamat + "','" + p.Email + "','" + p.NoTelepon +
                "', SHA2('" + p.Password + "', 512), SHA2('" + p.Pin + "', 512),'" + p.TglBuat.ToString("yyyy-MM-dd HH:mm:ss") + "','" + p.TglPerubahan.ToString("yyyy-MM-dd HH:mm:ss") +
                "','" + p.Id.Id + "','" + p.Answer + "')";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool HapusData(Pengguna p)
        {
            string sql = "delete from pengguna where nik = '" +  p.Nik + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool UbahData(Pengguna p)
        {
            string sql = "update pengguna set email = '" + p.Email + "', pin = SHA2('" + p.Pin + "', 512), password = SHA2('" + p.Password + "',512), tgl_perubahan = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where nik = '" + p.Nik + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static Pengguna CekLogin(string username, string password)
        {
            string sql = "";
            sql = "select * from pengguna " +
                " where nama_depan='" + username + "' AND Password = SHA2('" + password + "', 512)";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                SecurityQuestion s = new SecurityQuestion(hasil.GetInt16(10));
                Pengguna p = new Pengguna(hasil.GetString(0), hasil.GetString(1), hasil.GetString(2), hasil.GetString(3), hasil.GetString(4), hasil.GetString(5),
                    hasil.GetString(6), hasil.GetString(7), hasil.GetDateTime(8), hasil.GetDateTime(9), s, hasil.GetString(11));
                return p;
            }
            return null;
        }
        #endregion
    }
}

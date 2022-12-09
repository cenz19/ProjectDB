using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BankDiba_LIB
{
    public class Tabungan
    {
        private string noRekening;
        private Pengguna pengguna;
        private double saldo;
        private string status;
        private string keterangan;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Employee verifikator;

        public Tabungan(string noRekening, Pengguna pengguna, double saldo, string status, string keterangan, DateTime tglBuat, DateTime tglPerubahan, Employee verifikator)
        {
            NoRekening = noRekening;
            Pengguna = pengguna;
            Saldo = saldo;
            Status = status;
            Keterangan = keterangan;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            Verifikator = verifikator;
        }
        public Tabungan(string noRekening, Pengguna pengguna, double saldo, string status, string keterangan, Employee verifikator)
        {
            NoRekening = noRekening;
            Pengguna = pengguna;
            Saldo = saldo;
            Status = status;
            Keterangan = keterangan;
            TglBuat = DateTime.Now;
            TglPerubahan = DateTime.Now;
            Verifikator = verifikator;
        }

        public string NoRekening { get => noRekening; set => noRekening = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee Verifikator { get => verifikator; set => verifikator = value; }

        public static List<Tabungan> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select t.*, p.*, e.*, s.*, po.* from tabungan as t " +
                    "left join pengguna as p on t.pengguna_nik = p.nik " +
                    "inner join employee as e on t.verifikator = e.id " +
                    "left join security_question as s on p.security_question_id = s.id " +
                    "inner join positions as po on e.position_id = po.id";
            }
            else
            {
                sql = "select t.*, p.*, e.*, s.*, po.* from tabungan as t " +
                    "left join pengguna as p on t.pengguna_nik = p.nik " +
                    "inner join employee as e on t.verifikator = e.id " +
                    "left join security_question as s on p.security_question_id = s.id " +
                    "inner join positions as po on e.position_id = po.id " +
                    "where " + kriteria + " like '%" + nilai + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Tabungan> listTabungan = new List<Tabungan>();
            while (hasil.Read())
            {
                SecurityQuestion s = new SecurityQuestion(hasil.GetInt16(29), hasil.GetString(30));
                
                Positions po = new Positions(hasil.GetInt16(31), hasil.GetString(32), hasil.GetString(33));
                Employee e = new Employee(hasil.GetInt16(20), hasil.GetString(21), hasil.GetString(22), po, hasil.GetString(24), hasil.GetString(25), hasil.GetString(26), hasil.GetDateTime(27), hasil.GetDateTime(28));
                Pengguna p = new Pengguna(hasil.GetString(8), hasil.GetString(9), hasil.GetString(10), hasil.GetString(11), hasil.GetString(12),
                    hasil.GetString(13), hasil.GetString(14), hasil.GetString(15), hasil.GetDateTime(16), hasil.GetDateTime(17), s, hasil.GetString(19));
                Tabungan t = new Tabungan(hasil.GetString(0), p /*6*/, hasil.GetDouble(1), hasil.GetString(2), hasil.GetString(3), hasil.GetDateTime(4), hasil.GetDateTime(5), e /*7*/);
                listTabungan.Add(t);
            }
            return listTabungan;
        }

        
        public static bool TambahData(Tabungan t)
        {
            string sql = "insert into tabungan(no_rekening, saldo, keterangan, tgl_buat, tgl_perubahan, pengguna_nik, verifikator) " +
                "values('" + t.NoRekening + "'," + 0 + ",'" + t.Keterangan + "','" + t.TglBuat.ToString("yyyy-MM-hh HH:mm:ss") + "','" + 
                t.TglPerubahan.ToString("yyyy-MM-hh HH:mm:ss") + t.pengguna.Nik + "','" + t.Verifikator.Id + "')";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static bool HapusData(Tabungan t)
        {
            string sql = "delete from tabungan where no_rekening = '" + t.NoRekening + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool UbahData(Tabungan t)
        {
            string sql = "update tabungan set saldo = " + t.Saldo + ", status = '" + t.Status + 
                "', keterangan = '" + t.Keterangan + "', tgl_Perubahan = '" + t.TglPerubahan.ToString("yyyy-MM-hh HH:mm:ss") + "' " +
                "where no_rekening = " + t.NoRekening;
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static Tabungan CariTabungan(string nilai)
        {
            List<Tabungan> listTabungan = BacaData("no_rekening", nilai);
            Tabungan t = null;
            foreach (Tabungan tabungan in listTabungan)
            {
                if (tabungan.NoRekening == nilai)
                {
                    t = tabungan;
                }
            }
            return t;
        }

        public override string ToString()
        {
            return NoRekening;
        }
    }
}

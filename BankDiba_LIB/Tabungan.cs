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
        private Employee employee;

        public Tabungan(string noRekening, Pengguna pengguna, double saldo, string status, string keterangan, DateTime tglBuat, DateTime tglPerubahan, Employee employee)
        {
            NoRekening = noRekening;
            Pengguna = pengguna;
            Saldo = saldo;
            Status = status;
            Keterangan = keterangan;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            Employee = employee;
        }

        public string NoRekening { get => noRekening; set => noRekening = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee Employee { get => employee; set => employee = value; }

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
                    "where " + kriteria + " = '" + nilai + "'";
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

        public override string ToString()
        {
            return NoRekening;
        }
    }
}

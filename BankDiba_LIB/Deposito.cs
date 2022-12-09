using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BankDiba_LIB
{
    public class Deposito
    {
        private string id;
        private string jatuhTempo;
        private double nominal;
        private double bunga;
        private string status;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Tabungan tabungan;
        private Employee verifikatorBuka;
        private Employee verifikatorCair;

        public Deposito(string id, string jatuhTempo, double nominal, double bunga, string status, DateTime tglBuat, DateTime tglPerubahan, Tabungan tabungan, Employee verifikatorBuka, Employee verifikatorCair)
        {
            Id = id;
            Tabungan = tabungan;
            JatuhTempo = jatuhTempo;
            Nominal = nominal;
            Bunga = bunga;
            Status = status;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            VerifikatorBuka = verifikatorBuka;
            VerifikatorCair = verifikatorCair;
        }

        public string Id { get => id; set => id = value; }
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public string JatuhTempo { get => jatuhTempo; set => jatuhTempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double Bunga { get => bunga; set => bunga = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee VerifikatorBuka { get => verifikatorBuka; set => verifikatorBuka = value; }
        public Employee VerifikatorCair { get => verifikatorCair; set => verifikatorCair = value; }

        public static List<Deposito> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select d.*, t.*, e1.*, p1.*, e2.*, p2.* from deposito as d " +
                    "inner join tabungan as t on d.tabungan_no_rekening = t.no_rekening " +
                    "left join employee as e1 on d.verifikator_buka = e1.id " +
                    "left join positions as p1 on e1.position_id = p1.id " +
                    "left join employee as e2 on d.verifikator_cair = e2.id " +
                    "left join positions as p2 on e2.position_id = p2.id ";
            }
            else
            {
                sql = "select d.*, t.*, e1.*, p1.*, e2.*, p2.* from deposito as d " +
                    "inner join tabungan as t on d.tabungan_no_rekening = t.no_rekening " +
                    "left join employee as e1 on d.verifikator_buka = e1.id " +
                    "left join positions as p1 on e1.position_id = p1.id " +
                    "left join employee as e2 on d.verifikator_cair = e2.id " +
                    "left join positions as p2 on e2.position_id = p2.id " + 
                    "where d." + kriteria + " like '%" + nilai + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Deposito> listDeposito = new List<Deposito>();
            while (hasil.Read())
            {
                string tabungan = hasil.GetString(7);
                Tabungan t = Tabungan.CariTabungan(tabungan);
                Positions p1 = new Positions(hasil.GetInt16(27), hasil.GetString(28), hasil.GetString(29));
                Employee e1 = new Employee(hasil.GetInt16(18), hasil.GetString(19), hasil.GetString(20), p1,
                    hasil.GetString(22), hasil.GetString(23), hasil.GetString(24), hasil.GetDateTime(25), hasil.GetDateTime(26));
                Positions p2 = new Positions(hasil.GetInt16(39), hasil.GetString(40), hasil.GetString(41));
                Employee e2 = new Employee(hasil.GetInt16(30), hasil.GetString(31), hasil.GetString(32), p2,
                    hasil.GetString(34), hasil.GetString(35), hasil.GetString(36), hasil.GetDateTime(37), hasil.GetDateTime(38));
                Deposito d = new Deposito(hasil.GetString(0), hasil.GetString(1), hasil.GetDouble(2), hasil.GetDouble(3), hasil.GetString(4), hasil.GetDateTime(5), hasil.GetDateTime(6), t, e1, e2);
                listDeposito.Add(d);
            }
            return listDeposito;
        }

        public static bool TambahData(Deposito d)
        {
            string sql = "insert into deposito(id_deposito, jatuh_tempo, nominal, bunga, status, tgl_buat, tgl_perubahan, tabungan_no_rekening, verifikator_buka, verifikator_cair) " +
                "values('" + d.Id + "','" + d.JatuhTempo + "'," + d.Nominal + "," + d.Bunga + ",'" + d.Status + "','" + d.TglBuat.ToString("yyyy-MM-hh HH:mm:ss") + "','" 
                + d.TglPerubahan.ToString("yyyy-MM-hh HH:mm:ss") + "','" + d.Tabungan.NoRekening + "'," + d.VerifikatorBuka.Id + "," + d.VerifikatorCair.Id + ")";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool HapusData(Deposito d)
        {
            string sql = "delete from deposito where id_deposito = '" + d.Id + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool UbahData(Deposito d)
        {
            string sql = "update deposito set jatuh_tempo = '" + d.JatuhTempo + "', nominal = " + d.Nominal +
                ", bunga = " + d.Bunga + ", status = '" + d.Status + "', tgl_buat = '" + d.TglBuat.ToString("yyyy-MM-hh HH:mm:ss") +
                "', tgl_perubahan = '" + d.TglPerubahan.ToString("yyyy-MM-hh HH:mm:ss") + "', tabungan_no_rekening = '" + d.Tabungan.NoRekening +
                "', verifikator_buka = " + d.verifikatorBuka.Id + ", verifikator_cair = " + d.VerifikatorCair.Id +
                " where id_deposito = " + d.Id;
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
    }
}
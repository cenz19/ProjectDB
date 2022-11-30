using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BankDiba_LIB
{
    public class Inbox
    {
        #region DataMembers
        private Pengguna pengguna;
        private int idPesan;
        private string pesan;
        private DateTime tanggalKirim;
        private string status;
        private DateTime tglPerubahan;
        #endregion

        #region Consturctors
        public Inbox(Pengguna pengguna, int idPesan, string pesan, string status)
        {
            Pengguna = pengguna;
            IdPesan = idPesan;
            Pesan = pesan;
            TanggalKirim = DateTime.Now;
            Status = status;
            TglPerubahan = DateTime.Now;
        }
        #endregion

        #region Properties
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public int IdPesan { get => idPesan; set => idPesan = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime TanggalKirim { get => tanggalKirim; set => tanggalKirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region Methods
        public static List<Inbox> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select * from inbox";
            }
            else
            {
                sql = "select * from inbox where " + kriteria + " = '" + nilai + "'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Inbox> listInbox = new List<Inbox>();
            while (hasil.Read())
            {
                Inbox i = new Inbox((Pengguna)hasil.GetValue(0), hasil.GetInt16(1), hasil.GetString(2), hasil.GetString(3));
                listInbox.Add(i);
            }
            return listInbox;
        }
        public static bool HapusData(Inbox i)
        {
            string sql = "delete from inbox where id_pesan = '" + i.IdPesan + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool UbahPesan(Inbox i, string pesan)
        {
            string sql = "update inbox set pesan = '" + pesan + "',tgl_perubahan = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "where id_pesan = " + i.pesan + " and id_pengguna = '" + i.Pengguna.Nik + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }

        public static bool TambahData(Inbox i)
        {
            string sql = "insert into inbox(id_pengguna, id_pesan, pesan, tanggal_kirim, status, tgl_perubahan) " +
                "values('" + i.pengguna.Nik + "'," + i.IdPesan + ",'" + i.Pesan + "','" + i.TanggalKirim + "','" + i.Status + "','" + i.TglPerubahan;
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        #endregion
    }
}

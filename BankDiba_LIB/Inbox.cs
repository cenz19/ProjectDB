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
        private string idPesan;
        private string pesan;
        private DateTime tanggalKirim;
        private string status;
        private DateTime tglPerubahan;
        #endregion

        #region Consturctors
        public Inbox(string idPesan, Pengguna pengguna, string pesan, string status)
        {
            Pengguna = pengguna;
            IdPesan = idPesan;
            Pesan = pesan;
            TanggalKirim = DateTime.Now;
            Status = status;
            TglPerubahan = DateTime.Now;
        }
        public Inbox(string idPesan, Pengguna pengguna, string pesan, DateTime tglKirim, string status, DateTime tglPerubahan)
        {
            Pengguna = pengguna;
            IdPesan = idPesan;
            Pesan = pesan;
            TanggalKirim = tglKirim;
            Status = status;
            TglPerubahan = tglPerubahan;
        }
        #endregion

        #region Properties
        public string IdPesan { get => idPesan; set => idPesan = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
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
                sql = "select i.*, p.*, s.* from pengguna as p left join inbox as i on p.nik = i.id_pengguna left join security_question as s on s.id = p.security_question_id";
            }
            else
            {
                sql = "select i.*, p.*, s.* from pengguna as p left join inbox as i on p.nik = i.id_pengguna left join security_question as s on s.id = p.security_question_id where i." + kriteria + " = '" + nilai + "'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Inbox> listInbox = new List<Inbox>();
            while (hasil.Read())
            {
                SecurityQuestion s = new SecurityQuestion(hasil.GetInt16(18), hasil.GetString(19));
                Pengguna p = new Pengguna(hasil.GetString(6), hasil.GetString(7), hasil.GetString(8), hasil.GetString(9), hasil.GetString(10), hasil.GetString(11), hasil.GetString(12), hasil.GetString(13), hasil.GetDateTime(14), hasil.GetDateTime(15), s, hasil.GetString(17));
                Inbox i = new Inbox(hasil.GetString(0), p, hasil.GetString(2), hasil.GetDateTime(3), hasil.GetString(4), hasil.GetDateTime(5));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankDiba_LIB
{
    public class JenisTransaksi
    {
        #region DataMembers
        private int id;
        private string kode;
        private string nama;
        #endregion

        #region Constructors
        public JenisTransaksi(int id, string kode, string nama)
        {
            Id = id;
            Kode = kode;
            Nama = nama;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region Methods
        public static List<JenisTransaksi> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from jenis_transaksi";
            }
            else
            {
                sql = "select * from jenis_transaksi where " + kriteria + " like '%" + nilai + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<JenisTransaksi> listJenis = new List<JenisTransaksi>();
            while (hasil.Read())
            {
                JenisTransaksi j = new JenisTransaksi(hasil.GetInt16(0), hasil.GetString(1), hasil.GetString(2));
                listJenis.Add(j);
            }
            return listJenis;
        }

        public static bool TambahData(JenisTransaksi j)
        {
            string sql = "insert into jenis_transaksi(id, kode, nama) values('" + j.Id  + "','" + j.Kode + "','" + j.Nama + "')";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static bool HapusData(JenisTransaksi j)
        {
            string sql = "delete from jenis_transaksi where id = " + j.Id;
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static bool UbahData(JenisTransaksi j)
        {
            string sql = "Update jenis_transaksi set kode = '" + j.Kode + "', nama = '" + j.Nama + "' where id = " + j.Id;
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        #endregion
    }
}

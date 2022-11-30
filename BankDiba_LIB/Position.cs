using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace BankDiba_LIB
{
    public class Positions
    {
        #region DataMembers
        private int id;
        private string nama;
        private string keterangan;
        #endregion

        #region Constructors
        public Positions(int id, string nama, string keterangan)
        {
            Id = id;
            Nama = nama;
            Keterangan = keterangan;
        }

        public Positions(int id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region Methods
        public static List<Positions> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select * from Positions";
            }
            else
            {
                sql = "select * from Positions where " + kriteria + " like '%" + nilai + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Positions> listPosition = new List<Positions>();
            while (hasil.Read() == true)
            {
                Positions p = new Positions(hasil.GetInt16(0), hasil.GetString(1), hasil.GetString(2));
                listPosition.Add(p);
            }
            return listPosition;
        }

        public static bool TambahData(Positions p)
        {
            string sql = "insert into Positions(id, nama, keterangan) values(" + p.Id + ",'" + p.Nama + "','" + p.Keterangan + "')";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static bool HapusData(Positions p)
        {
            string sql = "delete from pengguna where id = '" + p.Id + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        public static bool UbahData(Positions p)
        {
            string sql = "Update Positions set nama = '" + p.Nama + "', keterangan = '" + p.Keterangan + "', id = '" + p.Id+ "' where id ='" + p.Id + "'";
            int hasil = Koneksi.JalankanPerintahDML(sql);
            if (hasil >= 1) return true;
            return false;
        }
        #endregion
    }
}

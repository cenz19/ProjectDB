using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankDiba_LIB
{
    class Transaksi
    {
        private string id;
        private DateTime tglTransaksi;
        private double nominal;
        private string keterangan;
        private JenisTransaksi jenisTransaksi;
        private Tabungan sumber;
        private VirtualGiftCard giftCard;
        private Tabungan tujuan;

        public Transaksi(string id, DateTime tglTransaksi, double nominal, string keterangan, JenisTransaksi jenisTransaksi, Tabungan sumber, Tabungan tujuan, VirtualGiftCard giftCard = null)
        {
            Id = id;
            TglTransaksi = tglTransaksi;
            Nominal = nominal;
            Keterangan = keterangan;
            JenisTransaksi = jenisTransaksi;
            Sumber = sumber;
            Tujuan = tujuan;
            GiftCard = giftCard;
        }

        public string Id { get => id; set => id = value; }
        public DateTime TglTransaksi { get => tglTransaksi; set => tglTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public JenisTransaksi JenisTransaksi { get => jenisTransaksi; set => jenisTransaksi = value; }
        public Tabungan Sumber { get => sumber; set => sumber = value; }
        public Tabungan Tujuan { get => tujuan; set => tujuan = value; }
        public VirtualGiftCard GiftCard { get => giftCard; set => giftCard = value; }

        public static List<Transaksi> BacaData(string kriteria, string nilai)
        {
            string sql = "";
            if(kriteria == "")
            {
                sql = "select t.*, j.*, v.* from Transaksi as t " +
                "inner join jenis_transaksi as j on t.jenis_transaksi_id = j.id";
            }
            else
            {
                sql = "select t.*, j.*, v.* from Transaksi as t " +
                "inner join jenis_transaksi as j on t.jenis_transaksi_id = j.id" +
                "left join virtual_gift_card as v on t.virtual_gift_card_id = v.id " +
                "where t." + kriteria + " like '%" + nilai + "%'"; 
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Transaksi> listTransaksi = new List<Transaksi>();
            while (hasil.Read())
            {
                JenisTransaksi j = new JenisTransaksi(hasil.GetInt16(8), hasil.GetString(9), hasil.GetString(10));
                Tabungan sumber = Tabungan.CariTabungan(hasil.GetString(5));
                Tabungan tujuan = Tabungan.CariTabungan(hasil.GetString(6));

                VirtualGiftCard v = null;
                if (hasil.GetString(14) != null)
                {
                    Tabungan giftCardAsal = Tabungan.CariTabungan(hasil.GetString(14));
                    Tabungan giftCardTujuan = Tabungan.CariTabungan(hasil.GetString(15));
                     v = new VirtualGiftCard(hasil.GetString(11), hasil.GetDateTime(12), hasil.GetInt16(13), giftCardAsal, giftCardTujuan);
                }
                Transaksi t = new Transaksi(hasil.GetString(0), hasil.GetDateTime(1), hasil.GetDouble(2), hasil.GetString(3), j, sumber, tujuan, v);
                listTransaksi.Add(t);
            }
            return listTransaksi;
        }
    }
}

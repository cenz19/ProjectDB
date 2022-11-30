using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace BankDiba_LIB
{
    public class Koneksi
    {
        #region DataMember
        private MySqlConnection koneksiDB;
        #endregion

        #region Properties
        public MySqlConnection KoneksiDB
        {
            get => koneksiDB;
            private set => koneksiDB = value;
        }
        #endregion

        #region Methods
        public void Connect()
        {
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            MySqlDataReader hasil = c.ExecuteReader();

            return hasil;
        }

        public static int JalankanPerintahDML(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            int hasil = c.ExecuteNonQuery();
            return hasil;
        }
        #endregion

        #region Constructor
        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword)
        {
            string strCon = $"server= {pServer}; database= {pDatabase}; username= {pUsername};" +
                $" pwd= {pPassword}";

            KoneksiDB = new MySqlConnection();
            koneksiDB.ConnectionString = strCon;

            Connect();
        }

        public Koneksi()
        {
            //Buka Konfigurasi App.Config
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Ambil section userSettings yang otomatis dibuat berdasarkan file .settings
            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];

            //Ambil bagian setting SistemPenjualanPembelian.db
            var settingSection = userSettings.Sections["_160421072_VincentKurniawan.db"] as ClientSettingsSection;

            //Ambil tiap variable setting
            string DbServer = settingSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string DbPassword = settingSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;

            string strCon = $"server={DbServer};database={DbName};uid={DbUsername};" +
                $"password={DbPassword}";
            KoneksiDB = new MySqlConnection();

            KoneksiDB.ConnectionString = strCon;

            Connect();
        }
        #endregion
    }
}


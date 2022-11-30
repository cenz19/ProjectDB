using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDiba_LIB
{
    public class HistoryPassword
    {
        #region DataMembers
        private DateTime tanggalDiubah;
        private Pengguna nik;
        private string password;
        #endregion

        #region Constructors
        public HistoryPassword(DateTime tanggalDiubah, Pengguna nik, string password)
        {
            TanggalDiubah = tanggalDiubah;
            Nik = nik;
            Password = password;
        }
        #endregion
        #region Properties

        public DateTime TanggalDiubah { get => tanggalDiubah; set => tanggalDiubah = value; }
        public Pengguna Nik { get => nik; set => nik = value; }
        public string Password { get => password; set => password = value; }
        #endregion
    }
}

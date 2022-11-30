using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankDiba_LIB
{
    public class Employee
    {
        #region DataMembers
        private int id;
        private string namaDepan;
        private string namaKeluarga;
        private Positions positions;
        private string nik;
        private string email;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        #endregion

        #region Constructors
        public Employee(int id, string namaDepan, string namaKeluarga, Positions Positions, 
            string nik, string email, string password, DateTime tglBuat, DateTime tglPerubahan)
        {
            this.id = id;
            this.namaDepan = namaDepan;
            this.namaKeluarga = namaKeluarga;
            this.positions = Positions;
            this.nik = nik;
            this.email = email;
            this.password = password;
            this.tglBuat = tglBuat;
            this.tglPerubahan = tglPerubahan;
        }
        #endregion
        #region Properties
        public int Id { get => id; set => id = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public Positions Positions { get => positions; set => positions = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion
    }
}

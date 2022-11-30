using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BankDiba_LIB
{
    public class SecurityQuestion
    {
        #region DataMembers
        private int id;
        private string question;
        #endregion

        #region Constructors
        public SecurityQuestion(int id, string question)
        {
            Id = id;
            Question = question;
        }
        public SecurityQuestion(int id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Id.ToString();
        }

        public static List<SecurityQuestion> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from security_question";
            }
            else
            {
                sql = "select * from security_question where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<SecurityQuestion> listQuestion = new List<SecurityQuestion>();
            while (hasil.Read() == true)
            {
                SecurityQuestion s = new SecurityQuestion(hasil.GetInt16(0), hasil.GetValue(1).ToString());
                listQuestion.Add(s);
            }
            return listQuestion;
        }
        #endregion

    }
}

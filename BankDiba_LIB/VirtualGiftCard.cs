using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDiba_LIB
{
    public class VirtualGiftCard
    {
        private string code;
        private DateTime kadaluarsa;
        private int limit;
        private Tabungan asal;
        private Tabungan tujuan;

        public VirtualGiftCard(string code, DateTime kadaluarsa, int limit, Tabungan asal, Tabungan tujuan)
        {
            Code = code;
            Kadaluarsa = kadaluarsa;
            Limit = limit;
            Asal = asal;
            Tujuan = tujuan;
        }

        public string Code { get => code; set => code = value; }
        public DateTime Kadaluarsa { get => kadaluarsa; set => kadaluarsa = value; }
        public int Limit { get => limit; set => limit = value; }
        public Tabungan Asal { get => asal; set => asal = value; }
        public Tabungan Tujuan { get => tujuan; set => tujuan = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo1
{
    public static class Contra
    {
        private static int Asc(string WLet)
        {
            if (WLet.Length == 0) return 0;
            int nAsc = (int)Convert.ToChar(WLet);
            return nAsc;
        }
        private static string Hex(string WHnd)
        {
            int nWord = Convert.ToInt32(WHnd); string WHex = String.Format("{0:X}", nWord);
            return WHex;
        }
        public static string X_FNCdHx(this string v, string WHnd)
        {
            String Wrd = ""; String WCar = ""; int nKey = 31; char CPad = '0';
            for (int J = 0; J <= WHnd.Length - 1; J++)
            {
                WCar = WHnd.Substring(J, 1); int nAsc = Asc(WCar) * nKey; string WHex = Hex(nAsc.ToString());
                Wrd = Wrd + WHex.PadLeft(4, CPad);
            }
            return Wrd;
        }
        public static string X_FNDcHx(this string V, string WHnd)
        {
            String Wrd = ""; String WCar = ""; int nKey = 31; int J = 0;
            while (J < WHnd.Length)
            {
                WCar = WHnd.Substring(J, 4); string XCar = WCar; int nHNum = Int32.Parse(XCar, System.Globalization.NumberStyles.HexNumber); int nChr = nHNum / nKey; Wrd = Wrd + Convert.ToChar(nChr);
                J = J + 4;
            }
            return Wrd;
        }
    }
}

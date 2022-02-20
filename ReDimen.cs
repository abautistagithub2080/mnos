using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01_SP_BG
{
    class ReDimen
    {
        private string[,] c = new string[7, 1]; public string[,] aRes = new string[7, 1]; 
        public void taga(Control ct, long w, long h)
        {
            int k = 0; int nTotal = 0;
            foreach (Control ctl in ct.Controls)
            {
                if (ctl.Name == "") break;
                k = c.GetUpperBound(1);
                var oldC = c;
                c = new string[7, k + 1 + 1];
                if (oldC != null)
                    for (int i = 0; i <= oldC.Length / oldC.GetLength(1) - 1; ++i)
                        Array.Copy(oldC, i * oldC.GetLength(1), c, i * c.GetLength(1), Math.Min(oldC.GetLength(1), c.GetLength(1)));
                c[0, k + 1] = ctl.Name;
                c[1, k + 1] = ctl.Left.ToString();
                c[2, k + 1] = ctl.Top.ToString();
                c[3, k + 1] = ctl.Width.ToString();
                c[4, k + 1] = ctl.Height.ToString();
                c[5, k + 1] = ctl.Font.Size.ToString();
                c[6, k + 1] = ctl.Font.Style.ToString();
                nTotal = ctl.Controls.Count;
                if (nTotal > 0) taga(ctl, ctl.Width, ctl.Height);
            }            
            aRes = (string[,]) c.Clone();            
        }

        public void mudar(Control cm, string s, int n, double x, double y)
        {
            double dPos = 0;
            foreach (Control ct in cm.Controls)
            {
                if (ct.Name == s)
                {
                    ct.Left = Convert.ToInt16(Convert.ToDouble(aRes[1, n]) * x);
                    ct.Top = Convert.ToInt16(Convert.ToDouble(aRes[2, n]) * y);
                    ct.Width = Convert.ToInt16(Convert.ToDouble(aRes[3, n]) * x);
                    ct.Height = Convert.ToInt16(Convert.ToDouble(aRes[4, n]) * y);
                    dPos = x < y ? x : y;
                    if (dPos > 0) ct.Font = new System.Drawing.Font(ct.Font.Name, Convert.ToInt16(Convert.ToDouble(aRes[5, n]) * dPos));
                    break;
                }
                else
                    mudar(ct, s, n, x, y);
            }
        }
    }
}

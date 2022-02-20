using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _01_SP_BG
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new FrmContra());
        }
    }
}

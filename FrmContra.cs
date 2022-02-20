using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01_SP_BG
{
    public partial class FrmContra : Form
    {
        public FrmContra()
        {
            InitializeComponent();
        }

        private void FrmContra_Load(object sender, EventArgs e)
        {
            string SP = "123";
            Console.WriteLine(SP);
            SP = null;
        }

        private void FrmContra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Controls.Clear(); this.Dispose();
            GC.SuppressFinalize(this); GC.Collect(); GC.WaitForPendingFinalizers();
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Demo1;

namespace _01_SP_BG
{
    public partial class Form7 : Form
    {
        string IDInv = "3";
        private string[,] c = new string[7, 1];
        private long xx, yy;
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tools oTool = new Tools();
            oTool.DevRootDB();
            if (!textBox1.Enabled) return;
            int nTotal = Convert.ToInt16(label1.Text) - Convert.ToInt16(textBox1.Text);
            string WSQL = "UPDATE tblInv SET Disponible ='" + nTotal  + "' WHERE IDInv=" + IDInv;
            oTool.SaveDato(WSQL);            
            WSQL = "INSERT INTO tblTransac(IDInv, Cantidad) VALUES(" + IDInv + ", " + textBox1.Text + ")";
            oTool.SaveDato(WSQL);
            oTool.Dispose(); oTool = null;
            SPCargaInv();
            textBox1.Text = "";
            if (nTotal == 0) {
                MessageBox.Show("Agotado!!!!");
                textBox1.Enabled = false;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ReDimen oReDim = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height; oReDim.taga(this, xx, yy); c = (string[,])oReDim.aRes.Clone();
            SPCargaInv();
        }

        private void SPCargaInv() {
            Tools oTool = new Tools();
            oTool.DevRootDB();
            string nDisp = "";
            string SQL = "SELECT * FROM tblInv WHERE IDInv=" + IDInv;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                nDisp = rBcs["Disponible"].ToString();
            }
            if (nDisp == "0") textBox1.Enabled = false;
            label1.Text = nDisp;
            rBcs.Close(); rBcs.Dispose(); rBcs = null;
            oTool.Dispose(); oTool = null;
        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen oReDim = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            oReDim.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) oReDim.mudar(this, c[0, j], j, sX, sY);
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            //label1.Dispose(); label1 = null;
            //textBox1.Dispose(); textBox1 = null;
            //button1.Dispose(); button1 = null;
            Array.Clear(c, 0, c.Length); c = null;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(Controls[i].Name);
                Controls[i].Dispose();
            }
        }
    }
}

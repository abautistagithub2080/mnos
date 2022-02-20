using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;  
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _01_SP_BG;

namespace Demo1
{
    public partial class Form2 : Form
    {
        string WIDBcs = ""; string RSQL = "";
        private string[,] c = new string[7, 1]; private long xx, yy;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Tools oTool = new Tools();
            ReDimen oReDim = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height; oReDim.taga(this, xx, yy); c = (string[,])oReDim.aRes.Clone();
            string SQL = "SELECT TOP 1 '0' AS IdMsc, '  ----NUEVO----' AS Nombre FROM tblMusica UNION SELECT IdMsc, Nombre FROM tblMusica ORDER BY IdMsc ASC;"; oTool.FillCbx(SQL, "IdMsc", "Nombre", ref cbxBcs); RSQL = SQL;
            oTool.Dispose(); oTool = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            string WBanco = txtBcs.Text.Trim().Replace("'","");
            string WLink = txtLink.Text.Trim().Replace("'", "");
            string WDesc = txtDesc.Text.Trim().Replace("'", "");            
            DateTime DFecha = DateTime.Now;  
            if (WBanco == "" || WBanco.Length ==0) return;
            string SQL = (WIDBcs == "0" ? "INSERT INTO tblMusica(Nombre, Link, Descrip,Fecha) VALUES('" + WBanco + "','" + WLink + "','" + WDesc + "','" + DFecha + "')" : "UPDATE tblMusica SET Nombre='" + WBanco + "', Link='" + WLink + "', Descrip='" + WDesc + "', Fecha='"+ DFecha +"' WHERE IdMsc=" + WIDBcs);
            Tools oTool = new Tools();
            oTool.SaveDato(SQL); SQL = RSQL;
            oTool.FillCbx(SQL, "IdMsc", "Nombre", ref cbxBcs); LimpiaTxt();
            oTool.Dispose(); oTool = null;
        }

        private void LimpiaTxt() {
            txtBcs.Text = ""; txtLink.Text = ""; txtDesc.Text = "";
        }

        private void cbxBcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            WIDBcs = cbxBcs.SelectedValue.ToString(); string WBcs = ""; string WLink = ""; string WDesc = "";
            if (WIDBcs == "0")
            {
                LimpiaTxt(); return;
            }
            string SQL = "SELECT * FROM tblMusica WHERE IdMsc=" + WIDBcs;
            Tools oTool = new Tools();
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read()) {
                WBcs = rBcs[1].ToString(); WLink = rBcs[2].ToString(); WDesc = rBcs[3].ToString();
            }
            txtBcs.Text = WBcs; txtLink.Text = WLink; txtDesc.Text = WDesc;
            rBcs.Close(); rBcs.Dispose(); rBcs = null;
            oTool.Dispose(); oTool = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (WIDBcs == "0") return;
            string SQL = "";
            Tools oTool = new Tools();
            if (MessageBox.Show("¿Deseas Eliminar dicho registro?", "Confirmacion de eleminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQL = "DELETE FROM tblMusica WHERE IdMsc=" + WIDBcs; oTool.SaveDato(SQL);
            }
            LimpiaTxt(); SQL = RSQL; oTool.FillCbx(SQL, "IdMsc", "Nombre", ref cbxBcs);
            oTool.Dispose(); oTool = null;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Array.Clear(c, 0, c.Length); c = null;
            AddTextChangedHandler(this);
            //for (int i = Controls.Count - 1; i >= 0; i--)
            //{
            //    Controls[i].Dispose();
            //}

            //Controls.Clear();

            //oTool.Dispose(); oTool = null;
        }


        private void AddTextChangedHandler(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                //Console.WriteLine(c.ToString());
                //Controls[c.Name].Dispose();
                DD(c.Name);
                AddTextChangedHandler(c);

            }
        }

        private void DD(string WControl) {
            Console.WriteLine(WControl);
            Controls[WControl].Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string XX = "";
            string PP = XX.X_FNCdHx("Queobolas");
            MessageBox.Show(PP);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen oReDim = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            oReDim.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) oReDim.mudar(this, c[0, j], j, sX, sY);
        }

    }
}
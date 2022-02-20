using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using Demo1;

namespace _01_SP_BG
{
    public partial class Form5 : Form
    {
        Tools oTool = new Tools();
        string WIDBcs = ""; string RSQL = "";
        private string[,] c = new string[7, 1];
        private long xx, yy;
        public Form5()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tools oFN = new Tools();
            string WNomCor = txtNomCorto.Text;
            string WNom = oFN.FNCdHx(txtNom.Text);
            string WCel = oFN.FNCdHx(txtCel.Text);
            string WDesc = oFN.FNCdHx(txtDesc.Text);
            oFN = null;
            string DFecha = DateTime.Now.ToString();
            if (WNomCor == "" || WNomCor.Length == 0) return;
            string WSQLI = "INSERT INTO tblContactoSP(NombreCorto, Nombre, Celular, Descripcion, Fecha) VALUES('" + WNomCor + "','" + WNom + "', '" + WCel + "', '" + WDesc + "', '" + DFecha + "')";
            string WSQLU = "UPDATE tblContactoSP SET NombreCorto='" + WNomCor + "', Nombre='" + WNom + "', Celular='" + WCel + "', Descripcion='" + WDesc + "', Fecha='" + DFecha + "' WHERE IdContacto=" + WIDBcs;
            string SQL = (WIDBcs == "0" ? WSQLI : WSQLU);
            oTool.SaveDato(SQL); SQL = RSQL;
            oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto); LimpiaTxt();            
        }

        private void LimpiaTxt()
        {

            txtNomCorto.Text = ""; txtNom.Text = ""; txtCel.Text = ""; txtDesc.Text = "";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ReDimen oReDim = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height; oReDim.taga(this, xx, yy); c = (string[,])oReDim.aRes.Clone();
            oTool.DevRootDB();
            string SQL = "SELECT TOP 1 '0' AS IdContacto, '  ----NUEVO----' AS NombreCorto FROM tblContactoSP UNION SELECT IdContacto, NombreCorto FROM tblContactoSP ORDER BY IdContacto ASC;"; oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto); RSQL = SQL;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (WIDBcs == "0") return;
            string SQL = "";
            if (MessageBox.Show("¿Deseas Eliminar dicho registro?", "Confirmacion de eleminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQL = "DELETE FROM tblContactoSP WHERE IdContacto=" + WIDBcs; oTool.SaveDato(SQL);
            }
            LimpiaTxt(); SQL = RSQL; oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto);
        }

        private void cbxContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            WIDBcs = cbxContacto.SelectedValue.ToString(); string WNomCor = ""; string WNom = ""; 
            string WCel = ""; string WDesc = "";
            if (WIDBcs == "0")
            {
                LimpiaTxt(); return;
            }

            string SQL = "SELECT * FROM tblContactoSP WHERE IdContacto=" + WIDBcs;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                WNomCor = rBcs["NombreCorto"].ToString(); WNom = rBcs[2].ToString(); 
                WCel = rBcs[3].ToString(); WDesc = rBcs[4].ToString();
            }

            Tools oFN = new Tools();
            txtNomCorto.Text = WNomCor; txtNom.Text = oFN.FNDcHx(WNom); 
            txtCel.Text = oFN.FNDcHx(WCel); txtDesc.Text = oFN.FNDcHx(WDesc);
            oFN = null;
            rBcs.Close(); rBcs.Dispose();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AddTextChangedHandler(this);
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Dispose(); tableLayoutPanel1 = null;
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.Dispose(); tableLayoutPanel2 = null;
            Array.Clear(c, 0, c.Length); c = null;
        }


        private void AddTextChangedHandler(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                DD(c.Name);
                AddTextChangedHandler(c);

            }
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen oReDim = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            oReDim.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) oReDim.mudar(this, c[0, j], j, sX, sY);
        }

        private void DD(string WControl)
        {
            Console.WriteLine(WControl);
            Controls[WControl].Dispose();
        }


    }
}

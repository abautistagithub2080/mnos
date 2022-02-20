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
    public partial class Form4 : Form
    {
        Tools oTool = new Tools();
        string WIDBcs = ""; string RSQL = "";
        private string[,] c = new string[7, 1]; private long xx, yy;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ReDimen oReDim = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height;
            oReDim.taga(this, xx, yy); c = (string[,])oReDim.aRes.Clone();
            string SQL = "SELECT TOP 1 '0' AS IdContacto, '  ----NUEVO----' AS NombreCorto FROM tblContacto UNION SELECT IdContacto, NombreCorto FROM tblContacto ORDER BY IdContacto ASC;"; oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto); RSQL = SQL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tools oFN = new Tools(); 
            string WNomCor = txtNomCorto.Text;
            string WNom = oFN.FNCdHx(txtNom.Text);
            string WPat = oFN.FNCdHx(txtPat.Text);
            string WMat = oFN.FNCdHx(txtMat.Text);
            string WMail = oFN.FNCdHx(txtEmail.Text);
            string WTel = oFN.FNCdHx(txtTele.Text);
            string WCel = oFN.FNCdHx(txtCel.Text);
            string WDesc = oFN.FNCdHx(txtDesc.Text);
            oFN.Dispose(); oFN = null;
            string DFecha = DateTime.Now.ToString();
            if (WNomCor == "" || WNomCor.Length == 0) return;
            string WSQLI = "INSERT INTO tblContacto(NombreCorto, Nombre, Paterno, Materno, Email, Telefono, Celular, Descripcion, Fecha) VALUES('" + WNomCor + "','" + WNom + "','" + WPat + "','" + WMat + "','" + WMail + "', '" + WTel + "', '" + WCel + "', '" + WDesc  + "', '" + DFecha + "')";
            string WSQLU = "UPDATE tblContacto SET NombreCorto='" + WNomCor + "', Nombre='" + WNom + "', Paterno='" + WPat + "', Materno='" + WMat + "', Email='" + WMail + "', Telefono='" + WTel + "', Celular='" + WCel + "', Descripcion='" + WDesc + "', Fecha='" + DFecha + "' WHERE IdContacto=" + WIDBcs;
            string SQL = (WIDBcs == "0" ? WSQLI : WSQLU);
            oTool.SaveDato(SQL); SQL = RSQL;
            oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto); LimpiaTxt();
        }

        private void LimpiaTxt()
        {

            txtNomCorto.Text=""; txtNom.Text = ""; txtPat.Text = "";  txtMat.Text = ""; txtEmail.Text = ""; txtTele.Text = "";
            txtCel.Text = ""; txtDesc.Text = "";           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (WIDBcs == "0") return;
            string SQL = "";
            if (MessageBox.Show("¿Deseas Eliminar dicho registro?", "Confirmacion de eleminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQL = "DELETE FROM tblContacto WHERE IdContacto=" + WIDBcs; oTool.SaveDato(SQL);
            }
            LimpiaTxt(); SQL = RSQL; oTool.FillCbx(SQL, "IdContacto", "NombreCorto", ref cbxContacto);
        }

        private void cbxContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            WIDBcs = cbxContacto.SelectedValue.ToString(); string WNomCor = ""; string WNom = ""; string WPat = ""; string WMat = "";
            string WMail = ""; string WTel = ""; string WCel = ""; string WDesc = "";
            if (WIDBcs == "0")
            {
                LimpiaTxt(); return;
            }

            string SQL = "SELECT * FROM tblContacto WHERE IdContacto=" + WIDBcs;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                WNomCor = rBcs["NombreCorto"].ToString(); WNom = rBcs[2].ToString();  WPat = rBcs[3].ToString();  WMat = rBcs[4].ToString();
                WMail = rBcs[5].ToString(); WTel = rBcs[6].ToString();  WCel = rBcs[7].ToString(); WDesc = rBcs[8].ToString();
            }

            Tools oFN = new Tools(); 
            txtNomCorto.Text = WNomCor; txtNom.Text = oFN.FNDcHx(WNom); txtPat.Text = oFN.FNDcHx(WPat); txtMat.Text = oFN.FNDcHx(WMat); txtEmail.Text = oFN.FNDcHx(WMail); txtTele.Text = oFN.FNDcHx(WTel);
            txtCel.Text = oFN.FNDcHx(WCel); txtDesc.Text = oFN.FNDcHx(WDesc);
            oFN.Dispose(); oFN = null;
            rBcs.Close(); rBcs.Dispose(); rBcs = null;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {            
            Array.Clear(c, 0, c.Length); c = null;
            for (int i = Controls.Count - 1; i >= 0; i--) Controls[i].Dispose();
            Controls.Clear();
            oTool.Dispose(); oTool = null;
        }

        private void AddTextChangedHandler(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                DD(c.Name);
                AddTextChangedHandler(c);

            }
        }

        private void DD(string WControl)
        {
            Console.WriteLine(WControl);
            Controls[WControl].Dispose();
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen oReDim = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            oReDim.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) oReDim.mudar(this, c[0, j], j, sX, sY);
        }

    }
}

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
    public partial class Form3 : Form
    {
        Tools oTool = new Tools();
        string WIDBcs = ""; string RSQL = "";
        private string[,] c = new string[7, 1]; private long xx, yy;
        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            ReDimen PP = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height;
            PP.taga(this, xx, yy); c = (string[,]) PP.aRes.Clone();
            string SQL = "SELECT TOP 1 '0' AS IdContactoUsr, '  ----NUEVO----' AS Cuenta FROM tblContactoUsr UNION SELECT IdContactoUsr, Cuenta FROM tblContactoUsr ORDER BY IdContactoUsr ASC;"; oTool.FillCbx(SQL, "IdContactoUsr", "Cuenta", ref cbxContactoUsr); RSQL = SQL;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tools oFN = new Tools(); 
            string WCuenta = txtCuenta.Text;
            string WUsuario = oFN.FNCdHx(txtUsuario.Text);
            string WPass = oFN.FNCdHx(txtPass.Text);
            string WDesc = oFN.FNCdHx(txtDescrip.Text);
            oFN = null;
            string DFecha = DateTime.Now.ToString();
            if (WCuenta == "" || WCuenta.Length == 0) return;
            string SQL = (WIDBcs == "0" ? "INSERT INTO tblContactoUsr(Usuario, Contrasenia, Cuenta, Descripcion, Fecha) VALUES('" + WUsuario + "','" + WPass + "','" + WCuenta + "','" + WDesc + "','" + DFecha + "')" : "UPDATE tblContactoUsr SET Usuario='" + WUsuario + "', Contrasenia='" + WPass + "', Cuenta='" + WCuenta + "', Descripcion='" + WDesc + "', Fecha='" + DFecha + "' WHERE IdContactoUsr=" + WIDBcs);
            oTool.SaveDato(SQL); SQL = RSQL;
            oTool.FillCbx(SQL, "IdContactoUsr", "Usuario", ref cbxContactoUsr); LimpiaTxt();
        }

        private void LimpiaTxt(){
            txtCuenta.Text = ""; txtDescrip.Text = ""; txtPass.Text = ""; txtUsuario.Text = "";
        }

        private void cbxContactoUsr_SelectedIndexChanged(object sender, EventArgs e)
        {
            WIDBcs = cbxContactoUsr.SelectedValue.ToString(); string WUsr = ""; string WContra = ""; string WCuenta = ""; string WDesc = "";
            if (WIDBcs == "0")
            {
                LimpiaTxt(); return;
            }
            string SQL = "SELECT * FROM tblContactoUsr WHERE IdContactoUsr=" + WIDBcs;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                WUsr = rBcs[1].ToString();
                WContra = rBcs[2].ToString();
                WCuenta = rBcs[3].ToString();
                WDesc = rBcs[4].ToString();
            }
            Tools oFN = new Tools(); 
            txtUsuario.Text = oFN.FNDcHx(WUsr);
            txtPass.Text  = oFN.FNDcHx(WContra);
            txtCuenta.Text = WCuenta;
            txtDescrip.Text = oFN.FNDcHx(WDesc);
            oFN = null;
            rBcs.Close(); rBcs.Dispose(); 
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (WIDBcs == "0") return;
            string SQL = "";
            if (MessageBox.Show("¿Deseas Eliminar dicho registro?", "Confirmacion de eleminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQL = "DELETE FROM tblContactoUsr WHERE IdContactoUsr=" + WIDBcs; oTool.SaveDato(SQL);
            }
            LimpiaTxt(); SQL = RSQL; oTool.FillCbx(SQL, "IdContactoUsr", "Usuario", ref cbxContactoUsr);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            oTool.Dispose(); oTool = null; Array.Clear(c, 0, c.Length); c = null;
            for (int i = this.Controls.Count - 1; i >= 0; i--) Controls[i].Dispose();
            this.Dispose();
        }
        
        private void Form3_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen PP = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            PP.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) PP.mudar(this, c[0, j], j, sX, sY);                
        }
    }
}

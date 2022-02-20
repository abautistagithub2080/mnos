using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Demo1;

namespace _01_SP_BG
{
    public partial class Form6 : Form
    {

        string WIDBcs = ""; string RSQL = ""; bool bEsGuardar = false;
        private string[,] c = new string[7, 1];
        private long xx, yy;
        public Form6()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string SQL = ""; bool SiSave = false;
            Tools oFN = new Tools();
            string WNomFile = txtNomFile.Text;
            string WDesc = txtDesc.Text;
            string DFecha = DateTime.Now.ToString();
            if (WNomFile == "" || WNomFile.Length == 0) return;
            string WRutaX = txtRuta.Text; 
            if (cbxFiles.SelectedIndex != 0 && !bEsGuardar)
            {
                SQL = "UPDATE tblFiles SET NombreFile='"+ WNomFile +"', Descripcion='"+ WDesc +"', Fecha='" + DFecha + "' WHERE IdFiles =" + cbxFiles.SelectedValue;
                oFN.SaveDato(SQL); SiSave = true;
            }
            else if (cbxFiles.SelectedIndex != 0 && bEsGuardar) {
                SQL = "UPDATE tblFiles SET NombreFile=?, Descripcion=?, Fecha=?, Files=? WHERE IdFiles =" + cbxFiles.SelectedValue;
                SiSave = oFN.FNSveFile(WRutaX, SQL, "@NombreFile|@Descr|@Fecha", WNomFile, WDesc, DFecha);
            }           
            else
            {
                SQL = "INSERT INTO tblFiles(NombreFile, Descripcion, Fecha, Files) VALUES (?, ?, ?, ?)";
                SiSave = oFN.FNSveFile(WRutaX, SQL, "@NombreFile|@Descr|@Fecha", WNomFile, WDesc, DFecha);
            }
            SQL = "SELECT TOP 1 '0' AS IdFiles, '  ----NUEVO----' AS NombreFile FROM tblFiles UNION SELECT IdFiles, NombreFile FROM tblFiles ORDER BY IdFiles ASC;"; oFN.FillCbx(SQL, "IdFiles", "NombreFile", ref cbxFiles); RSQL = SQL;
            oFN.Dispose(); oFN = null; bEsGuardar = false;
            LimpiaTxt();
            if (!SiSave) MessageBox.Show("Fallo el Guardado..."); 
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Tools oTool = new Tools();
            ReDimen oReDim = new ReDimen();
            xx = this.ClientSize.Width; yy = this.ClientSize.Height; oReDim.taga(this, xx, yy); c = (string[,])oReDim.aRes.Clone();
            string SQL = "SELECT TOP 1 '0' AS IdFiles, '  ----NUEVO----' AS NombreFile FROM tblFiles UNION SELECT IdFiles, NombreFile FROM tblFiles ORDER BY IdFiles ASC;"; oTool.FillCbx(SQL, "IdFiles", "NombreFile", ref cbxFiles); RSQL = SQL;
            oTool.Dispose(); oTool = null;
        }

        private void cbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tools oTool = new Tools();
            WIDBcs = cbxFiles.SelectedValue.ToString();
            if (WIDBcs == "0")
            {
                LimpiaTxt(); return;
            }
            string SQL = "SELECT NombreFile, Descripcion FROM tblFiles WHERE IdFiles=" + WIDBcs;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                txtNomFile.Text = rBcs["NombreFile"].ToString(); txtDesc.Text = rBcs["Descripcion"].ToString();
            }
            oTool.Dispose(); oTool = null;
        }

        private void LimpiaTxt() {

            txtDesc.Text = ""; txtNomFile.Text = ""; txtRuta.Text = "";  cbxFiles.SelectedIndex = 0;
        }

        private void btnDevSource_Click(object sender, EventArgs e)
        {
            bEsGuardar = true;           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string WRuta = openFileDialog1.FileName;
            txtNomFile.Text = FNDevFile(WRuta);
            txtRuta.Text = WRuta;
            ((IDisposable)openFileDialog1).Dispose();
            openFileDialog1 = null;
            GC.SuppressFinalize(this); GC.Collect(); GC.WaitForPendingFinalizers();
        }
        
        private void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally {
                o = null;
            }
        }

        private string FNDevFile(string WRuta) {
            string[] oRuta = WRuta.Split('\\');
            int nRuta = oRuta.Count()-1;
            string WFile = oRuta[nRuta].ToString();
            Array.Clear(oRuta, 0, oRuta.Length - 1); oRuta = null;
            return WFile;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.FileName = txtNomFile.Text;
            SaveFileDialog1.ShowDialog(); string WFile = SaveFileDialog1.FileName;
            Tools oFN = new Tools();
            string SQL = "SELECT * FROM tblFiles WHERE IdFiles=" + cbxFiles.SelectedValue;
            bool bWrite = oFN.FNWteFile(WFile, SQL);
            oFN.Dispose(); oFN = null;
            SaveFileDialog1.Dispose(); SaveFileDialog1 = null;
            if (bWrite) MessageBox.Show("Se guardo correctamente");
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Array.Clear(c, 0, c.Length); c = null;
            for (int i = Controls.Count - 1; i >= 0; i--) Controls[i].Dispose(); 
            Controls.Clear();
            //GC.Collect(); GC.WaitForPendingFinalizers();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (WIDBcs == "0") return;
            string SQL = "";
            Tools oTool = new Tools();
            if (MessageBox.Show("¿Deseas Eliminar dicho registro?", "Confirmacion de eleminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQL = "DELETE FROM tblFiles WHERE IdFiles=" + WIDBcs; oTool.SaveDato(SQL);
            }
            LimpiaTxt(); SQL = RSQL;
            oTool.FillCbx(SQL, "IdFiles", "NombreFile", ref cbxFiles);
            oTool.Dispose(); oTool = null;
        }
        
        private void Form6_Resize(object sender, EventArgs e)
        {
            double sX, sY; int j; ReDimen oReDim = new ReDimen();
            sX = this.ClientSize.Width / (double)xx; sY = this.ClientSize.Height / (double)yy;
            oReDim.aRes = (string[,])c.Clone();
            for (j = 1; j <= c.GetUpperBound(1); j++) oReDim.mudar(this, c[0, j], j, sX, sY);
        }
    }
}

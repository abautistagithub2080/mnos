using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace Demo1
{
    class Tools
    {
        
        bool disposed = false;  public string WDB = ""; public string WMsg = ".";
        public OleDbDataReader RD = null; public OleDbConnection DB = null; OleDbCommand cmd = null;

        public void FillGrid(string SQL, ref DataGridView DGV)            
        {            
            OleDbConnection DB = new OleDbConnection(WDB); OleDbCommand cmd = new OleDbCommand(SQL, DB); cmd.CommandType = CommandType.Text;
            DataTable DT = new DataTable(); OleDbDataAdapter da = new OleDbDataAdapter(cmd); da.Fill(DT); DGV.DataSource = DT;
            DT.Dispose(); cmd.Dispose(); da.Dispose(); DB.Close(); DB.Dispose();
        }
        public void FillCbx(string SQL, string WID, string WValue, ref  ComboBox cbx)
        {
            cmd = FNCMD(SQL);            
            DataTable DT = new DataTable(); OleDbDataAdapter da = new OleDbDataAdapter(cmd); da.Fill(DT); cbx.ValueMember = WID; cbx.DisplayMember = WValue; cbx.DataSource = DT;
            cmd.Dispose(); cmd=null; da.Dispose(); da = null; DB.Close(); DB.Dispose(); DB = null;
        }
        public OleDbDataReader FNRdrSP(string WSP, string WPar, params string[] oVal)
        {
            OleDbDataReader RD = null; char CLim = '|';
            OleDbConnection DB = new OleDbConnection(WDB); DB.Open(); OleDbCommand cmd = new OleDbCommand(WSP, DB); cmd.CommandType = CommandType.StoredProcedure; string[] oPars = WPar.Split(CLim);
            for (int K = 0; K <= oVal.Length - 1; K++) cmd.Parameters.AddWithValue(oPars[K], oVal[K]);
            RD = cmd.ExecuteReader(CommandBehavior.CloseConnection); return RD;
        }
        public bool FNSveFile(string WRutaFile,string WSP, string WPar, params string[] oVal)
        {
            try 
            {
                FileStream fs = new FileStream(@WRutaFile, FileMode.Open, FileAccess.Read);
                byte[] b = new byte[fs.Length - 1 + 1];
                fs.Read(b, 0, b.Length);
                fs.Close(); fs.Dispose(); fs = null;                
                cmd = FNCMD(WSP);
                char CLim = '|'; string[] oPars = WPar.Split(CLim);
                for (int K = 0; K <= oVal.Length - 1; K++) cmd.Parameters.AddWithValue(oPars[K], oVal[K]);      
                OleDbParameter P = new OleDbParameter("@File", OleDbType.LongVarBinary, b.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, b);
                cmd.Parameters.Add(P); cmd.ExecuteNonQuery(); P = null;
                Array.Clear(oPars, 0, oPars.Length); oPars = null; Array.Clear(b, 0, b.Length); b = null; Array.Clear(oVal, 0, oVal.Length); oVal = null;
                cmd.Dispose(); cmd = null;
                DB.Close(); DB.Dispose(); DB = null;  
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e); return false;
            }
        }

        public bool FNWteFile(string WRutaFile, string SQL)
        {
            try
            {
                OleDbDataReader RD = FNRdr(SQL); RD.Read();
                byte[] b = new byte[RD.GetBytes(4, 0, null, 0, int.MaxValue) - 1 + 1];
                RD.GetBytes(4, 0, b, 0, b.Length);
                FileStream fs = new FileStream(@WRutaFile, FileMode.Create, FileAccess.Write);
                fs.Write(b, 0, b.Length);
                RD.Close(); RD.Dispose(); RD = null;
                Array.Clear(b, 0, b.Length); b = null;
                fs.Close(); fs.Dispose(); fs = null;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e); return false;
            }
        }

        public void SaveDato(string SQL)
        {
            OleDbCommand cmd = FNCMD(SQL); cmd.ExecuteNonQuery(); cmd.Dispose(); cmd = null; DB.Close(); DB.Dispose(); DB = null;
        }
        public void DevRootDB() {
            string WRuta = Application.StartupPath; WDB = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + WRuta + "\\DBSP.JSN; Jet OLEDB:Database Password="+ FNContraXML(WRuta) +";";            
            //WDB = "Provider=SQLNCLI11;Data Source=LENOVO-PC;User ID=sa;Initial Catalog=DemoDKT; Password=12345;"; 
        }
        private string FNContraXML(string WRuta)
        {
            XmlDocument xDoc = new XmlDocument(); xDoc.Load(WRuta + "\\BILO.xml"); string WDat = "";
            XmlNodeList xPersonas = xDoc.GetElementsByTagName("Pass"); XmlNodeList xLista = ((XmlElement)xPersonas[0]).GetElementsByTagName("Contra");
            foreach (XmlElement nodo in xLista) WDat = nodo.InnerText; 
            xLista = null; xPersonas = null; xDoc = null;
            return WDat;
        }

        public OleDbCommand FNCMD(string SQL)
        {
            DevRootDB(); DB = new OleDbConnection(WDB); DB.Open(); cmd = DB.CreateCommand(); cmd.CommandText = SQL;
            return cmd;
        }
        public OleDbDataReader FNRdr(string SQL)
        {
            RD = FNCMD(SQL).ExecuteReader(CommandBehavior.CloseConnection); return RD;
        }

        public int Asc(string WLet)
        {
            if (WLet.Length == 0) return 0;
            int nAsc = (int)Convert.ToChar(WLet);
            return nAsc;
        }
        public string Hex(string WHnd)
        {
            int nWord = Convert.ToInt32(WHnd); string WHex = String.Format("{0:X}", nWord);
            return WHex;
        }
        public string FNCdHx(string WHnd)
        {
            String Wrd = ""; String WCar = ""; int nKey = 31; char CPad = '0';
            for (int J = 0; J <= WHnd.Length - 1; J++)
            {
                WCar = WHnd.Substring(J, 1); int nAsc = Asc(WCar) * nKey; string WHex = Hex(nAsc.ToString());
                Wrd = Wrd + WHex.PadLeft(4, CPad);
            }
            return Wrd;
        }
        public string FNDcHx(string WHnd)
        {
            String Wrd = ""; String WCar = ""; int nKey = 31; int J = 0;
            while (J < WHnd.Length)
            {
                WCar = WHnd.Substring(J, 4); string XCar = WCar; int nHNum = Int32.Parse(XCar, System.Globalization.NumberStyles.HexNumber); int nChr = nHNum / nKey; Wrd = Wrd + Convert.ToChar(nChr);
                J = J + 4;
            }
            return Wrd;
        }
        // ----------------------------------------------------------------------------------------------------------------

        public void Dispose()
        {
            Dispose(true); GC.SuppressFinalize(this); GC.Collect(); GC.WaitForPendingFinalizers();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)// Free any other managed objects here.
            {
            }// Free any unmanaged objects here.
            WDB = ""; WMsg = ""; disposed = true;
            if (DB != null){
                DB.Close(); DB.Dispose(); DB = null;
            }
            if (RD != null){
                RD.Close(); RD.Dispose(); RD = null;
            }

            if (cmd != null) {
                cmd.Dispose(); cmd = null;
            }

        }
        ~Tools()
        {
            Dispose(false);
        }
        // ----------------------------------------------------------------------------------------------------------------
    }
}

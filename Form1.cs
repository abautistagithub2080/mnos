using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Demo1;


namespace _01_SP_BG
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        public int i_Tab_Activa = 0; public int i_Tab_Count_General = 0; 
        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabCount; ++i)
                {
                    Rectangle r = tabControl1.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        ContextMenu cm = new ContextMenu();
                        int i_Tab = i; i_Tab++; i_Tab_Activa = i;
                        cm.MenuItems.Add(" Cerrar ", new EventHandler(menuItem2_Click));
                        cm.Show(tabControl1, e.Location);
                        break;
                    }
                }
            }
        }

        private void menuItem2_Click(System.Object sender, System.EventArgs e)
        {
            string WSelectedTab = tabControl1.SelectedTab.Name.ToString(); 
            tabControl1.TabPages.RemoveAt(i_Tab_Activa); SPFormClose(WSelectedTab);
        }

        private void AddPage() {
            i_Tab_Count_General++;
            string WTitle = "Nueva Pestaña";
            TabPage myTabPage = new TabPage(WTitle);
            myTabPage.Name = "TabPage" + (i_Tab_Count_General).ToString();
            tabControl1.TabPages.Add(myTabPage); 
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {  
            if (e.Node.Name.ToString() == "1") AddPage();
            string WIdNodo= e.Node.Name.ToString();
            Tools oTool = new Tools();
            string SQL = "SELECT * FROM tblSubMenus WHERE IdSubMenus=" + WIdNodo;
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            if (rBcs.Read())
            {
                string WtabPage = tabControl1.SelectedTab.Name;
                if (tabControl1.SelectedTab == tabControl1.TabPages[WtabPage])//your specific tabname
                {
                    string WForma = rBcs["Forma"].ToString(); string WNameSpace = rBcs["NombreEspacio"].ToString();
                    string WSubMenus = rBcs["SubMenus"].ToString();
                    Assembly asm = Assembly.GetEntryAssembly();
                    Type formtype = asm.GetType(string.Format("{0}.{1}", WNameSpace, WForma));                    
                    SPFormClose(WtabPage);
                    Form FF = (Form)Activator.CreateInstance(formtype); FF.Name = WtabPage;
                    FF.TopLevel = false; FF.FormBorderStyle = FormBorderStyle.None;  FF.Dock = DockStyle.Fill;
                    tabControl1.TabPages[WtabPage].Controls.Clear();
                    Panel PP = new Panel();
                    PP.Name = "Panel_" + WtabPage; PP.BorderStyle = BorderStyle.None;  PP.Dock = DockStyle.Fill; PP.BackColor = Color.Green;
                    PP.Controls.Add(FF);
                    tabControl1.TabPages[WtabPage].Text = WSubMenus; tabControl1.TabPages[WtabPage].Controls.Add(PP);
                    FF.Show(); FF = null; 
                }                 
            }
            rBcs.Close(); rBcs.Dispose(); rBcs = null;
            oTool.Dispose(); oTool = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string SQL = "SELECT * FROM tblMenus";
            Tools oTool = new Tools();
            OleDbDataReader rBcs = oTool.FNRdr(SQL);
            while (rBcs.Read())
            {
                TreeNode node = new TreeNode(rBcs["Nombre"].ToString()); node.Name = rBcs["IdMenu"].ToString();
                SQL = "SELECT IdSubMenus, SubMenus FROM tblSubMenus WHERE IdMenu=" + rBcs["IdMenu"].ToString();
                OleDbDataReader rSubMns = oTool.FNRdr(SQL);
                while (rSubMns.Read())
                {
                    node.Nodes.Add(rSubMns["IdSubMenus"].ToString(), rSubMns["SubMenus"].ToString());
                }
                rSubMns.Close(); rSubMns.Dispose(); rSubMns = null;
                treeView1.Nodes.Add(node);
            }
            rBcs.Close(); rBcs.Dispose(); rBcs = null;
            oTool.Dispose(); oTool = null;            
        }

        private string FNCerrarFormas() {
            string WCadForms = "";            
            foreach (Form f in Application.OpenForms)
            {
                string sForm = f.Name.ToString();
                if (f.Name.ToString() != "Form1") WCadForms += sForm + "|";
            }
            return WCadForms.Length == 0 ? "" : WCadForms.Substring(0, WCadForms.Length - 1);
        }

        private void SPFormClose(string sForm) {            
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == sForm).FirstOrDefault();
            if (null != frm)
            {
                frm.Close(); frm.Dispose(); frm = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string WCadForms = FNCerrarFormas(); string[] oForms = WCadForms.Split('|');
            for (int K = 0; K < oForms.Length; K++) SPFormClose(oForms[K]);
            Array.Clear(oForms, 0, oForms.Length); oForms = null;
            if (!tabPage0.IsDisposed) { tabPage0.Dispose(); tabPage0 = null; }
            tableLayoutPanel1.Controls.Clear(); tableLayoutPanel1.Dispose(); tableLayoutPanel1 = null;
            tabControl1.Dispose(); tabControl1 = null; treeView1.Dispose(); treeView1 = null;
            Controls.Clear(); this.Dispose();
            GC.SuppressFinalize(this);  GC.Collect(); GC.WaitForPendingFinalizers();
            Application.Exit();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using static DesktopApp2.FormICMSMain;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static ICMS.CompleteOrders;
using DesktopApp2;

namespace ICMS
{
    public partial class CompleteOrders : Form
    {
        delegate void SetColumnIndex(int i);
        private int PVCCurrRow = 0;
        private string tracer = "start";

        public class PVCInfo
        {
            public int id;
            public string desc;
            public decimal price;
            
        }
        public class CoilsToPrint
        {
            public int coilTagID;
            public string coilTagSuffix = "";
        }

        public class SkidsToPrint
        {
            public int skidID;
            public string coilTagSuffix = "";
            public string letter = "";
        }
        
        private List<int> procNum = new List<int>();

        private int row;
        private int CTL = 1;
        private int SheetPolish = 2;
        private int Buff = 3;
        private int Shear = 4;
        private int CoilPolish = 6;
        private int Slitting = 7;

        public class OrderTime
        {
            public int orderID;
            public int sequence;
            public DateTime start;
            public DateTime end;
        }

        //public class SkidData
        //{
        //    public int skidID;
        //    public string coilTagSuffix;
        //    public string letter;
        //    public string location;
        //    public int alloyID;
        //    public int finishID;
        //    public int customerID;
        //    public int branchID;
        //    public int orderID;
        //    public int sequenceNumber;
        //    public decimal sheetWeight;
        //    public decimal length;
        //    public decimal width;
        //    public decimal diagnol1;
        //    public decimal diagnol2;
        //    public decimal mic1;
        //    public decimal mic2;
        //    public decimal mic3;
        //    public int orderedPieceCount;
        //    public int pieceCount;
        //    public int pvcID;
        //    public int paper;
        //    public string comments;
        //    public int status;
        //    public int skidTypeID;
        //    public decimal skidPrice;
        //    public int notPrime;


        //}
        class GFG : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == 0 || y == 0)
                {
                    return 0;
                }

                // CompareTo() method 
                return x.CompareTo(y);

            }
        }


        public Boolean IsNumber(String s)
        {
            return decimal.TryParse(s, out decimal r) ? true : false;
            
        }

        public List<PVCInfo> PVCArray = new List<PVCInfo>();

        public class PVCRollInfo
        {
            public int GroupID;
            public int RollID;
            public string itemNumber;
            public int length;

        }

        private OrderPVC PVCInventory = new OrderPVC();

        public List<PVCRollInfo> PVCRollArray = new List<PVCRollInfo>();

        public class CTLInfo
        {
            public static decimal thickness = 0;
            public static decimal width = 0;
            public static string alloy = "";
            public static decimal discrepency = 0;
        }

        static class SQLConn
        {
            public static SqlConnection conn = FormICMSMain.SQLConn.conn;
        }
        public CompleteOrders()
        {
            tracer = "In CompleteOrders";
            InitializeComponent();
            try
            {

                

                procNum.Add(CTL);
                procNum.Add(CoilPolish);
                procNum.Add(Shear);
                procNum.Add(Buff);
                procNum.Add(SheetPolish);
                procNum.Add(Slitting);

                GetPVCInfo();
                //will be able to call PVCInventory later in program.
                PVCInventory.OpenSQLConn();
                PVCInventory.LoadPVC();
                PVCInventory.CloseSQlConn();

                CTLInfo.discrepency = DesktopApp2.FormICMSMain.CTLInfo.Discrepency;
                SQLConn.conn.Open();
                LoadProcesses();
                LoadFinishes();
                listViewCOOpenOrders.BringToFront();
                SetDataVisibility(false);
                
                if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == CTL)//cut to length=1
                {
                    LoadOrders(CTL);
                }
                labelCOCity.Text = PlantLocation.city;
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
                    
        }


        
        private void CompleteOrders_Load(object sender, EventArgs e)
        {
            tracer = "In CompleteOrders_Load";
        }

        private void LoadProcesses()
        {
            tracer = "In LoadProcesses";
            tabControlProcess.TabPages.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT distinct pr.processID, pr.processDesc from TSAMaster.Processes pr, " + PlantLocation.city + ".Machines ma ");
            sb.Append("where pr.ProcessID = ma.ProcessID ");

            //need to fix the rest of this.

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };


            int procID = -1;
            string processName = "";

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int proccntr = 0;

                    while (reader.Read())
                    {

                        processName = reader.GetString(reader.GetOrdinal("processDesc")).Trim();
                        procID = reader.GetInt32(reader.GetOrdinal("processID"));
                        tabControlProcess.TabPages.Add(processName);
                        tabControlProcess.TabPages[proccntr].Tag = procID;

                        proccntr++;


                    }
                }
            }
        }

        private void LoadFinishes()
        {
            tracer = "In LoadProcesses";
            

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".AlloyFinish af");
          
            
            
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                   
                    ListView lv = listViewAlloyFinish;

                    while (reader.Read())
                    {
                        ListViewItem lv1 = new ListViewItem();
                        
                        

                        lv1.Text = reader.GetInt32(reader.GetOrdinal("FinishID")).ToString();
                        

                        lv1.SubItems.Add(reader.GetInt32(reader.GetOrdinal("SteelTypeID")).ToString());
                        lv1.SubItems.Add(reader.GetString(reader.GetOrdinal("FinishDesc")).Trim());



                        lv.Items.Add(lv1);
                        

                    }
                }
            }
        }

        private void CompleteOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            tracer = "In CompleteOrders_FormClosed";
            SQLConn.conn.Close();
            
        }

        private void TabControlProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In TabControlPRocess_SelectedIndexChanged";
            listViewCOOpenOrders.Items.Clear();

            int selTab = Convert.ToInt32(tabControlProcess.SelectedTab.Tag);
            
            if (procNum.Contains(selTab)) //make sure we have a valid number being passed in.
            {
                LoadOrders(selTab);
            }
            else
            {
                MessageBox.Show("Invalid process selected.");

            }
            
            
        }

        private void LoadOrders(int procID)
        {
            tracer = "In LoadCTLOrders";
            using (DbDataReader reader = GetOpenOrders(procID))
            {
                ListView lv = listViewCOOpenOrders;
               
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        int tier = reader.GetInt32(reader.GetOrdinal("PriceTier"));
                        int orderID = reader.GetInt32(reader.GetOrdinal("OrderID"));
                        string customerName = reader.GetString(reader.GetOrdinal("LongCustomerName"));
                        string PONumber = reader.GetString(reader.GetOrdinal("CustomerPO"));
                        int weightFormula = reader.GetInt32(reader.GetOrdinal("weightFormula"));
                        DateTime dt = reader.GetDateTime(reader.GetOrdinal("PromiseDate"));

                        ListViewItem item = listViewCOOpenOrders.Items.Add(new System.Windows.Forms.ListViewItem(

                                        new string[] { orderID.ToString().Trim(),
                                                        customerName.Trim(),
                                                        PONumber.Trim(),
                                                        dt.ToString("MM/dd/yyyy").Trim() }));

                        item.Tag = tier;
                        item.SubItems[1].Tag = weightFormula;
                        
                        

                    }
                }
            }

        }
        

        private DbDataReader GetOpenOrders(int processID)
        {
            tracer = "In GetOpenOrders";


            StringBuilder sb = new StringBuilder();
            sb.Append("select * From tsamaster.Processes pr, ");
            sb.Append(PlantLocation.city + ".machines ma," + PlantLocation.city + ".OrderHdr oh, " + PlantLocation.city + ".Customer cu ");
            sb.Append("where pr.ProcessID = ma.processID ");
            sb.Append("and pr.ProcessID = @ProcessID ");
            sb.Append("and ma.machineID = oh.MachineID ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and oh.CustomerID = cu.CustomerID ");
            
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@ProcessID", processID);
            if (SQLConn.conn.State == ConnectionState.Closed)
            {

                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();
            return reader;
            

        }

        private void SetDataVisibility(bool vis)
        {
            tracer = "In SetDataVisibility";

            
            if (vis)
            {
                dataGridViewCOOrderEntry.Visible = true;
                buttonCOAddRow.Visible = true;
                buttonCORemoveRow.Visible = true;
                buttonCOCompleteOrder.Visible = true;
                tabControlProcess.Visible = false;
                listViewCOOpenOrders.Visible = false;
                labelCOCustomer.Visible = true;
                labelCOCustomerPO.Visible = true;
            }
            else
            {
                dataGridViewCOOrderEntry.Visible = false;
                buttonCOAddRow.Visible = false;
                buttonCORemoveRow.Visible = false;
                buttonCOCompleteOrder.Visible = false;
                tabControlProcess.Visible = true;
                listViewCOOpenOrders.Visible = true;
                labelCOCustomer.Visible = false;
                labelCOCustomerPO.Visible = false;
            }
        }

        private void ListViewCOOpenOrders_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == CTL)
            {
                CloseCTLOrder(e);
            }

            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == SheetPolish)
            {
                CloseSSSameOrder(e);
            }
            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == Buff)
            {
                CloseSSSameOrder(e);
            }

            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == CoilPolish)
            {
                CloseClClSameOrder (e);
            }
            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == Slitting)
            {
                CloseClClDiffOrder(e);
            }
        }
        private void CloseClClDiffOrder(ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {


                panelCOClClDiff.BringToFront();
                int orderID = Convert.ToInt32(e.Item.SubItems[0].Text);
                LoadClClDiffOrder(orderID);

            }
        }
        private void CloseSSSameOrder(ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {


                panelCOShShSame.BringToFront();
                int orderID = Convert.ToInt32(e.Item.SubItems[0].Text);
                LoadShShSameOrder(orderID);

            }
        }

        private void LoadClClDiffOrder(int orderID)
        {

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            using (DbDataReader reader = db.getClClDiffCloseOrderInfo(orderID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int row = dgvClClDfCloseOrder.Rows.Add();
                        int coilTagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string newTagSuffix = reader.GetString(reader.GetOrdinal("newTagSuffix")).Trim();

                        string alloy = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        string finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();

                        decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));

                        decimal slitWidth = reader.GetDecimal(reader.GetOrdinal("slitWidth"));

                        int origLBS = reader.GetInt32(reader.GetOrdinal("parentWeight"));
                        int newLBS = reader.GetInt32(reader.GetOrdinal("slitWeight"));

                        int paper = reader.GetInt32(reader.GetOrdinal("slitPaper"));

                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfTagID.Index].Value = coilTagID.ToString() + coilTagSuffix + newTagSuffix;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfTagID.Index].Tag = coilTagSuffix; //originalsuffix
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfThickness.Index].Value = thickness;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfWidth.Index].Value = Width;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfAlloy.Index].Value = alloy + " " + finish;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfOrigLBS.Index].Value = origLBS;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfNewLBS.Index].Value = newLBS;
                        dgvClClDfCloseOrder.Rows[row].Cells[dgvCOClClDfPaper.Index].Value = paper;

                    }
                }

            }
        }

        private void LoadShShSameOrder(int orderID)
        {
            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            int alloyID = -1;

            int custID = -1;

            lblOrderID.Text = orderID.ToString();

            DataGridView dgv = dataGridViewCOShShSame;
            int newFinishID = -1;
            using (DbDataReader reader = db.GetShShSameOrderInfo(orderID))
            {

                if (reader.HasRows)
                {
                    int i = 0;
                   
                    while (reader.Read())
                    {

                        string skidIDBase = reader.GetInt32(reader.GetOrdinal("SkidID")).ToString().Trim();
                        string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string skidLetter = reader.GetString(reader.GetOrdinal("skidLetter")).Trim();


                        string skidID =  skidIDBase + coilTagSuffix + "." + skidLetter;

                        int origSkidCount = reader.GetInt32(reader.GetOrdinal("breakSkid"));
                        int skidCount = reader.GetInt32(reader.GetOrdinal("orderPieceCount"));
                        decimal procprice = reader.GetDecimal(reader.GetOrdinal("ProcPrice"));

                        textBoxSSSmPrice.Text = procprice.ToString("G29");

                        string custPO = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();

                        textBoxSSSmPO.Text = custPO;
                        string comments = reader.GetString(reader.GetOrdinal("orderComments")).Trim();
                        richTextBoxSSSmComments.Text = comments;

                        string skComment = reader.GetString(reader.GetOrdinal("skidComments")).Trim();

                        labelCOCustomerPO.Text = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();

                      
                        custID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
                        panelCOShShSame.Tag = custID;

                        dgv.Rows.Add();

                        dgv.Rows[i].Cells[dgvSSSmComments.Index].Value = skComment;
                        dgv.Rows[i].Cells[dgvSSSmSkidIDBase.Index].Value = skidIDBase;
                        dgv.Rows[i].Cells[dgvSSSmCoilTagSuffix.Index].Value = coilTagSuffix;
                        dgv.Rows[i].Cells[dgvSSSmSkidLetter.Index].Value = skidLetter;


                        if (origSkidCount > 0)
                        {
                            dgv.Rows[i].Cells[dgvSSSmBreakSkid.Index].Tag = skidID;
                            dgv.Rows[i].Cells[dgvSSSmBreakSkid.Index].Value = true;
                        }
                        string orderLetter = reader.GetString(reader.GetOrdinal("orderLetter")).Trim();
                        dgv.Rows[i].Cells[dgvSSSmOrderLetter.Index].Value = orderLetter; 

                        skidID += "." + orderLetter;

                        dgv.Rows[i].Cells[dgvSSSmSkidID.Index].Value = skidID;

                        //place orig piece count 
                        dgv.Rows[i].Cells[dgvSSSmPieces.Index].Tag = origSkidCount;


                        dgv.Rows[i].Cells[dgvSSSmPieces.Index].Value = skidCount;
                        dgv.Rows[i].Tag = skidCount;
                        dgv.Rows[i].Cells[dgvSSSmAlloy.Index].Value = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                        alloyID = reader.GetInt32(reader.GetOrdinal("alloyID"));
                        newFinishID = reader.GetInt32(reader.GetOrdinal("newFinishID"));
                        int steelTypeID = reader.GetInt32(reader.GetOrdinal("steelTypeID"));
                        int fID = -1;
                        string fDesc = "";
                        for (int ki = 0; ki < listViewAlloyFinish.Items.Count; ki++)
                        {
                            if (Convert.ToInt32(listViewAlloyFinish.Items[ki].SubItems[1].Text) == steelTypeID)
                            {
                                ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmFinishID.Index]).Items.Add(listViewAlloyFinish.Items[ki].SubItems[0].Text);
                                ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmNewFinish.Index]).Items.Add(listViewAlloyFinish.Items[ki].SubItems[2].Text);

                            }
                            if (Convert.ToInt32(listViewAlloyFinish.Items[ki].SubItems[0].Text) == newFinishID)
                            {

                                fID = Convert.ToInt32(listViewAlloyFinish.Items[ki].SubItems[0].Text);
                                fDesc = listViewAlloyFinish.Items[ki].SubItems[2].Text;
                            }
                        }

                        dgv.Rows[i].Cells[dgvSSSmFinishID.Index].Value = fID.ToString().Trim() ; 
                        dgv.Rows[i].Cells[dgvSSSmNewFinish.Index].Value = fDesc;



                        dgv.Rows[i].Cells[dgvSSSmNewFinish.Index].Tag = newFinishID;
                        decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        dgv.Rows[i].Cells[dgvSSSmThickness.Index].Value = thickness.ToString("G29").Trim() ;
                        decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                        dgv.Rows[i].Cells[dgvSSSmWidth.Index].Value = width.ToString("G29").Trim();
                        decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                        dgv.Rows[i].Cells[dgvSSSmLength.Index].Value = length.ToString("G29").Trim();

                        decimal shWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));

                        if (shWeight > 0)
                        {
                            int skidWeight = Convert.ToInt32(shWeight * skidCount);
                        }
                        else
                        {
                            MetalFormula mt = new MetalFormula ();
                            decimal denFac = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                            decimal skidWeight = mt.MetFormula(denFac, thickness, length, width, skidCount, 0);
                            dgv.Rows[i].Cells[dgvSSSmWeight.Index].Value = skidWeight.ToString("G29").Trim();
                        }

                        

                        int pvcID = reader.GetInt32(reader.GetOrdinal("pvc"));
                        decimal pvcPrice = reader.GetDecimal(reader.GetOrdinal("pvcPrice"));

                        int ordBranchID = reader.GetInt32(reader.GetOrdinal("branchID"));

                        if (pvcID == 0)
                            pvcID = -1;
                        for (int j = 0; j < PVCArray.Count; j++)
                        {

                            ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVCGroupID.Index]).Items.Add(PVCArray[j].id);

                            ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVCPriceList.Index]).Items.Add(PVCArray[j].price);

                            ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVC.Index]).Items.Add(PVCArray[j].desc.Trim());

                            if (PVCArray[j].id == pvcID)
                            {
                                dgv.Rows[i].Cells[dgvSSSmPVC.Index].Value = PVCArray[j].desc.Trim();
                                dgv.Rows[i].Cells[dgvSSSmPVCGroupID.Index].Value = PVCArray[j].id;
                                dgv.Rows[i].Cells[dgvSSSmPVCPriceList.Index].Value = PVCArray[j].price;
                                dgv.Rows[i].Cells[dgvSSSmCurrPrice.Index].Value = pvcPrice;//price put in during order entry;
                                dgv.Rows[i].Cells[dgvSSSmPVC.Index].ToolTipText = pvcPrice.ToString();
                                if (PVCArray[j].id > 0)
                                {

                                    DataRow[] dr = PVCInventory.GroupID(PVCArray[j].id);


                                    for (int r = 0; r < dr.Length; r++)
                                    {
                                        ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVCRollID.Index]).Items.Add(dr[r]["PVCID"].ToString());

                                    }

                                    ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVCRollID.Index]).Items.Add("Choose");

                                    dgv.Rows[i].Cells[dgvSSSmPVCRollID.Index].Value = "Choose";


                                }
                                else
                                {
                                    ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmPVCRollID.Index]).Items.Add("N/A");
                                    dgv.Rows[i].Cells[dgvSSSmPVCRollID.Index].Value = "N/A";
                                }
                            }
                        }

                        using (DbDataReader branchreader = db.GetBranchInfo(custID,true))
                        {
                            if (branchreader.HasRows)
                            {
                                while (branchreader.Read())
                                {
                                    int branchID = branchreader.GetInt32(branchreader.GetOrdinal("BranchID"));
                                    ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmBranchID.Index]).Items.Add(branchID);

                                    string branchName = branchreader.GetString(branchreader.GetOrdinal("BranchDescShort")).Trim();
                                    ((DataGridViewComboBoxCell)dgv.Rows[i].Cells[dgvSSSmBranch.Index]).Items.Add(branchName);
                                    if (branchID == ordBranchID)
                                    {
                                        dgv.Rows[i].Cells[dgvSSSmBranchID.Index].Value = branchID;
                                        dgv.Rows[i].Cells[dgvSSSmBranch.Index].Value = branchName;
                                    }
                                }
                            }
                        }

                        

                        int paper = reader.GetInt32(reader.GetOrdinal("paper"));

                        if (paper > 0)
                        {
                            dgv.Rows[i].Cells[dgvSSSmPaper.Index].Value = true;
                        }
                        int lineMark = reader.GetInt32(reader.GetOrdinal("lineMark"));

                        if (lineMark > 0)
                        {
                            dgv.Rows[i].Cells[dgvSSSmLineMark.Index].Value = true;
                        }
                        dgv.Rows[i].Cells[dgvSSSmSkidPrice.Index].Value = 25.00;


                        i++;

                    }


                }

                reader.Close();

                
            }

            

            

            db.CloseSQLConn();

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            
        }


        private void CloseClClSameOrder(ItemCheckedEventArgs e)
        {
            if (e.Item.ForeColor == Color.Blue)
            {
                e.Item.Checked = true;
                return;
            }

            if (e.Item.Checked)
            {
                
                this.WindowState = FormWindowState.Maximized;
                //this.MinimumSize = this.Size;
                //this.MaximumSize = this.Size;
                Color c1 = Color.Black;
                Color c2 = Color.Blue;
                Color currColor = Color.Black;
                int tier = 0;
                if (e.Item.Tag != null)
                {
                    tier = Convert.ToInt32(e.Item.Tag);
                }
                labelCOCustomerTier.Tag = tier;
                int orderID = Convert.ToInt32(e.Item.SubItems[0].Text);
                labelCOCustomer.Text = e.Item.SubItems[1].Text;
                labelCOCustomerPO.Text = e.Item.SubItems[2].Text;
                DBUtils db = new DBUtils();
                db.OpenSQLConn();

                
                if (e.Item.Tag != null)
                {
                    tier = Convert.ToInt32(e.Item.Tag);
                }
                labelCOCustomerTier.Tag = tier;

                lblOrderID.Text = orderID.ToString();



                using (DbDataReader reader = db.GetClClSameDetails(orderID))
                {
                    if (reader.HasRows)
                    {
                        SetDataVisibility(true);
                        
                        int cntr = 0;
                        while (reader.Read())
                        {
                            dgvCOCLCLSame.Rows.Add();
                            int steelTypeID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));

                            int pWeight = reader.GetInt32(reader.GetOrdinal("pWeight"));
                            int nWeight = reader.GetInt32(reader.GetOrdinal("nWeight"));


                            //need to look for nWeight and pWeight 7/3/23 
                            //compare to decide what to do with finish.



                            int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                            string NewcoilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagNewSuffix")).Trim();


                            decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                            string alloy = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                            int origWeight = reader.GetInt32(reader.GetOrdinal("origWeight"));
                            int PolishWeight = reader.GetInt32(reader.GetOrdinal("polishWeight"));


                            int finishOrdinal = GetColOrdinal(reader, "FinishDesc",2);
                            int finishOrdinalID = GetColOrdinal(reader, "FinishID", 2);
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));

                            decimal densityFact = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));

                            string origFinish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim() ;
                            int origFinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));
                            string newFinish = reader.GetString(finishOrdinal).Trim();
                            int newfinishID = reader.GetInt32(finishOrdinalID);

                            int newFinID = reader.GetInt32(reader.GetOrdinal("DTLfinishID"));


                            for (int i = 0; i < listViewAlloyFinish.Items.Count; i++)
                            {
                                if (Convert.ToInt32(listViewAlloyFinish.Items[i].SubItems[1].Text) == steelTypeID)
                                {
                                    string finID = listViewAlloyFinish.Items[i].SubItems[0].Text.Trim();
                                    ((DataGridViewComboBoxCell)dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinish.Index]).Items.Add(listViewAlloyFinish.Items[i].SubItems[2].Text);
                                    ((DataGridViewComboBoxCell)dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinishID.Index]).Items.Add(finID);

                                    if (newfinishID == Convert.ToInt32(finID))
                                    {
                                        dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinishID.Index].Value = finID;
                                        dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinish.Index].Value = listViewAlloyFinish.Items[i].SubItems[2].Text;
                                    }
                                    //if (nWeight == pWeight)
                                    //{
                                    //    if (newfinishID == Convert.ToInt32(finID))
                                    //    {
                                    //        dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinishID.Index].Value = finID;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (origFinishID == Convert.ToInt32(finID))
                                    //    {
                                    //        dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinishID.Index].Value = finID;
                                    //    }
                                    //}
                                    //if (nWeight == pWeight)
                                    //{
                                    //    dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinish.Index].Value = newFinish.Trim();
                                    //}
                                    //else
                                    //{
                                    //    dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinish.Index].Value = origFinish.Trim();
                                    //}


                                }
                                
                            }
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewFinish.Index].Tag = densityFact;
                            //dgvCOCLCLSame.Rows[cntr].Cells[colClClSameCoilTagID.Index].Value = tagID.ToString().Trim() + coilTagSuffix.Trim() + NewcoilTagSuffix.Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameCoilTagID.Index].Value = tagID.ToString().Trim() + NewcoilTagSuffix.Trim();


                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameOriginalTag.Index].Value = tagID.ToString() + coilTagSuffix;
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameOrigTagSuffix.Index].Value = coilTagSuffix.Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameNewTagSuffix.Index].Value = NewcoilTagSuffix.Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClCLSameThickness.Index].Value = thickness.ToString().Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameWidth.Index].Value = width.ToString().Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameAlloy.Index].Value = alloy.Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameOrigFinish.Index].Value = origFinish.Trim();
                            
                            
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSameOrigLBS.Index].Value = origWeight.ToString().Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSamePolishLBS.Index].Value = nWeight.ToString().Trim();
                            dgvCOCLCLSame.Rows[cntr].Cells[colClClSamePolishLBS.Index].Tag = dgvCOCLCLSame.Rows[cntr].Cells[colClClSamePolishLBS.Index].Value;
                            if (paper > 0)
                            {
                                ((DataGridViewCheckBoxCell)dgvCOCLCLSame.Rows[cntr].Cells[colClClSamePaper.Index]).Value = true;
                            }
                            cntr++;

                        }
                        dateTimePickerClClSameStartTime.Value = dateTimePickerClClSameEndTime.Value.AddHours(-1);
                        panelCOClClSame.Visible = true;
                        panelCOClClSame.BringToFront();
                        buttonCOAddRow.Visible = false;
                        buttonCORemoveRow.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Missing information to close order.");
                    }
                    

                }
            }
        }
        
        private int GetColOrdinal(DbDataReader reader, string colname, int nth)
        {
            List<int> ls = new List<int>();

            DataTable dt = reader.GetSchemaTable();

            var occurances = dt.Rows.Cast<DataRow>().Where(r => string.Equals((string)r["ColumnName"], colname, StringComparison.Ordinal));

            var occurence = occurances.Skip(nth - 1).First();

            return (int)occurence["ColumnOrdinal"];
        }

        private void CloseCTLOrder(ItemCheckedEventArgs e)
        {
            tracer = "In ListViewCOOpenOrders_ItemChecked";
            if (e.Item.ForeColor == Color.Blue)
            {
                e.Item.Checked = true;
                return;
            }

            if (e.Item.Checked)
            {
                
                this.WindowState = FormWindowState.Maximized;
                //this.MinimumSize = this.Size;
                //this.MaximumSize = this.Size;
                Color c1 = Color.Black;
                Color c2 = Color.Blue;
                Color currColor = Color.Black;
                int tier = 0;
                if (e.Item.Tag != null)
                {
                    tier = Convert.ToInt32(e.Item.Tag);
                }
                int weightFormula = 0;
                if (e.Item.SubItems[1].Tag != null)
                {
                    weightFormula = Convert.ToInt32(e.Item.SubItems[1].Tag);
                }
                labelCOCustomerTier.Tag = tier;
                int orderID = Convert.ToInt32(e.Item.SubItems[0].Text);
                labelCOCustomer.Text = e.Item.SubItems[1].Text;
                labelCOCustomerPO.Text = e.Item.SubItems[2].Text;
                SkidSetup skidInfo = new SkidSetup();
                DBUtils db = new DBUtils();
                db.OpenSQLConn();
                int scraprow = 0;
                labelCOCustomerPO.Tag = orderID;

                lblOrderID.Text = orderID.ToString();
                lblOrderID.Tag = weightFormula;
                using (DbDataReader reader = db.GetCTLDetails(orderID))
                {
                    if (reader.HasRows)
                    {

                        buttonCOAddRow.Visible = true;
                        buttonCORemoveRow.Visible = true;
                        SetDataVisibility(true);
                        int skidcount = 0;
                        int currRow = 0;
                        string skidLetter = "A";
                        string prevTag = "";
                        string currTag = "";
                        bool setmaxletter = false;
                        while (reader.Read())
                        {

                           
                            if (!setmaxletter)
                            {
                                string maxLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                                if (!maxLetter.Equals(""))
                                {
                                    skidLetter = skidInfo.SetFirstLetter(maxLetter);
                                    skidLetter = skidInfo.GetNextLetter();
                                }
                                else
                                {
                                    skidLetter = skidInfo.SetFirstLetter();
                                }
                               
                                setmaxletter = true;
                            }
                            
                            
                            int custID = reader.GetInt32(reader.GetOrdinal("customerID"));
                            labelCOCustomer.Tag = custID;
                            skidcount += reader.GetInt32(reader.GetOrdinal("skidCount"));
                            int pieceCount = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                            decimal skidLength = reader.GetDecimal(reader.GetOrdinal("Length"));
                            decimal skidWidth = reader.GetDecimal(reader.GetOrdinal("Width"));
                            decimal thickness = reader.GetDecimal(reader.GetOrdinal("Thickness"));
                            double TheoDiag = Math.Sqrt(Convert.ToDouble((skidLength * skidLength) + (skidWidth * skidWidth)));
                            int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                            string tagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                            string MillInfo = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim() + "/" + reader.GetString(reader.GetOrdinal("heat")).Trim();
                             
                            string strCoilInfo = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim() + " " + reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                            string strCoilAlloy = strCoilInfo;
                            strCoilInfo += "-" + thickness.ToString("G29").Trim() + "X" + skidWidth.ToString("G29").Trim() + "X";
                            strCoilInfo += reader.GetDecimal(reader.GetOrdinal("weight")).ToString("G29").Trim() + "#";
                            string skidComments = reader.GetString(reader.GetOrdinal("comments")).Trim();
                            decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            int PVCID = reader.GetInt32(reader.GetOrdinal("PVCGroupID"));
                            decimal pvcPrice = reader.GetDecimal(reader.GetOrdinal("PVCPrice"));
                            int alloyID = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                            int finishID = reader.GetInt32(reader.GetOrdinal("FinishID"));
                            int skidTypeID = reader.GetInt32(reader.GetOrdinal("skidTypeID"));
                            Decimal skidprice = reader.GetDecimal(reader.GetOrdinal("skidPrice"));
                            decimal coilWeight = reader.GetDecimal(reader.GetOrdinal("weight"));
                            int sequenceNumber = reader.GetInt32(reader.GetOrdinal("sequenceNumber"));
                            decimal densityFactor = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                            if (prevTag.Equals(""))
                            {
                                currTag = tagID.ToString().Trim() + tagSuffix.Trim();
                                prevTag = currTag;
                                currColor = c1;
                                dgvCOCoilScrap.Rows.Add();
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapTagID"].Value = currTag;
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapTagID"].Tag = coilWeight;
                                ((DataGridViewComboBoxCell)dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"]).Items.Add("IN");
                                ((DataGridViewComboBoxCell)dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"]).Items.Add("LBS");
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"].Value = MachineDefaults.scrapUnit;
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagID"].Value = tagID;
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagID"].Tag = densityFactor;
                                dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagSuffix"].Value = tagSuffix;
                                scraprow++;
                            }
                            else
                            {
                                currTag = tagID.ToString().Trim() + tagSuffix.Trim();
                                if (!currTag.Equals(prevTag))//changed tags
                                {
                                    skidLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                                    if (skidLetter.Equals(""))
                                    {
                                        skidLetter = "A";
                                        skidLetter = skidInfo.SetFirstLetter(skidLetter);
                                    }
                                    else
                                    {
                                        skidLetter = skidInfo.SetFirstLetter(skidLetter);
                                        skidLetter = skidInfo.GetNextLetter();
                                    }
                                    
                                    prevTag = currTag;
                                    if (currColor == c1)
                                    {
                                        currColor = c2;
                                    }
                                    else
                                    {
                                        currColor = c1;
                                    }


                                    dgvCOCoilScrap.Rows.Add();
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapTagID"].Value = currTag;
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapTagID"].Tag = coilWeight;
                                    ((DataGridViewComboBoxCell)dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"]).Items.Add("IN");
                                    ((DataGridViewComboBoxCell)dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"]).Items.Add("LBS");
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOscrapUnits"].Value = MachineDefaults.scrapUnit;
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagID"].Value = tagID;
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagID"].Tag = densityFactor;
                                    dgvCOCoilScrap.Rows[scraprow].Cells["dgvCOScrapCoilTagSuffix"].Value = tagSuffix;
                                    scraprow++;

                                }
                            }
                            for (int i = currRow ; i < skidcount; i++)
                            {
                                dataGridViewCOOrderEntry.Rows.Add();
                                dataGridViewCOOrderEntry.Rows[i].Tag = sequenceNumber;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBaseTagID"].Value = tagID;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBaseTagID"].Tag = coilWeight;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagSuffix"].Value = tagSuffix;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagSuffix"].Tag = densityFactor;
                                dataGridViewCOOrderEntry.Rows[i].DefaultCellStyle.ForeColor = currColor;
                                    
                                    
                                
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilInfo"].Value = strCoilInfo;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilInfo"].Tag = skidWidth ;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOMillHeat"].Value = MillInfo;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagID"].Value = currTag;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value = skidLetter;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPieces"].Value = pieceCount;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLength"].Value = skidLength.ToString("G29");
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOTheoDiag"].Value = TheoDiag;

                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOAlloyID"].Value = alloyID;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOFinishID"].Value = finishID;

                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCODiag1"].ToolTipText = Math.Round(TheoDiag, 3).ToString();
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCODiag2"].ToolTipText = Math.Round(TheoDiag, 3).ToString();

                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness1"].Tag = thickness;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness2"].Tag = thickness;
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness3"].Tag = thickness;

                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness1"].ToolTipText = thickness.ToString("G29");
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness2"].ToolTipText = thickness.ToString("G29");
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOThickness3"].ToolTipText = thickness.ToString("G29");
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOstrAlloy"].Value = strCoilAlloy;

                                GetSkidTypes(i,skidTypeID);
                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOSkidPrice"].Value  = skidprice;

                                dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOSkidComments"].Value = skidComments;
                                if (sheetWeight > 0)
                                {
                                    dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOSheetWeight"].Value = sheetWeight;
                                }
                                if (paper > 0)
                                {
                                    dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPaper"].Value = true;
                                }

                                using (DbDataReader branchreader = db.GetBranchInfo(custID, true))
                                {

                                    if (branchreader.HasRows)
                                    {
                                        while (branchreader.Read())
                                        {
                                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranchID"]).Items.Add(branchreader.GetInt32(branchreader.GetOrdinal("BranchID")));
                                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranch"]).Items.Add(branchreader.GetString(branchreader.GetOrdinal("BranchDescShort")).Trim());

                                        }
                                    }
                                }
                                

                                int skidBranchID = 0;
                                if (!reader.IsDBNull(reader.GetOrdinal("BranchID")))
                                {
                                    skidBranchID = reader.GetInt32(reader.GetOrdinal("BranchID"));
                                }
                                
                                
                                if (skidBranchID != 0)
                                {
                                    //select the correct branch
                                    for (int j = 0; j < ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranchID"]).Items.Count; j++)
                                    {
                                        int currbranchID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranchID"]).Items[j]);
                                        if (currbranchID == skidBranchID)
                                        {
                                            dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranch"].Value = ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranch"]).Items[j];
                                            dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranchID"].Value = skidBranchID;
                                        }
                                    }

                                }
                                ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranchID"]).Items.Add(0);
                                ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOBranch"]).Items.Add("None");
                                for (int j = 0; j < PVCArray.Count; j++)
                                {
                                    ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCID"]).Items.Add(PVCArray[j].id);

                                    ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCPrice"]).Items.Add(PVCArray[j].price);

                                    ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVC"]).Items.Add(PVCArray[j].desc);
                                    if (PVCArray[j].id == PVCID)
                                    {
                                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVC"].Value = PVCArray[j].desc;
                                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCID"].Value = PVCArray[j].id ;
                                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCPrice"].Value = PVCArray[j].price;
                                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCCurrPrice"].Value = pvcPrice;//price put in during order entry;
                                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVC"].ToolTipText = pvcPrice.ToString() ;
                                        if (PVCArray[j].id > 0)
                                        {

                                            DataRow[] dr = PVCInventory.GroupID(PVCArray[j].id);

                                            
                                            for (int r = 0; r < dr.Length; r++)
                                            {
                                                ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCRollIDs"]).Items.Add(dr[r]["PVCID"].ToString());
                                                
                                            }

                                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCRollIDs"]).Items.Add("Choose");

                                            dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCRollIDs"].Value = "Choose";


                                        }
                                        else
                                        {
                                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCRollIDs"]).Items.Add("N/A");
                                            dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOPVCRollIDs"].Value = "N/A";
                                        }
                                    }
                                }



                                skidLetter = skidInfo.GetNextLetter();
                                currRow++;
                            }

                        }
                        panelCTLInfo.BringToFront();
                        dataGridViewCOOrderEntry.BringToFront();
                        dataGridViewCOOrderEntry.CurrentCell = dataGridViewCOOrderEntry.Rows[0].Cells["dgvCOActualPieces"];
                        dataGridViewCOOrderEntry.BeginEdit(true);
                        
                        for (int i = 0; i < dataGridViewCOOrderEntry.ColumnCount; i++)
                        {
                            dataGridViewCOOrderEntry.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        }
                    }
                }
                db.CloseSQLConn();
            }
            

        }

        private DbDataReader GetBranchInfo(int custID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".CustomerBranch ");
            sb.Append("where customerID = " + custID);

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        private void ButtonCOCompleteOrder_Click(object sender, EventArgs e)
        {
            tracer = "In ButtonCOCompleteORder_Click";
            //is everything filled out properly


            if (MessageBox.Show("Are you sure you are ready to close this order?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int timecntr = listViewCOTimeRecords.Items.Count;

            if (timecntr == 0)
            {
                MessageBox.Show("You must enter at least one start/end time");
                return;
            }
       
            List<int> pvcIds = new List<int>();

            
            //loop through each row
            for (int r = 0; r< dataGridViewCOOrderEntry.RowCount; r++)
            {

                //do we have pieces filled out
               
                if (!CheckCellValue("dgvCOActualPieces", r))
                {
                    MessageBox.Show("Piece Count required.");
                    return;
                }
                if (!CheckCellValue("dgvCODiag1", r))
                {
                    MessageBox.Show("Diagonal 1 required.");
                    return;
                }
                if (!CheckCellValue("dgvCODiag2", r))
                {
                    MessageBox.Show("Diagonal 2 required.");
                    return;
                }
                if (!CheckCellValue("dgvCOThickness1", r))
                {
                    MessageBox.Show("Thickness 1 required.");
                    return;
                }
                if (!CheckCellValue("dgvCOThickness2", r))
                {
                    MessageBox.Show("Thickness 2 required.");
                    return;
                }
                if (!CheckCellValue("dgvCOThickness3", r))
                {
                    MessageBox.Show("Thickness 3 required.");
                    return;
                }
                //check PVC
                 if (dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVC"].Value != null)
                {
                    if (!((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVC"]).Value.Equals("None"))
                    {
                        //did they select a roll?
                        if (((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVCRollIDs"]).Value.Equals("Choose") ||
                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVCRollIDs"]).Value.Equals("N/A"))
                        {
                            //nope...try again.
                            MessageBox.Show("PVC Roll ID is required.");
                            dataGridViewCOOrderEntry.CurrentCell = dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVCRollIDs"];
                            dataGridViewCOOrderEntry.MultiSelect = false;

                            dataGridViewCOOrderEntry.BeginEdit(true);
                            ((ComboBox)dataGridViewCOOrderEntry.EditingControl).DroppedDown = true;

                            return;
                        }
                        else
                        {
                            //yep...add to the list to see if we need to remove.  
                            int currID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVCRollIDs"]).Value);
                            bool addID = true;
                            //make sure the pvc tag is only in the list once.
                            foreach (int id in pvcIds)
                            {
                                if (currID == id)
                                {
                                    addID = false;
                                }
                            }

                            if (addID)
                            {
                                //didn't find the id so add to the list
                                pvcIds.Add(Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[r].Cells["dgvCOPVCRollIDs"]).Value));
                            }

                        }

                    }
                }
                
                
            }

            for (int re = 0;re < dgvCOCoilScrap.Rows.Count; re++)
            {
                if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index].Value == null)
                {
                    MessageBox.Show("Scrap Amount is required.");
                    dgvCOCoilScrap.Focus();
                    dgvCOCoilScrap.CurrentCell = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index];
                    dgvCOCoilScrap.BeginEdit(true);
                    return;
                }
                if (Convert.ToBoolean(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectCoil.Index].Value) == true)
                {
                    if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectReason.Index].Value == null)
                    {
                        MessageBox.Show("You must give a reason for rejecting coil.");
                        dgvCOCoilScrap.Focus();
                        dgvCOCoilScrap.CurrentCell = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectReason.Index];
                        dgvCOCoilScrap.BeginEdit(true);
                        return;
                    }
                    if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectReason.Index].Value.ToString().Length == 0)
                    {
                        MessageBox.Show("You must give a reason for rejecting coil.");
                        dgvCOCoilScrap.Focus();
                        dgvCOCoilScrap.CurrentCell = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectReason.Index];
                        dgvCOCoilScrap.BeginEdit(true);
                        return;

                    }
                }
            }

            //do we need to remove the PVC from inventory?
            GFG gg = new GFG();

           
            // use of List<T>.Sort(IComparer<T>)  
            // method. The comparer is "gg" 
            pvcIds.Sort(gg);

            //start transaction

            int orderID = Convert.ToInt32(labelCOCustomerPO.Tag);
            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            Cursor.Current = Cursors.WaitCursor;
            SqlTransaction tran = db.StartTrans();
            //SqlTransaction tranloc = SQLConn.conn.BeginTransaction();
            try
            {




                //update PVC rolls, etc



                


                RemovePVCRolls(pvcIds,dgvCOActualPieces.Index,dgvCOLength.Index, dgvCOPVCRollIDs.Index, dataGridViewCOOrderEntry, db, orderID, tran);


                

                //get time information
                AddOrderTime(timecntr, Convert.ToInt32(labelCOCustomerPO.Tag), listViewCOTimeRecords, tran);

                

                
                List<SkidsToPrint> stp = new List<SkidsToPrint>();
                List<CoilsToPrint> ctp = new List<CoilsToPrint>();

                SkidData sd = new SkidData();

                DataGridView dgv = dataGridViewCOOrderEntry;




                for (int i = 0; i < dgvCOCoilScrap.Rows.Count; i++)
                {
                    int tagid = Convert.ToInt32(dgvCOCoilScrap.Rows[i].Cells[dgvCOScrapCoilTagID.Index].Value);
                    string tagSuff = dgvCOCoilScrap.Rows[i].Cells[dgvCOScrapCoilTagSuffix.Index].Value.ToString().Trim();
                    dgvCOCoilScrap.Rows[i].Cells[dgvCOTotalLength.Index].Value = 0;
                    decimal totlen = 0;
                    for (int j = 0;j < dgv.Rows.Count; j++)
                    {
                        int skidID = Convert.ToInt32(dgv.Rows[j].Cells[dgvCOBaseTagID.Index].Value);
                        string skidSuffix = dgv.Rows[j].Cells[dgvCOcoilTagSuffix.Index].Value.ToString().Trim();

                        if (tagid == skidID && tagSuff.Equals(skidSuffix))
                        {
                            int pieces = Convert.ToInt32(dgv.Rows[j].Cells[dgvCOActualPieces.Index].Value);
                            decimal len = Convert.ToDecimal(dgv.Rows[j].Cells[dgvCOLength.Index].Value);

                            totlen += (pieces * len);


                        }
                    }
                    dgvCOCoilScrap.Rows[i].Cells[dgvCOTotalLength.Index].Value = totlen;


                }

                decimal lbsPerInch = 0;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (Convert.ToInt32(dgv.Rows[i].Cells["dgvCOActualPieces"].Value) > 0)
                    {


                        int coilWeight = -99;

                        sd.skidID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOBaseTagID"].Value);
                        sd.coilTagSuffix = dgv.Rows[i].Cells["dgvCOcoilTagSuffix"].Value.ToString().Trim();
                        sd.letter = dgv.Rows[i].Cells["dgvCOLetter"].Value.ToString().Trim();
                        //find the original coil weight
                        if (dgvCOCoilScrap.Rows.Count > 1)
                        {
                            for (int re = 0; re < dgvCOCoilScrap.Rows.Count; re++)
                            {
                                int coilTagID = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapCoilTagID.Index].Value);
                                string coilTagSuffix = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapCoilTagSuffix.Index].Value.ToString().Trim();

                                if (sd.skidID == coilTagID && sd.coilTagSuffix.Equals(coilTagSuffix))
                                {
                                    if (dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapTagEndWeight.Index].Value != null)
                                    {
                                        coilWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagID.Index].Tag) - Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagEndWeight.Index].Value);

                                    }
                                    else
                                    {
                                        coilWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagID.Index].Tag); ;

                                    }
                                    //coilWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagID.Index].Tag);
                                    decimal totlen = Convert.ToDecimal(dgvCOCoilScrap.Rows[re].Cells[dgvCOTotalLength.Index].Value);

                                    if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapUnits.Index].Value.ToString().ToUpper().Equals("IN"))
                                    {
                                        totlen += Convert.ToDecimal(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index].Value);
                                    }
                                    else
                                    {
                                        coilWeight -= Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index].Value);
                                    }

                                    lbsPerInch = coilWeight / totlen;

                                    dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapLbsPerInch.Index].Value = lbsPerInch;

                                    re = dgvCOCoilScrap.Rows.Count;
                                }
                            }

                        }
                        else
                        {
                            if (dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapTagEndWeight.Index].Value != null)
                            {
                                coilWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapTagID.Index].Tag) - Convert.ToInt32(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapTagEndWeight.Index].Value);

                            }
                            else
                            {
                                coilWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapTagID.Index].Tag); ;

                            }
                            decimal totlen = Convert.ToDecimal(dgvCOCoilScrap.Rows[0].Cells[dgvCOTotalLength.Index].Value);

                            if (dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapUnits.Index].Value.ToString().ToUpper().Equals("IN"))
                            {
                                totlen += Convert.ToDecimal(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapAmount.Index].Value);
                            }
                            else
                            {
                                coilWeight -= Convert.ToInt32(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapAmount.Index].Value);
                            }

                            lbsPerInch = coilWeight / totlen;

                            dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapLbsPerInch.Index].Value = lbsPerInch;
                        }

                        SkidsToPrint sp = new SkidsToPrint();
                        //setup a list of skids to print after we commit;
                        sp.skidID = sd.skidID;
                        sp.coilTagSuffix = sd.coilTagSuffix;
                        sp.letter = sd.letter;
                        stp.Add(sp);

                        sd.location = "";

                        sd.alloyID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOAlloyID"].Value);

                        sd.finishID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOFinishID"].Value);
                        sd.customerID = Convert.ToInt32(labelCOCustomer.Tag);
                        sd.branchID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOBranchID"].Value);
                        sd.orderID = Convert.ToInt32(labelCOCustomerPO.Tag);
                        sd.sequenceNumber = Convert.ToInt32(dgv.Rows[i].Tag);

                        sd.length = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOLength"].Value);

                        //the weightformula is stored in the lblorderid.tag

                        if (Convert.ToInt32(lblOrderID.Tag) == 0)
                        {
                            //Theo
                            sd.sheetWeight = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOSheetWeight"].Value);
                            lbsPerInch = 0;
                        }
                        else
                        {
                            sd.sheetWeight = sd.length * lbsPerInch;
                        }

                        sd.width = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOCoilInfo"].Tag);
                        sd.diagnol1 = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCODiag1"].Value);
                        sd.diagnol2 = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCODiag2"].Value);
                        sd.mic1 = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOThickness1"].Value);
                        sd.mic2 = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOThickness2"].Value);
                        sd.mic3 = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOThickness3"].Value);
                        sd.orderedPieceCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOPieces"].Value);
                        sd.pieceCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOActualPieces"].Value);
                        sd.pvcID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOPVCID"].Value);
                        sd.pvcPrice = Convert.ToDecimal(dgv.Rows[i].Cells[dgvCOPVCCurrPrice.Index].Value);
                        sd.paper = 0;
                        if (Convert.ToBoolean(dgv.Rows[i].Cells["dgvCOPaper"].Value) == true)
                        {
                            sd.paper = Convert.ToInt32((sd.length * sd.width * sd.pieceCount) / 144);
                        }
                        sd.comments = dgv.Rows[i].Cells["dgvCOSkidComments"].Value.ToString();
                        sd.status = 1;
                        sd.skidTypeID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCOSkidTypeID"].Value);
                        sd.skidPrice = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCOSkidPrice"].Value);
                        sd.notPrime = 0;
                        if (Convert.ToBoolean(dgv.Rows[i].Cells["dgvCONotPrime"].Value) == true)
                        {
                            sd.notPrime = 1;
                        }



                        db.InsertSkidDataRecord(sd, tran);
                    }
                }



                //update order header

                db.UpdateOrderHdr(orderID, -3, tran);


                int scrapAmount = 0;
                string scrapType = "";
                bool reject = false;
                string rejectReason = "";
                int weight = 0;
                
                //update coil
                for (int re = 0; re < dgvCOCoilScrap.RowCount; re++)
                {
                    if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index].Value == null)
                    {
                        scrapAmount = 0;
                    }
                    else
                    {
                        scrapAmount = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapAmount.Index].Value);
                    }
                    scrapType = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapUnits.Index].Value.ToString();
                    if (Convert.ToBoolean(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectCoil.Index].Value) == true)
                    {
                        reject = true;
                        rejectReason = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapRejectReason.Index].Value.ToString();
                    }
                    else
                    {
                        reject = false;
                        rejectReason = "";
                    }

                    int coilTagID = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapCoilTagID.Index].Value);
                    string coilTagSuffix = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapCoilTagSuffix.Index].Value.ToString().Trim();
                    lbsPerInch = Convert.ToDecimal(dgvCOCoilScrap.Rows[0].Cells[dgvCOScrapLbsPerInch.Index].Value);
                    //insert work order details.
                    db.InsertCoilWorkOrderDtls(coilTagID, coilTagSuffix, orderID, scrapAmount, scrapType, rejectReason, lbsPerInch, tran);

                    string coilLoc = "";
                    if (dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapLocation.Index].Value != null)
                    {
                        coilLoc = dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapLocation.Index].Value.ToString().Trim();
                    }

                    weight = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagEndWeight.Index].Value);
                    int status = 0;
                    if (weight > 0)
                    {
                        status = 1;
                        CoilsToPrint cp = new CoilsToPrint();
                        cp.coilTagID = coilTagID;
                        cp.coilTagSuffix = coilTagSuffix;
                        ctp.Add(cp);
                    }

                    //Update the coil information
                    db.UpdateCoil(coilTagID, coilTagSuffix, weight, coilLoc, status, reject, tran);
                    
                    



                    int prevWeight = Convert.ToInt32(dgvCOCoilScrap.Rows[re].Cells[dgvCOScrapTagID.Index].Tag);
                    //update coil weight changes
                    db.InsertCoilWeightChange(coilTagID, coilTagSuffix, orderID, prevWeight, weight, tran);


                }

                tran.Commit();
                //tranloc.Commit();
                db.CloseSQLConn();
                //listViewCOOpenOrders.Items[0].Checked = false;
                foreach (ListViewItem lv in listViewCOOpenOrders.CheckedItems)
                {
                    lv.ForeColor = Color.Blue;
                }
                PrintLabels pl = new PrintLabels();
                pl.PrintSkids(stp);
                pl.PrintCoils(ctp);

                ReportGeneration rg = new ReportGeneration();

                rg.WorkOrder(orderID);
                

            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se.Message);
                Console.WriteLine(se.StackTrace);
                //something went wrong rollback everything.
                tran.Rollback();
                //tranloc.Rollback();
                MessageBox.Show("Error: " + se);
                db.CloseSQLConn();
                //listViewCOOpenOrders.SelectedItems[0].Checked = false;
            }




            //commit transaction or rollback



            dataGridViewCOOrderEntry.Rows.Clear();
            dgvCOCoilScrap.Rows.Clear();
            listViewCOTimeRecords.Items.Clear();
            SetDataVisibility(false);
            listViewCOOpenOrders.BringToFront();

            Cursor.Current = Cursors.Default;
        }

        //private void TEMP_PrintSkids(List<SkidsToPrint> skidsToPrint)
        //{


        //    if (skidsToPrint.Count > 0)
        //    {
        //        DBUtils db = new DBUtils();

        //        db.OpenSQLConn();

        //        PrintLabels pl = new PrintLabels();
        //        for (int i = 0; i < skidsToPrint.Count; i++)
        //        {
        //            using (DbDataReader reader = db.GetSkidInfo("-1", skidsToPrint[i].skidID, skidsToPrint[i].coilTagSuffix, skidsToPrint[i].letter))
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {



        //                        pl.SkidLabelInfo.SkidID = reader.GetInt32(reader.GetOrdinal("skidID"));
        //                        pl.SkidLabelInfo.CoilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

        //                        pl.SkidLabelInfo.SkidLetter = reader.GetString(reader.GetOrdinal("letter")).Trim();
        //                        pl.SkidLabelInfo.Gauge = reader.GetDecimal(reader.GetOrdinal("thickness"));
        //                        pl.SkidLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
        //                        pl.SkidLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
        //                        pl.SkidLabelInfo.Type = reader.GetInt32(reader.GetOrdinal("steelTypeID"));
        //                        string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
        //                        string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
        //                        pl.SkidLabelInfo.Alloy = alloy + " " + finish;
        //                        pl.SkidLabelInfo.OrderID = reader.GetInt32(reader.GetOrdinal("orderID"));
        //                        pl.SkidLabelInfo.Heat = reader.GetString(reader.GetOrdinal("Heat")).Trim();
        //                        pl.SkidLabelInfo.Mill = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
        //                        pl.SkidLabelInfo.Vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();
        //                        decimal sheetweight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
        //                        int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
        //                        pl.SkidLabelInfo.Pieces = pieces;

        //                        pl.SkidLabelInfo.TheoWeight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SheetWeight")));
                                
        //                        pl.SkidLabelInfo.CustName = reader.GetString(reader.GetOrdinal("shortCustomerName")).Trim();
        //                        pl.SkidLabelInfo.PO = "";
        //                        if (!reader.IsDBNull(reader.GetOrdinal("CustomerPO")))
        //                        {
        //                            pl.SkidLabelInfo.PO = reader.GetString(reader.GetOrdinal("CustomerPO"));
        //                        }
                                
        //                        pl.SkidLabelInfo.RecDate = DateTime.Now.ToString("d");
        //                        pl.SkidLabelInfo.Carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));
        //                        pl.SkidLabelInfo.COO = reader.GetString(reader.GetOrdinal("countryOfOrigin"));
        //                        pl.SkidLabelInfo.SkidSteelDesc = reader.GetString(reader.GetOrdinal("SteelDesc"));
        //                        pl.SkidLabelInfo.Comments = reader.GetString(reader.GetOrdinal("comments"));
        //                        pl.SkidLabelInfo.Location = reader.GetString(reader.GetOrdinal("location"));
        //                        pl.SkidLabelInfo.TheoWeight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SkidWeight")));
                                
        //                        if (LabelPrinters.zebraTagPrinter)
        //                        {
        //                            pl.SkidLabelZebra(LabelPrinters.tagPrinter);
        //                        }
        //                        else
        //                        {
        //                            pl.SkidLabel(LabelPrinters.tagPrinter);
        //                        }
                                    
        //                    }
        //                }

        //            }
        //        }
        //    }
        //}

        private void RemovePVCRolls(List<int> pvcIds, int PieceCol, int lengthCol, int colIndex, DataGridView dgv, DBUtils db, int orderID, SqlTransaction tran)
        {
            foreach (int r in pvcIds)
            {
                bool removeRoll = false;
                decimal pvclengthused = 0;





                for (int i = 0; i < dgv.RowCount; i++)
                {
                    
                    if (IsNumber(dgv.Rows[i].Cells[colIndex].Value.ToString()))
                    {


                        if (Convert.ToInt32(dgv.Rows[i].Cells[colIndex].Value) == r)
                        {
                            decimal currlength = Convert.ToDecimal(dgv.Rows[i].Cells[lengthCol].Value) * Convert.ToDecimal(dgv.Rows[i].Cells[PieceCol].Value);
                            pvclengthused += currlength;
                            currlength = currlength / 12;
                            db.InsertPVCOrderInfo(r, orderID, i, Convert.ToInt32(currlength), tran);
                        }
                    }
                }


                //convert from inches to feet
                pvclengthused = pvclengthused / 12;

                db.UpdatePVCRollInfo(r, -1, Convert.ToInt32(pvclengthused), "", tran, true);


                DataRow[] dr = PVCInventory.PVCID(r);

                bool shouldremove = false;

                int newLength = 0;
                //did we find a record?
                if (dr.Length > 0)
                {
                    newLength = Convert.ToInt32(dr[0]["Length"]) - Convert.ToInt32(pvclengthused);
                    //did we use up the whole roll?
                    string me = dr[0]["Length"].ToString();
                    if (newLength < 0)
                    {
                        shouldremove = true;

                    }
                    PVCInventory.updateLength(r, newLength);




                }
                string msgbox = "Remove PVC Roll " + r.ToString() + " from inventory?(" + newLength +")";

                if (shouldremove)
                {
                    msgbox = "All footage used up. " + msgbox;
                }
                if (MessageBox.Show(msgbox, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    removeRoll = true;

                }

                if (removeRoll)
                {
                    db.UpdatePVCRollStatus(r, -3, orderID.ToString(), tran);
                    //PVCRollDtls status = -3;ReferenceNumber = orderID
                    MessageBox.Show("PVC TagID " + r.ToString() + " removed from inventory.");
                }




            }
        }


        
        private void AddOrderTime(int timecntr, int orderID, ListView lv, SqlTransaction tranloc)
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            OrderTime ot = new OrderTime();

            for (int t = 0; t < timecntr; t++)
            {
                ot.orderID = orderID;
                ot.sequence = t;
                ot.start = Convert.ToDateTime(lv.Items[t].SubItems[0].Text);
                ot.end = Convert.ToDateTime(lv.Items[t].SubItems[1].Text);

                //here
                //need to move  InsertOrderTime to DBUtils
                db.InsertOrderTime(ot, tranloc);
            }
        }
        private bool CheckCellValue(string cellName, int r)
        {

            if (dataGridViewCOOrderEntry.Rows[r].Cells[cellName].Value == null)
            {
                
                dataGridViewCOOrderEntry.CurrentCell = dataGridViewCOOrderEntry.Rows[r].Cells[cellName];
                dataGridViewCOOrderEntry.MultiSelect = false;
                dataGridViewCOOrderEntry.BeginEdit(true);
                return false;
            }
            else
            {
                if (dataGridViewCOOrderEntry.Rows[r].Cells[cellName].Style.BackColor == Color.Red)
                {
                    return false;
                } 
            }
            return true;
        }
        private void DataGridViewCOOrderEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tracer = "In DataGridViewCOOrderEntry_CellEndEdit";
            DataGridView dgv = dataGridViewCOOrderEntry;
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (e.ColumnIndex == dgv.Columns["dgvCOActualPieces"].Index)
            {
                if (Convert.ToInt32(dgv.Rows[row].Cells[col].Value) != Convert.ToInt32(dgv.Rows[row].Cells["dgvCOPieces"].Value))
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = Color.Red;
                    dgv.Rows[row].Cells[col].Style.BackColor = Color.LightGray;
                }
                else
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.ForeColor;
                    dgv.Rows[row].Cells[col].Style.BackColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.BackColor;
                }

            }
            if (e.ColumnIndex == dgv.Columns["dgvCODiag1"].Index || e.ColumnIndex == dgv.Columns["dgvCODiag2"].Index)
            {
                double ActDiag = Convert.ToDouble(dgv.Rows[row].Cells[col].Value);
                double TheoDiag = Convert.ToDouble(dgv.Rows[row].Cells["dgvCOTheoDiag"].Value);
                if (ActDiag > TheoDiag + .125 || ActDiag < TheoDiag - .125)
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = Color.Red;
                    dgv.Rows[row].Cells[col].Style.BackColor = Color.LightGray;
                }
                else
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.ForeColor;
                    dgv.Rows[row].Cells[col].Style.BackColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.BackColor;
                }
            }
            if (e.ColumnIndex == dgv.Columns["dgvCOThickness1"].Index || e.ColumnIndex == dgv.Columns["dgvCOThickness2"].Index ||
                e.ColumnIndex == dgv.Columns["dgvCOThickness3"].Index)
            {

                decimal thickness = Convert.ToDecimal(dgv.Rows[row].Cells[col].Tag);
                decimal valEntered = 0;
                if (dgv.Rows[row].Cells[col].Value != null)
                {
                    if (IsNumber(dgv.Rows[row].Cells[col].Value.ToString()))
                    {
                        valEntered = Convert.ToDecimal(dgv.Rows[row].Cells[col].Value);
                    }
                    else
                    {
                        MessageBox.Show("Must be numeric");
                        dgv.Rows[row].Cells[col].Style.BackColor = Color.Red;
                        return;

                    }
                }
                
                

                if (valEntered > thickness + CTLInfo.discrepency || valEntered < thickness - CTLInfo.discrepency  )
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = Color.Red;
                    dgv.Rows[row].Cells[col].Style.BackColor = Color.LightGray;
                }
                else
                {
                    dgv.Rows[row].Cells[col].Style.ForeColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.ForeColor;
                    dgv.Rows[row].Cells[col].Style.BackColor = dgv.Rows[row].Cells["dgvCOPieces"].Style.BackColor;
                }

            }
            if(e.ColumnIndex == dgv.Columns["dgvCOSheetWeight"].Index|| e.ColumnIndex == dgv.Columns["dgvCOSkidComments"].Index)
            {
                if (dgv.Rows[row].Cells["dgvCOSheetWeight"].Value == null)
                {
                    SetColumnIndex method = new SetColumnIndex(SetCellCTL );

                    dgv.BeginInvoke(method, e.RowIndex);
                }
                else
                {
                    if (col == dgv.Columns["dgvCOSheetWeight"].Index)
                    {
                        SetColumnIndex method = new SetColumnIndex(SetCellCTL);

                        dgv.BeginInvoke(method, e.RowIndex);
                    }
                }
            }
            
        }

        private void DataGridViewCOOrderEntry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            tracer = "In DataGridViewCOOrderEntry_EditingControlShowing";
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);


            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;

            //columns with decimal places
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOActualPieces"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                   
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCODiag1"].Index ||
                dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCODiag2"].Index ||
                dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOThickness1"].Index ||
                dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOThickness2"].Index ||
                dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOThickness3"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigit_KeyPress);
                }
            }
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOPVC"].Index)
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCO_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCO_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOOrderEntry.CurrentRow.Index;
                }
            }
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOPVCRollIDs"].Index)
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCORoll_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCORoll_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOOrderEntry.CurrentRow.Index;
                }
            }
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOBranch"].Index)
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCOBranch_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCOBranch_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOOrderEntry.CurrentRow.Index;
                }
            }
            if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOSkidType"].Index)
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCOSkidType_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCOSkidType_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOOrderEntry.CurrentRow.Index;
                }
            }

        }

        private void ComboBoxCORoll_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In ComboBoxCORoll_SelectedIndexChanged";
        }

        private void ComboBoxCOSkidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In ComboBoxCOSkidType_SelectedIndexChanged";


            ComboBox cb = (ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {

                if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOSkidType"].Index)
                {
                    int row = dataGridViewCOOrderEntry.CurrentRow.Index;
                    dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOSkidTypeID"].Value = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOSkidTypeID"]).Items[num]);



                    int tier = Convert.ToInt32(labelCOCustomerTier.Tag);
                    int skidID = Convert.ToInt32(dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOSkidTypeID"].Value);
                    decimal width = Convert.ToDecimal(dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOCoilInfo"].Tag);
                    decimal length = Convert.ToDecimal(dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOLength"].Value);
                    decimal price = GetSkidPricing(tier, skidID, width, length);
                    dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOSkidPrice"].Value = price;

                }
            }


        }

        private void ComboBoxCOBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In ComboBoxCOBranch_SelectedIndexChanged";

            if (PVCCurrRow != dataGridViewCOOrderEntry.CurrentRow.Index)
            {
                return;
            }


            ComboBox cb = (ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {

                if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOBranch"].Index)
                {
                    int row = dataGridViewCOOrderEntry.CurrentRow.Index;
                    dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOBranchID"].Value = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOBranchID"]).Items[num]);
                }
            }
        }


        private void ComboBoxCO_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In ComboBoxCO_SelectedIndexChanged";
            //I added this because it was dropping in here on the wrong row.
            if (PVCCurrRow != dataGridViewCOOrderEntry.CurrentRow.Index)
            {
                return;
            }
            
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {


                
                if (dataGridViewCOOrderEntry.CurrentCell.ColumnIndex == dataGridViewCOOrderEntry.Columns["dgvCOPVC"].Index)
                {

                    int row = dataGridViewCOOrderEntry.CurrentRow.Index;
                    int GroupID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCID"]).Items[num]);
                    dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCID"].Value = GroupID;

                    if (GroupID > 0)
                    {
                        decimal cPrice = Convert.ToDecimal(((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCPrice"]).Items[num]);

                        //pricehere
                        System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
                        //need to add default price
                        result = InputBox.Show(
                            "Enter PVC Price", "PVC Price",
                            "Price",
                            out string output, cPrice.ToString());

                        if (result != System.Windows.Forms.DialogResult.OK)
                        {
                            //????not sure what happens if they hit cancel

                        }
                        else
                        {
                            cPrice = Convert.ToDecimal(output);
                            dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCCurrPrice"].Value = cPrice;
                            dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVC"].ToolTipText = cPrice.ToString() ;

                        }
                        dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCRollIDs"].Value = null;

                        ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCRollIDs"]).Items.Clear();
                        DataRow[] dr = PVCInventory.GroupID(GroupID);


                        for (int r = 0; r < dr.Length; r++)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCRollIDs"]).Items.Add(dr[r]["PVCID"].ToString());

                        }

                        ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCRollIDs"]).Items.Add("Choose");

                        dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOPVCRollIDs"].Value = "Choose";
                    }

                    
                }
               



            }
        }
        private void ComboBoxCOShShmBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;

            if (item != null)
            {

                if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dataGridViewCOShShSame.Columns[dgvSSSmBranch.Index].Index)
                {
                    int row = dataGridViewCOShShSame.CurrentRow.Index;
                    int branchID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmBranchID.Index]).Items[num]);
                    dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmBranchID.Index].Value = branchID;
                }
            }

        }

        private void ComboBoxCOShShmFinish_SelectedIndexChanged(object sender, EventArgs e)
        {

            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;

            if (item != null)
            {

                if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dataGridViewCOShShSame.Columns[dgvSSSmNewFinish.Index].Index)
                {
                    int row = dataGridViewCOShShSame.CurrentRow.Index;
                    int FinishID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmFinishID.Index]).Items[num]);
                    dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmFinishID.Index].Value = FinishID.ToString().Trim();
                }
            }

        }

        private void ComboBoxCOShShm_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In ComboBoxCOShShm_SelectedIndexChanged";
            //I added this because it was dropping in here on the wrong row.
            if (PVCCurrRow != dataGridViewCOShShSame.CurrentRow.Index)
            {
                return;
            }

            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {



                if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dataGridViewCOShShSame.Columns[dgvSSSmPVC.Index].Index)
                {

                    int row = dataGridViewCOShShSame.CurrentRow.Index;
                    int GroupID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCGroupID.Index]).Items[num]);
                    dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCGroupID.Index].Value = GroupID;

                    if (GroupID > 0)
                    {
                        decimal cPrice = Convert.ToDecimal(((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCPriceList.Index]).Items[num]);

                        //pricehere
                        System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
                        //need to add default price
                        result = InputBox.Show(
                            "Enter PVC Price", "PVC Price",
                            "Price",
                            out string output, cPrice.ToString());

                        if (result != System.Windows.Forms.DialogResult.OK)
                        {
                            //????not sure what happens if they hit cancel

                        }
                        else
                        {
                            cPrice = Convert.ToDecimal(output);
                            dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmCurrPrice.Index].Value = cPrice;
                            dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVC.Index].ToolTipText = cPrice.ToString();

                        }
                        dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index].Value = null;

                        ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Clear();
                        DataRow[] dr = PVCInventory.GroupID(GroupID);


                        for (int r = 0; r < dr.Length; r++)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Add(dr[r]["PVCID"].ToString());

                        }

                        ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Add("Choose");

                        dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index].Value = "Choose";
                    }
                    else
                    {
                        //customer owned == -99
                        if (GroupID == -99)
                        {
                            dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index].Value = null;
                            ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Clear(); 

                            DBUtils db = new DBUtils();
                            db.OpenSQLConn();
                            using (DbDataReader reader = db.GetPVCInventory(Convert.ToInt32(panelCOShShSame.Tag)))
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        int RollID = reader.GetInt32(reader.GetOrdinal("PVCTagID"));
                                        string rollDesc = reader.GetString(reader.GetOrdinal("PVCDesc")).Trim();
                                        ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Add(RollID.ToString().Trim() + "-" + rollDesc);
                                    }
                                    ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index]).Items.Add("Choose");

                                    dataGridViewCOShShSame.Rows[row].Cells[dgvSSSmPVCRollID.Index].Value = "Choose";
                                }
                                reader.Close();

                            }
                            db.CloseSQLConn();


                        }
                    }


                }




            }
        }
        private void ColumnDigitNoDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            tracer = "In ColumnDigitNoDecimal_KeyPress";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void ColumnDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            tracer = "In ColumnDigit_KeyPress";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void SetCellCTL(int rowIndex)
        {
            tracer = "In SetCellCTL";
            if (rowIndex < 0)
            {
                return;
            }
                
            if (rowIndex < dataGridViewCOOrderEntry.RowCount -1)
            {
                
                

                dataGridViewCOOrderEntry.CurrentCell = dataGridViewCOOrderEntry.Rows[rowIndex + 1].Cells["dgvCOActualPieces"];
                dataGridViewCOOrderEntry.BeginEdit(true);
            }

        }
        private void SetNextRowContent(int rowIndex, string cellName)
        {
            if (dataGridViewCOOrderEntry.Rows[rowIndex].Cells[cellName].Value == null)
                dataGridViewCOOrderEntry.Rows[rowIndex].Cells[cellName].Value = dataGridViewCOOrderEntry.Rows[rowIndex-1].Cells[cellName].Value;
            dataGridViewCOOrderEntry.Rows[rowIndex].Cells[cellName].Style.ForeColor = dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells[cellName].Style.ForeColor;
            dataGridViewCOOrderEntry.Rows[rowIndex].Cells[cellName].Style.BackColor = dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells[cellName].Style.BackColor;
        }

        private void DataGridViewCOOrderEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            tracer = "In DataGridViewCOOrderEntry_CellClick";
            if (e.ColumnIndex >= 0)
            {
                if (dataGridViewCOOrderEntry.Columns[e.ColumnIndex].ReadOnly)
                {
                    SetColumnIndex method = new SetColumnIndex(SetCellCTL);

                    dataGridViewCOOrderEntry.BeginInvoke(method, e.RowIndex - 1);
                }
            }
            
        }

        private void GetPVCInfo()
        {
            tracer = "In GetPVCInfo";
            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            


            using (DbDataReader reader = db.GetPVCGroup())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int PVCID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                        string PVCDesc = reader.GetString(reader.GetOrdinal("GroupName"));
                        decimal decPrice = reader.GetDecimal(reader.GetOrdinal("Price"));

                        PVCArray.Add(new PVCInfo { id = PVCID, desc = PVCDesc, price = decPrice });
                    }
                }
                PVCArray.Add(new PVCInfo { id = -99, desc = "Customer", price = 0 });
                PVCArray.Add(new PVCInfo { id = -1, desc = "None", price = 0 });
            }

            db.CloseSQLConn();
        }

        

        private void ListViewCOOpenOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracer = "In listViewCOOpenOrders_SelectedIndexChanged";
        }

        private void DataGridViewCOOrderEntry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show( e.Exception.Message + " " + tracer );
        }

        private void DataGridViewCOOrderEntry_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowIndex = e.RowIndex;

            if (rowIndex > 0)
            {


                if (e.ColumnIndex == dataGridViewCOOrderEntry.Rows[rowIndex].Cells["dgvCOActualPieces"].ColumnIndex)
                {

                    if (dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells["dgvCOPVC"].Value != null)
                    {
                        if (dataGridViewCOOrderEntry.Rows[rowIndex].Cells["dgvCOPVC"].Value.Equals(dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells["dgvCOPVC"].Value))
                        {
                            dataGridViewCOOrderEntry.Rows[rowIndex].Cells["dgvCOPVCrollIDs"].Value = dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells["dgvCOPVCrollIDs"].Value;
                        }
                    }
                   

                    if (dataGridViewCOOrderEntry.Rows[rowIndex].Cells["dgvCOCoilTagID"].Value.Equals(dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells["dgvCOCoilTagID"].Value))
                    {

                        if (dataGridViewCOOrderEntry.Rows[rowIndex].Cells["dgvCOLength"].Value.Equals(dataGridViewCOOrderEntry.Rows[rowIndex - 1].Cells["dgvCOLength"].Value))
                        {
                            SetNextRowContent(rowIndex, "dgvCODiag1");
                            SetNextRowContent(rowIndex, "dgvCODiag2");
                        }

                        SetNextRowContent(rowIndex, "dgvCOThickness1");
                        SetNextRowContent(rowIndex, "dgvCOThickness2");
                        SetNextRowContent(rowIndex, "dgvCOThickness3");
                    }
                }
            }

        }
        private void AddClClSameRow(object sender, EventArgs e)
        {
            
            
            int row = 0;

            if (dataGridViewCOOrderEntry.CurrentRow != null)
            {
                row = dataGridViewCOOrderEntry.CurrentRow.Index;
            }
            

            string tagid = dgvCOCLCLSame.Rows[row].Cells["colClClSameCoilTagID"].Value.ToString().Trim();
            
            
            for (int i = 0; i < dgvCOCLCLSame.RowCount; i++)
            {
                if (dgvCOCLCLSame.Rows[i].Cells["colClClSameCoilTagID"].Value.ToString().Equals(tagid))
                {
                    
                }
            }
        }

        private bool AddCTLRow(object sender, EventArgs e)
        {
            SkidSetup skidInfo = new SkidSetup();
            string output;

            int row = dataGridViewCOOrderEntry.CurrentRow.Index;

            string tagid = dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOCoilTagID"].Value.ToString().Trim();
            string firstletter = "";
            string lastletter = "";
            string newLetter = "";
            int firstRow = 0;
            int lastrow = 0;
            for (int i = 0; i < dataGridViewCOOrderEntry.RowCount; i++)
            {
                if (dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagID"].Value.ToString().Equals(tagid))
                {
                    if (firstletter.Equals(""))
                    {
                        firstletter = dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value.ToString().Trim();
                        lastletter = firstletter;
                        firstRow = i;
                        lastrow = i;
                    }
                    else
                    {
                        lastletter = dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value.ToString().Trim();
                        lastrow = i;
                    }
                }
            }
            skidInfo.SetFirstLetter(lastletter);
            lastletter = skidInfo.GetNextLetter();
            DialogResult result = System.Windows.Forms.DialogResult.None;

            bool keepLooping = true;

            while (keepLooping)
            {


                result = InputBox.Show(
                     "Added Letter", "Enter a letter between " + firstletter + " and " + lastletter + ".",
                    "Letter",
                    out output, lastletter, false, true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return false;

                }
                else
                {
                    if (!skidInfo.LetterInSeries(output.Trim(), firstletter, lastletter))
                    {
                        MessageBox.Show("Letter not valid");

                    }
                    else
                    {
                        newLetter = output.Trim();
                        keepLooping = false;
                    }
                }
            }
            keepLooping = true;
            decimal newLength = 0;
            while (keepLooping)
            {
                result = InputBox.Show(
                    "Length", "Enter a Length.",
                   "Length",
                   out output);

                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    //cancel
                    return false ;

                }
                else
                {
                    if (Convert.ToDecimal(output) > 250)
                    {
                        if (MessageBox.Show("Are you sure the length is " + output + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            keepLooping = false;
                            newLength = Convert.ToDecimal(output);
                        }
                    }
                    else
                    {
                        keepLooping = false;
                        newLength = Convert.ToDecimal(output);
                    }
                }
            }
            keepLooping = true;
            int pieceCount = 1;
            while (keepLooping)
            {
                result = InputBox.Show(
                    "Piece Count", "Enter a Piece Count.",
                   "Piece Count",
                   out output,"",true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    //cancel
                    return false;

                }
                else
                {
                    if (Convert.ToInt32(output) > 30)
                    {
                        if (MessageBox.Show("Are you sure the Piece Count is " + output + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            keepLooping = false;
                            pieceCount = Convert.ToInt32(output);
                        }
                    }
                    else
                    {
                        keepLooping = false;
                        pieceCount = Convert.ToInt32(output);
                    }
                }
            }
            bool scrap = false;

            if (MessageBox.Show("Is this NOT PRIME material?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                scrap = true;
            }

            string previousLetter = skidInfo.GetPreviousLetter(newLetter);
            string reLetter = "";
            bool rowadded = false;
            bool tagfound = false;
            for (int i = 0; i < dataGridViewCOOrderEntry.RowCount; i++)
            {
                //is this the correct tag?
                if (tagid.Equals(dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagID"].Value.ToString().Trim()))
                {
                    //found the correct tag;
                    tagfound = true;
                    //is this the first row fo the tag?
                    if (reLetter.Equals(""))
                    {
                        //first row.  Start with whatever letter this is.
                        reLetter = dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value.ToString();
                        skidInfo.SetFirstLetter(reLetter);
                    }
                    else
                    {
                        //not on first row so get appropriate next letter.
                        reLetter = skidInfo.GetNextLetter();
                    }

                    //is this where we want to insert?
                    if (dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value.ToString().Equals(newLetter) && !rowadded)
                    {
                        //this is where we insert

                        rowadded = true;


                        CloneRow(i, newLetter, newLength, pieceCount, scrap, false);



                    }
                    else
                    {
                        //we didn't insert but we want to make sure the letters are correct.
                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value = reLetter;
                    }

                }
                else
                {
                    //if we have found the tag but haven't added a row and we aren't on the very first row
                    //we need to add the row because it is the last row of the series.
                    if (i > 0 && rowadded == false && tagfound == true)
                    {



                        rowadded = true;

                        //since we are adding as last row we want to copy previous row (true)
                        CloneRow(i, newLetter, newLength, pieceCount, scrap, true);

                    }
                }


            }
            //we went through every row and didn't add so we need to add at the very bottom of the datagrid
            if (tagfound == true && rowadded == false)
            {

                //since i is no longer valid we will just declare it and set it to how many rows we have.
                int i = dataGridViewCOOrderEntry.RowCount;



                rowadded = true;
                //we also want to copy the previous row since we are outside the scope of rows (true)
                CloneRow(i, newLetter, newLength, pieceCount, scrap, true);
            }
            return true;
        }


        private void ButtonCOAddRow_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == CTL)
            {
                AddCTLRow(sender, e);
            }

            //if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == CoilPolish)
            //{
            //    AddClClSameRow(sender, e);
            //}


        }

        

        private void CloneRow(int i, string newLetter, decimal newLength,int pieceCount,bool scrap, bool sub1)
        {

            int k = i;

            if (sub1)
            {
                k = i - 1;
            }
            DataGridViewRow dr = new DataGridViewRow();

            dr = (DataGridViewRow) dataGridViewCOOrderEntry.Rows[k].Clone();
            for (int j = 0; j<dataGridViewCOOrderEntry.ColumnCount; j++)
            {


                dr.Cells[j].Value = dataGridViewCOOrderEntry.Rows[k].Cells[j].Value;
                dr.Cells[j].Tag = dataGridViewCOOrderEntry.Rows[k].Cells[j].Tag;

                if (dataGridViewCOOrderEntry.Columns["dgvCOLetter"].Index == j)
                {
                    dr.Cells[j].Value = newLetter;
                }
                if (dataGridViewCOOrderEntry.Columns["dgvCOLength"].Index == j)
                {
                    dr.Cells[j].Value = newLength;
                }
                if (dgvCOActualPieces.Index == j)
                {
                    dr.Cells[j].Value = pieceCount;
                }

                if (dataGridViewCOOrderEntry.Columns["dgvCONotPrime"].Index == j)
                {
                    dr.Cells[j].Value = scrap;
                    if (scrap)
                        dr.Cells[j].Style.ForeColor = Color.Red;
                }

            }
            decimal width = Convert.ToDecimal(dr.Cells[dgvCOCoilInfo.Index].Tag);

            dr.Cells[dgvCODiag1.Index].ToolTipText = Math.Round(Math.Sqrt(Convert.ToDouble((newLength * newLength) + (width * width))), 2).ToString();
            dr.Cells[dgvCODiag2.Index].ToolTipText = dr.Cells[dgvCODiag1.Index].ToolTipText;

            dataGridViewCOOrderEntry.Rows.Insert(i, dr);

        }

        private void ButtonCORemoveRow_Click(object sender, EventArgs e)
        {

            if (tabControlProcess.SelectedTab.Text.Equals("Cut To Length"))
            
            {
                int row = dataGridViewCOOrderEntry.CurrentCell.RowIndex;
                string tagID = dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOCoilTagID"].Value.ToString();
                string skidLetter = dataGridViewCOOrderEntry.Rows[row].Cells["dgvCOLetter"].Value.ToString();
                string skidID = tagID.Trim() + "." + skidLetter.Trim();
                if (MessageBox.Show("Are you sure you want to remove " + skidID + "?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                SkidSetup sk = new SkidSetup();
                sk.SetFirstLetter(skidLetter);
                dataGridViewCOOrderEntry.Rows.RemoveAt(row);
                for (int i = row; i < dataGridViewCOOrderEntry.RowCount; i++)
                {
                    //if this is the same tag
                    if (dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOCoilTagID"].Value.ToString().Equals(tagID))
                    {

                        dataGridViewCOOrderEntry.Rows[i].Cells["dgvCOLetter"].Value = skidLetter;
                        skidLetter = sk.GetNextLetter();
                    }


                }
            }
        }

        private void ButtonCOCancel_Click(object sender, EventArgs e)
        {
            dataGridViewCOOrderEntry.Rows.Clear();
            dgvCOCoilScrap.Rows.Clear();
            listViewCOTimeRecords.Items.Clear();
            
            listViewCOOpenOrders.CheckedItems[0].Checked = false;
            SetDataVisibility(false);
            listViewCOOpenOrders.BringToFront();
        }




        public void GetSkidTypes(int rowcntr, int skidTypeID)
        {


            DBUtils db = new DBUtils();
            

            using (DbDataReader reader = db.GetSkidTypeData(true))
            {
                StringBuilder sp = new StringBuilder();

                int cntr = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        SkidType sk = new SkidType
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("skidTypeID")),
                            Description = reader.GetString(reader.GetOrdinal("skidDescription")).Trim(),
                            orderby = reader.GetInt32(reader.GetOrdinal("orderby")),
                            letter = reader.GetString(reader.GetOrdinal("skidLetter")).Trim()
                        };

                        ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[rowcntr].Cells["dgvCOSkidType"]).Items.Add(sk.Description);
                        ((DataGridViewComboBoxCell)dataGridViewCOOrderEntry.Rows[rowcntr].Cells["dgvCOSkidTypeID"]).Items.Add(sk.ID);
                        sp.Append(sk.letter + " = " + sk.Description + Environment.NewLine);
                        //skidTypes.Add(sk);??????
                        
                    
                        if (sk.ID == skidTypeID)
                        {
                            dataGridViewCOOrderEntry.Rows[rowcntr].Cells["dgvCOSkidType"].Value = sk.Description;
                            dataGridViewCOOrderEntry.Rows[rowcntr].Cells["dgvCOSkidTypeID"].Value = sk.ID;
                            dataGridViewCOOrderEntry.Rows[rowcntr].Cells["dgvCOSkidType"].ToolTipText = sp.ToString();
                        }

                        cntr++;
                    }
                }

            }

            
        }

        public DbDataReader GetSkidData()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select* From " + PlantLocation.city + ".skidType ");
            sb.Append("order by orderby");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };



            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public decimal GetSkidPricing(int tierLevel, int skidTypeID, decimal width, decimal length)
        {

            decimal price = 0;
            StringBuilder sb = new StringBuilder();

            sb.Append("select skidTypeID,price From " + PlantLocation.city + ".SkidPricing ");
            sb.Append("where tierLevel =  (select max(tierlevel) from " + PlantLocation.city + ".skidpricing ");
            sb.Append("where tierlevel in (" + tierLevel.ToString() + " ,0) ");
            sb.Append("and " + skidTypeID.ToString() + " = skidTypeID ");
            sb.Append("and " + width.ToString() + " >= fromwidth ");
            sb.Append("and " + width.ToString() + " < ToWidth ");
            sb.Append("and " + length.ToString() + " >= FromLength ");
            sb.Append("and " + length.ToString() + " < ToLength) ");
            sb.Append("and " + skidTypeID.ToString() + " = skidTypeID ");
            sb.Append("and " + width.ToString() + " >= fromwidth ");
            sb.Append("and " + width.ToString() + " < ToWidth ");
            sb.Append("and " + length.ToString() + " >= FromLength ");
            sb.Append("and " + length.ToString() + " < ToLength");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    price = reader.GetDecimal(reader.GetOrdinal("Price"));
                }
            }

            return price;
        }

        public int InsertOrderTime(OrderTime ot, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".OrderTimes ");
            sb.Append("(orderID, sequenceNum, startDate, endDate) ");
            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@orderID, @sequenceNum, @startDate, @endDate) ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };




            cmd.Parameters.AddWithValue("@orderID", ot.orderID);
            cmd.Parameters.AddWithValue("@sequenceNum", ot.sequence);
            cmd.Parameters.AddWithValue("@startDate", ot.start);
            cmd.Parameters.AddWithValue("@endDate", ot.end);
            

            int skidID = (int)cmd.ExecuteScalar();

            return skidID;

        }

        public int InsertSkidDataRecord(SkidData sd, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".SkidData ");
            sb.Append("(skidID,coilTagSuffix, letter,location,alloyID,finishID,customerID,branchID,");
            sb.Append("orderID,sequenceNum,sheetWeight,length,width,diagnol1,diagnol2,mic1,mic2,mic3,");
            sb.Append("orderedPieceCount,pieceCount,pvcID,pvcPrice, paper,comments,skidStatus,skidTypeID,");
            sb.Append("skidPrice,notPrime) ");
            sb.Append("output INSERTED.skidID ");
            sb.Append("VALUES(@skidID,@coilTagSuffix,@letter,@location,@alloyID,@finishID,@customerID,@branchID,");
            sb.Append("@orderID,@sequenceNum,@sheetWeight,@length,@width,@diagnol1,@diagnol2,@mic1,@mic2,@mic3,");
            sb.Append("@orderedPieceCount,@pieceCount,@pvcID,@pvcPrice,@paper,@comments,@status,@skidTypeID,");
            sb.Append("@skidPrice,@notPrime) ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };




            cmd.Parameters.AddWithValue("@skidID", sd.skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", sd.coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", sd.letter);
            cmd.Parameters.AddWithValue("@location", sd.location);
            cmd.Parameters.AddWithValue("@alloyID", sd.alloyID);
            cmd.Parameters.AddWithValue("@finishID", sd.finishID);
            cmd.Parameters.AddWithValue("@customerID", sd.customerID);
            cmd.Parameters.AddWithValue("@branchID", sd.branchID);

            cmd.Parameters.AddWithValue("@orderID", sd.orderID);
            cmd.Parameters.AddWithValue("@sequenceNum", sd.sequenceNumber);
            cmd.Parameters.AddWithValue("@sheetWeight", sd.sheetWeight);
            cmd.Parameters.AddWithValue("@length", sd.length );
            cmd.Parameters.AddWithValue("@width", sd.width);
            cmd.Parameters.AddWithValue("@diagnol1", sd.diagnol1 );



            cmd.Parameters.AddWithValue("@diagnol2", sd.diagnol2);
            cmd.Parameters.AddWithValue("@mic1", sd.mic1);
            cmd.Parameters.AddWithValue("@mic2", sd.mic2);
            cmd.Parameters.AddWithValue("@mic3", sd.mic3);
            cmd.Parameters.AddWithValue("@orderedPieceCount", sd.orderedPieceCount );
            cmd.Parameters.AddWithValue("@pieceCount", sd.pieceCount);

            cmd.Parameters.AddWithValue("@pvcID", sd.pvcID);
            cmd.Parameters.AddWithValue("@pvcPrice", sd.pvcPrice);
            cmd.Parameters.AddWithValue("@paper", sd.paper);
            cmd.Parameters.AddWithValue("@comments", sd.comments);
            cmd.Parameters.AddWithValue("@status", sd.status);
            cmd.Parameters.AddWithValue("@skidTypeID", sd.skidTypeID);
            cmd.Parameters.AddWithValue("@skidPrice", sd.skidPrice);
            cmd.Parameters.AddWithValue("@notPrime", sd.notPrime);

            int skidID = (int)cmd.ExecuteScalar();

            return skidID;

        }

  
        private void ButtonCORecordTime_Click(object sender, EventArgs e)
        {

            ListViewItem lv = new ListViewItem();

            lv.SubItems[0].Text = dateTimePickerCOStartDate.Text + " " + dateTimePickerCOStartTime.Text;
            lv.SubItems.Add("");
            lv.SubItems[1].Text = dateTimePickerCOEndDate.Text + " " + dateTimePickerCOEndTime.Text;

            listViewCOTimeRecords.Items.Add(lv);

        }

        private void ButtonCORemoveTime_Click(object sender, EventArgs e)
        {
            if (listViewCOTimeRecords.SelectedItems.Count > 0)
            {
                listViewCOTimeRecords.Items.RemoveAt(listViewCOTimeRecords.SelectedItems[0].Index);
            }
        }

        private void DgvCOCoilScrap_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);


            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;

            //columns with decimal places
            if (dgvCOCoilScrap.CurrentCell.ColumnIndex == dgvCOCoilScrap.Columns["dgvCOScrapAmount"].Index||
                dgvCOCoilScrap.CurrentCell.ColumnIndex == dgvCOCoilScrap.Columns["dgvCOScrapTagEndWeight"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {

                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
        }

        private void DgvCOCoilScrap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCOScrapAmount.Index)
            {
                if (Convert.ToDecimal(dgvCOCoilScrap.Rows[e.RowIndex].Cells["dgvCoScrapTagID"].Tag) < 0)
                {
                    MessageBox.Show("You can't have negative scrap");
                }
                if (Convert.ToDecimal (dgvCOCoilScrap.Rows[e.RowIndex].Cells["dgvCoScrapTagID"].Tag) < Convert.ToDecimal(dgvCOCoilScrap.Rows[e.RowIndex].Cells["dgvCoScrapAmount"].Value))
                {
                    MessageBox.Show("You can't scrap more than the original weight");
                    dgvCOCoilScrap.Rows[e.RowIndex].Cells["dgvCoScrapAmount"].Value = null;
                    dgvCOCoilScrap.CurrentCell = dgvCOCoilScrap.Rows[e.RowIndex].Cells["dgvCoScrapAmount"];
                    dgvCOCoilScrap.BeginEdit(true);
                }
            }


        }

        private void ButtonClClRecordTime_Click(object sender, EventArgs e)
        {

            

            if (dateTimePickerClClSameStartDate.Value.Date > dateTimePickerClClSameEndDate.Value.Date)
            {
                MessageBox.Show("Start date must be less than end date!");
            }

            if (dateTimePickerClClSameStartTime.Value.TimeOfDay  > dateTimePickerClClSameEndTime.Value.TimeOfDay)
            {
                if (dateTimePickerClClSameStartDate.Value.Date >= dateTimePickerClClSameEndDate.Value.Date)
                {
                    MessageBox.Show("Start time must be less than end time!");
                    return;
                }
                    
                
            }
            ListViewItem lv = new ListViewItem();

            lv.SubItems[0].Text = dateTimePickerClClSameStartDate.Text + " " + dateTimePickerClClSameStartTime.Text;
            lv.SubItems.Add("");
            lv.SubItems[1].Text = dateTimePickerClClSameEndDate.Text + " " + dateTimePickerClClSameEndTime.Text;


            listViewClClSameTimeRecords.Items.Add(lv);
        }

        private void ButtonClClRemoveTime_Click(object sender, EventArgs e)
        {
            if (listViewClClSameTimeRecords.SelectedItems.Count > 0)
            {
                listViewClClSameTimeRecords.Items.RemoveAt(listViewClClSameTimeRecords.SelectedItems[0].Index);
            }
        }

        private void ButtonClClSame_Cancel_Click(object sender, EventArgs e)
        {
            dgvCOCLCLSame.Rows.Clear();
            //dgvCOCoilScrap.Rows.Clear();
            listViewClClSameTimeRecords.Items.Clear();
            if (listViewCOOpenOrders.CheckedItems.Count > 0)
            {
                listViewCOOpenOrders.CheckedItems[0].Checked = false;
            }
            panelCOClClSame.SendToBack();
            listViewCOOpenOrders.BringToFront();
            SetDataVisibility(false);
        }

        private void Temp(object sender, DataGridViewCellEventArgs e)
        {
            int newlbs = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            int origlbs = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOrigLBS.Index].Value);

            int totlbs = 0;
            bool deleteRow = false;
            int totcnt = 0;
            string coilID = dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilTagID.Index].Value.ToString();
            for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
            {
                if (coilID.Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameCoilTagID.Index].Value.ToString()))
                {
                    totcnt++;
                }
            }

            if (newlbs == 0 && totcnt > 1)
            {
                //need to delete row and redistribute the weight.
                dgvCOCLCLSame.Rows.RemoveAt(e.RowIndex);
                deleteRow = true;

            }


            int firstRow = 0;
            bool foundRow = false;
            for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
            {
                if (coilID.Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameCoilTagID.Index].Value.ToString()))
                {
                    if (deleteRow && foundRow)
                    {
                        firstRow = i;
                        foundRow = true;
                    }
                    totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[e.ColumnIndex].Value);
                    if (dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value != null)
                        if (!dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                            totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value);
                }
            }
            if (deleteRow)
            {
                dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value = (origlbs + Convert.ToInt32(dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value)) - (totlbs);
                return;
            }


            int scraplbs = 0;
            if (dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value != null &&
                !dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
            {
                scraplbs = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value);

            }
            if (totlbs > origlbs)
            {
                MessageBox.Show("You have " + Convert.ToString(newlbs + scraplbs - origlbs) + "-lbs too much");
                dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                return;
            }
            if (totlbs < origlbs)
            {
                if (scraplbs == 0)
                {

                    if (origlbs - totlbs < (origlbs * .04))
                    {
                        scraplbs = origlbs - newlbs;
                        dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = scraplbs;
                    }
                    else
                    {
                        if (MessageBox.Show("Create a " + Convert.ToString(origlbs - totlbs) + " lbs coil?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            //add new row
                            DataGridViewRow dr = new DataGridViewRow();
                            dr = (DataGridViewRow)dgvCOCLCLSame.Rows[e.RowIndex].Clone();
                            for (int i = 0; i < dr.Cells.Count; i++)
                            {
                                dr.Cells[i].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Value;
                                dr.Cells[i].Tag = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Tag;
                                if (i == e.ColumnIndex)
                                {
                                    dr.Cells[i].Value = origlbs - totlbs;
                                }
                            }
                            dgvCOCLCLSame.Rows.Insert(e.RowIndex + 1, dr);
                            dgvCOCLCLSame.Refresh();

                        }
                        else
                        {
                            dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = origlbs - totlbs;
                        }

                    }

                }
                else
                {
                    if (newlbs + scraplbs > origlbs)
                    {
                        if (MessageBox.Show("You have " + Convert.ToString(newlbs + scraplbs - origlbs) + " lbs too many. Adjust Scrap?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = origlbs - newlbs;
                        }
                    }
                    if (origlbs - newlbs < (origlbs * .04))
                    {
                        if (MessageBox.Show("Change Scrap to " + Convert.ToString(origlbs - newlbs).Trim() + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            scraplbs = origlbs - newlbs;
                            dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = scraplbs;
                        }
                        else
                        {
                            //do we really need to ask this?
                            MessageBox.Show("Make another coil for the " + Convert.ToString(origlbs - scraplbs).Trim() + " lbs?");
                        }

                    }
                    else
                    {
                        if (MessageBox.Show("Create a " + Convert.ToString(origlbs - totlbs - scraplbs) + " lbs coil?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            //add new row
                            DataGridViewRow dr = new DataGridViewRow();
                            dr = (DataGridViewRow)dgvCOCLCLSame.Rows[e.RowIndex].Clone();
                            for (int i = 0; i < dr.Cells.Count; i++)
                            {
                                dr.Cells[i].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Value;
                                dr.Cells[i].Tag = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Tag;
                                if (i == e.ColumnIndex)
                                {
                                    dr.Cells[i].Value = origlbs - totlbs - scraplbs;
                                }
                            }
                            dr.Cells[colClClSameScrap.Index].Value = "";
                            dgvCOCLCLSame.Rows.Insert(e.RowIndex + 1, dr);
                            dgvCOCLCLSame.Refresh();

                        }
                        else
                        {
                            dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = origlbs - totlbs;
                        }
                    }
                }

            }
        }
        private void ScrapWeightChange()
        {
            DataGridViewRow dr = dgvCOCLCLSame.Rows[row];
            int totlbs = 0;
            int origweight = Convert.ToInt32(dr.Cells[colClClSameOrigLBS.Index].Value);
            int newWeight = Convert.ToInt32(dr.Cells[colClClSamePolishLBS.Index].Value);
            int scrapWeight = 0;
            if (dr.Cells[colClClSameScrap.Index].Value != null)
            {
                if (!dr.Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                {
                    scrapWeight = Convert.ToInt32(dr.Cells[colClClSameScrap.Index].Value);
                }
            }
            
            

            
            if (scrapWeight < 0)
            {

                MessageBox.Show("You cannot have a negative number");

                //revert back
                dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Value = dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Tag;
                return;
            }
            if (dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Tag != null)
            {
                if (!dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Tag.ToString().Equals(""))
                {
                    totlbs = Convert.ToInt32(dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Tag);
                }
            }
            totlbs += newWeight;

            if (scrapWeight > 0 && newWeight > 0)
            {
                if (scrapWeight > totlbs)
                {

                    MessageBox.Show("You cannot scrap more than the coil weight");

                    //revert back
                    dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Value = dgvCOCLCLSame.Rows[row].Cells[colClClSameScrap.Index].Tag;
                    return;
                }
                totlbs -= scrapWeight;
                dgvCOCLCLSame.Rows[row].Cells[colClClSamePolishLBS.Index].Value = totlbs;
            }
            //need to loop trhough and add up weights for total.
            totlbs = 0;
            //string coilID = dgvCOCLCLSame.Rows[row].Cells[colClClSameCoilTagID.Index].Value.ToString();
            string coilID = dgvCOCLCLSame.Rows[row].Cells[colClClSameOriginalTag.Index].Value.ToString();
            for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
            {
                if (coilID.Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameOriginalTag.Index].Value.ToString()))
                {
                    if (i != row)
                    {
                        totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSamePolishLBS.Index].Value);
                    }
                    if (dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value != null)
                        if (!dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                            totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value);
                }
            }
            dgvCOCLCLSame.Rows[row].Cells[colClClSamePolishLBS.Index].Value = origweight - totlbs;


        }
        private void DgvCOCLCLSame_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == colClClSamePolishLBS.Index)
            {
                //We are changing the polished lbs.  What coil is this?
                string coilID = dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOriginalTag.Index].Value.ToString();
                string origCoilTagSuffix = dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOrigTagSuffix.Index].Value.ToString().Trim();
                string newCoilTagSuffix = dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameNewTagSuffix.Index].Value.ToString().Trim();
                //What is the original weight of the coil?
                //What is the new weight?
                int newlbs = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (newlbs < 0)
                {
                    MessageBox.Show("Negative numbers not allowed.  Reverting back weight.");
                    dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                    return;
                }
                int origlbs = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOrigLBS.Index].Value);

                int totlbs = 0;
                //bool deleteRow = false;
                int totcnt = 0;
                int firstRow = -1;

                //bobby 1-11-23 need to look at base tagsuffix and not whole tag.

                for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
                {
                    if (dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOriginalTag.Index].Value.ToString().Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameOriginalTag.Index].Value.ToString()))
                    {
                        totcnt++;
                        if (firstRow == -1)
                        {
                            firstRow = i;
                        }
                    }
                }

                if (newlbs == 0 && totcnt > 1)
                {
                    //need to delete row and redistribute the weight.

                    if (e.RowIndex == firstRow)
                    {
                        MessageBox.Show("You cannot zero out the master coil.");
                        dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                        return;
                    }
                    dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value = Convert.ToInt32(dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value) + Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                    if (dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value != null)
                    {
                        if (!dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                        {
                            //add up the scrap if it is not null.
                            dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value = Convert.ToInt32(dgvCOCLCLSame.Rows[firstRow].Cells[e.ColumnIndex].Value) + Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value);
                        }

                    }
                    
                    dgvCOCLCLSame.Rows.RemoveAt(e.RowIndex);
                    //we have to renumber the divisions.  Get the first one.
                    newCoilTagSuffix = coilID.ToString() + dgvCOCLCLSame.Rows[firstRow].Cells[colClClSameNewTagSuffix.Index].Value.ToString().Trim();
                    //start renumbering.
                    RenumberTagSuffix(coilID, newCoilTagSuffix);
                    return;
                }
                else
                {
                    if (newlbs == 0)
                    {
                        //there was only one line.  can't delete or make zero.
                        MessageBox.Show("You cannot zero out the master coil.");
                        dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                        return;
                    }
                    
                }
                 

                //What is the total weight in this order, including scrap.
                for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
                {
                    if (coilID.Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameOriginalTag.Index].Value.ToString()))
                    {
                        //add up the coil weight
                        totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[e.ColumnIndex].Value);
                        if (dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value != null)
                        {
                            if (!dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                            {
                                //add up the scrap if it is not null.
                                totlbs += Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSameScrap.Index].Value);
                            }
                                
                        }
                            
                    }
                }

                if (totlbs > origlbs)
                {
                    MessageBox.Show("The total is too much.  Reverting back weight.");
                    dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                    //there is too much weight
                }
                else
                {
                    if (totlbs < origlbs)
                    {
                        int leftLBS = origlbs - totlbs;
                        //do we add the extra weight to another line or scrap?
                        if (MessageBox.Show("Create a " + leftLBS.ToString() + " lbs coil?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //create another row
                            DataGridViewRow dr = new DataGridViewRow();
                            dr = (DataGridViewRow)dgvCOCLCLSame.Rows[e.RowIndex].Clone();
                            for (int i = 0; i < dr.Cells.Count; i++)
                            {
                                dr.Cells[i].Value = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Value;
                                dr.Cells[i].Tag = dgvCOCLCLSame.Rows[e.RowIndex].Cells[i].Tag;
                                if (i == e.ColumnIndex)
                                {
                                    dr.Cells[i].Value = origlbs - totlbs;
                                    dr.Cells[i].Tag = dr.Cells[i].Value;
                                }
                            }
                            dr.Cells[colClClSameScrap.Index].Value = "";
                            

                            

                            dgvCOCLCLSame.Rows.Insert(e.RowIndex + 1, dr);
                            //We now have to renumber all of the rows.
                            //Get the tag suffix on the first row.
                            newCoilTagSuffix = coilID.ToString();// + dgvCOCLCLSame.Rows[firstRow].Cells[colClClSameNewTagSuffix.Index].Value.ToString().Trim();
                                                                 //break it into pieces

                            coilID = dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameOriginalTag.Index].Value.ToString().Trim();
                            newCoilTagSuffix = coilID;
                            RenumberTagSuffix(coilID, newCoilTagSuffix);
                            //only needed refresh for debugging.
                            //dgvCOCLCLSame.Refresh();
                        }
                        else
                        {
                            int scrap = 0;
                            if (dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value != null)
                                if (!dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value.ToString().Equals(""))
                                    scrap = Convert.ToInt32(dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value);
                            scrap += (origlbs - totlbs);
                            dgvCOCLCLSame.Rows[e.RowIndex].Cells[colClClSameScrap.Index].Value = scrap;
                        }
                    }
                    dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                
                //Does the total weight add up to the original weight?
                //If we are short on weight where does it go?
            }
            if (e.ColumnIndex == colClClSameScrap.Index)
            {

                ScrapWeightChange();

            }
            
        }
        private void RenumberTagSuffix(string coilID, string newCoilTagSuffix)
        {
            string[] tags = newCoilTagSuffix.Split('.');
            //is there anything there?
            int newtag = -1;
            if (tags.Length > 0)
            {
                newCoilTagSuffix = "";
                newtag = Convert.ToInt32(tags[tags.Length - 1]);

                for (int i = 1; i < tags.Length - 1; i++)
                {
                    newCoilTagSuffix += "." + tags[i];
                }

            }

            TagParser tp = new TagParser();
            tp.TagToBeParsed = coilID + newCoilTagSuffix;
            tp.ParseTag();
            int coilTagID = tp.TagID;
            string coilTagSuffix = tp.CoilTagSuffix;
               

            CoilSetup cs = new CoilSetup();
            cs.coilTagID = coilTagID;
            cs.coilTagSuffix = newCoilTagSuffix;
            //cs.SetStartPoint(newCoilTagSuffix);

            cs.resetTag();

            //string test = cs.getNextSuffix();
            //test = cs.getNextSuffix();
            //test = cs.getNextSuffix();
            

            
            for (int i = 0; i < dgvCOCLCLSame.Rows.Count; i++)
            {
                if (coilID.Equals(dgvCOCLCLSame.Rows[i].Cells[colClClSameOriginalTag.Index].Value.ToString()))
                {

                    string suff = cs.getNextSuffix();
                    dgvCOCLCLSame.Rows[i].Cells[colClClSameNewTagSuffix.Index].Value = suff;
                    dgvCOCLCLSame.Rows[i].Cells[colClClSameCoilTagID.Index].Value = coilTagID + suff;
                    
                }
            }
        }
        
        private void DgvCOCLCLSame_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if (e.ColumnIndex == colClClSamePolishLBS.Index || e.ColumnIndex == colClClSameScrap.Index)
            {
                dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = dgvCOCLCLSame.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                
            }
            
        }

    
        private void DgvCOCLCLSame_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        
        private void DgvCOCLCLSame_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgvCOCLCLSame.Rows[row];
                int scrapWeight = Convert.ToInt32(dr.Cells[colClClSameScrap.Index].Value);

                decimal thk = Convert.ToDecimal(dr.Cells[colClCLSameThickness.Index].Value);
                decimal wdt = Convert.ToDecimal(dr.Cells[colClClSameWidth.Index].Value);
                decimal lng = Convert.ToDecimal(scrapWeight);
                decimal density = Convert.ToDecimal(dr.Cells[colClClSameNewFinish.Index].Tag);

                MetalFormula mt = new MetalFormula();
                decimal sweight = mt.MetFormula(density, thk, lng, wdt, 1, 0);
                dr.Cells[colClClSameScrap.Index].Value = sweight;
                ScrapWeightChange();
            }
        }

        private void DgvCOCLCLSame_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (dgvCOCLCLSame.CurrentCell.ColumnIndex == colClClSameScrap.Index)
            {

                if (e.KeyCode == Keys.Return)
                {

                }
            }
        }

        private void DgvCOCLCLSame_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void DgvCOCLCLSame_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl tb)
            {
                tb.KeyDown -= DgvCOCLCLSame_KeyDown;
                tb.KeyDown += DgvCOCLCLSame_KeyDown;
            }
            if (dgvCOCLCLSame.CurrentCell.ColumnIndex == colClClSameNewFinish.Index)
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCLCLSame_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCLCLSame_SelectedIndexChanged);

                }
            }
        }

        private void ComboBoxCLCLSame_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {
                int row = dgvCOCLCLSame.CurrentCell.RowIndex;
                int FinishID =  Convert.ToInt32(((DataGridViewComboBoxCell)dgvCOCLCLSame.Rows[row].Cells[colClClSameNewFinishID.Index]).Items[num]);

                dgvCOCLCLSame.Rows[row].Cells[colClClSameNewFinishID.Index].Value = FinishID.ToString() ;
            }
        }
        private int AddCLCLSame()
        {
            int ordID = Convert.ToInt32(listViewCOOpenOrders.CheckedItems[0].SubItems[0].Text);
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            SqlTransaction tran = db.StartTrans();
            int retVal = -1;

            try
            {

                //update order_hdr

                db.UpdateOrderHdr(ordID, -1, tran);

                //insert time records
                

                ListView lv = listViewClClSameTimeRecords;

                int timecntr = lv.Items.Count;
                OrderTime ot = new OrderTime();

                for (int t = 0; t < timecntr; t++)
                {
                    ot.orderID = ordID;
                    ot.sequence = t;
                    ot.start = Convert.ToDateTime(lv.Items[t].SubItems[0].Text);
                    ot.end = Convert.ToDateTime(lv.Items[t].SubItems[1].Text);

                    db.InsertOrderTime(ot, tran);
                }


                int prevtag = -1;
                string prevSuf = "NO";
                bool needToInsert = false;


                db.DeleteCoilPolishDtl(ordID, tran);
                ClClSameDtlInfo polDtl = new ClClSameDtlInfo();
                for (int i = 0; i < dgvCOCLCLSame.RowCount; i++)
                {
                    //if mastercoil
                    //update coil
                    TagParser tp = new TagParser();
                    tp.TagToBeParsed = dgvCOCLCLSame.Rows[i].Cells[colClClSameCoilTagID.Index].Value.ToString().Trim();
                    tp.ParseTag();



                    int tagid = tp.TagID;
                    string tagsuffix = dgvCOCLCLSame.Rows[i].Cells[colClClSameOrigTagSuffix.Index].Value.ToString();

                    string newTagSuffix = dgvCOCLCLSame.Rows[i].Cells[colClClSameNewTagSuffix.Index].Value.ToString();

                    
                    //is this same as previous coil?
                    if (i == 0)
                    {
                        prevtag = tagid;
                        prevSuf = newTagSuffix;
                        db.UpdateCoilStatus(tagid, tagsuffix, -1, tran);
                    }
                    else
                    {
                        if (prevtag!= tagid)
                        {
                            needToInsert = false;
                            prevtag = tagid;
                            prevSuf = newTagSuffix;
                            db.UpdateCoilStatus(tagid, tagsuffix, -1, tran);
                        }
                        
                    }
                    int weight = Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSamePolishLBS.Index].Value);
                    int newFinishID = Convert.ToInt32(dgvCOCLCLSame.Rows[i].Cells[colClClSameNewFinishID.Index].Value);
                    if (needToInsert)
                    {
                        polDtl.orderID = ordID;
                        polDtl.coilTagID = tagid;
                        polDtl.coilTagSuffix = tagsuffix;
                        polDtl.newCoilTagSuffix = newTagSuffix;
                        polDtl.Weight = weight;
                        polDtl.FinishID = newFinishID;

                        db.AddCoilPolishDtl(polDtl, tran);


                        int retval = db.DuplicateCoil(tagid,prevSuf,newTagSuffix, newFinishID, weight, tran);
                        
                        PrintCoildLabel(i, tagid, newTagSuffix, tran, db);
                        //print label
                        
                    }
                    else
                    {
                        if (tagsuffix != newTagSuffix)
                        {
                            //insert if next records are same coil.
                            //update on this one because coil has been split/broken
                            needToInsert = true;

                            polDtl.orderID = ordID;
                            polDtl.coilTagID = tagid;
                            polDtl.coilTagSuffix = tagsuffix;
                            polDtl.newCoilTagSuffix = newTagSuffix;
                            polDtl.Weight = weight;
                            polDtl.FinishID = newFinishID;

                            db.AddCoilPolishDtl(polDtl, tran);

                            int retval = db.DuplicateCoil(tagid, tagsuffix, newTagSuffix, newFinishID, weight, tran);

                            //print label
                            PrintCoildLabel(i, tagid, newTagSuffix, tran, db);
                            
                        }
                        else
                        {
                            needToInsert = true;

                            polDtl.orderID = ordID;
                            polDtl.coilTagID = tagid;
                            polDtl.coilTagSuffix = tagsuffix;
                            polDtl.newCoilTagSuffix = newTagSuffix;
                            polDtl.Weight = weight;
                            polDtl.FinishID = newFinishID;

                            db.AddCoilPolishDtl(polDtl, tran);

                            int retval = db.DuplicateCoil(tagid, tagsuffix, newTagSuffix, newFinishID, weight, tran);

                            
                            //print label
                            PrintCoildLabel(i, tagid, newTagSuffix, tran, db);
                            
                        }
                    }

                }

                tran.Commit();

                retVal = 1;
         
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
                if (tran.Connection != null)
                {
                    tran.Rollback();
                }
                
                return -1;
            }

            dgvCOCLCLSame.Rows.Clear();

            listViewClClSameTimeRecords.Items.Clear();


            listViewCOOpenOrders.BringToFront();
            if (listViewCOOpenOrders.CheckedItems.Count > 0)
            {
                listViewCOOpenOrders.CheckedItems[0].Remove();
            }
            listViewCOOpenOrders.BringToFront();
            panelCOClClSame.SendToBack();
            SetDataVisibility(false);
            
            return retVal;
        }

        private void ButtonClClSame_Commit_Click(object sender, EventArgs e)
        {
            //make sure time has been recorded.

            if (listViewClClSameTimeRecords.Items.Count == 0)
            {
                MessageBox.Show("You must record a time first.");
                return;
            }

            if (AddCLCLSame() == 1)
            {

            }

        }

        private void btShShSmCancel_Click(object sender, EventArgs e)
        {
            dataGridViewCOShShSame.Rows.Clear();
            for (int i = 0;i < listViewCOOpenOrders.CheckedItems.Count;i++)
            {
                listViewCOOpenOrders.CheckedItems[i].Checked = false;
            }
            lvwSSSmTimes.Items.Clear(); 

            panelCOShShSame.SendToBack();
        }

        private void dataGridViewCOShShSame_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)

        {

            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black;
        }

        private void ShShSame_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewCOShShSame_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ShShSame_KeyPress);

            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;

            if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dgvSSSmPieces.Index) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ShShSame_KeyPress);
                }
            }

            if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dgvSSSmPVC.Index) //Desired Column
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCOShShm_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCOShShm_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOShShSame.CurrentRow.Index;
                }

            }

            if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dgvSSSmNewFinish.Index) //Desired Column
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCOShShmFinish_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCOShShmFinish_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOShShSame.CurrentRow.Index;
                }

            }
            if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dgvSSSmBranch.Index) //Desired Column
            {
                if (e.Control is ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCOShShmBranch_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCOShShmBranch_SelectedIndexChanged);
                    PVCCurrRow = dataGridViewCOShShSame.CurrentRow.Index;
                }

            }
            if (dataGridViewCOShShSame.CurrentCell.ColumnIndex == dgvSSSmSkidPrice.Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBoxNumber_KeyDown);
            }
        }

        private void btnCOShShSameCompleteOrder_Click(object sender, EventArgs e)
        {
            //if there is a breakskid the original piece count is in this tag.
            //check it to make sure piece counts add up.
            //dgv.Rows[i].Cells[dgvSSSmPieces.Index].Tag = origSkidCount;

            int timecntr = lvwSSSmTimes.Items.Count;


            if (lvwSSSmTimes.Items.Count <= 0)
            {
                MessageBox.Show("You Must enter a time.");
                return;
            }
            if (textBoxSSSmPrice.Text.Length <= 0)
            {
                MessageBox.Show("You Must Have a price.");
                textBoxSSSmPrice.Focus();
                return;
            }
            if (textBoxSSSmPO.Text.Length <= 0)
            {
                MessageBox.Show("You Must Have a PO.");
                textBoxSSSmPO.Focus(); 
                return;
            }
            for (int i = 0;i < dataGridViewCOShShSame.Rows.Count; i++)
            {
                Boolean checkForNonZero = false;

                //if it is a break skid the total piece count is in the tag of the piece count column
                int origPcCnt = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPieces.Index].Tag);
                int skidPcs = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPieces.Index].Value);
                if (dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidPrice.Index].Value == null || dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidPrice.Index].Value.ToString().Length <=0)
                {
                    MessageBox.Show("Skid Price must exist!  Missing on row " + (i+1));
                    return;
                }
                if (Convert.ToBoolean(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmBreakSkid.Index].Value) == false)
                {
                    //this is not a break skid so original piece count is in the tag of the row.
                    origPcCnt = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Tag);
                    if (origPcCnt != skidPcs)
                    {
                        MessageBox.Show("Pieces must equal " + origPcCnt.ToString().Trim() + ", which is original piece count!");
                        dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPieces.Index].Value = dataGridViewCOShShSame.Rows[i].Tag;
                        return;
                    }
                }
                else
                {
                    string origSkidID = dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmBreakSkid.Index].Tag.ToString().Trim();
                    int totPcs = 0;
                    string prevSkID = origSkidID;
                    for (int j =0; j < dataGridViewCOShShSame.Rows.Count; j++)
                    {
                        
                        if (dataGridViewCOShShSame.Rows[j].Cells[dgvSSSmBreakSkid.Index].Tag != null)
                        {
                            if (dataGridViewCOShShSame.Rows[j].Cells[dgvSSSmBreakSkid.Index].Tag.ToString().Trim().Equals(origSkidID))
                            {
                                int x = Convert.ToInt32(dataGridViewCOShShSame.Rows[j].Cells[dgvSSSmPieces.Index].Value);
                                totPcs += x;
                                if (x == 0)
                                {
                                    //check to see if this occurs again;
                                    checkForNonZero = true;
                                    prevSkID = dataGridViewCOShShSame.Rows[j].Cells[dgvSSSmBreakSkid.Index].Tag.ToString().Trim();
                                }
                                else
                                {
                                    if (checkForNonZero)
                                    {
                                        MessageBox.Show("Only the last item(s) can be zero for " + origSkidID + "!");
                                        return;
                                    }
                                }
                                
                                
                            }
                        }
                        
                    }
                    if (totPcs != origPcCnt)
                    {
                        MessageBox.Show("Skid " + origSkidID + " must add up to " + origPcCnt + "! Cnt=" + totPcs.ToString().Trim());
                        return;
                    }
                    
                    
                }
                //if the pvc is anything other than "None"
                if (!dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVC.Index].Value.ToString().Trim().Equals("None"))
                {
                    //make sure a roll has been selected
                    string pvcInfo = dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVCRollID.Index].Value.ToString();
                    string[] pvcArr = pvcInfo.Split('-');

                    string pvcRoll = pvcArr[0];


                    if (!IsNumber(pvcRoll))
                    {
                        MessageBox.Show("Please pick a PVC roll for " + dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidID.Index].Value.ToString());
                        return;
                    }
                }

            }

            //seems all is well
            int orderID = Convert.ToInt32(lblOrderID.Text);

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            
            SkidData skidData = new SkidData();

            
           
 
            SqlTransaction trans = db.StartTrans();
            

            try
            {

                List<int> pvcIDs = new List<int>();


                GFG gg = new GFG();



                for (int i = 0; i < dataGridViewCOShShSame.Rows.Count; i++)
                {
                    if (!dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVC.Index].Value.ToString().Trim().Equals("None"))
                    {
                        string pvcInfo = ((DataGridViewComboBoxCell)dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVCRollID.Index]).Value.ToString().Trim();
                        string[] pvcArr = pvcInfo.Split('-');

                        string pvcRoll = pvcArr[0];

                        int currID = Convert.ToInt32(pvcRoll);
                        bool addID = true;
                        //make sure the pvc tag is only in the list once.
                        foreach (int id in pvcIDs)
                        {
                            if (currID == id)
                            {
                                addID = false;
                            }
                        }

                        if (addID)
                        {
                            //didn't find the id so add to the list
                            pvcIDs.Add(currID);
                        }
                    }
                   
                }

                // use of List<T>.Sort(IComparer<T>)  
                // method. The comparer is "gg" 
                pvcIDs.Sort(gg);


                RemovePVCRolls(pvcIDs, dgvSSSmPieces.Index, dgvSSSmLength.Index, dgvSSSmPVCRollID.Index, dataGridViewCOShShSame, db, orderID, trans);




                string customerName = "";
                   

                AddOrderTime(timecntr, orderID, lvwSSSmTimes, trans);

                PrintLabels pl = new PrintLabels();
                List<SkidsToPrint> stp = new List<SkidsToPrint>();

                for (int i = 0; i < dataGridViewCOShShSame.Rows.Count; i++)
                {


                    



                    skidData.skidID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidIDBase.Index].Value);
                    skidData.coilTagSuffix = dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmCoilTagSuffix.Index].Value.ToString().Trim();
                    skidData.letter = dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidLetter.Index].Value.ToString().Trim();

                    DbDataReader reader = db.GetSkidData(skidData.skidID, skidData.coilTagSuffix, skidData.letter, trans);
                    

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            skidData.length = reader.GetDecimal(reader.GetOrdinal("length"));
                            skidData.location = reader.GetString(reader.GetOrdinal("location"));
                            skidData.sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                            skidData.width = reader.GetDecimal(reader.GetOrdinal("width"));
                            skidData.diagnol1 = reader.GetDecimal(reader.GetOrdinal("diagnol1"));
                            skidData.diagnol2 = reader.GetDecimal(reader.GetOrdinal("diagnol2"));
                            skidData.mic1 = reader.GetDecimal(reader.GetOrdinal("mic1"));
                            skidData.mic2 = reader.GetDecimal(reader.GetOrdinal("mic2"));
                            skidData.mic3 = reader.GetDecimal(reader.GetOrdinal("mic3"));
                            skidData.alloyID = reader.GetInt32(reader.GetOrdinal("alloyID"));
                            skidData.skidTypeID = reader.GetInt32(reader.GetOrdinal("skidTypeID"));
                            skidData.skidPrice = reader.GetDecimal(reader.GetOrdinal("skidPrice"));
                            skidData.status = reader.GetInt32(reader.GetOrdinal("skidStatus"));
                            skidData.customerID = reader.GetInt32(reader.GetOrdinal("customerID"));
                            skidData.sequenceNumber = reader.GetInt32(reader.GetOrdinal("sequenceNum"));
                            skidData.finishID = reader.GetInt32(reader.GetOrdinal("FinishID"));
                            skidData.branchID = reader.GetInt32(reader.GetOrdinal("branchID"));
                            skidData.orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                            skidData.orderedPieceCount = reader.GetInt32(reader.GetOrdinal("orderedPieceCount"));
                            skidData.pvcID = reader.GetInt32(reader.GetOrdinal("pvcID"));
                            skidData.paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            skidData.comments = reader.GetString(reader.GetOrdinal("comments"));
                            skidData.notPrime = reader.GetInt32(reader.GetOrdinal("notPrime"));
                            skidData.pieceCount = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                            customerName = reader.GetString(reader.GetOrdinal("longCustomerName"));

                        }

                    }

                    reader.Close();

                    skidData.skidPrice = Convert.ToDecimal(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidPrice.Index].Value);


                    skidData.pieceCount = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPieces.Index].Value);
                    skidData.finishID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmFinishID.Index].Value);
                    skidData.pvcID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVCGroupID.Index].Value);
                    skidData.paper = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPaper.Index].Value);
                    skidData.comments = Convert.ToString(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmComments.Index].Value).Trim();
                    skidData.branchID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmBranchID.Index].Value);
                    string orderletter = skidData.letter + "." + dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmOrderLetter.Index].Value.ToString().Trim();
                    skidData.orderID = orderID;
                    
                    if (Convert.ToBoolean(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmBreakSkid.Index].Value) == true)
                    {

                        


                        //Bobby Here
                        //PrintSkidLabel(i,orderletter, customerName, skidData, trans, db);




                        
                        db.UpdateSkidStatus(skidData.skidID, skidData.coilTagSuffix, skidData.letter, -4, trans);
                        string letter = skidData.letter;
                        skidData.letter = orderletter;
                        skidData.status = 1;

                        db.InsertSkidDataRecord(skidData, trans);

                        SkidsToPrint sp = new SkidsToPrint();
                        sp.skidID = skidData.skidID;
                        sp.coilTagSuffix = skidData.coilTagSuffix;
                        sp.letter = skidData.letter;
                        stp.Add(sp);
                        // i++  go to next record
                        skidData.letter = letter;

                        i++;
                        bool keepgoing = true;
                        if (i <= dataGridViewCOShShSame.Rows.Count - 1)
                        {


                            while (keepgoing)
                            {

                                if (skidData.skidID == Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidIDBase.Index].Value) &&
                                     dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmCoilTagSuffix.Index].Value.ToString().Trim().Equals(skidData.coilTagSuffix) &&
                                     dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmSkidLetter.Index].Value.ToString().Trim().Equals(skidData.letter))
                                {
                                    //if still same letter insert new record
                                    skidData.pieceCount = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPieces.Index].Value);
                                    skidData.finishID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmFinishID.Index].Value);
                                    skidData.pvcID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVCGroupID.Index].Value);
                                    skidData.pvcPrice = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPVCPriceList.Index].Value);
                                    skidData.paper = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmPaper.Index].Value);
                                    skidData.comments = Convert.ToString(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmComments.Index].Value).Trim();
                                    skidData.branchID = Convert.ToInt32(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmBranchID.Index].Value);

                                    string skLetter = skidData.letter;
                                    orderletter = skidData.letter + "." + dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmOrderLetter.Index].Value.ToString().Trim();



                                    skidData.letter = orderletter;



                                    db.InsertSkidDataRecord(skidData, trans);
                                    sp = new SkidsToPrint();
                                    sp.skidID = skidData.skidID;
                                    sp.coilTagSuffix = skidData.coilTagSuffix;
                                    sp.letter = skidData.letter;
                                    stp.Add(sp);
                                    //Bobby Here
                                    //PrintSkidLabel(i,orderletter, customerName, skidData, trans, db);
                                    skidData.letter = skLetter;

                                    i++;
                                    if (i >= dataGridViewCOShShSame.Rows.Count)
                                    {
                                        keepgoing = false;

                                    }
                                }
                                else
                                {
                                    //else i-- go back to previous and exit while loop
                                    i--;
                                    keepgoing = false;
                                }

                            }


                        }


                    }
                    else
                    {

                        //need to update status then insert instead of this
                        //8-17-23
                        //db.UpdateSkidInfo(skidData, orderletter, trans);

                        db.UpdateSkidStatus(skidData.skidID, skidData.coilTagSuffix, skidData.letter, -4, trans);
                        skidData.letter = orderletter;
                        skidData.status = 1;
                        db.InsertSkidDataRecord(skidData, trans);

                        //add to stp for later printing
                        SkidsToPrint sp = new SkidsToPrint();
                        sp.skidID = skidData.skidID;
                        sp.coilTagSuffix = skidData.coilTagSuffix;
                        sp.letter = skidData.letter;
                        stp.Add(sp);

                        //Bobby Here
                        //PrintSkidLabel(i, orderletter, customerName, skidData, trans, db);
                    }

                    



                }   

                db.UpdateOrderHdr(orderID, -1, trans);


                trans.Commit();
               

                //print all of the labels
                pl.PrintSkids(stp);

              

                dataGridViewCOShShSame.Rows.Clear();
                for (int i = 0; i < listViewCOOpenOrders.CheckedItems.Count; i++)
                {
                    listViewCOOpenOrders.CheckedItems[i].Remove();
                }
                lvwSSSmTimes.Items.Clear();

                panelCOShShSame.SendToBack();
                Cursor.Current = Cursors.WaitCursor;
                ReportGeneration rg = new ReportGeneration();

                rg.WorkOrder(orderID);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                if (trans.Connection != null)
                {
                    trans.Rollback();
                    
                    MessageBox.Show(ex.Message);
                }
               
            }

            
            

        }

        private void PrintCoildLabel(int i, int coilTagID, string coilTagSuffix , SqlTransaction trans, DBUtils db)
        {
            PrintLabels pl = new PrintLabels();


            using (DbDataReader reader = db.GetCoilInfo(coilTagID, coilTagSuffix, 0, trans))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pl.CoilLabelInfo.TagID = coilTagID.ToString().Trim() + coilTagSuffix;
                        pl.CoilLabelInfo.PO = reader.GetString(reader.GetOrdinal("dtlPO")).Trim();
                        pl.CoilLabelInfo.Alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim() + " " + reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        pl.CoilLabelInfo.Thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        pl.CoilLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
                        pl.CoilLabelInfo.MillNum = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                        pl.CoilLabelInfo.Carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));
                        pl.CoilLabelInfo.CoilCount = reader.GetInt32(reader.GetOrdinal("coilCount"));
                        pl.CoilLabelInfo.COO = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                        pl.CoilLabelInfo.CustName = reader.GetString(reader.GetOrdinal("longCustomerName")).Trim();
                        pl.CoilLabelInfo.Heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                        pl.CoilLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
                        pl.CoilLabelInfo.Location = reader.GetString(reader.GetOrdinal("location")).Trim();
                        if (!reader.IsDBNull(reader.GetOrdinal("receiveDate")))
                        {
                            pl.CoilLabelInfo.RecDate = reader.GetDateTime(reader.GetOrdinal("receiveDate")).ToString("d");
                        }
                        else
                        {
                            pl.CoilLabelInfo.RecDate = DateTime.Now.ToString("d") ;
                        }
                        
                        pl.CoilLabelInfo.RecID = reader.GetInt32(reader.GetOrdinal("receiveID"));
                        pl.CoilLabelInfo.SkidSteelDesc = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                        pl.CoilLabelInfo.Type = reader.GetInt32(reader.GetOrdinal("type"));
                        pl.CoilLabelInfo.Vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();
                        pl.CoilLabelInfo.Weight = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("weight")));

                       







                    }
                }
                reader.Close();
            }

            List<string> list = new List<string>();

            using (DbDataReader reader = db.GetCoilDamage(coilTagID, false,trans))
            {
                if (reader.HasRows)
                {
                    bool something = false;
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(reader.GetOrdinal("damageDescription")));
                        something = true;
                    }
                    if (something)
                    {
                        pl.CoilLabelInfo.Damage = list;
                    }
                }
            }

            if (LabelPrinters.zebraTagPrinter)
            {
                pl.CoilLabelZebra(LabelPrinters.tagPrinter);
            }
            else
            {
                pl.CoilLabel(LabelPrinters.tagPrinter);
            }
           
        }

        //private void PrintSkidLabel(int i, string orderletter, string customerName, SkidData skidData,SqlTransaction trans, DBUtils db)
        //{
        //    PrintLabels pl = new PrintLabels();


        //    using (DbDataReader reader = db.GetCoilInfo(skidData.skidID, skidData.coilTagSuffix, 0, trans))
        //    {
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                pl.SkidLabelInfo.COO = reader.GetString(reader.GetOrdinal("countryOfOrigin"));
        //                pl.SkidLabelInfo.Gauge = reader.GetDecimal(reader.GetOrdinal("thickness"));
        //                pl.SkidLabelInfo.Heat = reader.GetString(reader.GetOrdinal("heat"));
        //                pl.SkidLabelInfo.Mill = reader.GetString(reader.GetOrdinal("millCoilNum"));
        //                pl.SkidLabelInfo.Carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));
        //                pl.SkidLabelInfo.Vendor = reader.GetString(reader.GetOrdinal("vendor"));
        //                pl.SkidLabelInfo.SkidSteelDesc = reader.GetString(reader.GetOrdinal("SteelDesc"));


        //            }
        //        }
        //        reader.Close();
        //    }

        //    pl.SkidLabelInfo.SkidID = skidData.skidID;
        //    pl.SkidLabelInfo.CoilTagSuffix = skidData.coilTagSuffix;
        //    pl.SkidLabelInfo.SkidLetter = orderletter;
        //    pl.SkidLabelInfo.Location = skidData.location;
        //    pl.SkidLabelInfo.Alloy = dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmAlloy.Index].Value.ToString().Trim() + " " + dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmNewFinish.Index].Value.ToString().Trim();
        //    pl.SkidLabelInfo.CustName = customerName;
        //    pl.SkidLabelInfo.OrderID = skidData.orderID;
        //    decimal skidWeight = skidData.sheetWeight * skidData.pieceCount;
        //    if (skidWeight == 0)
        //    {
        //        skidWeight = Convert.ToDecimal(dataGridViewCOShShSame.Rows[i].Cells[dgvSSSmWeight.Index].Value);
        //    }

        //    pl.SkidLabelInfo.TheoWeight = Convert.ToInt32(skidWeight);
        //    pl.SkidLabelInfo.Length = skidData.length;
        //    pl.SkidLabelInfo.PO = textBoxSSSmPO.Text;
        //    pl.SkidLabelInfo.RecDate = DateTime.Now.ToShortDateString();
        //    pl.SkidLabelInfo.Comments = skidData.comments;




        //    pl.SkidLabelInfo.Pieces = skidData.pieceCount;

        //    pl.SkidLabelInfo.Type = skidData.skidTypeID;

        //    pl.SkidLabelInfo.Width = skidData.width;

        //    if (LabelPrinters.zebraTagPrinter)
        //    {
        //        pl.SkidLabelZebra(LabelPrinters.tagPrinter);
        //    }
        //    else
        //    {
        //        pl.SkidLabel(LabelPrinters.tagPrinter);
        //    }
        //}
        
        
        private void dataGridViewCOShShSame_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            return;
      
            
        }

        private void dataGridViewCOShShSame_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewCOShShSame.IsCurrentCellDirty)
            {
                dataGridViewCOShShSame.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btSSSmRecordTime_Click(object sender, EventArgs e)
        {

            ListViewItem lv = new ListViewItem();

            lv.SubItems[0].Text = dtSSSmStartDate.Text + " " + dtSSSmStartTime.Text;
            lv.SubItems.Add("");
            lv.SubItems[1].Text = dtSSSmEndDate.Text + " " + dtSSSmEndTime.Text;

            lvwSSSmTimes.Items.Add(lv);
        }
        private void dataGridViewTextBoxNumber_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void panelCOClClSame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewClClSameTimeRecords_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelClClEndtime_Click(object sender, EventArgs e)
        {

        }

        private void labelClClStartTime_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerClClSameEndTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerClClSameEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerClClSameStartTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerClClSameStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClClDiffCancel_Click(object sender, EventArgs e)
        {
            panelCOClClDiff.SendToBack();
            listViewCOOpenOrders.BringToFront();
            for (int i = listViewCOOpenOrders.CheckedItems.Count -1; i >= 0;i--)
            {
                listViewCOOpenOrders.CheckedItems[i].Checked = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using Extensions.DateTime;
using Microsoft.Win32;
using ICMS;
using System.Collections;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static DesktopApp2.FormICMSMain;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DesktopApp2
{


    public partial class FormICMSMain : Form
    {


        private int prevRunSheetTabPage;
        private bool justPrintedRunSheet = false;
        private int newRunSheetOrder;
        private bool RunSheetDropHappened = false;
        private int prevRunSheetOrder = -1;
        private int PVCRowID = 0;
        delegate void SetColumnIndex(int i);
        delegate void SetColumnIndexST(int i, int j);

        private bool bRenewCustList = false;
        private int sortColumn = -1;
        public TreeNode previousSelectedNode = null;
        public TreeNode previousCustSelectedNode = null;
        private static readonly Random getrandom = new Random();
        private bool balanceToActive = false;
        ListViewItem.ListViewSubItem SelectedLSI;
        public int intTagID = -1;
        public decimal decWidth = -1;
        public int intLength = -1;
        public bool wholeNumber = true;
        public bool allowText = false;
        public int intPVCRollStatus = -3;
        public string gLoc = "";

        
        private class SheetInfo
        {
            public decimal width = 0;
            public decimal length = 0;
            public string heat;
            public int pieceCount;
            public int origPcs;
            public string alloy;

        }

        public class PVCInfo
        {
            public int groupID;
            public string groupName;
            public decimal price;
        }
        private class OrdShearMat
        {
            public int orderID;
            public int sourceID;
            public int skidID;
            public string coilTagSuffix;
            public string letter;
            public int origPCS;
            public int cutPCS;

        }
        private class OrdShearDtl
        {
            public int orderID;
            public int sourceID;
            public int PCS;
            public decimal width;
            public decimal length;
            public int gauer;


        }

        public void NextLine()
        {
            int selRow = dgvSSDItems.SelectedRows[0].Index;
            if (selRow < dgvSSDItems.Rows.Count - 1)
            {
                dgvSSDItems.Rows[selRow + 1].Selected = true;
            }
        }

        public void PrevLine()
        {
            int selRow = dgvSSDItems.SelectedRows[0].Index;
            if (selRow != 0)
            {
                dgvSSDItems.Rows[selRow - 1].Selected = true;
            }
        }

        public System.Windows.Forms.TreeView GetTreeView()
        { return treeViewSSD; }

        public int GetSelectedRow()
        {
            if (dgvSSDItems.SelectedRows.Count > 0)
            {
                return dgvSSDItems.SelectedRows[0].Index;
            }
            return -1;

        }

        public ComboBox ShipComboBranch()
        {
            return comboBoxBranchChooser;
        }
        public decimal GetWidth()
        {
            return Convert.ToDecimal(dgvSSDItems.SelectedRows[0].Cells[dgvSSDWidth.Index].Value);
        }
        public decimal GetLength()
        {
            return Convert.ToDecimal(dgvSSDItems.SelectedRows[0].Cells[dgvSSDLength.Index].Value);
        }
        public string GetHeat()
        {
            return dgvSSDItems.SelectedRows[0].Cells[dgvSSDHeat.Index].Value.ToString();
        }
        public string GetAlloy()
        {
            return dgvSSDItems.SelectedRows[0].Cells[dgvSSDAlloy.Index].Value.ToString();
        }
        public int GetPieces()
        {
            return Convert.ToInt32(dgvSSDItems.SelectedRows[0].Cells[dgvSSDPieceCount.Index].Value);
        }

        public void LoadRemoteShipData()
        {
            DisplayCoilData(TreeViewCustomer.SelectedNode.Tag.ToString());
            DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());
            LoadShippingInfo();
        }
        private SheetInfo sheetDim = new SheetInfo();
        public System.Windows.Forms.ListView.CheckedListViewItemCollection GetShearSkids()
        { return listViewSSD.CheckedItems; }

        public System.Windows.Forms.ListView.CheckedListViewItemCollection GetShipCoilItems()
        { return listViewShipCoil.CheckedItems; }

        public System.Windows.Forms.ListView.CheckedListViewItemCollection GetShipSkidItems()
        { return listViewShipSkid.CheckedItems; }

        public System.Windows.Forms.ListView.ListViewItemCollection GetAllShipCoilItems()
        { return listViewShipCoil.Items; }

        public System.Windows.Forms.ListView.ListViewItemCollection GetAllShipSkidItems()
        { return listViewShipSkid.Items; }

        public void SyncShipColor()
        {
            foreach (ListViewItem lv in listViewShipCoil.Items)
            {
                ListViewCoilData.Items[lv.Index].ForeColor = lv.ForeColor;
            }
            foreach (ListViewItem lv in listViewShipSkid.Items)
            {
                listViewSkidData.Items[lv.Index].ForeColor = lv.ForeColor;
            }
        }

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public Boolean IsNumber(String s)
        {
            Boolean value = true;
            foreach (Char c in s.ToCharArray())
            {
                value = value && Char.IsDigit(c);
            }

            return value;
        }

        public class SkidPolishDtl
        {
            public int orderID;
            public int skidID;
            public string coilTagSuffix;
            public string skidLetter;
            public string orderLetter;
            public int orderPieceCount;
            public int alloyID;
            public int previousFinishID;
            public int newFinishID;
            public int PVC;
            public decimal PVCPrice;
            public int paper;
            public decimal paperPrice;
            public int lineMark;
            public decimal lineMarkPrice;
            public string comments;
            public int branchID;
            public int breakSkid;

        }
        public class SkidData
        {
            public int skidID;
            public string coilTagSuffix;
            public string letter;
            public string location;
            public int alloyID;
            public int finishID;
            public int customerID;
            public int branchID;
            public int orderID;
            public int sequenceNumber;
            public decimal sheetWeight;
            public decimal length;
            public decimal width;
            public decimal diagnol1;
            public decimal diagnol2;
            public decimal mic1;
            public decimal mic2;
            public decimal mic3;
            public int orderedPieceCount;
            public int pieceCount;
            public int pvcID;
            public int paper;
            public string comments;
            public int status;
            public int skidTypeID;
            public decimal skidPrice;
            public int notPrime;


        }
        public class MyListBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }


        static class Count
        {
            public static int counter = 0;
            public static int CoilCut = 0;
            public static decimal widthLeft = 0;

        }

        public List<SkidType> skidTypes;

        public List<PVCInfo> pvcData = new List<PVCInfo>();

        public List<PVCInfo> GetPVCList()
        {
            return pvcData;
        }

        public class SkidType
        {
            public int ID;
            public string Description;
            public int orderby;
            public string letter;

            public static implicit operator List<object>(SkidType v)
            {
                throw new NotImplementedException();
            }
        }

        public static class CTLInfo
        {
            private static decimal _thickness = 0;
            private static decimal _discrepency = 0;
            private static decimal _width = 0;
            private static string _alloy = "";

            public static decimal Thickness
            {
                get
                {
                    return _thickness;
                }
                set
                {
                    _thickness = value;
                }
            }

            public static decimal Width
            {
                get
                {
                    return _width;
                }
                set
                {
                    _width = value;
                }
            }


            public static string Alloy
            {
                get
                {
                    return _alloy;
                }
                set
                {
                    _alloy = value;
                }
            }

            public static decimal Discrepency
            {
                get
                {
                    return _discrepency;
                }
                set
                {
                    _discrepency = value;
                }
            }


        }


        public class ProcPricingInfo
        {
            public int TierLevel;
            public int SteelTypeID;
            public int MachineID;
            public decimal fromThickness;
            public decimal toThickness;
            public decimal fromWidth;
            public decimal toWidth;
            public int fromLength;
            public int toLength;
            public decimal price;


        }
        public class AlloyInfo
        {
            public int steelTypeID;
            public string finish;
            public int finishID;
            public string alloy;
            public int alloyID;
            public decimal density;
        }
        public class SkidPriceUpdate
        {
            public int tier;
            public int skidID;
            public decimal newFromWidth;
            public decimal newToWidth;
            public decimal newFromLength;
            public decimal newToLength;
            public decimal oldFromWidth;
            public decimal oldToWidth;
            public decimal oldFromLength;
            public decimal oldToLength;
            public decimal price;

        }
        public class ClClDiffHdrInfo
        {
            public int orderID;
            public int coilTagID;
            public string coilTagSuffix;
            public int origWeight;
            public int parentWeight;
            public int newWeight;
            public int FlagID1;
            public int FlagID2;
            public int cutbreak;
            public int cutcount;
            public int slitcount;
            public int widthLeftCol;
            public decimal width;
            public int paper;

        }
        public class WorkerInfo
        {
            public int WorkerID;
            public string FirstName;
            public string LastName;
            public int active;
        }
        public class CustInfo
        {
            public int CustomerID;
            public string ShortCustomerName;
            public string LongCustomerName;
            public string Address1;
            public string Address2;
            public string City;
            public string StateCode;
            public string Zip;
            public string Country;
            public string Phone;
            public string Fax;
            public string ContactName;
            public string Email;
            public string Packaging;
            public int MaxSkidWeight;
            public int PriceTier;
            public int WeightFormula;
            public int IsActive;
            public string QuickBookName;
            public int leadTime;

        }
        public class ClClSameHdrInfo
        {
            public int orderID;
            public int coilTagID;
            public string coilTagSuffix;
            public int previousFinishID;
            public int newFinishID;
            public int origWeight;
            public int PolishWeight;
            public int paper;

        }
        public class ClClSameDtlInfo
        {
            public int orderID;
            public int coilTagID;
            public string coilTagSuffix;
            public string newCoilTagSuffix;
            public int Weight;
            public int FinishID;
        }
        public class CTLDetail
        {
            public int orderID;
            public int CoilTagID;
            public string coilTagSuffix;
            public int sequenceNumber;
            public int skidCount;
            public int pieceCount;
            public decimal length;
            public decimal width;
            public int alloyID;
            public int finishID;
            public int skidTypeID;
            public string comments;
            public decimal sheetWeight;
            public int theoSkidWeight;
            public int paper;
            public int pvc;
            public decimal price;
            public int linemark;
            public decimal skidPrice;
            public int branchID;

        }
        public class OrderHdrInfo
        {
            public int masterOrderID;
            public int OrderID;
            public int CustomerID;
            public string CustomerPO;
            public DateTime OrderDate;
            public DateTime PromiseDate;
            public int Status;
            public string Comments;
            public int ScrapCredit;
            public int CalculationType;
            public string ShipComments;
            public int MachineID;
            public decimal ProcPrice;
            public int Posted;
            public decimal BreakIn;
            public int RunSheetOrder;
            public int MixHeats;
            public string runSheetComments;
            public decimal paperPrice;
        }
        public class RecDtlInfo
        {
            public int receiveID;
            public int coilTagID;
            public string skidLetter;
            public int type;
            public string purchaseOrder;
            public string millNum;
            public string heat;
            public int pieceCount;
            public int alloyID;
            public int finishID;
            public decimal thickness;
            public decimal width;
            public decimal length;
            public int weight;
        }
        public class RecHdrInfo
        {
            public int receiveID;
            public int custID;
            public string purchaseOrder;
            public string container;
            public DateTime receiveDate;
            public int status;
            public int workerID;
        }

        public class CoilInfo
        {
            public int coilTagID;
            public string coilTagSuffix;
            public int coilCount;
            public int customerID;
            public int receiveID;
            public string millCoilNum;
            public string vendor;
            public string location;
            public int alloyID;
            public int finishID;
            public decimal thickness;
            public decimal width;
            public decimal length;
            public int weight;
            public string heat;
            public string countryOfOrigin;
            public decimal carbon;
            public int coilStatus;
            public int type;
            public int typeNum;
        }
        static class RecGridInfo
        {
            public static int row = 0;
            public static int col = 0;
        }

        static class ClClSameGridInfo
        {
            public static int row = 0;
            public static int col = 0;
        }
        static class ClClDiffGridInfo
        {
            public static int row = 0;
            public static int col = 0;
            public static int colCnt = 0;
        }

        //TSAMaster.processFunction table
        public static class ProcessFunction
        {
            public const string ClClSame = "CoilCoilSame"; //coil polish (same width)
            public const string ClClDiff = "CoilCoilDiff"; //slitting (change Width)
            public const string ClSkSame = "CoilSkidSame"; //cut to length
            public const string ShShSame = "SheetSheetSame"; //sheet polish/buff
            public const string ShShDiff = "SheetSheetDiff"; //shear/gauer

        }



        static class SQLConn
        {
            public static SqlConnection conn = DBUtils.GetDBConnection();
        }
        static class SQLConn1
        {
            public static SqlConnection conn = DBUtils.GetDBConnection();
        }
        static class SQLConn2
        {
            public static SqlConnection conn = DBUtils.GetDBConnection();
        }
        //C#
        // Implements the manual sorting of items by columns.
        class ListViewItemComparer : IComparer
        {
            private readonly int col;
            private readonly System.Windows.Forms.SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = System.Windows.Forms.SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal;
#pragma warning disable IDE0018 // Inline variable declaration
                DateTime firstDate, secondDate;
#pragma warning restore IDE0018 // Inline variable declaration
                if (DateTime.TryParse(((ListViewItem)x).SubItems[col].Text, out firstDate) &&
                                DateTime.TryParse(((ListViewItem)y).SubItems[col].Text, out secondDate))
                {
                    returnVal = DateTime.Compare(firstDate, secondDate);
                }
                else
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == System.Windows.Forms.SortOrder.Descending)
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
                return returnVal;
            }
        }


        public FormICMSMain()
        {



            InitializeComponent();
            textBoxDefaultsCTLThickDiscrepency.KeyPress += new KeyPressEventHandler(ColumnDigit_KeyPress);

            GetDefaultPlant();
            GetTagPrinter();
            GetShippingPrinter();
            GetClClSameDefaultFinish();
            GetSSSmDefaultFinish();
            GetScrapUnit();
            GetHoldDown();
            GetReportDrive();
            GetCTLThicknessDiscrepency();
            tabControlICMS.BringToFront();
            tabControlICMS.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlOrderMachines.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlPlantLocations.DrawMode = TabDrawMode.OwnerDrawFixed;


            try
            {
                SQLConn.conn.Open();
                LoadPlantLocations();
                LoadCustomers(checkBoxInactiveCustomers.Checked);
                if (TreeViewCustomer.Nodes.Count > 0)
                {
                    DisplayCoilData(TreeViewCustomer.Nodes[0].Tag.ToString());
                    TreeViewCustomer.SelectedNode = TreeViewCustomer.Nodes[0];
                }
                
                //GetPVCData();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }

        private void GetPVCData()
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetPVCGroup())
            {
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        PVCInfo pv = new PVCInfo();

                        pv.groupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                        pv.groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                        pv.price = reader.GetDecimal(reader.GetOrdinal("Price"));

                        pvcData.Add(pv);

                    }
                }
            }
        }
        private void GetHoldDown()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string defHoldDown = (string)Registry.GetValue(keyName,
            "HoldDown",
            "Blank");
            if (defHoldDown == "Blank")
            {
                Registry.SetValue(keyName, "HoldDown", "3");
                MachineDefaults.HoldDown = 3;
            }
            else
            {
                MachineDefaults.HoldDown = Convert.ToInt32(defHoldDown) ;
            }


        }

        private void SetReportDrive(string reportDrive)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "ReportDrive", reportDrive);
            MachineDefaults.ReportDrive = reportDrive;



        }
        private void GetReportDrive()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string defReportDrive = (string)Registry.GetValue(keyName,
            "ReportDrive",
            "Blank");
            if (defReportDrive == "Blank")
            {
                Registry.SetValue(keyName, "ReportDrive", "C:\\");
                MachineDefaults.ReportDrive = "C:\\";
            }
            else
            {
                MachineDefaults.ReportDrive = defReportDrive;
            }


        }
        private void GetDefaultPlant()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string DefCity = (string)Registry.GetValue(keyName,
            "City",
            "Blank");
            if (DefCity == "Blank")
            {
                Registry.SetValue(keyName, "City", "Chicago");
                PlantLocation.city = "Chicago";
            }
            else
            {
                PlantLocation.city = DefCity;
            }


        }
        private void GetShippingPrinter()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\DB\\";
            const string keyName = userRoot + "\\" + subkey;

            string tagPrinter = (string)Registry.GetValue(keyName, "ShipLabelPrinter", "Blank");
            if (tagPrinter == "Blank")
            {
                Registry.SetValue(keyName, "ShipLabelPrinter", "");
                LabelPrinters.shippingPrinter = "";
            }
            else
            {
                LabelPrinters.shippingPrinter = tagPrinter;
            }


        }
        private void GetTagPrinter()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\DB\\";
            const string keyName = userRoot + "\\" + subkey;

            string tagPrinter = (string)Registry.GetValue(keyName, "LabelPrinter", "Blank");
            if (tagPrinter == "Blank")
            {
                Registry.SetValue(keyName, "LabelPrinter", "");
                LabelPrinters.tagPrinter = "";
            }
            else
            {
                LabelPrinters.tagPrinter = tagPrinter;
            }


        }
        private void GetCTLThicknessDiscrepency()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string CTLThicknessDisc = (string)Registry.GetValue(keyName, "CTLThicknessDiscrepency", "Blank");
            if (CTLThicknessDisc == "Blank")
            {
                Registry.SetValue(keyName, "CTLThicknessDiscrepency", ".01");
                CTLInfo.Discrepency = Convert.ToDecimal(.01);
            }
            else
            {
                CTLInfo.Discrepency = Convert.ToDecimal(CTLThicknessDisc);
            }


        }
        private void GetClClSameDefaultFinish()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string ClClSameDefaultFinish = (string)Registry.GetValue(keyName, "ClClSameDefaultFinish", "Blank");
            if (ClClSameDefaultFinish == "Blank")
            {
                Registry.SetValue(keyName, "ClClSameDefaultFinish", "");
                MachineDefaults.ClClSameDefaultFinish = "";
            }
            else
            {
                MachineDefaults.ClClSameDefaultFinish = ClClSameDefaultFinish;
            }


        }
        private void GetSSSmDefaultFinish()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string SSSmDefaultFinish = (string)Registry.GetValue(keyName, "SSSmDefaultFinish", "Blank");
            if (SSSmDefaultFinish == "Blank")
            {
                Registry.SetValue(keyName, "SSSmDefaultFinish", "");
                MachineDefaults.SSSmDefaultFinish = "";
            }
            else
            {
                MachineDefaults.SSSmDefaultFinish = SSSmDefaultFinish;
            }


        }
        private void GetScrapUnit()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;

            string scrapUnit = (string)Registry.GetValue(keyName, "ScrapUnit", "Blank");
            if (scrapUnit == "Blank")
            {
                Registry.SetValue(keyName, "ScrapUnit", "IN");
                MachineDefaults.scrapUnit = "IN";
            }
            else
            {
                MachineDefaults.scrapUnit = scrapUnit;
            }


        }
        private void SetHoldDown(int HoldDown)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "HoldDown", HoldDown.ToString());
            MachineDefaults.HoldDown = HoldDown;



        }
        private void SetDefaultPlant(string city)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "City", city);
            PlantLocation.city = city;



        }
        private void SetTagPrinter(string tagPrinter)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\DB\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "LabelPrinter", tagPrinter);
            LabelPrinters.tagPrinter = tagPrinter;



        }

        private void SetShippingPrinter(string shippingPrinter)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\DB\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "ShipLabelPrinter", shippingPrinter);
            LabelPrinters.shippingPrinter = shippingPrinter;



        }

        private void SetScrapUnit(string scrapUnit)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "ScrapUnit", scrapUnit);
            MachineDefaults.scrapUnit = scrapUnit;

        }

        private void SetClClSameDefaultFinish(string ClClSameDefaultFinish)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "ClClSameDefaultFinish", ClClSameDefaultFinish);
            MachineDefaults.ClClSameDefaultFinish = ClClSameDefaultFinish;



        }

        private void SetSSSmDefaultFinish(string SSSmDefaultFinish)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "SSSmDefaultFinish", SSSmDefaultFinish);
            MachineDefaults.SSSmDefaultFinish = SSSmDefaultFinish;



        }
        private void SetCTLThicknessDiscrepency(string CTLThickDefault)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\VB and VBA Program Settings\\ICMS\\";
            const string keyName = userRoot + "\\" + subkey;


            Registry.SetValue(keyName, "CTLThicknessDiscrepency", CTLThickDefault);
            CTLInfo.Discrepency = Convert.ToDecimal(CTLThickDefault);


        }

        
        public DbDataReader GetAlloyPriceHistory(int AlloyID)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("select * From " + PlantLocation.city + ".AlloyPriceHistory ");
            sb.Append("where AlloyID = " + AlloyID.ToString());
            sb.Append("order by dateUpdated desc");

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

        public DbDataReader GetAllSkidPricing(int tierLevel, bool ignoreTier = false, int skidID = -1)
        {

            
            StringBuilder sb = new StringBuilder();

            sb.Append("select * From " + PlantLocation.city +".skidPricing ");
            if (!ignoreTier)
            {
                sb.Append("where tierLevel =  " + tierLevel.ToString());
            }
            if (skidID != -1)
            {
                if (ignoreTier)
                {
                    sb.Append("where skidTypeID = " + skidID.ToString());
                }
                else
                {
                    sb.Append(" and skidTypeID = " + skidID.ToString());
                }
            }
            sb.Append(" order by tierLevel, skidTypeID, fromWidth, toWidth,fromLength,ToLength");

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

        public DbDataReader GetAllProcPricing(int tierLevel, bool ignoreTier = false, int SteelTypeID = -1, int MachineID = -1)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("select * From " + PlantLocation.city + ".ProcessPricing ");
            if (!ignoreTier)
            {
                sb.Append("where tierLevel =  " + tierLevel.ToString());
            }
            if (SteelTypeID != -1)
            {
                if (ignoreTier)
                {
                    sb.Append("where SteelTypeID = " + SteelTypeID.ToString());
                }
                else
                {
                    sb.Append(" and SteelTypeID = " + SteelTypeID.ToString());
                }
            }
            if (MachineID != -1)
            {
                if (ignoreTier && SteelTypeID==-1)
                {
                    sb.Append("where MachineID = " + MachineID.ToString());
                }
                else
                {
                    sb.Append(" and MachineID = " + MachineID.ToString());
                }
            }
            sb.Append(" order by tierLevel, SteelTypeID, MachineID, fromThickness, toThickness, fromWidth, toWidth,fromLength,ToLength");

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

        public decimal GetProcPricing(ProcPricingInfo procInfo)
        {

            decimal price = 0;
            StringBuilder sb = new StringBuilder();
            
            //I just used the 'from' variables for passing info in.
           
            sb.Append("select ProcessPricing.Price from " + PlantLocation.city + ".ProcessPricing ");
            sb.Append("where tierLevel =  (select max(tierlevel) from " + PlantLocation.city + ".ProcessPricing ");
            sb.Append("where tierlevel in (" + procInfo.TierLevel.ToString() + " ,0) ");
            sb.Append("and " + procInfo.SteelTypeID.ToString() + " = SteelTypeID ");
            sb.Append("and " + procInfo.MachineID.ToString() + " = MachineID ");
            sb.Append("and " + procInfo.fromThickness.ToString() + " >= fromThickness ");
            sb.Append("and " + procInfo.fromThickness.ToString() + " < toThickness ");
            sb.Append("and " + procInfo.fromWidth.ToString() + " >= fromwidth ");
            sb.Append("and " + procInfo.fromWidth.ToString() + " < ToWidth ");
            sb.Append("and " + procInfo.fromLength.ToString() + " >= FromLength ");
            sb.Append("and " + procInfo.fromLength.ToString() + " < ToLength) ");
            sb.Append("and " + procInfo.SteelTypeID.ToString() + " = SteelTypeID ");
            sb.Append("and " + procInfo.MachineID.ToString() + " = MachineID ");
            sb.Append("and " + procInfo.fromThickness.ToString() + " >= fromThickness ");
            sb.Append("and " + procInfo.fromThickness.ToString() + " < toThickness ");
            sb.Append("and " + procInfo.fromWidth.ToString() + " >= fromwidth ");
            sb.Append("and " + procInfo.fromWidth.ToString() + " < ToWidth ");
            sb.Append("and " + procInfo.fromLength.ToString() + " >= FromLength ");
            sb.Append("and " + procInfo.fromLength.ToString() + " < ToLength ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };



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
        
        public void GetSkidTypes(int rowcntr)
        {


            DBUtils db = new DBUtils();

            db.OpenSQLConn();



            using (DbDataReader reader = db.GetSkidTypeData())
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

                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvCTLSkidType"]).Items.Add(sk.Description);
                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvSkidTypeID"]).Items.Add(sk.ID);
                        sp.Append(sk.letter + " = " + sk.Description + Environment.NewLine);
                        //skidTypes.Add(sk);??????
                        cntr++;
                    }

                    dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvCTLSkidType"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvCTLSkidType"]).Items[0].ToString();
                    dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvSkidTypeID"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvSkidTypeID"]).Items[0];
                    dataGridViewCTLOrderEntry.Rows[rowcntr].Cells["dgvCTLSkidType"].ToolTipText = sp.ToString();
                }
                reader.Close();

            }
            db.CloseSQLConn();

        }
        
        public void GetAdders(int rowcntr)
        {
            dataGridViewAdders.Rows.Clear();
            StringBuilder sb = new StringBuilder();
            
            sb.Append("select* From " + PlantLocation.city + ".AdderDesc ");


            String sql = sb.ToString();
           
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            



            //default to .5 inch in case no records match
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                int cntr = 0;
                if (reader.HasRows)
                {



                    while (reader.Read())
                    {

                        string adderDesc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
                        int adderID = reader.GetInt32(reader.GetOrdinal("adderID"));

                        
                        if (adderID > 0)
                        {
                            dataGridViewAdders.Rows.Add();

                            dataGridViewAdders.Rows[cntr].Cells["dgvAdderDesc"].Value = adderDesc;
                            dataGridViewAdders.Rows[cntr].Cells["dgvAdderDesc"].Tag = adderID;
                            dataGridViewAdders.Rows[cntr].Cells["dgvAdderPrice"].Value = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
                            cntr++;
                        }
                        else
                        {
                            if (adderDesc.Equals("Paper"))
                            {
                                textBoxPaperPrice.Text = reader.GetDecimal(reader.GetOrdinal("adderPrice")).ToString().Trim();
                            }
                        }


                        
                    }



                }

            }
           
        }

        private decimal GetSlitTrim(decimal materialThickness)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select* From " + PlantLocation.city + ".slitterTrimTable ");
            sb.Append("where fromTrim < " + materialThickness.ToString());
            sb.Append(" and toTrim >= " + materialThickness.ToString());

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            //default to .5 inch in case no records match
            decimal returnVal = Convert.ToDecimal(0.5);
            using (DbDataReader reader = cmd.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnVal = reader.GetDecimal(reader.GetOrdinal("TrimAmount"));

                    }


                }

            }


            return returnVal;
        }
        private void DeleteSkidPricing(SkidPriceUpdate skud)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".skidPricing ");

            sb.Append("where TierLevel = " + skud.tier.ToString());
            sb.Append(" and skidTypeID = " + skud.skidID.ToString());
            sb.Append(" and fromWidth = " + skud.newFromWidth.ToString());
            sb.Append(" and toWidth = " + skud.newToWidth.ToString());
            sb.Append(" and fromLength = " + skud.newFromLength.ToString());
            sb.Append(" and toLength = " + skud.newToLength.ToString());



            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }

        private void DeleteProcPricing(ProcPricingInfo procInfo)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".ProcessPricing ");

            sb.Append("where TierLevel = " + procInfo.TierLevel.ToString());
            sb.Append(" and SteelTypeID = " + procInfo.SteelTypeID.ToString());
            sb.Append(" and MachineId = " + procInfo.MachineID.ToString());
            sb.Append(" and fromThickness = " + procInfo.fromThickness.ToString());
            sb.Append(" and toThickness = " + procInfo.toThickness.ToString());
            sb.Append(" and fromWidth = " + procInfo.fromWidth.ToString());
            sb.Append(" and toWidth = " + procInfo.toWidth.ToString());
            sb.Append(" and fromLength = " + procInfo.fromLength.ToString());
            sb.Append(" and toLength = " + procInfo.toLength.ToString());
            sb.Append(" and price = " + procInfo.price.ToString());



            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }
        private void DeletePVCItem(int itemnum)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".PVCDescription ");

            sb.Append("where PVCTypeID = " + itemnum.ToString());


            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }

        private void DeletePVCVendor(int VendorID)
        {
            


            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".PVCVendor ");

            sb.Append("where VendorID = " + VendorID.ToString());
            

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }

        private int UpdateCustomer(CustInfo CI)
        {
            int custCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Customer ");
            sb.Append("SET ShortCustomerName = @ShortCustomerName, ");
            sb.Append("LongCustomerName = @LongCustomerName, ");
            sb.Append("Address1 = @Address1, ");
            sb.Append("Address2 = @Address2, ");
            sb.Append("City = @City, ");
            sb.Append("StateCode = @StateCode, ");
            sb.Append("Zip = @Zip, ");
            sb.Append("Country = @Country, ");
            sb.Append("Phone = @Phone, ");
            sb.Append("Fax = @Fax, ");
            sb.Append("ContactName = @ContactName, ");
            sb.Append("Email = @Email, ");
            sb.Append("Packaging = @Packaging, ");
            sb.Append("MaxSkidWeight = @MaxSkidWeight, ");
            sb.Append("PriceTier = @PriceTier, ");
            sb.Append("WeightFormula = @WeightFormula, ");
            sb.Append("isActive = @isActive, ");
            sb.Append("QuickBookName = @QuickBookName, ");
            sb.Append("leadtime = @leadtime ");
            sb.Append("WHERE CustomerID = @CustomerID");




            
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@CustomerID", CI.CustomerID);
            cmd.Parameters.AddWithValue("@ShortCustomerName", CI.ShortCustomerName);
            cmd.Parameters.AddWithValue("@LongCustomerName", CI.LongCustomerName);
            cmd.Parameters.AddWithValue("@Address1", CI.Address1);
            cmd.Parameters.AddWithValue("@Address2", CI.Address2);
            cmd.Parameters.AddWithValue("@City", CI.City);
            cmd.Parameters.AddWithValue("@StateCode", CI.StateCode);
            cmd.Parameters.AddWithValue("@Zip", CI.Zip);
            cmd.Parameters.AddWithValue("@Country", CI.Country);
            cmd.Parameters.AddWithValue("@Phone", CI.Phone);
            cmd.Parameters.AddWithValue("@Fax", CI.Fax);
            cmd.Parameters.AddWithValue("@ContactName", CI.ContactName);
            cmd.Parameters.AddWithValue("@Email", CI.Email);
            cmd.Parameters.AddWithValue("@Packaging", CI.Packaging);
            cmd.Parameters.AddWithValue("@MaxSkidWeight", CI.MaxSkidWeight);
            cmd.Parameters.AddWithValue("@PriceTier", CI.PriceTier);
            cmd.Parameters.AddWithValue("@WeightFormula", CI.WeightFormula);
            cmd.Parameters.AddWithValue("@isActive", CI.IsActive);
            cmd.Parameters.AddWithValue("@QuickBookName", CI.QuickBookName);
            cmd.Parameters.AddWithValue("@leadTime", CI.leadTime);

            //returns record count affected
            custCnt = (int)cmd.ExecuteNonQuery();



            return custCnt;
        }
        private int UpdateAlloyInfo(int AlloyID,string AlloyDesc,decimal Density,int orderBy,decimal price = -1,bool priceOnly = false)
        {
            int updateCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Alloy ");
            if (priceOnly)
            {
                sb.Append("SET price = @Price ");
            }
            else
            {
                sb.Append("SET AlloyDesc = @AlloyDesc, ");

                sb.Append("DensityFactor = @Density, ");
                sb.Append("OrderList = @orderBy ");
            }
            
            

            sb.Append("WHERE AlloyID = @AlloyID");





            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (priceOnly)
            {
                cmd.Parameters.AddWithValue("@Price", price);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AlloyDesc", AlloyDesc.Trim());
                cmd.Parameters.AddWithValue("@Density", Density);
                cmd.Parameters.AddWithValue("@orderBy", orderBy);
                
            }

            cmd.Parameters.AddWithValue("@AlloyID", AlloyID);

            //returns record count affected
            updateCnt = (int)cmd.ExecuteNonQuery();



            return updateCnt;
        }
        

        private int UpdateBranchInfo(int BranchID, string shortName, string longName)
        {
            int BranchCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".CustomerBranch ");
            sb.Append("SET BranchDescShort = @shortName, BranchDescLong = @longName ");

            sb.Append("WHERE BranchID = @BranchID");





            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@shortName", shortName);
            cmd.Parameters.AddWithValue("@longName", longName);
            cmd.Parameters.AddWithValue("@BranchID", BranchID);


            //returns record count affected
            BranchCnt = (int)cmd.ExecuteNonQuery();



            return BranchCnt;
        }

        private int UpdateFinishDesc(int FinishID, string FinishDesc)
        {
            int SteelCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".AlloyFinish ");
            sb.Append("SET FinishDesc = @FinishDesc ");

            sb.Append("WHERE FinishID = @FinishID");





            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@FinishDesc", FinishDesc);
            cmd.Parameters.AddWithValue("@FinishID", FinishID);


            //returns record count affected
            SteelCnt = (int)cmd.ExecuteNonQuery();



            return SteelCnt;
        }
        private int UpdateWorker(WorkerInfo WI)
        {
            int custCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Workers ");
            sb.Append("SET firstName = @firstName, ");
            sb.Append("lastName = @lastName, ");
            sb.Append("active = @active ");
           
            sb.Append("WHERE WorkerID = @WorkerID");





            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@firstName", WI.FirstName);
            cmd.Parameters.AddWithValue("@lastName", WI.LastName);
            cmd.Parameters.AddWithValue("@active", WI.active);
            cmd.Parameters.AddWithValue("@WorkerID", WI.WorkerID );
            

            //returns record count affected
            custCnt = (int)cmd.ExecuteNonQuery();



            return custCnt;
        }
        private int UpdatePVCRollStatus(int RollTagID, decimal statusID, string referenceNumber)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".PVCRollDtls ");
            sb.Append(" set ");
            sb.Append("status = @statusID,ReferenceNumber = @refNum ");
            sb.Append("where PVCTagID = @RollTagID");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@statusID", statusID);
            cmd.Parameters.AddWithValue("@refNum", referenceNumber );

            cmd.Parameters.AddWithValue("@RollTagID", RollTagID);

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }


        private int UpdatePVCRollInfo(int RollTagID,decimal decWidth, int intLength, string strLoc)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".PVCRollDtls ");
            sb.Append(" set ");
            sb.Append("PVCWidth = @decWidth, currentLength = @intLength, Location = @Location ");
            sb.Append("where PVCTagID = @RollTagID");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@decWidth", decWidth);

            cmd.Parameters.AddWithValue("@intLength", intLength);
            cmd.Parameters.AddWithValue("@RollTagID", RollTagID);
            cmd.Parameters.AddWithValue("@Location", strLoc);

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }
        private int UpdatePVCVendor(int rowNum)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            
            sb.Append("update " + PlantLocation.city + ".PVCVendor ");
            sb.Append(" set ");
            sb.Append("VendorName = @VendorName, VendorPhoneNumber = @VendorPhoneNumber ");
            sb.Append("where VendorID = @VendorID");
           
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            
            cmd.Parameters.AddWithValue("@VendorName", dataGridViewPVCVendor.Rows[rowNum].Cells["dgvPVCVendorName"].Value.ToString());
            
            cmd.Parameters.AddWithValue("@VendorPhoneNumber", dataGridViewPVCVendor.Rows[rowNum].Cells["dgvPVCVendorPhone"].Value.ToString());
            cmd.Parameters.AddWithValue("@VendorID", dataGridViewPVCVendor.Rows[rowNum].Cells["dgvPVCVendorName"].Tag.ToString());

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        private int InsertOrderShearDtl(OrdShearDtl osd, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".orderShearDtl ");
            sb.Append("(orderID,sourceID,Pieces,width,length,gauer) ");
            sb.Append("output INSERTED.OrderID VALUES(@orderID,@sourceID,@Pieces,@width,@length,@gauer)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            //orderID,sourceID,Pieces,width,length,gauer
            cmd.Parameters.AddWithValue("@orderID", osd.orderID);
            cmd.Parameters.AddWithValue("@sourceID", osd.sourceID);

            cmd.Parameters.AddWithValue("@Pieces", osd.PCS);
            cmd.Parameters.AddWithValue("@width", osd.width);

            cmd.Parameters.AddWithValue("@length", osd.length);
            cmd.Parameters.AddWithValue("@gauer", osd.gauer);
            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;
        }


        private int InsertOrderShearMaterial(OrdShearMat osm, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".orderShearMaterial ");
            sb.Append("(orderID,sourceID,skidID,coilTagSuffix,letter,originalPCS,cutPCS) ");
            sb.Append("output INSERTED.OrderID VALUES(@orderID,@sourceID,@skidID,@coilTagSuffix,@letter,@originalPCS,@cutPCS)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            //orderID,sourceID,skidID,coilTagSuffix,letter,originalPCS,cutPCS
            cmd.Parameters.AddWithValue("@orderID", osm.orderID);
            cmd.Parameters.AddWithValue("@sourceID", osm.sourceID);

            cmd.Parameters.AddWithValue("@skidID", osm.skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", osm.coilTagSuffix);

            cmd.Parameters.AddWithValue("@letter", osm.letter);
            cmd.Parameters.AddWithValue("@originalPCS", osm.origPCS);
            cmd.Parameters.AddWithValue("@cutPCS", osm.cutPCS);
            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;
        }


        private int InsertAlloyPriceHistory(int AlloyID,  decimal price)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".AlloyPriceHistory ");
            sb.Append("(AlloyID,Price,dateUpdated) ");
            sb.Append("output INSERTED.AlloyID VALUES(@AlloyID,@Price, @dateUpdated)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@AlloyID", AlloyID);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@dateUpdated", DateTime.Now);
            

            int alloyID = (int)cmd.ExecuteScalar();



            return alloyID;
        }
        private int InsertProcessPricing(ProcPricingInfo procInfo)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".ProcessPricing ");
            
            sb.Append("output INSERTED.TierLevel VALUES(@TierLevel,@SteelTypeID, @MachineID, ");
            sb.Append("@fromThickness,@toThickness,@fromWidth,@toWidth,@fromLength,@toLength,@price )");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@TierLevel", procInfo.TierLevel);
            cmd.Parameters.AddWithValue("@SteelTypeID", procInfo.SteelTypeID);
            cmd.Parameters.AddWithValue("@MachineID", procInfo.MachineID);
            cmd.Parameters.AddWithValue("@fromThickness", procInfo.fromThickness);
            cmd.Parameters.AddWithValue("@toThickness", procInfo.toThickness);
            cmd.Parameters.AddWithValue("@fromWidth", procInfo.fromWidth);
            cmd.Parameters.AddWithValue("@toWidth", procInfo.toWidth);
            cmd.Parameters.AddWithValue("@fromLength", procInfo.fromLength);
            cmd.Parameters.AddWithValue("@toLength", procInfo.toLength);
            cmd.Parameters.AddWithValue("@price", procInfo.price);

            int tierLevel = (int)cmd.ExecuteScalar();



            return tierLevel;
        }
        
        private int InsertAlloy(int SteelTypeID, string AlloyDesc, decimal density, int orderBy,decimal price)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".Alloy ");
            sb.Append("(SteelTypeID,AlloyDesc, DensityFactor,OrderList,Price) ");
            sb.Append("output INSERTED.AlloyID VALUES(@SteelTypeID,@AlloyDesc, @DensityFactor,@OrderList,@price)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@SteelTypeID", SteelTypeID);
            cmd.Parameters.AddWithValue("@AlloyDesc", AlloyDesc);
            cmd.Parameters.AddWithValue("@DensityFactor", density);
            cmd.Parameters.AddWithValue("@OrderList", orderBy);
            cmd.Parameters.AddWithValue("@price", price);

            int alloyID = (int)cmd.ExecuteScalar();



            return alloyID;
        }
        

        private int InsertFinish(int SteelTypeID, String FinishDesc)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".AlloyFinish ");
            sb.Append("(SteelTypeID, FinishDesc) ");
            sb.Append("output INSERTED.FinishID VALUES(@SteelTypeID,@FinishDesc)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@SteelTypeID", SteelTypeID);
            cmd.Parameters.AddWithValue("@FinishDesc", FinishDesc);


            int SteelID = (int)cmd.ExecuteScalar();



            return SteelID;
        }
        private int InsertWorker(WorkerInfo WI)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".workers ");
            sb.Append("(firstName,lastName,active) ");
            sb.Append("output INSERTED.WorkerID VALUES(@firstName,@lastName, @active)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@firstName", WI.FirstName);
            cmd.Parameters.AddWithValue("@lastName", WI.LastName);
            cmd.Parameters.AddWithValue("@active", WI.active);



            int WorkerID = (int)cmd.ExecuteScalar();



            return WorkerID;
        }
        private int InsertPVCCustRollDtl(int TagID, int GroupID, string strDesc, string strLocation)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCCustRollDtl ");
            sb.Append("(PVCTagID,PVCGroupID,PVCDesc) ");
            sb.Append("output INSERTED.PVCTagID VALUES(@PVCTagID,@PVCGroupID, @PVCDesc)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@PVCTagID", TagID);
            cmd.Parameters.AddWithValue("@PVCGroupID", GroupID);
            cmd.Parameters.AddWithValue("@PVCDesc", strDesc);
           

            int PVCtagID = (int)cmd.ExecuteScalar();



            return PVCtagID;
        }

        private int InsertPVCRollDtl(int RecID, int typeID,int CustID, decimal dWidth , int iLength, decimal dPrice, string strLocation)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCRollDtls ");
            sb.Append("(PVCRecID,PVCTypeID,CustID,PVCWidth,PVCLength,currentLength,Price,location,Status) ");
            sb.Append("output INSERTED.PVCTagID VALUES(@PVCRecID,@PVCTypeID,@CustID,@PVCWidth,@PVCLength,@CurrentLength,@Price,@location,1)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@PVCRecID", RecID);
            cmd.Parameters.AddWithValue("@PVCTypeID", typeID);
            cmd.Parameters.AddWithValue("@CUstID", CustID);
            cmd.Parameters.AddWithValue("@PVCWidth", dWidth);
            cmd.Parameters.AddWithValue("@PVCLength", iLength);
            cmd.Parameters.AddWithValue("@CurrentLength", iLength);
            cmd.Parameters.AddWithValue("@Price", dPrice);
            cmd.Parameters.AddWithValue("@location", strLocation);



            int PVCtagID = (int)cmd.ExecuteScalar();



            return PVCtagID;
        }


        private int InsertPVCOrderInfo(int PVCRollID, int orderID, int seqNum, int linFootage)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCOrderInfo ");
            sb.Append("(PVCTagID,OrderID,skidSeqNum,LinearFootage) ");
            sb.Append("output INSERTED.PVCTagID VALUES(@PVCTagID,@OrderID,@skidSeqNum,@LinearFootage)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@PVCTagID", PVCRollID);
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            cmd.Parameters.AddWithValue("@skidSeqNum", seqNum);
            cmd.Parameters.AddWithValue("@LinearFootage", linFootage);
            


            int PVCtagID = (int)cmd.ExecuteScalar();



            return PVCtagID;
        }
        private int InsertPVCRecHdr(int VendorID, string refNum, string PONum, DateTime dt)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCRecHdr ");
            sb.Append("(VendorID,RefNumber,PONumber,Date) ");
            sb.Append("output INSERTED.PVCRecID VALUES(@VendorID,@refNumber,@PONumber,@Date)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@VendorID", VendorID);
            cmd.Parameters.AddWithValue("@refNumber", refNum);
            cmd.Parameters.AddWithValue("@PONumber", PONum);
            cmd.Parameters.AddWithValue("@Date", dt );
            



            int PVCRecID = (int)cmd.ExecuteScalar();



            return PVCRecID;
        }

        private int AddPVCVendorItem(int VendorID,int GroupID,string itemNumber,string itemDesc,int width,int length, int tack)
        {

           StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCDescription ");
            sb.Append("(VendorID,GroupID,ItemNumber,ItemDesc,DefaultWidth,DefaultLength, tack) ");
            sb.Append("output INSERTED.PVCTypeID VALUES(@VendorID,@GroupID,@ItemNumber,@ItemDesc,@DefaultWidth,@DefaultLength, @tack)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@VendorID", VendorID);
            cmd.Parameters.AddWithValue("@GroupID", GroupID);
            cmd.Parameters.AddWithValue("@ItemNumber", itemNumber);
            cmd.Parameters.AddWithValue("@ItemDesc", itemDesc);
            cmd.Parameters.AddWithValue("@DefaultWidth", width);
            cmd.Parameters.AddWithValue("@DefaultLength", length);
            cmd.Parameters.AddWithValue("@tack", tack);



            int PVCTypeID = (int)cmd.ExecuteScalar();



            return PVCTypeID;
        }

        private int InsertPVCVendor(int rowNum)
        {





            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCVendor ");
            sb.Append("(VendorName,VendorPhoneNumber) ");
            sb.Append("output INSERTED.VendorID VALUES(@VendorName, @VendorPhoneNumber)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@VendorName", dataGridViewPVCVendor.Rows[rowNum].Cells["dgvPVCVendorName"].Value.ToString());
            cmd.Parameters.AddWithValue("@VendorPhoneNumber", dataGridViewPVCVendor.Rows[rowNum].Cells["dgvPVCVendorPhone"].Value.ToString());


            int VendorID = (int)cmd.ExecuteScalar();



            return VendorID;
        }




        private int AddCoilSlitORderWidths(ClClDiffHdrInfo slitOrderInfo, SqlTransaction tran)
        {





            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilSlitOrderWidths ");
            sb.Append("(orderID,coilTagID,coilTagSuffix,cutbreak,cutNumber,widthLeftCol,width) ");
            sb.Append("output INSERTED.orderID VALUES(@orderID, @coilTagID,@coilTagSuffix,@cutbreak,@slitcount,@widthLeftCol,@width)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@orderID", slitOrderInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", slitOrderInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", slitOrderInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@cutbreak", slitOrderInfo.cutbreak);
            cmd.Parameters.AddWithValue("@slitcount", slitOrderInfo.slitcount);
            cmd.Parameters.AddWithValue("@widthLeftCol", slitOrderInfo.widthLeftCol);
            cmd.Parameters.AddWithValue("@width", slitOrderInfo.width);
            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;
        }
        private int AddCoilSlitORderBreaks(ClClDiffHdrInfo slitOrderInfo, SqlTransaction tran)
        {





            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilSlitOrderBreaks ");
            sb.Append("(orderID,coilTagID,coilTagSuffix,cutbreak,paper,slitcount,FlagID1,FlagID2,parentWeight,weight) ");
            sb.Append("output INSERTED.orderID VALUES(@orderID, @coilTagID,@coilTagSuffix,@cutbreak,@paper,@slitcount,@FlagID1,@FlagID2,@parentWeight,@weight)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@orderID", slitOrderInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", slitOrderInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", slitOrderInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@cutbreak", slitOrderInfo.cutbreak);
            cmd.Parameters.AddWithValue("@paper", slitOrderInfo.paper);
            cmd.Parameters.AddWithValue("@slitcount", slitOrderInfo.cutcount);
            cmd.Parameters.AddWithValue("@FlagID1", slitOrderInfo.FlagID1);
            cmd.Parameters.AddWithValue("@FlagID2", slitOrderInfo.FlagID2);
            cmd.Parameters.AddWithValue("@parentWeight", slitOrderInfo.parentWeight);
            cmd.Parameters.AddWithValue("@weight", slitOrderInfo.newWeight);
            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;
        }
        private int AddCoilSlitORderHdr(ClClDiffHdrInfo slitOrderInfo, SqlTransaction tran)
        {





            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilSlitOrderHdr ");
            sb.Append("(orderID,coilTagID,coilTagSuffix,origWeight) ");
            sb.Append("output INSERTED.orderID VALUES(@orderID, @coilTagID,@coilTagSuffix,@origWeight)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@orderID", slitOrderInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", slitOrderInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", slitOrderInfo.coilTagSuffix);


            cmd.Parameters.AddWithValue("@origWeight", slitOrderInfo.origWeight);
            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;
        }
        private int AddMasterOrder(int orderHdrID, int sequence, SqlTransaction tran, int masterID = -1)
        {





            StringBuilder sb = new StringBuilder();

            if (masterID == -1)
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".MasterOrder ");
                sb.Append("(orderID,sequence) ");
                sb.Append("output INSERTED.masterOrderID VALUES(@orderHdrID, @sequence)");

            }
            else
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".MasterOrder ");
                sb.Append("(masterOrderID,orderID,sequence) ");
                sb.Append("output INSERTED.masterOrderID VALUES(@masterID,@orderHdrID, @sequence)");
            }

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@masterID", masterID);
            cmd.Parameters.AddWithValue("@orderHdrID", orderHdrID);
            cmd.Parameters.AddWithValue("@sequence", sequence);
            cmd.Transaction = tran;

            masterID = (int)cmd.ExecuteScalar();



            return masterID;
        }
        private int AddSlitterTrim(int machineID)
        {





            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".SlitterTrimTable ");
            sb.Append("(machineID,fromTrim,toTrim,TrimAmount) ");
            sb.Append("output INSERTED.machineID VALUES(@machineID,@fromTrim,@toTrim,@TrimValue)");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.Parameters.AddWithValue("@machineID", machineID);
            cmd.Parameters.AddWithValue("@fromTrim", Convert.ToDecimal(textBoxClClDiffTrimFrom.Text));
            cmd.Parameters.AddWithValue("@toTrim", Convert.ToDecimal(textBoxClClDiffTrimTo.Text));
            cmd.Parameters.AddWithValue("@TrimValue", Convert.ToDecimal(textBoxClClDiffTrimValue.Text));



            machineID = (int)cmd.ExecuteScalar();



            return machineID;
        }
        private int UpdateOrderHdr(OrderHdrInfo ordHdrInfo, SqlTransaction tran, bool onlyStatusUpdate = false)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            if (!onlyStatusUpdate)
            {
                sb.Append("update " + PlantLocation.city + ".OrderHdr ");
                sb.Append(" set ");
                sb.Append("CustomerPO = @CustomerPO, OrderDate = @OrderDate,PromiseDate = @PromiseDate,");
                sb.Append("Comments = @Comments, ScrapCredit = @ScrapCredit,ProcPrice = @ProcPrice, ");
                sb.Append("runSheetComments = @runsheet, paperPrice = @paperPrice ");
                sb.Append("where orderID = @ORderID");
            }
            else
            {
                sb.Append("update " + PlantLocation.city + ".OrderHdr ");
                sb.Append(" set ");
                sb.Append("status = @status ");
                sb.Append("where orderID = @ORderID");
            }
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (!onlyStatusUpdate)
            {
                cmd.Parameters.AddWithValue("@CustomerPO", ordHdrInfo.CustomerPO);
                cmd.Parameters.AddWithValue("@OrderDate", ordHdrInfo.OrderDate);
                cmd.Parameters.AddWithValue("@PromiseDate", ordHdrInfo.PromiseDate);
                cmd.Parameters.AddWithValue("@Comments", ordHdrInfo.Comments);
                cmd.Parameters.AddWithValue("@ScrapCredit", ordHdrInfo.ScrapCredit);
                cmd.Parameters.AddWithValue("@ProcPrice", ordHdrInfo.ProcPrice);
                cmd.Parameters.AddWithValue("@runsheet", ordHdrInfo.runSheetComments);
                cmd.Parameters.AddWithValue("@paperPrice", ordHdrInfo.paperPrice);
            }
            else
            {
                cmd.Parameters.AddWithValue("@status", ordHdrInfo.Status);
            }
            cmd.Parameters.AddWithValue("@OrderID", ordHdrInfo.OrderID);
            cmd.Transaction = tran;
            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        private int AddCTLDetail(CTLDetail ctlDet, SqlTransaction tran)
        {
         
            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CTLDetail ");
            sb.Append("(orderID,coilTagID,coilTagSuffix,sequenceNumber,skidCount,pieceCount,");
            sb.Append("length,width,alloyID,finishID,skidTypeID,comments,sheetWeight,");
            sb.Append("theoSkidWeight,paper,PVCGroupID,PVCPrice,lineMark,skidPrice,branchID )");

            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@orderID,@coilTagID,@coilTagSuffix,@sequenceNumber,@skidCount,@pieceCount,");
            sb.Append("@length,@width,@alloyID,@finishID,@skidTypeID,@comments,@sheetWeight,");
            sb.Append("@theoSkidWeight,@paper,@PVCGroupID,@PVCPrice,@lineMark,@skidPrice,@BranchID )");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@orderID", ctlDet.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", ctlDet.CoilTagID );
            cmd.Parameters.AddWithValue("@coilTagSuffix", ctlDet.coilTagSuffix );
            cmd.Parameters.AddWithValue("@sequenceNumber", ctlDet.sequenceNumber);
            cmd.Parameters.AddWithValue("@skidCount", ctlDet.skidCount);
            cmd.Parameters.AddWithValue("@pieceCount", ctlDet.pieceCount);
            cmd.Parameters.AddWithValue("@length", ctlDet.length);
            cmd.Parameters.AddWithValue("@width", ctlDet.width );
            cmd.Parameters.AddWithValue("@alloyID", ctlDet.alloyID);
            cmd.Parameters.AddWithValue("@finishID", ctlDet.finishID);
            cmd.Parameters.AddWithValue("@skidTypeID", ctlDet.skidTypeID);
            cmd.Parameters.AddWithValue("@comments", ctlDet.comments );
            cmd.Parameters.AddWithValue("@sheetWeight", ctlDet.sheetWeight);
            cmd.Parameters.AddWithValue("@theoSkidWeight", ctlDet.theoSkidWeight);
            cmd.Parameters.AddWithValue("@paper", ctlDet.paper);
            cmd.Parameters.AddWithValue("@PVCGroupID", ctlDet.pvc);
            cmd.Parameters.AddWithValue("@PVCPrice", ctlDet.price);
            cmd.Parameters.AddWithValue("@lineMark", ctlDet.linemark);
            cmd.Parameters.AddWithValue("@skidPrice", ctlDet.skidPrice);
            cmd.Parameters.AddWithValue("@BranchID", ctlDet.branchID);

            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();

            return orderID;
            
        }
        private int AddCTLAdders(CTLDetail ctlDet, int adderID, decimal adderPrice, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CTLAdderPricing ");
            sb.Append("(orderID,coilTagID,coilTagSuffix,sequenceNumber,adderID, adderPrice )");
            

            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@orderID,@coilTagID,@coilTagSuffix,@sequenceNumber,@adderID,@adderPrice)");
            


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@orderID", ctlDet.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", ctlDet.CoilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", ctlDet.coilTagSuffix);
            cmd.Parameters.AddWithValue("@sequenceNumber", ctlDet.sequenceNumber);
            cmd.Parameters.AddWithValue("@adderID", adderID);
            cmd.Parameters.AddWithValue("@adderPrice", adderPrice);
            

            cmd.Transaction = tran;

            int orderID = (int)cmd.ExecuteScalar();

            return orderID;

        }

        private int UpdateOrderHdrAll(OrderHdrInfo ordHdrInfo, SqlTransaction tran)
        {
            int OrdHdrID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".OrderHdr ");
            sb.Append("set CustomerID (@CustomerID, CustomerPO = @CustomerPO ,OrderDate = @OrderDate ,PromiseDate = @PromiseDate, ");
            sb.Append("Status = @Status,Comments = @Comments, ScrapCredit = @ScrapCredit,CalculationType = @CalculationType, ");
            sb.Append("ShipComments = @ShipComments,MachineID = @MachineID,ProcPrice = @ProcPrice,Posted = @Posted, ");
            sb.Append("BreakIn = @BreakIn,RunSheetOrder = @RunSheetOrder,MixHeats = @MixHeats ");
            sb.Append("output INSERTED.orderID ");
            sb.Append("where orderID = @orderID ");
            
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@CustomerID", ordHdrInfo.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerPO", ordHdrInfo.CustomerPO);
            cmd.Parameters.AddWithValue("@OrderDate", ordHdrInfo.OrderDate);
            cmd.Parameters.AddWithValue("@PromiseDate", ordHdrInfo.PromiseDate);
            cmd.Parameters.AddWithValue("@Status", ordHdrInfo.Status);
            cmd.Parameters.AddWithValue("@Comments", ordHdrInfo.Comments);
            cmd.Parameters.AddWithValue("@ScrapCredit", ordHdrInfo.ScrapCredit);
            cmd.Parameters.AddWithValue("@CalculationType", ordHdrInfo.CalculationType);
            cmd.Parameters.AddWithValue("@ShipComments", ordHdrInfo.ShipComments);
            cmd.Parameters.AddWithValue("@MachineID", ordHdrInfo.MachineID);
            cmd.Parameters.AddWithValue("@ProcPrice", ordHdrInfo.ProcPrice);
            cmd.Parameters.AddWithValue("@Posted", ordHdrInfo.Posted);
            cmd.Parameters.AddWithValue("@BreakIn", ordHdrInfo.BreakIn);
            cmd.Parameters.AddWithValue("@RunSheetOrder", ordHdrInfo.RunSheetOrder);
            cmd.Parameters.AddWithValue("@MixHeats", ordHdrInfo.MixHeats);
            cmd.Parameters.AddWithValue("@orderID", ordHdrInfo.OrderID);

            cmd.Transaction = tran;

            OrdHdrID = (int)cmd.ExecuteScalar();



            return OrdHdrID;
        }

        private int AddOrderHdr(OrderHdrInfo ordHdrInfo, SqlTransaction tran)
        {
            int OrdHdrID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".OrderHdr ");
            sb.Append("(CustomerID,CustomerPO,OrderDate,PromiseDate,Status,Comments, ");
            sb.Append("ScrapCredit,CalculationType,ShipComments,MachineID,ProcPrice,Posted, ");
            sb.Append("BreakIn,RunSheetOrder,MixHeats,runSheetComments, paperPrice) ");
            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@CustomerID,@CustomerPO,@OrderDate,@PromiseDate,@Status,@Comments, ");
            sb.Append("@ScrapCredit,@CalculationType,@ShipComments,@MachineID,@ProcPrice,@Posted, ");
            sb.Append("@BreakIn,@RunSheetOrder,@MixHeats,@runSheet, @paperPrice)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (ordHdrInfo.runSheetComments == null)
            {
                ordHdrInfo.runSheetComments = "";
            }
            cmd.Parameters.AddWithValue("@CustomerID", ordHdrInfo.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerPO", ordHdrInfo.CustomerPO);
            cmd.Parameters.AddWithValue("@OrderDate", ordHdrInfo.OrderDate);
            cmd.Parameters.AddWithValue("@PromiseDate", ordHdrInfo.PromiseDate);
            cmd.Parameters.AddWithValue("@Status", ordHdrInfo.Status);
            cmd.Parameters.AddWithValue("@Comments", ordHdrInfo.Comments);
            cmd.Parameters.AddWithValue("@ScrapCredit", ordHdrInfo.ScrapCredit);
            cmd.Parameters.AddWithValue("@CalculationType", ordHdrInfo.CalculationType);
            cmd.Parameters.AddWithValue("@ShipComments", ordHdrInfo.ShipComments);
            cmd.Parameters.AddWithValue("@MachineID", ordHdrInfo.MachineID);
            cmd.Parameters.AddWithValue("@ProcPrice", ordHdrInfo.ProcPrice);
            cmd.Parameters.AddWithValue("@Posted", ordHdrInfo.Posted);
            cmd.Parameters.AddWithValue("@BreakIn", ordHdrInfo.BreakIn);
            cmd.Parameters.AddWithValue("@RunSheetOrder", ordHdrInfo.RunSheetOrder);
            cmd.Parameters.AddWithValue("@MixHeats", ordHdrInfo.MixHeats);
            cmd.Parameters.AddWithValue("@runSheet", ordHdrInfo.runSheetComments);
            cmd.Parameters.AddWithValue("@paperPrice", ordHdrInfo.paperPrice);
            cmd.Transaction = tran;

            OrdHdrID = (int)cmd.ExecuteScalar();



            return OrdHdrID;
        }

        private int AddDamage(int coilTagID, int damageID, SqlTransaction tran)
        {
            int damID = -1;


            
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilDamage ");
            sb.Append("(coilTagID,damageDescID) ");
            sb.Append("output INSERTED.coilTagID VALUES(@coilTagID, @damageDescID)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@damageDescID", damageID);
            cmd.Transaction = tran;

            damID = (int)cmd.ExecuteScalar();



            return damID;
        }

        private void DeleteCTLAdders(int OrderID, SqlTransaction tran)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CTLAdderPricing ");

            sb.Append("where orderID = " + OrderID.ToString());



            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Transaction = tran;

            cmd.ExecuteNonQuery();




        }

        private void DeleteCTLDetail(int OrderID, SqlTransaction tran)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CTLDetail ");

            sb.Append("where orderID = " + OrderID.ToString());
            


            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Transaction = tran;

            cmd.ExecuteNonQuery();




        }

        private void DeleteSlitTrim(int machineID, decimal fromTrim, decimal toTrim)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".SlitterTrimTable ");

            sb.Append("where machineID = " + machineID.ToString());
            sb.Append(" and fromTrim = " + fromTrim.ToString());
            sb.Append(" and toTrim = " + toTrim.ToString());


            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }
        private void DeleteMachineConnection(int fromMachineConnID)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".MachineConnections ");

            sb.Append("where machineConnectionID = " + fromMachineConnID);

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.ExecuteNonQuery();




        }
        private int AddMachineConnection(int fromMachineID, int toMachineID)
        {
            int conID = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".MachineConnections ");
            sb.Append("(fromMachine, toMachine) ");
            sb.Append("output INSERTED.MachineConnectionID VALUES(@fromID, @toID)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@fromID", fromMachineID);
            cmd.Parameters.AddWithValue("@toID", toMachineID);


            conID = (int)cmd.ExecuteScalar();



            return conID;
        }
        private int AddReceivingDtl(RecDtlInfo rdInfo, SqlTransaction tran)
        {

            int dtlRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".receiveDtl ");
            sb.Append("(receiveID,coilTagID,skidLetter,type,purchaseOrder, millNum,heat,pieceCount,alloyID,finishID,thickness,width,length,weight) ");
            sb.Append(" output INSERTED.receiveID VALUES(@receiveID,@coilTagID,@skidLetter,@type,@purchaseOrder, @millNum,@heat,@pieceCount,@alloyID,@finishID,@thickness,@width,@length,@weight)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };



            cmd.Parameters.AddWithValue("@receiveID", rdInfo.receiveID);
            cmd.Parameters.AddWithValue("@coilTagID", rdInfo.coilTagID);
            cmd.Parameters.AddWithValue("@skidLetter", rdInfo.skidLetter);
            cmd.Parameters.AddWithValue("@type", rdInfo.type);
            cmd.Parameters.AddWithValue("@purchaseOrder", rdInfo.purchaseOrder);
            cmd.Parameters.AddWithValue("@millNum", rdInfo.millNum);
            cmd.Parameters.AddWithValue("@heat", rdInfo.heat);
            cmd.Parameters.AddWithValue("@pieceCount", rdInfo.pieceCount);
            cmd.Parameters.AddWithValue("@alloyID", rdInfo.alloyID);
            cmd.Parameters.AddWithValue("@finishID", rdInfo.finishID);
            cmd.Parameters.AddWithValue("@thickness", rdInfo.thickness);
            cmd.Parameters.AddWithValue("@width", rdInfo.width);
            cmd.Parameters.AddWithValue("@length", rdInfo.length);
            cmd.Parameters.AddWithValue("@weight", rdInfo.weight);

            dtlRecID = (int)cmd.ExecuteScalar();



            return dtlRecID;
        }

        private int DeleteSlitOrderInfo(int OrderID, SqlTransaction tran)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CoilSlitOrderHdr ");
            sb.Append("where orderID = @OrderID");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            orderCnt = (int)cmd.ExecuteNonQuery();




            sb.Clear();
            sb.Append("Delete from " + PlantLocation.city + ".CoilSlitOrderBreaks ");
            sb.Append("where orderID = @OrderID");
            sql = sb.ToString();

            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            orderCnt = (int)cmd.ExecuteNonQuery();


            sb.Clear();
            sb.Append("Delete from " + PlantLocation.city + ".CoilSlitOrderWidths ");
            sb.Append("where orderID = @OrderID");
            sql = sb.ToString();

            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            orderCnt = (int)cmd.ExecuteNonQuery();

            return orderCnt;
        }
        private int DeleteCoilPolishHdr(int OrderID, SqlTransaction tran)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CoilPolishHdr ");
            sb.Append("where orderID = @OrderID");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        private int AddCoilPolishHdr(ClClSameHdrInfo cpInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilPolishHdr ");
            sb.Append("(OrderID,coilTagID,coilTagSuffix,previousFinish,newFinish, origWeight,polishWeight,paper) ");
            sb.Append("output INSERTED.OrderID VALUES(@OrderID,@coilTagID,@coilTagSuffix,@previousFinish,@newFinish, @origWeight,@polishWeight,@paper)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", cpInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", cpInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", cpInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@previousFinish", cpInfo.previousFinishID);
            cmd.Parameters.AddWithValue("@newFinish", cpInfo.newFinishID);
            cmd.Parameters.AddWithValue("@origWeight", cpInfo.origWeight);
            cmd.Parameters.AddWithValue("@polishWeight", cpInfo.PolishWeight);
            cmd.Parameters.AddWithValue("@paper", cpInfo.paper);


            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }


        private int DeleteCoilPolishDtl(int orderID, SqlTransaction tran)
        {
            int orderCnt = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("delete from " + PlantLocation.city + ".CoilPolishDtl ");
            sb.Append("where orderID = @OrderID");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }
        private int AddCoilPolishDtl(ClClSameDtlInfo cpInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilPolishDtl ");
            sb.Append("(OrderID,coilTagID,coilTagSuffix,coilTagNewSuffix,polishWeight, DTLfinishID) ");
            sb.Append("output INSERTED.OrderID VALUES(@OrderID,@coilTagID,@coilTagSuffix,@coilTagNewSuffix,@polishWeight, @finishID)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", cpInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", cpInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", cpInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@coilTagNewSuffix", cpInfo.newCoilTagSuffix);

            cmd.Parameters.AddWithValue("@polishWeight", cpInfo.Weight);
            cmd.Parameters.AddWithValue("@finishID", cpInfo.FinishID);


            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }







        private int AddReceivingHdr(RecHdrInfo rhInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".receiveHdr ");
            sb.Append("(custID,purchaseOrder,container,receiveDate,status, workerID) ");
            sb.Append("output INSERTED.receiveID VALUES(@custID, @purchaseOrder,@container, @receiveDate, @status, @workerID)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@custID", rhInfo.custID);
            cmd.Parameters.AddWithValue("@purchaseOrder", rhInfo.purchaseOrder);
            cmd.Parameters.AddWithValue("@container", rhInfo.container);
            cmd.Parameters.AddWithValue("@receiveDate", rhInfo.receiveDate);
            cmd.Parameters.AddWithValue("@status", rhInfo.status);
            cmd.Parameters.AddWithValue("@workerID", rhInfo.workerID);


            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }

        public int InsertSkidDataRecord(SkidData sd, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".SkidData ");
            sb.Append("(skidID,coilTagSuffix, letter,location,alloyID,finishID,customerID,branchID,");
            sb.Append("orderID,sequenceNum,sheetWeight,length,width,diagnol1,diagnol2,mic1,mic2,mic3,");
            sb.Append("orderedPieceCount,pieceCount,pvcID,paper,comments,skidStatus,skidTypeID,");
            sb.Append("skidPrice,notPrime) ");
            sb.Append("output INSERTED.skidID ");
            sb.Append("VALUES(@skidID,@coilTagSuffix,@letter,@location,@alloyID,@finishID,@customerID,@branchID,");
            sb.Append("@orderID,@sequenceNum,@sheetWeight,@length,@width,@diagnol1,@diagnol2,@mic1,@mic2,@mic3,");
            sb.Append("@orderedPieceCount,@pieceCount,@pvcID,@paper,@comments,@status,@skidTypeID,");
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
            cmd.Parameters.AddWithValue("@length", sd.length);
            cmd.Parameters.AddWithValue("@width", sd.width);
            cmd.Parameters.AddWithValue("@diagnol1", sd.diagnol1);



            cmd.Parameters.AddWithValue("@diagnol2", sd.diagnol2);
            cmd.Parameters.AddWithValue("@mic1", sd.mic1);
            cmd.Parameters.AddWithValue("@mic2", sd.mic2);
            cmd.Parameters.AddWithValue("@mic3", sd.mic3);
            cmd.Parameters.AddWithValue("@orderedPieceCount", sd.orderedPieceCount);
            cmd.Parameters.AddWithValue("@pieceCount", sd.pieceCount);

            cmd.Parameters.AddWithValue("@pvcID", sd.pvcID);
            cmd.Parameters.AddWithValue("@paper", sd.paper);
            cmd.Parameters.AddWithValue("@comments", sd.comments);
            cmd.Parameters.AddWithValue("@status", sd.status);
            cmd.Parameters.AddWithValue("@skidTypeID", sd.skidTypeID);
            cmd.Parameters.AddWithValue("@skidPrice", sd.skidPrice);
            cmd.Parameters.AddWithValue("@notPrime", sd.notPrime);

            int skidID = (int)cmd.ExecuteScalar();

            return skidID;

        }

        private int AddCoil(CoilInfo cinfo, SqlTransaction tran)
        {


            Count.counter++;

            

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".Coil ");
            sb.Append("(coilTagSuffix,coilCount,customerID,receiveID,millCoilNum, ");
            sb.Append("vendor,location,alloyID,finishID,thickness,width,length, ");
            sb.Append("weight,heat,countryOfOrigin,carbon,coilStatus,type,typeNum) ");
            sb.Append("output INSERTED.coilTagID VALUES(@coilTagSuffix, @coilCount,@customerID, @receiveID, @millCoilNum, @vendor, ");
            sb.Append("@location, @alloyID,@finishID,@thickness, @width, @length,@weight, @heat, ");
            sb.Append("@countryOfOrigin,@carbon, @coilStatus, @type, @typeNum)");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@coilTagSuffix", cinfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@coilCount", cinfo.coilCount);
            cmd.Parameters.AddWithValue("@customerID", cinfo.customerID);
            cmd.Parameters.AddWithValue("@receiveID", cinfo.receiveID);
            cmd.Parameters.AddWithValue("@millCoilNum", cinfo.millCoilNum);
            cmd.Parameters.AddWithValue("@vendor", cinfo.vendor);
            cmd.Parameters.AddWithValue("@location", cinfo.location);
            cmd.Parameters.AddWithValue("@alloyID", cinfo.alloyID);
            cmd.Parameters.AddWithValue("@finishID", cinfo.finishID);
            cmd.Parameters.AddWithValue("@thickness", cinfo.thickness);
            cmd.Parameters.AddWithValue("@width", cinfo.width);
            cmd.Parameters.AddWithValue("@length", cinfo.length);
            cmd.Parameters.AddWithValue("@weight", cinfo.weight);
            cmd.Parameters.AddWithValue("@heat", cinfo.heat);
            cmd.Parameters.AddWithValue("@countryOfOrigin", cinfo.countryOfOrigin);
            cmd.Parameters.AddWithValue("@carbon", cinfo.carbon);
            cmd.Parameters.AddWithValue("@coilStatus", cinfo.coilStatus);
            cmd.Parameters.AddWithValue("@type", cinfo.type);
            cmd.Parameters.AddWithValue("@typeNum", cinfo.typeNum);




            int tagID = (int)cmd.ExecuteScalar();


            return tagID;

        }
        
        private DbDataReader GetClClDiffModify(int orderID)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT oHdr.*,oh.*,ob.*,ow.*,cl.thickness, cl.width as coilwidth,al.AlloyDesc, ");
            sb.Append("af.FinishDesc,st.TrimAmount,cl.weight as origWeight ");

            sb.Append("from " + PlantLocation.city + ".CoilSlitOrderHdr oh ,");
            sb.Append(PlantLocation.city + ".CoilSlitOrderBreaks ob, ");
            sb.Append(PlantLocation.city + ".CoilSlitOrderWidths ow, ");

            sb.Append(PlantLocation.city + ".Coil cl, ");
            sb.Append(PlantLocation.city + ".Alloy al, ");
            sb.Append(PlantLocation.city + ".AlloyFinish af, ");
            sb.Append(PlantLocation.city + ".SlitterTrimTable st, ");
            sb.Append(PlantLocation.city + ".orderHdr oHdr ");

            sb.Append("where oh.OrderID = ob.OrderID ");
            sb.Append("and oh.orderID = " + orderID + " ");
            sb.Append("and oHdr.orderID = " + orderID + " ");
            sb.Append("and oh.OrderID = ow.OrderID ");
            sb.Append("and oh.coilTagID = ob.coilTagID ");
            sb.Append("and oh.coilTagID = ow.coilTagID ");
            sb.Append("and oh.coilTagSuffix = ob.coilTagSuffix ");
            sb.Append("and oh.coilTagSuffix = ow.coilTagSuffix ");
            sb.Append("and ob.cutbreak = ow.cutbreak ");
            sb.Append("and oh.coilTagID = cl.coilTagID ");
            sb.Append("and oh.coilTagSuffix = cl.coilTagSuffix ");
            sb.Append("and cl.alloyID = al.AlloyID ");
            sb.Append("and cl.finishID = af.finishID ");
            sb.Append("and cl.thickness > st.fromTrim ");
            sb.Append("and cl.thickness <= st.toTrim ");
            sb.Append("order by oh.orderid,oh.coilTagID,oh.coilTagSuffix,ob.cutbreak,ow.cutNumber");

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

        private int DeletePVCGroup(int groupID)
        {
            

            StringBuilder sb = new StringBuilder();
            sb.Append("update  " + PlantLocation.city + ".PVCGroup ");
            sb.Append("set active = -1 ");
            sb.Append("where groupID = " + groupID.ToString());

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            

            groupID = cmd.ExecuteNonQuery();



            return groupID;
        }

        private int AddPVCGroupName(string groupName, decimal price)
        {
            int groupID = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCGRoup ");
            sb.Append("(GroupName,active,Price) ");
            sb.Append("output INSERTED.GroupID VALUES(@groupName,1, @price)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@groupName", groupName);
            cmd.Parameters.AddWithValue("@price", price);

            groupID = (int)cmd.ExecuteScalar();



            return groupID;
        }

        private int InsertSkidPricing(SkidPriceUpdate skup)
        {
            int tierLevel = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".skidPricing ");
            sb.Append("(TierLevel,skidTypeID,fromWidth,toWidth,fromLength,toLength,price) ");
            sb.Append("output INSERTED.TierLevel VALUES(@TierLevel,@skidTypeID,@fromWidth,@toWidth,@fromLength,@toLength,@price)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@TierLevel", skup.tier);
            cmd.Parameters.AddWithValue("@skidTypeID", skup.skidID);
            cmd.Parameters.AddWithValue("@fromWidth", skup.newFromWidth );
            cmd.Parameters.AddWithValue("@toWidth", skup.newToWidth);
            cmd.Parameters.AddWithValue("@fromLength", skup.newFromLength);
            cmd.Parameters.AddWithValue("@toLength", skup.newToLength);
            cmd.Parameters.AddWithValue("@price", skup.price);







            tierLevel = (int)cmd.ExecuteScalar();



            return tierLevel;
        }
        private DbDataReader LoadPVCInventoryDetailed()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select 'tsa' as custname,PVCRollDtls.*,GroupName, Tack, ItemDesc ");
            sb.Append("from " + PlantLocation.city + ".PVCRollDtls, " + PlantLocation.city + ".PVCDescription , " + PlantLocation.city + ".PVCGroup ");
            sb.Append("where custID = 0 ");

            sb.Append("and PVCRollDtls.PVCTypeID = PVCDescription.PVCTypeID ");
            sb.Append("and PVCDescription.GroupID = PVCGroup.GroupID ");
            sb.Append("and status > 0 ");
            sb.Append("union ");
            sb.Append("select longCustomerName, PVCRollDtls.*, GroupName, -1 , PVCDesc ");
            sb.Append("from " + PlantLocation.city + ".Customer, " + PlantLocation.city + ".PVCRollDtls, " + PlantLocation.city + ".PVCCustRollDtl, " + PlantLocation.city + ".PVCGroup  ");

            sb.Append("where customer.CustomerID = PVCRollDtls.CustID ");
            sb.Append("and PVCCustRollDtl.PVCTagID = PVCRollDtls.PVCTagID ");
            sb.Append("and PVCCustRollDtl.PVCGroupID = PVCGroup.GroupID ");
            sb.Append("and custID != 0 ");
            sb.Append("and status > 0 ");



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
        private int GetPVCRollCustCount(int custID)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            sb.Append("select count(*) as gCount from " + PlantLocation.city + ".PVCCustRollDtl, " + PlantLocation.city + ".PVCRollDtls ");
            
            sb.Append("where PVCCustRollDtl.PVCTagID = PVCRollDtls.PVCTagID ");
            sb.Append("and PVCRollDtls.Status > 0 ");
            sb.Append("and PVCRollDtls.CustID = " + custID.ToString());

        
            String sql = sb.ToString();
            try
            {
                SQLConn1.conn.Open();
                SqlCommand cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn1.conn,
                    CommandText = sql

                };


                
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(reader.GetOrdinal("gCount"));
                        }




                    }

                }


                SQLConn1.conn.Close();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
           
            return count;
        }
        private int GetPVCRollCount(int groupID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select count(*) as gCount from " + PlantLocation.city + ".PVCGroup, " + PlantLocation.city + ".PVCRollDtls ," + PlantLocation.city + ".PVCDescription ");
            sb.Append("where PVCGroup.GroupID = PVCDescription.GroupID ");
            sb.Append("and PVCRollDtls.PVCTypeID = PVCDescription.PVCTypeID ");
            sb.Append("and PVCRollDtls.Status > 0 ");
            sb.Append("and PVCGroup.GroupID = " + groupID.ToString());

            String sql = sb.ToString();
            SQLConn1.conn.Open();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn1.conn,
                CommandText = sql
                
            };


            int count = 0;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(reader.GetOrdinal("gCount"));
                    }
                    
                    
                    
                    
                }
                
            }


            SQLConn1.conn.Close();
            return count;
        }

        public DbDataReader GetCTLDetails(int orderID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".CTLDetail cd, " + PlantLocation.city + ".Coil cl, ");
            sb.Append(PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af ");
            
            sb.Append(" where OrderID = " + orderID.ToString());
            sb.Append(" and cd.CoilTagID = cl.coilTagID ");
            sb.Append(" and cd.coilTagSuffix = cl.coilTagSuffix ");
            sb.Append(" and cd.AlloyID = al.AlloyID ");
            sb.Append(" and cd.FinishID = af.FinishID");
            
            sb.Append(" order by cd.coilTagID, cd.coilTagSuffix, cd.sequenceNumber");

            

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

        private DbDataReader LoadPVCVendorItems(int vndID, string itemNum = "")
        {

            StringBuilder sb = new StringBuilder();
            if (itemNum.Equals(""))
            {
                sb.Append("SELECT * ");

                sb.Append("from " + PlantLocation.city + ".PVCDescription pd, " + PlantLocation.city + ".PVCGroup pg ");

                sb.Append(" where VendorID = " + vndID.ToString());
                sb.Append(" and pd.groupID = pg.groupID");

            }
            else
            {
                sb.Append("SELECT * ");

                sb.Append("from " + PlantLocation.city + ".PVCDescription pd" );

                sb.Append(" where VendorID = " + vndID.ToString());
                sb.Append(" and itemNumber = @itemNumber ");

            }

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (!itemNum.Equals(""))
            {
                cmd.Parameters.AddWithValue("@itemNumber", itemNum);

            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        //Sheet polishing
        private DbDataReader GetSSSOrderNumbers(int SkidID, string CoilTagSuffix, string letter)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + PlantLocation.city + " .OrderHdr as oh ");


            sb.Append("where orderID in  ");
            sb.Append("(select orderID from " + PlantLocation.city + ".OrderPolishDtl as opd ");
            sb.Append("where opd.skidID = @SkidID ");
            sb.Append("and opd.coilTagSuffix = @CoilTagSuffix  ");
            sb.Append("and opd.skidletter = @letter ) ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("order by oh.OrderID ");


            String sql = sb.ToString();

            if (SQLConn2.conn.State == ConnectionState.Open)
            {
                SQLConn2.conn.Close();
                SQLConn2.conn.Open();
            }
            else
            {
                if (SQLConn2.conn.State == ConnectionState.Closed)
                {
                    SQLConn2.conn.Open();
                }
            }
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn2.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@SkidID", SkidID);
            cmd.Parameters.AddWithValue("@CoilTagSuffix", CoilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", letter);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        //Shearing
        private DbDataReader GetSSDOrderNumbers(int SkidID, string CoilTagSuffix,string letter)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + PlantLocation.city + " .OrderHdr as oh ");


            sb.Append("where orderID in  ");
            sb.Append("(select orderID from " + PlantLocation.city + ".OrderShearMaterial as osm ");
            sb.Append("where oh.orderID = osm.orderID  ");
            sb.Append("and osm.skidID = @SkidID ");
            sb.Append("and osm.coilTagSuffix = @CoilTagSuffix  ");
            sb.Append("and osm.letter = @letter ) ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("order by oh.OrderID ");


            String sql = sb.ToString();

            if (SQLConn2.conn.State == ConnectionState.Open)
            {
                SQLConn2.conn.Close();
                SQLConn2.conn.Open();
            }
            else
            {
                if (SQLConn2.conn.State == ConnectionState.Closed)
                {
                    SQLConn2.conn.Open();
                }
            }
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn2.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@SkidID", SkidID);
            cmd.Parameters.AddWithValue("@CoilTagSuffix", CoilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", letter);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        private DbDataReader GetCTLOrderNumbers(int CoilTagID, string CoilTagSuffix)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + PlantLocation.city + " .OrderHdr as oh ");
  

            sb.Append("where orderID in  ");
            sb.Append("(select orderID from " + PlantLocation.city + ".CTLDetail as cd  ");
            sb.Append("where oh.orderID = cd.orderID  ");
            sb.Append("and cd.coilTagID = @CoilTagID ");
            sb.Append("and cd.coilTagSuffix = @CoilTagSuffix ) ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("order by oh.OrderID ");


            String sql = sb.ToString();
            if (SQLConn2.conn.State == ConnectionState.Closed)
            {
                SQLConn2.conn.Open();
            }else
            {
                SQLConn2.conn.Close();
                SQLConn2.conn.Open();
            }
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn2.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@CoilTagID", CoilTagID );
            cmd.Parameters.AddWithValue("@CoilTagSuffix", CoilTagSuffix);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        private DbDataReader GetCCSOrderNumbers(int CoilTagID, string CoilTagSuffix)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + PlantLocation.city + " .OrderHdr as oh ");


            sb.Append("where orderID in  ");
            sb.Append("(select orderID from " + PlantLocation.city + ".CoilPolishHdr as cd  ");
            sb.Append("where oh.orderID = cd.orderID  ");
            sb.Append("and cd.coilTagID = @CoilTagID ");
            sb.Append("and cd.coilTagSuffix = @CoilTagSuffix ) ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("order by oh.OrderID ");


            String sql = sb.ToString();
            if (SQLConn2.conn.State == ConnectionState.Closed)
            {
                SQLConn2.conn.Open();
            }
            else
            {
                SQLConn2.conn.Close();
                SQLConn2.conn.Open();
            }
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn2.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@CoilTagID", CoilTagID);
            cmd.Parameters.AddWithValue("@CoilTagSuffix", CoilTagSuffix);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        private DbDataReader GetClClDiffOrderNumbers(int CoilTagID, string CoilTagSuffix)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + PlantLocation.city + ".OrderHdr as oh ");


            sb.Append("where orderID in  ");
            sb.Append("(select orderID from " + PlantLocation.city + ".CoilSlitOrderHdr as cd  ");
            sb.Append("where oh.orderID = cd.orderID  ");
            sb.Append("and cd.coilTagID = @CoilTagID ");
            sb.Append("and cd.coilTagSuffix = @CoilTagSuffix ) ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("order by oh.OrderID ");


            String sql = sb.ToString();
            if (SQLConn2.conn.State == ConnectionState.Closed)
            {
                SQLConn2.conn.Open();
            }
            else
            {
                SQLConn2.conn.Close();
                SQLConn2.conn.Open();
            }
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn2.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@CoilTagID", CoilTagID);
            cmd.Parameters.AddWithValue("@CoilTagSuffix", CoilTagSuffix);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader LoadPVCGroup(bool useSecondConnection = false)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".PVCGroup ");
            sb.Append(" where active > 0");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();
            if (useSecondConnection)
            {
                if (SQLConn2.conn.State != System.Data.ConnectionState.Open)
                {
                    SQLConn2.conn.Open();
                }
                cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn2.conn,
                    CommandText = sql
                };
            }
            else
            {
                cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn.conn,
                    CommandText = sql
                };
            }
            


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        private DbDataReader LoadPVCVendorInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".PVCVendor ");


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

        private DbDataReader LoadClClDiffOrderHdr(int orderID)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".orderHdr oh ," + PlantLocation.city + ".CoilSlitOrderHdr ch ");

            sb.Append("where oh.orderID = ch.orderID ");
            sb.Append("and oh.orderID = " + orderID);

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
        private DbDataReader LoadClSKSameOrderHdr(int orderID)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".orderHdr oh ");

            sb.Append("where oh.orderID = " + orderID);

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
        private DbDataReader LoadClClSameOrderHdr(int orderID)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".orderHdr oh ," + PlantLocation.city + ".coilPolishHdr ch ");

            sb.Append("where oh.orderID = ch.orderID ");
            sb.Append("and oh.orderID = " + orderID);

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
        private void LoadClClDiffOrders(int machineID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT distinct oh.orderID ");

            sb.Append("from " + PlantLocation.city + ".orderHdr oh ," + PlantLocation.city + ".coilSlitOrderHdr ch ");

            sb.Append("where oh.orderID = ch.orderID ");
            sb.Append("and machineID = " + machineID);
            sb.Append(" and oh.customerID = " + TreeViewCustomer.SelectedNode.Tag);
            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            comboBoxClClSameModify.Items.Clear();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        comboBoxClClDiffModify.Items.Add(orderID);
                    }
                }
            }
        }

        private void LoadCLSKSameOrders(int custID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select oh.* From tsamaster.Processes pr, ");
            sb.Append(PlantLocation.city + ".machines ma," + PlantLocation.city + ".OrderHdr oh ");
            sb.Append("where pr.ProcessID = ma.processID ");
            sb.Append("and pr.ProcessDesc = 'Cut To Length' ");
            sb.Append("and ma.machineID = oh.MachineID ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and oh.customerID = " + custID.ToString());
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            comboBoxCTLModify.Items.Clear();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        comboBoxCTLModify.Items.Add(orderID);
                    }
                }
            }
        }
        private void LoadClClSameOrders(int machineID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT distinct oh.orderID ");

            sb.Append("from " + PlantLocation.city + ".orderHdr oh ," + PlantLocation.city + ".coilPolishHdr ch ");

            sb.Append("where oh.orderID = ch.orderID ");
            sb.Append("and machineID = " + machineID);
            sb.Append(" and oh.customerID = " + TreeViewCustomer.SelectedNode.Tag);
            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            comboBoxClClSameModify.Items.Clear();
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        comboBoxClClSameModify.Items.Add(orderID);
                    }
                }
            }
        }
        private void DisplayCoilData(string customerID)
        {
            Count.counter++;
            ListViewCoilData.Items.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            //sb.Append("from " + PlantLocation.city + ".coil cl, " + PlantLocation.city + ".Alloy al, " + 
            //        PlantLocation.city + ".AlloyFinish af, " + PlantLocation.city + ".receiveDtl rd, " + 
            //        PlantLocation.city + ".receivehdr rh, " + PlantLocation.city + ".Customer cu ");


            sb.Append("from " + PlantLocation.city + ".coil cl, " + PlantLocation.city + ".Alloy al, " +
                    PlantLocation.city + ".AlloyFinish af, " +
                    PlantLocation.city + ".receivehdr rh, " + PlantLocation.city + ".Customer cu ");

            sb.Append("where cl.customerID = " + customerID + " and ((cl.coilstatus > 0 and cl.weight >0) or cl.coilstatus = -3) ");

            sb.Append("and cl.AlloyID = al.AlloyID and cl.finishID = af.FinishID ");
            //sb.Append("and cl.coilTagID = rd.coilTagID ");
            sb.Append("and rh.receiveID = cl.receiveID ");
            sb.Append("and cl.customerID = cu.customerID ");
            sb.Append("order by cl.coilTagID,cl.coilTagSuffix;");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            int cntr = 0;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    
                    int custTier = 0;

                    while (reader.Read())
                    {
                        string CoilTag = reader.GetValue(reader.GetOrdinal("coilTagID")).ToString().Trim();
                        string coilTagSuffix = reader.GetValue(reader.GetOrdinal("coilTagSuffix")).ToString();
                        CoilTag = CoilTag + coilTagSuffix;
                        int coilStatus = reader.GetInt32(reader.GetOrdinal("coilStatus"));
                        string strLocation = reader.GetValue(reader.GetOrdinal("location")).ToString();
                        string alloy = reader.GetValue(reader.GetOrdinal("alloyDesc")).ToString().Trim() + " " + reader.GetValue(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                        int alloyID = reader.GetInt32(reader.GetOrdinal("alloyID"));
                        int finishID = reader.GetInt32(reader.GetOrdinal("finishID"));
                        string gauge = reader.GetDecimal(reader.GetOrdinal("Thickness")).ToString("G29");
                        string width = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29");
                        string length = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29");
                        string weight = reader.GetDecimal(reader.GetOrdinal("weight")).ToString("G29");
                        string millCoilNum = reader.GetValue(reader.GetOrdinal("millCoilNum")).ToString();
                        string heat = reader.GetValue(reader.GetOrdinal("Heat")).ToString();
                        string carbon = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29");
                        string vendor = reader.GetValue(reader.GetOrdinal("Vendor")).ToString();
                        string PONum = reader.GetValue(reader.GetOrdinal("purchaseOrder")).ToString();
                        string Container = reader.GetValue(reader.GetOrdinal("Container")).ToString();
                        string recDate = reader.GetDateTime(reader.GetOrdinal("receiveDate")).ToShortDateString();
                        string recID = reader.GetValue(reader.GetOrdinal("receiveID")).ToString();
                        string coilCount = reader.GetValue(reader.GetOrdinal("coilCount")).ToString();
                        string countryOfOrigin = reader.GetValue(reader.GetOrdinal("countryOfOrigin")).ToString();
                        custTier = reader.GetInt32(reader.GetOrdinal("PriceTier"));
                        int steelTypeID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));

                        ListViewCoilData.Items.Add(new System.Windows.Forms.ListViewItem(new string[] { CoilTag.Trim(), strLocation.Trim(),alloy.Trim(),
                                                        gauge.Trim(),width.Trim(),length.Trim(),weight.Trim(),millCoilNum.Trim(),heat.Trim(),
                                                        carbon.Trim(),vendor.Trim(),PONum.Trim(),Container.Trim(),recDate.Trim(),
                                                        recID.Trim(),coilCount.Trim(),countryOfOrigin.Trim(),"" }));
                        ListViewCoilData.Items[cntr].SubItems[0].Tag = coilTagSuffix;
                        ListViewCoilData.Items[cntr].SubItems[2].Tag = alloyID;
                        ListViewCoilData.Items[cntr].SubItems[3].Tag = finishID; //putting finishid in thickness tag. easist place to hide it....
                        ListViewCoilData.Items[cntr].SubItems[4].Tag = steelTypeID;//putting steeltype in width
                        if (coilStatus == 2)
                        {
                            ListViewCoilData.Items[cntr].ForeColor = Color.Blue;
                        }
                        cntr++;

                    }
                    ListViewCoilData.Tag = custTier;
                }

            }

            
        }

        

        private Boolean GetCoilShipping (string customerID, string tagID, string coilTagSuffix)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from " + PlantLocation.city + ".shipdtl sd, " + PlantLocation.city + ".shiphdr sh ");
            sb.Append("where sd.shipID = sh.shipID ");
            sb.Append("and sh.status > 0 ");
            sb.Append("and sh.customerid = " + customerID.ToString());
            sb.Append(" and sd.id = " + tagID);
            sb.Append(" and sd.coiltagsuffix = @CoilTagSuffix ");
            sb.Append(" and sd.type = 0");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@CoilTagSuffix", coilTagSuffix);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }

            return false;
                    
        }

        private void DisplaySkidData(string customerID)
        {
            Count.counter++;
            listViewSkidData.Items.Clear();

            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            using (DbDataReader reader = db.GetSkidInfo(customerID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    int custTier = 0;

                    while (reader.Read())
                    {

                        string skidID = reader.GetValue(reader.GetOrdinal("skidID")).ToString().Trim();
                        int coilID = Convert.ToInt32(skidID);
                        string coilTagSuffix = reader.GetValue(reader.GetOrdinal("coilTagSuffix")).ToString().Trim();
                        string letter = reader.GetValue(reader.GetOrdinal("letter")).ToString().Trim();

                        skidID = skidID.Trim() + coilTagSuffix.Trim() + "." + letter.Trim();


                        int skidStatus = reader.GetInt32(reader.GetOrdinal("skidStatus"));

                        string strLocation = reader.GetValue(reader.GetOrdinal("location")).ToString().Trim();
                        string alloy = reader.GetValue(reader.GetOrdinal("alloyDesc")).ToString().Trim() + " " + reader.GetValue(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                        int alloyID = reader.GetInt32(reader.GetOrdinal("alloyID"));
                        int finishID = reader.GetInt32(reader.GetOrdinal("finishID"));
                        int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                        string gauge = reader.GetDecimal(reader.GetOrdinal("Thickness")).ToString("G29").Trim();
                        string width = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                        string length = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();
                        string coilWeight = reader.GetDecimal(reader.GetOrdinal("weight")).ToString("G29").Trim();
                        string millCoilNum = reader.GetValue(reader.GetOrdinal("millCoilNum")).ToString().Trim();
                        string heat = reader.GetValue(reader.GetOrdinal("Heat")).ToString().Trim();
                        string carbon = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                        int pvc = reader.GetInt32(reader.GetOrdinal("pvcID"));
                        int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                        custTier = reader.GetInt32(reader.GetOrdinal("PriceTier"));
                        int steelTypeID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));
                        decimal sheetweight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                        string skidComments = reader.GetString(reader.GetOrdinal("comments")).Trim();
                        int notPrime = reader.GetInt32(reader.GetOrdinal("notPrime"));
                        decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                        string strNotPrime = "False";
                        string branchName = reader.GetString(reader.GetOrdinal("BranchDescShort")).Trim();
                        int branchID = reader.GetInt32(reader.GetOrdinal("BranchID"));
                        int skidWeight = GetSkidWeight(sheetweight, pieces, density, Convert.ToDecimal(gauge), Convert.ToDecimal(length), Convert.ToDecimal(width));
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        int skidTypeID = reader.GetInt32(reader.GetOrdinal("skidTypeID"));

                        string strPVC = "False";
                        if (pvc > 0)
                        {
                            pvc = Convert.ToInt32(((Convert.ToDecimal(width) * Convert.ToDecimal(length)) / 144) * pieces);
                            strPVC = pvc.ToString().Trim();
                        }
                        string strPaper = "False";
                        if (paper > 0)
                        {
                            paper = Convert.ToInt32(((Convert.ToDecimal(width) * Convert.ToDecimal(length)) / 144) * pieces);
                            strPaper = paper.ToString().Trim();
                        }

                        if (notPrime > 0)
                        {
                            strNotPrime = "True";
                        }
                        ListViewItem lvitem =
                            listViewSkidData.Items.Add(new ListViewItem(new string[] { skidID.Trim(), strLocation.Trim(),pieces.ToString().Trim(), alloy.Trim(),
                                                        gauge.Trim(),width.Trim(),length.Trim(),skidWeight.ToString().Trim(),millCoilNum.Trim(),heat.Trim(),strPVC.Trim(),
                                                        strPaper.Trim(),skidComments.Trim(), strNotPrime.Trim(),branchName.Trim(),""}));//last item is holder for orders
                        lvitem.SubItems[0].Tag = coilTagSuffix;
                        lvitem.SubItems[1].Tag = orderID;
                        lvitem.SubItems[3].Tag = alloyID;
                        lvitem.SubItems[4].Tag = finishID; //putting finishid in thickness tag. easist place to hide it....
                        lvitem.SubItems[5].Tag = letter;//had to put letter here
                        lvitem.SubItems[6].Tag = skidTypeID;
                        lvitem.SubItems[10].Tag = steelTypeID;//putting steeltype in comments

                        lvitem.SubItems[12].Tag = branchID;
                        if (notPrime > 0)
                        {
                            lvitem.ForeColor = Color.Crimson;
                        }
                        if (skidStatus == 2)
                        {
                            lvitem.ForeColor = Color.Blue;
                        }
                        cntr++;

                    }
                    for (int i = 0; i < listViewSkidData.Columns.Count; i++)
                    {
                        listViewSkidData.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                        listViewSkidData.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                    }



                }
            }

            db.CloseSQLConn();
            






        }

        private Boolean GetSkidShipping(string customerID, int tagID, string coilTagSuffix, string letter)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from " + PlantLocation.city + ".shipdtl sd, " + PlantLocation.city + ".shiphdr sh ");
            sb.Append("where sd.shipID = sh.shipID ");
            sb.Append("and sh.status > 0 ");
            sb.Append("and sh.customerid = " + customerID);
            sb.Append(" and sd.id = " + tagID.ToString());
            sb.Append(" and sd.coiltagsuffix = @CoilTagSuffix ");
            sb.Append(" and sd.letter = @letter ");
            sb.Append(" and sd.type = 1");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@CoilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", letter);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }

            return false;

        }
        private int GetSkidWeight(decimal sheetweight, int pieces,decimal density ,decimal gauge,decimal length,decimal width)
        {
            int skidWeight = 0;
            if (sheetweight > 0)
            {
                skidWeight = Convert.ToInt32(sheetweight * pieces);
            }
            else
            {
                skidWeight = Convert.ToInt32(MetFormula(density, Convert.ToDecimal(gauge), Convert.ToDecimal(length), Convert.ToDecimal(width), pieces, 0));
            }

            return skidWeight;
        }
        private void LoadType()
        {
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"]).Items.Add("Coil");
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"]).Items.Add("Skid");
            if (RecGridInfo.row == 0)
            {

                dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"].Value = "Coil";
            }
        }

        
        private void LoadRecFinish(string alloyID)
        {


            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinish"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinish"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Items.Clear();
            DBUtils db = new DBUtils();
            db.OpenSQLConn();


            using (DbDataReader reader = db.GetFinish(alloyID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string Finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        int FinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));




                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinish"]).Items.Add(Finish);
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Items.Add(FinishID);

                        cntr++;



                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }
        private void LoadClClDiffFinish(string alloyID, int finishID, int row)
        {

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            using (DbDataReader reader = db.GetFinish(alloyID, finishID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string Finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        int FinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));


                        dataGridViewClClDiff.Rows[row].Cells["colClClSameOrigFinish"].Value = Finish;
                        dataGridViewClClDiff.Rows[row].Cells["colClClSameOrigFinish"].Tag = FinishID;
                        cntr++;



                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }

        private AlloyInfo GetFinishInfo(string alloyID, int finishID)
        {

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            AlloyInfo ai = new AlloyInfo();
            using (DbDataReader reader = db.GetFinish(alloyID, finishID))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        ai.finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        ai.finishID = reader.GetInt32(reader.GetOrdinal("FinishID"));

                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
            return ai;
        }

        private void LoadSSSmFinish(string alloyID, int finishID, int row)
        {

            LoadChangeFinish(alloyID, finishID, row, dataGridViewSSSmSkid, MachineDefaults.SSSmDefaultFinish, "dgvSSSmOrigFinish", "dgvSSSmNewFinish", "dgvSSSmFinishID");

            return;



        }

        private void LoadClClSameFinish(string alloyID, int finishID, int row)
        {

            LoadChangeFinish(alloyID, finishID, row, dataGridViewCLCLSame, MachineDefaults.ClClSameDefaultFinish, "colClClSameOrigFinish", "colClClSameNewFinish", "colClClSameNewFinishID");

            return;


            
        }

        private void LoadChangeFinish(string alloyID, int finishID, int row, DataGridView dgv, string defFinish, string colOrigFin, string colNewFin, string colNewFinID)
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            //get the original finish of the material
            using (DbDataReader reader = db.GetFinish(alloyID, finishID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string Finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        int FinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));


                        dgv.Rows[row].Cells[colOrigFin].Value = Finish;
                        dgv.Rows[row].Cells[colOrigFin].Tag = FinishID;
                        cntr++;



                    }
                }
                reader.Close();
            }
            //get all finishes for this Alloy
            using (DbDataReader reader = db.GetFinish(alloyID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string Finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        int FinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));
                        

                        ((DataGridViewComboBoxCell)dgv.Rows[row].Cells[colNewFin]).Items.Add(Finish);
                        ((DataGridViewComboBoxCell)dgv.Rows[row].Cells[colNewFinID]).Items.Add(FinishID);
                        if (defFinish.Trim().Equals(Finish))
                        {
                            dgv.Rows[row].Cells[colNewFin].Value = Finish;
                            dgv.Rows[row].Cells[colNewFinID].Value = FinishID;
                        }

                        cntr++;



                    }
                }
                reader.Close();
            }
            
        }

        
        
        private void LoadMachines(int procID)
        {

            tabControlMachines.TabPages.Clear();




            int leadTime = 0;

            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            using (DbDataReader reader = db.GetMachineInfo(procID))
            {
                if (reader.HasRows)
                {
                    int machineCntr = 0;

                    while (reader.Read())
                    {

                        string machineName = reader.GetString(reader.GetOrdinal("machineName")).Trim();
                        int machineID = reader.GetInt32(reader.GetOrdinal("machineID"));
                        
                        tabControlMachines.TabPages.Add(machineName);
                        tabControlMachines.TabPages[machineCntr].Tag = machineID;
                        if (machineCntr == 0)
                        {
                            leadTime = reader.GetInt32(reader.GetOrdinal("LeadTime"));

                            string procFunc = reader.GetString(reader.GetOrdinal("processFunction")).Trim();
                            switch (procFunc)
                            {
                                case ProcessFunction.ClClSame://coil polish
                                    panelCoilCoilSame.BringToFront();
                                    
                                    panelCoilSheetSame.Visible = false;
                                    panelClClDiff.Visible = false;
                                    panelSheetSheetSame.Visible = false;
                                    panelSheetSheetDiff.Visible = false;
                                    panelCoilCoilSame.Visible = true;
                                    DateTime dtClClSame = DateTime.Now.AddBusinessDays(leadTime);
                                    dateTimePickerClClSamePromise.Value = dtClClSame;

                                    break;
                                case ProcessFunction.ClSkSame://cut to length
                                    panelCoilSheetSame.BringToFront();
                                    
                                    panelCoilCoilSame.Visible = false;
                                    panelClClDiff.Visible = false;
                                    panelSheetSheetSame.Visible = false;
                                    panelSheetSheetDiff.Visible = false;
                                    panelCoilSheetSame.Visible = true;
                                    DateTime dtClSkSame = DateTime.Now.AddBusinessDays(leadTime);
                                    dateTimePickerCTLPromiseDate.Value = dtClSkSame;
                                    break;
                                case ProcessFunction.ClClDiff://slitter
                                    panelClClDiff.BringToFront();
                                    
                                    panelCoilCoilSame.Visible = false;
                                    panelCoilSheetSame.Visible = false;
                                    panelSheetSheetSame.Visible = false;
                                    panelSheetSheetDiff.Visible = false;
                                    panelClClDiff.Visible = true;
                                    DateTime dtClClDiff = DateTime.Now.AddBusinessDays(leadTime);
                                    dateTimePickerClClDiffPromiseDate.Value = dtClClDiff;
                                    break;
                                case ProcessFunction.ShShSame://sheet polish/buff
                                    panelSheetSheetSame.BringToFront();
                                    
                                    panelCoilCoilSame.Visible = false;
                                    panelCoilSheetSame.Visible = false;
                                    panelSheetSheetDiff.Visible = false;
                                    panelClClDiff.Visible = false;
                                    panelSheetSheetSame.Visible = true;
                                    DateTime dtSSSmSame = DateTime.Now.AddBusinessDays(leadTime);
                                    dateTimePickerSSSmPromiseDate.Value = dtSSSmSame;
                                    break;

                                case ProcessFunction.ShShDiff:
                                    panelSheetSheetDiff.BringToFront();
                                    
                                    panelSheetSheetSame.Visible = false;
                                    panelCoilCoilSame.Visible = false;
                                    panelCoilSheetSame.Visible = false;
                                    panelClClDiff.Visible = false;
                                    panelSheetSheetDiff.Visible = true;
                                    DateTime dtSSD = DateTime.Now.AddBusinessDays(leadTime);
                                    dateTimePickerSSDPromiseDate.Value = dtSSD;
                                    break;

                            }
                        }
                        machineCntr++;


                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
            int macid = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
            leadTime = GetMachineLeadTimes(macid);
            SetLeadTime(leadTime);
        }
        private void LoadProcesses()
        {

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
        private int UpdateSkidPricing(SkidPriceUpdate skup)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".skidPricing ");
            sb.Append("set fromWidth = @newFromWidth, ");
            sb.Append("toWidth = @newToWidth, ");
            sb.Append("fromLength = @newFromLength, ");
            sb.Append("toLength = @newToLength, ");
            sb.Append("price = @Price output inserted.TierLevel ");





            sb.Append(" where tierLevel = @tierLevel ");
            sb.Append("and skidTypeID = @skidTypeID ");
            sb.Append("and fromWidth = @oldFromWidth ");
            sb.Append("and toWidth = @oldToWidth ");
            sb.Append("and fromLength = @oldFromLength ");
            sb.Append("and toLength = @oldToLength ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };


            cmd.Parameters.AddWithValue("@newFromWidth", skup.newFromWidth);
            cmd.Parameters.AddWithValue("@newToWidth", skup.newToWidth);
            cmd.Parameters.AddWithValue("@newFromLength", skup.newFromLength);
            cmd.Parameters.AddWithValue("@newToLength", skup.newToLength);
            cmd.Parameters.AddWithValue("@tierLevel", skup.tier);
            cmd.Parameters.AddWithValue("@skidTypeID", skup.skidID);
            cmd.Parameters.AddWithValue("@oldFromWidth", skup.oldFromWidth);
            cmd.Parameters.AddWithValue("@oldToWidth", skup.oldToWidth);
            cmd.Parameters.AddWithValue("@oldFromLength", skup.oldFromLength);
            cmd.Parameters.AddWithValue("@oldToLength", skup.oldToLength);
            cmd.Parameters.AddWithValue("@Price", skup.price);

            int tierLevel = (int)cmd.ExecuteScalar();


            return tierLevel;
        }
        private int UpdateLeadTime(int machineID, int leadTime)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".Machines set leadTime = @leadTime ");
            sb.Append("output inserted.machineID where machineID = @machineID");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };


            cmd.Parameters.AddWithValue("@leadTime", leadTime);
            cmd.Parameters.AddWithValue("@machineID", machineID);


            machineID = (int)cmd.ExecuteScalar();


            return machineID;
        }


        private int GetMachineLeadTimes(int machineID)
        {
            int leadTime = 0;

            StringBuilder sb = new StringBuilder();
            int custID = -99;
            if (TreeViewCustomer.Nodes.Count > 0)
            {
                custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);

                sb.Append("SELECT mc.LeadTime, cu.leadTime as CustLeadTime from " + PlantLocation.city + ".Machines mc, " + PlantLocation.city + ".Customer cu ");

                sb.Append("where mc.machineID = " + machineID);
                sb.Append("and cu.CustomerID = " + custID);

            }
            else
            {
                sb.Append("SELECT * as CustLeadTime from " + PlantLocation.city + ".Machines mc ");

                sb.Append("where mc.machineID = " + machineID);
                
            }


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

                    while (reader.Read())
                    {
                        leadTime = reader.GetInt32(reader.GetOrdinal("LeadTime"));
                        if (custID != -99)
                        {
                            int custLead = reader.GetInt32(reader.GetOrdinal("CustLeadTime"));
                            if (custLead < leadTime && custLead > 0)
                            {
                                leadTime = custLead;
                                labelSpecialLeadTime.Visible = true;
                            }
                            else
                            {
                                labelSpecialLeadTime.Visible = false;
                            }
                        }
                        
                    }
                }
            }

            return leadTime;
        }

        private void LoadClClDiffNextMachine(int machineID)
        {

            comboBoxClClDiffSendTo.Items.Clear();
            using (DbDataReader reader = LoadNextMachineConnection(machineID))
            {


                if (reader.HasRows)
                {
                    comboBoxClClDiffSendTo.DisplayMember = "Text";
                    comboBoxClClDiffSendTo.ValueMember = "Value";
                    while (reader.Read())
                    {
                        string toMachine = reader.GetString(reader.GetOrdinal("toMachine")).Trim();
                        int toMachineID = reader.GetInt32(reader.GetOrdinal("toMachineID"));
                        comboBoxClClDiffSendTo.Items.Add(new { Text = toMachine, Value = toMachineID });
                    }
                    comboBoxClClDiffSendTo.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("There are no downstream machines available!");
                    checkBoxClClDiffMultStep.Checked = false;
                }

            }

        }
        private void LoadClClNextMachine(int machineID)
        {

            comboBoxClClSameToMachine.Items.Clear();
            using (DbDataReader reader = LoadNextMachineConnection(machineID))
            {


                if (reader.HasRows)
                {
                    comboBoxClClSameToMachine.DisplayMember = "Text";
                    comboBoxClClSameToMachine.ValueMember = "Value";
                    while (reader.Read())
                    {
                        string toMachine = reader.GetString(reader.GetOrdinal("toMachine")).Trim();
                        int toMachineID = reader.GetInt32(reader.GetOrdinal("toMachineID"));
                        comboBoxClClSameToMachine.Items.Add(new { Text = toMachine, Value = toMachineID });
                    }
                    comboBoxClClSameToMachine.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("There are no downstream machines available!");
                    checkBoxClClSameMultiStep.Checked = false;
                }

            }

        }

        private DbDataReader LoadNextMachineConnection(int machineID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select mc.MachineConnectionID , m1.machineID as fromMachineID, ");
            sb.Append("m2.machineID as toMachineID ,m1.machineName as fromMachine, m2.machineName as toMachine ");
            sb.Append("from " + PlantLocation.city + ".MachineConnections mc, " + PlantLocation.city + ".machines m1, " + PlantLocation.city + ".Machines m2 ");
            sb.Append("where mc.frommachine = m1.machineID ");
            sb.Append("and mc.toMachine = m2.machineID ");
            sb.Append("and m1.machineID = " + machineID);

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
        private void LoadOrderFlow()
        {
            listViewOrderFlowMachines.Items.Clear();
            StringBuilder sb = new StringBuilder();

            sb.Append("select mc.MachineConnectionID , m1.machineName as m1Name, m2.machineName as m2Name ");
            sb.Append("from " + PlantLocation.city + ".MachineConnections mc, " + PlantLocation.city + ".machines m1, " + PlantLocation.city + ".Machines m2 ");
            sb.Append("where mc.frommachine = m1.machineID ");
            sb.Append("and mc.toMachine = m2.machineID ");
            sb.Append("order by m1.machineName ");
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
                    int cntr = 0;
                    while (reader.Read())
                    {
                        int machineConnID = reader.GetInt32(reader.GetOrdinal("MachineConnectionID"));
                        string fromMachine = reader.GetString(reader.GetOrdinal("m1Name")).Trim();
                        string toMachine = reader.GetString(reader.GetOrdinal("m2Name")).Trim();

                        listViewOrderFlowMachines.Items.Add(
                            new System.Windows.Forms.ListViewItem(new string[]
                            { fromMachine.Trim(), toMachine.Trim() }));

                        listViewOrderFlowMachines.Items[cntr].Tag = machineConnID;
                        cntr++;
                    }
                }
            }

            sb.Clear();
            sb.Append("select m1.machineID, m1.machineName ");
            sb.Append("from " + PlantLocation.city + ".machines m1 ");


            sql = sb.ToString();

            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            if (comboBoxOrdFlowToMachine.Text.Equals(""))
            {
                comboBoxOrdFlowToMachine.Items.Clear();
                comboBoxOrdFlowFromMachine.Items.Clear();



                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        comboBoxOrdFlowFromMachine.DisplayMember = "Text";
                        comboBoxOrdFlowFromMachine.ValueMember = "Value";
                        while (reader.Read())
                        {

                            string fromMachine = reader.GetString(reader.GetOrdinal("machineName")).Trim();
                            int fromMachineID = reader.GetInt32(reader.GetOrdinal("machineID"));
                            comboBoxOrdFlowFromMachine.Items.Add(new { Text = fromMachine, Value = fromMachineID });


                        }
                    }
                }
                if (comboBoxOrdFlowFromMachine.Items.Count > 0)
                {
                    comboBoxOrdFlowFromMachine.SelectedIndex = 0;
                }
                
            }
        }
        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            
            for (int i = 0; i < drives.Count(); i++)
            {
                cbReportDrive.Items.Add(drives[i].Name);
                if (drives[i].Name.Equals(MachineDefaults.ReportDrive))
                {
                    cbReportDrive.Text = MachineDefaults.ReportDrive;
                }
            }

            
        }
        private void LoadMachineLeadTimes()
        {

            dataGridViewLeadTimes.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".Machines mc ");


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
                    int cntr = 0;
                    int leadTime = 3;
                    while (reader.Read())
                    {

                        string machineName = reader.GetString(reader.GetOrdinal("machineName")).Trim();
                        if (!reader.IsDBNull(reader.GetOrdinal("leadTime")))
                        {
                            leadTime = reader.GetInt32(reader.GetOrdinal("leadTime"));
                        }
                        else
                        {
                            leadTime = 3;
                        }
                        
                        int machineID = reader.GetInt32(reader.GetOrdinal("machineID"));
                        dataGridViewLeadTimes.Rows.Add();
                        dataGridViewLeadTimes.Rows[cntr].Cells["colMachine"].Value = machineName;
                        dataGridViewLeadTimes.Rows[cntr].Cells["colMachine"].Tag = machineID;
                        dataGridViewLeadTimes.Rows[cntr].Cells["colLeadTime"].Value = leadTime;

                        DateTime dt = DateTime.Now.AddBusinessDays(leadTime);
                        dataGridViewLeadTimes.Rows[cntr].Cells["colDate"].Value = dt.DayOfWeek + " " + dt.ToShortDateString();

                        cntr++;



                    }
                }
            }
        }

        private void LoadClClDiffAlloy(int row, int FindAlloyID)
        {

            DBUtils db = new DBUtils();
            db.OpenSQLConn();            

            using (DbDataReader reader = db.GetAlloyData(FindAlloyID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string alloy = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        int alloyID = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                        decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));



                        dataGridViewClClDiff.Rows[row].Cells["colClClDiffAlloy"].Value = alloy;
                        dataGridViewClClDiff.Rows[row].Cells["colClClDiffAlloy"].Tag = alloyID;
                        cntr++;



                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }

        private AlloyInfo GetAlloyInfo(int FindAlloyID)
        {

            AlloyInfo ai = new AlloyInfo();

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            using (DbDataReader reader = db.GetAlloyData(FindAlloyID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        ai.alloy = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        ai.alloyID = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                        ai.density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));




                        cntr++;



                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
            return ai;
        }

        private void LoadRecAlloy()
        {
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloy"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloyID"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colSteelType"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colRecSteelDesc"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinish"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloy"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloyID"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinish"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colSteelType"]).Items.Clear();
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colRecSteelDesc"]).Items.Clear();

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetAlloyData())
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string alloy = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        int alloyID = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                        decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                        int steelTypeID = reader.GetInt32(reader.GetOrdinal("steelTypeID"));
                        string steelDesc = reader.GetString(reader.GetOrdinal("SteelDesc"));

                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloy"]).Items.Add(alloy);
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloyID"]).Items.Add(alloyID);
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"]).Items.Add(density);
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colSteelType"]).Items.Add(steelTypeID);
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colRecSteelDesc"]).Items.Add(steelDesc);

                        cntr++;



                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }

       

        private void LoadDamage()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".DamageDescription ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            checkedListBoxDamage.DisplayMember = "Text";
            checkedListBoxDamage.ValueMember = "Value";

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {

                        string damageDesc = reader.GetString(reader.GetOrdinal("damageDescription")).Trim();
                        int damID = reader.GetInt32(reader.GetOrdinal("damageDescID"));

                        checkedListBoxDamage.Items.Insert(cntr, new MyListBoxItem { Text = damageDesc, Value = damID });

                        cntr++;



                    }
                }
            }
        }

        private DbDataReader GetWorkers(bool onlyActive = false)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".workers ");
            if (onlyActive)
            {
                sb.Append("where active > 0");
            }
            else
            {
                sb.Append("order by active desc, firstName");
            }

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



        private void LoadWorkers()
        {

            

            using (DbDataReader reader = GetWorkers(true))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
                    System.Windows.Forms.ComboBox cbID = new System.Windows.Forms.ComboBox();
                    while (reader.Read())
                    {
                        string firstName = reader.GetString(reader.GetOrdinal("firstName")).Trim();
                        string lastname = reader.GetString(reader.GetOrdinal("lastName")).Trim();
                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colUnloader"]).Items.Add(firstName + " " + lastname);

                        ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWorkerID"]).Items.Add(reader.GetValue(reader.GetOrdinal("workerID")));
                        //dataGridViewReceiving.Rows[RecGridInfo.row].Cells[1].
                        cntr++;
                    }

                }
            }
        }
        private void LoadPlantLocations()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT LocDesc from TSAMaster.Locations");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            int tabwidth = 0;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    int cntr = 0;

                    while (reader.Read())
                    {
                        string loc = reader.GetString(reader.GetOrdinal("LocDesc")).Trim();
                        tabControlPlantLocations.TabPages.Add(loc);
                        if (loc == PlantLocation.city)
                        {
                            tabControlPlantLocations.SelectedIndex = cntr;
                        }
                        Size sz = TextRenderer.MeasureText(loc, tabControlPlantLocations.Font);
                        tabwidth += sz.Width+7;
                        cntr++;
                    }
                    tabControlPlantLocations.TabPages.Add("Settings");
                    Size sz1 = TextRenderer.MeasureText("Settings", tabControlPlantLocations.Font);
                    tabwidth += sz1.Width+7;
                }
            }

            tabControlPlantLocations.Width = tabwidth ;
        }

        private DbDataReader GetCustInfo(int custID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".Customer ");
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

       
        private void LoadCustomers(bool bViewInactive)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT customerID,ShortCustomerName from " + PlantLocation.city + ".Customer ");
            if (bViewInactive)
            {

            }
            else
            {
                sb.Append("where isActive = 1 ");
            }

            sb.Append("order by ShortCustomerName;");


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
                    int cntr = 1;
                    TreeNode trnd;
                    while (reader.Read())
                    {


                        trnd = TreeViewCustomer.Nodes.Add(reader.GetString(reader.GetOrdinal("ShortCustomerName")).Trim());
                        trnd.Tag = reader.GetInt32(reader.GetOrdinal("CustomerID"));

                        cntr++;
                    }

                    //start with the first node for customers.
                    if (cntr > 1)
                    {
                        TreeViewCustomer.Nodes[0].TreeView.SelectedNode = TreeViewCustomer.Nodes[0];

                    }


                }
            }


        }

        private void FormICMSMain_Load(object sender, EventArgs e)
        {

        }

        private void StartOrderProcess(string custName, bool withmessage = true)
        {
            try
            {


                if (withmessage)
                {
                    MessageBox.Show("Writing Order for " + custName + "!");
                }

                if (!tabControlMachines.Visible)
                {
                    tabControlMachines.Visible = true;
                    tabControlProcess.Visible = true;
                    LoadProcesses();
                    if (tabControlProcess.TabPages.Count > 0)
                        LoadMachines(Convert.ToInt32(tabControlProcess.TabPages[0].Tag));
                }
                else
                {
                    if (tabControlProcess.SelectedTab.Text.Equals("Coil Polish"))
                    {
                        buttonClClSameReset.PerformClick();
                        OrderCloning();
                        checkBoxClClSameModify.Checked = false;
                        comboBoxClClSameModify.Items.Clear();
                        comboBoxClClSameModify.Text = "";
                        AddOrderCCSInfo();
                    }
                    if (tabControlProcess.SelectedTab.Text.Equals("Slitting"))
                    {
                        buttonClClDiffReset.PerformClick();
                        OrderCloning();
                        checkBoxClClDiffModify.Checked = false;
                        comboBoxClClDiffModify.Items.Clear();
                        comboBoxClClDiffModify.Text = "";
                        AddOrderClClDiffInfo();
                    }
                    if (tabControlProcess.SelectedTab.Text.Equals("Cut To Length"))
                    {

                        buttonCTLReset.PerformClick();
                        OrderCloning();
                        checkBoxCTLModify.Checked = false;
                        checkBoxCTLMultiStep.Checked = false;
                        textBoxCTLPO.Text = "";
                        textBoxCTLRunSheetComments.Text = "";
                        AddOrderCTLInfo();

                    }

                    if (tabControlProcess.SelectedTab.Text.Equals("Sheet Polish"))
                    {

                        //buttonCTLReset.PerformClick();
                        OrderCloning();
                        checkBoxSSSmModify.Checked = false;
                        checkBoxSSSmMultiStep.Checked = false;
                        textBoxSSSmPO.Text = "";
                        textBoxSSSmRunSheet.Text = "";
                        AddOrderSSSInfo();

                    }
                    if (tabControlProcess.SelectedTab.Text.Equals("Shear"))
                    {
                        OrderCloning();
                        AddOrderSSDInfo();
                        buttonSSDCancelOrder.PerformClick();
                    }
                }
            }
            catch(Exception se)
            {
                MessageBox.Show(se.Message);
            }


        }

        private void LoadOrderMachines()
        {
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            tabControlOrderMachines.TabPages.Clear();
            bool firstone = true;
            int firstMachine = -1;
            string firstProc = "";
            using (DbDataReader reader = db.GetMachineOrders())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string processName = reader.GetString(reader.GetOrdinal("processFunction")).Trim();
                        string MachineName = reader.GetString(reader.GetOrdinal("machineName")).Trim();
                        int machineID = reader.GetInt32(reader.GetOrdinal("machineID"));

                        tabControlOrderMachines.TabPages.Add(machineID.ToString() ,MachineName);
                        tabControlOrderMachines.TabPages[machineID.ToString()].Tag = processName;

                        if (firstone)
                        {
                            firstone = false;
                            firstMachine = machineID;
                            firstProc = processName;
                        }

                    }
                }
            }
            tabControlOrderMachines.TabPages.Add("Print","Print");
            if (!firstone)
            {
                RunSheetSelected(firstMachine, firstProc);
            }
            db.CloseSQLConn();
        }
        private void TabControlICMS_Selected(object sender, TabControlEventArgs e)
        {

            //Main Tab Pages
            if (e.TabPage == tabPageRunSheet)
            {
                LoadOrderMachines();
            }
            if (e.TabPage == tabPageReceiving)
            {

                try
                {
                    
                    dataGridViewReceiving.Rows.Clear();
                    AddReceivingRow();
                    LoadType();
                    LoadWorkers();
                    LoadDamage();
                    dataGridViewReceiving.CurrentCell = dataGridViewReceiving.Rows[0].Cells[1];
                    dataGridViewReceiving.BeginEdit(true);




                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }
                tabPageReceiving.Tag = PlantLocation.city;
            }
            
            if (e.TabPage == tabPageSkid)
            {
                listViewSkidData.Items.Clear();

                DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());
            }
            if (e.TabPage == tabPageOrders)
            {
                if (TreeViewCustomer.GetNodeCount(false) > 0)
                    StartOrderProcess(TreeViewCustomer.SelectedNode.Text);

            }
            else
            {
                tabControlMachines.Visible = false;
                tabControlProcess.Visible = false;
            }
            if (e.TabPage == tabPagePVC)
            {
                LoadListViewPVCDetail(listViewPVCInvDetail);
            }

            if (e.TabPage == tabPageCustomerInfo)
            {
                LoadCustomerInfo();
            }
            if (e.TabPage == tabPageWorkers)
            {
                LoadWorkerInfo();
            }
            if (e.TabPage == tabPageShipping)
            {
                LoadShippingInfo();
            }

        }

        private void LoadShippingInfo(string branch = "")
        {
            
            List<string> branches = new List<string>();
            listViewShipCoil.Items.Clear();
            panelModifyRelease.BringToFront();
            foreach (ListViewItem item in ListViewCoilData.Items)
            {
                listViewShipCoil.Items.Add((ListViewItem)item.Clone());

            }
            listViewShipCoil.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewShipCoil.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            if (branch.Equals(""))
            {
                branches.Add("All");
                //comboBoxBranchChooser.Items.Clear();
                int cntr = 0;
                listViewShipSkid.Items.Clear();
                foreach (ListViewItem item in listViewSkidData.Items)
                {
                    listViewShipSkid.Items.Add((ListViewItem)item.Clone());
                    if (cntr == 0)
                    {
                        branches.Add(item.SubItems[14].Text);
                        cntr++;
                    }
                    else
                    {
                        bool alreadythere = false;
                        foreach (string st in branches.ToArray())
                        {

                            if (st.Equals(item.SubItems[14].Text))
                            {
                                alreadythere = true;
                            }
                        }
                        if (!alreadythere)
                        {
                            branches.Add(item.SubItems[14].Text);
                        }

                    }

                }
                branches.Sort();
                
                
                comboBoxBranchChooser.DataSource = branches;
            }
            else
            {
                listViewShipSkid.Items.Clear();
                foreach (ListViewItem item in listViewSkidData.Items)
                {
                    if (item.SubItems[14].Text.Equals(branch))
                    {
                        listViewShipSkid.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }
           
            listViewShipSkid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewShipSkid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        }

        private void LoadWorkerInfo()
        {
            dataGridViewWorker.Rows.Clear();

            using (DbDataReader reader = GetWorkers())
            {
                if (reader.HasRows)
                {
                    WorkerInfo WI = new WorkerInfo();
                    int cntr = 0;
                    
                    while (reader.Read())
                    {
                        WI.FirstName = reader.GetString(reader.GetOrdinal("firstName")).Trim();
                        WI.LastName = reader.GetString(reader.GetOrdinal("lastName")).Trim();
                        WI.WorkerID = reader.GetInt32(reader.GetOrdinal("workerID"));
                        WI.active = reader.GetInt32(reader.GetOrdinal("active"));

                        dataGridViewWorker.Rows.Add();


                        dataGridViewWorker.Rows[cntr].Cells["WorkerID"].Value = WI.WorkerID;
                        dataGridViewWorker.Rows[cntr].Cells["WorkerFirstName"].Value = WI.FirstName;
                        dataGridViewWorker.Rows[cntr].Cells["WorkerLastName"].Value = WI.LastName;
                        if (WI.active > 0)
                        {
                            dataGridViewWorker.Rows[cntr].Cells["Workeractive"].Value = true;
                            dataGridViewWorker.Rows[cntr].Cells["Workeractive"].Tag = true;
                        }
                        else
                        {
                            dataGridViewWorker.Rows[cntr].Cells["Workeractive"].Value = false;
                            dataGridViewWorker.Rows[cntr].Cells["Workeractive"].Tag = false;
                        }

                        dataGridViewWorker.Rows[cntr].Cells["WorkerID"].Tag = WI.WorkerID;
                        dataGridViewWorker.Rows[cntr].Cells["WorkerFirstName"].Tag = WI.FirstName;
                        dataGridViewWorker.Rows[cntr].Cells["WorkerLastName"].Tag  = WI.LastName;



                        cntr++;

                    }
                    
                }
            }

        }

        private void LoadCustomerInfo()
        {
            dataGridViewCustInfo.Rows.Clear();
            if (TreeViewCustomer.Nodes.Count > 0)
            {
                int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);

                using (DbDataReader reader = GetCustInfo(custID))
                {
                    if (reader.HasRows)
                    {
                        int cntr = 0;
                        while (reader.Read())
                        {
                            dataGridViewCustInfo.Rows.Add();
                            CustInfo CI = new CustInfo
                            {
                                CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                ShortCustomerName = reader.GetString(reader.GetOrdinal("ShortCustomerName")).Trim(),
                                LongCustomerName = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim(),
                                Address1 = reader.GetString(reader.GetOrdinal("Address1")).Trim(),
                                Address2 = reader.GetString(reader.GetOrdinal("Address2")).Trim(),
                                City = reader.GetString(reader.GetOrdinal("City")).Trim(),
                                StateCode = reader.GetString(reader.GetOrdinal("StateCode")).Trim(),
                                Zip = reader.GetString(reader.GetOrdinal("Zip")).Trim(),
                                Country = reader.GetString(reader.GetOrdinal("Country")).Trim(),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")).Trim(),
                                Fax = reader.GetString(reader.GetOrdinal("Fax")).Trim(),
                                ContactName = reader.GetString(reader.GetOrdinal("ContactName")).Trim(),
                                Email = reader.GetString(reader.GetOrdinal("Email")).Trim(),
                                Packaging = reader.GetString(reader.GetOrdinal("Packaging")).Trim(),
                                MaxSkidWeight = reader.GetInt32(reader.GetOrdinal("MaxSkidWeight")),
                                PriceTier = reader.GetInt32(reader.GetOrdinal("PriceTier")),
                                WeightFormula = reader.GetInt32(reader.GetOrdinal("WeightFormula")),
                                IsActive = reader.GetInt32(reader.GetOrdinal("IsActive")),
                                QuickBookName = reader.GetString(reader.GetOrdinal("QuickBookName")).Trim(),
                                leadTime = reader.GetInt32(reader.GetOrdinal("leadTime"))
                            };

                            dataGridViewCustInfo.Rows[cntr].Cells["InfoShortName"].Value = CI.ShortCustomerName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoLongName"].Value = CI.LongCustomerName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress1"].Value = CI.Address1;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress2"].Value = CI.Address2;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoCity"].Value = CI.City;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoState"].Value = CI.StateCode;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoZip"].Value = CI.Zip;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoCountry"].Value = CI.Country;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPhone"].Value = CI.Phone;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoFax"].Value = CI.Fax;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoContact"].Value = CI.ContactName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoEmail"].Value = CI.Email;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPackaging"].Value = CI.Packaging;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoMaxWeight"].Value = CI.MaxSkidWeight;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPriceTier"].Value = CI.PriceTier;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoQBName"].Value = CI.QuickBookName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoLeadTime"].Value = CI.leadTime;

                            dataGridViewCustInfo.Rows[cntr].Cells["InfoShortName"].Tag = CI.ShortCustomerName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoLongName"].Tag = CI.LongCustomerName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress1"].Tag = CI.Address1;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress2"].Tag = CI.Address2;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoCity"].Tag = CI.City;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoState"].Tag = CI.StateCode;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoZip"].Tag = CI.Zip;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoCountry"].Tag = CI.Country;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPhone"].Tag = CI.Phone;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoFax"].Tag = CI.Fax;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoContact"].Tag = CI.ContactName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoEmail"].Tag = CI.Email;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPackaging"].Tag = CI.Packaging;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoMaxWeight"].Tag = CI.MaxSkidWeight;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoPriceTier"].Tag = CI.PriceTier;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoQBName"].Tag = CI.QuickBookName;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoLeadTime"].Tag = CI.leadTime;
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoWeightFormula"].Tag = CI.WeightFormula;

                            if (CI.WeightFormula == 0)
                            {
                                dataGridViewCustInfo.Rows[cntr].Cells["InfoWeightFormula"].Value = true;

                            }
                            else
                            {
                                dataGridViewCustInfo.Rows[cntr].Cells["InfoWeightFormula"].Value = false;
                            }
                            dataGridViewCustInfo.Rows[cntr].Cells["InfoLeadTime"].ToolTipText = dataGridViewCustInfo.Columns["InfoLeadTime"].ToolTipText;

                        }
                    }
                }

                dataGridViewBranchInfo.Rows.Clear();
                //load branch info here

                DBUtils db = new DBUtils();
                db.OpenSQLConn();

                using (DbDataReader reader = db.GetBranchInfo(custID))
                {
                    if (reader.HasRows)
                    {
                        int cntr = 0;
                        while (reader.Read())
                        {
                            dataGridViewBranchInfo.Rows.Add();
                            dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBShortBranch"].Value = reader.GetString(reader.GetOrdinal("BranchDescShort")).Trim();
                            dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBBranchID"].Value = reader.GetInt32(reader.GetOrdinal("BranchID"));
                            dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBLongBranch"].Value = reader.GetString(reader.GetOrdinal("BranchDescLong")).Trim();


                            dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBShortBranch"].Tag = dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBShortBranch"].Value  ;
                            dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBLongBranch"].Tag = dataGridViewBranchInfo.Rows[cntr].Cells["dgvCBLongBranch"].Value;

                            cntr++;
                        }
                    }
                    reader.Close();
                }
                db.CloseSQLConn();
            }
            
        }
        private void ListViewCoilData_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {

            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                ListViewCoilData.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (ListViewCoilData.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    ListViewCoilData.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    ListViewCoilData.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            ListViewCoilData.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.ListViewCoilData.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              ListViewCoilData.Sorting);
        }

        private void ListViewCoilData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridViewReceiving_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);



            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;

            //columns with decimal places
            if (dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colThickness"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colWidth"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colLength"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colCarbon"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigit_KeyPress);
                }
            }
            if (dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colPieceCount"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colWeight"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
            if (dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colAlloy"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colFinish"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colDamage"].Index ||
                dataGridViewReceiving.CurrentCell.ColumnIndex == dataGridViewReceiving.Columns["colUnloader"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                    
                }
            }

        }

        private void ComboBoxCTL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I had to add this check because it was dropping in here on the wrong row.
            if (dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPVC"].Index)
            {
                if (PVCRowID != dataGridViewCTLOrderEntry.CurrentRow.Index)
                {
                    return;
                }
            }
            

            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {


                if (RecGridInfo.col == dataGridViewCTLOrderEntry.Columns["dgvCTLAdder"].Index)
                {
                    string Adder = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"]).Items[num].ToString();
                    if (Adder.Equals("Change"))
                    {
                        ShowAdderComboBox();
                    }
                    else
                    {
                        int AdderID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"]).Items[num]);
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"].Value = Convert.ToString(Adder);
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"].Value = AdderID.ToString();

                    }
                }
                if (RecGridInfo.col == dataGridViewCTLOrderEntry.Columns["dgvCTLPVC"].Index)
                {
                    int GroupID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPVCGroupID"]).Items[num]);
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPVCGroupID"].Value = GroupID.ToString();
                    if (GroupID > 0)
                    {
                        decimal cPrice = Convert.ToDecimal(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPVCPriceList"]).Items[num]);

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
                            dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLCurrPrice"].Value = cPrice;
                        }
                    }
                    

                }
                if (RecGridInfo.col == dataGridViewCTLOrderEntry.Columns["dgvCTLSkidType"].Index)
                {
                    int skidID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvSkidTypeID"]).Items[num]);
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvSkidTypeID"].Value = skidID;
                    if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value != null)
                    {
                        int tier = Convert.ToInt32(ListViewCoilData.Tag);
                        skidID = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvSkidTypeID"].Value);
                        decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                        decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                        decimal price = GetSkidPricing(tier, skidID, width, length);
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLCurrSkidPrice"].Value = price;
                    }
                    
                }
                if (RecGridInfo.col == dataGridViewCTLOrderEntry.Columns["dgvCTLBranch"].Index)
                {
                    int BranchID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLBranchID"]).Items[num]);
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLBranchID"].Value = BranchID;
                }


                
            }
        }

        private void ComboBoxSSSmPVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I had to add this check because it was dropping in here on the wrong row.
            if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dataGridViewSSSmSkid.Columns[dgvSSSmPVC.Index].Index)
            {
                if (PVCRowID != dataGridViewSSSmSkid.CurrentRow.Index)
                {
                    return;
                }
            }


            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {

                RecGridInfo.row = dataGridViewSSSmSkid.CurrentCell.RowIndex;
                
                if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dataGridViewSSSmSkid.Columns[dgvSSSmPVC.Index].Index)
                {
                    int GroupID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[RecGridInfo.row].Cells[dgvSSSmPVCGroupID.Index]).Items[num]);
                    dataGridViewSSSmSkid.Rows[RecGridInfo.row].Cells[dgvSSSmPVCGroupID.Index].Value = GroupID.ToString();
                    if (GroupID > 0)
                    {
                        decimal cPrice = Convert.ToDecimal(((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[RecGridInfo.row].Cells[dgvSSSmPVCPriceList.Index]).Items[num]);

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
                            dataGridViewSSSmSkid.Rows[RecGridInfo.row].Cells[dgvSSSmCurrPrice.Index].Value = cPrice;
                        }
                    }


                }
                


            }


            
        }

        private void ComboBoxSSSm_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dgvSSSmNewFinish.Index)
            {
                //from original
                System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

                string item = cb.Text;
                int num = cb.SelectedIndex;
                if (item != null)
                {


                    string FinishID = ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[dataGridViewSSSmSkid.CurrentCell.RowIndex].Cells[dgvSSSmFinishID.Index]).Items[num].ToString();
                    dataGridViewSSSmSkid.Rows[dataGridViewSSSmSkid.CurrentCell.RowIndex].Cells[dgvSSSmFinishID.Index].Value = Convert.ToInt32(FinishID);

                }
            }
            if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dgvSSSmBranch.Index)
            {
                //from original
                System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

                string item = cb.Text;
                int num = cb.SelectedIndex;
                if (item != null)
                {


                    string branchID = ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[dataGridViewSSSmSkid.CurrentCell.RowIndex].Cells[dgvSSSmBranchID.Index]).Items[num].ToString();
                    dataGridViewSSSmSkid.Rows[dataGridViewSSSmSkid.CurrentCell.RowIndex].Cells[dgvSSSmBranchID.Index].Value = Convert.ToInt32(branchID);

                }
            }

        }


        private void ComboBoxPVCRecCust_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;
            if (item != null)
            {

                //?????need to sync type column with item column to keep track of the correct PVCTypeID when I insert.
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecGroupID"].Value = ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecGroupID"]).Items[num];
            }
        }
        private void ComboBoxPVCRec_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;
            if (item != null)
            {

                //?????need to sync type column with item column to keep track of the correct PVCTypeID when I insert.
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecTypeID"].Value = ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecTypeID"]).Items[num];
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefWidth"].Value = ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefWidth"]).Items[num];
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefLength"].Value = ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefLength"]).Items[num];
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecItemWidth"].Value = dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefWidth"].Value;
                dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecItemLength"].Value = dataGridViewPVCRec.Rows[RecGridInfo.row].Cells["PVCRecDefLength"].Value;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;
            if (item != null)
            {


                if (RecGridInfo.col == dataGridViewReceiving.Columns["colAlloy"].Index)
                {
                    string AlloyID = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloyID"]).Items[num].ToString();
                    string density = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"]).Items[num].ToString();
                    string steelTypeID = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colSteelType"]).Items[num].ToString();
                    string steelDesc = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colRecSteelDesc"]).Items[num].ToString();
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colAlloyID"].Value = Convert.ToInt32(AlloyID);
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"].Value = Convert.ToDecimal(density);
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colSteelType"].Value = Convert.ToDecimal(steelTypeID);
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colRecSteelDesc"].Value = steelDesc;

                    try
                    {
                        LoadRecFinish(AlloyID);

                    }
                    catch (Exception se)
                    {
                        Console.Write(se);
                    }
                }

                if (RecGridInfo.col == dataGridViewReceiving.Columns["colFinish"].Index)
                {
                    if (num >= 0)
                    {


                        string FinishID = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"]).Items[num].ToString();
                        dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colFinishID"].Value = Convert.ToInt32(FinishID);
                    }
                }
                if (RecGridInfo.col == dataGridViewReceiving.Columns["colUnloader"].Index)
                {
                    if (num >= 0)
                    {


                        string FinishID = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWorkerID"]).Items[num].ToString();
                        dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWorkerID"].Value = Convert.ToInt32(FinishID);
                    }
                }
                if (RecGridInfo.col == dataGridViewReceiving.Columns["colDamage"].Index)
                {
                    if (num >= 0)
                    {


                        string damageDesc = ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"]).Items[num].ToString();
                        if (damageDesc.Equals("Change"))
                        {
                            ShowDamageComboBox();
                        }
                    }
                }
            }
        }

        
        private void ComboBoxClClSame_SelectedIndexChanged(object sender, EventArgs e)
        {


            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;

            //finish
            if (dataGridViewCLCLSame.CurrentCell.ColumnIndex == dataGridViewCLCLSame.Columns["colClClSameNewFinish"].Index)
            {
                if (item != null)
                {


                    string FinishID = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"]).Items[num].ToString();
                    dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"].Value = Convert.ToInt32(FinishID);

                    int weightCount = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSamePolWeights.Index]).Items.Count;
                    int weight = Convert.ToInt32(dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSamePolWeights.Index].Value);
                    for (int i = 0; i < weightCount; i++)
                    {

                        var wtf = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSamePolWeights.Index]).Items[i];
                        if (Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSamePolWeights.Index]).Items[i]) == weight)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSameCoilFinish.Index]).Items[i] = FinishID;
                        }
                    }

                }
            }

            if (dataGridViewCLCLSame.CurrentCell.ColumnIndex == colClClSamePolWeights.Index) //Desired Column
            {
                if (item != null)
                {

                    var wtf1 = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSameCoilFinish.Index]).Items[num];
                    int FinID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSameCoilFinish.Index]).Items[num]);

                    for (int i = 0; i < ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"]).Items.Count; i++)
                    {
                        var wtf = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"]).Items[i];
                        if (Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"]).Items[i]) == FinID)
                        {
                            dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells["colClClSameNewFinishID"].Value = FinID;
                            dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSameNewFinish.Index].Value = ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[ClClSameGridInfo.row].Cells[colClClSameNewFinish.Index]).Items[i];

                        }
                    }
                }
            }
        }
        
        private void ColumnDigitNoDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void ColumnDigit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ShowDamageComboBox()
        {
            int RowHeight1 = dataGridViewReceiving.Rows[RecGridInfo.row].Height;
            Rectangle CellRectangle1 = dataGridViewReceiving.GetCellDisplayRectangle(RecGridInfo.col, RecGridInfo.row, false);
            Rectangle CellRectangle2 = dataGridViewReceiving.GetCellDisplayRectangle(RecGridInfo.col, RecGridInfo.row, false);

            CellRectangle1.X += dataGridViewReceiving.Left;
            CellRectangle1.Y += dataGridViewReceiving.Top + RowHeight1;

            CellRectangle2.X += dataGridViewReceiving.Left;
            CellRectangle2.Y += dataGridViewReceiving.Top + RowHeight1 + checkedListBoxDamage.Height;


            //checkedListBoxDamage.Height = 1;
            //this.Top = 1;
            //this.Height = 1;

            if (CellRectangle1.Y + 10 > dataGridViewReceiving.Height - checkedListBoxDamage.Height - buttonDamageDone.Height - 2 - 30)
            {
                checkedListBoxDamage.Left = CellRectangle1.X - 180;
                checkedListBoxDamage.Top = (dataGridViewReceiving.Top + dataGridViewReceiving.Height) - (checkedListBoxDamage.Height + buttonDamageDone.Height + 2) - 30;
                checkedListBoxDamage.Width = dataGridViewReceiving.Columns[RecGridInfo.col].Width + 70;


                buttonDamageDone.Left = checkedListBoxDamage.Left;
                buttonDamageDone.Top = checkedListBoxDamage.Top + checkedListBoxDamage.Height + 1;
            }
            else
            {
                checkedListBoxDamage.Left = CellRectangle1.X - 180;
                checkedListBoxDamage.Top = CellRectangle1.Y + 10;
                checkedListBoxDamage.Width = dataGridViewReceiving.Columns[RecGridInfo.col].Width + 70;


                buttonDamageDone.Left = checkedListBoxDamage.Left;
                buttonDamageDone.Top = checkedListBoxDamage.Top + checkedListBoxDamage.Height + 1;
            }






            checkedListBoxDamage.Visible = true;
            checkedListBoxDamage.BringToFront();
            buttonDamageDone.Visible = true;

        }

        private void ShowAdderComboBox()
        {
            int RowHeight1 = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Height;
            Rectangle CellRectangle1 = dataGridViewCTLOrderEntry.GetCellDisplayRectangle(RecGridInfo.col, RecGridInfo.row, false);
            Rectangle CellRectangle2 = dataGridViewCTLOrderEntry.GetCellDisplayRectangle(RecGridInfo.col, RecGridInfo.row, false);

            CellRectangle1.X += dataGridViewCTLOrderEntry.Left;
            CellRectangle1.Y += dataGridViewCTLOrderEntry.Top + RowHeight1;

            CellRectangle2.X += dataGridViewCTLOrderEntry.Left;
            CellRectangle2.Y += dataGridViewCTLOrderEntry.Top + RowHeight1 + dataGridViewAdders.Height;



            if (CellRectangle1.Y + 10 > dataGridViewReceiving.Height - dataGridViewAdders.Height - buttonAdderDone.Height - 2 - 30)
            {
                dataGridViewAdders.Left = CellRectangle1.X - 180;
                dataGridViewAdders.Top = (dataGridViewReceiving.Top + dataGridViewCTLOrderEntry.Height) - (dataGridViewAdders.Height + buttonAdderDone.Height + 2) - 30;
               
               

                buttonAdderDone.Left = dataGridViewAdders.Left;
                buttonAdderDone.Top = dataGridViewAdders.Top + dataGridViewAdders.Height + 1;
            }
            else
            {
               
                dataGridViewAdders.Left = CellRectangle1.X - 180;
                dataGridViewAdders.Top = CellRectangle1.Y + 10;
                //dataGridViewAdders.Width = dataGridViewReceiving.Columns[RecGridInfo.col].Width + 170;

                buttonAdderDone.Left = dataGridViewAdders.Left;
                buttonAdderDone.Top = dataGridViewAdders.Top + dataGridViewAdders.Height + 1;
            }






            dataGridViewAdders.Visible = true;
            dataGridViewAdders.BringToFront();
            buttonAdderDone.Visible = true;
            buttonAdderDone.BringToFront();

        }
        private void DataGridViewReceiving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewReceiving.Columns["colDamage"].Index)
            {
                //check if "Change" clicked
                if (((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"]).Items.Count == 0)
                {
                    ShowDamageComboBox();
                }


            }
            if (e.ColumnIndex == dataGridViewReceiving.Columns["colAlloy"].Index)
            {
            }
        }



        private void AddReceivingRow()
        {
            RecGridInfo.row = dataGridViewReceiving.Rows.Count;
            dataGridViewReceiving.Rows.Add();

            int cnt = dataGridViewReceiving.Rows.Count;
            if (cnt > 1)
            {
                if (RecGridInfo.row > 0)
                {
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colUnloader"].Value = dataGridViewReceiving.Rows[RecGridInfo.row - 1].Cells["colUnloader"].Value;
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"].Value = dataGridViewReceiving.Rows[RecGridInfo.row - 1].Cells["colType"].Value;

                }
                else
                {
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colUnloader"].Value = dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colUnloader"].Value;
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"].Value = dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colType"].Value;
                }

            }
            dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colPieceCount"].Value = 1;
            try
            {
                LoadRecAlloy();

            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        }

        private void ButtonRecieveAddRow_Click(object sender, EventArgs e)
        {
            checkedListBoxDamage.Visible = false;
            buttonDamageDone.Visible = false;
            AddReceivingRow();
            LoadWorkers();
            LoadType();
            dataGridViewReceiving.CurrentCell = dataGridViewReceiving.Rows[dataGridViewReceiving.Rows.Count - 1].Cells["colPurchaseOrder"];
            dataGridViewReceiving.BeginEdit(true);
        }

        private void ButtonReceiveDeleteRow_Click(object sender, EventArgs e)
        {
            checkedListBoxDamage.Visible = false;
            buttonDamageDone.Visible = false;
            if (dataGridViewReceiving.SelectedRows.Count > 0 && dataGridViewReceiving.Rows.Count > 1)
            {

                dataGridViewReceiving.Rows.RemoveAt(dataGridViewReceiving.SelectedRows[0].Index);
            }

        }

        private void UpdateInfo(object sender, DataGridViewCellEventArgs e)
        {
            RecGridInfo.row = e.RowIndex;
            RecGridInfo.col = e.ColumnIndex;
            dataGridViewReceiving.CurrentCell = dataGridViewReceiving.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dataGridViewReceiving.BeginEdit(true);
        }








        private decimal MetFormula(decimal metFactor, decimal gauge, decimal length, decimal width, int piececount, int weight, bool bRoundOff = true)
        {

            decimal retVal = 0;





            if (gauge == 0)
            {
                if (length == 0 || width == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (piececount * length * width * metFactor)), 4);
                return retVal;
            }

            if (length == 0)
            {
                if (gauge == 0 || width == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * piececount * width * metFactor)), 3);
                return retVal;

            }

            if (width == 0)
            {
                if (gauge == 0 || length == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * length * piececount * metFactor)), 1);
                return retVal;

            }

            if (piececount == 0)
            {
                if (gauge == 0 || length == 0 || width == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * length * width * metFactor)), 0);
                return retVal;
            }

            if (weight == 0)
            {
                if (gauge == 0 || length == 0 || width == 0 || piececount == 0)
                {
                    return -1;
                }
                if (bRoundOff)
                {

                    retVal = Math.Round((piececount * gauge * length * width * metFactor), 0);
                }
                else
                {
                    retVal = piececount * gauge * length * width * metFactor;
                }
                return retVal;
            }
            //something went wrong.  Shouldn't get to this point.
            return -1;
        }
        
        private void DataGridViewReceiving_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].ColumnIndex)
            {
                if( Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Value) > .55m)
                {
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Style.ForeColor = Color.Black;
                }
            }

                   
            if (e.ColumnIndex == dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWeight"].ColumnIndex)
            {
                if (dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colPieceCount"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWidth"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWeight"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Value != null)
                {
                    if (dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colLength"].Value == null)
                    {


                        int piececnt = Convert.ToInt32(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colPieceCount"].Value);
                        decimal densityFactor = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"].Value);
                        decimal width = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWidth"].Value);
                        int weight = Convert.ToInt32(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWeight"].Value);
                        decimal thickness = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Value);



                        decimal length = MetFormula(densityFactor, thickness, 0, width, piececnt, weight);
                        dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colLength"].Value = length;
                    }
                }
            }

            if (e.ColumnIndex == dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colLength"].ColumnIndex)
            {
                if (dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colPieceCount"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWidth"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colLength"].Value != null &&
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Value != null)
                {

                    int piececnt = Convert.ToInt32(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colPieceCount"].Value);
                    decimal densityFactor = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDensityFactor"].Value);
                    decimal width = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWidth"].Value);
                    decimal length = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colLength"].Value);
                    decimal thickness = Convert.ToDecimal(dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colThickness"].Value);



                    int weight = Convert.ToInt32(MetFormula(densityFactor, thickness, length, width, piececnt, 0));
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colWeight"].Value = weight;
                }
            }
        }

        private void ButtonDamageDone_Click(object sender, EventArgs e)
        {
            //clear current stuff
            dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"].Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"]).Items.Clear();
            dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamageID"].Value = null;
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamageID"]).Items.Clear();

            string damageDesc = "";
            string damageID = "";

            //load selected items
            for (int i = 0; i < checkedListBoxDamage.CheckedItems.Count; i++)
            {
                damageID = ((MyListBoxItem)checkedListBoxDamage.CheckedItems[i]).Value.ToString();
                damageDesc = ((MyListBoxItem)checkedListBoxDamage.CheckedItems[i]).Text;


                ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"]).Items.Add(damageDesc);
                ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamageID"]).Items.Add(damageID);
                if (i == 0)
                {
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"].Value = damageDesc;
                    dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamageID"].Value = damageID;
                }
            }
            //add change option in dropdown
            ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[RecGridInfo.row].Cells["colDamage"]).Items.Add("Change");


            //hide box and button
            buttonDamageDone.Visible = false;
            checkedListBoxDamage.Visible = false;

            //clear out previous selections.
            foreach (int j in checkedListBoxDamage.CheckedIndices)
            {
                checkedListBoxDamage.SetItemCheckState(j, CheckState.Unchecked);
            }
        }

        private bool CheckReceivingInfoCorrect()
        {
            for (int i = 0; i < dataGridViewReceiving.Rows.Count; i++)
            {
                for (int c = 0; c < dataGridViewReceiving.Rows[i].Cells.Count; c++)
                {
                    if (dataGridViewReceiving.Rows[i].Cells[c].Value == null && dataGridViewReceiving.Columns[c].Visible == true)
                    {
                        if (!dataGridViewReceiving.Columns[c].Name.Equals("colDamage"))
                        {
                            MessageBox.Show(dataGridViewReceiving.Columns[c].Name.Substring(3) + " cannot be null");
                            dataGridViewReceiving.CurrentCell = dataGridViewReceiving.Rows[i].Cells[c];
                            dataGridViewReceiving.BeginEdit(false);

                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool VerifyCustomer()
        {
            if (MessageBox.Show(this, "Are you sure " + TreeViewCustomer.SelectedNode.Text + " is correct", "Verify Customer", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return false;
            }
            return true;
        }

        private void ButtonRecSubmit_Click(object sender, EventArgs e)
        {
            if (VerifyCustomer())
            {


                if (CheckReceivingInfoCorrect())
                {

                    DBUtils db = new DBUtils();
                    db.OpenSQLConn();
                    SqlTransaction trans = db.StartTrans();

                    
                    SqlTransaction tran = SQLConn.conn.BeginTransaction();
                    try
                    {


                        for (int i = 0; i < dataGridViewReceiving.Rows.Count; i++)
                        {
                            if (i == 0)
                            {


                                PrintLabels pl = new PrintLabels();
                                RecHdrInfo rhInfo = new RecHdrInfo();
                                CoilInfo cCoilInfo = new CoilInfo();
                                RecDtlInfo rdInfo = new RecDtlInfo();

                                for (i = 0; i < dataGridViewReceiving.Rows.Count; i++)
                                {

                                    if (i == 0)
                                    {
                                        rhInfo.container = textBoxContainer.Text;
                                        rhInfo.custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
                                        rhInfo.purchaseOrder = dataGridViewReceiving.Rows[i].Cells["colPurchaseOrder"].Value.ToString();
                                        rhInfo.receiveDate = dateTimePicker1.Value;
                                        if (checkBoxPreReceiving.Checked)
                                        {
                                            rhInfo.status = -3;
                                        }
                                        else
                                        {
                                            rhInfo.status = 1;
                                        }
                                        rhInfo.workerID = Convert.ToInt32(dataGridViewReceiving.Rows[i].Cells["colWorkerID"].Value);
                                        rhInfo.receiveID = AddReceivingHdr(rhInfo, tran);

                                    }


                                    cCoilInfo.alloyID = Convert.ToInt32(dataGridViewReceiving.Rows[i].Cells["colAlloyID"].Value);
                                    cCoilInfo.carbon = Convert.ToDecimal(dataGridViewReceiving.Rows[i].Cells["colCarbon"].Value);
                                    cCoilInfo.coilCount = Convert.ToInt32(dataGridViewReceiving.Rows[i].Cells["colPieceCount"].Value);
                                    if (checkBoxPreReceiving.Checked)
                                    {
                                        cCoilInfo.coilStatus = -3;
                                    }
                                    else
                                    {
                                        if (dataGridViewReceiving.Rows[i].Cells["colType"].Value.Equals( "Coil"))
                                        {
                                            cCoilInfo.coilStatus = 1;
                                        }
                                        else
                                        {
                                            cCoilInfo.coilStatus = -2;
                                        }
                                        
                                    }

                                    cCoilInfo.coilTagSuffix = "";
                                    cCoilInfo.countryOfOrigin = dataGridViewReceiving.Rows[i].Cells["colOriginCountry"].Value.ToString();
                                    cCoilInfo.customerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
                                    cCoilInfo.finishID = Convert.ToInt32(dataGridViewReceiving.Rows[i].Cells["colFinishID"].Value);
                                    cCoilInfo.heat = dataGridViewReceiving.Rows[i].Cells["colHeat"].Value.ToString();
                                    cCoilInfo.length = Convert.ToDecimal(dataGridViewReceiving.Rows[i].Cells["colLength"].Value);
                                    cCoilInfo.location = dataGridViewReceiving.Rows[i].Cells["colLocation"].Value.ToString();
                                    cCoilInfo.millCoilNum = dataGridViewReceiving.Rows[i].Cells["colMillNumber"].Value.ToString();
                                    cCoilInfo.receiveID = rhInfo.receiveID;
                                    cCoilInfo.thickness = Convert.ToDecimal(dataGridViewReceiving.Rows[i].Cells["colThickness"].Value);
                                    cCoilInfo.vendor = dataGridViewReceiving.Rows[i].Cells["colVendor"].Value.ToString();
                                    cCoilInfo.weight = Convert.ToInt32(dataGridViewReceiving.Rows[i].Cells["colWeight"].Value);
                                    cCoilInfo.width = Convert.ToDecimal(dataGridViewReceiving.Rows[i].Cells["colWidth"].Value);
                                    cCoilInfo.coilTagID = AddCoil(cCoilInfo, tran);

                                    if (cCoilInfo.coilStatus == -2)
                                    {
                                        SkidData sd = new SkidData
                                        {
                                            skidID = cCoilInfo.coilTagID,
                                            coilTagSuffix = cCoilInfo.coilTagSuffix,
                                            letter = "A",
                                            location = cCoilInfo.location,
                                            alloyID = cCoilInfo.alloyID,
                                            finishID = cCoilInfo.finishID,
                                            customerID = cCoilInfo.customerID,
                                            branchID = 0,
                                            orderID = 0,
                                            sequenceNumber = 0,
                                            sheetWeight = Convert.ToDecimal(Convert.ToDecimal(cCoilInfo.weight) / Convert.ToDecimal(cCoilInfo.coilCount)),
                                            length = cCoilInfo.length,
                                            width = cCoilInfo.width
                                        };

                                        
                                            
                                            
                                        sd.diagnol1 = sd.diagnol2 = 0;
                                        sd.mic1 = sd.mic2 = sd.mic3 = 0;
                                        sd.pieceCount = sd.orderedPieceCount = cCoilInfo.coilCount;
                                        sd.pvcID = -1;
                                        sd.paper = -1;
                                        sd.comments = "Receive ID " + cCoilInfo.receiveID;
                                        sd.status = 1;
                                        sd.skidTypeID = -1;
                                        sd.skidPrice = -1;
                                        sd.notPrime = 0;

                                        pl.SkidLabelInfo.SkidID = sd.skidID;
                                        pl.SkidLabelInfo.CoilTagSuffix = sd.coilTagSuffix;
                                        pl.SkidLabelInfo.SkidLetter = sd.letter;
                                        pl.SkidLabelInfo.Location = sd.location;
                                        pl.SkidLabelInfo.Alloy = dataGridViewReceiving.Rows[i].Cells["colAlloy"].Value.ToString().Trim() + " " + dataGridViewReceiving.Rows[i].Cells["colFinish"].Value.ToString().Trim();
                                        pl.SkidLabelInfo.CustName = TreeViewCustomer.SelectedNode.Text;
                                        pl.SkidLabelInfo.OrderID = sd.orderID;
                                        pl.SkidLabelInfo.TheoWeight = cCoilInfo.weight;
                                        pl.SkidLabelInfo.Length = sd.length;
                                        pl.SkidLabelInfo.PO = rhInfo.purchaseOrder;
                                        pl.SkidLabelInfo.Carbon = cCoilInfo.carbon;
                                        pl.SkidLabelInfo.Comments = sd.comments;
                                        pl.SkidLabelInfo.COO = cCoilInfo.countryOfOrigin;
                                        pl.SkidLabelInfo.Gauge = cCoilInfo.thickness;
                                        pl.SkidLabelInfo.Heat = cCoilInfo.heat;
                                        pl.SkidLabelInfo.Mill = cCoilInfo.millCoilNum;
                                        pl.SkidLabelInfo.Pieces = sd.pieceCount;
                                        pl.SkidLabelInfo.RecDate = rhInfo.receiveDate.ToShortDateString();
                                        pl.SkidLabelInfo.Type = sd.skidTypeID;
                                        pl.SkidLabelInfo.Vendor = cCoilInfo.vendor;
                                        pl.SkidLabelInfo.Width = cCoilInfo.width;
                                        pl.SkidLabelInfo.SkidSteelDesc = dataGridViewReceiving.Rows[i].Cells["colRecSteelDesc"].Value.ToString().Trim();

                                        //*******************need to test************


                                        //AddSkid()
                                        db.InsertSkidDataRecord(sd, trans);

                                    }
                                    else
                                    {
                                        pl.CoilLabelInfo.Alloy = dataGridViewReceiving.Rows[i].Cells["colAlloy"].Value.ToString().Trim() + " " + dataGridViewReceiving.Rows[i].Cells["colFinish"].Value.ToString().Trim();
                                        pl.CoilLabelInfo.CoilCount = cCoilInfo.coilCount;
                                        pl.CoilLabelInfo.Heat = cCoilInfo.heat;
                                        pl.CoilLabelInfo.Length = cCoilInfo.length;
                                        pl.CoilLabelInfo.Location = cCoilInfo.location;
                                        pl.CoilLabelInfo.MillNum = cCoilInfo.millCoilNum;
                                        pl.CoilLabelInfo.RecDate = rhInfo.receiveDate.ToShortDateString();
                                        pl.CoilLabelInfo.TagID = cCoilInfo.coilTagID.ToString().Trim() + cCoilInfo.coilTagSuffix.Trim();
                                        pl.CoilLabelInfo.Thickness = cCoilInfo.thickness;
                                        pl.CoilLabelInfo.Type = cCoilInfo.type;
                                        pl.CoilLabelInfo.Weight = cCoilInfo.weight;
                                        pl.CoilLabelInfo.Width = cCoilInfo.width;
                                        pl.CoilLabelInfo.Vendor = cCoilInfo.vendor;
                                        pl.CoilLabelInfo.CustName = TreeViewCustomer.SelectedNode.Text;
                                        pl.CoilLabelInfo.PO = rhInfo.purchaseOrder;
                                        pl.CoilLabelInfo.RecID = rhInfo.receiveID;
                                        pl.CoilLabelInfo.Carbon = cCoilInfo.carbon;
                                        pl.CoilLabelInfo.COO = cCoilInfo.countryOfOrigin;
                                        pl.CoilLabelInfo.SkidSteelDesc = dataGridViewReceiving.Rows[i].Cells["colRecSteelDesc"].Value.ToString().Trim();
                                        



                                    }

                                    rdInfo.alloyID = cCoilInfo.alloyID;
                                    rdInfo.coilTagID = cCoilInfo.coilTagID;
                                    rdInfo.finishID = cCoilInfo.finishID;
                                    rdInfo.heat = cCoilInfo.heat;
                                    rdInfo.length = cCoilInfo.length;
                                    rdInfo.millNum = cCoilInfo.millCoilNum;
                                    rdInfo.pieceCount = cCoilInfo.coilCount;
                                    rdInfo.purchaseOrder = dataGridViewReceiving.Rows[i].Cells["colPurchaseOrder"].Value.ToString();
                                    rdInfo.receiveID = rhInfo.receiveID;
                                    rdInfo.skidLetter = cCoilInfo.coilTagSuffix;
                                    rdInfo.thickness = cCoilInfo.thickness;
                                    rdInfo.type = 1;
                                    if (cCoilInfo.coilStatus == -2)
                                    {
                                        rdInfo.type = 0;
                                        rdInfo.skidLetter = "A";
                                    }
                                    
                                    rdInfo.weight = cCoilInfo.weight;
                                    rdInfo.width = cCoilInfo.width;
                                    

                                    AddReceivingDtl(rdInfo, tran);

                                    if (dataGridViewReceiving.Rows[i].Cells["colDamageID"].Value != null)
                                    {
                                        for (int dc = 0; dc < ((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[i].Cells["colDamageID"]).Items.Count; dc++)

                                        {
                                            int damageID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewReceiving.Rows[i].Cells["colDamageID"]).Items[dc]);
                                            AddDamage(cCoilInfo.coilTagID, damageID, tran);
                                        }
                                    }
                                    if (cbRecPrintLabel.Checked)
                                    {
                                        if (cCoilInfo.coilStatus == -2)
                                        {
                                            pl.SkidLabel(LabelPrinters.tagPrinter);
                                        }
                                        else
                                        {
                                            pl.CoilLabel(LabelPrinters.tagPrinter);
                                        }
                                    }
                                    
                                }

                                ReportGeneration rg = new ReportGeneration();

                                
                               
                                

                                for (i = dataGridViewReceiving.Rows.Count; i > 0; i--)
                                {
                                    dataGridViewReceiving.Rows.RemoveAt(i - 1);
                                }

                                tran.Commit();
                                trans.Commit();

                                rg.setReportDrive(MachineDefaults.ReportDrive);

                                rg.Receiving(rhInfo.receiveID);

                                MessageBox.Show("Receiving ID " + rhInfo.receiveID + " has been created.");

                                AddReceivingRow();
                                LoadType();
                                LoadWorkers();
                                LoadDamage();
                                DisplayCoilData(TreeViewCustomer.SelectedNode.Tag.ToString());
                                DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());
                                dataGridViewReceiving.Rows[0].Cells["colType"].Selected = true;

                                dataGridViewReceiving.BeginEdit(true);
                                ((System.Windows.Forms.ComboBox)dataGridViewReceiving.EditingControl).DroppedDown = true;
                            }
                        }
                    }
                    catch (Exception se)
                    {
                        try
                        {
                            tran.Rollback();
                            trans.Rollback();
                        }
                        catch (Exception ex2)
                        { 
                        }

                        MessageBox.Show("Error: " + se);
                        Console.WriteLine(se.StackTrace);
                    }
                }
            }
        }


        private void TreeViewCustomer_Enter(object sender, EventArgs e)
        {
            if (TreeViewCustomer.SelectedNode != null)
            {
                TreeViewCustomer.SelectedNode.BackColor = Color.Empty;
                TreeViewCustomer.SelectedNode.ForeColor = Color.Empty;
            }
        }

        private void TreeViewCustomer_Leave(object sender, EventArgs e)
        {
            if (TreeViewCustomer.SelectedNode != null)
            {
                TreeViewCustomer.SelectedNode.BackColor = SystemColors.Highlight;
                TreeViewCustomer.SelectedNode.ForeColor = Color.White;
            }
        }


        
        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            //tabControlPlantLocations.Invalidate();
        }

        private void TabControlPlantLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPlantLocations.SelectedTab.Text.Equals("Settings"))
            {

                tabControlSettings.BringToFront();
                LoadMachineLeadTimes();
                LoadPrinters();
                LoadClClSameDefaultFinish();
                LoadSSSmDefaultFinish();
                LoadClClDiffDefaultSettings();
                LoadDrives();
               
                LoadScrapUnit();
                textBoxDefaultsCTLThickDiscrepency.Text = CTLInfo.Discrepency.ToString("G29");
                labelAboutConnString.Text = "ICMS 2.0";

            }
            else
            {
                try
                {
                    tabControlICMS.SelectedTab = tabPageCoil;
                    tabControlProcess.Visible = false;
                    tabControlMachines.Visible = false;
                    tabControlICMS.BringToFront();
                    SetDefaultPlant(tabControlPlantLocations.SelectedTab.Text);
                    TreeViewCustomer.Nodes.Clear();
                    ListViewCoilData.Items.Clear();
                    LoadCustomers(checkBoxInactiveCustomers.Checked);
                    if (TreeViewCustomer.Nodes.Count > 0)
                    {
                        DisplayCoilData(TreeViewCustomer.Nodes[0].Tag.ToString());
                        TreeViewCustomer.SelectedNode = TreeViewCustomer.Nodes[0];
                        TreeViewCustomer.Refresh();
                    }
                    
                    //SetTabHeader(tabControlPlantLocations.SelectedTab, Color.Yellow);

                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }
            }
        }

        private void TabControlSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlSettings.SelectedTab.Text.Equals("Lead Times"))
            {
                LoadMachineLeadTimes();
            }
            if (tabControlSettings.SelectedTab.Text.Equals("Order Flow"))
            {
                LoadOrderFlow();
            }
            if (tabControlSettings.SelectedTab.Text.Equals("Skid Pricing"))
            {

                LoadSkidPricing();
            }
            if (tabControlSettings.SelectedTab.Text.Equals("Proc Pricing"))
            {

                LoadProcPricing();
            }

            if (tabControlSettings.SelectedTab.Text.Equals("Steel Types"))
            {

                LoadSteelTypes();
            }

            if (tabControlSettings.SelectedTab.Text.Equals("Steel Prices"))
            {

                LoadSteelPrices();
            }
            
        }

        private void LoadSteelPrices()
        {
            listViewSPPrice.Items.Clear();
            int cntr = 0;

            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            using (DbDataReader reader = db.GetAlloyData())
            {

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {



                        ListViewItem lv = new ListViewItem();

                        lv.SubItems[0].Text = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        lv.SubItems[0].Tag = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                        lv.SubItems.Add(reader.GetDecimal(reader.GetOrdinal("Price")).ToString("C"));
                        

                        listViewSPPrice.Items.Add(lv);


                        cntr++;
                    }

                    
                }
                reader.Close();
            }
            db.CloseSQLConn();
            
            if (cntr > 0)
            {
                listViewSPPrice.Items[0].Selected = true;
                listViewSPPrice.Select();
            }
        }


        private void LoadSteelTypes()
        {
            listBoxSteelTypes.Items.Clear();
            int cntr = 0;

            DBUtils db = new DBUtils();

            db.OpenSQLConn();



            listBoxSteelTypes.DisplayMember = "Text";
            listBoxSteelTypes.ValueMember = "Value";

            using (DbDataReader reader = db.GetSteelTypes())
            {

                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {

                       
                        string steelDesc = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                        int SteelTypeID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));
                        listBoxSteelTypes.Items.Add(new { Text = steelDesc, Value = SteelTypeID });


                        cntr++;
                    }
                    
                }
                reader.Close();
            }
            db.CloseSQLConn();
            if (cntr > 0)
            {
                listBoxSteelTypes.SelectedIndex = 0;
            }
        }

        private void LoadProcPricing(int defTier = -1)
        {
            try
            {
                //get Available Tiers
                if (defTier == -1)
                {

                    

                    //get tiers
                    
                    GetAvailableProcTiers(defTier);

                    //get steel types

                    DBUtils db = new DBUtils();
                    db.OpenSQLConn();


                    using (DbDataReader reader = db.GetSteelTypes())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                comboBoxProcSteelTypeDesc.Items.Add(reader.GetString(reader.GetOrdinal("SteelDesc")));
                                comboBoxProcSteelTypeID.Items.Add(reader.GetInt32(reader.GetOrdinal("SteelTypeID")));
                            }
                        }
                        reader.Close();
                    }

                    //get machines

                    using (DbDataReader reader = db.GetMachineNames())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                comboBoxProcMachineDesc.Items.Add(reader.GetString(reader.GetOrdinal("machineName")));
                                comboBoxProcMachineID.Items.Add(reader.GetInt32(reader.GetOrdinal("machineID")));
                            }
                        }
                        reader.Close();
                    }

                    db.CloseSQLConn();
                }
                else
                {
                    comboBoxTierLevel.SelectedIndex = comboBoxTierLevel.SelectedIndex;
                }


                //get Skid types

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }

        }
        private void LoadSkidPricing(int defTier = -1)
        {
            try
            {
                //get Available Tiers
                if (defTier == -1)
                {
                    GetAvailableTiers(defTier);
                    LoadSkidTypes();
                }
                else
                {
                    comboBoxTierLevel.SelectedIndex = comboBoxTierLevel.SelectedIndex;
                }
                

                //get Skid types
                
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
            
        }


        private void LoadSkidTypes()
        {
            bool ok = false;

            comboBoxSkidDescription.Items.Clear();
            comboBoxSkidTypeID.Items.Clear();

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            using (DbDataReader reader = db.GetSkidTypeData())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ok = true;
                        comboBoxSkidDescription.Items.Add(reader.GetString(reader.GetOrdinal("SkidDescription")).Trim());
                        comboBoxSkidTypeID.Items.Add(reader.GetInt32(reader.GetOrdinal("SkidTypeID")));
                    }
                     
                }
                reader.Close();
            }
            if (ok)
            {
                comboBoxSkidDescription.SelectedIndex = 0;
            }
            db.CloseSQLConn();
        }

        private void GetAvailableProcTiers(int defTier = -1)
        {
            comboBoxProcTierLevel.Items.Clear();
            int tierLevel = -1;
            int prevTier = -1;
            using (DbDataReader reader = GetAllProcPricing(0, true))
            {
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        if (tierLevel == -1)
                        {
                            tierLevel = reader.GetInt32(reader.GetOrdinal("TierLevel"));
                            prevTier = tierLevel;

                            comboBoxProcTierLevel.Items.Add(tierLevel);
                            comboBoxProcTierLevel.Tag = tierLevel;
                        }
                        else
                        {
                            tierLevel = reader.GetInt32(reader.GetOrdinal("TierLevel"));
                            if (prevTier != tierLevel)
                            {
                                comboBoxProcTierLevel.Items.Add(tierLevel);
                                prevTier = tierLevel;
                                //save max tier in Tag field
                                if (Convert.ToInt32(comboBoxProcTierLevel.Tag) < tierLevel)
                                {
                                    comboBoxProcTierLevel.Tag = tierLevel;
                                }
                            }
                        }

                    }

                }

            }
            if (tierLevel != -1 || defTier == -1)
            {


                comboBoxProcTierLevel.Text = comboBoxProcTierLevel.Items[0].ToString();


            }
            //all Tiers to be added
            comboBoxProcTierLevel.Items.Add("Add Tier");
        }
        private void GetAvailableTiers(int defTier = -1)
        {
            comboBoxTierLevel.Items.Clear();
            int tierLevel = -1;
            int prevTier = -1;
            using (DbDataReader reader = GetAllSkidPricing(0, true))
            {
                if (reader.HasRows)
                {
                    

                    while (reader.Read())
                    {
                        if (tierLevel == -1)
                        {
                            tierLevel = reader.GetInt32(reader.GetOrdinal("TierLevel"));
                            prevTier = tierLevel;

                            comboBoxTierLevel.Items.Add(tierLevel);
                            comboBoxTierLevel.Tag = tierLevel;
                        }
                        else
                        {
                            tierLevel = reader.GetInt32(reader.GetOrdinal("TierLevel"));
                            if (prevTier != tierLevel)
                            {
                                comboBoxTierLevel.Items.Add(tierLevel);
                                prevTier = tierLevel;
                                //save max tier in Tag field
                                if (Convert.ToInt32(comboBoxTierLevel.Tag) < tierLevel)
                                {
                                    comboBoxTierLevel.Tag = tierLevel;
                                }
                            }
                        }

                    }
                    
                }

            }
            if (tierLevel != -1 || defTier == -1)
            {
                
                
                 comboBoxTierLevel.Text = comboBoxTierLevel.Items[0].ToString();
                
                
            }
            //all Tiers to be added
            comboBoxTierLevel.Items.Add("Add Tier");
        }
        private void DataGridViewLeadTimes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateLeadTime(Convert.ToInt32(dataGridViewLeadTimes.Rows[e.RowIndex].Cells["colMachine"].Tag), Convert.ToInt32(dataGridViewLeadTimes.Rows[e.RowIndex].Cells["colLeadTime"].Value));
                DateTime dt = DateTime.Now.AddBusinessDays(Convert.ToInt32(dataGridViewLeadTimes.Rows[e.RowIndex].Cells["colLeadTime"].Value));


                dataGridViewLeadTimes.Rows[e.RowIndex].Cells["colDate"].Value = dt.DayOfWeek + " " + dt.ToShortDateString();


            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        }

        private void DataGridViewLeadTimes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);




            if (dataGridViewLeadTimes.CurrentCell.ColumnIndex == dataGridViewLeadTimes.Columns["colLeadTime"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
        }

        private void LoadPrinters()
        {
            int cntr = 0;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBoxTagLabelPrinter.Items.Add(printer.ToString());
                if (LabelPrinters.tagPrinter.Equals(printer.ToString()))
                {
                    comboBoxTagLabelPrinter.SelectedIndex = cntr;
                }
                comboBoxShippingLabelPrinter.Items.Add(printer.ToString());
                if (LabelPrinters.shippingPrinter.Equals(printer.ToString()))
                {
                    comboBoxShippingLabelPrinter.SelectedIndex = cntr;
                }
                cntr++;
            }
        }

        private void LoadClClDiffDefaultSettings()
        {
            comboBoxClClDiffTrim.Items.Clear();
            int CLCLID = 7;//default procid
            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            using (DbDataReader reader = db.GetCLCLProcID())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CLCLID = reader.GetInt32(reader.GetOrdinal("processID"));
                    }
                }
                reader.Close();
            }



            using (DbDataReader reader = db.GetMachineInfo(CLCLID))
            {
                int cntr = 0;
                if (reader.HasRows)
                {
                    comboBoxClClDiffTrim.DisplayMember = "Text";
                    comboBoxClClDiffTrim.ValueMember = "Value";
                    while (reader.Read())
                    {
                        string machineName = reader.GetString(reader.GetOrdinal("machineName")).Trim();
                        int machineID = reader.GetInt32(reader.GetOrdinal("machineID"));

                        comboBoxClClDiffTrim.Items.Add(
                           new { Text = machineName, Value = machineID });
                        cntr++;
                    }

                }
            }
            if (comboBoxClClDiffTrim.Items.Count > 0)
            {
                comboBoxClClDiffTrim.SelectedIndex = 0;
            }

        }

        private void LoadScrapUnit()
        {
            if (MachineDefaults.scrapUnit.Equals("IN"))
            {
                radioButtonScrapUnitInches.Checked = true;
            
            }
            else
            {
                radioButtonScrapUnitLBS.Checked = true;
            }
        }

        
        private void LoadClClSameDefaultFinish()
        {


            LoadDefaultFinish(comboBoxDefaultClClSameFinish, MachineDefaults.ClClSameDefaultFinish);

        }
        private void LoadSSSmDefaultFinish()
        {

            LoadDefaultFinish(comboBoxDefaultSSSmFinish, MachineDefaults.SSSmDefaultFinish);


        }

        private void LoadDefaultFinish(System.Windows.Forms.ComboBox cb,string defaultFin)
        {
            cb.Items.Clear();

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            //pass in 0 for steeltypeid to get all stainless finishes
            using (DbDataReader reader = db.GetFinish("-1", -1, 0))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {
                        string defFin = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        cb.Items.Add(defFin);
                        if (defFin.Equals(defaultFin))
                        {
                            cb.Text = defFin;
                        }
                        cntr++;
                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();

        }

        private void ComboBoxTagLabelPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTagPrinter(comboBoxTagLabelPrinter.Items[comboBoxTagLabelPrinter.SelectedIndex].ToString());
        }

        private void ComboBoxShippingLabelPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShippingLabelPrinter.SelectedIndex >= 0)
            {
                SetShippingPrinter(comboBoxShippingLabelPrinter.Items[comboBoxShippingLabelPrinter.SelectedIndex].ToString());
            }

        }

        private void TabControlProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlProcess.TabPages.Count > 0)
                LoadMachines(Convert.ToInt32(tabControlProcess.SelectedTab.Tag));

        }


        
        private void OrderCloning()
        {
            if (panelCoilCoilSame.Visible)
            {
                listViewClClSame.Items.Clear();
                foreach (ListViewItem item in ListViewCoilData.Items)
                {
                    listViewClClSame.Items.Add((ListViewItem)item.Clone());
                }
                listViewClClSame.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewClClSame.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            if (panelClClDiff.Visible)
            {
                listViewClClDiff.Items.Clear();
                foreach (ListViewItem item in ListViewCoilData.Items)
                {
                    listViewClClDiff.Items.Add((ListViewItem)item.Clone());
                }
                listViewClClDiff.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewClClDiff.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            if (panelCoilSheetSame.Visible)
            {
                listViewCTLCoilList.Items.Clear();
                foreach (ListViewItem item in ListViewCoilData.Items)
                {
                    listViewCTLCoilList.Items.Add((ListViewItem)item.Clone());
                }
                listViewCTLCoilList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewCTLCoilList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            if (panelSheetSheetSame.Visible)
            {
                listViewSSSmSkidData.Items.Clear();
                foreach (ListViewItem item in listViewSkidData.Items)
                {
                    listViewSSSmSkidData.Items.Add((ListViewItem)item.Clone());
                }
                listViewSSSmSkidData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewSSSmSkidData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            if (panelSheetSheetDiff.Visible)
            {
                listViewSSD.Items.Clear();
                foreach (ListViewItem item in listViewSkidData.Items)
                {
                    listViewSSD.Items.Add((ListViewItem)item.Clone());
                }
                listViewSSD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewSSD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }


        }
        private void PanelSheetSheetSame_VisibleChanged(object sender, EventArgs e)
        {

            //start sheet polishing process
            buttonSSSmStartOrder.Visible = true;
            buttonSSSmAddOrder.Visible = false;

            listViewSSSmSkidData.BringToFront();
            if (panelSheetSheetSame.Visible.Equals(true))
            {
                OrderCloning();
                AddOrderSSSInfo();
            }
        }
        private void PanelCoilCoilSame_VisibleChanged(object sender, EventArgs e)
        {
            buttonCLCLSameStartOrder.Visible = true;
            buttonClClSameAddOrder.Visible = false;

            listViewClClSame.BringToFront();
            if (panelCoilCoilSame.Visible.Equals(true))
            {
                OrderCloning();
                AddOrderCCSInfo();
            }
        }

        private void PanelClClDiff_VisibleChanged(object sender, EventArgs e)
        {
            listViewClClDiff.BringToFront();
            buttonClClDiffStartOrder.Visible = true;
            buttonClClDiffAddOrder.Visible = false;
            OrderCloning();
            AddOrderClClDiffInfo();
        }

        private void ButtonClClDiffStartOrder_Click(object sender, EventArgs e)
        {
            if (!CheckMachine())
            {
                return;
            }
            dataGridViewClClDiff.Rows.Clear();
            ClClDiffGridInfo.colCnt = dataGridViewClClDiff.ColumnCount;
            dataGridViewClClDiff.CellClick -=
            new DataGridViewCellEventHandler(DataGridViewClClDiff_CellClick);
            dataGridViewClClDiff.BringToFront();
            if (checkBoxClClDiffModify.Checked)
            {
                if (comboBoxClClDiffModify.Text.Equals(""))
                {
                    checkBoxClClDiffModify.Checked = false;
                }
            }


            // pricing$-
            ProcPricingInfo procInfo = new ProcPricingInfo
            {
                MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag),
                TierLevel = Convert.ToInt32(ListViewCoilData.Tag)
            };

            int cntr = 0;
            for (int i = 0; i < listViewClClDiff.CheckedItems.Count; i++)
            {
                dataGridViewClClDiff.Rows.Add();
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"].Value = listViewClClDiff.CheckedItems[i].SubItems[0].Text;//tag
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"].Tag = listViewClClDiff.CheckedItems[i].SubItems[0].Tag;//tagsuffix
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffThickness"].Value = listViewClClDiff.CheckedItems[i].SubItems[3].Text;//thickness
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidth"].Value = listViewClClDiff.CheckedItems[i].SubItems[4].Text;//width
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffOrigWeight"].Value = listViewClClDiff.CheckedItems[i].SubItems[6].Text;//Weight
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffNewWeight"].Value = listViewClClDiff.CheckedItems[i].SubItems[6].Text;//Weight
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffAlloy"].Value = listViewClClDiff.CheckedItems[i].SubItems[2].Text;//alloy
                decimal trimAmount = GetSlitTrim(Convert.ToDecimal(dataGridViewClClDiff.Rows[i].Cells["colClClDiffThickness"].Value));
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffTrimAmount"].Value = trimAmount;
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value = listViewClClDiff.CheckedItems[i].SubItems[4].Text;//width
                dataGridViewClClDiff.Rows[i].Cells["colClClDiffCutCount"].Value = 0;
                if (cntr == 0)
                {
                   
                    
                    procInfo.SteelTypeID = Convert.ToInt32(listViewClClDiff.CheckedItems[i].SubItems[4].Tag);
                    procInfo.fromWidth = Convert.ToDecimal(listViewClClDiff.CheckedItems[i].SubItems[4].Text);
                    procInfo.fromThickness = Convert.ToDecimal(listViewClClDiff.CheckedItems[i].SubItems[3].Text);


                }
                cntr++;

            }
            if (cntr > 0)
            {
                dataGridViewClClDiff.BringToFront();
                buttonClClDiffStartOrder.Visible = false;
                buttonClClDiffAddOrder.Visible = true;
                buttonClClDiffReset.Visible = true;
                buttonClClDiffResetCuts.Visible = true;
                textBoxClClDiffPrice.Text = GetProcPricing(procInfo).ToString();
            }
            else
            {

                MessageBox.Show("Nothing selected");
                ResetClClDiff();

            }

            dataGridViewClClDiff.CellClick +=
            new DataGridViewCellEventHandler(DataGridViewClClDiff_CellClick);

        }
        private int DeleteBreakRows(int parentRow, int FlagID)
        {
            int removedCount = 0;
            for (int i = parentRow + 1; i < dataGridViewClClDiff.Rows.Count; i++)
            {
                if (dataGridViewClClDiff.Rows[i].Cells["colClClDiffThickness"].Tag == null)
                {
                    //not sure if I want to do something here yet.
                }
                else
                {


                    if ((int)dataGridViewClClDiff.Rows[i].Cells["colClClDiffThickness"].Tag == FlagID)
                    {
                        dataGridViewClClDiff.Rows.RemoveAt(i);
                        removedCount++;
                        i--;
                    }
                    else
                    {
                        if (dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"].Value.ToString().Equals(dataGridViewClClDiff.Rows[parentRow].Cells["colClClDiffTagID"].Value.ToString()))
                        {
                            if ((int)dataGridViewClClDiff.Rows[i].Cells["colClClDiffOrigWeight"].Tag == FlagID)
                            {
                                int cnt = DeleteBreakRows(i, (int)dataGridViewClClDiff.Rows[i].Cells["colClClDiffThickness"].Tag);
                                dataGridViewClClDiff.Rows.RemoveAt(i);
                                removedCount++;
                                i--;
                            }
                            else
                            {
                                i = dataGridViewClClDiff.Rows.Count + 1;
                            }
                        }
                        else
                        {
                            i = dataGridViewClClDiff.Rows.Count + 1;
                        }

                    }
                }
            }
            dataGridViewClClDiff.Rows[parentRow].Cells["colClClDiffNewWeight"].Value = dataGridViewClClDiff.Rows[parentRow].Cells["colClClDiffOrigWeight"].Value;
            dataGridViewClClDiff.Rows[parentRow].Cells["colClClDiffThickNess"].Tag = dataGridViewClClDiff.Rows[parentRow].Cells["colClClDiffOrigWeight"].Tag;
            return removedCount;

        }



        public DataGridViewRow CloneWithValues(DataGridViewRow row, int rowtoClone = -1)
        {

            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();

            for (Int32 index = 0; index < row.Cells.Count; index++)
            {

                clonedRow.Cells[index].Value = row.Cells[index].Value;
                clonedRow.Cells[index].Tag = row.Cells[index].Tag;
                if (index < ClClDiffGridInfo.colCnt - 1)
                {
                    clonedRow.Cells[index].Style = new DataGridViewCellStyle { ForeColor = Color.Blue, BackColor = Color.LightGray };

                }
            }


            return clonedRow;
        }
        private void DataGridViewClClDiff_CellClick(object sender, EventArgs e)
        {


        }
        private void ButtonClClSameStartOrder_Click(object sender, EventArgs e)
        {
            if (!CheckMachine())
            {
                return;
            }
            if (checkBoxClClSameModify.Checked)
            {
                if (comboBoxClClSameModify.Text.Equals(""))
                {
                    checkBoxClClSameModify.Checked = false;
                }
            }
            int cntr = 0;

            // need to add pricing$-
            ProcPricingInfo procInfo = new ProcPricingInfo
            {
                MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag),
                TierLevel = Convert.ToInt32(ListViewCoilData.Tag)
            };

            for (int i = 0; i < listViewClClSame.CheckedItems.Count; i++)
            {
                dataGridViewCLCLSame.Rows.Add();
                dataGridViewCLCLSame.Rows[i].Cells[0].Value = listViewClClSame.CheckedItems[i].SubItems[0].Text;//tag
                dataGridViewCLCLSame.Rows[i].Cells[0].Tag = listViewClClSame.CheckedItems[i].SubItems[0].Tag;//tagsuffix
                dataGridViewCLCLSame.Rows[i].Cells[1].Value = listViewClClSame.CheckedItems[i].SubItems[3].Text;//thickness
                dataGridViewCLCLSame.Rows[i].Cells[2].Value = listViewClClSame.CheckedItems[i].SubItems[4].Text;//width
                AlloyInfo ai = GetAlloyInfo(Convert.ToInt32(listViewClClSame.CheckedItems[i].SubItems[2].Tag));

                dataGridViewCLCLSame.Rows[i].Cells[3].Value = ai.alloy;
                dataGridViewCLCLSame.Rows[i].Cells[3].Tag = ai.alloyID;
                LoadClClSameFinish(listViewClClSame.CheckedItems[i].SubItems[2].Tag.ToString(), Convert.ToInt32(listViewClClSame.CheckedItems[i].SubItems[3].Tag), i);

                dataGridViewCLCLSame.Rows[i].Cells["colClClSameOrigLBS"].Value = listViewClClSame.CheckedItems[i].SubItems[6].Text;//weight
                dataGridViewCLCLSame.Rows[i].Cells["colClClSamePolishLBS"].Value = listViewClClSame.CheckedItems[i].SubItems[6].Text;//weight
                dataGridViewCLCLSame.Rows[i].Cells["colClClSameCoilCnt"].Value = 1;

                int polID = Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells[colClClSameNewFinishID.Index].Value);

                ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[i].Cells["colClClSamePolWeights"]).Items.Add(listViewClClSame.CheckedItems[i].SubItems[6].Text);
                ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[i].Cells[colClClSameCoilFinish.Index]).Items.Add(polID);


                dataGridViewCLCLSame.Rows[i].Cells["colClClSamePolWeights"].Value = listViewClClSame.CheckedItems[i].SubItems[6].Text;//weight


                ((DataGridViewCheckBoxCell)dataGridViewCLCLSame.Rows[i].Cells["colClClSamePaper"]).Value = true;

                if (cntr == 0)
                {

                    //probably not right
                    procInfo.SteelTypeID = Convert.ToInt32(listViewClClSame.CheckedItems[i].SubItems[4].Tag);
                    procInfo.fromWidth = Convert.ToDecimal(listViewClClSame.CheckedItems[i].SubItems[4].Text);
                    procInfo.fromThickness = Convert.ToDecimal(listViewClClSame.CheckedItems[i].SubItems[3].Text);

                }
                cntr++;

            }

            
            

            if (cntr > 0)
            {
                dataGridViewCLCLSame.BringToFront();
                buttonCLCLSameStartOrder.Visible = false;
                buttonClClSameAddOrder.Visible = true;
                textBoxClClSamePrice.Text = GetProcPricing(procInfo).ToString();
            }
            else
            {

                MessageBox.Show("Nothing selected");

            }

        }

        private void ResetClClDiff()
        {

            dataGridViewClClDiff.Rows.Clear();

            if (dataGridViewClClDiff.Columns.Count > ClClDiffGridInfo.colCnt)
            {
                for (int i = dataGridViewClClDiff.Columns.Count; i > ClClDiffGridInfo.colCnt; i--)
                {
                    dataGridViewClClDiff.Columns.RemoveAt(i - 1);
                }
            }
            for (int i = listViewClClDiff.CheckedItems.Count - 1; i >= 0; i--)
            {
                listViewClClDiff.CheckedItems[i].Checked = false;
            }
            listViewClClDiff.BringToFront();
            buttonClClDiffStartOrder.Visible = true;
            buttonClClDiffAddOrder.Visible = false;
            buttonClClDiffResetCuts.Visible = false;
            buttonClClDiffReset.Visible = false;

            Count.CoilCut = 0;
        }
        private void ButtonClClDiffReset_Click(object sender, EventArgs e)
        {
            ResetClClDiff();
        }

        private void ButtonClClSameReset_Click(object sender, EventArgs e)
        {
            dataGridViewCLCLSame.Rows.Clear();


            for (int i = listViewClClSame.CheckedItems.Count - 1; i >= 0; i--)
            {
                listViewClClSame.CheckedItems[i].Checked = false;
            }
            listViewClClSame.BringToFront();
            buttonCLCLSameStartOrder.Visible = true;
            buttonClClSameAddOrder.Visible = false;
        }

        private void ComboBoxDefaultClClSameFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetClClSameDefaultFinish(comboBoxDefaultClClSameFinish.Text.Trim());
            comboBoxDefaultClClSameFinish.Text = comboBoxDefaultClClSameFinish.Text.Trim();


        }
        private void ComboBoxDefaultSSSmFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSSSmDefaultFinish(comboBoxDefaultSSSmFinish.Text.Trim());
            comboBoxDefaultSSSmFinish.Text = comboBoxDefaultSSSmFinish.Text.Trim();
        }

        
        private void DataGridViewCLCLSame_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].ColumnIndex)
            {
                int PolLBS = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Value);
                int newFinID = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameNewFinishID.Index].Value);

                int origFinID = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameOrigFinish.Index].Tag) ;

                if (PolLBS > Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameOrigLBS"].Value))
                {
                    //roll back weight.
                    MessageBox.Show("You cannot polish more than original weight!");
                    dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Value = dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Tag;
                    return;
                }
                dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = null;
                ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Clear();
                ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilFinish.Index]).Items.Clear();

                //should this be 2 coils?
                if (PolLBS != Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameOrigLBS.Index].Value)) 
                {
                    if (MessageBox.Show("Should this be split into 2 coils?", "How to Divide", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Value = 2;
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Tag = "SPLIT";
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(PolLBS);
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilFinish.Index]).Items.Add(newFinID);
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = PolLBS;
                        int remLBS = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameOrigLBS"].Value) - PolLBS;
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(remLBS);
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilFinish.Index]).Items.Add(origFinID);

                    }
                    else
                    {
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Value = 1;
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(PolLBS);
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = PolLBS;

                    }
                }
                
                
            }
            if (e.ColumnIndex == dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].ColumnIndex)
            {

                int cnt = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Value);
                int startweight = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Value);
                if (dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Tag == null)
                {
                    dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Tag = "";
                }

                if (cnt > 1 && !dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Tag.ToString().Equals("SPLIT"))
                {
                    
                    if (MessageBox.Show("Split evenly?", "How to Divide", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = null;
                        if (((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Count > 0)
                        {
                            
                            ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Clear();
                            ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilFinish.Index]).Items.Clear();

                        }
                        int newFinID = Convert.ToInt32(dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameNewFinishID.Index].Value);
                        double weights = Math.Round(Convert.ToDouble(startweight / cnt), 0);
                        for (int i = 1; i <= cnt; i++)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(weights);
                            ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells[colClClSameCoilFinish.Index]).Items.Add(newFinID);
                            
                        }
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = weights;
                    }
                    else
                    {
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = null;
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Clear();

                        String output = "";
                        int weightleft = startweight;
                        for (int i = 1; i <= cnt - 1; i++)
                        {

                            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

                            result = InputBox.Show(
                                "You have " + weightleft + " pounds left",
                                "Please enter weight for coil " + i,
                                "Value",
                                out output);

                            if (result != System.Windows.Forms.DialogResult.OK)
                            {


                                dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Value = 1;
                                ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(startweight);
                                dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = startweight;
                                return;
                            }
                            else
                            {
                                int w = Convert.ToInt32(output);
                                if (w > weightleft)
                                {
                                    //get new value
                                    MessageBox.Show("You entered more weight than you had.  Try again!");
                                    i--;
                                }
                                else
                                {
                                    //add to list
                                    ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(w);
                                    weightleft -= w;
                                }
                            }

                        }
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(weightleft);
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = weightleft;

                    }
                }
                else
                {

                    if (!dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Tag.ToString().Equals("SPLIT"))
                    {
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = null;
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Clear();
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSameCoilCnt"].Value = 1;
                        ((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"]).Items.Add(startweight);
                        dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolWeights"].Value = startweight;
                    }
                    
                }
            }
        }

        private void DataGridViewCLCLSame_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].ColumnIndex)
            {
                //store weight in case we need to roll back
                dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Tag = dataGridViewCLCLSame.Rows[e.RowIndex].Cells["colClClSamePolishLbs"].Value;
            }
            ClClSameGridInfo.row = e.RowIndex;
            ClClSameGridInfo.col = e.ColumnIndex;

        }

        private void DataGridViewCLCLSame_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);


            if (dataGridViewCLCLSame.CurrentCell.ColumnIndex == dataGridViewCLCLSame.Columns["colClClSamePolishLBS"].Index ||
                dataGridViewCLCLSame.CurrentCell.ColumnIndex == dataGridViewCLCLSame.Columns["colClClSameCoilCnt"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
            if (dataGridViewCLCLSame.CurrentCell.ColumnIndex == dataGridViewCLCLSame.Columns["colClClSameNewFinish"].Index ||
                dataGridViewCLCLSame.CurrentCell.ColumnIndex == colClClSamePolWeights.Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxClClSame_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxClClSame_SelectedIndexChanged);
                }
            }

            
        }

        private void ButtonClClSameAddOrder_Click(object sender, EventArgs e)
        {
            //check values
            if (textBoxClClSamePrice.Text == null || textBoxClClSamePrice.Text.Equals(""))
            {
                MessageBox.Show("Must have a Price!");
                textBoxClClSamePrice.Focus();
                return;
            }

            if (textBoxClClSamePO.Text == null || textBoxClClSamePO.Text.Equals(""))
            {
                MessageBox.Show("Must have a Purchase Order!");
                textBoxClClSamePO.Focus();
                return;
            }
            bool modifyOrder = false;

            if (buttonClClSameAddOrder.Text == "Modify Order")
            {
                modifyOrder = true;

            }
            else
            {
                modifyOrder = false;
            }

            //I have to get leadtimes before starting the sql transaction.
            int nextleadTime = 0;
            int leadTime = GetMachineLeadTimes(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));
            if (checkBoxClClSameMultiStep.Checked)
            {
                nextleadTime = GetMachineLeadTimes((comboBoxClClSameToMachine.SelectedItem as dynamic).Value);
            }

            //start database transaction so we can rollback if something fails along the way.
            SqlTransaction tran = SQLConn.conn.BeginTransaction();
            try
            {


                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    masterOrderID = -1,
                    CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                    CustomerPO = textBoxClClSamePO.Text.Trim(),
                    OrderDate = DateTime.Now.Date,
                    PromiseDate = dateTimePickerClClSamePromise.Value.Date,
                    Status = 1,
                    Comments = richTextBoxClClSameComments.Text.Trim(),
                    runSheetComments = richTextBoxClClSameComments.Text
                };
                if (checkBoxClClSameScrap.Checked)
                {
                    ordHdrInfo.ScrapCredit = 1;
                }
                else
                {
                    ordHdrInfo.ScrapCredit = 0;

                }
                ordHdrInfo.CalculationType = 1;
                ordHdrInfo.ShipComments = "";
                ordHdrInfo.MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                ordHdrInfo.ProcPrice = Convert.ToDecimal(textBoxClClSamePrice.Text);
                ordHdrInfo.Posted = 0;
                ordHdrInfo.BreakIn = 0;
                ordHdrInfo.RunSheetOrder = DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                ordHdrInfo.MixHeats = 0;


                if (modifyOrder)
                {
                    ordHdrInfo.OrderID = Convert.ToInt32(comboBoxClClSameModify.Text);
                    UpdateOrderHdr(ordHdrInfo, tran);
                }
                else
                {
                    ordHdrInfo.OrderID = AddOrderHdr(ordHdrInfo, tran);


                    //sequence will have to be worked out as I develop this ??????
                    int sequence = 0;
                    ordHdrInfo.masterOrderID = AddMasterOrder(ordHdrInfo.OrderID, sequence, tran);

                    if (checkBoxClClSameMultiStep.Checked)
                    {
                        //?????order ID is changing.
                        //add the next order hdr
                        leadTime += nextleadTime;
                        DateTime dt = DateTime.Now.AddBusinessDays(leadTime).Date;
                        ordHdrInfo.PromiseDate = dt.Date;
                        ordHdrInfo.MachineID = (comboBoxClClSameToMachine.SelectedItem as dynamic).Value;
                        int NextOrderID = AddOrderHdr(ordHdrInfo, tran);
                        //increment master order sequence
                        sequence++;
                        ordHdrInfo.masterOrderID = AddMasterOrder(NextOrderID, sequence, tran, ordHdrInfo.masterOrderID);
                    }
                }

                ClClSameHdrInfo polHdr = new ClClSameHdrInfo();
                ClClSameDtlInfo polDtl = new ClClSameDtlInfo();
                if (modifyOrder)
                {
                    polHdr.orderID = Convert.ToInt32(comboBoxClClSameModify.Text);
                }
                else
                {
                    polHdr.orderID = ordHdrInfo.OrderID;
                }


                for (int i = 0; i < dataGridViewCLCLSame.Rows.Count; i++)
                {

                    TagParser tp = new TagParser();
                    tp.TagToBeParsed = dataGridViewCLCLSame.Rows[i].Cells["colClClSameCoilTagID"].Value.ToString() ;


                    tp.ParseTag();

                    polHdr.coilTagID = tp.TagID;
                    polHdr.coilTagSuffix = tp.CoilTagSuffix;



                  


                    polHdr.previousFinishID = Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells["colClClSameOrigFinish"].Tag);


                    polHdr.newFinishID = Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells["colClClSameNewFinishID"].Value);
                    polHdr.origWeight = Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells["colClClSameOrigLBS"].Value);
                    polHdr.PolishWeight = Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells["colClClSamePolishLBS"].Value);
                    if (Convert.ToBoolean(dataGridViewCLCLSame.Rows[i].Cells["colClClSamePaper"].Value) == true)
                    {
                        polHdr.paper = 1;
                    }
                    else
                    {
                        polHdr.paper = 0;
                    }

                    if (modifyOrder && i == 0)
                    {
                        DeleteCoilPolishHdr(polHdr.orderID, tran);
                    }

                    AddCoilPolishHdr(polHdr, tran);

                    //need to look at colClClSameCoilCnt
                    //here 7/7/23
                    //started with 1 for tagSuffix
                    for (int j = 1; j <= Convert.ToInt32(dataGridViewCLCLSame.Rows[i].Cells[colClClSameCoilCnt.Index].Value); j++)
                    {
                        polDtl.orderID = polHdr.orderID;
                        polDtl.coilTagID = polHdr.coilTagID;
                        polDtl.coilTagSuffix = polHdr.coilTagSuffix;
                        polDtl.newCoilTagSuffix = polDtl.coilTagSuffix + "." + j;
                        polDtl.Weight = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[i].Cells["colClClSamePolWeights"]).Items[j - 1]);
                        polDtl.FinishID = Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCLCLSame.Rows[i].Cells[colClClSameCoilFinish.Index]).Items[j - 1]);

                        if (modifyOrder && j == 1 && i == 0)
                        {
                            //because we are deleting the whole order only go on first record.
                            DeleteCoilPolishDtl(polDtl.orderID, tran);
                        }

                        AddCoilPolishDtl(polDtl, tran);


                    }
                }
                tran.Commit();
                if (modifyOrder)
                {
                    MessageBox.Show("Order " + ordHdrInfo.OrderID + " has been modified!");
                    StartOrderProcess(TreeViewCustomer.SelectedNode.Text, false);
                }
                else
                {
                    if (checkBoxClClSameMultiStep.Checked)
                    {
                        MessageBox.Show("Master Order " + ordHdrInfo.masterOrderID + " and Coil Polish Order " + ordHdrInfo.OrderID + " created.");

                    }
                    else
                    {
                        MessageBox.Show("Coil Polish Order " + ordHdrInfo.OrderID + " created.");

                    }
                    StartOrderProcess(TreeViewCustomer.SelectedNode.Text, false);
                }
                //is the master order going to drive everything????

            }
            catch (Exception se)
            {
                tran.Rollback();
                Console.WriteLine("Error: " + se);
                MessageBox.Show("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }


        }


        private void TextBoxClClSamePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ComboBoxOrdFlowFromMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOrdFlowToMachine.Items.Clear();
            comboBoxOrdFlowToMachine.ValueMember = "Value";
            comboBoxOrdFlowToMachine.DisplayMember = "Text";

            for (int i = 0; i < comboBoxOrdFlowFromMachine.Items.Count; i++)
            {

                if (comboBoxOrdFlowFromMachine.SelectedIndex != i)
                {
                    comboBoxOrdFlowToMachine.Items.Add(
                        new
                        {
                            (comboBoxOrdFlowFromMachine.Items[i] as dynamic).Text,
                            (comboBoxOrdFlowFromMachine.Items[i] as dynamic).Value
                        });
                }
            }
            comboBoxOrdFlowToMachine.SelectedIndex = 0;
        }

        private void ButtonOrdFlowAddConnection_Click(object sender, EventArgs e)
        {
            int fromID = (comboBoxOrdFlowFromMachine.SelectedItem as dynamic).Value;
            int toID = (comboBoxOrdFlowToMachine.SelectedItem as dynamic).Value;
            AddMachineConnection(fromID, toID);
            LoadOrderFlow();
        }

        private void ButtonOrdFlowDelConnections_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView.CheckedIndexCollection checkedItems = listViewOrderFlowMachines.CheckedIndices;

            while (checkedItems.Count > 0)
            {
                int connId = Convert.ToInt32(listViewOrderFlowMachines.Items[checkedItems[0]].Tag);
                DeleteMachineConnection(connId);
                listViewOrderFlowMachines.Items.RemoveAt(checkedItems[0]);

            }
            LoadOrderFlow();
        }

        private void CheckBoxClClSameMultiStep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClClSameMultiStep.Checked)
            {
                labelClClSameMultiToMachine.Visible = true;
                comboBoxClClSameToMachine.Visible = true;
                LoadClClNextMachine(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));

            }
            else
            {
                labelClClSameMultiToMachine.Visible = false;
                comboBoxClClSameToMachine.Visible = false;
            }
        }



        private void CheckBoxClClSameModify_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClClSameModify.Checked)
            {
                LoadClClSameOrders(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));
                comboBoxClClSameModify.Visible = true;
                buttonClClSameAddOrder.Text = "Modify Order";
                checkBoxClClSameMultiStep.Visible = false;
                buttonClClSameDelete.Visible = true;
            }
            else
            {
                comboBoxClClSameModify.Visible = false;
                buttonClClSameAddOrder.Text = "Add Order";
                checkBoxClClSameMultiStep.Visible = true;
                buttonClClSameDelete.Visible = false;

            }
        }

        private void ComboBoxClClSameModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear the rows
            dataGridViewCLCLSame.Rows.Clear();
            buttonClClSameReset.PerformClick();
            // load order from database
            ClClSameHdrInfo hInfo = new ClClSameHdrInfo();
            ClClSameDtlInfo dInfo = new ClClSameDtlInfo();
            int orderID = Convert.ToInt32(comboBoxClClSameModify.SelectedItem);
            using (DbDataReader reader = LoadClClSameOrderHdr(orderID))
            {
                if (reader.HasRows)
                {

                    int cntr = 0;
                    while (reader.Read())
                    {
                        if (cntr == 0)
                        {
                            //load info
                            richTextBoxClClSameComments.Text = reader.GetString(reader.GetOrdinal("Comments")).Trim();
                            dateTimePickerClClSamePromise.Value = reader.GetDateTime(reader.GetOrdinal("PromiseDate"));
                            checkBoxClClSameScrap.Checked = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal("ScrapCredit")));
                            textBoxClClSamePrice.Text = reader.GetDecimal(reader.GetOrdinal("ProcPrice")).ToString();
                            textBoxClClSamePO.Text = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();

                        }

                        int coilid = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string coilSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                        for (int i = 0; i < listViewClClSame.Items.Count; i++)
                        {
                            if (listViewClClSame.Items[i].SubItems[0].Text.Equals(Convert.ToString(coilid + coilSuffix).Trim()))
                            {
                                listViewClClSame.Items[i].Checked = true;
                            }
                        }

                    }
                }
            }
        }

        private void TreeViewCustomer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            if (previousCustSelectedNode != null)
            {
                previousCustSelectedNode.BackColor = TreeViewCustomer.BackColor;
                previousCustSelectedNode.ForeColor = TreeViewCustomer.ForeColor;
            }

            ListViewCoilData.Items.Clear();
            listViewSkidData.Items.Clear();
            UpdateInventoryLabel();
            try
            {
                DisplayCoilData(e.Node.Tag.ToString());
                DisplaySkidData(e.Node.Tag.ToString());
                if (tabControlICMS.SelectedTab.Text.Equals("Orders"))
                {
                    StartOrderProcess(e.Node.Text.ToString());
                    
                    
                    int MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                    int leadtime = GetMachineLeadTimes(MachineID);
                    SetLeadTime(leadtime);




                }
                if (tabControlICMS.SelectedTab.Text.Equals("Cust Info"))
                {
                    LoadCustomerInfo();
                }
                if (tabControlICMS.SelectedTab.Text.Equals("Shipping"))
                {
                    LoadShippingInfo();
                }
                
            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
            Cursor.Current = Cursors.Default;
        }

        private void ButtonClClSameDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction tran = SQLConn.conn.BeginTransaction();

            try
            {


                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    OrderID = Convert.ToInt32(comboBoxClClSameModify.Text),
                    Status = -99
                };
                UpdateOrderHdr(ordHdrInfo, tran, true);
                DeleteCoilPolishHdr(ordHdrInfo.OrderID, tran);
                DeleteCoilPolishDtl(ordHdrInfo.OrderID, tran);

                tran.Commit();
                MessageBox.Show("Order " + ordHdrInfo.OrderID + " deleted!");
                StartOrderProcess(TreeViewCustomer.SelectedNode.Text, false);
            }
            catch (Exception se)
            {
                tran.Rollback();
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        }





        private void CheckBoxClClDiffModify_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClClDiffModify.Checked)
            {
                LoadClClDiffOrders(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));
                comboBoxClClDiffModify.Visible = true;
                buttonClClDiffModifyDelte.Visible = true;
                checkBoxClClDiffMultStep.Visible = false;
                buttonClClDiffAddOrder.Text = "Modify Order";
            }
            else
            {
                comboBoxClClDiffModify.Visible = false;
                buttonClClDiffModifyDelte.Visible = false;
                checkBoxClClDiffMultStep.Visible = true;
                buttonClClDiffAddOrder.Text = "Add Order";
                buttonClClDiffReset.PerformClick();
            }



        }

        private void CheckBoxClClDiffMultStep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClClDiffMultStep.Checked)
            {
                labelClClDiffMultSendTo.Visible = true;
                comboBoxClClDiffSendTo.Visible = true;
                LoadClClDiffNextMachine(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));

            }
            else
            {
                labelClClDiffMultSendTo.Visible = false;
                comboBoxClClDiffSendTo.Visible = false;
            }
        }

        private void DataGridViewClClDiff_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ClClDiffGridInfo.row = e.RowIndex;
            ClClDiffGridInfo.col = e.ColumnIndex;

            Count.widthLeft = Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidthLeft"].Value);

            dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidthLeft"].Tag = dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidthLeft"].Value;
            if (e.ColumnIndex > dataGridViewClClDiff.Columns["colClClDiffAddCutButton"].Index)
            {
                dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }

        }

        private void DataGridViewClClDiff_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.ColumnIndex > ClClDiffGridInfo.colCnt)
            {
                //var wtf = dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) < 0)
                {
                    MessageBox.Show("Must be greater than zero!");
                    dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                    return;
                }
                decimal widthTot = 0;
                //only allowed to edit cut.
                int cutCnt = 0;
                for (int i = ClClDiffGridInfo.colCnt; i <= dataGridViewClClDiff.ColumnCount - 1; i++)
                {
                    if (dataGridViewClClDiff.Rows[e.RowIndex].Cells[i].Value != null && !dataGridViewClClDiff.Rows[e.RowIndex].Cells[i].Value.Equals(""))
                    {
                        widthTot += Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells[i].Value);

                        cutCnt++;

                    }
                }


                if (Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidth"].Value) - widthTot >= 0)
                {
                    decimal trim = Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffTrimAmount"].Value);
                    if (Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidth"].Value) - widthTot - trim >= 0)
                    {
                        Count.widthLeft = Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidth"].Value) - widthTot;
                        dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidthLeft"].Value = Count.widthLeft;
                        dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffCutCount"].Value = cutCnt;
                    }
                    else
                    {
                        if (MessageBox.Show("Exceed recommended Trim?", "Exceeding Trim", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Count.widthLeft = Convert.ToDecimal(dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidth"].Value) - widthTot;
                            dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffWidthLeft"].Value = Count.widthLeft;
                            dataGridViewClClDiff.Rows[e.RowIndex].Cells["colClClDiffCutCount"].Value = cutCnt;
                        }
                        else
                        {
                            dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;

                        }


                    }

                }
                else
                {

                    MessageBox.Show("you aint got that much");
                    dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridViewClClDiff.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;

                }
            }
        }

        private void ButtonClClDiffResetCuts_Click(object sender, EventArgs e)
        {

            int cutCnt = 0;
            if (dataGridViewClClDiff.ColumnCount > ClClDiffGridInfo.colCnt)
            {
                for (int i = ClClDiffGridInfo.colCnt; i <= dataGridViewClClDiff.ColumnCount; i++)
                {
                    if (dataGridViewClClDiff.Rows[ClClDiffGridInfo.row].Cells[i - 1].Value != null && i != ClClDiffGridInfo.colCnt)
                    {

                        dataGridViewClClDiff.Rows[ClClDiffGridInfo.row].Cells[i - 1].Value = null;
                        cutCnt++;

                    }
                }

                for (int j = dataGridViewClClDiff.ColumnCount; j > ClClDiffGridInfo.colCnt; j--)
                {
                    bool delcol = true;
                    for (int k = 0; k < dataGridViewClClDiff.RowCount - 1; k++)
                    {
                        if (dataGridViewClClDiff.Rows[k].Cells[j - 1].Value != null)
                        {
                            delcol = false;
                            j = 8;
                            k = dataGridViewClClDiff.RowCount;
                        }

                    }
                    if (delcol)
                    {
                        Count.CoilCut--;
                        dataGridViewClClDiff.Columns.RemoveAt(j - 1);
                    }
                }
                dataGridViewClClDiff.Rows[ClClDiffGridInfo.row].Cells["colClClDiffWidthLeft"].Value = dataGridViewClClDiff.Rows[ClClDiffGridInfo.row].Cells["colClClDiffWidth"].Value;
                dataGridViewClClDiff.Rows[ClClDiffGridInfo.row].Cells["colClClDiffCutCount"].Value = 0;
            }



        }

        private void TextBoxClClDiffTrimFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }




            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void TextBoxClClDiffTrimTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }




            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxClClDiffTrimValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxClClDiffTrimValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }




            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        private void ButtonClClDiffAddTrim_Click(object sender, EventArgs e)
        {
            //SlitterTrimTable
            AddSlitterTrim((comboBoxClClDiffTrim.SelectedItem as dynamic).Value);
            listViewClClDiffTrim.Items.Clear();
            LoadSlitTrimInfo();



        }

        private void TabPageDefaultMachines_Click(object sender, EventArgs e)
        {

        }
        private void LoadSlitTrimInfo()
        {
            listViewClClDiffTrim.Items.Clear();

            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            using (DbDataReader reader = db.GetSlitterTrimInfo((comboBoxClClDiffTrim.SelectedItem as dynamic).Value))
            {
                if (reader.HasRows)
                {

                    int cntr = 0;
                    while (reader.Read())
                    {
                        decimal fromTrim = reader.GetDecimal(reader.GetOrdinal("fromTrim"));
                        decimal toTrim = reader.GetDecimal(reader.GetOrdinal("toTrim"));
                        decimal TrimAmount = reader.GetDecimal(reader.GetOrdinal("TrimAmount"));

                        ListViewItem lv = new ListViewItem
                        {
                            Text = fromTrim.ToString()
                        };
                        lv.SubItems.Add(toTrim.ToString());
                        lv.SubItems.Add(TrimAmount.ToString());
                        listViewClClDiffTrim.Items.Add(lv);
                        cntr++;

                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }
        private void ComboBoxClClDiffTrim_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadSlitTrimInfo();
        }

        private void ButtonClClDiffTrimRemove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView.CheckedIndexCollection checkedItems = listViewClClDiffTrim.CheckedIndices;
            int machineID = Convert.ToInt32((comboBoxClClDiffTrim.SelectedItem as dynamic).Value);

            while (checkedItems.Count > 0)
            {
                decimal fromTrim = Convert.ToDecimal(listViewClClDiffTrim.Items[checkedItems[0]].Text);
                decimal toTrim = Convert.ToDecimal(listViewClClDiffTrim.Items[checkedItems[0]].SubItems[1].Text);
                DeleteSlitTrim(machineID, fromTrim, toTrim);
                listViewClClDiffTrim.Items.RemoveAt(checkedItems[0]);

            }
            LoadSlitTrimInfo();
        }

        private void ButtonClClDiffAddOrder_Click(object sender, EventArgs e)
        {
            //make sure every row has something done.
            for (int i = 0; i < dataGridViewClClDiff.RowCount; i++)
            {
                //if this isn't a coil break lets make sure it is something else
                if (dataGridViewClClDiff.Rows[i].Cells["colClClDiffBreak"].Value == null || !(bool)dataGridViewClClDiff.Rows[i].Cells["colClClDiffBreak"].Value)
                {
                    //see if this is a subset of break coil
                    if (dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"].Style.BackColor != Color.LightGray)
                    {
                        bool blank = true;
                        for (int j = ClClDiffGridInfo.colCnt; j < dataGridViewClClDiff.ColumnCount; j++)
                        {
                            if (dataGridViewClClDiff.Rows[i].Cells[j].Value != null)
                            {
                                j = dataGridViewClClDiff.ColumnCount;
                                blank = false;
                            }
                        }
                        if (blank)
                        {
                            MessageBox.Show("Tag " + dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"].Value + " does not have any actions against it.");
                            dataGridViewClClDiff.CurrentCell = dataGridViewClClDiff.Rows[i].Cells["colClClDiffTagID"];
                            dataGridViewClClDiff.BeginEdit(true);
                            return;
                        }
                    }

                }
            }
            if (textBoxClClDiffPrice.Text == null || textBoxClClDiffPrice.Text.Equals(""))
            {
                MessageBox.Show("Must have a Price!");
                textBoxClClDiffPrice.Focus();
                return;
            }

            if (textBoxClClDiffPO.Text == null || textBoxClClDiffPO.Text.Equals(""))
            {
                MessageBox.Show("Must have a Purchase Order!");
                textBoxClClDiffPO.Focus();
                return;
            }

            //all clear load up database info
            int nextleadTime = 0;
            int leadTime = GetMachineLeadTimes(Convert.ToInt32(tabControlMachines.SelectedTab.Tag));
            if (checkBoxClClDiffMultStep.Checked)
            {
                nextleadTime = GetMachineLeadTimes((comboBoxClClDiffSendTo.SelectedItem as dynamic).Value);
            }
            bool modifyOrder = false;

            if (buttonClClDiffAddOrder.Text == "Modify Order")
            {
                modifyOrder = true;

            }
            else
            {
                modifyOrder = false;
            }
            //start transaction
            SqlTransaction tran = SQLConn.conn.BeginTransaction();
            try
            {




                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    masterOrderID = -1,
                    CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                    CustomerPO = textBoxClClDiffPO.Text.Trim(),
                    OrderDate = DateTime.Now.Date,
                    PromiseDate = dateTimePickerClClDiffPromiseDate.Value.Date,
                    Status = 1,
                    Comments = richTextBoxClClDiffComments.Text.Trim()
                };
                if (checkBoxClClDiffScrapCredit.Checked)
                {
                    ordHdrInfo.ScrapCredit = 1;
                }
                else
                {
                    ordHdrInfo.ScrapCredit = 0;

                }
                ordHdrInfo.CalculationType = 1;
                ordHdrInfo.ShipComments = "";
                ordHdrInfo.MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                ordHdrInfo.ProcPrice = Convert.ToDecimal(textBoxClClDiffPrice.Text);
                ordHdrInfo.Posted = 0;
                ordHdrInfo.BreakIn = 0;
                ordHdrInfo.RunSheetOrder = DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                ordHdrInfo.MixHeats = 0;



                if (modifyOrder)
                {
                    ordHdrInfo.OrderID = Convert.ToInt32(comboBoxClClDiffModify.Text);
                    UpdateOrderHdr(ordHdrInfo, tran);
                    DeleteSlitOrderInfo(ordHdrInfo.OrderID, tran);
                }
                else
                {
                    //if this is the second step masterord and sequence will be set from previous
                    //otherwise they are both zero(0)
                    int masterOrd = Convert.ToInt32(labelClClDiffMasterFrom.Text);
                    int sequence = Convert.ToInt32(labelClClDiffMasterSequence.Text);


                    ordHdrInfo.OrderID = AddOrderHdr(ordHdrInfo, tran);
                    if (masterOrd == 0)
                    {
                        //setting to -1 for addmasterorder flow
                        masterOrd = -1;
                    }



                    ordHdrInfo.masterOrderID = AddMasterOrder(ordHdrInfo.OrderID, sequence, tran, masterOrd);
                    labelClClDiffMasterFrom.Text = ordHdrInfo.masterOrderID.ToString();
                    if (checkBoxClClDiffMultStep.Checked)
                    {
                        //?????order ID is changing.
                        //add the next order hdr
                        leadTime += nextleadTime;
                        DateTime dt = DateTime.Now.AddBusinessDays(leadTime).Date;
                        ordHdrInfo.PromiseDate = dt.Date;
                        ordHdrInfo.MachineID = (comboBoxClClDiffSendTo.SelectedItem as dynamic).Value;
                        int NextOrderID = AddOrderHdr(ordHdrInfo, tran);
                        //increment master order sequence
                        sequence++;
                        ordHdrInfo.masterOrderID = AddMasterOrder(NextOrderID, sequence, tran, ordHdrInfo.masterOrderID);
                    }
                }








                ClClDiffHdrInfo slitOrdinfo = new ClClDiffHdrInfo
                {
                    orderID = ordHdrInfo.OrderID,
                    cutbreak = 0,
                    width = 0
                };
                int cutbreak = 0;
                for (int r = 0; r < dataGridViewClClDiff.RowCount; r++)
                {

                    slitOrdinfo.cutcount = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffCutCount"].Value);

                    if (dataGridViewClClDiff.Rows[r].Cells["colClClDiffTagID"].Style.BackColor != Color.LightGray)
                    {
                        //master coil record.




                        //need to strip off the suffix

                        string[] coilid = Convert.ToString(dataGridViewClClDiff.Rows[r].Cells["colClClDiffTagID"].Value).Split('.');

                        slitOrdinfo.coilTagID = Convert.ToInt32(coilid[0]);
                        slitOrdinfo.coilTagSuffix = dataGridViewClClDiff.Rows[r].Cells["colClClDiffTagID"].Tag.ToString().Trim();

                        if (dataGridViewClClDiff.Rows[r].Cells["colClClDiffPaper"].Value == null || !(bool)dataGridViewClClDiff.Rows[r].Cells["colClClDiffPaper"].Value)
                        {
                            slitOrdinfo.paper = 0;
                        }
                        else
                        {
                            slitOrdinfo.paper = 1;
                        }


                        slitOrdinfo.origWeight = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffOrigWeight"].Value);
                        //insert into coilslitorderhdr

                        AddCoilSlitORderHdr(slitOrdinfo, tran);




                        //insert into coilslitorderbreaks
                        slitOrdinfo.newWeight = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffNewWeight"].Value);
                        slitOrdinfo.parentWeight = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffOrigWeight"].Value);
                        slitOrdinfo.cutbreak = cutbreak;
                        slitOrdinfo.FlagID1 = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffThickness"].Tag);
                        slitOrdinfo.FlagID2 = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDifforigWeight"].Tag);


                        AddCoilSlitORderBreaks(slitOrdinfo, tran);


                        cutbreak++;

                    }
                    else
                    {
                        //slave coil breaks

                        //insert into coilslitorderbreaks
                        slitOrdinfo.newWeight = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffNewWeight"].Value);

                        slitOrdinfo.cutbreak = cutbreak;
                        slitOrdinfo.parentWeight = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffOrigWeight"].Value);
                        slitOrdinfo.FlagID1 = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDiffThickness"].Tag);
                        slitOrdinfo.FlagID2 = Convert.ToInt32(dataGridViewClClDiff.Rows[r].Cells["colClClDifforigWeight"].Tag);

                        AddCoilSlitORderBreaks(slitOrdinfo, tran);

                        cutbreak++;
                    }
                    int slitcount = 0;
                    slitOrdinfo.slitcount = 0;
                    //see if there are any slit cuts on this break.
                    //might not need +1 here need to check
                    if (ClClDiffGridInfo.colCnt == dataGridViewClClDiff.ColumnCount)
                    {
                        //there was only a break on here
                        //insert one row so we don't have to do outter joins later.
                        slitOrdinfo.width = Convert.ToDecimal(dataGridViewClClDiff.Rows[r].Cells["colClClDiffWidth"].Value);
                        slitOrdinfo.widthLeftCol = 1;
                        AddCoilSlitORderWidths(slitOrdinfo, tran);
                        slitcount++;

                    }
                    else
                    {


                        for (int c = ClClDiffGridInfo.colCnt; c <= dataGridViewClClDiff.ColumnCount; c++)
                        {

                            if (c == dataGridViewClClDiff.ColumnCount)
                            {
                                slitOrdinfo.width = Convert.ToDecimal(dataGridViewClClDiff.Rows[r].Cells["colClClDiffWidthLeft"].Value);
                                if (slitOrdinfo.width > 0)
                                {
                                    slitOrdinfo.widthLeftCol = 1;
                                    slitOrdinfo.slitcount = slitcount;
                                    AddCoilSlitORderWidths(slitOrdinfo, tran);
                                    slitcount++;
                                }
                            }
                            else
                            {


                                //if there is a width cut here insert
                                if (dataGridViewClClDiff.Rows[r].Cells[c].Value != null)
                                {
                                    //insert into coilslitorderwidths
                                    slitOrdinfo.slitcount = slitcount;
                                    slitOrdinfo.width = Convert.ToDecimal(dataGridViewClClDiff.Rows[r].Cells[c].Value);
                                    slitOrdinfo.widthLeftCol = 0;
                                    AddCoilSlitORderWidths(slitOrdinfo, tran);

                                    slitcount++;
                                }
                                else
                                {
                                    //check if there is a remaining width
                                    slitOrdinfo.width = Convert.ToDecimal(dataGridViewClClDiff.Rows[r].Cells["colClClDiffWidthLeft"].Value);
                                    if (slitOrdinfo.width > 0)
                                    {
                                        slitOrdinfo.widthLeftCol = 1;
                                        slitOrdinfo.slitcount = slitcount;
                                        AddCoilSlitORderWidths(slitOrdinfo, tran);
                                        slitcount++;
                                    }
                                    //no more cuts on this row.
                                    c = dataGridViewClClDiff.ColumnCount + 1;
                                }
                            }

                        }
                    }

                }

                //commit the transaction since all is good
                tran.Commit();
                if (modifyOrder)
                {
                    MessageBox.Show("Order " + slitOrdinfo.orderID + " was successfully update!");
                }
                else
                {
                    MessageBox.Show("Order " + slitOrdinfo.orderID + " has been added!");
                }
                textBoxClClDiffPO.Text = "";
                textBoxClClDiffPrice.Text = "";
                richTextBoxClClDiffComments.Text = "";
                dateTimePickerClClDiffPromiseDate.Value = DateTime.Now.AddBusinessDays(leadTime);
                checkBoxClClDiffModify.Checked = false;
                comboBoxClClDiffModify.Text = "";

                comboBoxClClDiffModify.Items.Clear();
                checkBoxClClDiffScrapCredit.Checked = false;
                buttonClClDiffReset.PerformClick();
                return;
            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
                //something went wrong rollback everything.
                tran.Rollback();
            }

        }

        private void ComboBoxClClDiffModify_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (MessageBox.Show("Do you need to change coils?", "Change Coils", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                //clear the rows
                dataGridViewClClDiff.Rows.Clear();
                buttonClClDiffReset.PerformClick();

                // load order from database
                ClClDiffHdrInfo hinfo = new ClClDiffHdrInfo();

                int orderID = Convert.ToInt32(comboBoxClClDiffModify.SelectedItem);
                using (DbDataReader reader = LoadClClDiffOrderHdr(orderID))
                {
                    if (reader.HasRows)
                    {

                        int cntr = 0;
                        while (reader.Read())
                        {
                            if (cntr == 0)
                            {
                                //load info
                                richTextBoxClClDiffComments.Text = reader.GetString(reader.GetOrdinal("Comments")).Trim();
                                dateTimePickerClClDiffPromiseDate.Value = reader.GetDateTime(reader.GetOrdinal("PromiseDate"));
                                checkBoxClClDiffScrapCredit.Checked = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal("ScrapCredit")));
                                textBoxClClDiffPrice.Text = reader.GetDecimal(reader.GetOrdinal("ProcPrice")).ToString("G29");
                                textBoxClClDiffPO.Text = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();

                            }

                            int coilid = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                            string coilSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                            for (int i = 0; i < listViewClClDiff.Items.Count; i++)
                            {
                                if (listViewClClDiff.Items[i].SubItems[0].Text.Equals(Convert.ToString(coilid + coilSuffix).Trim()))
                                {
                                    listViewClClDiff.Items[i].Checked = true;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                Count.CoilCut = 0;


                using (DbDataReader reader = GetClClDiffModify(Convert.ToInt32(comboBoxClClDiffModify.SelectedItem)))
                {


                    ClClDiffGridInfo.colCnt = dataGridViewClClDiff.Columns["colClClDiffAddCutButton"].Index + 1;
                    if (reader.HasRows)
                    {

                        int prevCoilID = -1;
                        string prevSuffix = "nope";
                        int prevWeight = -1;
                        ClClDiffHdrInfo hinfo = new ClClDiffHdrInfo();
                        int slitcntr = 0;
                        int breakcntr = -1;
                        dataGridViewClClDiff.Rows.Clear();
                        dataGridViewClClDiff.BringToFront();
                        for (int i = dataGridViewClClDiff.ColumnCount - 1; i > ClClDiffGridInfo.colCnt; i--)
                        {
                            dataGridViewClClDiff.Columns.RemoveAt(i);

                        }

                        while (reader.Read())
                        {
                            if (breakcntr != reader.GetInt32(reader.GetOrdinal("cutbreak")))
                            {
                                if (breakcntr == -1)
                                {

                                    //load info
                                    richTextBoxClClDiffComments.Text = reader.GetString(reader.GetOrdinal("Comments")).Trim();
                                    dateTimePickerClClDiffPromiseDate.Value = reader.GetDateTime(reader.GetOrdinal("PromiseDate"));
                                    checkBoxClClDiffScrapCredit.Checked = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal("ScrapCredit")));
                                    textBoxClClDiffPrice.Text = reader.GetDecimal(reader.GetOrdinal("ProcPrice")).ToString("G29");
                                    textBoxClClDiffPO.Text = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();


                                }
                                breakcntr = reader.GetInt32(reader.GetOrdinal("cutbreak"));
                                slitcntr = reader.GetInt32(reader.GetOrdinal("cutnumber"));
                                if (prevCoilID != reader.GetInt32(reader.GetOrdinal("coilTagID")) ||
                                    !reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim().Equals(prevSuffix))
                                {

                                    prevCoilID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                                    prevSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                                    if (prevWeight == -1)
                                    {
                                        prevWeight = reader.GetInt32(reader.GetOrdinal("weight"));
                                    }

                                    if (prevWeight == reader.GetInt32(reader.GetOrdinal("weight")))
                                    {
                                        AddClClDiffRow(reader, breakcntr, slitcntr);
                                    }
                                    else
                                    {
                                        AddClClDiffRow(reader, breakcntr, slitcntr, true);
                                    }

                                    prevWeight = reader.GetInt32(reader.GetOrdinal("weight"));


                                }
                                else
                                {
                                    if (prevWeight == reader.GetInt32(reader.GetOrdinal("weight")))
                                    {
                                        AddClClDiffRow(reader, breakcntr, slitcntr);
                                    }
                                    else
                                    {
                                        AddClClDiffRow(reader, breakcntr, slitcntr, true);
                                    }

                                    prevWeight = reader.GetInt32(reader.GetOrdinal("weight"));
                                }

                                AddClClDiffColumn(reader, breakcntr, slitcntr);
                            }
                            else
                            {

                                AddClClDiffColumn(reader, breakcntr, slitcntr);
                                //add slitting?
                            }

                        }
                        decimal widthleft = 0;
                        for (int i = 0; i < dataGridViewClClDiff.RowCount; i++)
                        {
                            widthleft = 0;
                            if (dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value == null)
                            {
                                if (dataGridViewClClDiff.ColumnCount > ClClDiffGridInfo.colCnt)
                                {
                                    for (int c = ClClDiffGridInfo.colCnt; c < dataGridViewClClDiff.ColumnCount; c++)
                                    {
                                        widthleft += Convert.ToDecimal(dataGridViewClClDiff.Rows[i].Cells[c].Value);
                                    }
                                    dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value = Convert.ToDecimal(Convert.ToDecimal(dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidth"].Value) - widthleft).ToString("G29");
                                    dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value = dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value;
                                }
                                else
                                {
                                    dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidthLeft"].Value = Convert.ToDecimal(dataGridViewClClDiff.Rows[i].Cells["colClClDiffWidth"].Value).ToString("G29");
                                }
                            }
                        }
                    }
                }
            }
            buttonClClDiffStartOrder.Visible = false;
            buttonClClDiffAddOrder.Visible = true;
            buttonClClDiffReset.Visible = true;
            buttonClClDiffResetCuts.Visible = true;
        }
        private void AddClClDiffColumn(DbDataReader reader, int rowcntr, int slitcntr, bool useWeight = false)
        {
            int widthLeftCol = reader.GetInt32(reader.GetOrdinal("widthLeftCol"));
            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
            int cutnumber = reader.GetInt32(reader.GetOrdinal("cutnumber"));

            if (widthLeftCol == 0)
            {
                //is there a blank space here?
                if (dataGridViewClClDiff.ColumnCount > ClClDiffGridInfo.colCnt + cutnumber)
                {
                    dataGridViewClClDiff.Rows[rowcntr].Cells[cutnumber + ClClDiffGridInfo.colCnt].Value = width.ToString("G29");
                    dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffCutCount"].Value = cutnumber + 1;
                }
                else
                {
                    Count.CoilCut++;
                    DataGridViewTextBoxColumn normalColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Cut " + Count.CoilCut
                    };

                    dataGridViewClClDiff.Columns.Add(normalColumn);
                    dataGridViewClClDiff.Rows[rowcntr].Cells[cutnumber + ClClDiffGridInfo.colCnt].Value = width.ToString("G29");
                    dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffCutCount"].Value = Count.CoilCut;
                }



            }
            else
            {
                dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffWidthLeft"].Value = width.ToString("G29");
            }
        }
        private void AddClClDiffRow(DbDataReader reader, int rowcntr, int slitcntr, bool useWeight = false)
        {
            dataGridViewClClDiff.Rows.Add();
            int origWeight = reader.GetInt32(reader.GetOrdinal("origWeight"));
            int parentWeight = reader.GetInt32(reader.GetOrdinal("parentWeight"));
            int weight = reader.GetInt32(reader.GetOrdinal("weight"));
            int FlagID1 = reader.GetInt32(reader.GetOrdinal("FlagID1"));
            int FlagID2 = reader.GetInt32(reader.GetOrdinal("FlagID2"));
            int paper = 0;
            if (!reader.IsDBNull(reader.GetOrdinal("paper")))
            {
                paper = reader.GetInt32(reader.GetOrdinal("paper"));
            }


            if (origWeight != parentWeight)
            {
                for (int i = 0; i < ClClDiffGridInfo.colCnt; i++)
                {
                    dataGridViewClClDiff.Rows[rowcntr].Cells[i].Style = new DataGridViewCellStyle { ForeColor = Color.Blue, BackColor = Color.LightGray };
                }
            }
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffTagID"].Value = reader.GetInt32(reader.GetOrdinal("coilTagID")).ToString() + reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffTagID"].Tag = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffThickness"].Value = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29");
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffWidth"].Value = reader.GetDecimal(reader.GetOrdinal("coilwidth")).ToString("G29");
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffAlloy"].Value = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim() + " " + reader.GetString(reader.GetOrdinal("finishDesc")).Trim();

            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffOrigWeight"].Value = parentWeight.ToString("G29");


            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffNewWeight"].Value = weight.ToString("G29");

            if (parentWeight != weight)
            {
                dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffBreak"].Value = true;

            }

            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffThickness"].Tag = FlagID1;
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffOrigWeight"].Tag = FlagID2;
            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffTrimAmount"].Value = reader.GetDecimal(reader.GetOrdinal("TrimAmount")).ToString("G29");
            if (paper == 0)
            {
                dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffPaper"].Value = false;
            }
            else
            {
                dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffPaper"].Value = true;
            }

            dataGridViewClClDiff.Rows[rowcntr].Cells["colClClDiffCutCount"].Value = slitcntr.ToString("G29");


        }

        private void ButtonClClDiffModifyDelte_Click(object sender, EventArgs e)
        {
            SqlTransaction tran = SQLConn.conn.BeginTransaction();

            try
            {


                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    OrderID = Convert.ToInt32(comboBoxClClDiffModify.Text),
                    Status = -99
                };
                UpdateOrderHdr(ordHdrInfo, tran, true);
                DeleteSlitOrderInfo(ordHdrInfo.OrderID, tran);

                tran.Commit();
                MessageBox.Show("Order " + ordHdrInfo.OrderID + " deleted!");
                StartOrderProcess(TreeViewCustomer.SelectedNode.Text, false);
                textBoxClClDiffPO.Text = "";
                textBoxClClDiffPrice.Text = "";
                richTextBoxClClDiffComments.Text = "";
            }
            catch (Exception se)
            {
                tran.Rollback();
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        }

        private void PanelCoilSheetSame_VisibleChanged(object sender, EventArgs e)
        {
            CTLInfo.Thickness = 0;
            CTLInfo.Width = 0;
            CTLInfo.Alloy = "";
            buttonCTLStartOrder.Visible = true;
            buttonCTLAddOrder.Visible = false;
            buttonCTLDeleteRow.Visible = false;

            listViewCTLCoilList.BringToFront();
            if (panelCoilSheetSame.Visible.Equals(true))
            {
                OrderCloning();

                AddOrderCTLInfo();

                
            }
        }
        private void AddOrderClClDiffInfo()
        {
            for (int i = 0; i < listViewClClDiff.Items.Count; i++)
            {
                string[] coilid = Convert.ToString(listViewClClDiff.Items[i].SubItems[0].Text).Split('.');

                int coilTagID = Convert.ToInt32(coilid[0]);
                string coilTagSuffix = listViewClClDiff.Items[i].SubItems[0].Tag.ToString().Trim();

                try
                {
                    using (DbDataReader reader = GetClClDiffOrderNumbers(coilTagID, coilTagSuffix))
                    {
                        string strOrders = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                strOrders += reader.GetInt32(reader.GetOrdinal("orderID")).ToString() + " ";
                            }
                            listViewClClDiff.Items[i].ForeColor = Color.Red;
                        }
                        listViewClClDiff.Items[i].SubItems[lvCCDOrders.Index].Text = strOrders;
                        reader.Close();
                    }

                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }
            }
        }
        //Coil Polish
        private void AddOrderCCSInfo()
        {
            for (int i = 0; i < listViewClClSame.Items.Count; i++)
            {
                string[] coilid = Convert.ToString(listViewClClSame.Items[i].SubItems[0].Text).Split('.');

                int coilTagID = Convert.ToInt32(coilid[0]);
                string coilTagSuffix = listViewClClSame.Items[i].SubItems[0].Tag.ToString().Trim();

                try
                {
                    using (DbDataReader reader = GetCCSOrderNumbers(coilTagID, coilTagSuffix))
                    {
                        string strOrders = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                strOrders += reader.GetInt32(reader.GetOrdinal("orderID")).ToString() + " ";
                            }
                            listViewClClSame.Items[i].ForeColor = Color.Red;
                        }
                        listViewClClSame.Items[i].SubItems[lvCCSOrders.Index].Text = strOrders;
                        reader.Close();
                    }

                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }
            }
        }
        private void AddOrderCTLInfo()
        {
            Cursor.Current = Cursors.WaitCursor;

            int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);

            
            List<string> tagList = new List<string>();
            List<int> orderList = new List<int>();
            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            using (DbDataReader reader = db.GetOrdersCustomer(custID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ordID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        int currTagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string tagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim() ;

                        tagList.Add(currTagID.ToString() + tagSuffix);
                        orderList.Add(ordID);
                    }
                }

            }


            db.CloseSQLConn();

            //are there any orders?  if note no need to run through the list.
            if (tagList.Count > 0)
            {
                for (int i = 0; i < listViewCTLCoilList.Items.Count; i++)
                {
                    string currTag = listViewCTLCoilList.Items[i].SubItems[0].Text;

                    if (tagList.Contains(currTag))
                    {
                        string strOrders = "";
                        for (int j = 0; j < tagList.Count; j++)
                        {
                            if (tagList[j].Equals(currTag))
                            {
                                strOrders += orderList[j].ToString() + " ";
                            }
                        }
                        listViewCTLCoilList.Items[i].SubItems[colCTLOrders.Index].Text = strOrders;
                        listViewCTLCoilList.Items[i].ForeColor = Color.Red;
                    }
                }
            }

            



            Cursor.Current = Cursors.Default;
        }
        private void AddOrderSSDInfo()
        {
            for (int i = 0; i < listViewSSD.Items.Count ; i++)
            {

                TagParser tp = new TagParser();
                tp.TagToBeParsed = listViewSSD.Items[i].SubItems[0].Text;
                tp.ParseTag();

                int coilTagID = tp.TagID;
                string coilTagSuffix = tp.CoilTagSuffix;
                string letter = tp.SkidLetter;

               
                try
                {
                    using (DbDataReader reader = GetSSDOrderNumbers(coilTagID, coilTagSuffix, letter))
                    {
                        string strOrders = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                strOrders += reader.GetInt32(reader.GetOrdinal("orderID")).ToString() + " ";
                            }
                            listViewSSD.Items[i].ForeColor = Color.Red;
                        }
                        listViewSSD.Items[i].SubItems[lvwSSDOrders.Index].Text = strOrders;
                        reader.Close();
                    }
                }
                catch (Exception se)
                {
                    MessageBox.Show("AddOrderSSDInfo Error: " + se);
                    MessageBox.Show(se.StackTrace);
                }
            }
        }

        private void AddOrderSSSInfo()
        {
            for (int i = 0; i < listViewSSSmSkidData.Items.Count; i++)
            {

                TagParser tp = new TagParser();
                tp.TagToBeParsed = listViewSSSmSkidData.Items[i].SubItems[0].Text;
                tp.ParseTag();


                int coilTagID = tp.TagID;
                string coilTagSuffix = tp.CoilTagSuffix;
                string letter = tp.SkidLetter;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (DbDataReader reader = GetSSSOrderNumbers(coilTagID, coilTagSuffix, letter))
                    {
                        string strOrders = "";
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                strOrders += reader.GetInt32(reader.GetOrdinal("orderID")).ToString() + " ";
                            }
                            listViewSSSmSkidData.Items[i].ForeColor = Color.Red;
                        }
                        listViewSSSmSkidData.Items[i].SubItems[lvsssOrders.Index].Text = strOrders;
                        reader.Close();
                    }
                }
                catch (Exception se)
                {
                    MessageBox.Show("AddOrderSSDInfo Error: " + se);
                    MessageBox.Show(se.StackTrace);
                }
                Cursor.Current = Cursors.Default;
            }
        }
        private void ListViewCSCoilList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string alloyComp = "";
            if (e.Item.Checked)
            {
                if (!e.Item.Checked && !e.Item.Focused)
                    return;

                if (e.Item.ForeColor == Color.Red)
                {
                    e.Item.Checked = false;
                    return;
                }
                int row = e.Item.Index;
                if (CTLInfo.Width == 0)
                {
                    CTLInfo.Width = Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLWidth.Index].Text);
                }
                if (CTLInfo.Thickness == 0)
                {
                    CTLInfo.Thickness = Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLThickness.Index].Text);
                }
                if (CTLInfo.Alloy.Equals(""))
                {

                    CTLInfo.Alloy = listViewCTLCoilList.Items[row].SubItems[colCTLAlloy.Index].Tag.ToString();


                }
                else
                {

                    alloyComp = listViewCTLCoilList.Items[row].SubItems[colCTLAlloy.Index].Tag.ToString();
                    if (!CTLInfo.Alloy.Equals(alloyComp))
                    {
                        if (MessageBox.Show("Are you sure you want to mix alloys?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            listViewCTLCoilList.Items[row].Checked = false;
                            return;
                        }
                    }
                }


                if (Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLWidth.Index].Text) > CTLInfo.Width + CTLInfo.Discrepency ||
                    Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLWidth.Index].Text) < CTLInfo.Width - CTLInfo.Discrepency)
                {
                    if (MessageBox.Show("Are you sure you want to mix widths?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        listViewCTLCoilList.Items[row].Checked = false;
                        return;
                    }
                }



                if (Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLThickness.Index].Text) > CTLInfo.Thickness + CTLInfo.Discrepency ||
                    Convert.ToDecimal(listViewCTLCoilList.Items[row].SubItems[colCTLThickness.Index].Text) < CTLInfo.Thickness - CTLInfo.Discrepency)
                {
                    if (MessageBox.Show("Are you sure you want to mix thickness?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        listViewCTLCoilList.Items[row].Checked = false;
                        return;
                    }
                }




            }
            else
            {
                if (listViewCTLCoilList.CheckedItems.Count == 0)
                {
                    CTLInfo.Thickness = 0;
                    CTLInfo.Width = 0;
                    CTLInfo.Alloy = "";
                }
                else
                {
                    if (listViewCTLCoilList.CheckedItems.Count == 1)
                    {
                        CTLInfo.Thickness = Convert.ToDecimal(listViewCTLCoilList.CheckedItems[0].SubItems[colCTLThickness.Index].Text);
                        CTLInfo.Width = Convert.ToDecimal(listViewCTLCoilList.CheckedItems[0].SubItems[colCTLWidth.Index].Text);
                        CTLInfo.Alloy = listViewCTLCoilList.CheckedItems[0].SubItems[colCTLAlloy.Index].Tag.ToString();
                    }
                }
            }

        }

        private void TextBoxDefaultsCTLThickDiscrepency_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxDefaultsCTLThickDiscrepency_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ButtonDefaultCTLThickDiscUpdate_Click(object sender, EventArgs e)
        {
            SetCTLThicknessDiscrepency(textBoxDefaultsCTLThickDiscrepency.Text);
        }

        private void ButtonCTLStartOrder_Click(object sender, EventArgs e)
        {
            if (!CheckMachine())
            {
                return;
            }
            

            buttonCTLAddOrder.Visible = true;
            buttonCTLAddOrder.Text = "Add Order";
            buttonCTLStartOrder.Visible = false;
            buttonCTLDeleteRow.Visible = true;
            buttonCTLArrowUp.Visible = true;
            buttonCTLArrowDown.Visible = true;
            int cntr = 0;
            int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);


            // Getting Pricing* info
            ProcPricingInfo procInfo = new ProcPricingInfo
            {
                MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag),
                TierLevel = Convert.ToInt32(ListViewCoilData.Tag)
            };

            dataGridViewCTLOrderEntry.Rows.Clear();
            for (int i = 0; i < listViewCTLCoilList.CheckedItems.Count; i++)
            {
                dataGridViewCTLOrderEntry.Rows.Add();
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Value = listViewCTLCoilList.CheckedItems[i].SubItems[0].Text;//tag
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Tag = listViewCTLCoilList.CheckedItems[i].SubItems[0].Tag;//tagsuffix
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLThickness"].Value = listViewCTLCoilList.CheckedItems[i].SubItems[3].Text;//thickness
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWidth"].Value = listViewCTLCoilList.CheckedItems[i].SubItems[4].Text;//width
                AlloyInfo ai = GetAlloyInfo(Convert.ToInt32(listViewCTLCoilList.CheckedItems[i].SubItems[2].Tag));
                
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Value = ai.alloy;
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Tag = ai.alloyID;
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLDensityFactor"].Value = ai.density;



                ai = GetFinishInfo(listViewCTLCoilList.CheckedItems[i].SubItems[colCTLAlloy.Index].Tag.ToString(), Convert.ToInt32(listViewCTLCoilList.CheckedItems[i].SubItems[colCTLThickness.Index].Tag));

                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeight"].Value = listViewCTLCoilList.CheckedItems[i].SubItems[colCTLWeight.Index].Text;//weight
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeightLeft"].Value = dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeight"].Value;

                procInfo.SteelTypeID = Convert.ToInt32(listViewCTLCoilList.CheckedItems[i].SubItems[4].Tag);
                procInfo.fromWidth = Convert.ToDecimal(listViewCTLCoilList.CheckedItems[i].SubItems[4].Text);
                procInfo.fromThickness = Convert.ToDecimal(listViewCTLCoilList.CheckedItems[i].SubItems[3].Text);

                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWidth"].Tag = procInfo.SteelTypeID;


                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Value = dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Value + " " + ai.finish;
                dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Tag = dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAlloy"].Tag + "." + ai.finishID;
                ((DataGridViewCheckBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLPaper"]).Value = true;
                
                GetSkidTypes(cntr);
                if (cntr == 0)
                {
                    GetAdders(cntr);
                }
                

                DBUtils db = new DBUtils();
                db.OpenSQLConn();
                int custCount = db.GetPVCRollCustCount(custID);

                DgvCTLPVCadd(cntr, dataGridViewCTLOrderEntry, "CTL",false,custCount ); 




                using (DbDataReader reader = db.GetBranchInfo(custID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLBranchID"]).Items.Add(reader.GetInt32(reader.GetOrdinal("BranchID")));
                            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLBranch"]).Items.Add(reader.GetString(reader.GetOrdinal("BranchDescShort")).Trim());

                        }
                    }
                    reader.Close();
                }
                db.CloseSQLConn();
                cntr++;
                
            }

            procInfo.fromLength = 1;
            procInfo.price = GetProcPricing(procInfo);
            textBoxCTLPrice.Text = procInfo.price.ToString();

            if (dataGridViewCTLOrderEntry.RowCount > 0)
            {
                dataGridViewCTLOrderEntry.BringToFront();
                dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLSkidCount"];
                dataGridViewCTLOrderEntry.BeginEdit(true);

            }


        }
        private void DgvPVCRecadd(int cntr)
        {
            using (DbDataReader reader = LoadPVCGroup())
            {


                if (reader.HasRows)
                {
                    string fPVCG = "";
                    int fGID = -1;
                    int fCntr = 0;
                    while (reader.Read())
                    {
                        string strPVCGroup = reader.GetString(reader.GetOrdinal("groupName")).Trim();
                        int GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"));

                        
                        if (fCntr == 0)
                        {
                            fPVCG = strPVCGroup;
                            fGID = GroupID;
                        }
                        //dataGridViewPVCRec.Rows.Add();
                        if (dataGridViewPVCRec.Rows.Count > 0)
                        {
                            ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells[PVCRecGroupType.Index]).Items.Add(strPVCGroup);
                            ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells[PVCRecGroupID.Index]).Items.Add(GroupID);
                            fCntr++;
                        }
                        
                       
                    }
                    if (fCntr > 0)
                    {
                        dataGridViewPVCRec.Rows[cntr].Cells["PVCRecGroupType"].Value = fPVCG;

                        dataGridViewPVCRec.Rows[cntr].Cells["PVCRecGroupID"].Value = fGID;

                    }

                }

            }
        }
        private void DgvCTLPVCadd(int cntr, DataGridView dgv ,string OrderType, bool useSecondConnection = false, int custCount = 0)
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            //int custCount = db.GetPVCRollCustCount(custID);
            
            using (DbDataReader reader = LoadPVCGroup(useSecondConnection))
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string strPVCGroup = reader.GetString(reader.GetOrdinal("groupName")).Trim();
                        int GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                        decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                        int rollcnt = GetPVCRollCount(GroupID);

                        strPVCGroup += "-" + rollcnt.ToString();
                        ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVC"]).Items.Add(strPVCGroup);
                        ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCGroupID"]).Items.Add(GroupID.ToString());
                        ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCPriceList"]).Items.Add(price.ToString());
                    }
                    
                    ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVC"]).Items.Add("Customer-" + custCount);
                    ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCGroupID"]).Items.Add("-99");
                    
                    ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVC"]).Items.Add("None");
                    dgv.Rows[cntr].Cells["dgv" + OrderType + "PVC"].Value = "None";
                    ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCGroupID"]).Items.Add("-1");
                    dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCGroupID"].Value = "-1";
                    ((DataGridViewComboBoxCell)dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCPriceList"]).Items.Add("0");
                    dgv.Rows[cntr].Cells["dgv" + OrderType + "PVCPriceList"].Value = "0";
                    dgv.Rows[cntr].Cells["dgv" + OrderType + "CurrPrice"].Value = "0";
                }

            }
            if (useSecondConnection)
            {
                SQLConn2.conn.Close();
            }
        }

        private void ButtonCTLAddOrder_Click(object sender, EventArgs e)
        {
            OrderHdrInfo ordHdrInfo = new OrderHdrInfo();
            CTLDetail ctlDet = new CTLDetail();
            //is everything filled out?
            if (textBoxCTLPrice.Text == "")
            {
                MessageBox.Show("Price cannot be blank!");
                textBoxCTLPrice.Focus();
                return;
            }
            if (textBoxCTLPO.Text == "")
            {
                MessageBox.Show("PO cannot be blank!");
                textBoxCTLPO.Focus();
                return;
            }
            DataGridView dgv = dataGridViewCTLOrderEntry;            //make sure we have the basic items we need.
            decimal paperPrice = -1;
            if (textBoxPaperPrice.Text != "")
            {
                paperPrice = Convert.ToDecimal(textBoxPaperPrice.Text);
            }
            
            
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (paperPrice == -1 && Convert.ToBoolean(dgv.Rows[i].Cells["dgvCTLPaper"].Value) == true)
                {
                    MessageBox.Show("Paper Price cannot be blank");
                    textBoxPaperPrice.Focus();
                    return;
                }
               
                int skidCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLSkidCount"].Value);
                int pieceCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLPieceCount"].Value);
                decimal length = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLLength"].Value);
                if (skidCount == 0 || pieceCount == 0 || length == 0)
                {
                    if (skidCount == 0)
                    {
                        MessageBox.Show("Skid Count cannot be blank or zero!");
                        dgv.CurrentCell = dgv.Rows[i].Cells["dgvCTLSkidCount"];
                        dgv.BeginEdit(true);
                        return;
                    }
                    if (pieceCount == 0)
                    {
                        MessageBox.Show("Piece Count cannot be blank or zero!");
                        dgv.CurrentCell = dgv.Rows[i].Cells["dgvCTLPieceCount"];
                        dgv.BeginEdit(true);
                        return;
                    }
                    if (length == 0)
                    {
                        MessageBox.Show("Length cannot be blank or zero!");
                        dgv.CurrentCell = dgv.Rows[i].Cells["dgvCTLLength"];
                        dgv.BeginEdit(true);
                        return;
                    }

                }



            }

            SqlTransaction tran = SQLConn.conn.BeginTransaction();

            if (buttonCTLAddOrder.Text.Equals("Modify Order"))
            {
                int ModOrderID = Convert.ToInt32(comboBoxCTLModify.Text);

                //delete old CTL data (revised data inserted below)
                DeleteCTLDetail(ModOrderID, tran);
                DeleteCTLAdders(ModOrderID, tran);
                //update hdr info
                ordHdrInfo = new OrderHdrInfo
                {
                    CustomerPO = textBoxCTLPO.Text.Trim(),
                    OrderDate = DateTime.Now.Date,
                    PromiseDate = dateTimePickerCTLPromiseDate.Value.Date,
                    Status = 1,
                    Comments = richTextBoxCTLComments.Text.Trim(),
                    OrderID = ModOrderID,
                    ProcPrice = Convert.ToDecimal(textBoxCTLPrice.Text),
                    runSheetComments = textBoxCTLRunSheetComments.Text
                    
                  
                    
                    
                };
                if (checkBoxCTLScrapCredit.Checked)
                {
                    ordHdrInfo.ScrapCredit = 1;
                }
                else
                {
                    ordHdrInfo.ScrapCredit = 0;

                }
                ordHdrInfo.paperPrice = 0;
                if (textBoxPaperPrice.Text != "")
                {
                    ordHdrInfo.paperPrice = Convert.ToDecimal(textBoxPaperPrice.Text);
                }
                UpdateOrderHdr(ordHdrInfo, tran);
                ctlDet.orderID = ModOrderID;
            }
            else
            {






                try
                {
                    //add order header
                    ordHdrInfo = new OrderHdrInfo
                    {
                        masterOrderID = -1,
                        CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                        CustomerPO = textBoxCTLPO.Text.Trim(),
                        OrderDate = DateTime.Now.Date,
                        PromiseDate = dateTimePickerCTLPromiseDate.Value.Date,
                        Status = 1,
                        Comments = richTextBoxCTLComments.Text.Trim(),
                        runSheetComments = textBoxCTLRunSheetComments.Text
                    };
                    if (checkBoxCTLScrapCredit.Checked)
                    {
                        ordHdrInfo.ScrapCredit = 1;
                    }
                    else
                    {
                        ordHdrInfo.ScrapCredit = 0;

                    }
                    ordHdrInfo.CalculationType = 1;
                    ordHdrInfo.ShipComments = "";
                    ordHdrInfo.MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                    ordHdrInfo.ProcPrice = Convert.ToDecimal(textBoxCTLPrice.Text);
                    ordHdrInfo.Posted = 0;
                    ordHdrInfo.BreakIn = 0;
                    ordHdrInfo.RunSheetOrder = DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                    ordHdrInfo.MixHeats = 0;
                    ordHdrInfo.paperPrice = 0;
                    if (textBoxPaperPrice.Text != "")
                    {
                        ordHdrInfo.paperPrice = Convert.ToDecimal(textBoxPaperPrice.Text);
                    }

                    ordHdrInfo.OrderID = AddOrderHdr(ordHdrInfo, tran);

                    //add master order info.
                    int ordSeq = 1;

                    ordHdrInfo.masterOrderID = AddMasterOrder(ordHdrInfo.OrderID, ordSeq, tran);

                    //add order detail
                    ctlDet = new CTLDetail
                    {
                        orderID = ordHdrInfo.OrderID
                    };
                }
                catch (Exception se)
                {
                    tran.Rollback();
                    MessageBox.Show(se.Message);
                    return;
                }

            }
            try
            {

                //insert CTL details
                for (int i = 0; i < dataGridViewCTLOrderEntry.RowCount; i++)
                {
                    ctlDet.sequenceNumber = i;


                    string[] coilid = Convert.ToString(dgv.Rows[i].Cells["dgvCTLTagID"].Value).Split('.');

                    ctlDet.CoilTagID = Convert.ToInt32(coilid[0]);
                    ctlDet.coilTagSuffix = dgv.Rows[i].Cells["dgvCTLTagID"].Tag.ToString().Trim();


                    ctlDet.skidCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLSkidCount"].Value);
                    ctlDet.pieceCount = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLPieceCount"].Value);
                    ctlDet.length = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLLength"].Value);
                    ctlDet.width = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLWidth"].Value);

                    string[] alloyinfo = Convert.ToString(dgv.Rows[i].Cells["dgvCTLAlloy"].Tag).Split('.');
                    ctlDet.alloyID = Convert.ToInt32(alloyinfo[0]);
                    ctlDet.finishID = Convert.ToInt32(alloyinfo[1]);

                    ctlDet.skidTypeID = Convert.ToInt32(dgv.Rows[i].Cells["dgvSkidTypeID"].Value);
                    if (dgv.Rows[i].Cells["dgvCTLComments"].Value != null)
                    {
                        ctlDet.comments = dgv.Rows[i].Cells["dgvCTLComments"].Value.ToString();
                    }
                    else
                    {
                        ctlDet.comments = "";
                    }
                    if (dgv.Rows[i].Cells["dgvCTLSheetWeight"].Value != null)
                    {
                        ctlDet.sheetWeight = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLSheetWeight"].Value);

                    }
                    else
                    {
                        ctlDet.sheetWeight = -1;
                    }
                    if (dgv.Rows[i].Cells["dgvCTLTheoLBS"].Value != null)
                    {
                        ctlDet.theoSkidWeight = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLTheoLBS"].Value);

                    }
                    else
                    {
                        ctlDet.theoSkidWeight = -1;
                    }

                    if (Convert.ToBoolean(dgv.Rows[i].Cells["dgvCTLPaper"].Value) == true)
                    {
                        ctlDet.paper = 1;
                    }
                    else
                    {
                        ctlDet.paper = 0;
                    }

                    ctlDet.pvc = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLPVCGroupID"].Value);
                    ctlDet.price = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLCurrPrice"].Value);
                    ctlDet.skidPrice = Convert.ToDecimal(dgv.Rows[i].Cells["dgvCTLCurrSkidPrice"].Value);
                    if (dgv.Rows[i].Cells["dgvCTLBranchID"].Value == null)
                    {
                        ctlDet.branchID = 0;
                    }
                    else
                    {
                        ctlDet.branchID = Convert.ToInt32(dgv.Rows[i].Cells["dgvCTLBranchID"].Value);
                    }
                    
                    AddCTLDetail(ctlDet, tran);

                    int addernum = ((DataGridViewComboBoxCell)dgv.Rows[i].Cells["dgvCTLAdder"]).Items.Count;

                    for (int j = 0; j < addernum - 1; j++)
                    {
                        int adderID = Convert.ToInt32(((DataGridViewComboBoxCell)dgv.Rows[i].Cells["dgvCTLAdderID"]).Items[j]);
                        decimal adderPrice = Convert.ToDecimal(((DataGridViewComboBoxCell)dgv.Rows[i].Cells["dgvCTLAdderPrice"]).Items[j]);
                        AddCTLAdders(ctlDet, adderID, adderPrice, tran);
                    }

                }
                tran.Commit();
                
            }

            catch (Exception se)
            {
                tran.Rollback();
                MessageBox.Show(se.Message);
                
            }

            //clear data
            buttonCTLReset.PerformClick();

            //message order#
            MessageBox.Show("Order Number " + ctlDet.orderID.ToString() +
                        " (Master Number " + ordHdrInfo.masterOrderID + ") has been created!");
            ReportGeneration rg = new ReportGeneration();
            rg.WorkOrder(ctlDet.orderID);

            //add adder information if needed.
            buttonCTLAddOrder.Visible = false;
            buttonCTLStartOrder.Visible = true;
            buttonCTLDeleteRow.Visible = false;
            buttonCTLArrowDown.Visible = false;
            buttonCTLArrowUp.Visible = false;
        }
        private bool CheckMachine()
        {
            if (tabControlMachines.TabCount > 1)
            {
                if (MessageBox.Show("Is order for " + tabControlMachines.SelectedTab.Text + "?", "Verify Machine", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

        }

        private void DataGridViewCTLOrderEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            var senderGrid = (DataGridView)sender;
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            string output = "";
            int weightleft = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells["dgvCTLWeightLeft"].Value);

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLAddCut"].Index)
            {

                result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "How Many Rows would you like to Add?", "Add Rows",
                                    out output);

                if (result != System.Windows.Forms.DialogResult.OK)
                {

                    return;
                }
                else
                {
                    if (output.Equals(""))
                    {

                        return;
                    }

                    DataGridViewRow dr = new DataGridViewRow();
                    int cntr = Convert.ToInt32(output);
                    if (cntr <= 0)
                    {
                        MessageBox.Show("Must be greater than zero.");
                        return;
                    }
                    for (int i = 0; i < cntr; i++)
                    {
                        dr = CloneWithValues(dataGridViewCTLOrderEntry.Rows[e.RowIndex]);
                        dataGridViewCTLOrderEntry.Rows.Insert(e.RowIndex + 1, dr);
                        dataGridViewCTLOrderEntry.Rows[e.RowIndex + 1].Cells["dgvCTLSkidCount"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[e.RowIndex + 1].Cells["dgvCTLPieceCount"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[e.RowIndex + 1].Cells["dgvCTLLength"].Value = null;
                    }

                    dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[e.RowIndex + 1].Cells["dgvCTLSkidCount"];
                    dataGridViewCTLOrderEntry.BeginEdit(true);
                }
            }
            else
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLAddSkid"].Index)
                {

                    result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "How many Skids?", "Add Skids",
                                    out output);

                    if (result != System.Windows.Forms.DialogResult.OK)
                    {
                        //delete last column?
                        return;
                    }
                    else
                    {
                        if (output.Equals(""))
                        {
                            //delete last column
                            return;
                        }
                    }
                    int skidcount = Convert.ToInt32(output);

                    DataGridViewTextBoxColumn normalColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Skid Count"
                    };

                    dataGridViewCTLOrderEntry.Columns.Add(normalColumn);
                    int colid = dataGridViewCTLOrderEntry.ColumnCount - 1;
                    dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells[colid].Value = skidcount.ToString();





                    result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "What is the length?", "Add Skids",
                                    out output);

                    if (result != System.Windows.Forms.DialogResult.OK)
                    {

                        return;
                    }
                    else
                    {
                        if (output.Equals(""))
                        {

                            return;
                        }
                    }
                    double length = Convert.ToDouble(output);

                    normalColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Length"
                    };

                    dataGridViewCTLOrderEntry.Columns.Add(normalColumn);

                    colid = dataGridViewCTLOrderEntry.ColumnCount - 1;
                    dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells[colid].Value = length.ToString("G29");



                    result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "How many pieces?", "Add Skids",
                                    out output);

                    if (result != System.Windows.Forms.DialogResult.OK)
                    {
                        //delete last column?
                        return;
                    }
                    else
                    {
                        if (output.Equals(""))
                        {
                            //delete last column
                            return;
                        }
                    }
                    int pieces = Convert.ToInt32(output);

                    normalColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Pieces"
                    };

                    dataGridViewCTLOrderEntry.Columns.Add(normalColumn);
                    colid = dataGridViewCTLOrderEntry.ColumnCount - 1;
                    dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells[colid].Value = pieces.ToString();
                    dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells[colid].Value = pieces.ToString();

                }
            }
        }

        private void DataGridViewCTLOrderEntry_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            RecGridInfo.row = e.RowIndex;
            RecGridInfo.col = e.ColumnIndex;
            //label1.Text = RecGridInfo.row.ToString();
        }

        private void DataGridViewCTLOrderEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLAdder"].Index)
            {
                //check if "Change" clicked
                if (((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"]).Items.Count == 0)
                {
                    ShowAdderComboBox();
                }


            }
        }

        private void ButtonAdderDone_Click(object sender, EventArgs e)
        {
            //clear current stuff
            dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"].Value = null;
            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"]).Items.Clear();
            dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"].Value = null;
            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"]).Items.Clear();

            string adderDesc = "";
            string adderID = "";
            decimal adderPrice = -1;
            int cntr = 0;
            //load selected items
            for (int i = 0; i < dataGridViewAdders.RowCount; i++)
            {
                //is the row selected
                if (Convert.ToBoolean(dataGridViewAdders.Rows[i].Cells["colSelect"].Value) == true )
                {
                    adderID = dataGridViewAdders.Rows[i].Cells["dgvAdderDesc"].Tag.ToString();
                    adderDesc = dataGridViewAdders.Rows[i].Cells["dgvAdderDesc"].Value.ToString();
                    adderPrice = Convert.ToDecimal(dataGridViewAdders.Rows[i].Cells["dgvAdderPrice"].Value);


                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"]).Items.Add(adderDesc);
                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"]).Items.Add(adderID.ToString());
                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderPrice"]).Items.Add(adderPrice);

                    if (cntr == 0)
                    {
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"].Value = adderDesc;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderID"].Value = adderID.ToString();
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdderPrice"].Value = adderPrice;
                    }
                    cntr++;
                    dataGridViewAdders.Rows[i].Cells["colSelect"].Value = false;
                }


                


            }
            //add change option in dropdown
            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLAdder"]).Items.Add("Change");


            //hide box and button
            buttonAdderDone.Visible = false;
            dataGridViewAdders.Visible = false;

            //clear out previous selections.
            
        }

        private void DataGridViewCTLOrderEntry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);


            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;

            //columns with decimal places
            if (dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLLength"].Index ||

                dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLTheoLBS"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigit_KeyPress);
                }
            }
            if (dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLSkidCount"].Index ||
                dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPieceCount"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }
            if (dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLAdder"].Index ||
                dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLSkidType"].Index||
                dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLBranch"].Index ||
                dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPVC"].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {


                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxCTL_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxCTL_SelectedIndexChanged);
                    PVCRowID = dataGridViewCTLOrderEntry.CurrentRow.Index;
                }
            }

            if (dataGridViewCTLOrderEntry.CurrentCell.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLTheoLBS"].Index) //Desired Column
            {

            }
        }




        private void DataGridViewCTLOrderEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (balanceToActive)
            {
                return;
            }
            //is there a change in length/piececount/skidcount/comments?
            if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLLength"].Index ||
                e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPieceCount"].Index ||
                e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLSkidCount"].Index ||
                e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLComments"].Index)
            {
                if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLLength"].Index)
                {
                    if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value== null)
                    {
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLCurrSkidPrice"].Value = null;
                    }
                    else
                    {
                        int tier = Convert.ToInt32(ListViewCoilData.Tag);
                        int skidID = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvSkidTypeID"].Value);
                        decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                        decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                        decimal price = GetSkidPricing(tier, skidID, width, length);
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLCurrSkidPrice"].Value = price;
                    }
                    
                }
                //is there data in pcs/length/skidcnt
                if (dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells["dgvCTLPieceCount"].Value != null &&
                    dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells["dgvCTLLength"].Value != null
                    && dataGridViewCTLOrderEntry.Rows[e.RowIndex].Cells["dgvCTLSkidCount"].Value != null)
                {
                    //did we just finish with the commments section?
                    if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLComments"].Index)
                    {
                        //are we on the last row?
                        if (dataGridViewCTLOrderEntry.RowCount - 1 > e.RowIndex)
                        {
                            //not on last row grab tagID
                            string tagid = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTagID"].Value.ToString();

                            //is the next row the same as this rows tagID?
                            if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLTagID"].Value.Equals(tagid))
                            {
                                //it is equal so we must have gone back into the list.  just tab down to next row.



                                AddCTLLine(true);



                            }
                            else
                            {
                                //not the same tag id so we are on last row of current
                                //the next row is diff so add a row if we have enough weight

                                //calculate weight left vs acceptable
                                decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                                decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                                decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                                decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                                int pcs = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value);
                                pcs *= Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value);

                                int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);

                                int totweight = CalcTotLBS();

                                int lbsleft = startweight - totweight;

                                int sheetlbs = Convert.ToInt32(MetFormula(density, thickness, 96, width, 1, 0));
                                //do we need another row?
                                if (lbsleft > sheetlbs)
                                {
                                    //yes


                                    AddCTLLine();



                                }
                                else
                                {
                                    //probably not but ask anyway.
                                    if (MessageBox.Show("Coil seems complete. Add another line?", "Out of material", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    {

                                        AddCTLLine();
                                    }
                                    else
                                    {

                                        AddCTLLine(true);
                                    }
                                }


                            }

                        }
                        else
                        {
                            if (Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Value) > 0)
                            {
                                AddCTLLine();
                            }

                        }
                    }
                    else
                    {
                        if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPieceCount"].Index)
                        {
                            if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value !=
                                dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Tag)
                            {
                                dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value = null;
                            }
                        }



                        //not in the comments section
                        //just calculate out weights
                        decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                        decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                        decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                        decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                        int pcs = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value);
                        pcs *= Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value);

                        int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);



                        string tagid = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTagID"].Value.ToString();

                        int totweight = CalcTotLBS();
                        SetWeightLeft(startweight - totweight);
                    }





                }
                else
                {

                    decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                    decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                    decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);

                    //what do we do here?
                    int totlbs = CalcTotLBS();
                    int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);
                    SetWeightLeft(startweight - totlbs);
                }
            }
            else
            {
                if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLTheoLBS"].Index)
                {
                    if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value != null)
                    {
                        if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value != null)
                        {
                            //why do you need a theo here?
                            if (MessageBox.Show("Override current piece count?", "Override?", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value == null)
                        {
                            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


                            int weightleft = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Value);

                            result = InputBox.Show(
                                                    "You have " + weightleft + " lbs left",
                                                    "What is the Length?",
                                                    "Value",
                                                    out string output, "", false);

                            if (result != DialogResult.OK)
                            {
                                return;
                            }

                            dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value = Convert.ToDecimal(output);

                        }

                        //figure out how many pieces this is?

                        decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                        decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                        decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                        decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                        int theolbs = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value);

                        //run through calculator
                        int pcs = Convert.ToInt32(MetFormula(density, thickness, length, width, 0, theolbs));
                        //dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value = pcs;
                        if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value == null)
                        {
                            dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value = 1;
                        }
                        int totlbs = CalcTotLBS();

                        int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);
                        SetWeightLeft(startweight - totlbs);
                        if (startweight - totlbs > 100)
                        {
                            string tagid = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTagID"].Value.ToString();

                            //is the next row the same as this rows tagID?
                            if (RecGridInfo.row < dataGridViewCTLOrderEntry.RowCount - 1)
                            {


                                if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLTagID"].Value.Equals(tagid))
                                {
                                    //it is equal so we must have gone back into the list.  just tab down to next row.



                                    AddCTLLine(true);



                                }
                                else
                                {
                                    AddCTLLine();
                                }
                            }
                            else
                            {
                                //on last row add another
                                AddCTLLine();
                            }

                        }
                        else
                        {
                            AddCTLLine(true);
                        }

                    }
                    else
                    {
                        AddCTLLine(true);
                    }
                }
                else
                {
                    if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLSheetWeight"].Index)
                    {
                        if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSheetWeight"].Value != null)
                        {
                            if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value != null)
                            {
                                decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                                decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                                decimal length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value);
                                decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                                decimal sheetTheoLBS = MetFormula(density, thickness, length, width, 1, 0);
                                decimal sheetNewLBS = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSheetWeight"].Value);
                                decimal percDiff = 0;
                                if (sheetNewLBS >= sheetTheoLBS)
                                {

                                    if (sheetTheoLBS > 0)
                                    {
                                        percDiff = ((sheetNewLBS - sheetTheoLBS) / sheetTheoLBS) * 100;
                                    }
                                    

                                }
                                else
                                {
                                    if (sheetTheoLBS > 0)
                                    {
                                        percDiff = ((sheetTheoLBS - sheetNewLBS) / sheetTheoLBS) * 100;
                                    }
                                }
                                percDiff = Math.Round(percDiff, 1);
                                if (percDiff > 5)
                                {
                                    if (MessageBox.Show("There is a " + percDiff + "% difference!", "Difference", MessageBoxButtons.OKCancel) == DialogResult.Cancel)

                                    {
                                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSheetWeight"].Value = null;
                                        return;

                                    }

                                }


                                int totlbs = CalcTotLBS();
                                int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);
                                SetWeightLeft(startweight - totlbs);

                            }
                        }
                        else
                        {
                            int totlbs = CalcTotLBS();
                            int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);
                            SetWeightLeft(startweight - totlbs);
                        }
                    }


                }

            }

        }

        private int CalcTotLBS(int currRow = -1)
        {
            int skids = 0;
            int pcs = 0;
            decimal length = 0;
            int totlbs = 0;

            if (currRow == -1)
            {
                currRow = RecGridInfo.row;
            }
            for (int i = 0; i < dataGridViewCTLOrderEntry.RowCount; i++)
            {
                if (dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Value.ToString().Trim() == dataGridViewCTLOrderEntry.Rows[currRow].Cells["dgvCTLTagID"].Value.ToString().Trim())
                {
                    if (dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLSkidCount"].Value != null &&
                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLPieceCount"].Value != null &&
                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLLength"].Value != null)
                    {
                        skids = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLSkidCount"].Value);
                        pcs = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLPieceCount"].Value);
                        length = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLLength"].Value);

                        if (dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLSheetWeight"].Value != null)
                        {
                            totlbs += Convert.ToInt32(Math.Round(
                                                (skids * pcs *
                                                Convert.ToDecimal(
                                                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLSheetWeight"].Value)), 0));

                        }
                        else
                        {
                            decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLDensityFactor"].Value);
                            decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLThickness"].Value);
                            decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWidth"].Value);

                            totlbs += Convert.ToInt32(MetFormula(density, thickness, length, width, skids * pcs, 0));

                        }
                    }
                }


            }
            return totlbs;
        }

        private void AddCTLLine(bool moveonly = false)
        {
            if (!moveonly)
            {
                DataGridViewRow dr = new DataGridViewRow();
                int cntr = 1;
                if (cntr <= 0)
                {
                    MessageBox.Show("Must be greater than zero.");
                    return;
                }
                for (int i = 0; i < cntr; i++)
                {
                    dr = CloneWithValues(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row]);
                    dataGridViewCTLOrderEntry.Rows.Insert(RecGridInfo.row + 1, dr);
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLSkidCount"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLPieceCount"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLLength"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLTheoLBS"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLSheetWeight"].Value = null;
                }

            }




            int nextindex = 12;

            SetColumnIndex method = new SetColumnIndex(MymethodCTL);

            dataGridViewCTLOrderEntry.BeginInvoke(method, nextindex);
        }

        private void SetWeightLeft(int weightleft, string tagid = "-1", int currRow = -1)
        {
            if (currRow == -1)
            {
                currRow = RecGridInfo.row;
            }
            if (tagid.Equals("-1"))
            {
                tagid = dataGridViewCTLOrderEntry.Rows[currRow].Cells["dgvCTLTagID"].Value.ToString();
            }
            for (int i = 0; i < dataGridViewCTLOrderEntry.RowCount; i++)
            {

                if (tagid == dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Value.ToString())
                {
                    dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeightLeft"].Value = weightleft;
                    if (weightleft < 0)
                    {
                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeightLeft"].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                    }
                    else
                    {
                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLWeightLeft"].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
                    }
                }


            }
        }

        private void BalanceToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balanceToActive = true;
            int lbsleft = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Value);
            if (lbsleft <= 70)
            {
                MessageBox.Show("There is not enough weight left.");
                return;
            }
            //if some of the fields are null and some are not.
            if ((dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value == null ||
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value == null ||
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value == null) &&
                    (
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value != null ||
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value != null ||
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value != null))
            {
                if (MessageBox.Show("Incomplete line. Do you want me to remove values?", "Incomplete", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value = null;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSheetWeight"].Value = null;
                }
            }

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            string comments = "";
            int weightleft = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Value);
            int maxlbs = -1;
            int maxpcs = -1;
            result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "What is the Max Pieces? (Cancel for Theo Weight)",
                                    "Value",
                                    out string output, "", true);

            if (result != DialogResult.OK)
            {

                result = InputBox.Show(
                                    "You have " + weightleft + " lbs left",
                                    "What is the Max Weight?",
                                    "Value",
                                    out output, "", true);
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                else
                {
                    if (output.Equals(""))
                    {

                        return;
                    }
                    maxlbs = Convert.ToInt32(output);
                }


            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }
                maxpcs = Convert.ToInt32(output);
            }
            decimal length = -1;

            decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
            decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
            decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);



            result = InputBox.Show(
                                "You have " + weightleft + " lbs left",
                                "What is the Length?",
                                "Value",
                                out output, "", false);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }
                length = Convert.ToDecimal(output);
                int tier = Convert.ToInt32(ListViewCoilData.Tag);
                int skidID = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvSkidTypeID"].Value);
                decimal price = GetSkidPricing(tier, skidID, width, length);
                dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLCurrSkidPrice"].Value = price;
            }
            if (maxlbs > 0)
            {
                maxpcs = Convert.ToInt32(MetFormula(density, thickness, length, width, 0, maxlbs));
            }
            string strDefComm = "";
            if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLComments"].Value != null)
            {
                strDefComm = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLComments"].Value.ToString();
            }
            result = InputBox.Show(
                                "You have " + weightleft + " lbs left",
                                "Comments?",
                                "Value",
                                out output, strDefComm,
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            else
            {

                comments = output;
            }


            if (maxpcs == -1)
            {
                //total pieces

                int onesheet = Convert.ToInt32(MetFormula(density, thickness, length, width, 1, 0));
                maxpcs = Convert.ToInt32(Math.Round(Convert.ToDouble(maxlbs / onesheet), 0));
            }
            else
            {
                int skidcnt = 0;
                decimal totpc = MetFormula(density, thickness, length, width, 0, weightleft);

                if (totpc < maxpcs)
                {
                    skidcnt = 1;
                    maxpcs = Convert.ToInt32(totpc);
                }
                else
                {
                    int weightLeft = Convert.ToInt32(MetFormula(density, thickness, length, width, Convert.ToInt32(totpc), 0));
                    if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value != null &&
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value != null &&
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value != null)
                    {
                        DataGridViewRow dr = CloneWithValues(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row]);

                        dataGridViewCTLOrderEntry.Rows.Insert(RecGridInfo.row, dr);
                        //RecGridInfo.row++;

                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSheetWeight"].Value = null;
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTheoLBS"].Value = null;
                    }
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Value = weightLeft;
                    if (weightleft < 0)
                    {
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                    }
                    else
                    {
                        dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeightLeft"].Style = new DataGridViewCellStyle { ForeColor = Color.Black };

                    }
                    skidcnt = Convert.ToInt32(Math.Round(totpc / maxpcs, 0));



                    if (skidcnt * maxpcs > totpc)
                    {
                        skidcnt -= 1;
                    }
                }

                if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value != null &&
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value != null &&
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value != null)
                {
                    AddCTLLine();
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLSkidCount"].Value = skidcnt;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLPieceCount"].Value = maxpcs;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLLength"].Value = length;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells["dgvCTLComments"].Value = comments;
                }
                else
                {
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLSkidCount"].Value = skidcnt;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value = maxpcs;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLLength"].Value = length;
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLComments"].Value = comments;
                }




                int remainder = Convert.ToInt32(totpc - (skidcnt * maxpcs));

                if (remainder > 0)
                {
                    DataGridViewRow dr = CloneWithValues(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row]);
                    //dr.Cells["dgvCTLPieceCount"].Value = remainder;

                    int row = RecGridInfo.row;
                    dataGridViewCTLOrderEntry.Rows.Insert(row, dr);

                    row++;

                    dataGridViewCTLOrderEntry.Rows[row].Cells["dgvCTLPieceCount"].Value = remainder;

                    dataGridViewCTLOrderEntry.Rows[row].Cells["dgvCTLSkidCount"].Value = 1;
                    RecGridInfo.row = row;
                    //label1.Text = RecGridInfo.row.ToString();

                }

                int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);


                string tagid = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTagID"].Value.ToString();
                int totweight = CalcTotLBS();
                SetWeightLeft(Convert.ToInt32(startweight - totweight), tagid);
                dataGridViewCTLOrderEntry.RefreshEdit();

            }

            balanceToActive = false;


        }

        
        private void DataGridViewCTLOrderEntry_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var r = dataGridViewCTLOrderEntry.HitTest(e.X, e.Y);
                RecGridInfo.row = r.RowIndex;
                //label1.Text = RecGridInfo.row.ToString();
                if (RecGridInfo.row >= 0)
                {
                    for (int i = 0; i < dataGridViewCTLOrderEntry.RowCount; i++)
                    {
                        dataGridViewCTLOrderEntry.Rows[i].Selected = false;
                    }
                    Point pt = new Point
                    {
                        X = e.X + this.Left + 200,
                        Y = e.Y + this.Top + 100
                    };
                    contextMenuStrip1.Show(pt);
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Selected = true;
                }
            }


        }


        private void ButtonCTLReset_Click(object sender, EventArgs e)
        {
            if (buttonCTLAddOrder.Visible == true)
            {
                dataGridViewCTLOrderEntry.Rows.Clear();
                listViewCTLCoilList.BringToFront();
                buttonCTLStartOrder.BringToFront();
                buttonCTLStartOrder.Visible = true;
                buttonCTLAddOrder.Visible = false;
                buttonCTLDeleteRow.Visible = false;
                buttonCTLArrowDown.Visible = false;
                buttonCTLArrowUp.Visible = false;
                checkBoxCTLModify.Checked = false;

            }
            else
            {
                for (int i = listViewCTLCoilList.CheckedItems.Count - 1; i >= 0; i--)
                {
                    listViewCTLCoilList.CheckedItems[i].Checked = false;
                }
            }

        }

        private void ButtonCTLDeleteRow_Click(object sender, EventArgs e)
        {
            int cntr = 0;
            string tagid = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLTagID"].Value.ToString();
            for (int i = 0; i < dataGridViewCTLOrderEntry.RowCount; i++)
            {
                if (dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Value.Equals(tagid))
                {
                    cntr++;
                }
            }
            if (cntr > 1)
            {

                decimal density = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLDensityFactor"].Value);
                decimal thickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLThickness"].Value);
                decimal width = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWidth"].Value);
                int startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLWeight"].Value);

                dataGridViewCTLOrderEntry.Rows.RemoveAt(RecGridInfo.row);
                if (RecGridInfo.row > 0)
                {
                    RecGridInfo.row--;

                }
                int totweight = CalcTotLBS();
                if (totweight < 0)
                {
                    totweight = 0;
                }
                SetWeightLeft(Convert.ToInt32(startweight - totweight), tagid);
                if (RecGridInfo.row > 0)
                {
                    dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row - 1].Cells["dgvCTLSkidCount"];
                    dataGridViewCTLOrderEntry.BeginEdit(true);
                }
                else
                {
                    dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLSkidCount"];
                    dataGridViewCTLOrderEntry.BeginEdit(true);
                }

            }

        }


        private void MymethodST(int columnIndex,int rowindex)
        {
            if (columnIndex == dataGridViewSteelTypeAlloys.Columns["dgvSTDisplayOrder"].Index)
            {
                int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;
                LoadAlloys(SteelTypeId);
                if (rowindex < dataGridViewSteelTypeAlloys.RowCount - 1)
                {
                    dataGridViewSteelTypeAlloys.CurrentCell = dataGridViewSteelTypeAlloys.Rows[rowindex + 1].Cells[columnIndex];

                }
                else
                {
                    dataGridViewSteelTypeAlloys.CurrentCell = dataGridViewSteelTypeAlloys.Rows[rowindex].Cells[columnIndex];

                }

                dataGridViewSteelTypeAlloys.BeginEdit(true);
            }

        }


        private void MymethodCTL(int columnIndex)
        {
            if (RecGridInfo.row < dataGridViewCTLOrderEntry.RowCount - 1)
            {
                DataGridViewColumnCollection columnCollection = dataGridViewCTLOrderEntry.Columns;

                DataGridViewColumn lastVisibleColumn = columnCollection.GetLastColumn(
                                        DataGridViewElementStates.Visible, DataGridViewElementStates.None);

                if (RecGridInfo.col == 0 || RecGridInfo.col == lastVisibleColumn.Index && RecGridInfo.row == dataGridViewCTLOrderEntry.RowCount - 1)
                {
                    balanceToActive = true;
                    
                    dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells[columnIndex];
                    dataGridViewCTLOrderEntry.BeginEdit(true);
                    balanceToActive = false;
                }
                else
                {


                    dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row + 1].Cells[columnIndex];
                    dataGridViewCTLOrderEntry.BeginEdit(true);
                }
            }
            else
            {
                dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells[columnIndex];
                dataGridViewCTLOrderEntry.BeginEdit(true);
            }

        }

        private void DataGridViewCTLOrderEntry_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ButtonCTLArrowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridViewCTLOrderEntry;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                //see if row above is same tag#
                if (!dgv.Rows[rowIndex].Cells["dgvCTLTagID"].Value.Equals(dgv.Rows[rowIndex - 1].Cells["dgvCTLTagID"].Value))
                {
                    return;
                }
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex - 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
            catch { }
        }

        private void ButtonCTLArrowDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridViewCTLOrderEntry;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                if (!dgv.Rows[rowIndex].Cells["dgvCTLTagID"].Value.Equals(dgv.Rows[rowIndex + 1].Cells["dgvCTLTagID"].Value))
                {
                    return;
                }
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows.Remove(selectedRow);
                dgv.Rows.Insert(rowIndex + 1, selectedRow);
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch { }
        }

        private void ButtonCTLArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void DataGridViewCTLOrderEntry_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (e.ColumnIndex == dataGridViewCTLOrderEntry.Columns["dgvCTLPieceCount"].Index)
            {



                if (dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value != null)
                {
                    dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Tag = dataGridViewCTLOrderEntry.Rows[RecGridInfo.row].Cells["dgvCTLPieceCount"].Value;
                }
            }
        }

        private void TabControlPVC_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPagePVCVendor)
            {
                LoadPVCVendor();
            }
            if(e.TabPage == tabPagePVCItems)
            {
                textBoxPVCItemDescAdd.CharacterCasing = CharacterCasing.Upper;
                textBoxPVCItemNumberAdd.CharacterCasing = CharacterCasing.Upper;
                LoadPVCVendorComboBox(comboBoxPVCVendor,true);

            }
            if(e.TabPage == tabPagePVCGroup)
            {
                LoadListBoxPVCGroup();
            }
            if (e.TabPage == tabPagePVCReceiving)
            {
                LoadPVCVendorComboBox(comboBoxPVCRecVendors, true);
                if (comboBoxPVCRecVendors.Items.Count > 0)
                {
                    if (buttonPVCRecAdd.Enabled == true)
                    {
                        buttonPVCRecAdd.Enabled = true;
                        int VendorID = (comboBoxPVCRecVendors.Items[comboBoxPVCRecVendors.SelectedIndex] as dynamic).Value;
                    }
                    
                }
                else
                {
                    buttonPVCRecAdd.Enabled = false;
                    MessageBox.Show("You have to add a vendor before you can enter an order");
                }

                //LoadPVCRecVendorItems(VendorID);
            }
            if(e.TabPage == tabPagePVCInvDetailed)
            {
                LoadListViewPVCDetail(listViewPVCInvDetail);
            }
            if (e.TabPage == tabPagePVCAdjust)
            {
                LoadListViewPVCDetail(listViewPVCAdjInv);
            }
            if (e.TabPage == tabPagePVCInventory)
            {
                LoadListViewPVCDetail(listViewPVCInvDetail);
            }
        }

        private void LoadPVCRecVendorItems(int vendID)
        {
            int cntr = 0;
            using (DbDataReader reader = LoadPVCVendorItems(vendID))
            {

                if (reader.HasRows)
                {
                    buttonPVCRecAdd.Enabled = true;
                    dataGridViewPVCRec.Rows.Add();
                    string fItem = "";
                    int fType = -99;
                    decimal fWidth = -99;
                    int fLength = -99;
                    while (reader.Read())
                    {
                        
                        string itemNum = reader.GetString(reader.GetOrdinal("ItemNumber")).Trim();
                        int TypeID = reader.GetInt32(reader.GetOrdinal("PVCTypeID"));
                        decimal width = reader.GetDecimal(reader.GetOrdinal("DefaultWidth"));
                        int length = reader.GetInt32(reader.GetOrdinal("DefaultLength"));
                        if (fItem == "")
                        {
                            fItem = itemNum;
                            fType = TypeID;
                            fWidth = width;
                            fLength = length;
                        }
                        ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells["PVCRecItemNumber"]).Items.Add(itemNum);
                        ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells["PVCRecTypeID"]).Items.Add(TypeID);
                        ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefWidth"]).Items.Add(width);
                        ((DataGridViewComboBoxCell)dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefLength"]).Items.Add(length );
                        

                    }

                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecItemNumber"].Value = fItem;
                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecTypeID"].Value = fType;
                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefWidth"].Value = fWidth;
                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefLength"].Value = fLength;
                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecItemWidth"].Value = dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefWidth"].Value;
                    dataGridViewPVCRec.Rows[cntr].Cells["PVCRecItemLength"].Value = dataGridViewPVCRec.Rows[cntr].Cells["PVCRecDefLength"].Value;
                    
                }
                else
                {

                    buttonPVCRecAdd.Enabled = false;
                    MessageBox.Show("you must have items in oreder to do receiving.");
                }



            }
            DgvPVCRecadd(cntr);
        }
        private void LoadListBoxPVCGroup()
        {
            listBoxPVCGroupList.Items.Clear();
            using (DbDataReader reader = LoadPVCGroup())
            {
                if (reader.HasRows)
                {
                    listBoxPVCGroupList.DisplayMember = "Text";
                    listBoxPVCGroupList.ValueMember = "Value";
                    
                    while (reader.Read())
                    {


                        string groupName = reader.GetString(reader.GetOrdinal("GroupName")).Trim();
                        int groupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                        listBoxPVCGroupList.Items.Add(new { Text = groupName, Value = groupID });

                    }


                }
            }


        }
        private void LoadPVCVendorComboBox(System.Windows.Forms.ComboBox cb,bool bGroup)
        {
            listViewPVCItems.Items.Clear();
            cb.Items.Clear();
            using (DbDataReader reader = LoadPVCVendorInfo())
            {
                if (reader.HasRows)
                {
                    cb.DisplayMember = "Text";
                    cb.ValueMember = "Value";

                    while (reader.Read())
                    {
                        
                       
                            string VendName = reader.GetString(reader.GetOrdinal("VendorName")).Trim();
                            int VendID = reader.GetInt32(reader.GetOrdinal("VendorID"));
                            cb.Items.Add(new { Text = VendName , Value = VendID });
                        
                    }
                
                
                }
            }
            if (bGroup)
            {
                using (DbDataReader reader = LoadPVCGroup())
                {
                    if (reader.HasRows)
                    {
                        comboBoxPVCItemGroupAdd.DisplayMember = "Text";
                        comboBoxPVCItemGroupAdd.ValueMember = "Value";

                        while (reader.Read())
                        {


                            string groupName = reader.GetString(reader.GetOrdinal("GroupName")).Trim();
                            int groupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                            comboBoxPVCItemGroupAdd.Items.Add(new { Text = groupName, Value = groupID });

                        }


                    }
                }
                if (comboBoxPVCItemGroupAdd.Items.Count > 0)
                {
                    comboBoxPVCItemGroupAdd.SelectedIndex = 0;
                }
                comboBoxPVCItemTack.SelectedIndex = 1;
            }
            
            
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
            }
           
        }

        private void LoadPVCVendor()
        {

            dataGridViewPVCVendor.Rows.Clear();
            using (DbDataReader reader = LoadPVCVendorInfo())
            {
                if (reader.HasRows)
                {

                    int cntr = 0;
                    while (reader.Read())
                    {


                        dataGridViewPVCVendor.Rows.Add();
                        dataGridViewPVCVendor.Rows[cntr].Cells["dgvPVCVendorName"].Value = reader.GetString(reader.GetOrdinal("VendorName")).Trim();
                        dataGridViewPVCVendor.Rows[cntr].Cells["dgvPVCVendorPhone"].Value = reader.GetString(reader.GetOrdinal("VendorPhoneNumber")).Trim();
                        dataGridViewPVCVendor.Rows[cntr].Cells["dgvPVCVendorName"].Tag = reader.GetInt32(reader.GetOrdinal("VendorID"));



                        cntr++;

                    }
                    dataGridViewPVCVendor.Rows.Add();
                }
                else
                {
                    dataGridViewPVCVendor.Rows.Add();
                }
            }


        }

        private void ButtonPVCVendorUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewPVCVendor.RowCount; i++)
            {
                if (dataGridViewPVCVendor.Rows[i].Cells["dgvPVCVendorName"].Tag == null)
                {
                    //insert a row
                    int vendID = InsertPVCVendor(i);
                    dataGridViewPVCVendor.Rows[i].Cells["dgvPVCVendorName"].Tag = vendID;
                }
                else
                {
                    //update row
                    int cnt = UpdatePVCVendor(i);
                    
                }
            }
            if (dataGridViewPVCVendor.Rows[dataGridViewPVCVendor.RowCount-1].Cells["dgvPVCVendorName"].Value != null)
            {
                dataGridViewPVCVendor.Rows.Add();
            }
        }

        private void ButtonPVCVendorDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridViewPVCVendor.SelectedRows.Count > 0 && dataGridViewPVCVendor.Rows.Count > 1)
            {
                //?????
                //will need to make sure there are no items out there.
                int VendorID = Convert.ToInt32(dataGridViewPVCVendor.SelectedRows[0].Cells["dgvPVCVendorName"].Tag);
                DeletePVCVendor(VendorID);
                dataGridViewPVCVendor.Rows.RemoveAt(dataGridViewPVCVendor.SelectedRows[0].Index);
            }
        }

        private void DataGridViewPVCVendor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBoxPVCVendor_SelectedIndexChanged(object sender, EventArgs e)
        {

            PopulatePVCVendorItems();
        }
        private string GetTack(int tack)
        {
            string strTack = "";
            switch (tack)
            {
                case 0:
                    strTack = "Low";
                    break;
                case 1:
                    strTack = "Medium";
                    break;
                case 2:
                    strTack = "High";
                    break;
                default:
                    strTack = "UNK";
                    break;
            }
            return strTack;
        }
        private void PopulatePVCVendorItems()
        {
            listViewPVCItems.Items.Clear();
            int VendorID = (comboBoxPVCVendor.Items[comboBoxPVCVendor.SelectedIndex] as dynamic).Value;

            using (DbDataReader reader = LoadPVCVendorItems(VendorID))
            {
                if (reader.HasRows)
                {

                    
                    while (reader.Read())
                    {
                        string gn = reader.GetString(reader.GetOrdinal("groupName")).Trim();
                        string inum = reader.GetString(reader.GetOrdinal("ItemNumber")).Trim();
                        string id = reader.GetString(reader.GetOrdinal("ItemDesc")).Trim();
                        string dw = reader.GetDecimal(reader.GetOrdinal("DefaultWidth")).ToString().Trim();
                        string dl = reader.GetInt32(reader.GetOrdinal("DefaultLength")).ToString().Trim();
                        int tack = reader.GetInt32(reader.GetOrdinal("tack"));
                        int typeid = reader.GetInt32(reader.GetOrdinal("PVCTypeID"));
                        string strTack = GetTack(tack);
                        ListViewItem lv =  listViewPVCItems.Items.Add(new System.Windows.Forms.ListViewItem(new string[]
                        {   gn,strTack, inum,id,dw,dl                        }));
                        lv.SubItems[2].Tag = typeid;
                        
                    }
                }
            }
        }

        private void ButtonPVCGroupAddGroup_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            result = InputBox.Show(
                                    "Enter Group Name",
                                    "Please enter then Name of the Group to Add (i.e B&W)",
                                    "Group Name",
                                    out string output,"",false,true,false);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }
                else
                {
                    decimal Price = 0;
                    bool keepgoing = false; 
                    while (!keepgoing)
                    {
                        result = InputBox.Show(
                                   "Enter Price for " + output,
                                   "Please enter the billing price for " + output,
                                   output + "Price",
                                   out string strPrice, "", false, false, true);
                        if (result != System.Windows.Forms.DialogResult.OK)
                        {

                            return;
                        }
                        else
                        {
                            if (output.Equals(""))
                            {

                                return;
                            }
                            else
                            {
                                
                                bool isValidDecimal = decimal.TryParse(strPrice, out Price);
                                if (isValidDecimal)
                                {
                                    keepgoing = true;
                                }
                            }
                            
                        }
                    }
                   
                    //add group name
                    int groupID = AddPVCGroupName(output, Price);
                    LoadListBoxPVCGroup();
                }
            }
        }

        private void ButtonPVCGroupDeleteGroup_Click(object sender, EventArgs e)
        {
            if (listBoxPVCGroupList.SelectedIndex >= 0)
            {
                int groupID = (listBoxPVCGroupList.Items[listBoxPVCGroupList.SelectedIndex] as dynamic).Value;

                DeletePVCGroup(groupID);

                LoadListBoxPVCGroup();
            }
            
        }

        private void ListViewPVCItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int CheckDupItem(int VendID, string itemnum)
        {
            int cntr = 0;
            using (DbDataReader reader = LoadPVCVendorItems(VendID, itemnum))
            {
                if (reader.HasRows)
                {

                    
                    while (reader.Read())
                    {
                        cntr++;
                    }
                }
            }
            return cntr;
        }

        private void ButtonPVCItemsAddItem_Click(object sender, EventArgs e)
        {
            
            int VendorID = (comboBoxPVCVendor.Items[comboBoxPVCVendor.SelectedIndex] as dynamic).Value;
            int groupID = (comboBoxPVCItemGroupAdd.Items[comboBoxPVCItemGroupAdd.SelectedIndex] as dynamic).Value;
            string itemNumber = textBoxPVCItemNumberAdd.Text;
            if (itemNumber.Equals(""))
            {
                MessageBox.Show("Item Number cannot be blank");
                return;
            }
            int ok = CheckDupItem(VendorID, itemNumber);
            if (ok > 0)
            {
                MessageBox.Show("item already exists");
                return;
            }

            string itemDesc = textBoxPVCItemDescAdd.Text;
            int width = 0;
            int length = 0;

            int tack = comboBoxPVCItemTack.SelectedIndex;
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            result = InputBox.Show(
                                    "Enter Width",
                                    "Please enter the default width for this item",
                                    "Default Width",
                                    out string output,"",true);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }
                else
                {
                    width = Convert.ToInt32(output);
                    
                }
            }
            result = InputBox.Show(
                                   "Enter Length",
                                   "Please enter the default length for this item",
                                   "Default Length",
                                   out output, "", true);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }
                else
                {
                    length = Convert.ToInt32(output);


                }
            }
            AddPVCVendorItem(VendorID, groupID, itemNumber, itemDesc, width, length, tack);
            PopulatePVCVendorItems();
        }

        private void ComboBoxPVCRecVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewPVCRec.Rows.Clear();
            int vendID = (comboBoxPVCRecVendors.Items[comboBoxPVCRecVendors.SelectedIndex] as dynamic).Value;

            LoadPVCRecVendorItems(vendID);
            
        }

        private void ButtonPVCRecAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = new DataGridViewRow();

            

            dr = CloneWithValues(dataGridViewPVCRec.Rows[dataGridViewPVCRec.RowCount - 1]);

            dataGridViewPVCRec.Rows.Insert(dataGridViewPVCRec.RowCount-1,dr);
        }

        private void ButtonPVCRecDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridViewPVCRec.RowCount > 1)
            {
                dataGridViewPVCRec.Rows.RemoveAt(RecGridInfo.row);
            }

            
        }

        private void DataGridViewPVCRec_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            RecGridInfo.row = e.RowIndex;
            RecGridInfo.col = e.ColumnIndex;

        }

        private void ButtonPVCRecAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPVCRecPONum.Text == null ||
                textBoxPVCRecRefNumber.Text == null)
            {
                MessageBox.Show("PO Number and Reference number are required!");
                return;
            }
            if (textBoxPVCRecPONum.Text.Equals("") ||
                textBoxPVCRecRefNumber.Text.Equals(""))
            {
                MessageBox.Show("PO Number and Reference number are required!");
                return;
            }
            string refNum = textBoxPVCRecRefNumber.Text;
            string poNum = textBoxPVCRecPONum.Text;
            DateTime dt = dateTimePicker2.Value;
            int CustID = 0;
            if (checkBoxPVCRecCustomer.Checked)
            {
                CustID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);

                int PVCRecID = InsertPVCRecHdr(CustID, refNum, poNum, dt);
                try
                {


                    for (int i = 0; i < dataGridViewPVCRec.RowCount; i++)
                    {


                        decimal dWidth = Convert.ToDecimal(dataGridViewPVCRec.Rows[i].Cells["PVCRecItemWidth"].Value);
                        int iLength = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecItemLength"].Value);
                        decimal dPrice = Convert.ToDecimal(dataGridViewPVCRec.Rows[i].Cells["PVCRecPrice"].Value);
                        int rollCnt = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecRollCount"].Value);
                        string strLocation = dataGridViewPVCRec.Rows[i].Cells["PVCRecLocation"].Value.ToString();
                        for (int j = 0; j < rollCnt; j++)
                        {
                            int TagID = InsertPVCRollDtl(PVCRecID, -1, CustID, dWidth, iLength, dPrice, strLocation);

                            //insert PVCCustRollDtl
                            int PVCGroupID = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecGroupID"].Value);
                            string PVCDesc = dataGridViewPVCRec.Rows[i].Cells["PVCRecItemNumberTextBox"].Value.ToString();

                            InsertPVCCustRollDtl(TagID, PVCGroupID, PVCDesc, strLocation);
                        }

                    }
                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }

            }
            else
            {
                int vendID = (comboBoxPVCRecVendors.Items[comboBoxPVCRecVendors.SelectedIndex] as dynamic).Value;
                
                
                try
                {
                    
                    

                    int PVCRecID = InsertPVCRecHdr(vendID, refNum, poNum, dt);

                    for (int i = 0; i < dataGridViewPVCRec.RowCount; i++)
                    {

                        int TypeID = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecTypeID"].Value);
                        decimal dWidth = Convert.ToDecimal(dataGridViewPVCRec.Rows[i].Cells["PVCRecItemWidth"].Value);
                        int iLength = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecItemLength"].Value);
                        decimal dPrice = Convert.ToDecimal(dataGridViewPVCRec.Rows[i].Cells["PVCRecPrice"].Value);
                        int rollCnt = Convert.ToInt32(dataGridViewPVCRec.Rows[i].Cells["PVCRecRollCount"].Value);
                        string strLocation = dataGridViewPVCRec.Rows[i].Cells["PVCRecLocation"].Value.ToString();
                        for (int j = 0; j < rollCnt; j++)
                        {
                            int TagID = InsertPVCRollDtl(PVCRecID, TypeID, CustID, dWidth, iLength, dPrice,strLocation);

                        }

                    }
                    MessageBox.Show("PVC Receiver " + PVCRecID.ToString() + " has been created.");

                    

                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }
            }
            //??????Print tags for receiver.

            tabControlPVC.SelectedTab = tabPagePVCInventory;
            textBoxPVCRecPONum.Text = "";
            textBoxPVCRecRefNumber.Text = "";
        }

        

        private void DataGridViewPVCRec_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewPVCRec.CurrentCell.ColumnIndex == dataGridViewPVCRec.Columns["PVCRecItemNumber"].Index)//Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxPVCRec_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxPVCRec_SelectedIndexChanged);
                }
            }
            if (dataGridViewPVCRec.CurrentCell.ColumnIndex == dataGridViewPVCRec.Columns["PVCRecGroupType"].Index)//Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxPVCRecCust_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxPVCRecCust_SelectedIndexChanged);
                }
            }
        }

        private void ButtonPVCItemDelete_Click(object sender, EventArgs e)
        {

            try
            {


                for (int i = 0; i < listViewPVCItems.Items.Count; i++)
                {
                    if (listViewPVCItems.Items[i].Checked)
                    {
                        int itemsnum = Convert.ToInt32(listViewPVCItems.Items[i].SubItems[2].Tag);
                        //int vendID = (comboBoxPVCVendor.Items[comboBoxPVCVendor.SelectedIndex] as dynamic).Value;
                        DeletePVCItem(itemsnum);
                    }
                }
                PopulatePVCVendorItems();
            }
            catch(Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        }

        private void TabControlPVCInventory_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPagePVCInvDetailed)
            {
                LoadListViewPVCDetail(listViewPVCInvDetail);
            }
        }
        
        private void LoadListViewPVCDetail(System.Windows.Forms.ListView lvName)
        {

            lvName.Items.Clear();
            try
            {
                using (DbDataReader reader = LoadPVCInventoryDetailed())
                {



                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            string custname = reader.GetString(reader.GetOrdinal("custname")).Trim();
                            int tagID = reader.GetInt32(reader.GetOrdinal("PVCTagID"));
                            string groupName = reader.GetString(reader.GetOrdinal("groupName")).Trim();
                            int tack = reader.GetInt32(reader.GetOrdinal("Tack"));
                            decimal width = reader.GetDecimal(reader.GetOrdinal("PVCWidth"));
                            int length = reader.GetInt32(reader.GetOrdinal("currentLength"));
                            string strItemDesc = reader.GetString(reader.GetOrdinal("ItemDesc")).Trim();
                            string strLocation = reader.GetString(reader.GetOrdinal("location")).Trim();
                            string strTack = GetTack(tack);

                            ListViewItem lv = lvName.Items.Add(
                                    new System.Windows.Forms.ListViewItem(new string[]
                                    {   custname,tagID.ToString().Trim(), groupName,strTack,strLocation, strItemDesc,
                                    width.ToString().Trim(),length.ToString().Trim() }));

                        }

                    }
                }

            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }


        }

        private void CheckBoxPVCRecCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPVCRecCustomer.Checked)
            {
                //confirm customer
                if (VerifyCustomer())
                {
                    dataGridViewPVCRec.Columns["PVCRecItemNumber"].Visible = false;
                    dataGridViewPVCRec.Columns["PVCRecItemNumberTextBox"].Visible = true;
                    dataGridViewPVCRec.Columns["PVCRecGroupType"].Visible = true;
                    comboBoxPVCRecVendors.Visible = false;
                }
                else
                {
                    checkBoxPVCRecCustomer.Checked = false;

                }

                //
            }
            else
            {
                dataGridViewPVCRec.Columns["PVCRecItemNumber"].Visible = true;
                dataGridViewPVCRec.Columns["PVCRecItemNumberTextBox"].Visible = false;
                dataGridViewPVCRec.Columns["PVCRecGroupType"].Visible = false ;
                comboBoxPVCRecVendors.Visible = true;
            }
        }

        private void ListViewPVCInvDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListViewPVCAdjInv_MouseDown(object sender, MouseEventArgs e)
        {
            HideTextEditor();
        }

        private void ListViewPVCAdjInv_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo i = listViewPVCAdjInv.HitTest(e.X, e.Y);
            SelectedLSI = i.SubItem;
            if (SelectedLSI == null)
                return;

            int border = 0;
            switch (listViewPVCAdjInv.BorderStyle)
            {
                case BorderStyle.FixedSingle:
                    border = 1;
                    break;
                case BorderStyle.Fixed3D:
                    border = 2;
                    break;
            }
            

            int CellWidth = SelectedLSI.Bounds.Width;
            int CellHeight = SelectedLSI.Bounds.Height;
            int CellLeft = border + listViewPVCAdjInv.Left + i.SubItem.Bounds.Left;
            int CellTop = listViewPVCAdjInv.Top + i.SubItem.Bounds.Top;
            // First Column
            if (i.SubItem == i.Item.SubItems[0])
                CellWidth = listViewPVCAdjInv.Columns[0].Width;

            if (i.SubItem == i.Item.SubItems[4]||i.SubItem == i.Item.SubItems[6]||i.SubItem == i.Item.SubItems[7])
            {
                if (i.SubItem == i.Item.SubItems[4])
                {
                    SelectedLSI.Tag = "Location";
                    wholeNumber = false;
                    allowText = true;
                }
                if (i.SubItem == i.Item.SubItems[6])
                {
                    SelectedLSI.Tag = "Width";
                    wholeNumber = false;
                    allowText = false;
                }
                if (i.SubItem == i.Item.SubItems[7])
                {
                    SelectedLSI.Tag = "Length";
                    wholeNumber = true;
                    allowText = false;
                }
                gLoc = i.Item.SubItems[4].Text;
                decWidth = Convert.ToDecimal(i.Item.SubItems[6].Text);
                intLength = Convert.ToInt32(i.Item.SubItems[7].Text);

                intTagID = Convert.ToInt32(i.Item.SubItems[1].Text);

                TxtEdit.Location = new Point(CellLeft, CellTop);
                TxtEdit.Size = new Size(CellWidth, CellHeight);
                TxtEdit.Visible = true;
                TxtEdit.BringToFront();
                TxtEdit.Text = i.SubItem.Text;
                TxtEdit.Select();
                TxtEdit.SelectAll();
            }
            
        }

        private void TxtEdit_Leave(object sender, EventArgs e)
        {
            HideTextEditor();
        }

        private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                HideTextEditor();
        }

        private void HideTextEditor()
        {
            TxtEdit.Visible = false;
            if (SelectedLSI != null && TxtEdit.Text != "")
            {
                SelectedLSI.Text = TxtEdit.Text;
                if (SelectedLSI.Tag.Equals("Width"))
                {
                    //update width on tag
                    decWidth = Convert.ToDecimal(SelectedLSI.Text);
                }
                if (SelectedLSI.Tag.Equals("Length"))
                {
                    //update Length on tag

                    intLength = Convert.ToInt32(SelectedLSI.Text);
                }
                if (SelectedLSI.Tag.Equals("Location"))
                {
                    //update Length on tag

                    gLoc  = SelectedLSI.Text;
                }
                if (SelectedLSI.Tag.Equals("Length")|| SelectedLSI.Tag.Equals("Width")|| SelectedLSI.Tag.Equals("Location"))
                {
                    UpdatePVCRollInfo(intTagID, decWidth, intLength, gLoc);
                    LoadListViewPVCDetail(listViewPVCAdjInv);
                }
                    
                

            }
                
            SelectedLSI = null;
            TxtEdit.Text = "";
        }

        private void TxtEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (allowText)
            {

            }
            else
            {
                if (wholeNumber)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                    }
                }





                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            
        }

        private void ButtonPVCAdjInv_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            string output = "";

            int ordid = -1;
            
            if (intPVCRollStatus == Convert.ToInt32(radioButtonPVCAdjSold.Tag))
            {
                //ask for PO# or something
                result = InputBox.Show(
                                    "What is a reference PO# for the sale?",
                                    "Please Enter a reference PO# for the sale!",
                                    "Reference#",
                                    out output,"",false,true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {

                    return;
                }
                else
                {
                    if (output.Equals(""))
                    {

                        return;
                    }
                    

                }

                //insert into PVC
            }
            if (intPVCRollStatus == Convert.ToInt32(radioButtonPVCAdjUsed.Tag))
            {
                //ask for order# or something
                result = InputBox.Show(
                                    "What order was this used on?",
                                    "Please enter the order number!",
                                    "Order#",
                                    out output,"",true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {

                    return;
                }
                else
                {
                    if (output.Equals(""))
                    {

                        return;
                    }


                }
                ordid = Convert.ToInt32(output);
            }

            for (int i = 0; i < listViewPVCAdjInv.CheckedItems.Count; i++)
            {
                intTagID = Convert.ToInt32(listViewPVCAdjInv.CheckedItems[i].SubItems[1].Text);

                UpdatePVCRollStatus(intTagID, intPVCRollStatus,output);
                if (radioButtonPVCAdjUsed.Checked)
                {
                    //insert into PVCOrderInfo
                    int linFoot = Convert.ToInt32(listViewPVCAdjInv.CheckedItems[i].SubItems[7].Text);
                    InsertPVCOrderInfo(intTagID, ordid, -1, linFoot);
                }


            }
            //reload after changes

            LoadListViewPVCDetail(listViewPVCAdjInv);
        }

        private void RadioButtonPVCAdjNotFound_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    intPVCRollStatus = Convert.ToInt32(rb.Tag);
                }
            }
        }

        private void RadioButtonPVCAdjSold_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    intPVCRollStatus = Convert.ToInt32(rb.Tag);
                }
            }
        }

        private void RadioButtonPVCAdjUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    intPVCRollStatus = Convert.ToInt32(rb.Tag);
                }
            }
        }

        private void TabControlMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMachines.TabPages.Count > 0)
            {
                if (Convert.ToInt32(tabControlProcess.SelectedTab.Tag) == 1)//cut to length
                {
                    ProcPricingInfo procInfo = new ProcPricingInfo
                    {
                        MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag)
                    };

                    if (dataGridViewCTLOrderEntry.RowCount > 0)
                    {


                        

                        procInfo.TierLevel = Convert.ToInt32(ListViewCoilData.Tag);

                        

                        procInfo.SteelTypeID = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLWidth"].Tag);

                        procInfo.fromThickness = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLThickness"].Value);
                        procInfo.fromWidth = Convert.ToDecimal(dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLWidth"].Value);
                        procInfo.fromLength = 1;//length doesn't matter in CTL base price

                        textBoxCTLPrice.Text = GetProcPricing(procInfo).ToString();
                    }

                    int leadtime = GetMachineLeadTimes(procInfo.MachineID);



                    SetLeadTime(leadtime);

                }
            }
            
            
        }
        
        private void SetLeadTime(int leadtime)
        {
            


            switch (Convert.ToInt32(tabControlProcess.SelectedTab.Tag))
            {
                case 0:
                    break;
                case 1:
                    dateTimePickerCTLPromiseDate.Value = DateTime.Now.AddBusinessDays(leadtime);
                    break;
                case 2:
                    dateTimePickerSSSmPromiseDate.Value = DateTime.Now.AddBusinessDays(leadtime);
                    break;
                case 3:
                    break;
            }
           

        }

        private void TabControlMachines_Selected(object sender, TabControlEventArgs e)
        {

            //default to 3 days.
            int leadtime = 3;
            //null?????

            if (tabControlMachines.TabPages.Count > 0)
            {



                leadtime = GetMachineLeadTimes(Convert.ToInt32(e.TabPage.Tag));



                SetLeadTime(leadtime);
            }


        }

        private void DataGridViewCustInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCustInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != dataGridViewCustInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag)
            {
                //something changed
                //updateCustomerInfo
                CustInfo CI = new CustInfo();
                int cntr = e.RowIndex;
                if (e.ColumnIndex == dataGridViewCustInfo.Columns["InfoShortName"].Index ||
                    e.ColumnIndex == dataGridViewCustInfo.Columns["InfoLongName"].Index)
                {
                    bRenewCustList = true;
                }
                CI.CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
                CI.ShortCustomerName = dataGridViewCustInfo.Rows[cntr].Cells["InfoShortName"].Value.ToString();
                CI.LongCustomerName = dataGridViewCustInfo.Rows[cntr].Cells["InfoLongName"].Value.ToString();
                CI.Address1 = dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress1"].Value.ToString();
                CI.Address2 = dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress2"].Value.ToString();
                CI.City = dataGridViewCustInfo.Rows[cntr].Cells["InfoCity"].Value.ToString();
                CI.StateCode = dataGridViewCustInfo.Rows[cntr].Cells["InfoState"].Value.ToString();
                CI.Zip = dataGridViewCustInfo.Rows[cntr].Cells["InfoZip"].Value.ToString();
                CI.Country = dataGridViewCustInfo.Rows[cntr].Cells["InfoCountry"].Value.ToString();
                CI.Phone = dataGridViewCustInfo.Rows[cntr].Cells["InfoPhone"].Value.ToString();
                CI.Fax = dataGridViewCustInfo.Rows[cntr].Cells["InfoFax"].Value.ToString();
                CI.ContactName = dataGridViewCustInfo.Rows[cntr].Cells["InfoContact"].Value.ToString();
                CI.Email = dataGridViewCustInfo.Rows[cntr].Cells["InfoEmail"].Value.ToString();
                CI.Packaging = dataGridViewCustInfo.Rows[cntr].Cells["InfoPackaging"].Value.ToString();
                CI.MaxSkidWeight = Convert.ToInt32(dataGridViewCustInfo.Rows[cntr].Cells["InfoMaxWeight"].Value);
                CI.PriceTier = Convert.ToInt32(dataGridViewCustInfo.Rows[cntr].Cells["InfoPriceTier"].Value);
                CI.QuickBookName = dataGridViewCustInfo.Rows[cntr].Cells["InfoQBName"].Value.ToString();
                CI.leadTime = Convert.ToInt32(dataGridViewCustInfo.Rows[cntr].Cells["InfoLeadTime"].Value);
                CI.IsActive = 1;
                if (Convert.ToBoolean(dataGridViewCustInfo.Rows[cntr].Cells["InfoWeightFormula"].Value) == true)
                {
                    CI.WeightFormula = 0;
                }
                else
                {
                    CI.WeightFormula = 1;
                }
                try
                {
                    UpdateCustomer(CI);
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoShortName"].Tag = CI.ShortCustomerName;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoLongName"].Tag = CI.LongCustomerName;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress1"].Tag = CI.Address1;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoAddress2"].Tag = CI.Address2;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoCity"].Tag = CI.City;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoState"].Tag = CI.StateCode;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoZip"].Tag = CI.Zip;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoCountry"].Tag = CI.Country;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoPhone"].Tag = CI.Phone;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoFax"].Tag = CI.Fax;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoContact"].Tag = CI.ContactName;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoEmail"].Tag = CI.Email;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoPackaging"].Tag = CI.Packaging;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoMaxWeight"].Tag = CI.MaxSkidWeight;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoPriceTier"].Tag = CI.PriceTier;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoQBName"].Tag = CI.QuickBookName;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoLeadTime"].Tag = CI.leadTime;
                    dataGridViewCustInfo.Rows[cntr].Cells["InfoWeightFormula"].Tag = CI.WeightFormula;
                    //this makes sure we get correct pricing on the order entry without having to reload everything.
                    ListViewCoilData.Tag = CI.PriceTier;
                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);

                }

                if (bRenewCustList)
                {
                    TreeViewCustomer.SelectedNode.Text = CI.ShortCustomerName;
                    bRenewCustList = false;
                }
            }
        }

        private void ButtonAddWorker_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                "Enter First Name",
                                "First Name",
                                "First Name",
                                out string output, "", false, true);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            WorkerInfo WI = new WorkerInfo
            {
                FirstName = output
            };

            result = InputBox.Show(
                                "Enter Last Name",
                                "Last Name",
                                "Last Name",
                                out output, "", false, true);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            WI.LastName = output;
            WI.active = 1;
            try
            {
                InsertWorker(WI);
                LoadWorkerInfo();
            }
            catch(Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);

            }
        }

        private void DataGridViewWorker_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewWorker.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != dataGridViewWorker.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag)
            {

                WorkerInfo WI = new WorkerInfo
                {
                    FirstName = dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerFirstName"].Value.ToString(),
                    LastName = dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerLastName"].Value.ToString()
                };
                if (Convert.ToBoolean(dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerActive"].Value) == true)
                {
                    WI.active = 1;
                }
                else
                {
                    WI.active = 0;
                }
                WI.WorkerID = Convert.ToInt32(dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerID"].Value);

                try
                {
                    UpdateWorker(WI);
                    dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerFirstName"].Tag = WI.FirstName;
                    dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerLastName"].Tag = WI.LastName;
                    dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerActive"].Tag  = dataGridViewWorker.Rows[e.RowIndex].Cells["WorkerActive"].Value;

                }
                catch (Exception se)
                {
                    Console.WriteLine("Error: " + se);
                    Console.WriteLine(se.StackTrace);
                }

            }
        }
        
        private void TabControlICMS_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (tabControlICMS.TabPages[e.Index].Name.Equals("tabPageReports") || 
                tabControlICMS.TabPages[e.Index].Name.Equals("tabPagePVC") ||
                tabControlICMS.TabPages[e.Index].Name.Equals("tabPageRunSheet"))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
                //tabControlICMS.TabPages[e.Index].BackColor = Color.Yellow;
            }
            else
            {
                tabControlICMS.TabPages[e.Index].BackColor = Color.LightYellow;
            }

            
            TabPage page = tabControlICMS.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void CheckBoxCTLModify_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCTLModify.Checked)
            {
                //make sure we are looking at right list
                buttonCTLReset.PerformClick();

                //get orders for this customer that are CTL and open.
                int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
                LoadCLSKSameOrders(custID);

                comboBoxCTLModify.Visible = true;
                comboBoxCTLModify.DroppedDown = true;
            }
            else
            {
                buttonCTLReset.PerformClick();
                comboBoxCTLModify.Visible = false;
            }
        }

        private void ComboBoxCTLModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //clear the rows
            dataGridViewCTLOrderEntry.Rows.Clear();
            buttonCTLReset.PerformClick();
            // load order from database
            CTLDetail ctlDet = new CTLDetail();
            int cntr = 0;
            ctlDet.orderID = Convert.ToInt32(comboBoxCTLModify.Items[comboBoxCTLModify.SelectedIndex]);

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetOrderHdr(ctlDet.orderID))
            {
                if (reader.HasRows)
                {

                    
                    while (reader.Read())
                    {
                        if (cntr == 0)
                        {
                            //load info
                            richTextBoxCTLComments.Text = reader.GetString(reader.GetOrdinal("Comments")).Trim() ;
                            dateTimePickerCTLPromiseDate.Value = reader.GetDateTime(reader.GetOrdinal("PromiseDate"));
                            checkBoxCTLScrapCredit.Checked = Convert.ToBoolean(reader.GetInt32(reader.GetOrdinal("ScrapCredit")));
                            textBoxCTLPrice.Text = reader.GetDecimal(reader.GetOrdinal("ProcPrice")).ToString();
                            textBoxCTLPO.Text = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim();
                            textBoxPaperPrice.Text = reader.GetDecimal(reader.GetOrdinal("paperPrice")).ToString().Trim();
                            textBoxCTLRunSheetComments.Text = reader.GetString(reader.GetOrdinal("runSheetComments")).Trim();
                        }

                        
                        

                    }

                }
                reader.Close();

            }
            cntr = 0;
            if (dataGridViewAdders.Rows.Count == 0)
            {
                using (DbDataReader reader = db.GetAdderDesc())
                {
                    cntr = 0;
                    if (reader.HasRows)
                    {



                        while (reader.Read())
                        {

                            string adderDesc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
                            int adderID = reader.GetInt32(reader.GetOrdinal("adderID"));


                            if (adderID > 0)
                            {
                                dataGridViewAdders.Rows.Add();

                                dataGridViewAdders.Rows[cntr].Cells["dgvAdderDesc"].Value = adderDesc;
                                dataGridViewAdders.Rows[cntr].Cells["dgvAdderDesc"].Tag = adderID;
                                dataGridViewAdders.Rows[cntr].Cells["dgvAdderPrice"].Value = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
                                cntr++;
                            }
                            else
                            {
                                if (adderDesc.Equals("Paper"))
                                {
                                    textBoxPaperPrice.Text = reader.GetDecimal(reader.GetOrdinal("adderPrice")).ToString().Trim();
                                }
                            }



                        }



                    }
                    reader.Close();

                }

                    
            }
            dataGridViewCTLOrderEntry.Rows.Add();
            

            using (DbDataReader reader = db.GetSkidTypeData())
            {
                StringBuilder sp = new StringBuilder();

                cntr = 0;
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

                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"]).Items.Add(sk.Description);
                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"]).Items.Add(sk.ID);
                        sp.Append(sk.letter + " = " + sk.Description + Environment.NewLine);
                        //skidTypes.Add(sk);??????
                        
                    }

                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"]).Items[0].ToString();
                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"]).Items[0];
                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"].ToolTipText = sp.ToString();
                }
                reader.Close();

            }

            int custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            

            using (DbDataReader reader = db.GetBranchInfo(custID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"]).Items.Add(reader.GetInt32(reader.GetOrdinal("BranchID")));
                        ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranch"]).Items.Add(reader.GetString(reader.GetOrdinal("BranchDescShort")).Trim());

                    }
                }
                reader.Close();
            }
            

            int startweight = 0;
            int totlbs = 0;

            int custCount = db.GetPVCRollCustCount(custID);

            using (DbDataReader reader = db.GetCTLDetails(ctlDet.orderID))
            {
                if (reader.HasRows)
                {
                    string coilTagID = "";
                    while (reader.Read())
                    {
                        if (cntr == 0)
                        {
                            
                            
                            
                        }
                        else
                        {
                            DataGridViewRow row = CloneWithValues((DataGridViewRow)dataGridViewCTLOrderEntry.Rows[cntr-1]);
                            dataGridViewCTLOrderEntry.Rows.Insert(cntr, row);
                            //default to none and will get reset below
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVC"].Value = "None";
                        }
                        dataGridViewCTLOrderEntry.Rows[cntr].Tag = reader.GetInt32(reader.GetOrdinal("sequenceNumber"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTagID"].Value = reader.GetInt32(reader.GetOrdinal("coilTagID")).ToString().Trim() + reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTagID"].Tag = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        if (coilTagID == "")
                        {
                            coilTagID = dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTagID"].Value.ToString().Trim();
                        }
                        else
                        {
                            if (coilTagID != dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTagID"].Value.ToString().Trim())
                            {
                                totlbs = CalcTotLBS(cntr-1);
                                startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[cntr-1].Cells["dgvCTLWeight"].Value);
                                SetWeightLeft(startweight - totlbs, "-1", cntr-1);
                                totlbs = 0;
                            }
                        }
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLThickness"].Value = reader.GetDecimal(reader.GetOrdinal("Thickness"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLWidth"].Value = reader.GetDecimal(reader.GetOrdinal("Width"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLAlloy"].Value = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim() + " " + reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLAlloy"].Tag = reader.GetInt32(reader.GetOrdinal("AlloyID")).ToString() + "." + reader.GetInt32(reader.GetOrdinal("FinishID")).ToString();
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLWeight"].Value = Math.Round(reader.GetDecimal(reader.GetOrdinal("Weight")), 0);
                        if (reader.GetInt32(reader.GetOrdinal("Paper")) > 0)
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPaper"].Value = true;
                        }
                        else
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPaper"].Value = false;
                        }

                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLDensityFactor"].Value = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));

                        //have to query PVC seperately so it finds everything.
                        if (cntr == 0)
                        {
                            //get the pvc Information for the first row and clone the rest.
                            DgvCTLPVCadd(cntr,dataGridViewCTLOrderEntry , "CTL" ,true, custCount);
                        }
                        int pvcID = reader.GetInt32(reader.GetOrdinal("PVCGroupID"));
                        if (pvcID > 0)
                        {
                           
                            for (int i = 0;i< ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVCGroupID"]).Items.Count; i++)
                            {
                                if (Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVCGroupID"]).Items[i]) == pvcID)
                                {
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVC"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVC"]).Items[i];
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVCGroupID"].Value = pvcID.ToString();
                                    i = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPVCGroupID"]).Items.Count;
                                }
                            }


                        }
                        int skidID = reader.GetInt32(reader.GetOrdinal("skidTypeID"));
                        if (skidID > 0)
                        {
                            for (int i = 0; i < ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"]).Items.Count; i++)
                            {
                                if (Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"]).Items[i]) == skidID)
                                {
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidType"]).Items[i];
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"].Value = skidID;
                                    i = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvSkidTypeID"]).Items.Count;
                                }
                            }
                        }
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLCurrSkidPrice"].Value = reader.GetDecimal(reader.GetOrdinal("skidPrice"));

                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLCurrPrice"].Value = reader.GetDecimal(reader.GetOrdinal("PVCPrice"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSkidCount"].Value = reader.GetInt32(reader.GetOrdinal("skidCount"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLPieceCount"].Value = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLLength"].Value = reader.GetDecimal(reader.GetOrdinal("length"));
                        dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLComments"].Value = reader.GetString(reader.GetOrdinal("comments")).Trim();
                        decimal shLBS = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                        if (shLBS > 0)
                        {

                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSheetWeight"].Value = Math.Round(Math.Abs(shLBS), 3) ;
                        }
                        else
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLSheetWeight"].Value = null;
                        }
                        int theoLBS = reader.GetInt32(reader.GetOrdinal("theoSkidWeight"));
                        if (theoLBS > 0)
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTheoLBS"].Value = theoLBS;
                        }
                        else
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLTheoLBS"].Value = null;
                        }
                        int BranchID = -1;
                        if (!reader.IsDBNull(reader.GetOrdinal("BranchID")))
                        {
                            BranchID = reader.GetInt32(reader.GetOrdinal("BranchID"));
                        }
                            
                        if (BranchID > 0)
                        {
                            for (int i = 0; i < ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"]).Items.Count; i++)
                            {
                                if (Convert.ToInt32(((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"]).Items[i]) == BranchID)
                                {
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranch"].Value = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranch"]).Items[i];
                                    dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"].Value = BranchID;
                                    i = ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"]).Items.Count;
                                }
                            }
                        }
                        else
                        {
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranch"].Value = null;
                            dataGridViewCTLOrderEntry.Rows[cntr].Cells["dgvCTLBranchID"].Value = null;
                        }
                        //skidtypeid????? load modify ctl




                        cntr++;
                    }

                    totlbs = CalcTotLBS(cntr-1);
                    startweight = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[cntr-1].Cells["dgvCTLWeight"].Value);
                    SetWeightLeft(startweight - totlbs, "-1", cntr-1);
                }
                else
                {
                    //reset everything since something went wrong.
                    dataGridViewCTLOrderEntry.Rows.Clear();
                    listViewCTLCoilList.BringToFront();
                    buttonCTLStartOrder.BringToFront();
                    buttonCTLStartOrder.Visible = true;
                    buttonCTLAddOrder.Visible = false;
                    buttonCTLDeleteRow.Visible = false;
                    buttonCTLArrowUp.Visible = false;
                    buttonCTLArrowDown.Visible = false;
                    buttonCTLAddOrder.Text = "Add Order";
                    for (int i = listViewCTLCoilList.CheckedItems.Count - 1; i >= 0; i--)
                    {
                        listViewCTLCoilList.CheckedItems[i].Checked = false;
                    }
                    MessageBox.Show("No data found for that order!");
                    return;
                }
            }

            //did we have any rows?
            if (cntr > 0)
            {
                for (int i = 0; i < dataGridViewCTLOrderEntry.Rows.Count; i++)
                {
                    //loop through to populate adders

                    string[] coilid = Convert.ToString(dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Value).Split('.');

                    ctlDet.CoilTagID = Convert.ToInt32(coilid[0]);
                    ctlDet.coilTagSuffix = dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLTagID"].Tag.ToString().Trim();
                    int seqNum = Convert.ToInt32(dataGridViewCTLOrderEntry.Rows[i].Tag);

                    using (DbDataReader reader = db.GetOrderAdders(ctlDet.orderID, ctlDet.CoilTagID, ctlDet.coilTagSuffix, seqNum))
                    {
                        if (reader.HasRows)
                        {
                            int addcntr = 0;
                            while (reader.Read())
                            {
                                string adderDesc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
                                int adderID = reader.GetInt32(reader.GetOrdinal("adderID"));
                                decimal adderPrice = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
                                if (adderID > 0)
                                {
                                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdder"]).Items.Add(adderDesc);
                                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdderID"]).Items.Add(adderID.ToString());
                                    ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdderPrice"]).Items.Add(adderPrice);
                                    if (addcntr == 0)
                                    {
                                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdder"].Value = adderDesc;
                                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdderID"].Value = adderID.ToString();
                                        dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdderPrice"].Value = adderPrice;
                                    }


                                    addcntr++;
                                }
                                
                            }
                            ((DataGridViewComboBoxCell)dataGridViewCTLOrderEntry.Rows[i].Cells["dgvCTLAdder"]).Items.Add("Change");
                            

                        }
                    }

                }
                //set up for writing the order.
                buttonCTLAddOrder.Visible = true;
                buttonCTLStartOrder.Visible = false;
                buttonCTLDeleteRow.Visible = true;
                buttonCTLArrowUp.Visible = true;
                buttonCTLArrowDown.Visible = true;
                buttonCTLAddOrder.Text = "Modify Order";


            
                dataGridViewCTLOrderEntry.BringToFront();
                dataGridViewCTLOrderEntry.CurrentCell = dataGridViewCTLOrderEntry.Rows[0].Cells["dgvCTLSkidCount"];
                dataGridViewCTLOrderEntry.BeginEdit(true);
            }

            db.CloseSQLConn();
        }

        private void ComboBoxSkidDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSkidPricingInfo();
            }
            catch(Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void LoadSkidPricingInfo()
        {
            int num = comboBoxSkidDescription.SelectedIndex;
            comboBoxSkidTypeID.Text = comboBoxSkidTypeID.Items[num].ToString();
            int tier = Convert.ToInt32(comboBoxTierLevel.Text);
            int skidID = Convert.ToInt32(comboBoxSkidTypeID.Text);
            dataGridViewSkidPricing.Rows.Clear();
            using (DbDataReader reader = GetAllSkidPricing(tier, false, skidID))
            {
                if (reader.HasRows)
                {
                    int cntr = 0;
                    while (reader.Read())
                    {
                        dataGridViewSkidPricing.Rows.Add();

                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromWidth"].Value = reader.GetDecimal(reader.GetOrdinal("FromWidth"));
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToWidth"].Value = reader.GetDecimal(reader.GetOrdinal("ToWidth"));
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromLength"].Value = reader.GetDecimal(reader.GetOrdinal("FromLength"));
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToLength"].Value = reader.GetDecimal(reader.GetOrdinal("ToLength"));
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPPrice"].Value = reader.GetDecimal(reader.GetOrdinal("Price"));

                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromWidth"].Tag = dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromWidth"].Value;
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToWidth"].Tag = dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToWidth"].Value;
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromLength"].Tag = dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPFromLength"].Value;
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToLength"].Tag = dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPToLength"].Value;
                        dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPPrice"].Tag = dataGridViewSkidPricing.Rows[cntr].Cells["dgvSPPrice"].Value;


                        cntr++;
                    }
                }
            }
        }

        private void ComboBoxTierLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNumber(comboBoxTierLevel.Text)&& comboBoxSkidDescription.Items.Count > 0)
                {
                    LoadSkidPricingInfo();
                }
                else
                {
                    if (comboBoxTierLevel.Text.Equals("Add Tier"))
                    {
                        if (IsNumber(comboBoxTierLevel.Tag.ToString()))
                        {
                            int cnt = comboBoxTierLevel.Items.Count;
                            int max = Convert.ToInt32(comboBoxTierLevel.Tag);
                            comboBoxTierLevel.Items.Insert(cnt - 1, max + 1);
                            comboBoxTierLevel.Text = Convert.ToString(max+1);
                        }
                    }
                }
                
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void DataGridViewSkidPricing_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            if (dataGridViewSkidPricing.Rows[row].Cells[col].Tag != dataGridViewSkidPricing.Rows[row].Cells[col].Value)
            {
                //something changed
                SkidPriceUpdate skup = new SkidPriceUpdate
                {
                    
                    tier = Convert.ToInt32(comboBoxTierLevel.Text),
                    skidID = Convert.ToInt32(comboBoxSkidTypeID.Text),
                    oldFromWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPFromWidth"].Tag),
                    oldToWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPToWidth"].Tag),
                    oldFromLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPFromLength"].Tag),
                    oldToLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPToLength"].Tag),
                    newFromWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPFromWidth"].Value),
                    newToWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPToWidth"].Value),
                    newFromLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPFromLength"].Value),
                    newToLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPToLength"].Value),
                    price = Convert.ToDecimal(dataGridViewSkidPricing.Rows[row].Cells["dgvSPPrice"].Value)
                };
                try
                {


                    UpdateSkidPricing(skup);
                    dataGridViewSkidPricing.Rows[row].Cells[col].Tag = dataGridViewSkidPricing.Rows[row].Cells[col].Value;
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        private void ButtonSkidPriceTest_Click(object sender, EventArgs e)
        {
            int tier = 0;
            int skidID = 0;
            if (IsNumber(comboBoxTierLevel.Text))
            {
                tier = Convert.ToInt32(comboBoxTierLevel.Text);
                if (IsNumber(comboBoxSkidTypeID.Text))
                {
                    skidID = Convert.ToInt32(comboBoxSkidTypeID.Text);
                }
                else
                {
                    MessageBox.Show("problem with skidType");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid Tier Level");
                return;
            }

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                "Enter Width",
                                "Width",
                                "Width",
                                out string output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            decimal width = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Enter Length",
                                "Length",
                                "Length",
                                out  output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            decimal length = Convert.ToDecimal(output);

            decimal price = GetSkidPricing(tier, skidID, width, length);

            labelTestPriceValue.Text = price.ToString();


        }

        private void ButtonAddPrice_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            SkidPriceUpdate skup = new SkidPriceUpdate();

            result = InputBox.Show(
                                "Enter From Width",
                                "From Width",
                                "From Width",
                                out string output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            skup.newFromWidth = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Enter To Width",
                                "From Width",
                                "From Width",
                                out output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            skup.newToWidth = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Enter From Length",
                                "From Length",
                                "From Length",
                                out output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            skup.newFromLength = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Enter To Length",
                                "To Length",
                                "To Length",
                                out output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            skup.newToLength = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Enter Price",
                                "Price",
                                "Price",
                                out output);

            if (result != System.Windows.Forms.DialogResult.OK)
            {

                return;
            }
            else
            {
                if (output.Equals(""))
                {

                    return;
                }

            }
            skup.price = Convert.ToDecimal(output);
            skup.tier = Convert.ToInt32(comboBoxTierLevel.Text);
            skup.skidID = Convert.ToInt32(comboBoxSkidTypeID.Text);
            try
            {
                InsertSkidPricing(skup);
                LoadSkidPricingInfo();
            }
            catch(Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ButtonDeleteSkidPrice_Click(object sender, EventArgs e)
        {
            SkidPriceUpdate skud = new SkidPriceUpdate
            {
                tier = Convert.ToInt32(comboBoxTierLevel.Text),
                skidID = Convert.ToInt32(comboBoxSkidTypeID.Text),
                newFromWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[RecGridInfo.row].Cells["dgvSPFromWidth"].Value),
                newToWidth = Convert.ToDecimal(dataGridViewSkidPricing.Rows[RecGridInfo.row].Cells["dgvSPToWidth"].Value),
                newFromLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[RecGridInfo.row].Cells["dgvSPFromLength"].Value),
                newToLength = Convert.ToDecimal(dataGridViewSkidPricing.Rows[RecGridInfo.row].Cells["dgvSPToLength"].Value)
            };

            try
            {
                DeleteSkidPricing(skud);
                LoadSkidPricingInfo();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void DataGridViewSkidPricing_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            RecGridInfo.row = e.RowIndex;
            RecGridInfo.col = e.ColumnIndex;
        }

        private void DataGridViewCustInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBoxCTLPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxPaperPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TabControlPlantLocations_DrawItem(object sender, DrawItemEventArgs e)
        {



            TabPage page = tabControlPlantLocations.TabPages[e.Index];
            if (page == tabControlPlantLocations.SelectedTab && tabControlPlantLocations.SelectedIndex != tabControlPlantLocations.TabCount-1)
            {
                SetTabHeader(page, Color.Yellow);
            }
            else
            {
                if (tabControlPlantLocations.SelectedIndex == tabControlPlantLocations.TabCount - 1)
                {
                    
                    SetTabHeader(page, Color.Yellow);
                }
                else
                {
                    SetTabHeader(page, Color.LightGray);
                }
                
            }


            using (Brush br = new SolidBrush(TabColors[tabControlPlantLocations.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(tabControlPlantLocations.TabPages[e.Index].Text, e.Font);
                e.Graphics.DrawString(tabControlPlantLocations.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, -1);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }

        private void ComboBoxProcTierLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsNumber(comboBoxProcTierLevel.Text) && comboBoxProcSteelTypeID.Text != "" && comboBoxProcMachineID.Text != "")
                {
                    PopulateProcDataGrid();
                }
                else
                {
                    if (comboBoxProcTierLevel.Text.Equals("Add Tier"))
                    {
                        if (IsNumber(comboBoxProcTierLevel.Tag.ToString()))
                        {
                            int cnt = comboBoxProcTierLevel.Items.Count;
                            int max = Convert.ToInt32(comboBoxProcTierLevel.Tag);
                            comboBoxProcTierLevel.Items.Insert(cnt - 1, max + 1);
                            comboBoxProcTierLevel.Text = Convert.ToString(max + 1);
                        }
                    }
                }

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ButtonSteelTypeAdd_Click(object sender, EventArgs e)
        {
            //insert into SteelType
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            result = InputBox.Show(
                                "Steel Type Description",
                                "Description?",
                                "Value",
                                out string output,"",
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                DBUtils db = new DBUtils();
                db.OpenSQLConn();

                int steelTypeID = db.InsertSteelType(output.Trim());

                db.CloseSQLConn();

                int lb = listBoxSteelTypes.Items.Add(new { Text = output.Trim(), Value = steelTypeID });
                listBoxSteelTypes.SelectedIndex = lb;

            }
            catch(Exception se)
            {
                MessageBox.Show("Error Adding Steel Type :" + se.Message);
            }
            

        }

        private void ListBoxSteelTypes_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ListBoxSteelTypes_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ListBoxSteelTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load alloys for steel type
            
            int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;
            LoadFinishes(SteelTypeId);
            LoadAlloys(SteelTypeId);
            
        }
        private void LoadFinishes(int SteelTypeID)
        {
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            listBoxSTFinish.Items.Clear();
            try
            {
                listBoxSTFinish.DisplayMember = "Text";
                listBoxSTFinish.ValueMember = "Value";

                using (DbDataReader reader = db.GetFinish("0",0, SteelTypeID))
                {
                    if (reader.HasRows)
                    {
                        int cntr = 0;

                        while (reader.Read())
                        {
                            
                            string finishDesc = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                            int FinishID = reader.GetInt32(reader.GetOrdinal("FinishID"));
                            listBoxSTFinish.Items.Add(new { Text = finishDesc, Value = FinishID });

                            cntr++;
                        }
                    }
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
            db.CloseSQLConn();
        }
        private void LoadAlloys(int SteelTypeID)
        {
            DataGridView dgv = dataGridViewSteelTypeAlloys;
            dgv.Rows.Clear();
            try
            {

                DBUtils db = new DBUtils();

                db.OpenSQLConn();


                using (DbDataReader reader = db.GetAlloyData(-1, SteelTypeID))
                {
                    if (reader.HasRows)
                    {
                        int cntr = 0;
                        
                        while (reader.Read())
                        {
                            dgv.Rows.Add();
                            dgv.Rows[cntr].Cells["dgvSTAlloy"].Value = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                            dgv.Rows[cntr].Cells["dgvSTAlloyID"].Value = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                            dgv.Rows[cntr].Cells["dgvSTDensity"].Value = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                            dgv.Rows[cntr].Cells["dgvSTDisplayOrder"].Value = reader.GetInt32(reader.GetOrdinal("OrderList"));
                            dgv.Rows[cntr].Cells["dgvSTPrice"].Value = reader.GetDecimal(reader.GetOrdinal("Price")).ToString("C");


                            dgv.Rows[cntr].Cells["dgvSTAlloy"].Tag = dgv.Rows[cntr].Cells["dgvSTAlloy"].Value;
                            dgv.Rows[cntr].Cells["dgvSTDensity"].Tag = dgv.Rows[cntr].Cells["dgvSTDensity"].Value;
                            dgv.Rows[cntr].Cells["dgvSTDisplayOrder"].Tag = dgv.Rows[cntr].Cells["dgvSTDisplayOrder"].Value;
                            cntr++;
                        }
                    }
                    reader.Close();
                }
                db.CloseSQLConn();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ListBoxSteelTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = (listBoxSteelTypes.SelectedItem as dynamic).Text.Trim();
            int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;

            DialogResult dr = MessageBox.Show("Do you want to Change " + curItem + "?",
                      "Update Steel Description", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    return;

            }

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                "Steel Type Description",
                                "Description?",
                                "Value",
                                out string output, "",
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            //update Steel desc with output
            try
            {
                DBUtils db = new DBUtils();
                db.OpenSQLConn();
                db.UpdateSteelDesc(SteelTypeId, output.Trim());
                db.CloseSQLConn();

                LoadSteelTypes();

                
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void DataGridViewSteelTypeAlloys_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridViewSteelTypeAlloys;

            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                int alloyID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["dgvSTAlloyID"].Value);
                string alloyDesc = dgv.Rows[e.RowIndex].Cells["dgvSTAlloy"].Value.ToString().Trim();
                decimal density = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["dgvSTDensity"].Value);
                int orderBy = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["dgvSTDisplayOrder"].Value);

                UpdateAlloyInfo(alloyID,alloyDesc,density,orderBy);

                SetColumnIndexST method = new SetColumnIndexST(MymethodST);

                dataGridViewCTLOrderEntry.BeginInvoke(method, e.ColumnIndex, e.RowIndex);

            }
        }

        private void DataGridViewSteelTypeAlloys_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void ButtonSteelTypeAddAlloy_Click(object sender, EventArgs e)
        {
            int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                "Alloy Description",
                                "Description?",
                                "Value",
                                out string output, "",
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string alloyDesc = output.Trim();


            result = InputBox.Show(
                                "Density Factor",
                                "Density?",
                                "Value",
                                out output, "",
                                false);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            decimal density = Convert.ToDecimal(output);

            result = InputBox.Show(
                                "Price",
                                "Price?",
                                "Value",
                                out output, "",
                                false);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            decimal price = Convert.ToDecimal(output);


            int maxOrderBy = 0;
            for (int i = 0; i < dataGridViewSteelTypeAlloys.RowCount; i++)
            {
                int currOB = Convert.ToInt32(dataGridViewSteelTypeAlloys.Rows[i].Cells["dgvSTDisplayOrder"].Value);
                if (currOB > maxOrderBy)
                {
                    maxOrderBy = currOB;
                }
            }


            maxOrderBy += 1;




            


            //update Steel desc with output
            try
            {


                int AlloyID = InsertAlloy(SteelTypeId, alloyDesc, density, maxOrderBy,price);
                InsertAlloyPriceHistory(AlloyID, price);
                int rowID = dataGridViewSteelTypeAlloys.Rows.Add();
                dataGridViewSteelTypeAlloys.Rows[rowID].Cells["dgvSTAlloyID"].Value = AlloyID;
                dataGridViewSteelTypeAlloys.Rows[rowID].Cells["dgvSTAlloy"].Value = alloyDesc;
                dataGridViewSteelTypeAlloys.Rows[rowID].Cells["dgvSTDensity"].Value = density;
                dataGridViewSteelTypeAlloys.Rows[rowID].Cells["dgvSTDisplayOrder"].Value = maxOrderBy;

                SetColumnIndexST method = new SetColumnIndexST(MymethodST);

                dataGridViewCTLOrderEntry.BeginInvoke(method, dataGridViewSteelTypeAlloys.Columns["dgvSTDisplayOrder"].Index, rowID);

                

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ListBoxSTFinish_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            // Get the currently selected item in the ListBox.
            string curItem = (listBoxSTFinish.SelectedItem as dynamic).Text.Trim();
            int FinishId = (listBoxSTFinish.SelectedItem as dynamic).Value;

            DialogResult dr = MessageBox.Show("Do you want to Change " + curItem + "?",
                      "Update Finish Description", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    return;

            }

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                "Finish Description",
                                "Description?",
                                "Value",
                                out string output, "",
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            //update Steel desc with output
            try
            {
                UpdateFinishDesc(FinishId, output.Trim());

                int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;

                LoadFinishes(SteelTypeId);
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void ButtonSTAddFinish_Click(object sender, EventArgs e)
        {
            //insert into SteelType
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            result = InputBox.Show(
                                "Finish Description",
                                "Description?",
                                "Value",
                                out string output, "",
                                false, true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                int SteelTypeId = (listBoxSteelTypes.SelectedItem as dynamic).Value;

                int FinishID = InsertFinish(SteelTypeId, output.Trim());

                listBoxSTFinish.Items.Add(new { Text = output.Trim(), Value = FinishID });
            }
            catch(Exception se)
            {
                MessageBox.Show("Error Adding Finish :" + se.Message);
            }
            
        }

        private void ListViewSPPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSPPrice.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listViewSPPrice.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                LoadPriceHistorInfo(intselectedindex);
            }
        }

        private void LoadPriceHistorInfo(int intselectedindex)
        {
            listViewSPHistory.Items.Clear();
            chartSPHistory.Series["Price"].Points.Clear();
            int AlloyID = Convert.ToInt32(listViewSPPrice.Items[intselectedindex].SubItems[0].Tag);

            using (DbDataReader reader = GetAlloyPriceHistory(AlloyID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem();
                        decimal price = reader.GetDecimal(reader.GetOrdinal("Price"));
                        DateTime dt = reader.GetDateTime(reader.GetOrdinal("dateUpdated"));

                        lv.SubItems[0].Text = price.ToString("C");

                        lv.SubItems.Add(dt.ToString("MM/dd/yyyy"));

                        listViewSPHistory.Items.Add(lv);

                        chartSPHistory.Series["Price"].Points.AddXY(dt.ToString("MM/dd/yyyy"), price);

                    }
                }

            }
        }
        private void ListViewSPPrice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            result = InputBox.Show(
                                "New Price",
                                "New Price?",
                                "Value",
                                out string output, "");
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (Convert.ToDecimal(output) > 2)
            {
                if (MessageBox.Show(this, "Are you sure " + output.Trim() + " is correct", "Verify Price", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            decimal price = Convert.ToDecimal(output);

            int row = listViewSPPrice.SelectedIndices[0];

            int alloyID = Convert.ToInt32(listViewSPPrice.Items[row].SubItems[0].Tag);

            UpdateAlloyInfo(alloyID, "", -1, -1, price, true);


            listViewSPPrice.Items[row].SubItems[1].Text = price.ToString("C");

            InsertAlloyPriceHistory(alloyID, price);

            LoadPriceHistorInfo(row);
        }

        private void ButtonCustInfoAddBranch_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            result = InputBox.Show(
                                "Short Name",
                                "Short Name?",
                                "Value",
                                out string output, "",false,true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string shortName = output.Trim();

             result = InputBox.Show(
                                "Branch Long Name",
                                "Branch Long Name?",
                                "Value",
                                out  output, "",false,true);
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string longName = output.Trim();

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            
            int custid = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            try
            {
                db.InsertBranchInfo(custid, shortName, longName);
                LoadCustomerInfo();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
            db.CloseSQLConn();
        }

        private void DataGridViewBranchInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridViewBranchInfo;

            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                int branchID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["dgvCBBranchID"].Value);
                string shortName = dgv.Rows[e.RowIndex].Cells["dgvCBShortBranch"].Value.ToString().Trim();
                string longName = dgv.Rows[e.RowIndex].Cells["dgvCBLongBranch"].Value.ToString().Trim();
                try
                {
                    UpdateBranchInfo(branchID, shortName, longName);
                }
                catch(Exception se)
                {
                    MessageBox.Show(se.Message);
                }
                LoadCustomerInfo();
            }
        }

        private void DataGridViewBranchInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;
        }

        private void ComboBoxProcSteelTypeDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProcSteelTypeDesc.SelectedIndex >= 0)
            {
                comboBoxProcSteelTypeID.SelectedIndex = comboBoxProcSteelTypeDesc.SelectedIndex;
                if (comboBoxProcSteelTypeID.Text != "")
                {
                }
            }
            if (comboBoxProcTierLevel.Text !="" && comboBoxProcSteelTypeID.Text != "" && comboBoxProcMachineID.Text != "")
            {
                //load the proc pricing
                PopulateProcDataGrid();
            }
          
        }

        private void ComboBoxProcMachineDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProcMachineDesc.SelectedIndex >= 0)
            {
                comboBoxProcMachineID.SelectedIndex = comboBoxProcMachineDesc.SelectedIndex;

            }
            if (comboBoxProcTierLevel.Text != "" && comboBoxProcSteelTypeID.Text != "" && comboBoxProcMachineID.Text != "")
            {
                //load the proc pricing
                PopulateProcDataGrid();
            }
        }

        private void PopulateProcDataGrid()
        {
            DataGridView dgv = dataGridViewProcPricing;
            dgv.Rows.Clear();

            int tierLevel = Convert.ToInt32(comboBoxProcTierLevel.Text);
            int steelTypeID = Convert.ToInt32(comboBoxProcSteelTypeID.Text);
            int machineID = Convert.ToInt32(comboBoxProcMachineID.Text);
            int cntr = 0;
            using (DbDataReader reader = GetAllProcPricing(tierLevel, false, steelTypeID, machineID))
            {
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        dgv.Rows.Add();

                        dgv.Rows[cntr].Cells["dgvProcFromThickness"].Value = reader.GetDecimal(reader.GetOrdinal("fromThickness"));
                        dgv.Rows[cntr].Cells["dgvProcToThickness"].Value = reader.GetDecimal(reader.GetOrdinal("toThickness"));
                        dgv.Rows[cntr].Cells["dgvProcFromWidth"].Value = reader.GetDecimal(reader.GetOrdinal("fromWidth"));
                        dgv.Rows[cntr].Cells["dgvProcToWidth"].Value = reader.GetDecimal(reader.GetOrdinal("toWidth"));
                        dgv.Rows[cntr].Cells["dgvProcFromLength"].Value = reader.GetInt32(reader.GetOrdinal("fromLength"));
                        dgv.Rows[cntr].Cells["dgvProcToLength"].Value = reader.GetInt32(reader.GetOrdinal("toLength"));
                        dgv.Rows[cntr].Cells["dgvProcPrice"].Value = reader.GetDecimal(reader.GetOrdinal("Price"));
                        
                        cntr++;
                    }
                }
            }
        }

        private void ButtonProcPricAdd_Click(object sender, EventArgs e)
        {

            if (comboBoxProcTierLevel.Text != "" && comboBoxProcSteelTypeID.Text != "" && comboBoxProcMachineID.Text != "")
            {
                ProcPricingInfo procInfo = new ProcPricingInfo
                {
                    TierLevel = Convert.ToInt32(comboBoxProcTierLevel.Text),
                    SteelTypeID = Convert.ToInt32(comboBoxProcSteelTypeID.Text),
                    MachineID = Convert.ToInt32(comboBoxProcMachineID.Text)
                };

                try
                {

                

                    wholeNumber = false;
                    string output;
                    output = GetInput("What is the From Thickness?", "From Thickness", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromThickness = Convert.ToDecimal(output);

                    output = GetInput("What is the To Thickness?", "To Thickness", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.toThickness = Convert.ToDecimal(output);

                    output = GetInput("What is the From Width?", "From Width", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromWidth = Convert.ToDecimal(output);

                    output = GetInput("What is the To Width?", "To Width", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.toWidth = Convert.ToDecimal(output);

                    wholeNumber = true;
                    output = GetInput("What is the From Length?", "From Length", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromLength = Convert.ToInt32(output);

                    output = GetInput("What is the To Length?", "To Length", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.toLength = Convert.ToInt32(output);

                    wholeNumber = false;

                    output = GetInput("What is the Price?", "Price", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.price = Convert.ToDecimal(output);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message);
                    return;
                }


                try
                {
                    InsertProcessPricing(procInfo);
                    PopulateProcDataGrid();
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message);
                }

            }
            else
            {
                MessageBox.Show("Tier, Metal Type and Machine must all be populated!");
            }


        }


        private string GetInput(string Question,string header, string inputTitle)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;


            result = InputBox.Show(
                                    header,
                                    Question ,
                                    inputTitle,
                                    out string output,"",wholeNumber);

            if (result != DialogResult.OK)
            {
                return "";
            }

            return output.Trim();
        }

        private void ButtonProcPriceDelete_Click(object sender, EventArgs e)
        {

            if (dataGridViewProcPricing.RowCount > 0 && dataGridViewProcPricing.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this?", "Delete Pricing", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                ProcPricingInfo procInfo = new ProcPricingInfo
                {
                    TierLevel = Convert.ToInt32(comboBoxProcTierLevel.Text),
                    SteelTypeID = Convert.ToInt32(comboBoxProcSteelTypeID.Text),
                    MachineID = Convert.ToInt32(comboBoxProcMachineID.Text)
                };

                DataGridViewRow row = dataGridViewProcPricing.SelectedRows[0];

                procInfo.fromThickness = Convert.ToDecimal(row.Cells["dgvProcFromThickness"].Value);
                procInfo.toThickness = Convert.ToDecimal(row.Cells["dgvProcToThickness"].Value);
                procInfo.fromWidth = Convert.ToDecimal(row.Cells["dgvProcFromWidth"].Value);
                procInfo.toWidth = Convert.ToDecimal(row.Cells["dgvProcToWidth"].Value);
                procInfo.fromLength = Convert.ToInt32(row.Cells["dgvProcFromLength"].Value);
                procInfo.toLength = Convert.ToInt32(row.Cells["dgvProcToLength"].Value);
                procInfo.price = Convert.ToDecimal(row.Cells["dgvProcPrice"].Value);

                try
                {
                    DeleteProcPricing(procInfo);
                    PopulateProcDataGrid();
                }
                catch(Exception se)
                {
                    MessageBox.Show(se.Message);
                }
            }
            
            
            
        }

        private void ButtonProcTest_Click(object sender, EventArgs e)
        {

            if (comboBoxProcTierLevel.Text != "" && comboBoxProcSteelTypeID.Text != "" && comboBoxProcMachineID.Text != "")
            {
                ProcPricingInfo procInfo = new ProcPricingInfo
                {
                    TierLevel = Convert.ToInt32(comboBoxProcTierLevel.Text),
                    SteelTypeID = Convert.ToInt32(comboBoxProcSteelTypeID.Text),
                    MachineID = Convert.ToInt32(comboBoxProcMachineID.Text)
                };

                try
                {



                    wholeNumber = false;
                    string output;
                    output = GetInput("What is the Thickness?", "Thickness", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromThickness = Convert.ToDecimal(output);


                    output = GetInput("What is the Width?", "Width", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromWidth = Convert.ToDecimal(output);


                    wholeNumber = true;

                    output = GetInput("What is the Length? (enter 0 for Cut To Length)", "From Length", "Value");
                    if (output == "")
                    {
                        MessageBox.Show("Cancelled");
                        return;
                    }
                    procInfo.fromLength = Convert.ToInt32(output);


                }
                catch (Exception se)
                {
                    MessageBox.Show(se.Message);
                    return;
                }


                decimal price = GetProcPricing(procInfo);
                labelProcPriceResults.Text = price.ToString();
            }
        }

        

        private void CheckBoxCloseOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCloseOrders.Checked)
            {
                CompleteOrders co = new CompleteOrders();
                
                co.Show();
                this.Hide();
                co.FormClosing += ClosedOrders_Closing;
            }
            
        }

        private void ClosedOrders_Closing(object sender, FormClosingEventArgs e)
        {
            checkBoxCloseOrders.Checked = false;
            this.Show();


            ListViewCoilData.Items.Clear();
            listViewSkidData.Items.Clear();

            try
            {
                DisplayCoilData(TreeViewCustomer.SelectedNode.Tag.ToString());
                DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());
                if (tabControlICMS.SelectedTab.Text.Equals("Orders"))
                {
                    StartOrderProcess(TreeViewCustomer.SelectedNode.Text.ToString(),false);


                    int MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                    int leadtime = GetMachineLeadTimes(MachineID);
                    SetLeadTime(leadtime);




                }
                if (tabControlICMS.SelectedTab.Text.Equals("Cust Info"))
                {
                    LoadCustomerInfo();
                }

            }
            catch (Exception se)
            {
                Console.WriteLine("Error: " + se);
                Console.WriteLine(se.StackTrace);
            }
        

        }

        
        private void RadioButtonScrapUnitInches_CheckedChanged(object sender, EventArgs e)
        {
            SetScrapUnit("IN");
        }

        private void RadioButtonScrapUnitLBS_CheckedChanged(object sender, EventArgs e)
        {
            SetScrapUnit("LBS");
        }


        private void ButtonSSSmStartOrder_Click(object sender, EventArgs e)
        {
            if (!CheckMachine())
            {
                return;
            }

            dataGridViewSSSmSkid.Rows.Clear();

            // pricing$-good
            ProcPricingInfo procInfo = new ProcPricingInfo
            {
                MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag),
                TierLevel = Convert.ToInt32(ListViewCoilData.Tag)
            };

            //***************
            int cntr = 0;
            for (int i = 0; i < listViewSSSmSkidData.CheckedItems.Count; i++)
            {
                if (i == 0)
                {
                    dataGridViewSSSmSkid.Rows.Add();
                }
                else
                {
                    DataGridViewRow dr = CloneWithValues(dataGridViewSSSmSkid.Rows[i - 1]);
                    dataGridViewSSSmSkid.Rows.Add(dr);

                }

                string curBranch = listViewSSSmSkidData.CheckedItems[i].SubItems[12].Text;
                int curBranchId = Convert.ToInt32(listViewSSSmSkidData.CheckedItems[i].SubItems[12].Tag);

                

                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmSkidID.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[0].Text;//tag
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmSkidID.Index].Tag = listViewSSSmSkidData.CheckedItems[i].SubItems[0].Tag;//tagsuffix
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmPieces.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[2].Text;//pieces
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmAlloy.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[3].Text;//Alloy
                AlloyInfo ai = GetAlloyInfo(Convert.ToInt32(listViewSSSmSkidData.CheckedItems[i].SubItems[3].Tag));

                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmLetter.Index].Value = "A";
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmAlloyID.Index].Value = ai.alloyID;
                
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmDensityFactor.Index].Value = ai.density;

                
                procInfo.SteelTypeID = Convert.ToInt32(listViewSSSmSkidData.CheckedItems[i].SubItems[10].Tag);
                procInfo.fromWidth = Convert.ToDecimal(listViewSSSmSkidData.CheckedItems[i].SubItems[5].Text);
                procInfo.fromThickness = Convert.ToDecimal(listViewSSSmSkidData.CheckedItems[i].SubItems[4].Text);


                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmThickness.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[4].Text;//thick
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmFinishID.Index].Tag = listViewSSSmSkidData.CheckedItems[i].SubItems[4].Tag;//original Finish ID
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmWidth.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[5].Text;//width
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmLength.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[6].Text;//Length
                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmWeight.Index].Value = listViewSSSmSkidData.CheckedItems[i].SubItems[7].Text;//Weight

                if (i == 0)
                {
                    
                    int custid = Convert.ToInt32( TreeViewCustomer.SelectedNode.Tag);

                    DBUtils db = new DBUtils();

                    db.OpenSQLConn();
                    int custCount = db.GetPVCRollCustCount(custid);

                    DgvCTLPVCadd(i, dataGridViewSSSmSkid, "SSSm", false,custCount);

                    LoadSSSmFinish(ai.alloyID.ToString(), Convert.ToInt32(listViewSSSmSkidData.CheckedItems[i].SubItems[3].Tag), i);


                    using (DbDataReader reader = db.GetBranchInfo(Convert.ToInt32(custid)))
                    {
                        if (reader.HasRows)
                        {

                           
                            while (reader.Read())
                            {


                                string branch = reader.GetString(reader.GetOrdinal("BranchDescShort")).Trim();
                                int branchid = reader.GetInt32(reader.GetOrdinal("BranchID"));
                                ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index]).Items.Add(branch);
                                ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index]).Items.Add(branchid);
                                if (branchid == curBranchId)
                                {
                                    dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index].Value = branchid;
                                    dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index].Value = branch.Trim() ;
                                }


                            }

                            ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index]).Items.Add("None");
                            ((DataGridViewComboBoxCell)dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index]).Items.Add(0);
                            if (curBranchId == 0)
                            {
                                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index].Value = 0;
                                dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index].Value = "None";
                            }
                        }

                        reader.Close();

                    }
                    db.CloseSQLConn();

                }
                else
                {
                    if (curBranchId == 0)
                    {
                        dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index].Value = 0;
                        dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index].Value = "None";
                    }
                    else
                    {
                        dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranchID.Index].Value = curBranchId;
                        dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmBranch.Index].Value = curBranch;
                    }
                }



                cntr++;

            }


            procInfo.price = GetProcPricing(procInfo);

            textBoxSSSmPrice.Text = procInfo.price.ToString();

            if (cntr > 0)
            {
                for (int i = 0; i < dataGridViewSSSmSkid.ColumnCount; i++)
                {
                    dataGridViewSSSmSkid.AutoResizeColumn(i);
                }
                
                dataGridViewSSSmSkid.BringToFront();
                buttonSSSmStartOrder.Visible = false;
                buttonSSSmAddOrder.Visible = true;
            }
            else
            {

                MessageBox.Show("Nothing selected");

            }
        }

        private void DataGridViewSSSmSkid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);


            if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dataGridViewSSSmSkid.Columns[dgvSSSmNewFinish.Index].Index||
                dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dataGridViewSSSmSkid.Columns[dgvSSSmBranch.Index].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    
                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxSSSm_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxSSSm_SelectedIndexChanged);
                }
            }


            if (dataGridViewSSSmSkid.CurrentCell.ColumnIndex == dataGridViewSSSmSkid.Columns[dgvSSSmPVC.Index].Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.ComboBox combo)
                {
                    combo.DropDown -= new EventHandler(Combo_DropDown);
                    combo.DropDown += new EventHandler(Combo_DropDown);


                    

                    combo.SelectedIndexChanged -= new EventHandler(ComboBoxSSSmPVC_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBoxSSSmPVC_SelectedIndexChanged);
                    PVCRowID = dataGridViewSSSmSkid.CurrentRow.Index;
                }
            }


        }

        private void Combo_DropDown(object sender, EventArgs e)
        {
            ((System.Windows.Forms.ComboBox)sender).BackColor = Color.White;
        }
        private void DataGridViewSSSmSkid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //are we in the breakskid column
            if (e.ColumnIndex == dgvSSSmBreakSkid.Index)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index];

                bool isChecked = (bool)checkbox.EditedFormattedValue;
                //did they check the column?
                if (isChecked)
                {

                    //default to 1 piece which is the minimum
                    
                    int piececount = 1;

                    System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
                    
                    result = InputBox.Show(
                        "How Many pieces do you want to take off?", "Removal Count",
                        "Pieces",
                        out string output, piececount.ToString(), true);

                    if (result != System.Windows.Forms.DialogResult.OK)
                    {
                        //cancel hit
                        ((DataGridViewCheckBoxCell)dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index]).EditingCellFormattedValue = false;

                        return;

                    }
                    else
                    {
                        //is this an actual number?  should be since we limit to numeric only in inputbox
                        if (IsNumber(output))
                        {
                            //pieces entered
                            piececount = Convert.ToInt32(output);
                            //piece count on current skid.
                            int origPieces = Convert.ToInt32(dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmPieces.Index].Value);

                            if (dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmPieces.Index].Tag != null)
                            {
                                if (dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmPieces.Index].Tag.ToString().Trim().Equals("Break"))
                                {
                                    //already part of a break
                                    //origPieces = Convert.ToInt32(dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index].Tag);
                                }
                            }
                            else
                            {
                                dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index].Tag = origPieces;
                            }


                            
                            dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmPieces.Index].Tag = "Break";
                            

                            
                            
                            //make sure we don't go over the original piece count
                            if (piececount < origPieces)
                            {
                                //no negative numbers allowed
                                if (piececount < 0)
                                {
                                    MessageBox.Show("Must be a positive number.");
                                    return;
                                }
                                //copy the current row int dr variable
                                DataGridViewRow dr = CloneWithValues(dataGridViewSSSmSkid.Rows[e.RowIndex]);
                                //set the piece count
                                dr.Cells[dgvSSSmPieces.Index].Value = piececount;
                                //insert the copied row just after the selected row.
                                dataGridViewSSSmSkid.Rows.Insert(e.RowIndex + 1, dr);
                                //update the piece count to reflect the break.
                                dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmPieces.Index].Value = origPieces - piececount;
                                

                                //get ready to redo the letters.
                                SkidSetup skidInfo = new SkidSetup();

                                string firstletter = "";
                                string lastletter = "";
                                //get the tag that we are working with
                                string tagID = dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmSkidID.Index].Value.ToString().Trim();
                                //set a flag for first time through the loop
                                bool firstRec = true;
                                //loop through each row
                                for (int i = 0; i < dataGridViewSSSmSkid.RowCount; i++)
                                {
                                    //see if this rows tagID matches the tagID in question
                                    if (dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmSkidID.Index].Value.ToString().Trim().Equals(tagID))
                                    {
                                        //found a match is this the first row?
                                        if (firstRec)
                                        {
                                            //first row.  Use the letter to start the sequence
                                            firstletter = dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmLetter.Index].Value.ToString();
                                            skidInfo.SetFirstLetter(firstletter);
                                            firstRec = false;
                                        }
                                        else
                                        {
                                            //no longer on the first row.  get the next letter and set it.
                                            lastletter = skidInfo.GetNextLetter();
                                            dataGridViewSSSmSkid.Rows[i].Cells[dgvSSSmLetter.Index].Value = lastletter;
                                        }

                                    }
                                }


                                //uncheck the break skid box.
                                ((DataGridViewCheckBoxCell)dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index]).EditingCellFormattedValue  = false;

                            }
                            else
                            {
                                MessageBox.Show("Piece count must be less than " + origPieces.ToString() + "!");
                                ((DataGridViewCheckBoxCell)dataGridViewSSSmSkid.Rows[e.RowIndex].Cells[dgvSSSmBreakSkid.Index]).EditingCellFormattedValue = false;

                            }
                        }

                    }
                }
            }
        }

        private void ButtonSSmAddOrder_Click(object sender, EventArgs e)
        {

           
            //make sure everything is filled out
            if (textBoxSSSmPO.Text == null||textBoxSSSmPO.Text.Equals(""))
            {
                MessageBox.Show("PO is required!");
                textBoxSSSmPO.Focus();
                return;
            }
            if (textBoxSSSmPrice.Text == null || textBoxSSSmPrice.Text.Equals(""))
            {
                MessageBox.Show("Price is required!");
                textBoxSSSmPO.Focus();
                return;
            }


            SqlTransaction tran = SQLConn.conn.BeginTransaction();

            try
            {

                //insert order header information (including master order)
                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    masterOrderID = -1,
                    CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                    CustomerPO = textBoxSSSmPO.Text.Trim(),
                    OrderDate = DateTime.Now.Date,
                    PromiseDate = dateTimePickerSSSmPromiseDate.Value.Date,
                    Status = 1,
                    Comments = richTextBoxSSSmComments.Text.Trim(),
                    runSheetComments = textBoxSSSmRunSheet.Text,
                    ShipComments = "",
                    ProcPrice = Convert.ToDecimal(textBoxSSSmPrice.Text),
                    MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag)

            };
                ordHdrInfo.OrderID = AddOrderHdr(ordHdrInfo, tran);


                //sequence will have to be worked out as I develop this ??????
                int sequence = 0;
                ordHdrInfo.masterOrderID = AddMasterOrder(ordHdrInfo.OrderID, sequence, tran);


                SkidPolishDtl spd = new SkidPolishDtl
                {
                    orderID = ordHdrInfo.OrderID
                };

                
                DataGridView dgv = dataGridViewSSSmSkid;
                //loop through the list and add order details.
                for (int i = 0; i < dataGridViewSSSmSkid.RowCount; i++)
                {



                    string skidID = dgv.Rows[i].Cells[dgvSSSmSkidID.Index].Value.ToString().Trim();

                    TagParser tp = new TagParser();

                    tp.TagToBeParsed = skidID;
                    tp.ParseTag();

                    spd.skidID = tp.TagID;
                    spd.coilTagSuffix = tp.CoilTagSuffix;
                    spd.skidLetter = tp.SkidLetter;

                    string[] parser = skidID.Split('.');


                    spd.orderLetter = dgv.Rows[i].Cells[dgvSSSmLetter.Index].Value.ToString().Trim();
                    spd.orderPieceCount = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmPieces.Index].Value);
                    spd.alloyID = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmAlloyID.Index].Value);
                    spd.previousFinishID = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmFinishID.Index].Tag);//set tag to previous
                    spd.newFinishID = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmFinishID.Index].Value);


                    if (dgv.Rows[i].Cells[dgvSSSmPVC.Index].Value.ToString().Equals("None"))
                    {
                        spd.PVC = 0;//if unchecked
                        spd.PVCPrice = 0;
                    }
                    else
                    {
                        spd.PVC = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmPVCGroupID.Index].Value);
                        spd.PVCPrice = Convert.ToDecimal(dgv.Rows[i].Cells[dgvSSSmCurrPrice.Index].Value);
                    }

                    spd.paper = Convert.ToBoolean(dgv.Rows[i].Cells[dgvSSSmPaper.Index].Value) == true ? 1 : 0;

                    spd.lineMark = Convert.ToBoolean(dgv.Rows[i].Cells[dgvSSSmLineMark.Index].Value) == true ? 1 : 0;

                    if (dgv.Rows[i].Cells[dgvSSSmComments.Index].Value == null)
                    {
                        dgv.Rows[i].Cells[dgvSSSmComments.Index].Value = "";
                    }
                    spd.comments = dgv.Rows[i].Cells[dgvSSSmComments.Index].Value.ToString().Trim();
                    spd.branchID = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmBranchID.Index].Value);
                    spd.breakSkid = 0;
                    if (dgv.Rows[i].Cells[dgvSSSmPieces.Index].Tag != null)
                    {
                        if (dgv.Rows[i].Cells[dgvSSSmPieces.Index].Tag.ToString().Equals("Break"))
                        {
                            //set to the original Piece Count;
                            spd.breakSkid = Convert.ToInt32(dgv.Rows[i].Cells[dgvSSSmBreakSkid.Index].Tag);
                        }
                    }
                    
                    //insert into database
                    InsertOrderPolishDtl(spd, tran);
                    
                }

                //message box saying done and give order number
                MessageBox.Show("Order " + ordHdrInfo.OrderID.ToString() + 
                                " (Master order " + ordHdrInfo.masterOrderID.ToString() + ") created.");


                dgv.Rows.Clear();
                //clear list

                listViewSSSmSkidData.BringToFront();
                buttonSSSmStartOrder.BringToFront();
                buttonSSSmAddOrder.Visible = false;
                buttonSSSmStartOrder.Visible = true;

               //go back to listview of skids.
               tran.Commit();
            }
            catch (Exception se)
            {

                MessageBox.Show(se.ToString());
                tran.Rollback();

            }

        }
        private int InsertOrderPolishDtl(SkidPolishDtl spd, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".orderPolishDtl ");
            sb.Append("([orderID], [skidID],[coilTagSuffix],[skidLetter],[orderLetter] ");
            sb.Append(",[orderPieceCount],[AlloyID],[previousFinishID],[newFinishID] ");
            sb.Append(",[pvc],[pvcPrice],[paper],[paperPrice],[lineMark],[lineMarkPrice],[comments],[branchID],[breakSkid]) ");
            sb.Append(" output INSERTED.orderID  VALUES ");
            sb.Append("(@orderID, @skidID,@coilTagSuffix,@skidLetter,@orderLetter ");
            sb.Append(",@orderPieceCount,@AlloyID,@previousFinishID,@newFinishID ");
            sb.Append(",@pvc,@pvcPrice,@paper,@paperPrice,@lineMark,@lineMarkPrice,@comments,@branchID,@breakSkid) ");
            


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction  = tran

            };
            cmd.Parameters.AddWithValue("@orderID", spd.orderID);
            cmd.Parameters.AddWithValue("@skidID", spd.skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", spd.coilTagSuffix.Trim());
            cmd.Parameters.AddWithValue("@skidLetter", spd.skidLetter.Trim());
            cmd.Parameters.AddWithValue("@orderLetter", spd.orderLetter.Trim());
            cmd.Parameters.AddWithValue("@orderPieceCount", spd.orderPieceCount);
            cmd.Parameters.AddWithValue("@AlloyID", spd.alloyID);
            cmd.Parameters.AddWithValue("@previousFinishID", spd.previousFinishID);
            cmd.Parameters.AddWithValue("@newFinishID", spd.newFinishID);
            cmd.Parameters.AddWithValue("@pvc", spd.PVC);
            cmd.Parameters.AddWithValue("@pvcPrice", spd.PVCPrice);
            cmd.Parameters.AddWithValue("@paper", spd.paper);
            cmd.Parameters.AddWithValue("@paperPrice", spd.paperPrice);
            cmd.Parameters.AddWithValue("@lineMark", spd.lineMark);
            cmd.Parameters.AddWithValue("@lineMarkPrice", spd.lineMarkPrice);
            cmd.Parameters.AddWithValue("@comments", spd.comments.Trim());
            cmd.Parameters.AddWithValue("@branchID", spd.branchID);
            cmd.Parameters.AddWithValue("@breakSkid", spd.breakSkid);

            int orderID = (int)cmd.ExecuteScalar();



            return orderID;

        }

        private void ButtonShipStart_Click(object sender, EventArgs e)
        {
            Shipping sh = new Shipping
            {
                custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                f1 = this,
                firstCustPO = true,
                branch = comboBoxBranchChooser.Text
            };
            sh.LoadItems();
            
            sh.Show();
        }

        private void ListViewShipSkid_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.ForeColor == Color.Blue)
            {
                e.Item.Checked = false;
            }
            else
            {
                CheckForShipItems();
            }
            

        }

        private void ListViewShipCoil_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.ForeColor == Color.Blue)
            {
                //don't allow to ship on an item that is already on a BOL
                e.Item.Checked = false;
            }
            else
            {
                CheckForShipItems();
            }
            
        }
        private void CheckForShipItems()
        {
            if (listViewShipCoil.CheckedItems.Count > 0||
                listViewShipSkid.CheckedItems.Count > 0)
            {
                buttonShipStart.BackColor = Color.Yellow;
                buttonShipStart.Enabled = true;
            }
            else
            {
                buttonShipStart.BackColor = Color.LightGray;
                buttonShipStart.Enabled = false;
            }
        }


        private void PanelSheetSheetDiff_VisibleChanged(object sender, EventArgs e)
        {
            if (panelSheetSheetDiff.Visible)
            {
                OrderCloning();
                AddOrderSSDInfo();
            }
            
        }

        private void ButtonSSDStartOrder_Click(object sender, EventArgs e)
        {

            // pricing$-good
            ProcPricingInfo procInfo = new ProcPricingInfo
            {
                MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag),
                TierLevel = Convert.ToInt32(ListViewCoilData.Tag)
            };

            if (listViewSSD.CheckedItems.Count > 0)
            {
                procInfo.SteelTypeID = Convert.ToInt32(listViewSSD.CheckedItems[0].SubItems[10].Tag);
                procInfo.fromWidth = Convert.ToDecimal(listViewSSD.CheckedItems[0].SubItems[5].Text);
                procInfo.fromThickness = Convert.ToDecimal(listViewSSD.CheckedItems[0].SubItems[4].Text);
            }
            else
            {
                MessageBox.Show("You must select at least one item to shear!");
                return;
            }

            textBoxSSDPrice.Text = GetProcPricing(procInfo).ToString();

            panelSSDOrderEntry.Visible = true;
            panelSSDOrderEntry.BringToFront();
            buttonSSDStartOrder.Visible = false;
            checkBoxCutFullSkids.Visible = false;
            buttonSSDAddOrder.Visible = true;
            
            buttonSSDCancelOrder.Width = buttonSSDStartOrder.Width;
            buttonSSDCancelOrder.Height = buttonSSDStartOrder.Height;
            buttonSSDCancelOrder.Top = buttonSSDStartOrder.Top;
            buttonSSDCancelOrder.Left = buttonSSDStartOrder.Left;
            buttonSSDCancelOrder.Anchor = buttonSSDStartOrder.Anchor;

            buttonSSDCancelOrder.Visible = true;
            
        }

        private void ButtonUpdateHoldDown_Click(object sender, EventArgs e)
        {
            if (IsNumber(textBoxHoldDown.Text) && !textBoxHoldDown.Text.Equals(""))
            {

                SetHoldDown(Convert.ToInt32(textBoxHoldDown.Text));
            }
            

        }

        private void ListViewSSD_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //is the item checked
            if (e.Item.Checked)
            {
                if (!e.Item.Checked && !e.Item.Focused)
                    return;

                if (e.Item.ForeColor == Color.Red)
                {
                    e.Item.Checked = false;
                    return;
                }
                if (checkBoxCutFullSkids.Checked == false)
                {
                    int cutpcs = 0;
                    //ask how many pieces
                    int pcs = Convert.ToInt32(e.Item.SubItems[2].Text);
                    if (InputBox.Show("How Many Pieces", "How Many Pieces will be sheared?", "How Many Pieces", out string output, pcs.ToString(), true) != DialogResult.Cancel)
                    {
                        if (IsNumber(output))
                        {
                            cutpcs = Convert.ToInt32(output);
                            if (cutpcs > pcs)
                            {
                                MessageBox.Show("You have more than " + pcs + " pieces!");
                                e.Item.Checked = false;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Must be numeric");
                        }

                        e.Item.SubItems[2].Tag = cutpcs;
                    }
                }
                else
                {
                    e.Item.SubItems[2].Tag = e.Item.SubItems[2].Text;
                }
                
                
            }
        }

        private void ButtonSSDAddOrder_Click(object sender, EventArgs e)
        {
            if (textBoxSSDPrice.Text.Length <= 0)
            {
                MessageBox.Show("Price Required.");
                textBoxSSDPrice.Focus();
                return;
            }
            if (textBoxSSDPurchaseOrder.Text.Length <= 0)
            {
                MessageBox.Show("Purchase Order Required.");
                textBoxSSDPurchaseOrder.Focus();
                return;
            }
            for (int i = 0; i < treeViewSSD.Nodes.Count; i++)
            {
                if (treeViewSSD.Nodes[i].Nodes.Count <= 0)
                {
                    MessageBox.Show("All Items must have cuts!");
                    treeViewSSD.SelectedNode = treeViewSSD.Nodes[i];
                    dgvSSDItems.Rows[i].Selected = true;
                    return;
                }
            }
            SqlTransaction tran = SQLConn.conn.BeginTransaction();
            try
            {
                
               

                //add order hdr

                
                OrderHdrInfo ordHdrInfo = new OrderHdrInfo
                {
                    masterOrderID = -1,
                    CustomerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag),
                    CustomerPO = textBoxSSDPurchaseOrder.Text.Trim(),
                    OrderDate = DateTime.Now.Date,
                    PromiseDate = dateTimePickerSSDPromiseDate.Value.Date,
                    Status = 1,
                    Comments = richTextBoxSSDComments.Text.Trim(),
                    runSheetComments = textBoxSSDRunSheetComments.Text
                };
                if (checkBoxSSDScrapCredit.Checked)
                {
                    ordHdrInfo.ScrapCredit = 1;
                }
                else
                {
                    ordHdrInfo.ScrapCredit = 0;

                }
                ordHdrInfo.CalculationType = 1;
                ordHdrInfo.ShipComments = "";
                ordHdrInfo.MachineID = Convert.ToInt32(tabControlMachines.SelectedTab.Tag);
                ordHdrInfo.ProcPrice = Convert.ToDecimal(textBoxSSDPrice.Text);
                ordHdrInfo.Posted = 0;
                ordHdrInfo.BreakIn = 0;
                ordHdrInfo.RunSheetOrder = DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                ordHdrInfo.MixHeats = 0;




                int orderID = AddOrderHdr(ordHdrInfo, tran);


                //add ordershearmaterial

                OrdShearMat osm = new OrdShearMat
                {
                    orderID = orderID
                };
                for (int i = 0; i < dgvSSDItems.Rows.Count; i++)
                {
                    osm.sourceID = i;

                    int skidcount = ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDSkidIDs.Index]).Items.Count;

                    for (int j = 0; j < skidcount; j++)
                    {
                        string[] skidInfo = ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDSkidIDs.Index]).Items[j].ToString().Split('.');

                        osm.skidID = Convert.ToInt32(skidInfo[0]);

                        osm.letter = skidInfo[skidInfo.Count() - 1];

                        osm.coilTagSuffix = ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDCoilTagSuffix.Index]).Items[j].ToString();

                        osm.origPCS = Convert.ToInt32(((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDOrigPcs.Index]).Items[j].ToString());

                        osm.cutPCS = Convert.ToInt32(((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDCutPcs.Index]).Items[j].ToString());

                        InsertOrderShearMaterial(osm,tran);
                    }



                    //add ordersheardtl

                    OrdShearDtl osd = new OrdShearDtl
                    {
                        orderID = orderID,
                        sourceID = osm.sourceID
                    };

                    foreach (TreeNode tn in treeViewSSD.Nodes[i].Nodes)
                    {

                        string[] cutinfo = tn.Text.ToString().Split(' ');

                        osd.PCS = Convert.ToInt32(cutinfo[0]);

                        string[] wl = cutinfo[2].Split('X');
                        osd.width = Convert.ToDecimal(wl[0]);
                        osd.length = Convert.ToDecimal(wl[1]);

                        osd.gauer = 0;
                        
                        if (cutinfo[cutinfo.Count() -1].ToString() == "*Gauer")
                        {
                            osd.gauer = 1;
                        }

                        InsertOrderShearDtl(osd, tran);

                    }

                }
                tran.Commit();
                MessageBox.Show("Order# " + orderID.ToString() + " created!");
                treeViewSSD.Nodes.Clear();
                dgvSSDItems.Rows.Clear();

                foreach (ListViewItem lv in listViewSSD.Items)
                {
                    if (lv.Checked)
                    {
                        lv.ForeColor = Color.Red;
                        lv.Checked = false;
                    }
                }
                buttonSSDStartOrder.Visible = false;
                buttonSSDAddOrder.Visible = true;
                checkBoxCutFullSkids.Visible = true;
                panelSSDOrderEntry.Visible = false;
                panelSSDOrderEntry.SendToBack();
                textBoxSSDPurchaseOrder.Text = "";
                textBoxSSDPrice.Text = "";
                textBoxSSDRunSheetComments.Text = "";
                

            }
            catch(Exception se)
            {
                MessageBox.Show(se.Message);
                tran.Rollback();
            }


        }

       
        private void ButtonAddCuts_Click(object sender, EventArgs e)
        {
            ShearInputBox sib = new ShearInputBox()
            {
                SOForm = this
            };
            

            sib.ShowDialog();
        }

        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSSD.Nodes)
            {
                for (int i = tn.Nodes.Count - 1; i >= 0; i--)
                {
                    tn.Nodes[i].Remove();
                }
            }
        }

        private void PanelSSDOrderEntry_VisibleChanged(object sender, EventArgs e)
        {
            if (panelSSDOrderEntry.Visible == true)
            {


                int cntr = 0;

                foreach (ListViewItem fn in GetShearSkids())
                {


                    //need to group by heat.
                    decimal width = Convert.ToDecimal(fn.SubItems[5].Text);
                    sheetDim.width = width;
                    sheetDim.length = Convert.ToDecimal(fn.SubItems[6].Text);
                    sheetDim.heat = fn.SubItems[9].Text;
                    sheetDim.pieceCount = Convert.ToInt32(fn.SubItems[2].Tag);
                    sheetDim.origPcs = Convert.ToInt32(fn.SubItems[2].Text);
                    sheetDim.alloy = fn.SubItems[3].Text;

                    string tagID = fn.SubItems[0].Text;
                    string coilTagSuffix = fn.SubItems[0].Tag.ToString();

                    if (cntr == 0)
                    {

                        dgvSSDItems.Rows.Add();
                        dgvSSDItems.Rows[cntr].Cells[dgvSSDHeat.Index].Value = sheetDim.heat;
                        dgvSSDItems.Rows[cntr].Cells[dgvSSDAlloy.Index].Value = sheetDim.alloy;
                        dgvSSDItems.Rows[cntr].Cells[dgvSSDPieceCount.Index].Value = sheetDim.pieceCount;
                        dgvSSDItems.Rows[cntr].Cells[dgvSSDWidth.Index].Value = sheetDim.width;
                        dgvSSDItems.Rows[cntr].Cells[dgvSSDLength.Index].Value = sheetDim.length;

                        ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDSkidIDs.Index]).Items.Add(tagID);
                        ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDCoilTagSuffix.Index]).Items.Add(coilTagSuffix);
                        ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDCutPcs.Index]).Items.Add(sheetDim.pieceCount);
                        ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDOrigPcs.Index]).Items.Add(sheetDim.origPcs);



                        dgvSSDItems.Rows[cntr].Cells[dgvSSDSkidIDs.Index].Value = tagID;



                        TreeNode tn = treeViewSSD.Nodes.Add(sheetDim.width + " " + sheetDim.length + " " + sheetDim.heat);
                        tn.Tag = sheetDim.width + " " + sheetDim.length + " " + sheetDim.pieceCount;
                        treeViewSSD.SelectedNode = tn;
                        cntr++;
                        
                    }
                    else
                    {
                        bool match = false;
                        for (int i = 0; i < cntr; i++)
                        {

                            if (sheetDim.width == Convert.ToDecimal(dgvSSDItems.Rows[i].Cells[dgvSSDWidth.Index].Value) &&
                                sheetDim.length == Convert.ToDecimal(dgvSSDItems.Rows[i].Cells[dgvSSDLength.Index].Value) &&
                                sheetDim.heat == dgvSSDItems.Rows[i].Cells[dgvSSDHeat.Index].Value.ToString()
                                )
                            {
                                string[] st = treeViewSSD.Nodes[i].Tag.ToString().Split(' ');
                                int pieces = Convert.ToInt32(st[2]);

                                ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDCutPcs.Index]).Items.Add(sheetDim.pieceCount);
                                ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDOrigPcs.Index]).Items.Add(sheetDim.origPcs);

                                sheetDim.pieceCount += pieces;
                                treeViewSSD.Nodes[i].Tag = st[0] + " " + st[1] + " " + sheetDim.pieceCount.ToString();

                                dgvSSDItems.Rows[i].Cells[dgvSSDPieceCount.Index].Value = sheetDim.pieceCount;
                                ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDSkidIDs.Index]).Items.Add(tagID);
                                ((DataGridViewComboBoxCell)dgvSSDItems.Rows[i].Cells[dgvSSDCoilTagSuffix.Index]).Items.Add(coilTagSuffix);
                                
                                match = true;
                            }


                        }

                        if (!match)
                        {
                            dgvSSDItems.Rows.Add();
                            dgvSSDItems.Rows[cntr].Cells[dgvSSDHeat.Index].Value = sheetDim.heat;
                            dgvSSDItems.Rows[cntr].Cells[dgvSSDAlloy.Index].Value = sheetDim.alloy;
                            dgvSSDItems.Rows[cntr].Cells[dgvSSDPieceCount.Index].Value = sheetDim.pieceCount;
                            dgvSSDItems.Rows[cntr].Cells[dgvSSDWidth.Index].Value = sheetDim.width;
                            dgvSSDItems.Rows[cntr].Cells[dgvSSDLength.Index].Value = sheetDim.length;

                            ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDSkidIDs.Index]).Items.Add(tagID);
                            ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDCoilTagSuffix.Index]).Items.Add(coilTagSuffix);
                            ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDCutPcs.Index]).Items.Add(sheetDim.pieceCount);
                            ((DataGridViewComboBoxCell)dgvSSDItems.Rows[cntr].Cells[dgvSSDOrigPcs.Index]).Items.Add(sheetDim.origPcs);


                            dgvSSDItems.Rows[cntr].Cells[dgvSSDSkidIDs.Index].Value = tagID;


                            TreeNode tn = treeViewSSD.Nodes.Add(sheetDim.width + " " + sheetDim.length + " " + sheetDim.heat);
                            tn.Tag = sheetDim.width + " " + sheetDim.length + " " + sheetDim.pieceCount;
                            cntr++;
                        }


                    }



                }
                for (int i = 0; i < treeViewSSD.Nodes.Count; i++)
                {
                    string[] st = treeViewSSD.Nodes[i].Tag.ToString().Split(' ');
                    treeViewSSD.Nodes[i].Text += " " + st[2];
                }
                if (treeViewSSD.Nodes.Count > 0)
                {
                    treeViewSSD.SelectedNode = treeViewSSD.Nodes[0];

                }
            }
        }

        private void ButtonFinished_Click(object sender, EventArgs e)
        {
            panelSSDOrderEntry.Visible = false;
            panelSSDOrderEntry.SendToBack();
        }

        private void TreeViewSSD_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo ht = treeViewSSD.HitTest(e.X, e.Y);
                if (ht.Node != null)
                {
                    treeViewSSD.SelectedNode = ht.Node;
                }

                contextMenuStripAddVertical.Show(Cursor.Position);
            }
        }

        

        private void ClearItem_Click(object sender, EventArgs e)
        {
            if (treeViewSSD.SelectedNode.Parent == null)
            {
                MessageBox.Show("Can't delete this line.");
            }
            else
            {
                treeViewSSD.SelectedNode.Remove();
            }
        }

        private void DgvSSDItems_SelectionChanged(object sender, EventArgs e)
        {
            if (treeViewSSD.Nodes.Count > 0)
            {
                int i = GetSelectedRow();
                if (i >= 0)
                {
                    treeViewSSD.SelectedNode = null;
                    treeViewSSD.Select();
                    treeViewSSD.SelectedNode = treeViewSSD.Nodes[i];
                    treeViewSSD.Select();
                }
                
            }
            
        }

        private void TreeViewSSD_Validating(object sender, CancelEventArgs e)
        {
            treeViewSSD.SelectedNode.BackColor = SystemColors.Highlight;
            treeViewSSD.SelectedNode.ForeColor = Color.White;
            previousSelectedNode = treeViewSSD.SelectedNode;
        }

        private void TreeViewSSD_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (previousSelectedNode != null)
            {
                previousSelectedNode.BackColor = treeViewSSD.BackColor;
                previousSelectedNode.ForeColor = treeViewSSD.ForeColor;
            }
        }

        private void TreeViewSSD_Enter(object sender, EventArgs e)
        {
            if (treeViewSSD.SelectedNode != null)
            {
                treeViewSSD.SelectedNode.BackColor = Color.Empty;
                treeViewSSD.SelectedNode.ForeColor = Color.Empty;
            }
        }

        private void TreeViewSSD_Leave(object sender, EventArgs e)
        {
            if (treeViewSSD.SelectedNode != null)
            {
                treeViewSSD.SelectedNode.BackColor = SystemColors.Highlight;
                treeViewSSD.SelectedNode.ForeColor = Color.White;
            }
        }

        private void TreeViewSSD_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = e.Node.Index;
            if (e.Node.Parent != null)
            {
 

                index = e.Node.Parent.Index;
            }
            dgvSSDItems.Rows[index].Selected = true;
        }

        private void ButtonSSDCancelOrder_Click(object sender, EventArgs e)
        {
            buttonSSDStartOrder.Visible = true ;
            buttonSSDAddOrder.Visible = true;
            buttonSSDCancelOrder.Visible = false;
            checkBoxCutFullSkids.Visible = true;
            panelSSDOrderEntry.Visible = false;
            panelSSDOrderEntry.SendToBack();
            textBoxSSDPurchaseOrder.Text = "";
            textBoxSSDPrice.Text = "";
            textBoxSSDRunSheetComments.Text = "";
            dgvSSDItems.Rows.Clear();
            treeViewSSD.Nodes.Clear();
        }

        private void ListViewShipCoil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonReleaseBOL_Click(object sender, EventArgs e)
        {
            GetReleaseInfo();
        }

        private void GetReleaseInfo()
        {
            bool oktogo = false;
            string output = "";
            while (!oktogo)
            {
                InputBox.Show("BOL Number", "Please Enter the BOL#", "Enter BOL#", out output, "",true );
                //check if it is a number
                if (IsNumber(output) && !output.Equals(""))
                {
                    oktogo = true;
                }
                else
                {
                    if (output.Equals(""))
                    {
                        return;
                    }
                    MessageBox.Show("You must enter a number!");
                }
                //lookup customer/items?
            }


            if (MessageBox.Show("Release BOL# " + output.Trim() +"?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ReleaseBOL(Convert.ToInt32(output));
            }
        }
        
        private int ReleaseBOL(int bolNumber)
        {
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            SqlTransaction tran =  db.StartTrans();
            try
            {

                //update shiphdr status
                int hcnt = db.UpdateShipHdrStatus(bolNumber, -1, tran);
                if (hcnt == 0)
                {
                    MessageBox.Show("BOL not found!");
                    tran.Rollback();
                    db.CloseSQLConn();
                    return -1;
                }

                //update shiphdr status
                db.UpdateShipDtlStatus(bolNumber, -1, tran);

                //update all skids
                int skidcnt = db.UpdateShipSkidStatus(bolNumber, -1, tran);

                //update all coils
                int coilcnt = db.UpdateShipCoilStatus(bolNumber, -1, tran);

                tran.Commit();
                db.CloseSQLConn();
                MessageBox.Show("BOL# " + bolNumber + " released (" + skidcnt + "-skids " + coilcnt + "-coils)");

            }
            catch (Exception se)
            {
                tran.Rollback();
                MessageBox.Show(se.Message);
                return -1;
            }

            DisplayCoilData(TreeViewCustomer.SelectedNode.Tag.ToString());
            DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());
            LoadShippingInfo();
            
            return 1;
        }

        private void ComboBoxBranchChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            string branch = (string)cb.SelectedItem;
            if (branch.Equals("All"))
            {
                LoadShippingInfo();
            }
            else
            {
                LoadShippingInfo(branch);
            }
            
        }

        private void CheckBoxShipModifyRel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShipModifyRel.Checked)
            {
                checkBoxShipModifyRel.Checked = false;

                InputBox.Show("BOL Modify", "Please enter the BOL#", "Bol Modify3", out string output, "", true);

                if (output.Equals(""))
                {
                    return;
                }

                Shipping sh = new Shipping
                {
                    f1 = this
                };
                DBUtils db = new DBUtils();

                db.OpenSQLConn();
                int custID = db.GetShipCust(Convert.ToInt32(output));
                db.CloseSQLConn();
                for(int i = 0;i < TreeViewCustomer.Nodes.Count; i++)
                {
                    if (Convert.ToInt32(TreeViewCustomer.Nodes[i].Tag) == custID)
                    {
                        TreeViewCustomer.SelectedNode.BackColor = Color.Empty;
                        TreeViewCustomer.SelectedNode.ForeColor = Color.Empty;

                        TreeViewCustomer.SelectedNode = TreeViewCustomer.Nodes[i];

                        TreeViewCustomer.SelectedNode.BackColor = SystemColors.Highlight;
                        TreeViewCustomer.SelectedNode.ForeColor = Color.White;

                        i = TreeViewCustomer.Nodes.Count;

                    }
                }

                bool ok = sh.ModifyBOL(Convert.ToInt32(output));
                if (ok)
                {
                    sh.Show();
                }
                else
                {
                    MessageBox.Show("The BOL was not found or has already been released.");
                }
                
            }
        }

        private void ButtonBuildTruck_Click(object sender, EventArgs e)
        {
            BuildATruck bd = new BuildATruck
            {
                f1 = this,
                customerID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag)
            };

            bd.Show();

        }

        private void test()
        {
            PrintLabels lb = new PrintLabels();

            lb.SkidLabelInfo.Location = "test";


            //lb.SkidLabel(LabelPrinters.tagPrinter);

            
        }

        private void ListViewCoilData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //ListViewCoilData.SelectedItems.Clear();
                //ListViewHitTestInfo hi = ListViewCoilData.HitTest(new Point(e.X + ((Control)sender).Left + 190, e.Y + ((Control)sender).Top + 80));
                ListViewHitTestInfo hi = ListViewCoilData.HitTest(e.Location);
                string tag = "";
                if (hi.Item == null)
                {
                    if (ListViewCoilData.Items.Count == 1)
                    {
                        ListViewCoilData.Items[0].Selected = true;
                        tag = ListViewCoilData.Items[0].SubItems[0].Text;
                    }
                    else
                    {
                        if (ListViewCoilData.Items.Count ==0)
                        {
                            return;
                        }
                        else
                        {
                            if (hi.Item == null)
                            {
                                return;
                            }
                            
                            tag = hi.Item.Text;
                        }
                    }

                }
                else
                {
                    
                    tag = hi.Item.Text;
                }
                transferCoilToolStripMenuItem.Tag = tag;
                transferCoilToolStripMenuItem.Text = "Transfer " + tag;
                contextMenuStrip2.Show(this, new Point(e.X + ((Control)sender).Left + 190, e.Y + ((Control)sender).Top + 80));
            }
        }

        private void toolMenuPrintLabel_Click(object sender, EventArgs e)
        {

            PrintCoilLabel();


        }
        private void PrintCoilLabel()
        {
            PrintLabels pl = new PrintLabels();

            pl.CoilLabelInfo.TagID = ListViewCoilData.SelectedItems[0].SubItems[hdrTagID.DisplayIndex].Text;
            pl.CoilLabelInfo.Alloy = ListViewCoilData.SelectedItems[0].SubItems[hdrAlloy.DisplayIndex].Text;
            pl.CoilLabelInfo.Carbon = Convert.ToDecimal(ListViewCoilData.SelectedItems[0].SubItems[hdrCarbon.DisplayIndex].Text);
            pl.CoilLabelInfo.CoilCount = Convert.ToInt32(ListViewCoilData.SelectedItems[0].SubItems[hdrCoilCount.DisplayIndex].Text);
            pl.CoilLabelInfo.COO = ListViewCoilData.SelectedItems[0].SubItems[hdrCountryOfOrigin.DisplayIndex].Text;
            pl.CoilLabelInfo.CustName = TreeViewCustomer.SelectedNode.Text;
            pl.CoilLabelInfo.Heat = ListViewCoilData.SelectedItems[0].SubItems[hdrHeat.DisplayIndex].Text;
            pl.CoilLabelInfo.Length = Convert.ToDecimal(ListViewCoilData.SelectedItems[0].SubItems[hdrLength.DisplayIndex].Text);
            pl.CoilLabelInfo.Location = ListViewCoilData.SelectedItems[0].SubItems[hdrLocation.DisplayIndex].Text;
            pl.CoilLabelInfo.MillNum = ListViewCoilData.SelectedItems[0].SubItems[hdrMillNum.DisplayIndex].Text;
            pl.CoilLabelInfo.PO = ListViewCoilData.SelectedItems[0].SubItems[hdrPONum.DisplayIndex].Text;
            pl.CoilLabelInfo.RecDate = ListViewCoilData.SelectedItems[0].SubItems[hdrRecDate.DisplayIndex].Text;
            pl.CoilLabelInfo.RecID = Convert.ToInt32(ListViewCoilData.SelectedItems[0].SubItems[hdrRecID.DisplayIndex].Text);
            pl.CoilLabelInfo.Thickness = Convert.ToDecimal(ListViewCoilData.SelectedItems[0].SubItems[hdrThickness.DisplayIndex].Text);
            pl.CoilLabelInfo.Type = Convert.ToInt32(ListViewCoilData.SelectedItems[0].SubItems[4].Tag);
            pl.CoilLabelInfo.Vendor = ListViewCoilData.SelectedItems[0].SubItems[hdrVendor.DisplayIndex].Text;
            pl.CoilLabelInfo.Weight = Convert.ToInt32(ListViewCoilData.SelectedItems[0].SubItems[hdrWeight.DisplayIndex].Text);
            pl.CoilLabelInfo.Width = Convert.ToDecimal(ListViewCoilData.SelectedItems[0].SubItems[hdrWidth.DisplayIndex].Text);

            pl.CoilLabel(LabelPrinters.tagPrinter);
        }

        private void printSkidLabel_MouseDown(object sender, MouseEventArgs e)
        {
            PrintSkidLabels();
        }

        private void PrintSkidLabels()
        {
            PrintLabels pl = new PrintLabels();

            pl.SkidLabelInfo.SkidID = -1;
            pl.SkidLabelInfo.SkidIDString = listViewSkidData.SelectedItems[0].SubItems[lvSkidID.DisplayIndex].Text;
            pl.SkidLabelInfo.Alloy = listViewSkidData.SelectedItems[0].SubItems[lvSkidAlloy.DisplayIndex].Text;
            pl.SkidLabelInfo.Carbon = 0;
            pl.SkidLabelInfo.Comments = listViewSkidData.SelectedItems[0].SubItems[lvSkidComments.DisplayIndex].Text;
            pl.SkidLabelInfo.COO = "";
            pl.SkidLabelInfo.CustName = TreeViewCustomer.SelectedNode.Text;
            pl.SkidLabelInfo.Gauge = Convert.ToDecimal(listViewSkidData.SelectedItems[0].SubItems[lvSkidThickness.DisplayIndex].Text);
            pl.SkidLabelInfo.Heat = listViewSkidData.SelectedItems[0].SubItems[lvSkidHeat.DisplayIndex].Text;
            pl.SkidLabelInfo.Length = Convert.ToDecimal(listViewSkidData.SelectedItems[0].SubItems[lvSkidLength.DisplayIndex].Text);
            pl.SkidLabelInfo.Location = listViewSkidData.SelectedItems[0].SubItems[lvSkidLocation.DisplayIndex].Text;
            pl.SkidLabelInfo.Mill = listViewSkidData.SelectedItems[0].SubItems[lvSkidMillNum.DisplayIndex].Text;
            pl.SkidLabelInfo.OrderID = Convert.ToInt32(listViewSkidData.SelectedItems[0].SubItems[1].Tag);
            pl.SkidLabelInfo.Pieces = Convert.ToInt32(listViewSkidData.SelectedItems[0].SubItems[lvPieceCount.DisplayIndex].Text);
            pl.SkidLabelInfo.PO = "";
            pl.SkidLabelInfo.RecDate = "";
            pl.SkidLabelInfo.TheoWeight = Convert.ToInt32(listViewSkidData.SelectedItems[0].SubItems[lvSkidWeight.DisplayIndex].Text);
            pl.SkidLabelInfo.Type = Convert.ToInt32(listViewSkidData.SelectedItems[0].SubItems[10].Tag);
            pl.SkidLabelInfo.Vendor = "";
            pl.SkidLabelInfo.Width = Convert.ToDecimal(listViewSkidData.SelectedItems[0].SubItems[lvSkidWidth.DisplayIndex].Text);

            pl.SkidLabel(LabelPrinters.tagPrinter);
        }

        
        private void btnReportReceiving_Click(object sender, EventArgs e)
        {
            if (txtReportRecieving.Text.Length > 0)
            {
                ReportGeneration rg = new ReportGeneration();

                rg.setReportDrive(MachineDefaults.ReportDrive);

                int rec = Convert.ToInt32(txtReportRecieving.Text);

                rg.Receiving(rec);
            }
            else
            {
                MessageBox.Show("Please enter a Receiver number");
                txtReportRecieving.Focus();
            }
            
        }

        private void txtReportRecieving_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            
        }

        private void cbReportDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            string selectedDrive = (string)cbReportDrive.SelectedItem;

            SetReportDrive(selectedDrive);
        }

        private void btnRepotShipping_Click(object sender, EventArgs e)
        {

            if (tbReportShipping.Text.Length > 0)
            {
                ReportGeneration rg = new ReportGeneration();

                rg.setReportDrive(MachineDefaults.ReportDrive);

                int ship = Convert.ToInt32(tbReportShipping.Text);

                rg.Shipping(ship);
            }
            else
            {
                MessageBox.Show("Please enter a Shipping number");
                tbReportShipping.Focus();
            }
        }

        private void tbReportShipping_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void ListViewCoilData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

            ListViewHitTestInfo info = ListViewCoilData.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            bool changesMade = false;
            if (item != null)
            {
                using (CoilUpdate cu = new CoilUpdate())
                {
                    TagParser tp = new TagParser();
                    tp.TagToBeParsed = item.SubItems[0].Text;
                    tp.ParseTag();


                    cu.CoilID = tp.TagID;
                    cu.CoilTagSuffix = tp.CoilTagSuffix;
                    cu.lvCoil = item;
                    cu.ChangesMade = false;

                    cu.ShowDialog(this);

                    changesMade = cu.ChangesMade;
                    
                } // Dispose form
                if (changesMade)
                {
                    DisplayCoilData(TreeViewCustomer.SelectedNode.Tag.ToString());

                    for (int i = 0; i < ListViewCoilData.Items.Count; i++)
                    {
                        if (ListViewCoilData.Items[i].SubItems[0].Text.Equals(item.SubItems[0].Text))
                        {
                            ListViewCoilData.Items[i].Selected = true;
                        }

                    }

                    if (MessageBox.Show("Would you like to print a new label?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrintCoilLabel();
                    }

                   
                }
                


            }


        }

        private void listViewSkidData_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            ListViewHitTestInfo info = listViewSkidData.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            bool changesMade = false;
            if (item != null)
            {
                using (SkidUpdate sd = new SkidUpdate())
                {
                    sd.lvSkidItem = item;
                    string[] skidstuff = item.SubItems[0].Text.Split('.');
                    int skidid = Convert.ToInt32(skidstuff[0]);
                    sd.SkidID = skidid;
                    sd.CoilTagSuffix = item.SubItems[0].Tag.ToString().Trim();
                    sd.SkidLetter = item.SubItems[5].Tag.ToString().Trim();

                    sd.changesMade = false;

                    sd.ShowDialog();

                    changesMade = sd.changesMade;


                    //sd.lvSkidItem = item;
                }

                if (changesMade)
                {
                    DisplaySkidData(TreeViewCustomer.SelectedNode.Tag.ToString());

                    for (int i = 0; i < listViewSkidData.Items.Count; i++)
                    {
                        if (listViewSkidData.Items[i].SubItems[0].Text.Equals(item.SubItems[0].Text))
                        {
                            listViewSkidData.Items[i].Selected = true;
                        }

                    }

                    if (MessageBox.Show("Would you like to print a new label?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PrintSkidLabels();
                    }

                   
                }
                   
            }


            //lvitem.SubItems[0].Tag = coilTagSuffix;
            //lvitem.SubItems[1].Tag = orderID;
            //lvitem.SubItems[3].Tag = alloyID;
            //lvitem.SubItems[4].Tag = finishID; //putting finishid in thickness tag. easist place to hide it....
            //lvitem.SubItems[5].Tag = letter;//had to put letter here
            //lvitem.SubItems[6].Tag = skidTypeID;
            //lvitem.SubItems[10].Tag = steelTypeID;//putting steeltype in comments

            //lvitem.SubItems[12].Tag = branchID;

        }

        private void listViewSkidData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo hi = listViewSkidData.HitTest(e.Location);
                if (hi.Item == null)
                {
                    return;
                }
                hi.Item.Selected = true;

                transferSkidToolStripMenuItem.Tag = hi.Item.Text;
                transferSkidToolStripMenuItem.Text = "Transfer " + hi.Item.Text;

                contextMenuStrip3.Show(this, new System.Drawing.Point(e.X + ((Control)sender).Left + 190, e.Y + ((Control)sender).Top + 80));
            }
        }

        private void btnSSMCancel_Click(object sender, EventArgs e)
        {
            dataGridViewSSSmSkid.Rows.Clear();
            dataGridViewSSSmSkid.SendToBack();
            buttonSSSmStartOrder.Visible = true;
            buttonSSSmAddOrder.Visible = false;
            for (int i = 0;i < listViewSSSmSkidData.CheckedItems.Count; i++)
            {
                listViewSSSmSkidData.CheckedItems[i].Checked = false;
                i--;
            }
        }

        private void listBoxPVCGroupList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            decimal price = 0;
            int groupID = (listBoxPVCGroupList.Items[listBoxPVCGroupList.SelectedIndex] as dynamic).Value;

            using (DbDataReader reader = db.GetPVCGroup(groupID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        price = reader.GetDecimal(reader.GetOrdinal("price"));
                    }
                }
                reader.Close();

            }

            //pricehere
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            //need to add default price
            bool keepgoing = false;
            while (!keepgoing)
            {
                result = InputBox.Show(
                "Enter PVC Price", "PVC Price",
                "Price",
                out string output, price.ToString(),true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;

                }
                else
                {
                    bool isValidDecimal = decimal.TryParse(output, out price);
                    if (isValidDecimal)
                    {
                        keepgoing = true;
                    }
                }
            }
            db.UpdatePVCGroupPrice (groupID, price);
            
        }

        private void btnReportWorkOrder_Click(object sender, EventArgs e)
        {
            if (tbReportWorkOrder.Text.Length > 0)
            {
                ReportGeneration rg = new ReportGeneration();

                int ordID = Convert.ToInt32(tbReportWorkOrder.Text);

                rg.WorkOrder(ordID);
            }
            
        }

        private void tbReportWorkOrder_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabControlSettings_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageWorkers)
            {
                LoadWorkerInfo();
            }
            
        }

        private void btAddCustomer_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();


            cust.ShowDialog();
            
            if (cust.DoAnything())
            {
                TreeViewCustomer.Nodes.Clear();
                ListViewCoilData.Items.Clear();
                LoadCustomers(checkBoxInactiveCustomers.Checked);
                DisplayCoilData(TreeViewCustomer.Nodes[0].Tag.ToString());
            }

            
        }

        private void btAddMachine_Click(object sender, EventArgs e)
        {
            MachineAdd md = new MachineAdd();

            md.ShowDialog();


        }

        private void richTextBoxSSSmComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxSSSmRunSheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxSSSmPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxCTLPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxCTLRunSheetComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void richTextBoxCTLComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void richTextBoxClClSameComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxClClSamePO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxSSDPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxSSDRunSheetComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void richTextBoxSSDComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void textBoxSSSmPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnReportInventory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int custID = 0;
            if (!chkBxReportInventoryAllCustomers.Checked)
            {
                custID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            }
            ReportGeneration rg = new ReportGeneration();

            rg.setReportDrive(MachineDefaults.ReportDrive);

            bool coils = true;
            bool skids = true;
            if (!chkBxInventoryCoils.Checked)
            {
                coils = false;
            }
            if (!chkBxInventorySkids.Checked)
            {
                skids = false;
            }

            if (!coils && !skids)
            {
                return;
            }
            List<int> CustIDs = new List<int>();
            //grab the customerIDs from the treeview list.  Already in alphabetical order.
            for (int i = 0;i< TreeViewCustomer.Nodes.Count; i++)
            {
                if (custID == 0)
                {
                    CustIDs.Add(Convert.ToInt32(TreeViewCustomer.Nodes[i].Tag));
                }
                else
                {
                    //only running report for current customer
                    CustIDs.Add(custID);
                    i = TreeViewCustomer.Nodes.Count;
                }
                    
            }

            rg.Inventory(coils, skids, CustIDs, lblInventoryUpdate);

            Cursor.Current = Cursors.Default;
        }

        private void listViewSSSmSkidData_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked && !e.Item.Focused)
                return; 

            if (e.Item.ForeColor == Color.Red)
            {
                e.Item.Checked = false;
                return;
            }
        }

        private void listViewClClDiff_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked && !e.Item.Focused)
                return;

            if (e.Item.ForeColor == Color.Red)
            {
                e.Item.Checked = false;
                return;
            }
        }

        private void listViewClClSame_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked && !e.Item.Focused)
                return;

            if (e.Item.ForeColor == Color.Red)
            {
                e.Item.Checked = false;
                return;
            }
        }

        private void chkBxReportInventoryAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInventoryLabel();
        }
        private void UpdateInventoryLabel()
        {
            if (chkBxReportInventoryAllCustomers.Checked)
            {
                lblInventoryUpdate.Text = "All Customers Selected";
            }
            else
            {
                lblInventoryUpdate.Text = TreeViewCustomer.SelectedNode.Text + " Selected.";
            }
        }

        
        private void transferCoilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string purchaseOrder = "";

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            while (purchaseOrder.Length < 1)
            {
                result = InputBox.Show(
                           "Enter Purchase Order", "Purchase Order",
                           "Purchase Order",
                           out string output, "", false, true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {

                    MessageBox.Show("Canceled");
                    return;

                }
                else
                {
                    purchaseOrder = output;
                    if (purchaseOrder.Length < 1)
                    {
                        MessageBox.Show("Purchase Order required");
                    }
                }
            }

            string strTagID = transferCoilToolStripMenuItem.Tag.ToString();

            TagParser tp = new TagParser();
            tp.TagToBeParsed = strTagID;
            tp.ParseTag();

            int tagID = tp.TagID;
            string coilTagSuffix = tp.CoilTagSuffix;

            int currCustID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            TransferItem tf = new TransferItem();

            for (int i = 0;i < TreeViewCustomer.Nodes.Count;i++)
            {
                int custid = Convert.ToInt32(TreeViewCustomer.Nodes[i].Tag);

                if (custid != currCustID)
                {
                    tf.addItem(TreeViewCustomer.Nodes[i].Text, custid);
                }
                
            }

            tf.ShowDialog();

            int newCustID = tf.getCustID();

            if (newCustID == -1)
            {
                return;
            }
            string newCustName = tf.getCustName();

            

            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            SqlTransaction tran = db.StartTrans();

            try
            {

                db.UpdateCoilCust(tagID, coilTagSuffix, newCustID, tran);

                int transferID = db.InsertTransfer(0, tagID, coilTagSuffix, "", currCustID, newCustID, purchaseOrder, DateTime.Now, tran);

                tran.Commit();

                ListViewCoilData.Items.Clear();
                DisplayCoilData(currCustID.ToString());

                MessageBox.Show(tagID + coilTagSuffix + " transferred to " + newCustName + " on transfer#" + transferID.ToString() + "!");
                ReportGeneration rg = new ReportGeneration();
                rg.TransferReport(transferID);
            
            }catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
                
            }
            db.CloseSQLConn();
        }

        private void transferSkidToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string purchaseOrder = "";

            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;

            while (purchaseOrder.Length < 1)
            {
                result = InputBox.Show(
                           "Enter Purchase Order", "Purchase Order",
                           "Purchase Order",
                           out string output, "", false, true);

                if (result != System.Windows.Forms.DialogResult.OK)
                {

                    MessageBox.Show("Canceled");
                    return;

                }
                else
                {
                    purchaseOrder = output;
                    if (purchaseOrder.Length < 1)
                    {
                        MessageBox.Show("Purchase Order required");
                    }
                }
            }

            string strTagID = transferSkidToolStripMenuItem.Tag.ToString();

            TagParser tp = new TagParser();
            tp.TagToBeParsed = strTagID;
            tp.ParseTag();

            int tagID = tp.TagID;
            string coilTagSuffix = tp.CoilTagSuffix;
            string skidLetter = tp.SkidLetter;

            int currCustID = Convert.ToInt32(TreeViewCustomer.SelectedNode.Tag);
            TransferItem tf = new TransferItem();

            for (int i = 0; i < TreeViewCustomer.Nodes.Count; i++)
            {
                int custid = Convert.ToInt32(TreeViewCustomer.Nodes[i].Tag);

                if (custid != currCustID)
                {
                    tf.addItem(TreeViewCustomer.Nodes[i].Text, custid);
                }

            }

            tf.ShowDialog();

            int newCustID = tf.getCustID();

            if (newCustID == -1)
            {
                return;
            }
            string newCustName = tf.getCustName();
            
            

            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            SqlTransaction tran = db.StartTrans();

            try
            {

                db.UpdateSkidCust(tagID, coilTagSuffix,skidLetter, newCustID, tran);

                int transferID = db.InsertTransfer(0, tagID, coilTagSuffix, skidLetter, currCustID, newCustID, purchaseOrder, DateTime.Now, tran);

                tran.Commit();

                listViewSkidData.Items.Clear();
                DisplaySkidData(currCustID.ToString());

                MessageBox.Show(tagID + coilTagSuffix + "." + skidLetter + " transferred to " + newCustName + " on transfer#" + transferID.ToString() + "!");

                ReportGeneration rg = new ReportGeneration();

                rg.TransferReport(transferID);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);

            }
            db.CloseSQLConn();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History ht = new History();
            string tag = transferCoilToolStripMenuItem.Tag.ToString();
            ht.setTagID(tag);

            ht.ShowDialog();
        }

        private void historyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            History ht = new History();
            string tag = transferSkidToolStripMenuItem.Tag.ToString();
            ht.setTagID(tag);

            ht.ShowDialog();
        }

        private void tbReportHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReportHistory_Click(object sender, EventArgs e)
        {
            History ht = new History();

       

            int tID = ht.setTagID(tbReportHistory.Text);
            if (tID < 0)
            {
                return;
            }
            ht.ShowDialog();

        }

        private void dataGridViewCLCLSame_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void TreeViewCustomer_Validating(object sender, CancelEventArgs e)
        {
            if (TreeViewCustomer.Nodes.Count > 0)
            {
                TreeViewCustomer.SelectedNode.BackColor = SystemColors.Highlight;
                TreeViewCustomer.SelectedNode.ForeColor = Color.White;
                previousSelectedNode = TreeViewCustomer.SelectedNode;

            }
            
        }

        private void LoadRunSheetShShSame(int machineID)
        {
            lvwRunSheet.Tag = tabControlOrderMachines.TabPages[machineID.ToString()].Text;

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            lvwRunSheet.Columns.Clear();

            lvwRunSheet.Columns.Add("Num");
            lvwRunSheet.Columns.Add("Thk");
            lvwRunSheet.Columns.Add("Width");
            lvwRunSheet.Columns.Add("Customer");
            lvwRunSheet.Columns.Add("Work Order");
            lvwRunSheet.Columns.Add("Tag");
            lvwRunSheet.Columns.Add("Location");
            lvwRunSheet.Columns.Add("Due Date");
            lvwRunSheet.Columns.Add("Weight");
            lvwRunSheet.Columns.Add("PVC");
            lvwRunSheet.Columns.Add("Paper");
            lvwRunSheet.Columns.Add("Comments");
            lvwRunSheet.Columns.Add("Skid Size");
            lvwRunSheet.Columns.Add("BRK");

            using (DbDataReader reader = db.GetShShRunSheet(machineID))
            {
                
                int rowCnt = 1;
                while (reader.Read())
                {
                    ListViewItem lv = new ListViewItem();
                    int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                    decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));
                    int runSheetOrder = reader.GetInt32(reader.GetOrdinal("runSheetOrder"));
                    string custName = reader.GetString(reader.GetOrdinal("ShortCustomerName")).Trim();
                    string Location = reader.GetString(reader.GetOrdinal("location")).Trim();
                    DateTime dueDate = reader.GetDateTime(reader.GetOrdinal("promiseDate"));
                    decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                    int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                    decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                    decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                    decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                    int skidWeight = Convert.ToInt32(sheetWeight * pieces);
                    if (sheetWeight <= 0)
                    {
                        MetalFormula mt = new MetalFormula();
                        skidWeight = Convert.ToInt32(mt.MetFormula(density, thk, length, width, pieces, 0));

                    }

                    int pvc = reader.GetInt32(reader.GetOrdinal("pvc"));
                    string strPVC = "N";
                    if (pvc > 0)
                    {
                        strPVC = "Y";
                    }
                    int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                    string strPaper = "N";
                    if (paper > 0)
                    {
                        strPaper = "Y";
                    }
                    int breakSkid = reader.GetInt32(reader.GetOrdinal("breakSkid"));
                    string brkSkid = "N";
                    if (breakSkid > 0)
                    {
                        brkSkid = "Y";
                    }
                    string comments = reader.GetString(reader.GetOrdinal("RunSheetComments")).Trim();

                    int skidID = reader.GetInt32(reader.GetOrdinal("skidID"));
                    string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                    string skidLetter = reader.GetString(reader.GetOrdinal("letter")).Trim();

                    lv.Text = rowCnt.ToString();
                    lv.Tag = runSheetOrder;
                    lv.SubItems.Add(thk.ToString("G29"));
                    lv.SubItems.Add(width.ToString("G29"));
                    lv.SubItems.Add(custName);
                    lv.SubItems.Add(orderID.ToString());
                    lv.SubItems.Add(skidID.ToString() + coilTagSuffix + "." + skidLetter);
                    lv.SubItems.Add(Location);
                    lv.SubItems.Add(dueDate.ToString("d"));
                    lv.SubItems.Add(skidWeight.ToString("G29"));
                    lv.SubItems.Add(strPVC);
                    lv.SubItems.Add(strPaper);
                    lv.SubItems.Add(comments);
                    lv.SubItems.Add(width.ToString("G29") + " X " + length.ToString("G29"));
                    lv.SubItems.Add(brkSkid);

                    lvwRunSheet.Items.Add(lv);

                    rowCnt++;
                }
                

            }
            for (int i = 0; i < lvwRunSheet.Columns.Count; i++)
            {
                lvwRunSheet.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwRunSheet.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void LoadRunSheetClSkSame (int machineID)
        {

            

            lvwRunSheet.Tag = tabControlOrderMachines.TabPages[machineID.ToString()].Text;

            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            lvwRunSheet.Columns.Clear();

            lvwRunSheet.Columns.Add("Num");
            lvwRunSheet.Columns.Add("Thk");
            lvwRunSheet.Columns.Add("Width");
            lvwRunSheet.Columns.Add("Customer");
            lvwRunSheet.Columns.Add("Work Order");
            lvwRunSheet.Columns.Add("Tag");
            lvwRunSheet.Columns.Add("Location");
            lvwRunSheet.Columns.Add("Due Date");
            lvwRunSheet.Columns.Add("Weight");
            lvwRunSheet.Columns.Add("PVC");
            lvwRunSheet.Columns.Add("Paper");
            lvwRunSheet.Columns.Add("Comments");
            lvwRunSheet.Columns.Add("Skid Size");
            lvwRunSheet.Columns.Add("CNT");

            using (DbDataReader reader = db.GetCTLRunSheet(machineID))
            {
                if (reader.HasRows)
                {

                    int prevOrd = -1;
                    int prevTag = -1;
                    string prevsuffix = "TEST FOR PREVIOUS";
                    int rowCnt = 1;
                    ListViewItem lv = new ListViewItem();
                    int colcnt = 0;
                    int maxskidCols = 1;
                    while (reader.Read())
                    {
                        
                        int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                        int coilTagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                        decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                        int skidCount = reader.GetInt32(reader.GetOrdinal("skidCount"));
                        int runSheetOrder = reader.GetInt32(reader.GetOrdinal("runSheetOrder"));

                        if (orderID != prevOrd || prevTag != coilTagID || !prevsuffix.Equals(coilTagSuffix))
                        {
                            if (prevOrd != -1)
                            {
                                lvwRunSheet.Items.Add(lv);
                                lv = new ListViewItem();
                                lvwRunSheet.Refresh();
                            }
                            

                            prevOrd = orderID;
                            prevTag = coilTagID;
                            prevsuffix = coilTagSuffix;

                            int sequenceNum = reader.GetInt32(reader.GetOrdinal("sequenceNumber"));
                            decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));
                           
                            string custName = reader.GetString(reader.GetOrdinal("ShortCustomerName")).Trim();
                            string Location = reader.GetString(reader.GetOrdinal("location")).Trim();
                            DateTime dueDate = reader.GetDateTime(reader.GetOrdinal("promiseDate"));
                            decimal weigth = reader.GetDecimal(reader.GetOrdinal("weight"));
                            int pvc = reader.GetInt32(reader.GetOrdinal("pvcGroupID"));
                            string strPVC = "N";
                            if (pvc > 0)
                            {
                                strPVC = "Y";
                            }
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            string strPaper = "N";
                            if (paper > 0)
                            {
                                strPaper = "Y";
                            }
                            string comments = reader.GetString(reader.GetOrdinal("RunSheetComments")).Trim();


                            
                            lv.Text = rowCnt.ToString();
                            lv.Tag = runSheetOrder;
                            lv.SubItems.Add(thk.ToString("G29"));
                            lv.SubItems.Add(width.ToString("G29"));
                            lv.SubItems.Add(custName);
                            lv.SubItems.Add(orderID.ToString());
                            lv.SubItems.Add(coilTagID.ToString() + coilTagSuffix);
                            lv.SubItems.Add(Location);
                            lv.SubItems.Add(dueDate.ToString("d"));
                            lv.SubItems.Add(weigth.ToString("G29"));
                            lv.SubItems.Add(strPVC);
                            lv.SubItems.Add(strPaper);
                            lv.SubItems.Add(comments);
                            lv.SubItems.Add(width.ToString("G29") + " X " + length.ToString("G29"));
                            lv.SubItems.Add(skidCount.ToString());
                            colcnt = 1;

                            
                            rowCnt++;
                        }
                        else
                        {
                            colcnt++;
                            if (colcnt > maxskidCols)
                            {
                                lvwRunSheet.Columns.Add("Skid Size");
                                lvwRunSheet.Columns.Add("CNT");
                                
                                maxskidCols = colcnt;
                            }
                            lv.SubItems.Add(width.ToString("G29") + " X " + length.ToString("G29"));
                            lv.SubItems.Add(skidCount.ToString());
                        }


                        


                        


                    }
                    lvwRunSheet.Items.Add(lv);
                }

            }

            for (int i = 0; i < lvwRunSheet.Columns.Count; i++)
            {
                lvwRunSheet.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvwRunSheet.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }

        }

        private void RunSheetSelected(int machineID, string procFunc)
        {
            //bobby
            prevRunSheetTabPage = machineID;
            lvwRunSheet.Items.Clear();
            switch (procFunc)
            {
                case ProcessFunction.ClClSame://coil polish
                    break;
                case ProcessFunction.ClSkSame:
                    LoadRunSheetClSkSame(machineID);
                    break;
                case ProcessFunction.ShShSame:
                    LoadRunSheetShShSame(machineID);
                    break;
                case ProcessFunction.ClClDiff:
                    break;
                case ProcessFunction.ShShDiff:
                    break;

            }
        }

        private void tabControlOrderMachines_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControlOrderMachines.TabCount > 0)
            {
                if (e.TabPage.Name.Equals("Print"))
                {
                    lvwRunSheet.Tag = tabControlOrderMachines.TabPages[prevRunSheetTabPage.ToString()].Text;
                    Cursor.Current = Cursors.WaitCursor;
                    ReportGeneration rg = new ReportGeneration();
                    rg.RunSheet(lvwRunSheet);
                    justPrintedRunSheet = true;
                    tabControlOrderMachines.SelectedTab = tabControlOrderMachines.TabPages[prevRunSheetTabPage.ToString()];

                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    if (!justPrintedRunSheet)
                    {
                        int machineID = Convert.ToInt32(e.TabPage.Name);
                        string procFunc = e.TabPage.Tag.ToString();
                        
                        RunSheetSelected(machineID, procFunc);
                    }
                    
                    justPrintedRunSheet = false;
                    
                }
                
            }
            

        }

        private void lvwRunSheet_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
            
        }

        private void lvwRunSheet_DragDrop(object sender, DragEventArgs e)
        {
            int targetIndex = lvwRunSheet.InsertionMark.Index;

            // If the insertion mark is not visible, exit the method.
            if (targetIndex == -1)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            RunSheetDropHappened = true;
            // If the insertion mark is to the right of the item with
            // the corresponding index, increment the target index.
            if (lvwRunSheet.InsertionMark.AppearsAfterItem)
            {
                targetIndex++;
            }

            // Retrieve the dragged item.
            ListViewItem draggedItem =
                (ListViewItem)e.Data.GetData(typeof(ListViewItem));
           
            
            
           
            int runsheetOrder = Convert.ToInt32(draggedItem.Tag);

            int rowCnt = 0;
            for (int i = 0; i < lvwRunSheet.Items.Count; i++)
            {
                int chkitem = Convert.ToInt32(lvwRunSheet.Items[i].Tag);
                if (chkitem == runsheetOrder)
                {
                    rowCnt++;
                }
            }
            
            List<int> removeList = new List<int>();
            bool found = false;
            for (int i = 0; i < lvwRunSheet.Items.Count; i++)
            {
                
                int chkitem = Convert.ToInt32(lvwRunSheet.Items[i].Tag);
                if (chkitem == runsheetOrder)
                {
                    found = true;
                    lvwRunSheet.Items.Insert(targetIndex, (ListViewItem)lvwRunSheet.Items[i].Clone());
                    lvwRunSheet.Refresh();
                    if (targetIndex <= i + rowCnt)
                    {
                        for (int j = 0; j < removeList.Count; j++)
                        {
                            removeList[j]++;
                        }
                        i++;
                    }
                    removeList.Add(i);
                    targetIndex++;
                }
                else
                {
                    if (found)
                    {
                        i = lvwRunSheet.Items.Count;
                    }
                }
            }

            for (int i = removeList.Count -1; i >= 0; i--)
            {
                int rm = removeList[i];
                lvwRunSheet.Items.Remove(lvwRunSheet.Items[rm]);

            }

            int prevORd = -1;
            int ordCntr = 1;

            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            for (int i = 0; i < lvwRunSheet.Items.Count; i++)
            {
                
                lvwRunSheet.Items[i].Selected = false;
                int ord = Convert.ToInt32(lvwRunSheet.Items[i].SubItems[4].Text);
                if (prevORd != ord)
                {
                    //update orderhdr.runsheetorder to ordCntr
                    db.UpdateRunSheetOrder(ord, ordCntr);
                    prevORd = ord;
                    ordCntr++;
                }
                lvwRunSheet.Items[i].Text = (i +1).ToString();
                
            }

            db.CloseSQLConn();

            Cursor.Current = Cursors.Default;


        }

        private void lvwRunSheet_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lvwRunSheet.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lvwRunSheet_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint =
            lvwRunSheet.PointToClient(new Point(e.X, e.Y));

            // Retrieve the index of the item closest to the mouse pointer.
            int targetIndex = lvwRunSheet.InsertionMark.NearestIndex(targetPoint);
            

            // Confirm that the mouse pointer is not over the dragged item.
            if (targetIndex > -1)
            {
                // Determine whether the mouse pointer is to the left or
                // the right of the midpoint of the closest item and set
                // the InsertionMark.AppearsAfterItem property accordingly.
                Rectangle itemBounds = lvwRunSheet.GetItemRect(targetIndex);
                if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    lvwRunSheet.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    lvwRunSheet.InsertionMark.AppearsAfterItem = false;
                }
            }

            // Set the location of the insertion mark. If the mouse is
            // over the dragged item, the targetIndex value is -1 and
            // the insertion mark disappears.
            label4.Text = targetIndex.ToString();
            label4.Refresh();
            if (targetIndex > -1)
            {
                int targetRunOrd = Convert.ToInt32(lvwRunSheet.Items[targetIndex].Tag);
                if (targetRunOrd == prevRunSheetOrder)
                {
                    targetIndex = -1;
                }
                if (targetIndex > -1)
                {
                    int topofOrd = -1;
                    for (int i = 0; i < lvwRunSheet.Items.Count; i++)
                    {
                        if (Convert.ToInt32(lvwRunSheet.Items[i].Tag) == targetRunOrd)
                        {
                            topofOrd = i;
                            i = lvwRunSheet.Items.Count;
                        }
                    }
                    targetIndex = topofOrd;
                }
                
            }
            
            lvwRunSheet.InsertionMark.Index = targetIndex;
        }

        private void lvwRunSheet_DragLeave(object sender, EventArgs e)
        {
            lvwRunSheet.InsertionMark.Index = -1;
        }

        private void tabControlOrderMachines_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (tabControlOrderMachines.TabPages[e.Index].Name.Equals("Print"))
            {
                //e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
                tabControlOrderMachines.TabPages[e.Index].BackColor = Color.Yellow;
            }
            else
            {
                tabControlOrderMachines.TabPages[e.Index].BackColor = Color.LightYellow;
            }


            TabPage page = tabControlOrderMachines.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void lvwRunSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!RunSheetDropHappened)
            {
                int selCnt = lvwRunSheet.SelectedItems.Count;
                if (selCnt == 1)
                {
                    int runSheetOrd = Convert.ToInt32(lvwRunSheet.SelectedItems[0].Tag);
                    prevRunSheetOrder = runSheetOrd;
                    int selIndex = lvwRunSheet.SelectedItems[0].Index;
                    for (int i = 0; i < lvwRunSheet.Items.Count; i++)
                    {
                        if (i != selIndex)
                        {
                            if (Convert.ToInt32(lvwRunSheet.Items[i].Tag) == runSheetOrd)
                            {
                                lvwRunSheet.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
            
           


        }

        private void lvwRunSheet_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                ListViewHitTestInfo info = lvwRunSheet.HitTest(e.Location);
                if (info.Item == null)
                {
                    return;
                }
                newRunSheetOrder = Convert.ToInt32(info.Item.Tag);
                int newIndex = info.Item.Index;
                if (newRunSheetOrder != prevRunSheetOrder)
                {

                    if (prevRunSheetOrder != -1)
                    {
                        for (int i = 0; i < lvwRunSheet.Items.Count; i++)
                        {
                            if (i != newIndex)
                            {
                                if (lvwRunSheet.Items[i].Selected)
                                {
                                    lvwRunSheet.Items[i].Selected = false;
                                }
                            }
                        }
                    }
                }
                

            }
        }

        private void lvwRunSheet_MouseUp(object sender, MouseEventArgs e)
        {
            RunSheetDropHappened = false;
        }

        private void tbReportTransferID_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbReportTransferTagID.Text = "";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void btnReportTransfer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ReportGeneration rg = new ReportGeneration();
            int retVal = -1;
            if (tbReportTransferID.Text.Length > 0)
            {
                int transferID = Convert.ToInt32(tbReportTransferID.Text);
                retVal = rg.TransferReport(transferID);
            }
            else
            {
                retVal = rg.TransferReport(-1, tbReportTransferTagID.Text);
            }
            
            if (retVal == -1)
            {
                MessageBox.Show("Transfer not found.");
            }
            Cursor.Current = Cursors.Default;
        }

        private void tbReportTransferTagID_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbReportTransferID.Text = "";
        }

        private void txtReportRecieving_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReportReceiving.PerformClick();
            }
        }

        private void tbReportShipping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRepotShipping.PerformClick();
            }
        }

        private void tbReportWorkOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReportWorkOrder.PerformClick();
            }
        }

        private void tbReportHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReportHistory.PerformClick();
            }
        }

        private void tbReportTransferID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReportTransfer.PerformClick();
            }
        }

        private void tbReportTransferTagID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReportTransfer.PerformClick();
            }
        }
    }
        
}




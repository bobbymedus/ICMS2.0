using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using static DesktopApp2.FormICMSMain;
using System.ComponentModel.Design;
using System.Windows.Forms.VisualStyles;
using System.Data;

namespace ICMS
{
    internal class ReportGeneration
    {

        private class Location
        {
            public string name;
            public string address;
            public string city;
            public string state;
            public string zip;
        }


        private List<PVCInfo> pvcInfo = new List<PVCInfo>();

        static bool IsFileOpen(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // The file does not exist
                return false;
            }

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }

        // The DllImport requires -- Using System.Runtime.InteropServices;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);

        static class ReportDrive
        {
            public static string reportDrive { get; set; }

        }
        private class coilRows
        {
            public int coilID;
            public int hRow;
        }

        public void setReportDrive(string letter)
        {

            ReportDrive.reportDrive = letter;
        }

        private void SaveFile(Excel._Workbook oWB, string filename, string Category)
        {
            string reportDrive = ReportDrive.reportDrive;
            string directoryPath = Path.Combine(reportDrive, "Reports");



            if (!Directory.Exists(directoryPath))
            {
                // Directory does not exist, create it
                Directory.CreateDirectory(directoryPath);
                Directory.CreateDirectory(directoryPath + "\\" + Category);

            }
            else
            {
                if (!Directory.Exists(directoryPath + "\\" + Category))
                {
                    Directory.CreateDirectory(directoryPath + "\\" + Category);
                }
            }


            string filePath = Path.Combine(directoryPath + "\\" + Category, filename);
            if (IsFileOpen(filePath))
            {


                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExt = Path.GetExtension(filePath);
                string directory = Path.GetDirectoryName(filePath);
                int suffix = 1;

                while (IsFileOpen(filePath))
                {
                    string newFileName = $"{fileName} ({suffix}){fileExt}";
                    filePath = Path.Combine(directory, newFileName);
                    suffix++;
                }

                oWB.SaveAs(filePath);



            }
            else
            {
                oWB.SaveAs(filePath);
            }





        }



        public void Receiving(int recID)
        {




            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            oXL = new Excel.Application();






            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oXL.ActiveWindow.DisplayGridlines = false;

            oSheet.get_Range("A1", "D1").Merge();

            oSheet.Cells[1, 1] = "Report from TSA Processing: ";
            oSheet.Cells[1, 6] = "Receive ID:";
            oSheet.Cells[1, 8] = recID;

            oSheet.get_Range("A6", "G6").Merge();
            oSheet.Cells[6, 1] = "Legend: CC=Coil Count     C/O=Country of Origin     C=Carbon";

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            DbDataReader reader = db.GetCoilReceiveData(recID);
            oSheet.get_Range("A3", "J3").Merge();
            oSheet.get_Range("A4", "E4").Merge();

            bool haveCoils = false;
            bool haveSkids = false;

            if (reader.HasRows)
            {
                haveCoils = true;

            }
            bool printHdr = false;

            int hRow = 8;
            if (haveCoils)
            {


                oRng = oSheet.get_Range("A" + hRow, "L" + hRow);


                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
                                    = Excel.XlLineStyle.xlDouble;
                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle
                                    = Excel.XlLineStyle.xlDouble;


                oSheet.Cells[hRow, 1] = "Tag ID";
                oSheet.Cells[hRow, 2] = "CC";
                oSheet.Cells[hRow, 3] = "Mill Num";
                oSheet.Cells[hRow, 4] = "Heat Num";
                oSheet.Cells[hRow, 5] = "C/O";
                oSheet.Cells[hRow, 6] = "C";
                oSheet.Cells[hRow, 7] = "Weight";
                oSheet.Cells[hRow, 8] = "Gauge";
                oSheet.Cells[hRow, 9] = "Width";
                oSheet.Cells[hRow, 10] = "Alloy";
                oSheet.Cells[hRow, 11] = "Type";
                oSheet.Cells[hRow, 12] = "Location";

                hRow++;


                List<coilRows> cra = new List<coilRows>();
                while (reader.Read())
                {
                    if (!printHdr)
                    {
                        oSheet.Cells[3, 1] = "We have received the following items for " + reader.GetString(reader.GetOrdinal("LongCustomerName"));
                        oSheet.Cells[4, 1] = "under your PO of " + reader.GetString(reader.GetOrdinal("purchaseOrder"));
                        printHdr = true;
                    }
                    string[] CoilInfo = new string[12];

                    //TagID
                    coilRows cr = new coilRows();
                    int coilID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                    cr.coilID = coilID;
                    cr.hRow = hRow;
                    cra.Add(cr);

                    CoilInfo[0] = coilID.ToString().Trim() + " " +
                                    reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                    //CoilCount
                    CoilInfo[1] = reader.GetInt32(reader.GetOrdinal("coilCount")).ToString().Trim();
                    //MillNum
                    CoilInfo[2] = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                    //HeatNum
                    CoilInfo[3] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    //C/O
                    CoilInfo[4] = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                    //C
                    CoilInfo[5] = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                    //Weight
                    CoilInfo[6] = reader.GetInt32(reader.GetOrdinal("origWeight")).ToString().Trim();
                    //Gauge
                    CoilInfo[7] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    //Width
                    CoilInfo[8] = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                    //Alloy
                    CoilInfo[9] = reader.GetString(reader.GetOrdinal("AlloyDesc")).ToString().Trim() + " " +
                                  reader.GetString(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                    //Type
                    CoilInfo[10] = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                    //Location
                    CoilInfo[11] = reader.GetString(reader.GetOrdinal("location")).Trim();

                    oSheet.get_Range("A" + hRow, "L" + hRow).Value2 = CoilInfo;
                    hRow++;

                }

                reader.Close();

                int cnt = 0;

                foreach (coilRows coilID in cra.ToArray())
                {
                    reader = db.GetCoilDamage(coilID.coilID);
                    coilID.hRow += cnt;
                    int dCnt = 0;
                    if (reader.HasRows)
                    {
                        if (dCnt == 0)
                        {
                            oSheet.Cells[coilID.hRow, 14] = "Damage:";
                            dCnt++;

                        }

                        while (reader.Read())
                        {
                            if (dCnt > 1)
                            {
                                oSheet.Rows[coilID.hRow + 1].Insert();
                                cnt++;
                            }
                            oSheet.Cells[coilID.hRow + dCnt - 1, 15] = reader.GetString(reader.GetOrdinal("damageDescription"));

                            dCnt++;
                        }

                    }
                    reader.Close();

                }



                hRow++;

                reader.Close();
            }






            hRow += 3;
            reader.Close();

            reader = db.GetSkidReceiveData(recID);

            if (reader.HasRows)
            {
                haveSkids = true;
            }

            if (haveSkids)
            {
                oRng = oSheet.get_Range("A" + hRow, "M" + hRow);

                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
                                            = Excel.XlLineStyle.xlDouble;
                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle
                                            = Excel.XlLineStyle.xlDouble;
                oSheet.Cells[hRow, 1] = "Skid ID";
                oSheet.Cells[hRow, 2] = "PC";
                oSheet.Cells[hRow, 3] = "Mill Num";
                oSheet.Cells[hRow, 4] = "Heat Num";
                oSheet.Cells[hRow, 5] = "C/O";
                oSheet.Cells[hRow, 6] = "C";
                oSheet.Cells[hRow, 7] = "Alloy";
                oSheet.Cells[hRow, 8] = "Gauge";
                oSheet.Cells[hRow, 9] = "Width";
                oSheet.Cells[hRow, 10] = "Length";
                oSheet.Cells[hRow, 11] = "Weight";
                oSheet.Cells[hRow, 12] = "Type";
                oSheet.Cells[hRow, 13] = "Location";


                hRow++;
                List<coilRows> cra = new List<coilRows>();
                while (reader.Read())
                {
                    if (!printHdr)
                    {
                        oSheet.Cells[3, 1] = "We have received the following items for " + reader.GetString(reader.GetOrdinal("LongCustomerName"));
                        oSheet.Cells[4, 1] = "under your PO of " + reader.GetString(reader.GetOrdinal("purchaseOrder"));
                        printHdr = true;
                    }
                    string[] SkidInfo = new string[13];

                    coilRows cr = new coilRows();

                    int coilID = reader.GetInt32(reader.GetOrdinal("skidID"));
                    cr.coilID = coilID;
                    cr.hRow = hRow;
                    cra.Add(cr);


                    //TagID
                    SkidInfo[0] = reader.GetInt32(reader.GetOrdinal("skidID")).ToString().Trim() + "-" +
                                    reader.GetString(reader.GetOrdinal("letter")).Trim();
                    //PieceCount
                    SkidInfo[1] = reader.GetInt32(reader.GetOrdinal("pieceCount")).ToString().Trim();
                    //MillNum
                    SkidInfo[2] = reader.GetString(reader.GetOrdinal("millNum")).Trim();
                    //HeatNum
                    SkidInfo[3] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    //C/O
                    SkidInfo[4] = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                    //C
                    SkidInfo[5] = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                    //Alloy
                    SkidInfo[6] = reader.GetString(reader.GetOrdinal("AlloyDesc")).ToString().Trim() + " " +
                                  reader.GetString(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                    //Gauge
                    SkidInfo[7] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    //Width
                    SkidInfo[8] = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                    //Length
                    SkidInfo[9] = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();

                    //Weight
                    SkidInfo[10] = reader.GetInt32(reader.GetOrdinal("weight")).ToString().Trim();



                    //Type
                    SkidInfo[11] = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                    //Location
                    SkidInfo[12] = reader.GetString(reader.GetOrdinal("location")).Trim();

                    oSheet.get_Range("A" + hRow, "M" + hRow).Value2 = SkidInfo;
                    hRow++;

                }

                reader.Close();



                int cnt = 0;

                foreach (coilRows coilID in cra.ToArray())
                {
                    reader = db.GetCoilDamage(coilID.coilID);
                    coilID.hRow += cnt;
                    int dCnt = 0;
                    if (reader.HasRows)
                    {
                        if (dCnt == 0)
                        {
                            oSheet.Cells[coilID.hRow, 14] = "Damage:";
                            dCnt++;

                        }

                        while (reader.Read())
                        {
                            if (dCnt > 1)
                            {
                                oSheet.Rows[coilID.hRow + 1].Insert();
                                cnt++;
                            }
                            oSheet.Cells[coilID.hRow + dCnt - 1, 15] = reader.GetString(reader.GetOrdinal("damageDescription"));

                            dCnt++;
                        }

                    }
                    reader.Close();

                }

                reader.Close();


            }

            oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


            oRng = oSheet.get_Range("A1", "M1");
            oRng.EntireColumn.AutoFit();

            db.CloseSQLConn();
            oXL.Visible = true;

            string filename = "Rec-" + recID + ".xlsx";

            SaveFile(oWB, filename, "Receiving");


        }

        private int ShippingCopyPage(Excel._Worksheet oSheet, int pages)
        {

            int bottomofPage = 63;
            int pasteRow = (bottomofPage * pages) + 1;
            int pasteRowBottom = pasteRow + 63;
            int numberOfRecordsPerPage = 17;
            Excel.Range oRng;

            Excel.HPageBreaks pageBreaks = (Excel.HPageBreaks)oSheet.HPageBreaks;
            Excel.Range range = (Excel.Range)oSheet.Rows[pasteRow];
            pageBreaks.Add(range);

            Excel.VPageBreaks pageVBreaks = (Excel.VPageBreaks)oSheet.VPageBreaks;
            oRng = (Excel.Range)oSheet.Columns["M"];
            pageVBreaks.Add(oRng);


            oRng = oSheet.Range["A1:L" + bottomofPage.ToString()];

            Excel.Range destinationRange = oSheet.Range["A" + pasteRow.ToString() + ":L" + pasteRowBottom.ToString()];
            oRng.Copy(destinationRange);
            for (int i = 1; i <= oRng.Rows.Count; i++)
            {
                destinationRange.Rows[i].RowHeight = oRng.Rows[i].RowHeight;
            }
            oRng = oSheet.Range["A" + (pasteRow + 22).ToString() + ":J" + (pasteRow + 22 + (numberOfRecordsPerPage * 2) - 1).ToString()];

            oRng.ClearContents();

            oSheet.Cells[pasteRow + 57, 3] = "=C58";
            oSheet.Cells[pasteRow + 57, 4] = "=D58";
            oSheet.Cells[pasteRow + 57, 5] = "=E58";

            return pasteRow + 22;
        }

        public void Shipping(int shipID)
        {
            /////*********TODO***********
            ///add coil release info
            ///Need to make it work with multiple pages.
            int totWeight = 0;
            string reportDrive = ReportDrive.reportDrive;
            string directoryPath = Path.Combine(reportDrive, "Reports\\Templates");

            string templatePath = Path.Combine(directoryPath, "BOL.xltx");

            // Create an instance of the Excel application
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;


            oXL = new Excel.Application();


            oWB = oXL.Workbooks.Open(templatePath);
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            // Disable alerts to prevent Excel from displaying prompts
            oXL.DisplayAlerts = false;

            // Open the template file


            //oXL.Visible  =true;
            oXL.ScreenUpdating = false;


            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            DbDataReader reader = db.GetLocationInfo();

            Location lc = new Location();

            while (reader.Read())
            {
                lc.name = reader.GetString(reader.GetOrdinal("LocationName")).Trim();
                lc.address = reader.GetString(reader.GetOrdinal("LocationAddress")).Trim();
                lc.state = reader.GetString(reader.GetOrdinal("LocationState")).Trim();
                lc.city = reader.GetString(reader.GetOrdinal("LocationCity")).Trim();
                lc.zip = reader.GetString(reader.GetOrdinal("LocationZip")).Trim();
            }

            reader.Close();

            oSheet.Cells[1, 1] = lc.name;
            oSheet.Cells[2, 1] = lc.address + ", " + lc.city + ", " + lc.state + ", " + lc.zip;
            oSheet.Cells[7, 2] = lc.city + ", " + lc.state;

            bool withCust = true;
            int skidcount = 0;
            int coilcount = 0;
            bool headerInfo = false;
            bool foundInfo = false;
            int row = 23;
            int recordcount = 0;
            int pagecount = 0;

            int weight = 0;

            oSheet.Cells[61, 10] = "*" + shipID.ToString().Trim() + "*";


            reader = db.GetShipCoilDtls(shipID, withCust);

            if (reader.HasRows)
            {
                foundInfo = true;
                while (reader.Read())
                {



                    if (recordcount > 16)
                    {
                        pagecount++;
                        recordcount = 0;
                        row = ShippingCopyPage(oSheet, pagecount);

                        //next page needed
                    }
                    if (!headerInfo)
                    {
                        oSheet.Cells[4, 11] = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                        oSheet.Cells[21, 2] = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                        oSheet.Cells[5, 11] = reader.GetString(reader.GetOrdinal("custPO")).Trim();

                        oSheet.Cells[16, 2] = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim();
                        oSheet.Cells[17, 2] = reader.GetString(reader.GetOrdinal("Address1")).Trim();
                        oSheet.Cells[18, 2] = reader.GetString(reader.GetOrdinal("CUCITY")).Trim() + ", " +
                                                reader.GetString(reader.GetOrdinal("StateCode")).Trim() + ", " +
                                                reader.GetString(reader.GetOrdinal("CUZIP")).Trim();

                        oSheet.Cells[16, 7] = reader.GetString(reader.GetOrdinal("destination")).Trim();
                        oSheet.Cells[17, 7] = reader.GetString(reader.GetOrdinal("deliveryAddress")).Trim();
                        oSheet.Cells[18, 7] = reader.GetString(reader.GetOrdinal("SHCity")).Trim() + ", " +
                                                reader.GetString(reader.GetOrdinal("State")).Trim() + ", " +
                                                reader.GetString(reader.GetOrdinal("SHzip")).Trim();
                        headerInfo = true;
                    }

                    oSheet.Cells[row, 1] = "PO#";
                    oSheet.Cells[row, 2] = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                    oSheet.Cells[row, 3] = "Mill#";
                    oSheet.Cells[row, 4] = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                    oSheet.Cells[row, 5] = "Count =";
                    oSheet.Cells[row, 6] = reader.GetInt32(reader.GetOrdinal("coilCount")).ToString().Trim();
                    oSheet.Cells[row, 7] = "Heat#";
                    oSheet.Cells[row, 8] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    weight = reader.GetInt32(reader.GetOrdinal("weight"));
                    totWeight += weight;
                    oSheet.Cells[row, 9] = weight.ToString().Trim();
                    oSheet.Cells[row, 10] = "Coil";
                    oSheet.Cells[row + 1, 1] = "Tag# " +
                                                reader.GetInt32(reader.GetOrdinal("coilTagID")).ToString().Trim() +
                                                reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                    oSheet.Cells[row + 1, 3] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    oSheet.Cells[row + 1, 4] = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim() + " " +
                                                reader.GetString(reader.GetOrdinal("FinishDesc"));
                    oSheet.Cells[row + 1, 5] = reader.GetDecimal(reader.GetOrdinal("Width")).ToString("G29").Trim();
                    oSheet.Cells[row + 1, 6] = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();

                    row += 2;
                    coilcount++;
                    recordcount++;


                }
                oSheet.Cells[58, 4] = coilcount;
            }



            reader.Close();



            reader = db.GetShipSkidlDtls(shipID, withCust);


            if (reader.HasRows)
            {
                foundInfo = true;
                while (reader.Read())
                {



                    if (recordcount > 16)
                    {
                        pagecount++;
                        recordcount = 0;
                        row = ShippingCopyPage(oSheet, pagecount);
                        //next page needed
                    }
                    if (!headerInfo)
                    {
                        oSheet.Cells[4, 11] = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                        oSheet.Cells[21, 2] = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                        oSheet.Cells[5, 11] = reader.GetString(reader.GetOrdinal("custPO")).Trim();

                        oSheet.Cells[16, 2] = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim();
                        oSheet.Cells[17, 2] = reader.GetString(reader.GetOrdinal("Address1")).Trim();
                        oSheet.Cells[18, 2] = reader.GetString(reader.GetOrdinal("CUCITY")).Trim() + ", " +
                                              reader.GetString(reader.GetOrdinal("StateCode")).Trim() + ", " +
                                              reader.GetString(reader.GetOrdinal("CUZIP")).Trim();

                        oSheet.Cells[16, 7] = reader.GetString(reader.GetOrdinal("destination")).Trim();
                        oSheet.Cells[17, 7] = reader.GetString(reader.GetOrdinal("deliveryAddress")).Trim();
                        oSheet.Cells[18, 7] = reader.GetString(reader.GetOrdinal("SHCity")).Trim() + ", " +
                                              reader.GetString(reader.GetOrdinal("State")).Trim() + ", " +
                                              reader.GetString(reader.GetOrdinal("SHzip")).Trim();
                        headerInfo = true;

                    }

                    oSheet.Cells[row, 1] = "PO#";
                    oSheet.Cells[row, 2] = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                    oSheet.Cells[row, 3] = "Mill#";
                    oSheet.Cells[row, 4] = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                    oSheet.Cells[row, 5] = "Count =";
                    oSheet.Cells[row, 6] = reader.GetInt32(reader.GetOrdinal("pieceCount")).ToString().Trim();
                    oSheet.Cells[row, 7] = "Heat#";
                    oSheet.Cells[row, 8] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    weight = reader.GetInt32(reader.GetOrdinal("weight"));
                    totWeight += weight;


                    oSheet.Cells[row, 9] = weight.ToString().Trim();
                    oSheet.Cells[row, 10] = "Skid";
                    oSheet.Cells[row + 1, 1] = "Tag# " +
                                                reader.GetInt32(reader.GetOrdinal("skidID")).ToString().Trim() +
                                                reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim() + "-" +
                                                reader.GetString(reader.GetOrdinal("letter")).ToString().Trim(); ;
                    oSheet.Cells[row + 1, 3] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    oSheet.Cells[row + 1, 4] = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim() + " " +
                                                reader.GetString(reader.GetOrdinal("FinishDesc"));
                    oSheet.Cells[row + 1, 5] = reader.GetDecimal(reader.GetOrdinal("Width")).ToString("G29").Trim();
                    oSheet.Cells[row + 1, 6] = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();

                    row += 2;
                    skidcount++;
                    recordcount++;

                }
                oSheet.Cells[58, 3] = skidcount;
            }

            if (!foundInfo)
            {



                reader.Close();

                if (oXL != null)
                {
                    int excelProcessId = 0;

                    //your Excel Application variable has access to its Hwnd property
                    GetWindowThreadProcessId(new IntPtr(oXL.Hwnd), ref excelProcessId);

                    // you need System.Diagnostics to use Process Class
                    Process ExcelProc = Process.GetProcessById(excelProcessId);

                    if (ExcelProc != null)
                    {
                        ExcelProc.Kill();
                    }
                }

                MessageBox.Show("No records found for " + shipID.ToString());
                return;
            }
            reader.Close();

            oSheet.Cells[58, 5] = totWeight;

            oXL.ScreenUpdating = true;
            oXL.Visible = true;
        }


        public void WorkOrder(int orderID)
        {



            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            string custPO = "";
            string customername = "";
            string contact = "";
            string phone = "";
            string orderdate = "";
            string promisedate = "";
            string processFunction = "";
            string hdrComments = "";
            int status = -9999;
            string packaging = "";


            using (DbDataReader reader = db.GetOrderHdr(orderID))
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        custPO = reader.GetString(reader.GetOrdinal("CustomerPO")).Trim(); ;
                        customername = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim();
                        contact = reader.GetString(reader.GetOrdinal("ContactName")).Trim();
                        phone = reader.GetString(reader.GetOrdinal("phone")).Trim();
                        orderdate = reader.GetDateTime(reader.GetOrdinal("orderDate")).ToString("M/dd/yyyy");
                        promisedate = reader.GetDateTime(reader.GetOrdinal("PromiseDate")).ToString("M/dd/yyyy");
                        processFunction = reader.GetString(reader.GetOrdinal("processFunction")).Trim();
                        status = reader.GetInt32(reader.GetOrdinal("status"));
                        hdrComments = reader.GetString(reader.GetOrdinal("comments"));
                        packaging = reader.GetString(reader.GetOrdinal("Packaging"));
                    }
                }
                else
                {
                    MessageBox.Show("Order " + orderID.ToString() + " not found!");
                    return;
                }
                reader.Close();
            }

            db.CloseSQLConn();

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            oXL = new Excel.Application();






            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oXL.ActiveWindow.DisplayGridlines = false;





            oSheet.Columns[1].ColumnWidth = 10.22;//A
            oSheet.Columns[2].ColumnWidth = 2.89;//B
            oSheet.Columns[3].ColumnWidth = 7.22;//C
            oSheet.Columns[4].ColumnWidth = 1.22;//D
            oSheet.Columns[5].ColumnWidth = 6.11;//E
            oSheet.Columns[6].ColumnWidth = 1.78;//F
            oSheet.Columns[7].ColumnWidth = 3.33;//G
            oSheet.Columns[8].ColumnWidth = 5;//H
            oSheet.Columns[9].ColumnWidth = 5.22;//I
            oSheet.Columns[10].ColumnWidth = 5.78;//J
            oSheet.Columns[11].ColumnWidth = 1.56;//K
            oSheet.Columns[12].ColumnWidth = 7.22;//L
            oSheet.Columns[13].ColumnWidth = 2.89;//M
            oSheet.Columns[14].ColumnWidth = 3.56;//N
            oSheet.Columns[15].ColumnWidth = 3.56;//O
            oSheet.Columns[16].ColumnWidth = 3.78;//P
            oSheet.Columns[17].ColumnWidth = 3.89;//Q
            oSheet.Columns[18].ColumnWidth = 7.89;//R
            oSheet.Columns[19].ColumnWidth = 13.89;//S
            oSheet.Columns[20].ColumnWidth = 8.11;//T
            oSheet.Columns[21].ColumnWidth = 8.11;//U
            oSheet.Columns[22].ColumnWidth = 8.11;//V

            oSheet.Rows[1].RowHeight = 13.22;
            oSheet.Rows[2].RowHeight = 6;
            oSheet.Rows[3].RowHeight = 13.22;
            oSheet.Rows[4].RowHeight = 6;
            oSheet.Rows[5].RowHeight = 13.22;
            oSheet.Rows[6].RowHeight = 15;



            MergeCellAddBox(oSheet, "A1", "B1", "Customer");

            MergeCellAddBox(oSheet, "C1", "D1", "");
            MergeCellAddBox(oSheet, "E1", "E1", "PO#");
            MergeCellAddBox(oSheet, "F1", "I1", "", true);
            MergeCellAddBox(oSheet, "J1", "K1", "Order#");
            MergeCellAddBox(oSheet, "L1", "L1", "", true);
            MergeCellAddBox(oSheet, "T1", "T1", "Date");


            MergeCellAddBox(oSheet, "A3", "F3", "", true);
            MergeCellAddBox(oSheet, "H3", "J3", "", true);
            MergeCellAddBox(oSheet, "L3", "P3", "", true);

            MergeCellAddBox(oSheet, "A5", "B5", "OrderDate");
            MergeCellAddBox(oSheet, "C5", "D5", "", true);
            MergeCellAddBox(oSheet, "F5", "I5", "Promise Date");
            MergeCellAddBox(oSheet, "J5", "L5", "", true);
            


            MergeCellAddBox(oSheet, "A7", "A7", "Tag", true);
            MergeCellAddBox(oSheet, "B7", "D7", "Alloy", true);
            MergeCellAddBox(oSheet, "E7", "E7", "Thick", true);
            MergeCellAddBox(oSheet, "F7", "G7", "Width", true);
            MergeCellAddBox(oSheet, "H7", "I7", "Skid Wgt", true);
            MergeCellAddBox(oSheet, "J7", "K7", "Scrap", true);
            MergeCellAddBox(oSheet, "L7", "L7", "BegWgt", true);
            MergeCellAddBox(oSheet, "M7", "N7", "EndWgt", true);
            MergeCellAddBox(oSheet, "O7", "P7", "Location", true);
            MergeCellAddBox(oSheet, "Q7", "R7", "Heat#", true);
            MergeCellAddBox(oSheet, "S7", "S7", "Mill#", true);

            MergeCellAddBox(oSheet, "A8", "A8", "", true);
            MergeCellAddBox(oSheet, "B8", "D8", "", true);
            MergeCellAddBox(oSheet, "E8", "E8", "", true);
            MergeCellAddBox(oSheet, "F8", "G8", "", true);
            MergeCellAddBox(oSheet, "H8", "I8", "", true);
            MergeCellAddBox(oSheet, "J8", "K8", "", true);
            MergeCellAddBox(oSheet, "L8", "L8", "", true);
            MergeCellAddBox(oSheet, "M8", "N8", "", true);
            MergeCellAddBox(oSheet, "O8", "P8", "", true);
            MergeCellAddBox(oSheet, "Q8", "R8", "", true);
            MergeCellAddBox(oSheet, "S8", "S8", "", true);

            MergeCellAddBox(oSheet, "L10", "L10", "Status");

            string ordStatus = "Open";
            if (status < 0)
            {
                ordStatus = "Closed";
            }
            MergeCellAddBox(oSheet, "M10", "N10", ordStatus, true);

            MergeCellAddBox(oSheet, "A12", "G14", packaging, true);
            oSheet.Range["A12"].Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop ;
            oSheet.Range["A12"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.Range["A12"].WrapText = true;
           
            
            MergeCellAddBox(oSheet, "I12", "P14", hdrComments, true);
            oSheet.Range["I12"].Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
            oSheet.Range["I12"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.Range["A12"].WrapText = true;

            
            bool CTL = false;
            if (processFunction == ProcessFunction.ClSkSame)
            {
                CTL = true;
            }

            MergeDataRow(oSheet, 16, true, true);
            MergeDataRow(oSheet, 17);

            MergeCellAddBox(oSheet, "O15", "Q15", "RA Readings");






            string cellPO = "F1";
            string cellOrdID = "L1";
            string cellCustName = "A3";
            string cellContact = "H3";
            string cellPhone = "L3";
            string cellOrdDate = "C5";
            string cellPromiseDt = "J5";

            

            oSheet.get_Range(cellPO, cellPO).Value = custPO;
            oSheet.get_Range(cellCustName, cellCustName).Value = customername ;
            oSheet.get_Range(cellOrdID, cellOrdID).Value = orderID ;
            oSheet.get_Range(cellContact, cellContact).Value = contact;
            oSheet.get_Range(cellPhone, cellPhone).Value = phone;
            oSheet.get_Range(cellOrdDate, cellOrdDate).Value = orderdate ;
            oSheet.get_Range(cellPromiseDt, cellPromiseDt).Value = promisedate;

            

            switch (processFunction)
            {
                case ProcessFunction.ClClSame://coil polish
                    break;
                case ProcessFunction.ClSkSame://cut to length
                    WorkOrderClskSame(orderID, oSheet, status);
                    break;
                case ProcessFunction.ClClDiff://slitter
                    break;
                case ProcessFunction.ShShSame://sheet polish/buff
                    WorkOrderShShSame(orderID, oSheet, status);
                    break;
                case ProcessFunction.ShShDiff:
                    break;
            }

            oXL.ScreenUpdating = true;
            oXL.Visible = true;


        }

        public void WorkOrderClskSame(int orderID, _Worksheet oSheet, int status)
        {
            DBUtils db  = new DBUtils();

            db.OpenSQLConn();

            string prevCoilTagSuffix = "";
            string prevSkidLetter = "";
            
            int firstHeaderRow = 8;
            int firstDtlRow = 17;
            bool addRow = true;
            List<int> coilIDs = new List<int>();
            List<string> coilSuffix = new List<string>();
            List<decimal> skidWeigts = new List<decimal>();

            if (status < 0)
            {
                using (DbDataReader reader = db.GetSkidHistory(-1, null, orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int pvc = reader.GetInt32(reader.GetOrdinal("pvcID"));
                            if (pvc > 0)
                            {
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "YES", true);
                            }
                            else
                            {
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "NO", true);
                            }
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            if (paper > 0)
                            {
                                MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "Y", true);
                            }
                            else
                            {
                                MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "N", true);
                            }
                            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                            MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), length.ToString("G29"), true);

                            int orderedPCS = reader.GetInt32(reader.GetOrdinal("orderedPieceCount"));
                            MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "E" + firstDtlRow.ToString(), orderedPCS.ToString(), true);

                            int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                            MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), pieces.ToString(), true);

                            int coilTagID = reader.GetInt32(reader.GetOrdinal("skidID"));
                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                            string skidLetter = reader.GetString(reader.GetOrdinal("letter")).Trim();

                            coilIDs.Add(coilTagID);
                            coilSuffix.Add(coilTagSuffix);

                            string skidID = coilTagID.ToString() + coilTagSuffix + "." + skidLetter;
                            MergeCellAddBox(oSheet, "H" + firstDtlRow.ToString(), "I" + firstDtlRow.ToString(), skidID, true);

                            decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                            string weight = "";
                            if (sheetWeight > 0)
                            {
                                decimal w = sheetWeight * pieces;
                                skidWeigts.Add(w);
                                weight = Math.Round(w).ToString();

                            }
                            else
                            {
                                decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));

                                MetalFormula mt = new MetalFormula();
                                decimal t = reader.GetDecimal(reader.GetOrdinal("thickness"));
                                decimal w = reader.GetDecimal(reader.GetOrdinal("width"));

                                w = mt.MetFormula(density, t, length, w, pieces, 0);
                                skidWeigts.Add(w);
                                weight = Math.Round(w).ToString();
                            }

                            MergeCellAddBox(oSheet, "J" + firstDtlRow.ToString(), "K" + firstDtlRow.ToString(), weight, true);

                            decimal diag = reader.GetDecimal(reader.GetOrdinal("diagnol1"));
                            MergeCellAddBox(oSheet, "L" + firstDtlRow.ToString(), "L" + firstDtlRow.ToString(), diag.ToString("G29"), true);

                            diag = reader.GetDecimal(reader.GetOrdinal("diagnol2"));
                            MergeCellAddBox(oSheet, "M" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), diag.ToString("G29"), true);

                            decimal mic = reader.GetDecimal(reader.GetOrdinal("mic1"));
                            MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), mic.ToString("G29"), true);

                            mic = reader.GetDecimal(reader.GetOrdinal("mic2"));
                            MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), mic.ToString("G29"), true);

                            mic = reader.GetDecimal(reader.GetOrdinal("mic3"));
                            MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), mic.ToString("G29"), true);

                            string comments = reader.GetString(reader.GetOrdinal("comments"));
                            MergeCellAddBox(oSheet, "R" + firstDtlRow.ToString(), "V" + firstDtlRow.ToString(), comments, true);
                            firstDtlRow++;
                        }
                    }
                }
            }
            else
            {
                //open order get CTLDetail information
                SkidSetup sp = new SkidSetup();
                int prevTagID = -999;
                string prevSuffix = "";
                string skidLetter = "A";
                int TagCntr = -1;
                using (DbDataReader reader = db.GetCTLDetails(orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int coilTagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim() ;
                            coilIDs.Add(coilTagID);
                            coilSuffix.Add(coilTagSuffix);
                            TagCntr++;
                            if (prevTagID == -999)
                            {
                                prevTagID = coilTagID;
                                prevSuffix = coilTagSuffix;
                                string maxLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                                if (maxLetter.Equals(""))
                                {
                                    maxLetter = "A";
                                }
                                sp.SetFirstLetter(maxLetter);
                                skidLetter = maxLetter;
                                
                            }
                            else
                            {
                                if (coilTagID != prevTagID || !coilTagSuffix.Equals(prevCoilTagSuffix))
                                {
                                    prevTagID = coilTagID;
                                    prevSuffix = coilTagSuffix;
                                    string maxLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                                    if (maxLetter.Equals(""))
                                    {
                                        maxLetter = "A";
                                    }
                                    sp.SetFirstLetter(maxLetter);
                                    skidLetter = maxLetter;
                                    
                                }
                            }
                            
                            int skidCnt = reader.GetInt32(reader.GetOrdinal("skidCount"));
                            int pieceCount = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                            decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            int pvc = reader.GetInt32(reader.GetOrdinal("PVCGroupID"));
                            string comments = reader.GetString(reader.GetOrdinal("comments"));
                            decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                            decimal t = reader.GetDecimal(reader.GetOrdinal("thickness"));
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                            
                            
                            
                           
                            
                            for (int i = 0;i < skidCnt; i++)
                            {
                                if (pvc > 0)
                                {
                                    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "YES", true);
                                }
                                else
                                {
                                    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "NO", true);
                                }
                                
                                if (paper > 0)
                                {
                                    MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "Y", true);
                                }
                                else
                                {
                                    MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "N", true);
                                }
                                MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), length.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "E" + firstDtlRow.ToString(), pieceCount.ToString(), true);

                                MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), "", true);

                                string skidID = coilTagID.ToString() + coilTagSuffix + "." + skidLetter;
                                MergeCellAddBox(oSheet, "H" + firstDtlRow.ToString(), "I" + firstDtlRow.ToString(), skidID, true);
                                skidLetter = sp.GetNextLetter();

                                string weight;

                                if (sheetWeight > 0)
                                {
                                    decimal w = sheetWeight * pieceCount;
                                    if (i == 0)
                                    {
                                        skidWeigts.Add(w);
                                    }
                                    else
                                    {
                                        skidWeigts[TagCntr] += w;
                                    }
                                    
                                    weight = Math.Round(w).ToString();

                                }
                                else
                                {
                                    

                                    MetalFormula mt = new MetalFormula();
                                    

                                    decimal w = mt.MetFormula(density, t, length, width, pieceCount, 0);
                                    if (i == 0)
                                    {
                                        skidWeigts.Add(w);
                                    }
                                    else
                                    {
                                        skidWeigts[TagCntr] += w;
                                    }
                                    weight = Math.Round(w).ToString();
                                }   

                                MergeCellAddBox(oSheet, "J" + firstDtlRow.ToString(), "K" + firstDtlRow.ToString(), weight, true);
                                MergeCellAddBox(oSheet, "R" + firstDtlRow.ToString(), "V" + firstDtlRow.ToString(), comments, true);

                                MergeCellAddBox(oSheet, "L" + firstDtlRow.ToString(), "L" + firstDtlRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "M" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), "", true);
                                firstDtlRow++;
                            }

                            
                        }
                    }
                }
            }

            

            string prevcoil = "Nope";
            for (int i = 0; i < coilIDs.Count; i++)
            {
                using (DbDataReader reader = db.GetCoilCTLInfo(coilIDs[i], coilSuffix[i], orderID, status))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            int currtagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                            string coilTagID = currtagID.ToString() + coilTagSuffix;

                            if (!prevcoil.Equals(coilTagID))
                            {
                                prevcoil = coilTagID;
                                string alloyDesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                                string finishDesc = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                                decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                                decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));

                                string location = reader.GetString(reader.GetOrdinal("location"));
                                string heat = reader.GetString(reader.GetOrdinal("heat"));
                                string millnum = reader.GetString(reader.GetOrdinal("millCoilNum"));
                                int weight = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("weight")));
                                int endWeight = 0;
                                int scrap = 0;
                                string scrapType = "";
                                if (status < 0)
                                {
                                    weight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
                                    endWeight = reader.GetInt32(reader.GetOrdinal("currentWeight"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("scrapAmount")))
                                    {
                                        scrap = reader.GetInt32(reader.GetOrdinal("scrapAmount"));
                                    }
                                    scrapType = "IN";
                                    if (!reader.IsDBNull(reader.GetOrdinal("scrapUnit")))
                                    {
                                        scrapType = reader.GetString(reader.GetOrdinal("scrapUnit"));
                                    }

                                }
                                decimal w = 0;
                                for (int j = 0; j < coilIDs.Count; j++)
                                {
                                    if (coilIDs[j] == currtagID)
                                    {
                                        w += skidWeigts[j];
                                    }
                                }
                                int TotskidWeight = Convert.ToInt32(Math.Round(w, 0));

                                MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), coilTagID, true);
                                MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                                MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), TotskidWeight.ToString(), true);
                                MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), scrap.ToString() + " " + scrapType, true);
                                MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString(), true);
                                string endLBS = "0";
                                if (endWeight != -1)
                                {
                                    endLBS = endWeight.ToString();
                                }
                                MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), endLBS, true);
                                MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                                MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                                MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                                firstHeaderRow++;

                            }


                            
                        }
                    }
                    
                }
            }






            db.CloseSQLConn();

        }
        public void WorkOrderClskSame_DontLikeIt(int orderID, _Worksheet oSheet, int status)
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            if (status > 0)
            {

            }
            else
            {

            }
            using (DbDataReader reader = db.GetCTLDetails(orderID,-1,"",true))
            {


                
                string prevCoilTagSuffix = "";
                string prevSkidLetter = "";
                int firstHeaderRow = 8;
                int firstDtlRow = 17;
                bool addRow = true;
                string prevTagID = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        int currtagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string coilTagID = currtagID.ToString() + coilTagSuffix;
                        if (!prevTagID.Equals(coilTagID))
                        {
                            addRow = true;
                        }
                        if (addRow)
                        { 
                            addRow = false;
                            prevTagID = coilTagID;

                            

                            string alloyDesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                            string finishDesc = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                            decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                            
                            string location = reader.GetString(reader.GetOrdinal("location"));
                            string heat = reader.GetString(reader.GetOrdinal("heat"));
                            string millnum = reader.GetString(reader.GetOrdinal("millCoilNum"));
                            int weight = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("weight")));
                            int endWeight = -1;
                            if (!reader.IsDBNull(reader.GetOrdinal("previousWeight")))
                            {
                                weight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
                                endWeight = reader.GetInt32(reader.GetOrdinal("currentWeight"));


                            }
                            MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), coilTagID, true);
                            MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                            MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), "0", true);
                            MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), "0", true);
                            MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString("G29"), true);
                            string endLBS = "0";
                            if (endWeight != -1)
                            {
                                endLBS = endWeight.ToString();
                            }
                            MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), endLBS, true);
                            MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                            MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                            MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                            firstHeaderRow++;
                        }
                        


                    }
                }


            }





            db.CloseSQLConn();
        }

        public void WorkOrderShShSame(int orderID, _Worksheet oSheet, int status)
        {

            MergeCellAddBox(oSheet, "H7", "I7", "Length", true);
            MergeCellAddBox(oSheet, "J7", "K7", "Pieces", true);

            DBUtils db = new DBUtils();

            db.OpenSQLConn();


            using (DbDataReader PVCreader = db.GetPVCGroup())
            {
                if (PVCreader.HasRows)
                {
                    while (PVCreader.Read())
                    {
                        PVCInfo pv = new PVCInfo();
                        
                        pv.groupID = PVCreader.GetInt32(PVCreader.GetOrdinal("GroupID"));
                        pv.groupName = PVCreader.GetString(PVCreader.GetOrdinal("GroupName")).Trim();
                        pv.price = PVCreader.GetDecimal(PVCreader.GetOrdinal("price"));

                        pvcInfo.Add(pv);

                    }
                }
                PVCreader.Close();
            }


            int prevTagID = -1;
            string prevCoilTagSuffix = "";
            string prevSkidLetter = "";
            int firstHeaderRow = 8;
            int firstDtlRow = 17;
            using (DbDataReader reader = db.GetShShSameOrderInfo(orderID, status))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int tagID = reader.GetInt32(reader.GetOrdinal("SkidID"));
                        string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string skidLetter = reader.GetString(reader.GetOrdinal("skidLetter")).Trim();
                        string orderLetter = reader.GetString(reader.GetOrdinal("orderLetter")).Trim();
                        string alloyDesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                        string oldFinish = reader.GetString(reader.GetOrdinal("oldFin")).Trim();
                        string newFinish = reader.GetString(reader.GetOrdinal("newFin")).Trim();
                        decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                        decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                        string location = reader.GetString(reader.GetOrdinal("location"));
                        string heat = reader.GetString(reader.GetOrdinal("heat"));
                        string millnum = reader.GetString(reader.GetOrdinal("millCoilNum"));
                        decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                        decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                        int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));//from skiddata
                        int breakSkid = reader.GetInt32(reader.GetOrdinal("breakSkid"));
                        int orderPieces = reader.GetInt32(reader.GetOrdinal("orderPieceCount"));
                        int pvc = reader.GetInt32(reader.GetOrdinal("pvc"));
                        int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                        decimal diag1 = reader.GetDecimal(reader.GetOrdinal("diagnol1"));
                        decimal diag2 = reader.GetDecimal(reader.GetOrdinal("diagnol2"));
                        decimal mic1 = reader.GetDecimal(reader.GetOrdinal("mic1"));
                        decimal mic2 = reader.GetDecimal(reader.GetOrdinal("mic2"));
                        decimal mic3 = reader.GetDecimal(reader.GetOrdinal("mic3"));
                        string skidComments = reader.GetString(reader.GetOrdinal("skidComments"));


                        int origPieces = pieces;
                        if (breakSkid > 0)
                        {
                            origPieces = breakSkid;
                        }


                        
                        decimal skidweight = 0;
                        bool worryAboutIt = false;  
                        if (prevTagID == -1)
                        {
                            prevTagID = tagID;
                            prevCoilTagSuffix = coilTagSuffix;
                            prevSkidLetter = skidLetter;
                        }
                        else
                        {
                            worryAboutIt = true;
                            if (prevTagID != tagID || prevCoilTagSuffix != coilTagSuffix || prevSkidLetter != skidLetter)
                            {
                                firstHeaderRow++;
                                firstDtlRow++;
                                prevTagID = tagID;
                                prevCoilTagSuffix = coilTagSuffix;
                                prevSkidLetter = skidLetter;
                                Range line = (Range)oSheet.Rows[firstHeaderRow];
                                line.Insert();
                                worryAboutIt = false;
                                

                            }
                           
                        }

                        string skidID = tagID.ToString().Trim() + coilTagSuffix + "." + skidLetter;

                        if (coilTagSuffix.Length == 0)
                        {
                            skidID = tagID.ToString().Trim() + "." + skidLetter;
                        }


                        if (!worryAboutIt)
                        {
                            if (sheetWeight == 0)
                            {
                                MetalFormula mt = new MetalFormula();
                                skidweight = mt.MetFormula(density, thickness, length, width, origPieces, 0);
                            }
                            else
                            {
                                skidweight = Math.Round(sheetWeight * origPieces, 0);
                            }

                            
                            

                            MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), skidID, true);
                            MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + oldFinish, true);
                            MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), length.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), origPieces.ToString(), true);
                            MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), skidweight.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                            MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                            MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                        }

                        skidID = tagID.ToString().Trim() + coilTagSuffix + "." + skidLetter + "." + orderLetter;

                        if (coilTagSuffix.Length == 0)
                        {
                            skidID = tagID.ToString().Trim() + "." + skidLetter + "." + orderLetter;
                        }

                        if (pvc > 0)
                        {
                            string pvcName = width.ToString("G29");

                            try
                            {
                                PVCInfo pv = pvcInfo.Find(x => x.groupID == pvc);
                                pvcName = pv.groupName.Trim();
                            }
                            catch(Exception ex)
                            {

                            }
                            
                            
                            MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(),pvcName, true);

                        }
                        else
                        {
                            MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "NO", true);

                        }
                        if (paper > 0)
                        {
                            MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), width.ToString("G29"), true);

                        }
                        else
                        {
                            MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "NO", true);

                        }
                        MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), length.ToString("G29"), true);
                        MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "E" + firstDtlRow.ToString(), orderPieces.ToString(), true);
                        
                        if (status < 0)
                        {
                            MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), pieces.ToString(), true);
                            if (sheetWeight == 0)
                            {
                                MetalFormula mt = new MetalFormula();
                                skidweight = mt.MetFormula(density, thickness, length, width, pieces, 0);
                            }
                            else
                            {
                                skidweight = Math.Round(sheetWeight * pieces, 0);
                            }

                        }
                        else
                        {
                            MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), "", true);
                            if (sheetWeight == 0)
                            {
                                MetalFormula mt = new MetalFormula();
                                skidweight = mt.MetFormula(density, thickness, length, width, orderPieces, 0);
                            }
                            else
                            {
                                skidweight = Math.Round(sheetWeight * orderPieces, 0);
                            }

                        }
                        MergeCellAddBox(oSheet, "H" + firstDtlRow.ToString(), "I" + firstDtlRow.ToString(), skidID, true);

                        
                        MergeCellAddBox(oSheet, "J" + firstDtlRow.ToString(), "K" + firstDtlRow.ToString(), skidweight.ToString("G29"), true);
                        MergeCellAddBox(oSheet, "L" + firstDtlRow.ToString(), "L" + firstDtlRow.ToString(), oldFinish.Trim(), true);
                        MergeCellAddBox(oSheet, "M" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), newFinish.Trim(), true);
                        if (status < 0)
                        {
                            MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), mic1.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), mic2.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), mic3.ToString("G29"), true);


                        }
                        else
                        {
                            MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), "", true);
                        }
                        MergeCellAddBox(oSheet, "R" + firstDtlRow.ToString(), "V" + firstDtlRow.ToString(), skidComments, true);




                        firstDtlRow++;
                    }

                        
                }
                else
                {
                    MessageBox.Show("Something is wrong on the detail side of order " + orderID.ToString());
                    return;
                }
            }

            db.CloseSQLConn();

        }

        public void MergeCellAddBox(_Worksheet oSheet, string fromCell, string toCell,string verbage,  bool withBorder = false)
        {

            
            Excel.Range oRng;

            oRng = oSheet.get_Range(fromCell, toCell);
            oRng.Merge();
            if (withBorder)
            {
                oRng.Cells.Borders.Weight = XlBorderWeight.xlThin;
            }
            
            if (verbage.Length > 0)
            {
                oRng.Value = verbage;
            }
            
            

            
        }

        public void MergeDataRow(_Worksheet oSheet, int row, bool isHeader = false, bool CTL = false)
        {
            string verbage = "";
            bool withBorder = true;
            if (isHeader)
            {
                withBorder = false;
            }

            if (isHeader)            
                verbage = "PVC";
            MergeCellAddBox(oSheet, "A" + row.ToString(), "A" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "PI";
            MergeCellAddBox(oSheet, "B" + row.ToString(), "B" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "Len(in)";
            MergeCellAddBox(oSheet, "C" + row.ToString(), "C" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "PCS";
            MergeCellAddBox(oSheet, "D" + row.ToString() , "E" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "ActPCS";
            MergeCellAddBox(oSheet, "F" + row.ToString() , "G" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "SkidID";
            MergeCellAddBox(oSheet, "H" + row.ToString() , "I" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "Weight";
            MergeCellAddBox(oSheet, "J" + row.ToString() , "K" + row.ToString(), verbage, withBorder);
            if (CTL)
            {
                if (isHeader)
                    verbage = "DIAG1";
                MergeCellAddBox(oSheet, "L" + row.ToString(), "L" + row.ToString(), verbage, withBorder);

                if (isHeader)
                    verbage = "DIAG2";
                MergeCellAddBox(oSheet, "M" + row.ToString(), "N" + row.ToString(), verbage, withBorder);
            }
            else
            {
                if (isHeader)
                    verbage = "PrevFin";
                MergeCellAddBox(oSheet, "L" + row.ToString(), "L" + row.ToString(), verbage, withBorder);

                if (isHeader)
                    verbage = "NewFin";
                MergeCellAddBox(oSheet, "M" + row.ToString(), "N" + row.ToString(), verbage, withBorder);
            }
            
           
            if (isHeader)
                verbage = "1";
            MergeCellAddBox(oSheet, "O" + row.ToString(), "O" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "2";
            MergeCellAddBox(oSheet, "P" + row.ToString(), "P" + row.ToString(), verbage, withBorder);
            if (isHeader)
                verbage = "3";
            MergeCellAddBox(oSheet, "Q" + row.ToString(), "Q" + row.ToString(), verbage, withBorder);           
            if (isHeader)
                verbage = "Comments";
            MergeCellAddBox(oSheet, "R" + row.ToString() , "V" + row.ToString(), verbage, withBorder);

        }

        
        public void Inventory(bool coils, bool skids, List<int> CustIDs, System.Windows.Forms.Label lblUpdate)
        {
            string updText = lblUpdate.Text;
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            oXL = new Excel.Application();


            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            DBUtils db = new DBUtils();
            lblUpdate.Text = "Opening Database.";
            db.OpenSQLConn();

            
            int row = 1;
            
            foreach (int custID in CustIDs)
            {
                bool addCustRow = true;


                if (coils)
                {
                    using (DbDataReader reader = db.GetCoilInfo(0, "", custID))
                    {
                        if (reader.HasRows)
                        {
                            
                            decimal weightTot = 0;
                            string custName = "";
                            while (reader.Read())
                            {

                                if (addCustRow)
                                {
                                    
                                    custName = reader.GetString(reader.GetOrdinal("longCustomerName")).Trim();
                                    lblUpdate.Text = "Getting information for " + custName + ".";
                                    string[] cName = { custName };
                                    InvAddRow(row, oSheet, cName, "A");
                                    row++;
                                    
                                    InvHeader(row, oSheet);
                                    row++;
                                    addCustRow = false;

                                }
                               

                                int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                                string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                                string coilTag = tagID.ToString().Trim() + coilTagSuffix;

                                int pieces = reader.GetInt32(reader.GetOrdinal("coilCount"));

                                string alloyDesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                                string finishDesc = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                                string alloy = alloyDesc + " " + finishDesc;

                                decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));
                                decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                                decimal length = reader.GetDecimal(reader.GetOrdinal("length"));

                                int intPaper = reader.GetInt32(reader.GetOrdinal("paper"));

                                string paper = "Y";
                                if (intPaper == 0)
                                {
                                    paper = "N";
                                }
                                int intPvc = reader.GetInt32(reader.GetOrdinal("pvc"));

                                string pvc = "Y";
                                if (intPvc == 0)
                                {
                                    pvc = "N";
                                }

                                decimal weight = reader.GetDecimal(reader.GetOrdinal("weight"));
                                weightTot += weight;
                                decimal carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));

                                string heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                                string mill = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();

                                string coo = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();

                                string location = reader.GetString(reader.GetOrdinal("location")).Trim();

                                string vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();

                                string poNum = reader.GetString(reader.GetOrdinal("purchaseOrder")).Trim();

                                int recID = reader.GetInt32(reader.GetOrdinal("receiveID"));

                                DateTime recDate = reader.GetDateTime(reader.GetOrdinal("receiveDate"));

                                
                                object[] info = {coilTag, pieces, alloy,thk,width,
                                        length, pvc, paper,weight, carbon,
                                        mill,heat,coo,location,vendor,poNum,recID, recDate.ToString("d"),weightTot };

                                InvAddRow(row, oSheet, info);


                                row++;
                            }
                        }
                        reader.Close();
                    }
                }
                if (skids)
                {
                    using(DbDataReader reader = db.GetSkidInfo(custID.ToString()))
                    {
                        if (reader.HasRows)
                        {
                           
                            
                            decimal weightTot = 0;
                            decimal skidweight = 0;
                            string custName = "";
                            bool firstSkidRow = true;

                            while (reader.Read())
                            {
                                if (addCustRow)
                                {
                                    custName = reader.GetString(reader.GetOrdinal("longCustomerName"));
                                    lblUpdate.Text = "Getting information for " + custName + ".";
                                    string[] cName = { custName };
                                    InvAddRow(row, oSheet, cName, "A");
                                    row++;
                                   
                                    InvHeader(row, oSheet, true);
                                    row++;
                                    addCustRow = false;
                                    firstSkidRow = false;

                                }
                                if (firstSkidRow)
                                {
                                    InvHeader(row, oSheet, true);
                                    row++;
                                    firstSkidRow = false;
                                }
                                int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                                string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                                string skidLetter = reader.GetString(reader.GetOrdinal("letter"));
                                string coilTag = tagID.ToString().Trim() + coilTagSuffix + "." + skidLetter;

                                int pieceCount = reader.GetInt32(reader.GetOrdinal("pieceCount"));

                                string alloyDesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();
                                string finishDesc = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();
                                string alloy = alloyDesc + " " + finishDesc;

                                decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));
                                decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                                decimal length = reader.GetDecimal(reader.GetOrdinal("length"));

                                int intPaper = reader.GetInt32(reader.GetOrdinal("paper"));

                                string paper = "Y";
                                if (intPaper == 0)
                                {
                                    paper = "N";
                                }
                                int intPvc = reader.GetInt32(reader.GetOrdinal("pvcID"));

                                string pvc = "Y";
                                if (intPvc == 0)
                                {
                                    pvc = "N";
                                }

                                decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));

                                if (sheetWeight > 0)
                                {
                                    skidweight = sheetWeight * pieceCount;
                                }
                                else
                                {
                                    decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                                    MetalFormula mt = new MetalFormula();
                                    skidweight = mt.MetFormula(density, thk, length, width, pieceCount, 0);
                                }

                                decimal carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));

                                string heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                                string mill = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();

                                string coo = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();

                                string location = reader.GetString(reader.GetOrdinal("location"));

                                string vendor = reader.GetString(reader.GetOrdinal("vendor"));

                                string skidType = reader.GetString(reader.GetOrdinal("skidDescription"));

                                int notPrime = reader.GetInt32(reader.GetOrdinal("notPrime"));
                                string prime = "";
                                if (notPrime > 0)
                                {
                                    prime = "Not Prime";
                                }
                                int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));


                                string comments = reader.GetString(reader.GetOrdinal("comments")).Trim();


                                object[] info = {coilTag, pieceCount, alloy,thk,width,
                                        length, pvc, paper,skidweight, carbon,
                                        mill,heat,coo,location,vendor,prime,skidType, orderID,comments };

                                InvAddRow(row, oSheet, info);
                                row++;

                            }
                        }
                    }
                }
                row ++;
            }

            lblUpdate.Text = "Cleaning things up.";

            //oSheet.PageSetup.Zoom = false;
            oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            //oSheet.PageSetup.FitToPagesWide = 1;
            oSheet.PageSetup.FitToPagesTall = 1;

            //oRng = oSheet.get_Range("A1", "S1");
            //oRng.EntireColumn.AutoFit();

            db.CloseSQLConn();
            oXL.Visible = true;
            //set text back to whatever it was.
            lblUpdate.Text = updText;
        }

        private void InvHeader(int row, _Worksheet oSheet, bool skid = false)
        {
            string[] header;
            if (skid)
            {
                string[] skidheader = { "SkidID", "PCS", "Alloy", "Thk", "W", "Lng", "PVC", "PI",
                "Weight", "C", "Mill#", "Heat", "C/O", "Loc", "Vnd", "NotPrime", "Skid", "WO#", "Comments" };
                header = skidheader;
            }
            else
            {
                string[] coilheader = { "CoilID", "PCS", "Alloy", "Thk", "W", "Lng", "PVC", "PI",
                "Weight", "C", "Mill#", "Heat", "C/O", "Loc", "Vnd", "PO", "RecID", "Date", "Comments" };
                header = coilheader;
            }
            

            InvAddRow(row, oSheet, header);


        }
        private void InvAddRow(int row, _Worksheet oSheet, object[] info,string toCell = "S")
        {
            oSheet.get_Range("A" + row.ToString(), toCell + row.ToString()).Value = info;
        }

        public void RunSheet(ListView lvwRunSheet)
        {

            if (lvwRunSheet.Items.Count <= 0)
            {
                return;
            }
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
           

            oXL = new Excel.Application();


            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            object[,] arr = new object[lvwRunSheet.Items.Count +1, lvwRunSheet.Columns.Count + 1];
            oSheet.get_Range("A1", "B1").Merge();
            oSheet.get_Range("A1","B1").Value2 = lvwRunSheet.Tag.ToString();
            int topRow = 2;

            for (int i = 0;i< lvwRunSheet.Columns.Count;i++)
            {
                arr[0, i] = lvwRunSheet.Columns[i].Text;
            }
            for (int i = 0;i < lvwRunSheet.Items.Count;i++)
            {
                ListViewItem lv  = lvwRunSheet.Items[i];

                //arr[i, 0] = lv.Text;
                for (int c = 0; c < lv.SubItems.Count; c++)
                {
                    arr[i +1, c ] = lv.SubItems[c].Text;
                   
                }
                
                
            }

            WriteArray(oSheet, topRow, 1, arr);

            oXL.Visible = true;
            //set text back to whatever it was.

        }
        public void WriteArray( _Worksheet sheet, int startRow, int startColumn, object[,] array)
        {
            var row = array.GetLength(0);
            var col = array.GetLength(1);
            Range c1 = (Range)sheet.Cells[startRow, startColumn];
            Range c2 = (Range)sheet.Cells[startRow + row - 1, startColumn + col - 1];
            Range range = sheet.Range[c1, c2];
            range.Value = array;
        }

        public int TransferReport(int transferID = -1, string tagID = "Need to parse this")
        {
            
            

            int coilTagID = -1;
            string coilTagSuffix = "";
            string letter = "";

            if (transferID != -1)
            {

            }
            else
            {
                TagParser tp = new TagParser();
                tp.TagToBeParsed = tagID;
                tp.ParseTag();
                coilTagID = tp.TagID;
                coilTagSuffix = tp.CoilTagSuffix;
                letter = tp.SkidLetter;
                

            }
            

            

            int rowCnt = 2;

            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            using (DbDataReader reader = db.GetTransferInfo(coilTagID, coilTagSuffix, letter, transferID))
            {
                if (reader.HasRows)
                {
                    Excel.Application oXL;
                    Excel._Workbook oWB;
                    Excel._Worksheet oSheet;


                    oXL = new Excel.Application();


                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                    oSheet.get_Range("A1", "D1").Merge();
                    oSheet.Cells[1, 1] = "Report from TSA Processing: ";

                    while (reader.Read())
                    {
                        
                            transferID = reader.GetInt32(reader.GetOrdinal("transferID"));

                        
                        int tagid = reader.GetInt32(reader.GetOrdinal("transferCoilTagID"));
                        string suffix = reader.GetString(reader.GetOrdinal("transferCoilTagSuffix")).Trim();
                        string skidLetter = reader.GetString(reader.GetOrdinal("transferLetter")).Trim();

                        string origCust = reader.GetString(reader.GetOrdinal("origCust")).Trim();
                        string newCust = reader.GetString(reader.GetOrdinal("newCust")).Trim();
                        string PO = reader.GetString(reader.GetOrdinal("purchaseOrder")).Trim();
                        DateTime dtTrans = reader.GetDateTime(reader.GetOrdinal("transferDate"));


                        oSheet.Cells[rowCnt, 1] = "Transfer ID:";


                        oSheet.Cells[rowCnt, 2] = transferID;
                        string fullTag = tagid.ToString() + suffix;
                        if (skidLetter.Length > 0)
                        {
                            fullTag += "." + skidLetter;
                        }

                        oSheet.Cells[rowCnt, 3] = fullTag + " transfered from "
                                                    + origCust + " to " + newCust
                                                    + " on " + dtTrans.ToString("d")
                                                    + " -Purchase Order: " + PO;


                        rowCnt++;
                    }
                    oXL.Visible = true;
                }
                else
                {
                    return -1;
                }


            }




            return 1;


            
        }

    }
}

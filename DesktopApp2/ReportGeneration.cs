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
using System.Drawing;
using System.Xml.Linq;
using Org.BouncyCastle.Ocsp;

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

        public int RSCoilCnt { get; set; }
        public int RSPieceCnt { get; set; }
        public int RStotWeight { get; set; }

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
                try
                {
                    oWB.SaveAs(filePath);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }





        }



        public void Receiving(int recID)
        {




            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            oXL = new Excel.Application();



            //here
            //oXL.Visible = true;

            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oXL.ActiveWindow.DisplayGridlines = false;

            oSheet.get_Range("A1", "E1").Merge();

            oSheet.Cells[1, 1] = "Report from TSA Processing " + PlantLocation.city + ": ";
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


                oRng = oSheet.get_Range("A" + hRow, "N" + hRow);


                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
                                    = Excel.XlLineStyle.xlDouble;
                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle
                                    = Excel.XlLineStyle.xlDouble;


                oSheet.Cells[hRow, 1] = "PO#";
                oSheet.Cells[hRow, 2] = "Tag ID";
                oSheet.Cells[hRow, 3] = "CC";
                oSheet.Cells[hRow, 4] = "Mill Num";
                oSheet.Cells[hRow, 5] = "Heat Num";
                oSheet.Cells[hRow, 6] = "C/O";
                oSheet.Cells[hRow, 7] = "C";
                oSheet.Cells[hRow, 8] = "Weight";
                oSheet.Cells[hRow, 9] = "Gauge";
                oSheet.Cells[hRow, 10] = "Width";
                oSheet.Cells[hRow, 11] = "Alloy";
                oSheet.Cells[hRow, 12] = "Type";
                oSheet.Cells[hRow, 13] = "Location";

                hRow++;

                int totWeight = 0;
                int totCnt = 0;

                List<coilRows> cra = new List<coilRows>();
                while (reader.Read())
                {
                    if (!printHdr)
                    {
                        DateTime dtRec = reader.GetDateTime(reader.GetOrdinal("receiveDate"));  
                        oSheet.Cells[3, 1] = "We have received the following items for " + reader.GetString(reader.GetOrdinal("LongCustomerName"));
                        oSheet.Cells[4, 1] = " on " + dtRec.ToString("d");
                        printHdr = true;
                    }
                    string[] CoilInfo = new string[13];
                    //PO#
                    string poNum = reader.GetString(reader.GetOrdinal("dtlPO")).Trim();
                    CoilInfo[0] = poNum;


                    //TagID
                    coilRows cr = new coilRows();
                    int coilID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                    cr.coilID = coilID;
                    cr.hRow = hRow;
                    cra.Add(cr);

                    CoilInfo[1] = coilID.ToString().Trim() + " " +
                                    reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                    //CoilCount
                    int coilCnt = reader.GetInt32(reader.GetOrdinal("coilCount"));
                    CoilInfo[2] = coilCnt.ToString().Trim();
                    totCnt += coilCnt;
                    //MillNum
                    CoilInfo[3] = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                    //HeatNum
                    CoilInfo[4] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    //C/O
                    CoilInfo[5] = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                    //C
                    CoilInfo[6] = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                    //Weight
                    int weight = reader.GetInt32(reader.GetOrdinal("origWeight"));
                    CoilInfo[7] = weight.ToString().Trim();
                    totWeight += weight;
                    //Gauge
                    CoilInfo[8] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    //Width
                    CoilInfo[9] = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                    //Alloy
                    CoilInfo[10] = reader.GetString(reader.GetOrdinal("AlloyDesc")).ToString().Trim() + " " +
                                  reader.GetString(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                    //Type
                    CoilInfo[11] = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                    //Location
                    CoilInfo[12] = reader.GetString(reader.GetOrdinal("location")).Trim();

                    oSheet.get_Range("A" + hRow, "M" + hRow).Value2 = CoilInfo;
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
                                oSheet.Rows[coilID.hRow + dCnt - 1].Insert();
                                cnt++;
                                hRow++;
                            }
                            oSheet.Cells[coilID.hRow + dCnt - 1, 15] = reader.GetString(reader.GetOrdinal("damageDescription"));

                            dCnt++;
                        }

                    }
                    reader.Close();

                }
                //A-E
                oSheet.get_Range("A" + hRow.ToString(), "E" + hRow.ToString()).Merge();
                oSheet.Cells[hRow, 1] = "Total Count = " + totCnt + ": Total Weight = " + totWeight;


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
                oRng = oSheet.get_Range("A" + hRow, "N" + hRow);

                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
                                            = Excel.XlLineStyle.xlDouble;
                oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle
                                            = Excel.XlLineStyle.xlDouble;
                oSheet.Cells[hRow, 1] = "PO#";
                oSheet.Cells[hRow, 2] = "Skid ID";
                oSheet.Cells[hRow, 3] = "PC";
                oSheet.Cells[hRow, 4] = "Mill Num";
                oSheet.Cells[hRow, 5] = "Heat Num";
                oSheet.Cells[hRow, 6] = "C/O";
                oSheet.Cells[hRow, 7] = "C";
                oSheet.Cells[hRow, 8] = "Alloy";
                oSheet.Cells[hRow, 9] = "Gauge";
                oSheet.Cells[hRow, 10] = "Width";
                oSheet.Cells[hRow, 11] = "Length";
                oSheet.Cells[hRow, 12] = "Weight";
                oSheet.Cells[hRow, 13] = "Type";
                oSheet.Cells[hRow, 14] = "Location";


                hRow++;

                int totPieces = 0;
                int totWeight = 0;
                int totCnt = 0;
                List<coilRows> cra = new List<coilRows>();
                while (reader.Read())
                {
                   
                    if (!printHdr)
                    {
                        DateTime dtRec = reader.GetDateTime(reader.GetOrdinal("receiveDate"));
                        oSheet.Cells[3, 1] = "We have received the following items for " + reader.GetString(reader.GetOrdinal("LongCustomerName"));
                        oSheet.Cells[4, 1] = " on " + dtRec.ToString("d");
                        printHdr = true;
                    }
                    string[] SkidInfo = new string[14];

                    coilRows cr = new coilRows();

                    int coilID = reader.GetInt32(reader.GetOrdinal("skidID"));
                    cr.coilID = coilID;
                    cr.hRow = hRow;
                    cra.Add(cr);
                    //PO#
                    SkidInfo[0] = reader.GetString(reader.GetOrdinal("dtlPO"));

                    //TagID
                    SkidInfo[1] = reader.GetInt32(reader.GetOrdinal("skidID")).ToString().Trim() + "." +
                                    reader.GetString(reader.GetOrdinal("letter")).Trim();
                    //PieceCount
                    int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                    SkidInfo[2] = pieces.ToString().Trim();
                    totPieces += pieces;
                    //MillNum
                    SkidInfo[3] = reader.GetString(reader.GetOrdinal("millNum")).Trim();
                    //HeatNum
                    SkidInfo[4] = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    //C/O
                    SkidInfo[5] = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                    //C
                    SkidInfo[6] = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                    //Alloy
                    SkidInfo[7] = reader.GetString(reader.GetOrdinal("AlloyDesc")).ToString().Trim() + " " +
                                  reader.GetString(reader.GetOrdinal("FinishDesc")).ToString().Trim();
                    //Gauge
                    SkidInfo[8] = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    //Width
                    SkidInfo[9] = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                    //Length
                    SkidInfo[10] = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();

                    //Weight
                    int weight = reader.GetInt32(reader.GetOrdinal("weight"));
                    SkidInfo[11] = weight.ToString().Trim();
                    totWeight += weight;


                    //Type
                    SkidInfo[12] = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                    //Location
                    SkidInfo[13] = reader.GetString(reader.GetOrdinal("location")).Trim();

                    oSheet.get_Range("A" + hRow, "N" + hRow).Value2 = SkidInfo;
                    hRow++;
                    totCnt++;

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
                                oSheet.Rows[coilID.hRow + dCnt -1 ].Insert();
                                cnt++;
                                hRow++;
                                
                            }
                            oSheet.Cells[coilID.hRow + dCnt - 1, 15] = reader.GetString(reader.GetOrdinal("damageDescription"));

                            dCnt++;
                        }

                    }
                    reader.Close();

                }

                reader.Close();

                oSheet.Cells[hRow, 1] = "Total Count = " + totCnt.ToString().Trim() + ": Total Weight = " + totWeight.ToString().Trim() + ": Total Pieces = " + totPieces.ToString().Trim();

            }

            oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


            oRng = oSheet.get_Range("A1", "N1");
            oRng.EntireColumn.AutoFit();

            db.CloseSQLConn();
            oXL.Visible = true;

            string filename = "Rec-" + recID + ".xlsx";
            try
            {
                SaveFile(oWB, filename, "Receiving");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


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
            //need to figure out WORKORDER and 

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
                        oSheet.Cells[4, 11] = reader.GetInt32(reader.GetOrdinal("orderID"));
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
                        oSheet.Cells[7, 8] = reader.GetDateTime(reader.GetOrdinal("releaseDate")).ToString("d");
                        oSheet.Cells[60, 9] = reader.GetString(reader.GetOrdinal("shipPerson")).Trim();
                        
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
                                                reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim() + "." +
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


        public void WorkOrder(int orderID,bool printOperatorTag = false)
        {


            PrintLabels pl = new PrintLabels();

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
            string machineName = "";


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
                        hdrComments = reader.GetString(reader.GetOrdinal("comments")).Trim();
                        packaging = reader.GetString(reader.GetOrdinal("Packaging")).Trim();
                        machineName = reader.GetString(reader.GetOrdinal("machineName")).Trim();

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

            MergeCellAddBox(oSheet, "Q1", "S1", machineName);
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


            //oXL.Visible = true;

            MergeDataRow(oSheet, 16,true, processFunction);
            MergeDataRow(oSheet, 17, false, processFunction);

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

            pl.SkidLabelInfo.CustName = customername;

            //temp  remove
            //oXL.Visible = true;

            //temp  remove

            //print work orders
            switch (processFunction)
            {
                case ProcessFunction.ClClSame://coil polish
                    WorkOrderClClSame(orderID, oSheet, status);
                    break;
                case ProcessFunction.ClSkSame://cut to length
                    WorkOrderClSkSame(orderID, oSheet, status);
                    break;
                case ProcessFunction.ClClDiff://slitter
                    WorkOrderClClDiff(orderID, oSheet, status);
                    break;
                case ProcessFunction.ShShSame://sheet polish/buff
                    WorkOrderShShSame(orderID, oSheet, status);
                    break;
                case ProcessFunction.ShShDiff:
                    WorkOrderShShDiff(orderID, oSheet, status);
                    break;
            }


            oSheet.PageSetup.LeftFooter = "&\"Calibri\"&B&12Date___________\rStart___________\rStop___________";
            oSheet.PageSetup.CenterFooter = "&\"Calibri\"&B&12Operator___________\rLeveler___________\rPage &P of &N";
            oSheet.PageSetup.RightFooter = "&\"Calibri\"&B&12Skids_________\rPacker_________\r_________";
            oSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            oSheet.PageSetup.Zoom = false;
            oSheet.PageSetup.FitToPagesWide = 1;
            oXL.ScreenUpdating = true;
            oXL.Visible = true;


        }
        public void WorkOrderClClDiff(int orderID, _Worksheet oSheet, int status)
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();
            int firstHeaderRow = 8;
            int firstDtlRow = 17;


            Excel.Range oRng;

            oRng = oSheet.get_Range("A" + firstDtlRow.ToString() , "Z" + firstDtlRow.ToString());
            oRng.UnMerge();

            oRng.Borders.LineStyle = XlLineStyle.xlLineStyleNone;



            MergeCellAddBox(oSheet, "U1", "V1", DateTime.Now.ToString("d"));
            MergeCellAddBox(oSheet, "O15", "Q15", "MIC Readings");
            MergeCellAddBox(oSheet, "A16", "A16", "");
            MergeCellAddBox(oSheet, "B16", "B16", "");
            MergeCellAddBox(oSheet, "C16", "C16", "");
            MergeCellAddBox(oSheet, "D16", "D16", "");
            MergeCellAddBox(oSheet, "E16", "E16", "");
            MergeCellAddBox(oSheet, "F16", "F16", "");
            MergeCellAddBox(oSheet, "G16", "G16", "");
            MergeCellAddBox(oSheet, "H16", "H16", "");
            MergeCellAddBox(oSheet, "I16", "I16", "");
            MergeCellAddBox(oSheet, "J16", "J16", "");
            MergeCellAddBox(oSheet, "K16", "K16", "");
            MergeCellAddBox(oSheet, "L16", "L16", "");
            MergeCellAddBox(oSheet, "M16", "M16", "");
            MergeCellAddBox(oSheet, "N16", "N16", "");





            using (DbDataReader reader = db.GetClClDiffDetails(orderID))
            {
                if (reader.HasRows)
                {
                    int prevCutBreak = -9999;
                    int prevTagID = -9999;
                    string prevCoilTagSuffix = "NOPE";
                    while (reader.Read())
                    {


                        int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string tagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string alloyDesc = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                        string finishDesc = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                        decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        decimal width = reader.GetDecimal(reader.GetOrdinal("OGWidth"));
                        decimal densityFactor = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                        int weight = reader.GetInt32(reader.GetOrdinal("OrigWeight")); 
                        string location = reader.GetString(reader.GetOrdinal("location")).Trim();
                        string heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                        string millnum = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                        string origTagID = tagID.ToString() + tagSuffix;
                        int cutbreak = reader.GetInt32(reader.GetOrdinal("cutBreak"));
                        int breakWeight = reader.GetInt32(reader.GetOrdinal("nWeight"));
                        string slitComments = reader.GetString(reader.GetOrdinal("slitComments")).Trim();
                        if (prevTagID == -9999)
                        {

                            MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), origTagID, true);
                            MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                            MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), "NA", true);//skid weight
                            MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), "", true);//scrap
                            MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString(), true);
                            MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                            MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                            MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                            MergeCellAddBox(oSheet, "A" + (firstDtlRow - 1).ToString(), "B" + (firstDtlRow - 1).ToString(), "Tag - " + origTagID, true);


                            prevTagID = tagID;
                            prevCoilTagSuffix = tagSuffix;
                            prevCutBreak = cutbreak;
                            if (weight != breakWeight)
                            {
                                
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "Break " + (cutbreak + 1).ToString() + "- " + breakWeight.ToString("###,###") + "#", true);

                                decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                                MetalFormula mf = new MetalFormula();
                                int breakLength = Convert.ToInt32(mf.MetFormula(density, thickness, 0, width, 1, breakWeight, true) / 12);
                                
                                MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), breakLength.ToString("###,###") + " feet", true);
                                MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "F" + firstDtlRow.ToString(), "SLIT TO", true);
                                MergeCellAddBox(oSheet, "G" + firstDtlRow.ToString(), "H" + firstDtlRow.ToString(), "EST LBS", true);
                                MergeCellAddBox(oSheet, "I" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), "SCALE WEIGHT", true);

                                firstDtlRow++;
                            }
                        }
                        else
                        {
                            if (prevTagID != tagID || !prevCoilTagSuffix.Equals(tagSuffix))
                            {
                                firstHeaderRow++;
                                Range line = (Range)oSheet.Rows[firstHeaderRow];
                                line.Insert();

                                MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), origTagID, true);
                                MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                                MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), "NA", true);
                                MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString(), true);
                                MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                                MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                                MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                                
                                firstDtlRow += 3;
                                prevTagID = tagID;
                                prevCoilTagSuffix = tagSuffix;
                                MergeCellAddBox(oSheet, "A" + (firstDtlRow - 1).ToString(), "B" + (firstDtlRow - 1).ToString(), "Tag - " + origTagID, true);


                            }
                            else if (prevCutBreak != cutbreak)
                            {
                                if (weight != breakWeight)
                                {
                                    firstDtlRow++;

                                    
                                    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), "Break " + (cutbreak + 1).ToString() + "- " + breakWeight.ToString("###,###") + "#", true);

                                    decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                                    MetalFormula mf = new MetalFormula();
                                    int breakLength = Convert.ToInt32(mf.MetFormula(density, thickness, 0, width, 1, breakWeight, true) / 12);

                                    MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), breakLength.ToString("###,###") + " feet", true);
                                    MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "F" + firstDtlRow.ToString(), "SLIT TO", true);
                                    MergeCellAddBox(oSheet, "G" + firstDtlRow.ToString(), "H" + firstDtlRow.ToString(), "EST LBS", true);
                                    MergeCellAddBox(oSheet, "I" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), "SCALE WEIGHT", true);

                                    firstDtlRow++;
                                }
                                prevCutBreak = cutbreak;
                            }
                        }


                        string tagNewSuffix = reader.GetString(reader.GetOrdinal("newTagSuffix")).Trim();
                        string coilTagID = tagID.ToString() + tagNewSuffix;

                        char colLetter = 'A';
                        if (weight != breakWeight)
                        {
                            colLetter = 'B';

                            
                        }

                        //nextChar = (char)(((int)letter) + 1);

                        //B-C
                        MergeCellAddBox(oSheet, (char)(((int)colLetter)) + firstDtlRow.ToString(), (char)(((int)colLetter) + 1) + firstDtlRow.ToString(), coilTagID, true);


                        decimal slitWidth = reader.GetDecimal(reader.GetOrdinal("width"));

                        //D-F
                        MergeCellAddBox(oSheet, (char)(((int)colLetter) + 2) + firstDtlRow.ToString(), (char)(((int)colLetter) + 4) + firstDtlRow.ToString(), slitWidth.ToString("G29"), true);

                        int slitWeight = reader.GetInt32(reader.GetOrdinal("slitWeight"));
                        //G-H
                        int adder = 7;
                        if (weight != breakWeight)
                        {
                            adder = 6;
                        }
                        MergeCellAddBox(oSheet, (char)(((int)colLetter) + 5) + firstDtlRow.ToString(), (char)(((int)colLetter) + adder) + firstDtlRow.ToString(), slitWeight.ToString("###,###") + "#", true);


                        //string newFinish = reader.GetString(reader.GetOrdinal("newFinishDesc")).Trim();
                        //MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), newFinish, true)


                        MergeCellAddBox(oSheet, (char)(((int)colLetter) + adder + 1) + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), "", true) ;
                        MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), "", true);
                        MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), "", true);
                        MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), "", true);
                        

                        //int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                        //string comm = "Paper";
                        //if (paper <= 0)
                        //    comm = "NO PAPER!!!";

                        MergeCellAddBox(oSheet, "R" + firstDtlRow.ToString(), "V" + firstDtlRow.ToString(), slitComments, true);


                        firstDtlRow++;
                    }

                }
            }


            db.CloseSQLConn();

        }

        public void WorkOrderClSkSame(int orderID, _Worksheet oSheet, int status)
        {
            DBUtils db  = new DBUtils();

            db.OpenSQLConn();

            CTLPrice pricing = new CTLPrice();
            pricing.OrderID = orderID;

            pricing.GetCTLPrices();

            MergeCellAddBox(oSheet, "U1", "V1", DateTime.Now.ToString("d"));

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

            int row = 0;
            decimal totalCharge = 0;
            decimal scrapCredit = 0;
            for (int i = 0; i < pricing.Adders.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        row = 3;
                        break;
                    case 1:
                        row = 5; 
                        break;
                    default:
                        row++;
                        break;
                }
                MergeCellAddBox(oSheet, "T" + row.ToString(), "T" + row.ToString(), pricing.Adders[i].adderDesc);
                string charges = pricing.Adders[i].charge.ToString("$##,###.00##") + " X " + pricing.Adders[i].amount.ToString();
                MergeCellAddBox(oSheet, "U" + row.ToString(), "U" + row.ToString(), charges);
                decimal total = Math.Round(pricing.Adders[i].charge * pricing.Adders[i].amount,2);
                MergeCellAddBox(oSheet, "V" + row.ToString(), "V" + row.ToString(), total.ToString("$##,###.00"));
                if (pricing.Adders[i].charge >= 0)
                {
                    totalCharge += total;
                }
                else
                {
                    scrapCredit += total;
                }
            }
            if (totalCharge > 0)
            {
                row++;
                MergeCellAddBox(oSheet, "T" + row.ToString(), "V" + row.ToString(), "Total " + totalCharge.ToString("$##,###.00"), true);
                if (scrapCredit != 0)
                {
                    row++;
                    MergeCellAddBox(oSheet, "T" + row.ToString(), "V" + row.ToString(), "Scrap Credit " + scrapCredit.ToString("$##,###.00"), true);
                    totalCharge += scrapCredit;
                    row++;
                    MergeCellAddBox(oSheet, "T" + row.ToString(), "V" + row.ToString(), "Invoice Total " + totalCharge.ToString("$##,###.00"), true);

                }

            }
            oSheet.get_Range("T1", "U1").EntireColumn.AutoFit();

            string prevCoilTagSuffix = "";
            
            
            int firstHeaderRow = 8;
            int firstDtlRow = 17;
            
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
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                            decimal w = 0;

                            int skidWeight = reader.GetInt32(reader.GetOrdinal("SkidWeight"));

                            
                            if (skidWeight > 0)
                            {
                                w = skidWeight;
                                skidWeigts.Add(skidWeight);
                                weight = skidWeight.ToString();
                            }
                            else
                            {
                                if (sheetWeight > 0)
                                {
                                    w = sheetWeight * pieces;
                                    skidWeigts.Add(w);
                                    weight = Math.Round(w).ToString();

                                }
                                else
                                {
                                    decimal density = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));

                                    MetalFormula mt = new MetalFormula();
                                    decimal t = reader.GetDecimal(reader.GetOrdinal("thickness"));


                                    w = mt.MetFormula(density, t, length, width, pieces, 0);
                                    skidWeigts.Add(w);
                                    weight = Math.Round(w).ToString();
                                }
                            }
                            
                            decimal sqft = (length * width * pieces) / 144;
                            if (pvc > 0)
                            {
                                string pvcName = "";
                                PVCInfo pv = pvcInfo.Find(x => x.groupID == pvc);
                                pvcName = pv.groupName.Trim();
                                if (status < 0)
                                {
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //here
                                    
                                    pvcName = Math.Round(sqft, 0).ToString();
                                }
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), pvcName, true);
                            }
                            else
                            {
                                string pvcName = "NO";
                                //if (status < 0)
                                //{
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //here
                                //    decimal sqft = (length * width * pieces) / 144;
                                //    pvcName = Math.Round(sqft, 0).ToString();
                                //}
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), pvcName, true);
                            }
                            if (paper > 0)
                            {
                                string paperName = "Y";
                                
                                if (status < 0)
                                {
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //here
                                    
                                    paperName = Math.Round(sqft, 0).ToString();
                                }
                                MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), paperName, true);
                            }
                            else
                            {
                                string paperName = "NO";
                                //if (status < 0)
                                //{
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //temporary for Trish
                                //    //here
                                //    decimal sqft = (length * width * pieces) / 144;
                                //    pvcName = Math.Round(sqft, 0).ToString();
                                //}
                                MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), paperName, true);
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
                                    sp.SetFirstLetter(maxLetter);
                                }
                                else
                                {
                                    sp.SetFirstLetter(maxLetter);
                                    maxLetter = sp.GetNextLetter();
                                }
                                
                                
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
                                        sp.SetFirstLetter(maxLetter);
                                    }
                                    else
                                    {
                                        sp.SetFirstLetter(maxLetter);
                                        maxLetter = sp.GetNextLetter();
                                    }
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
                                decimal sqft = (length * width * pieceCount) / 144;
                                if (pvc > 0)
                                {
                                    string pvcName = "";
                                    PVCInfo pv = pvcInfo.Find(x => x.groupID == pvc);
                                    pvcName = pv.groupName.Trim();
                                    if (status < 0)
                                    {
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //here
                                        
                                        pvcName = Math.Round(sqft, 0).ToString();
                                    }
                                    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), pvcName, true);
                                }
                                else
                                {
                                    string pvcName = "NO";
                                    //if (status < 0)
                                    //{
                                    //    //temporary for Trish
                                    //    //temporary for Trish
                                    //    //temporary for Trish
                                    //    //temporary for Trish
                                    //    //temporary for Trish
                                    //    //temporary for Trish
                                    //    //here
                                    //    decimal sqft = (length * width * pieceCount) / 144;
                                    //    pvcName = Math.Round(sqft, 0).ToString();
                                    //}
                                    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), pvcName, true);
                                }
                                
                                if (paper > 0)
                                {
                                    string paperName = "Y";
                                    if (status < 0)
                                    {
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //temporary for Trish
                                        //here

                                        paperName = Math.Round(sqft, 0).ToString();
                                    }
                                    MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), paperName, true);
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
                                if (prevcoil != "Nope")
                                {
                                    oSheet.Rows[firstHeaderRow].Insert();
                                }
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
                                decimal lbsPerInch = 0;
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
                                    if (!reader.IsDBNull(reader.GetOrdinal("lbsPerInch")))
                                    {
                                        lbsPerInch = reader.GetDecimal(reader.GetOrdinal("lbsPerInch"));
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
        
        private void WorkOrderClClSame(int orderID, _Worksheet oSheet,int status)
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            MergeCellAddBox(oSheet, "U1", "V1", DateTime.Now.ToString("d"));

            int firstHeaderRow = 8;
            int firstDtlRow = 17;

            using (DbDataReader reader = db.GetClClSameDetails(orderID))
            {
                if (reader.HasRows)
                {
                    int prevTagID = -9999;
                    string prevCoilTagSuffix = "NOPE";
                    while (reader.Read())
                    {


                        int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        string tagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string alloyDesc = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                        string finishDesc = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                        decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                        decimal densityFactor = reader.GetDecimal(reader.GetOrdinal("DensityFactor"));
                        int weight = Convert.ToInt32( reader.GetDecimal(reader.GetOrdinal("weight")));
                        string location = reader.GetString(reader.GetOrdinal("location")).Trim();
                        string heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                        string millnum = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                        string origTagID = tagID.ToString() + tagSuffix;
                        if (prevTagID == -9999)
                        {
                            MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), origTagID, true);
                            MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                            MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                            MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), "NA", true);
                            MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString(), true);
                            MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), "", true);
                            MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                            MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                            MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);
                            prevTagID = tagID;
                            prevCoilTagSuffix = tagSuffix;
                        }
                        else
                        {
                            if (prevTagID != tagID || !prevCoilTagSuffix.Equals(tagSuffix))
                            {
                                firstHeaderRow++;
                                Range line = (Range)oSheet.Rows[firstHeaderRow];
                                line.Insert();
                                
                                MergeCellAddBox(oSheet, "A" + firstHeaderRow.ToString(), "A" + firstHeaderRow.ToString(), origTagID, true);
                                MergeCellAddBox(oSheet, "B" + firstHeaderRow.ToString(), "D" + firstHeaderRow.ToString(), alloyDesc + " " + finishDesc, true);
                                MergeCellAddBox(oSheet, "E" + firstHeaderRow.ToString(), "E" + firstHeaderRow.ToString(), thickness.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "F" + firstHeaderRow.ToString(), "G" + firstHeaderRow.ToString(), width.ToString("G29"), true);
                                MergeCellAddBox(oSheet, "H" + firstHeaderRow.ToString(), "I" + firstHeaderRow.ToString(), "NA", true);
                                MergeCellAddBox(oSheet, "J" + firstHeaderRow.ToString(), "K" + firstHeaderRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "L" + firstHeaderRow.ToString(), "L" + firstHeaderRow.ToString(), weight.ToString(), true);
                                MergeCellAddBox(oSheet, "M" + firstHeaderRow.ToString(), "N" + firstHeaderRow.ToString(), "", true);
                                MergeCellAddBox(oSheet, "O" + firstHeaderRow.ToString(), "P" + firstHeaderRow.ToString(), location, true);
                                MergeCellAddBox(oSheet, "Q" + firstHeaderRow.ToString(), "R" + firstHeaderRow.ToString(), heat, true);
                                MergeCellAddBox(oSheet, "S" + firstHeaderRow.ToString(), "S" + firstHeaderRow.ToString(), millnum, true);

                                firstDtlRow +=2;
                                prevTagID = tagID;
                                prevCoilTagSuffix = tagSuffix;


                            }
                        }
                        
                        
                        string tagNewSuffix = reader.GetString(reader.GetOrdinal("coilTagNewSuffix"));
                        string coilTagID = tagID.ToString() + tagNewSuffix;
                        MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), coilTagID, true);

                        
                        MergeCellAddBox(oSheet, "C" + firstDtlRow.ToString(), "C" + firstDtlRow.ToString(), alloyDesc, true);


                        
                        MergeCellAddBox(oSheet, "D" + firstDtlRow.ToString(), "E" + firstDtlRow.ToString(), finishDesc, true);


                        string newFinish = reader.GetString(reader.GetOrdinal("newFinishDesc")).Trim();
                        MergeCellAddBox(oSheet, "F" + firstDtlRow.ToString(), "G" + firstDtlRow.ToString(), newFinish, true);


                       
                        

                        
                        int newWeight = reader.GetInt32(reader.GetOrdinal("nWeight"));
                        MergeCellAddBox(oSheet, "H" + firstDtlRow.ToString(), "I" + firstDtlRow.ToString(), newWeight.ToString(), true);

                        MetalFormula mt = new MetalFormula();
                        
                        decimal length = Math.Round(mt.MetFormula(densityFactor, thickness, 0, width, 1, newWeight)/12,1);
                        MergeCellAddBox(oSheet, "J" + firstDtlRow.ToString(), "K" + firstDtlRow.ToString(),length.ToString("G29"), true);


                        MergeCellAddBox(oSheet, "L" + firstDtlRow.ToString(), "N" + firstDtlRow.ToString(), "", true);
                        
                        
                        MergeCellAddBox(oSheet, "O" + firstDtlRow.ToString(), "O" + firstDtlRow.ToString(), "", true);
                        MergeCellAddBox(oSheet, "P" + firstDtlRow.ToString(), "P" + firstDtlRow.ToString(), "", true);
                        MergeCellAddBox(oSheet, "Q" + firstDtlRow.ToString(), "Q" + firstDtlRow.ToString(), "", true);

                        int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                        string comm = "Paper";
                        if (paper <= 0)
                            comm = "NO PAPER!!!";
                        
                        MergeCellAddBox(oSheet, "R" + firstDtlRow.ToString(), "V" + firstDtlRow.ToString(), comm, true);

                       
                        firstDtlRow++;
                    }

                }
            }

            
            db.CloseSQLConn();

        }

        public void WorkOrderShShDiff(int orderID, _Worksheet oSheet, int status)
        {


        }

        public void WorkOrderShShSame(int orderID, _Worksheet oSheet, int status)
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            SheetSheetSamePricing pricing = new SheetSheetSamePricing();
            pricing.OrderID = orderID;

            pricing.GetShShPrices();

            MergeCellAddBox(oSheet, "U1", "V1", DateTime.Now.ToString("d"));

            int row = 0;
            decimal totalCharge = 0;
            for (int i = 0; i < pricing.Adders.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        row = 3;
                        break;
                    case 1:
                        row = 5;
                        break;
                    default:
                        row++;
                        break;
                }
                MergeCellAddBox(oSheet, "T" + row.ToString(), "T" + row.ToString(), pricing.Adders[i].adderDesc);
                string charges = pricing.Adders[i].charge.ToString("$##,###.00##") + " X " + pricing.Adders[i].amount.ToString();
                MergeCellAddBox(oSheet, "U" + row.ToString(), "U" + row.ToString(), charges);
                decimal total = Math.Round(pricing.Adders[i].charge * pricing.Adders[i].amount, 2);
                MergeCellAddBox(oSheet, "V" + row.ToString(), "V" + row.ToString(), total.ToString("$##,###.00"));
                totalCharge += total;
            }
            if (totalCharge > 0)
            {
                row++;
                MergeCellAddBox(oSheet, "T" + row.ToString(), "V" + row.ToString(), "Total " + totalCharge.ToString("$##,###.00"), true);

            }
            oSheet.get_Range("T1", "U1").EntireColumn.AutoFit();


            MergeCellAddBox(oSheet, "H7", "I7", "Length", true);
            MergeCellAddBox(oSheet, "J7", "K7", "Pieces", true);

           


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
                            //skidweight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SheetWeight")));
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
                        decimal sqft = (length * width * pieces) / 144;
                        if (pvc > 0)
                        {
                            string pvcName = "";

                            try
                            {
                                PVCInfo pv = pvcInfo.Find(x => x.groupID == pvc);
                                pvcName = pv.groupName.Trim();
                                if (status < 0)
                                {
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //temporary for Trish
                                    //here
                                    
                                    pvcName = Math.Round(sqft, 0).ToString();
                                }
                                
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
                            
                            MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(),pvcName, true);

                        }
                        else
                        {
                            //if (status < 0)
                            //{
                            //    //temporary for Trish
                            //    //temporary for Trish
                            //    //temporary for Trish
                            //    //temporary for Trish
                            //    //temporary for Trish
                            //    //temporary for Trish
                            //    //here
                            //    decimal sqft = (length * width * pieces) / 144;

                            //    MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), Math.Round(sqft, 0).ToString(), true);

                            //}
                            //else
                            //{
                                MergeCellAddBox(oSheet, "A" + firstDtlRow.ToString(), "A" + firstDtlRow.ToString(), "NO", true);
                            //}
                            

                        }
                        if (paper > 0)
                        {
                            string paperName = width.ToString("G29");
                            if (status < 0)
                            {
                                paperName = sqft.ToString("G29");
                            }
                            MergeCellAddBox(oSheet, "B" + firstDtlRow.ToString(), "B" + firstDtlRow.ToString(), paperName, true);

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
            else
            {
                oRng.Value = null;
            }
            
            

            
        }

        public void MergeDataRow(_Worksheet oSheet, int row, bool isHeader = false, string processFunction = "")
        {


            bool CTL = false;
            bool CLCLSame = false;
            if (processFunction == ProcessFunction.ClSkSame)
            {
                CTL = true;
            }
            else
            {
                if (processFunction == ProcessFunction.ClClSame)
                {
                    CLCLSame = true;
                }
            }

            string verbage = "";
            bool withBorder = true;
            if (isHeader)
            {
                withBorder = false;
            }

           
            if (CLCLSame)
            {
                if (isHeader)
                {
                    verbage = "New Tag ID";
                }
                MergeCellAddBox(oSheet, "A" + row.ToString(), "B" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "Alloy";
                MergeCellAddBox(oSheet, "C" + row.ToString(), "C" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "OrigFin";
                MergeCellAddBox(oSheet, "D" + row.ToString(), "E" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "NewFin";
                MergeCellAddBox(oSheet, "F" + row.ToString(), "G" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "Target LBS";
                MergeCellAddBox(oSheet, "H" + row.ToString(), "I" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "Lin Ft";
                MergeCellAddBox(oSheet, "J" + row.ToString(), "K" + row.ToString(), verbage, withBorder);
            }
            else
            {
                if (isHeader)
                {
                    verbage = "PVC";
                }
                MergeCellAddBox(oSheet, "A" + row.ToString(), "A" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "PI";
                MergeCellAddBox(oSheet, "B" + row.ToString(), "B" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "Len(in)";
                MergeCellAddBox(oSheet, "C" + row.ToString(), "C" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "PCS";
                MergeCellAddBox(oSheet, "D" + row.ToString(), "E" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "ActPCS";
                MergeCellAddBox(oSheet, "F" + row.ToString(), "G" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "SkidID";
                MergeCellAddBox(oSheet, "H" + row.ToString(), "I" + row.ToString(), verbage, withBorder);
                if (isHeader)
                    verbage = "Weight";
                MergeCellAddBox(oSheet, "J" + row.ToString(), "K" + row.ToString(), verbage, withBorder);
            }           
                
            
            
            
            
            
            
            
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
                if (!CLCLSame)
                {
                    if (isHeader)
                        verbage = "PrevFin";
                    MergeCellAddBox(oSheet, "L" + row.ToString(), "L" + row.ToString(), verbage, withBorder);

                    if (isHeader)
                        verbage = "NewFin";
                    MergeCellAddBox(oSheet, "M" + row.ToString(), "N" + row.ToString(), verbage, withBorder);
                }
                else
                {
                    if (isHeader)
                        verbage = "Actual LBS";
                    MergeCellAddBox(oSheet, "L" + row.ToString(), "N" + row.ToString(), verbage, withBorder);

                }

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
            
            oXL = new Excel.Application();


            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            DBUtils db = new DBUtils();
            lblUpdate.Text = "Opening Database.";
            db.OpenSQLConn();

            DateTime dtNow = DateTime.Now;
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
                            int totCoilCnt = 0;
                            decimal weightTot = 0;
                            string custName = "";
                            while (reader.Read())
                            {

                                if (addCustRow)
                                {
                                    
                                    custName = reader.GetString(reader.GetOrdinal("longCustomerName")).Trim();
                                    lblUpdate.Text = "Getting information for " + custName + ".";
                                    string[] cName = { custName + " - " + dtNow.ToString("d") };
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
                                totCoilCnt += pieces;

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

                                string poNum = reader.GetString(reader.GetOrdinal("dtlPO")).Trim();

                                int recID = reader.GetInt32(reader.GetOrdinal("receiveID"));

                                DateTime recDate = reader.GetDateTime(reader.GetOrdinal("receiveDate"));

                                
                                object[] info = {coilTag, pieces, alloy,thk,width,
                                        length, pvc, paper,weight, carbon,
                                        mill,heat,coo,location,vendor,poNum,recID, recDate.ToString("d"),weightTot };

                                InvAddRow(row, oSheet, info);


                                row++;
                            }

                            object[] totals = { "Total Weight: " + weightTot.ToString("###,###,###").Trim(),"","", "Coil Count: " + totCoilCnt.ToString().Trim() };
                            InvAddRow(row, oSheet, totals, "D");
                            row += 2;
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
                            int skidweight = 0;
                            string custName = "";
                            bool firstSkidRow = true;
                            int totSkidWeight = 0;
                            int totskidCnt = 0;
                            while (reader.Read())
                            {
                                if (addCustRow)
                                {
                                    custName = reader.GetString(reader.GetOrdinal("longCustomerName"));
                                    lblUpdate.Text = "Getting information for " + custName + ".";
                                    string[] cName = { custName + " - " + dtNow.ToString("d") };
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

                                skidweight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SkidWeight")));
                                totSkidWeight += skidweight;
                                totskidCnt++;

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

                                string customerPO = "";
                                if (!reader.IsDBNull(reader.GetOrdinal("customerPO")))
                                {
                                    customerPO = reader.GetString(reader.GetOrdinal("customerPO")).Trim();
                                }
                                

                                string dtSkidDate = "UNK";
                                
                                if (!reader.IsDBNull(reader.GetOrdinal("skidDate")))
                                {
                                    DateTime dtSkid = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("skidDate")));
                                    dtSkidDate = dtSkid.ToString("d");
                                        
                                }
                                

                                string comments = reader.GetString(reader.GetOrdinal("comments")).Trim();


                                object[] info = {coilTag, pieceCount, alloy,thk,width,
                                        length, pvc, paper,skidweight, carbon,
                                        mill,heat,coo,location,vendor,prime,dtSkidDate, orderID + "-" + customerPO,comments, };

                                InvAddRow(row, oSheet, info);
                                row++;

                            }

                            object[] totals = { "Total Weight: " + totSkidWeight.ToString("###,###,###").Trim(), "", "", "Skid Count: " + totskidCnt.ToString().Trim() };
                            InvAddRow(row, oSheet, totals, "D");
                            row += 2;
                            
                        }
                    }
                }
                
            }

            lblUpdate.Text = "Cleaning things up.";
            oSheet.Columns["Q:R"].AutoFit();
            
            oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
            oSheet.PageSetup.Zoom = false;
            oSheet.PageSetup.FitToPagesTall = 430;
            oSheet.PageSetup.FitToPagesWide = 1;
            oSheet.PageSetup.PrintArea = "A:S";
           
            db.CloseSQLConn();
            oXL.Visible = true;

            //make sure the file path is there.  ReportDrive is usual "T:\"
            string path = MachineDefaults.ReportDrive + @"Reports\Inventory\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //save the file
            oSheet.SaveAs(path + DateTime.Now.ToString("MMddyyyyHHmmss"));
            //set text back to whatever it was.
            lblUpdate.Text = updText;
        }

        private void InvHeader(int row, _Worksheet oSheet, bool skid = false)
        {
            string[] header;
            if (skid)
            {
                string[] skidheader = { "SkidID", "PCS", "Alloy", "Thk", "W", "Lng", "PVC", "PI",
                "Weight", "C", "Mill#", "Heat", "C/O", "Loc", "Vnd", "NotPrime", "Date", "WO#", "Comments" };
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

            object[,] arr = new object[lvwRunSheet.Items.Count + 1, lvwRunSheet.Columns.Count + 1];
            oSheet.get_Range("A1", "B1").Merge();
            oSheet.get_Range("A1", "B1").Value2 = lvwRunSheet.Tag.ToString();

            if (RSCoilCnt >= 0)
            {
                oSheet.get_Range("C1", "D1").Merge();
                oSheet.get_Range("C1", "D1").Value2 = "Count: " + RSCoilCnt.ToString("###,###");
            }
            if (RStotWeight >= 0)
            {
                oSheet.get_Range("F1", "G1").Merge();
                oSheet.get_Range("F1", "G1").Value2 = "LBS: " + RStotWeight.ToString("###,###,###");
            }
            if (RSPieceCnt >= 0)
            {
                oSheet.get_Range("I1", "J1").Merge();
                oSheet.get_Range("I1", "J1").Value2 = "Pieces: " + RSPieceCnt.ToString("###,###");
            }
            int topRow = 2;

            for (int i = 0;i< lvwRunSheet.Columns.Count;i++)
            {
                arr[0, i] = lvwRunSheet.Columns[i].Text;
            }

            int rowCnt = 0;
            for (int i = 0;i < lvwRunSheet.Items.Count;i++)
            {
                ListViewItem lv  = lvwRunSheet.Items[i];
                if (lv.ForeColor != Color.Red)
                {
                    for (int c = 0; c < lv.SubItems.Count; c++)
                    {
                        if (c == 0)
                        {
                            arr[rowCnt + 1, c] = rowCnt;
                        }
                        else
                        {
                            arr[rowCnt + 1, c] = lv.SubItems[c].Text;
                        }
                        

                    }
                    rowCnt++;
                }
                
               
                
                
            }

            WriteArray(oSheet, topRow, 1, arr);

            string path = MachineDefaults.ReportDrive + @"Reports\RunSheet\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //save the file
            oSheet.SaveAs(path + DateTime.Now.ToString("MMddyyyyHHmmss"));

            oXL.Visible = true;
            //oXL.Quit();
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
                    bool hasSkidHeader = false;
                    bool hasCoilHeader = false;
                    Excel.Application oXL;
                    Excel._Workbook oWB;
                    Excel._Worksheet oSheet;


                    oXL = new Excel.Application();


                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                    oSheet.get_Range("A1", "D1").Merge();
                    oSheet.Cells[1, 1] = "Report from TSA Processing: ";
                    int materialType = 0;
                    while (reader.Read())
                    {
                        
                        transferID = reader.GetInt32(reader.GetOrdinal("transferID"));

                        
                        int tagid = reader.GetInt32(reader.GetOrdinal("transferCoilTagID"));
                        coilTagID = tagid;
                        string suffix = reader.GetString(reader.GetOrdinal("transferCoilTagSuffix")).Trim();
                        coilTagSuffix = suffix;
                        string skidLetter = reader.GetString(reader.GetOrdinal("transferLetter")).Trim();
                        letter = skidLetter;

                        origCust = reader.GetString(reader.GetOrdinal("origCust")).Trim();
                        newCust = reader.GetString(reader.GetOrdinal("newCust")).Trim();
                        PO = reader.GetString(reader.GetOrdinal("purchaseOrder")).Trim();
                        dtTrans = reader.GetDateTime(reader.GetOrdinal("transferDate"));
                        materialType = reader.GetInt32(reader.GetOrdinal("materialType"));
                        if (!hasCoilHeader && !hasSkidHeader)
                        {
                            oSheet.Cells[rowCnt, 1] = "Transfer ID:";


                            oSheet.Cells[rowCnt, 2] = transferID;
                        }
                       
                        string fullTag = tagid.ToString() + suffix;
                        if (skidLetter.Length > 0)
                        {
                            fullTag += "." + skidLetter;
                        }

                        tags.Add(fullTag);

                        cellValue = oSheet.Cells[2, 3].Value?.ToString() ?? "";

                        for (int i = 0; i < tags.Count(); i++)
                        {
                            if (i == 0)
                                cellValue += tags[i];

                            else
                                cellValue += ", " + tags[i];
                        }

                        rowCnt++;

                        
                    
                        if (materialType == 1)
                        {
                            using (DbDataReader reader1 = db.GetSkidInfo("-1", coilTagID, coilTagSuffix, letter, true))
                            {
                                if (reader1.HasRows)
                                {
                                    if (!hasSkidHeader)
                                    {
                                        object[] info1 = {"Tag", "PCS", "Alloy","THK","Wdth",
                                            "LNG", "PVC", "PAP","LBS", "Carbon",
                                            "Mill","Heat","COO","LOC","VND","PRIME","Date", "Order","Comments", };

                                        InvAddRow(rowCnt, oSheet, info1, "R");
                                        rowCnt++;
                                        hasSkidHeader = true;
                                    }
                                    
                                    while (reader1.Read())
                                    {


                                        tagID = reader1.GetInt32(reader1.GetOrdinal("coilTagID")).ToString();
                                        coilTagSuffix = reader1.GetString(reader1.GetOrdinal("coilTagSuffix")).Trim();

                                        skidLetter = reader1.GetString(reader1.GetOrdinal("letter"));
                                        string coilTag = tagID.ToString().Trim() + coilTagSuffix + "." + skidLetter;

                                        int pieceCount = reader1.GetInt32(reader1.GetOrdinal("pieceCount"));

                                        string alloyDesc = reader1.GetString(reader1.GetOrdinal("AlloyDesc")).Trim();
                                        string finishDesc = reader1.GetString(reader1.GetOrdinal("FinishDesc")).Trim();
                                        string alloy = alloyDesc + " " + finishDesc;

                                        decimal thk = reader1.GetDecimal(reader1.GetOrdinal("thickness"));
                                        decimal width = reader1.GetDecimal(reader1.GetOrdinal("width"));
                                        decimal length = reader1.GetDecimal(reader1.GetOrdinal("length"));

                                        int intPaper = reader1.GetInt32(reader1.GetOrdinal("paper"));

                                        string paper = "Y";
                                        if (intPaper == 0)
                                        {
                                            paper = "N";
                                        }
                                        int intPvc = reader1.GetInt32(reader1.GetOrdinal("pvcID"));

                                        string pvc = "Y";
                                        if (intPvc == 0)
                                        {
                                            pvc = "N";
                                        }


                                        decimal sheetWeight = reader1.GetDecimal(reader1.GetOrdinal("sheetWeight"));

                                        int skidweight = Convert.ToInt32(reader1.GetValue(reader1.GetOrdinal("SkidWeight")));


                                        decimal carbon = reader1.GetDecimal(reader1.GetOrdinal("carbon"));

                                        string heat = reader1.GetString(reader1.GetOrdinal("heat")).Trim();

                                        string mill = reader1.GetString(reader1.GetOrdinal("millCoilNum")).Trim();

                                        string coo = reader1.GetString(reader1.GetOrdinal("countryOfOrigin")).Trim();

                                        string location = reader1.GetString(reader1.GetOrdinal("location"));

                                        string vendor = reader1.GetString(reader1.GetOrdinal("vendor"));

                                        string skidType = reader1.GetString(reader1.GetOrdinal("skidDescription"));

                                        int notPrime = reader1.GetInt32(reader1.GetOrdinal("notPrime"));
                                        string prime = "";
                                        if (notPrime > 0)
                                        {
                                            prime = "Not Prime";
                                        }
                                        int orderID = reader1.GetInt32(reader1.GetOrdinal("orderID"));
                                        string dtSkidDate = "UNK";

                                        if (!reader1.IsDBNull(reader1.GetOrdinal("skidDate")))
                                        {
                                            DateTime dtSkid = Convert.ToDateTime(reader1.GetValue(reader1.GetOrdinal("skidDate")));
                                            dtSkidDate = dtSkid.ToString("d");

                                        }


                                        string comments = reader1.GetString(reader1.GetOrdinal("comments")).Trim();


                                        object[] info = {coilTag, pieceCount, alloy,thk,width,
                                            length, pvc, paper,skidweight, carbon,
                                            mill,heat,coo,location,vendor,prime,dtSkidDate, orderID,comments, };

                                        InvAddRow(rowCnt, oSheet, info, "R");
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (DbDataReader reader1 = db.GetCoilInfo(coilTagID, coilTagSuffix,0,null,true))
                            {
                                if (reader1.HasRows)
                                {
                                    if (!hasCoilHeader)
                                    {
                                        object[] info1 = {"TAG", "Count", "Alloy","THK","Width",
                                            "Length", "PVC", "Paper","LBS", "Carbon",
                                            "Mill#","Heat","COO","Loc","VND","PO","Rec#", "RecDate" };

                                        InvAddRow(rowCnt, oSheet, info1, "R");
                                        rowCnt++;
                                        hasCoilHeader = true;
                                    }
                                    

                                    while (reader1.Read())
                                    {
                                        tagID = reader1.GetInt32(reader1.GetOrdinal("coilTagID")).ToString() ;
                                        coilTagSuffix = reader1.GetString(reader1.GetOrdinal("coilTagSuffix")).Trim();
                                        string coilTag = tagID.ToString().Trim() + coilTagSuffix;

                                        int pieces = reader1.GetInt32(reader1.GetOrdinal("coilCount"));
                                   

                                        string alloyDesc = reader1.GetString(reader1.GetOrdinal("AlloyDesc")).Trim();
                                        string finishDesc = reader1.GetString(reader1.GetOrdinal("FinishDesc")).Trim();
                                        string alloy = alloyDesc + " " + finishDesc;

                                        decimal thk = reader1.GetDecimal(reader1.GetOrdinal("thickness"));
                                        decimal width = reader1.GetDecimal(reader1.GetOrdinal("width"));
                                        decimal length = reader1.GetDecimal(reader1.GetOrdinal("length"));

                                        int intPaper = reader1.GetInt32(reader1.GetOrdinal("paper"));

                                        string paper = "Y";
                                        if (intPaper == 0)
                                        {
                                            paper = "N";
                                        }
                                        int intPvc = reader1.GetInt32(reader1.GetOrdinal("pvc"));

                                        string pvc = "Y";
                                        if (intPvc == 0)
                                        {
                                            pvc = "N";
                                        }

                                        decimal weight = reader1.GetDecimal(reader1.GetOrdinal("weight"));
                                    
                                        decimal carbon = reader1.GetDecimal(reader1.GetOrdinal("carbon"));

                                        string heat = reader1.GetString(reader1.GetOrdinal("heat")).Trim();
                                        string mill = reader1.GetString(reader1.GetOrdinal("millCoilNum")).Trim();

                                        string coo = reader1.GetString(reader1.GetOrdinal("countryOfOrigin")).Trim();

                                        string location = reader1.GetString(reader1.GetOrdinal("location")).Trim();

                                        string vendor = reader1.GetString(reader1.GetOrdinal("vendor")).Trim();

                                        string poNum = reader1.GetString(reader1.GetOrdinal("dtlPO")).Trim();

                                        int recID = reader1.GetInt32(reader1.GetOrdinal("receiveID"));

                                        DateTime recDate = reader1.GetDateTime(reader1.GetOrdinal("receiveDate"));


                                        object[] info = {coilTag, pieces, alloy,thk,width,
                                            length, pvc, paper,weight, carbon,
                                            mill,heat,coo,location,vendor,poNum,recID, recDate.ToString("d") };

                                        InvAddRow(rowCnt, oSheet, info, "R");
                                    }
                                }
                            }
                        }
                    }

                    reader.Close();
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

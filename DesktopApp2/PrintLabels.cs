using FluentFTP;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Objects;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Printing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;
using static DesktopApp2.FormICMSMain;
using static ICMS.CompleteOrders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.IO;
using Org.BouncyCastle.Crypto;

namespace ICMS
{
    class PrintLabels
    {

        public class ShipLabelInfo
        {
            public string dtShip;
            public string strCust;
            public string strPO;
            public int tagID;
            public string coilTagSuffix;
            public string letter;
            public string strTagID;
            public int cntr;
        }

        public class coilLabelInfo
        {
            private string millnum;
            public string MillNum
            {
                get { return millnum; }
                set { millnum = value; }
            }

            private string alloy;
            public string Alloy
            {
                get { return alloy; }
                set { alloy = value; }
            }

            private decimal length;
            public decimal Length
            {
                get { return length; }
                set { length = value; }
            }
            private decimal thickness;
            public decimal Thickness
            {
                get { return thickness; }
                set { thickness = value; }
            }
            private decimal width;
            public decimal Width
            {
                get { return width; }
                set { width = value; }
            }

            private int coilCount;
            public int CoilCount
            {
                get { return coilCount; }
                set { coilCount = value; }
            }

            private int weight;
            public int Weight
            {
                get { return weight; }
                set { weight = value; }
            }

            private int type;
            public int Type
            {
                get { return type; }
                set { type = value; }
            }

            private string recDate;
            public string RecDate
            {
                get { return recDate; }
                set { recDate = value; }
            }
            private string heat;
            public string Heat
            {
                get { return heat; }
                set { heat = value; }
            }

            private string location;
            public string Location
            {
                get { return location; }
                set { location = value; }
            }
            private string tagID;
            public string TagID
            {
                get { return tagID; }
                set { tagID = value; }
            }
            private string vendor;
            public string Vendor
            {
                get { return vendor; }
                set { vendor = value; }
            }
            private string custName;
            public string CustName
            {
                get { return custName; }
                set { custName = value; }
            }
            private string po;
            public string PO
            {
                get { return po; }
                set { po = value; }
            }
            private int recID;

            public int RecID
            {
                get { return recID; }
                set { recID = value; }
            }
            private decimal carbon;

            public decimal Carbon
            {
                get { return carbon; }
                set { carbon = value; }
            }
            private string coo;//country of origin
            public string COO
            {
                get { return coo; }
                set { coo = value; }
            }
            private string skidSteelDesc;
            public string SkidSteelDesc
            {
                get { return skidSteelDesc; }
                set { skidSteelDesc = value; }
            }
            private List<string> damage;

            public List<string> Damage
            {
                get { return damage; }
                set { damage = value;}
            }
        }


        public coilLabelInfo CoilLabelInfo = new coilLabelInfo();

        public class skidLabelInfo
        {
            public bool rec = false;
            

            private string location;
            public string Location
            {
                get { return location; }
                set { location = value; }
            }
            private string comments;
            public string Comments
            {
                get { return comments; }
                set { comments = value; }
            }
            private decimal gauge;
            public decimal Gauge
            {
                get { return gauge; }
                set { gauge = value; }
            }
            private decimal width;
            public decimal Width
            {
                get { return width; }
                set { width = value; }
            }
            private decimal length;
            public decimal Length
            {
                get { return length; }
                set { length = value; }
            }
            private int type;
            public int Type
            {
                get { return type; }
                set { type = value; }
            }
            private string alloy;
            public string Alloy
            {
                get { return alloy; }
                set { alloy = value; }
            }
            private int orderID;
            public int OrderID
            {
                get { return orderID; }
                set { orderID = value; }
            }
            private string heat;
            public string Heat
            {
                get { return heat; }
                set { heat = value; }
            }
            private string mill;
            public string Mill
            {
                get { return mill; }
                set { mill = value; }
            }
            private string vendor;
            public string Vendor
            {
                get { return vendor; }
                set { vendor = value; }
            }
            private int theoweight;
            public int TheoWeight
            {
                get { return theoweight; }
                set { theoweight = value; }
            }
            private string custName;
            public string CustName
            {
                get { return custName; }
                set { custName = value; }
            }
            private string po;
            public string PO
            {
                get { return po; }
                set { po = value; }
            }
            private int pieces;
            public int Pieces
            {
                get { return pieces; }
                set { pieces = value; }
            }
            private string recdate;
            public string RecDate
            {
                get { return recdate; }
                set { recdate = value; }
            }
            private decimal carbon;
            public decimal Carbon
            {
                get { return carbon; }
                set { carbon = value; }
            }
            private string coo;//country of origin
            public string COO
            {
                get { return coo; }
                set { coo = value; }
            }
            private int skidID;
            public int SkidID
            {
                get { return skidID; }
                set { skidID = value; }
            }

            private string skidletter;
            public string SkidLetter
            {
                get { return skidletter; }
                set { skidletter = value; }
            }
            private string coilTagSuffix;
            public string CoilTagSuffix
            {
                get { return coilTagSuffix; }
                set { coilTagSuffix = value; }
            }
            private string skidIDstring;
            public string SkidIDString
            {
                get { return skidIDstring; }
                set { skidIDstring = value; }
            }

            private string skidSteelDesc;
            public string SkidSteelDesc
            {
                get { return skidSteelDesc; }
                set { skidSteelDesc = value; }
            }

        }
        
        public PVCTagInfo pvcTagInfo = new PVCTagInfo();

        public class PVCTagInfo
        {
            private string custName;

            public string CustName
            {
                get { return custName; }
                set { custName = value; }
            }

            private decimal width;

            public decimal Width
            {
                get { return width;}
                set { width = value; }
            }
            private int tagID;

            public int TagID
            {
                get { return tagID;}
                set { tagID = value; }
            }

            private string shortDesc;

            public string ShortDesc
            {
                get { return shortDesc; }
                set { shortDesc = value; }
            }

            private string longDesc;
            public string LongDesc
            {
                get { return longDesc; }
                set { longDesc = value; }
            }

            private string poNum;

            public string PoNum
            {
                get { return poNum; }
                set { poNum = value; }
            }

            private int recID;

            public int RecID
            {
                get { return recID; }
                set { recID = value; }
            }

            private DateTime recDate;

            public DateTime RecDate
            {
                get { return recDate; }
                set { recDate = value; }
            }
            private string location;

            public string Location
            {
                get { return location; }
                set { location = value; }
            }
        }

        public skidLabelInfo SkidLabelInfo = new skidLabelInfo();

        private void SkidLabel(string strPrinter)
        {
            StringBuilder sb = new StringBuilder();


            string strType = SkidLabelInfo.SkidSteelDesc; 

            string skidIDDesc = "";
            if (SkidLabelInfo.SkidID == -1)
            {
                skidIDDesc = SkidLabelInfo.SkidIDString;
            }
            else
            {
                skidIDDesc = SkidLabelInfo.SkidID + SkidLabelInfo.CoilTagSuffix + "." + SkidLabelInfo.SkidLetter;
            }

            sb.Append("<STX><ESC>C<ETX>\r\n");
            sb.Append("<STX><ESC>P<ETX>\r\n");
            sb.Append("<STX>E4;F4;<ETX>\r\n");
            sb.Append("<STX>H0;o1,0;f0;c26;h18;w20;d0,32;<ETX>\r\n");
            sb.Append("<STX>H1;o1,40;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H2;o1,75;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H3;o1,110;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H4;o1,150;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H5;o1,190;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H6;o1,230;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H7;o1,270;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H8;o475,40;f0;c26;h30;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H9;o475,110;f0;c26;h18;w20;d0,15;<ETX>\r\n");
            sb.Append("<STX>H10;o475,150;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H11;o475,190;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H12;o475,230;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H13;o475,270;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H14;o1,710;f0;h18;w20;c26;d0,30 ;<ETX>\r\n");
            sb.Append("<STX>H15;o1,760;f0;h18;w20;c26;d0,30;<ETX>\r\n");
            sb.Append("<STX>H16;o1,323;f0;c26;h180;w75;d0,30;<ETX>\r\n");//w75 controls width of large tagid
            sb.Append("<STX>B17;o1,317;c0,0;h45;i1;d0,10;<ETX>\r\n");
            sb.Append("<STX>B18;o1,380;c0,0;h50;w6;i1;d0,10;<ETX>\r\n");
            sb.Append("<STX>H19;o960,0;f0;c26;h15;w11;d0,32;<ETX>\r\n");



            sb.Append("<STX>L27;o1,710;f0;l1100;w4;<ETX>\r\n");
            sb.Append("<STX>R;<ETX>\r\n");
            sb.Append("<STX><ESC>E4<ETX>\r\n");
            sb.Append("<STX><CAN><ETX>\r\n");

            sb.Append("<STX>" + SkidLabelInfo.Gauge.ToString("G29").Trim() + " X " + SkidLabelInfo.Width.ToString("G29").Trim() + " X " +SkidLabelInfo.Length.ToString("G29").Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>" + strType + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.Alloy + "<CR><ETX>\r\n");
            if (SkidLabelInfo.rec)
            {
                sb.Append("<STX>RecID: " + SkidLabelInfo.OrderID + "<CR><ETX>\r\n");
            }
            else
            {
                sb.Append("<STX>Order: " + SkidLabelInfo.OrderID + "<CR><ETX>\r\n");
            }
            
            sb.Append("<STX>Heat: " + SkidLabelInfo.Heat + "<CR><ETX>\r\n");
            sb.Append("<STX>Mill: " + SkidLabelInfo.Mill + "<CR><ETX>\r\n");
            sb.Append("<STX>Vend: " + SkidLabelInfo.Vendor + "<CR><ETX>\r\n");
            sb.Append("<STX>ThWt: " + SkidLabelInfo.TheoWeight + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.CustName + "<CR><ETX>\r\n");
            sb.Append("<STX>PO: " + SkidLabelInfo.PO + "<CR><ETX>\r\n");
            sb.Append("<STX>PCS: " + SkidLabelInfo.Pieces + "<CR><ETX>\r\n");
            sb.Append("<STX>Date: " + SkidLabelInfo.RecDate + "<CR><ETX>\r\n");

            sb.Append("<STX>Cb: " + SkidLabelInfo.Carbon + "<CR><ETX>\r\n");
            sb.Append("<STX>C of O: " + SkidLabelInfo.COO + "<CR><ETX>\r\n");

            sb.Append("<STX>" + SkidLabelInfo.Location + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.Comments + "<CR><ETX>\r\n");


            sb.Append("<STX>" + skidIDDesc + "<CR><ETX>\r\n");
            sb.Append("<STX>" + skidIDDesc + "<CR><ETX>\r\n");
            sb.Append("<STX>" + skidIDDesc + "<CR><ETX>\r\n");


            sb.Append("<STX><ETB><ETX>\r\n");

            SendToPrinter(sb, strPrinter);
        }

        //************start******************

        public void CoilLabel(string strPrinter)

        {

            string strType = CoilLabelInfo.SkidSteelDesc;
           
     
            StringBuilder sb = new StringBuilder();
            sb.Append("<STX><ESC>P<ETX>\r\n");
            sb.Append("<STX>E4;F4;<ETX>\r\n");
            sb.Append("<STX>H0;o1,80;f0;c26;h18;w20;d0,32;<ETX>\r\n");
            sb.Append("<STX>H1;o1,115;f0;c26;h18;w20;d0,15;<ETX>\r\n");
            sb.Append("<STX>H2;o1,149;f0;c26;h18;w20;d0,25;<ETX>\r\n");
            sb.Append("<STX>H3;o1,185;f0;c26;h18;w20;d0,32;<ETX>\r\n");
            sb.Append("<STX>H4;o1,222;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H5;o1,260;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H6;o1,300;f0;c26;h18;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H7;o1,340;f0;c26;h18;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H8;o475,110;f0;c26;h30;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H9;o475,185;f0;c26;h18;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H10;o475,222;f0;c26;h18;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H11;o475,260;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H12;o475,300;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H13;o475,340;f0;c26;h18;w20;d0,28;<ETX>\r\n"); 
            sb.Append("<STX>H14;o1,403;f0;c26;h180;w75;d0,30;<ETX>\r\n");//w75 controls width of large tagid

            sb.Append("<STX>H15;o1,0;f0;h28;w48;c25;r0;b3;d3, TSA INVENTORY LABEL ;<ETX>\r\n");
            sb.Append("<STX>B16;o1,397;c0,0;h45;i1;d0,10;<ETX>\r\n");
            sb.Append("<STX>B17;o1,460;c0,0;h50;w6;i1;d0,10;<ETX>\r\n");
            sb.Append("<STX>H18;o960,210;f0;c26;h15;w14;d0,32;<ETX>\r\n");


            //    'add damage if needed
            int cntr = 19;
            int nSpaceDamage = 250;
            int ntmp = 1;
            //Set rsDamage = getCoilDamage(lTagIDNew)


            bool bdamage = false;
            if (CoilLabelInfo.Damage != null)
            {
                for (int i = 0; i < CoilLabelInfo.Damage.Count; i++)
                {
                    bdamage = true;
                    if (ntmp < 11)
                    {
                        sb.Append("<STX>H" + cntr + ";o960," + nSpaceDamage.ToString() + ";f0;c26;h10;w10;d0,16;<ETX>\r\n");
                        cntr++;
                        ntmp++;
                        nSpaceDamage += 20;
                    }
                }
            }
            
            //Do While Not rsDamage.EOF
            //    bdamage = True
            //    If ntmp< 11 Then 'there is only room for 11 damage desc on the label.
            //        strOutput = strOutput & _
            //                "<STX>H" & cntr & ";o960," & nSpaceDamage & ";f0;c26;h10;w10;d0,16;<ETX>" & vbCr
            //        cntr = cntr + 1
            //        ntmp = ntmp + 1
            //        nSpaceDamage = nSpaceDamage + 20
            //    End If
            //    rsDamage.MoveNext
            //Loop



            sb.Append("<STX>R;<ETX>\r\n");
            sb.Append("<STX><ESC>E4<ETX>\r\n");
            sb.Append("<STX><CAN><ETX>\r\n");




            sb.Append("<STX>" + CoilLabelInfo.Thickness + " X " + CoilLabelInfo.Width + " X " + CoilLabelInfo.Length + "<CR><ETX>\r\n");
            sb.Append("<STX>" + strType + "<CR><ETX>\r\n");
            sb.Append("<STX>" + CoilLabelInfo.Alloy + "<CR><ETX>\r\n");
            sb.Append("<STX>Weight: " + CoilLabelInfo.Weight + "<CR><ETX>\r\n");
            sb.Append("<STX>Heat: " + CoilLabelInfo.Heat + "<CR><ETX>\r\n");
            sb.Append("<STX>Mill: " + CoilLabelInfo.MillNum + "<CR><ETX>\r\n");
            sb.Append("<STX>Vend: " + CoilLabelInfo.Vendor + "<CR><ETX>\r\n");
            sb.Append("<STX>Loc:  " + CoilLabelInfo.Location + "<CR><ETX>\r\n");
            sb.Append("<STX>" + CoilLabelInfo.CustName + "<CR><ETX>\r\n");

            sb.Append("<STX>PO: " + CoilLabelInfo.PO + "<CR><ETX>\r\n");
            sb.Append("<STX>Rv: " + CoilLabelInfo.RecID + "-" +CoilLabelInfo.RecDate + "<CR><ETX>\r\n");
            sb.Append("<STX>Coil Count: " + CoilLabelInfo.CoilCount + "<CR><ETX>\r\n");
            sb.Append("<STX>Carbon: " + CoilLabelInfo.Carbon + "<CR><ETX>\r\n");
            sb.Append("<STX>C of O: " + CoilLabelInfo.COO + "<CR><ETX>\r\n");
            sb.Append("<STX>" + CoilLabelInfo.TagID + "<CR><ETX>\r\n");
            sb.Append("<STX>" + CoilLabelInfo.TagID + "<CR><ETX>\r\n");
            sb.Append("<STX>" + CoilLabelInfo.TagID + "<CR><ETX>\r\n");
            //sb.Append("<STX>DAMAGE:<CR><ETX>\r\n");

            if (!bdamage)
            {
                sb.Append("<STX><CR><ETX>\r\n");
            }
            else
            {
                sb.Append("<STX>Damage: Y<CR><ETX>\r\n");
                ntmp = 1;
                for (int i = 0;i < CoilLabelInfo.Damage.Count; i++)
                {
                    if (ntmp < 11)
                    {
                        sb.Append("<STX>" + CoilLabelInfo.Damage[i] + "<CR><ETX>\r\n");
                        ntmp++;
                    }
                }
            }
            //If bdamage = False Then
            //    strOutput = strOutput & _
            //            "<STX><CR><ETX>" & vbCr
            //Else
            //    strOutput = strOutput & _
            //            "<STX>Damage: Y<CR><ETX>" & vbCr
            //    rsDamage.MoveFirst
            //    ntmp = 1
            //    Do While Not rsDamage.EOF
            //        bdamage = True
            //        If ntmp< 11 Then 'there is only room for 11 damage desc on the label.
            //            strOutput = strOutput & _
            //                    "<STX>" & rsDamage!damagedesc & "<CR><ETX>" & vbCr
            //            ntmp = ntmp + 1
            //        End If
            //        rsDamage.MoveNext
            //    Loop
            //'rsDamage.Close







            sb.Append("<STX><ETB><ETX>\r\n");

            SendToPrinter(sb, strPrinter);

        }

        private void SkidLabelZebra(string strPrinter)
        {

            string strType = SkidLabelInfo.SkidSteelDesc;

            string skidIDDesc = "";
            if (SkidLabelInfo.SkidID == -1)
            {
                skidIDDesc = SkidLabelInfo.SkidIDString;
            }
            else
            {
                skidIDDesc = SkidLabelInfo.SkidID + SkidLabelInfo.CoilTagSuffix + "." + SkidLabelInfo.SkidLetter;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("^XA");
            sb.Append("^FWR");
            
            sb.Append("^CF0,90");
            sb.Append("^FO650,600^FD" + SkidLabelInfo.CustName.Trim() + "^FS");
            sb.Append("^CF0,50");
            sb.Append("^FO750,20^FD" + SkidLabelInfo.Pieces.ToString().Trim() + " PCS - ");
            sb.Append(SkidLabelInfo.Gauge.ToString("G29").Trim() + " X " + SkidLabelInfo.Width.ToString("G29").Trim() + " X " + SkidLabelInfo.Length.ToString("G29").Trim() + "^FS");
            sb.Append("^FO120,10^GB10,1200,10^FS");
            sb.Append("^FO705,20^FD" + strType.Trim() + "^FS");
            sb.Append("^FO660,20^FD" + SkidLabelInfo.Alloy.Trim() + "^FS");
            sb.Append("^CF0,40");
            if (SkidLabelInfo.rec)
            {
                sb.Append("^FO600,20^FDRecID: " + SkidLabelInfo.OrderID.ToString().Trim() + "^FS");
            }
            else
            {
                sb.Append("^FO600,20^FDOrder: " + SkidLabelInfo.OrderID.ToString().Trim() + "^FS");
            }
            
            sb.Append("^FO560,20^FDHeat: " + SkidLabelInfo.Heat.Trim() + "^FS");
            sb.Append("^FO520,20^FDMill: " + SkidLabelInfo.Mill.Trim() + "^FS");
            sb.Append("^FO480,20^FDVend: " + SkidLabelInfo.Vendor.Trim() + "^FS");
            sb.Append("^FO440,20^FDThWt: " + SkidLabelInfo.TheoWeight.ToString().Trim() + "^FS");
            sb.Append("^CF0,40");
            sb.Append("^FO600,500^FDPO: " + SkidLabelInfo.PO.Trim() + "^FS");
            sb.Append("^FO560,500^FDPCS: " + SkidLabelInfo.Pieces.ToString().Trim() + "^FS");
            sb.Append("^FO520,500^FDDate:" + SkidLabelInfo.RecDate.Trim() + "^FS");
            sb.Append("^FO480,500^FDCarbon: " + SkidLabelInfo.Carbon.ToString("G29").Trim() + "^FS");
            sb.Append("^FO440,500^FDC of O: " + SkidLabelInfo.COO.Trim() + "^FS");
            sb.Append("^BY7,3,80");
            sb.Append("^FO360,20^BC,,N^FD" + skidIDDesc + "^FS");
            sb.Append("^CF0,200");
            sb.Append("^FO90,20^FD" + skidIDDesc + "^FS");
            sb.Append("^CF0,40");
            sb.Append("^FO65,20^FD" + SkidLabelInfo.Location.Trim() + "^FS");
            sb.Append("^FO30,20^FD" + SkidLabelInfo.Comments.Trim() + "^FS");
            sb.Append("^XZ");


            string IPAddress = "";

            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            foreach (var queue in queues)
            {
                string printerName = queue.Name;
                if (printerName.Equals(strPrinter))
                {
                    IPAddress = queue.QueuePort.Name;
                }
                
            }

            if (IPAddress.Length > 0)
            {
                Connection connection = new TcpConnection(IPAddress, 9100);

                //var printerConn = new TcpConnection(strPrinter, 9100);

                connection.Open();

                ZebraPrinter p = ZebraPrinterFactory.GetInstance(connection);
                p.SendCommand(sb.ToString());

                connection.Close();
            }
            else
            {
                SendToPrinter(sb, strPrinter);
            }

            

            
            

            //string test = sb.ToString();

        }

        
        public void CoilLabelZebra(string strPrinter)
        {


            string strType = CoilLabelInfo.SkidSteelDesc;


            StringBuilder sb = new StringBuilder();
            sb.Append("^XA\r\n");
            sb.Append("^CF0,60");
            sb.Append("^FO740,10^GB70,1200,50^FS\r\n");
            sb.Append("^FWR^FO740,410^FR^FDTSA Processing^FS\r\n");
            sb.Append("^CF0,60\r\n");
            sb.Append("^FO670,20^FD" + CoilLabelInfo.Thickness.ToString("#0.00#") + " X " + CoilLabelInfo.Width.ToString("#0.00#") + " X " + CoilLabelInfo.Length.ToString("##0.00#") + "^FS\r\n");
            sb.Append("^FO600,20^FD" + strType + "^FS\r\n");
            sb.Append("^FO550,20^FD" + CoilLabelInfo.Alloy + "^FS\r\n");
            sb.Append("^CF0,40\r\n");
            sb.Append("^FO500,20^FDWeight: " + CoilLabelInfo.Weight + "^FS\r\n");
            sb.Append("^FO460,20^FDHeat: " + CoilLabelInfo.Heat + "^FS\r\n");
            sb.Append("^FO420,20^FDMill: " + CoilLabelInfo.MillNum + "^FS\r\n");
            sb.Append("^FO380,20^FDVend: " + CoilLabelInfo.Vendor + "^FS\r\n");
            sb.Append("^FO340,20^FDLoc: " + CoilLabelInfo.Location + "^FS\r\n");
            sb.Append("^CF0,90\r\n");
            sb.Append("^FO560,550^FD" + CoilLabelInfo.CustName + "^FS\r\n");
            sb.Append("^CF0,40\r\n");
            sb.Append("^FO500,500^FDPO: " + CoilLabelInfo.PO + "^FS\r\n");
            sb.Append("^FO460,500^FDRv: " + CoilLabelInfo.RecID + " - " + CoilLabelInfo.RecDate + "^FS\r\n");
            sb.Append("^FO420,500^FDCoil Count: " + CoilLabelInfo.CoilCount + "^FS\r\n");
            sb.Append("^FO380,500^FDCarbon: " + CoilLabelInfo.Carbon + "^FS\r\n");
            sb.Append("^FO340,500^FDC of O: " + CoilLabelInfo.COO + "^FS\r\n");
            sb.Append("^BY7,3,80\r\n");
            sb.Append("^FO255,20^BC,,N^FD" + CoilLabelInfo.TagID + "^FS\r\n");
            sb.Append("^CF0,230\r\n");
            sb.Append("^FO0,20^FD" + CoilLabelInfo.TagID + "^ FS\r\n");
            sb.Append("^XZ\r\n");

            string IPAddress = "";

            string temp = sb.ToString();
            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            foreach (var queue in queues)
            {
                string printerName = queue.Name;
                if (printerName.Equals(strPrinter))
                {
                    IPAddress = queue.QueuePort.Name;
                }

            }

            if (IPAddress.Length > 0)
            {
                Connection connection = new TcpConnection(IPAddress, 9100);

                //var printerConn = new TcpConnection(strPrinter, 9100);

                connection.Open();

                ZebraPrinter p = ZebraPrinterFactory.GetInstance(connection);
                p.SendCommand(sb.ToString());

                connection.Close();
            }
            else
            {
                SendToPrinter(sb, strPrinter);
            }

            string test = sb.ToString();

        }

        public void PVCLabel(string strPrinter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<STX><ESC>C<ETX>\r\n");
            sb.Append("<STX><ESC>P<ETX>\r\n");
            sb.Append("<STX>E4;F4;<ETX>\r\n");
            sb.Append("<STX>H0;o1,60;f0;c26;h36;w30;d0,32;<ETX>\r\n");
            sb.Append("<STX>H1;o1,120;f0;c26;h36;w30;d0,30;<ETX>\r\n");
            sb.Append("<STX>H2;o1,240;f0;c26;h20;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>B3;o1,460;c0,0;h85;w8;i1;d0,10;<ETX>\r\n");
            sb.Append("<STX>H4;o1,490;f0;c26;h130;w90;d0,30;<ETX>\r\n");
            sb.Append("<STX>H5;o1,350;f0;c26;h36;w30;d0,30;<ETX>\r\n");
            sb.Append("<STX>H6;o600,240;f0;c26;h20;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H7;o600,290;f0;c26;h20;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H8;o600,340;f0;c26;h20;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H9;o1,0;f0;h28;w48;c25;r0;b3;d3, PVC INVENTORY LABEL ;<ETX>\r\n");
            sb.Append("<STX>R;<ETX>\r\n");
            sb.Append("<STX><ESC>E4<ETX>\r\n");
            sb.Append("<STX><CAN><ETX>\r\n");
            sb.Append("<STX>" + pvcTagInfo.Width.ToString("G29") + " Wide<CR><ETX>\r\n");
            sb.Append("<STX>" + pvcTagInfo.ShortDesc + "<CR><ETX>\r\n");
            sb.Append("<STX>Desc: " + pvcTagInfo.LongDesc + " <CR><ETX>\r\n");
            sb.Append("<STX>" + pvcTagInfo.TagID.ToString() + "<CR><ETX>\r\n");
            sb.Append("<STX>" + pvcTagInfo.TagID.ToString() + "<CR><ETX>\r\n");
            sb.Append("<STX>" + pvcTagInfo.CustName + "<CR><ETX>\r\n");
            sb.Append("<STX>PO: " + pvcTagInfo.PoNum + "<CR><ETX>\r\n");
            sb.Append("<STX>RV: " + pvcTagInfo.RecID.ToString() + " - " + pvcTagInfo.RecDate.ToString("d") + "<CR><ETX>\r\n");
            sb.Append("<STX>Loc: " + pvcTagInfo.Location + "<CR><ETX>\r\n");
            sb.Append("<STX><ETB><ETX>\r\n");

            

            SendToPrinter(sb, strPrinter);

        }

        public void PVCLabelZebra(string strPrinter)
        {
            //test hi
            StringBuilder sb = new StringBuilder();
            //sb.Append("^XA\r\n");
            //sb.Append("^CF0,60");
            //sb.Append("^FO740,10^GB70,1200,50^FS\r\n");
            //sb.Append("^FWR^FO740,410^FR^FDPVC INVENTORY LABEL^FS\r\n");
            //sb.Append("^CF0,60\r\n");
            sb.Append("^FO670,20^FD" + pvcTagInfo.Width.ToString("G29") + " Wide^FS\r\n");
            sb.Append("^FO600,20^FD" + pvcTagInfo.ShortDesc + "^FS\r\n");
            
            sb.Append("^CF0,40\r\n");
            sb.Append("^FO500,20^FDDesc: " + pvcTagInfo.LongDesc + "^FS\r\n");
            sb.Append("^CF0,90\r\n");
            if (pvcTagInfo.CustName.Length <= 15)
            {
                sb.Append("^FO560,550^FD" + pvcTagInfo.CustName + "^FS\r\n");
            }
            else
            {
                sb.Append("^FO560,550^FD" + pvcTagInfo.CustName.Substring(0, 15) + "^FS\r\n");
            }
            sb.Append("^CF0,40\r\n");
            sb.Append("^FO500,500^FDPO: " + pvcTagInfo.PoNum + "^FS\r\n");
            sb.Append("^FO460,500^FDRv: " + pvcTagInfo.RecID.ToString() + " - " + pvcTagInfo.RecDate.ToString("d") + "^FS\r\n");
            sb.Append("^BY7,3,80\r\n");
            sb.Append("^FO255,20^BC,,N^FDP"+ pvcTagInfo.TagID.ToString() + "^FS\r\n");
            sb.Append("^CF0,230\r\n");
            sb.Append("^FO0,20^FD" + pvcTagInfo.TagID.ToString() + "^ FS\r\n");
            sb.Append("^XZ\r\n");

            string IPAddress = "";

            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            foreach (var queue in queues)
            {
                string printerName = queue.Name;
                if (printerName.Equals(strPrinter))
                {
                    IPAddress = queue.QueuePort.Name;
                }

            }

            if (IPAddress.Length > 0)
            {
                Connection connection = new TcpConnection(IPAddress, 9100);

                //var printerConn = new TcpConnection(strPrinter, 9100);

                connection.Open();

                ZebraPrinter p = ZebraPrinterFactory.GetInstance(connection);
                p.SendCommand(sb.ToString());

                connection.Close();
            }
            else
            {
                SendToPrinter(sb, strPrinter);
            }

            string test = sb.ToString();

        }


        public void PrintShShSameOperTag(int orderID, string strPrinter, bool Zebra = false)
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetShShSameOperTagInfo(orderID))
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        SkidLabelInfo.Gauge = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        SkidLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
                        SkidLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
                        string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                        string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                        SkidLabelInfo.Alloy = alloy + " " + finish;
                        SkidLabelInfo.OrderID = orderID;
                        SkidLabelInfo.Heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                        SkidLabelInfo.Mill = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                        SkidLabelInfo.CustName = reader.GetString(reader.GetOrdinal("shortCustomerName")).Trim();
                        SkidLabelInfo.Pieces = reader.GetInt32(reader.GetOrdinal("orderPieceCount"));
                        SkidLabelInfo.SkidID = reader.GetInt32(reader.GetOrdinal("skidID"));
                        SkidLabelInfo.CoilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string skidletter = reader.GetString(reader.GetOrdinal("skidLetter")).Trim();
                        string ordLetter = reader.GetString(reader.GetOrdinal("orderLetter")).Trim();
                        SkidLabelInfo.SkidLetter = skidletter + "." + ordLetter;
                        SkidLabelInfo.SkidIDString = SkidLabelInfo.SkidID + SkidLabelInfo.CoilTagSuffix + "." + skidletter + "." + ordLetter;

                        if (Zebra)
                        {
                            ZebraOperatorTag(strPrinter);
                        }
                        else
                        {
                            OperatorTag(strPrinter);
                        }

                    }
                }
            }


        }

        public string findOperatorType(int orderID)
        {
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            string procFunc = "";
            using (DbDataReader reader = db.GetMachineOrders(orderID))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        procFunc = reader.GetString(reader.GetOrdinal("processFunction")).Trim();
                        int procID = reader.GetInt32(reader.GetOrdinal("processID"));
                    }
                }
                
            }
            return procFunc;
        }

        public void PrintOperatorTag(int orderID, string strPrinter, bool Zebra = false)
        {

            switch (findOperatorType(orderID))
            {
                case ProcessFunction.ShShSame:
                    PrintShShSameOperTag(orderID,strPrinter,Zebra);
                    
                    return;
                    


            }

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetOperatorTagInfo(orderID))
            {
                if (reader.HasRows)
                {

                    int prevTagID = -999;
                    string prevSuffix = "";
                    SkidSetup sp = new SkidSetup();
                    while (reader.Read())
                    {
                        SkidLabelInfo.CustName = reader.GetString(reader.GetOrdinal("longCustomerName"));
                        SkidLabelInfo.SkidID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                        SkidLabelInfo.CoilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        SkidLabelInfo.Gauge = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        SkidLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
                        SkidLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
                        string alloy = reader.GetString(reader.GetOrdinal("alloyDesc"));
                        string finish = reader.GetString(reader.GetOrdinal("finishDesc"));


                        SkidLabelInfo.Alloy = alloy.Trim() + " " + finish.Trim();
                        SkidLabelInfo.OrderID = orderID;
                        SkidLabelInfo.Pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                        SkidLabelInfo.Mill = reader.GetString(reader.GetOrdinal("millCoilNum"));
                        SkidLabelInfo.Heat = reader.GetString(reader.GetOrdinal("heat"));

                        int skidcount = reader.GetInt32(reader.GetOrdinal("skidCount"));


                        bool isA = false;
                        if (prevTagID == -999)
                        {
                            prevTagID = SkidLabelInfo.SkidID;
                            prevSuffix = SkidLabelInfo.CoilTagSuffix.Trim();
                            string maxLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                            if (maxLetter.Equals(""))
                            {
                                maxLetter = "A";
                                isA = true;
                            }
                            sp.SetFirstLetter(maxLetter);
                            if (!isA)
                            {
                                //we didn't start with A so have to increment to next higher letter
                                maxLetter = sp.GetNextLetter();
                            }
                            
                            SkidLabelInfo.SkidLetter = maxLetter;

                        }
                        else
                        {
                            if (SkidLabelInfo.SkidID != prevTagID || !SkidLabelInfo.CoilTagSuffix.Equals(prevSuffix))
                            {
                                prevTagID = SkidLabelInfo.SkidID;
                                prevSuffix = SkidLabelInfo.CoilTagSuffix.Trim();
                                string maxLetter = reader.GetString(reader.GetOrdinal("MaxLetter")).Trim();
                                if (maxLetter.Equals(""))
                                {
                                    maxLetter = "A";
                                    isA = true;
                                }
                                sp.SetFirstLetter(maxLetter);
                                if (!isA)
                                {
                                    //we didn't start with A so have to increment to next higher letter
                                    maxLetter = sp.GetNextLetter();
                                }
                                SkidLabelInfo.SkidLetter = maxLetter;

                            }
                        }
                        
                        


                        
                        for (int i = 0; i < skidcount; i++)
                        {
                            if (Zebra)
                            {
                                ZebraOperatorTag(strPrinter);
                            }
                            else
                            {
                                OperatorTag(strPrinter);
                            }
                            SkidLabelInfo.SkidLetter = sp.GetNextLetter();
                                

                        }




                    }
                }
            }
        }

        public void OperatorTag(string strPrinter)
        {

            string skidIDDesc = "";
            if (SkidLabelInfo.SkidID == -1)
            {
                skidIDDesc = SkidLabelInfo.SkidIDString;
            }
            else
            {
                skidIDDesc = SkidLabelInfo.SkidID + SkidLabelInfo.CoilTagSuffix.Trim() + "." + SkidLabelInfo.SkidLetter;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<STX><ESC>C<ETX>\r\n");
            sb.Append("<STX><ESC>P<ETX>\r\n");
            sb.Append("<STX>E4;F4;<ETX>\r\n");
            sb.Append("<STX>H0;o1,192;f0;c26;h18;w20;d0,32;<ETX>\r\n");
            sb.Append("<STX>H1;o1,230;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H2;o1,307;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H3;o1,365;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H4;o1,423;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H5;o1,500;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H6;o1,616;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H7;o692,240;f0;c26;h18;w20;d0,20;<ETX>\r\n");
            sb.Append("<STX>H8;o692,307;f0;c26;h18;w20;d0,15;<ETX>\r\n");
            sb.Append("<STX>H9;o692,365;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H10;o692,423;f0;c26;h18;w20;d0,18;<ETX>\r\n");
            sb.Append("<STX>H11;o475,500;f0;c26;h18;w20;d0,30;<ETX>\r\n");
            sb.Append("<STX>H12;o475,660;f0;c26;h36;w36;d0,30;<ETX>\r\n");
            sb.Append("<STX>R;<ETX>\r\n");
            sb.Append("<STX><ESC>E4<ETX>\r\n");
            sb.Append("<STX><CAN><ETX>\r\n");
            sb.Append("<STX>" + PlantLocation.city + "<CR><ETX>\r\n");
            sb.Append("<STX>" + "" + "<CR><ETX>\r\n");
            sb.Append("<STX>" + "Date: ________________ " + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.CustName.Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.Gauge.ToString("G29").Trim() + " X " + SkidLabelInfo.Width.ToString("G29").Trim() + " X " + SkidLabelInfo.Length.ToString("G29").Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>" + "Part# _____________" + "<CR><ETX>\r\n");
            sb.Append("<STX>" + "Operator ____________________" + "<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.Alloy.Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>Order: " + SkidLabelInfo.OrderID.ToString().Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>Pieces: (" + SkidLabelInfo.Pieces.ToString().Trim() + ")_________<CR><ETX>\r\n");
            sb.Append("<STX>" + SkidLabelInfo.Mill.Trim() + "/" + SkidLabelInfo.Heat.Trim() + "<CR><ETX>\r\n");
            sb.Append("<STX>Checked By: __________________ <CR><ETX>\r\n");
            sb.Append("<STX>TAG:" + skidIDDesc + "<CR><ETX>\r\n");
            sb.Append("<STX><ETB><ETX>\r\n");

            SendToPrinter(sb, strPrinter);

        }
        public void ZebraOperatorTag(string strPrinter)
        {

        
            string strType = SkidLabelInfo.SkidSteelDesc;

            string skidIDDesc = "";
            if (SkidLabelInfo.SkidID == -1)
            {
                skidIDDesc = SkidLabelInfo.SkidIDString;
            }
            else
            {
                skidIDDesc = SkidLabelInfo.SkidID + SkidLabelInfo.CoilTagSuffix.Trim() + "." + SkidLabelInfo.SkidLetter;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("^XA");
            sb.Append("^FWR");
            sb.Append("^CF0,150");
            sb.Append("^FO600,20^FD" + SkidLabelInfo.CustName.Trim() + "^FS");
            sb.Append("^FO20,20^FD" + skidIDDesc + "^FS");
            sb.Append("^CF0,50");
            sb.Append("^FO500,20^FDDate: _________________^FS");
            sb.Append("^FO400,20^FD" + SkidLabelInfo.Gauge.ToString("G29").Trim() + " X " + SkidLabelInfo.Width.ToString("G29").Trim() + " X " + SkidLabelInfo.Length.ToString("G29").Trim() + "^FS");
            sb.Append("^FO300,20^FDPart#_________________^FS");
            sb.Append("^FO200,20^FDOperator_________________^FS");
            sb.Append("^FO500,700^FD" + SkidLabelInfo.Alloy.Trim() + "^FS");
            sb.Append("^FO450,700^FDOrder: " + SkidLabelInfo.OrderID.ToString().Trim() + "^FS");
            sb.Append("^FO400,700^FDPieces:(" + SkidLabelInfo.Pieces.ToString().Trim() + ")______^FS");
            sb.Append("^FO300,700^" + SkidLabelInfo.Mill.Trim() + "/" + SkidLabelInfo.Heat.Trim() + "^FS");
            sb.Append("^FO200,650^FDChecked By____________^FS");
            sb.Append("^XZ");

            string IPAddress = "";

            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            foreach (var queue in queues)
            {
                string printerName = queue.Name;
                if (printerName.Equals(strPrinter))
                {
                    IPAddress = queue.QueuePort.Name;
                }

            }

            if (IPAddress.Length > 0)
            {
                Connection connection = new TcpConnection(IPAddress, 9100);

                //var printerConn = new TcpConnection(strPrinter, 9100);

                connection.Open();

                ZebraPrinter p = ZebraPrinterFactory.GetInstance(connection);
                p.SendCommand(sb.ToString());

                connection.Close();
            }
            else
            {
                SendToPrinter(sb, strPrinter);
            }
        }

        public void PrintCoils(List<CoilsToPrint> coilToPrint)
        {
            if (coilToPrint.Count > 0)
            {
                DBUtils db = new DBUtils();

                db.OpenSQLConn();

                for (int i = 0; i < coilToPrint.Count; i++)
                {
                    using(DbDataReader reader = db.GetCoilInfo(coilToPrint[i].coilTagID, coilToPrint[i].coilTagSuffix))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int tagID = reader.GetInt32(reader.GetOrdinal("coilTagID"));
                                string suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                                CoilLabelInfo.TagID = tagID + suffix;
                                CoilLabelInfo.Thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));
                                CoilLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
                                CoilLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
                                CoilLabelInfo.SkidSteelDesc = reader.GetString(reader.GetOrdinal("SteelDesc"));
                                string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                                string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();

                                CoilLabelInfo.Alloy = alloy + " " + finish;

                                CoilLabelInfo.Weight = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("weight")));
                                CoilLabelInfo.Heat = reader.GetString(reader.GetOrdinal("heat")).Trim();
                                CoilLabelInfo.MillNum = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                                CoilLabelInfo.Vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();
                                CoilLabelInfo.Location = reader.GetString(reader.GetOrdinal("location")).Trim();
                                CoilLabelInfo.CustName = reader.GetString(reader.GetOrdinal("shortCustomerName")).Trim();
                                CoilLabelInfo.PO = reader.GetString(reader.GetOrdinal("dtlPO")).Trim();
                                CoilLabelInfo.RecID = reader.GetInt32(reader.GetOrdinal("receiveID"));
                                CoilLabelInfo.RecDate = reader.GetDateTime(reader.GetOrdinal("receiveDate")).ToString("d");
                                CoilLabelInfo.CoilCount = reader.GetInt32(reader.GetOrdinal("coilCount"));
                                CoilLabelInfo.Carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));
                                CoilLabelInfo.COO = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();

                                List<string> list = new List<string>();
                                db.OpenSQLConn1();
                                using (DbDataReader reader1 = db.GetCoilDamage(tagID,true))
                                {
                                    if (reader1.HasRows)
                                    {
                                        while (reader1.Read()) 
                                        {
                                            list.Add(reader1.GetString(reader1.GetOrdinal("damageDescription")));
                                        }
                                    }
                                }

                                CoilLabelInfo.Damage = list;

                                if (LabelPrinters.zebraTagPrinter)
                                {
                                    CoilLabelZebra(LabelPrinters.tagPrinter);
                                }
                                else
                                {
                                    CoilLabel(LabelPrinters.tagPrinter);
                                }
                                

                            }
                        }
                    }
                }
            }
        }

        public void PrintSkids(List<SkidsToPrint> skidsToPrint)
        {


            if (skidsToPrint.Count > 0)
            {
                DBUtils db = new DBUtils();

                db.OpenSQLConn();

                //PrintLabels pl = new PrintLabels();
                for (int i = 0; i < skidsToPrint.Count; i++)
                {
                    using (DbDataReader reader = db.GetSkidInfo("-1", skidsToPrint[i].skidID, skidsToPrint[i].coilTagSuffix, skidsToPrint[i].letter))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {



                                SkidLabelInfo.SkidID = reader.GetInt32(reader.GetOrdinal("skidID"));
                                SkidLabelInfo.CoilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                                SkidLabelInfo.SkidLetter = reader.GetString(reader.GetOrdinal("letter")).Trim();
                                SkidLabelInfo.Gauge = reader.GetDecimal(reader.GetOrdinal("thickness"));
                                SkidLabelInfo.Width = reader.GetDecimal(reader.GetOrdinal("width"));
                                SkidLabelInfo.Length = reader.GetDecimal(reader.GetOrdinal("length"));
                                SkidLabelInfo.Type = reader.GetInt32(reader.GetOrdinal("steelTypeID"));
                                string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                                string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                                SkidLabelInfo.Alloy = alloy + " " + finish;
                                SkidLabelInfo.OrderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                                if (SkidLabelInfo.OrderID == 0)
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("receiveID")))
                                    {
                                        SkidLabelInfo.rec = true;
                                        SkidLabelInfo.OrderID = reader.GetInt32(reader.GetOrdinal("receiveID"));
                                    }

                                }
                                
                                SkidLabelInfo.Heat = reader.GetString(reader.GetOrdinal("Heat")).Trim();
                                SkidLabelInfo.Mill = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                                SkidLabelInfo.Vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();
                                decimal sheetweight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
                                int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                                SkidLabelInfo.Pieces = pieces;

                                SkidLabelInfo.TheoWeight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SheetWeight")));

                                SkidLabelInfo.CustName = reader.GetString(reader.GetOrdinal("shortCustomerName")).Trim();
                                SkidLabelInfo.PO = "";
                                if (!reader.IsDBNull(reader.GetOrdinal("CustomerPO")))
                                {
                                    SkidLabelInfo.PO = reader.GetString(reader.GetOrdinal("CustomerPO"));
                                }
                                else
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("purchaseOrder")))
                                    {
                                        SkidLabelInfo.PO = reader.GetString(reader.GetOrdinal("purchaseOrder"));
                                    }
                                        
                                }

                                SkidLabelInfo.RecDate = reader.GetDateTime(reader.GetOrdinal("SkidDate")).ToString("d");
                                SkidLabelInfo.Carbon = reader.GetDecimal(reader.GetOrdinal("carbon"));
                                SkidLabelInfo.COO = reader.GetString(reader.GetOrdinal("countryOfOrigin"));
                                SkidLabelInfo.SkidSteelDesc = reader.GetString(reader.GetOrdinal("SteelDesc"));
                                SkidLabelInfo.Comments = reader.GetString(reader.GetOrdinal("comments"));
                                SkidLabelInfo.Location = reader.GetString(reader.GetOrdinal("location"));
                                SkidLabelInfo.TheoWeight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("SkidWeight")));

                                if (LabelPrinters.zebraTagPrinter)
                                {
                                    SkidLabelZebra(LabelPrinters.tagPrinter);
                                }
                                else
                                {
                                    SkidLabel(LabelPrinters.tagPrinter);
                                }

                            }
                        }

                    }
                }
            }
        }

        public void printAllShipLabels(int bolID, string strShipPrinter)
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            List<ShipLabelInfo> shi = new List<ShipLabelInfo>();

            using (DbDataReader reader = db.getShipInfo(bolID))
            {
                if (reader.HasRows)
                {
                    int cntr = 1;
                    int totcntr = 0;
                    while (reader.Read())
                    {
                        ShipLabelInfo shiItem = new ShipLabelInfo();   
                        shiItem.dtShip = reader.GetDateTime(reader.GetOrdinal("releaseDate")).ToString("d");
                        shiItem.strCust = reader.GetString(reader.GetOrdinal("ShortCustomerName")).Trim();
                        shiItem.strPO = reader.GetString(reader.GetOrdinal("releaseNUM")).Trim();
                        shiItem.tagID = reader.GetInt32(reader.GetOrdinal("id"));
                        shiItem.coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        shiItem.letter = reader.GetString(reader.GetOrdinal("letter")).Trim();
                        shiItem.strTagID = shiItem.tagID.ToString() + shiItem.coilTagSuffix + "." + shiItem.letter;
                        shiItem.cntr = cntr;

                        shi.Add(shiItem);

                        totcntr++;
                        cntr++;
                    }

                    for (int i = 0; i < shi.Count; i++)
                    {
                        if (LabelPrinters.zebraShipTagPrinter)
                        {
                            ShippingLabelZebra(bolID.ToString(), shi[i].dtShip, shi[i].strCust, shi[i].strPO, shi[i].strTagID, shi[i].cntr, totcntr, strShipPrinter);
                        }
                        else
                        {
                            ShipLabelPrint(bolID.ToString(), shi[i].dtShip, shi[i].strCust, shi[i].strPO, shi[i].strTagID, shi[i].cntr, totcntr, strShipPrinter);
                        }
                        
                    }
                }
            }
        }

        public void ShippingLabelZebra(string bolID, string dtShip, string strCust, string strPO, string tagID, int currCnt, int totCnt, string strPrinter)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("^XA\r\n");
            sb.Append("^CF0,60^FO740,10^GB70,1200,50^FS\r\n");
            sb.Append("^FWR^FO740,410^FR^FDTSA Shipping Label^FS\r\n");
            sb.Append("^CF0,60\r\n");
            sb.Append("^FO670,20^FD" + dtShip + "^FS\r\n");
            sb.Append("^FO670,520^FD"+ strCust.Trim() + "^FS\r\n");
            sb.Append("^FO550,20^FDPO: " + strPO.Trim() + "^FS\r\n");
            sb.Append("^CF0,100\r\n");
            sb.Append("^FO400,20^FD" + tagID.Trim() + "^FS\r\n");
            sb.Append("^CF0,100\r\n");
            sb.Append("^FO400,800^FD" + currCnt.ToString() + " of " + totCnt.ToString() + "^FS\r\n");
            //box
            sb.Append("^FO400,780^GB120,350,3^FS\r\n");
            sb.Append("^BY7,3,80\r\n");
            sb.Append("^FO255,20^BC,,N^FD" + bolID.ToString() + "^FS\r\n");
            sb.Append("^CF0,230\r\n");
            sb.Append("^FO0,20^FD" + bolID.ToString() + "^FS\r\n");
            sb.Append("^XZ\r\n");

            string IPAddress = "";

            var server = new PrintServer();
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
            foreach (var queue in queues)
            {
                string printerName = queue.Name;
                if (printerName.Equals(strPrinter))
                {
                    IPAddress = queue.QueuePort.Name;
                }

            }

            if (IPAddress.Length > 0)
            {
                Connection connection = new TcpConnection(IPAddress, 9100);

                //var printerConn = new TcpConnection(strPrinter, 9100);

                connection.Open();

                ZebraPrinter p = ZebraPrinterFactory.GetInstance(connection);
                p.SendCommand(sb.ToString());

                connection.Close();
            }
            else
            {
                SendToPrinter(sb, strPrinter);
            }

        }

        private void ShipLabelPrint(string bolID, string dtShip, string strCust, string strPO, string tagID, int currCnt, int totCnt, string strPrinter)
        {

            StringBuilder strLabel = new StringBuilder();
            strLabel.Append("<STX><ESC>P<ETX>\r\n");
            strLabel.Append("<STX>E4;F4;<ETX>\r\n");
            strLabel.Append("<STX>H0;o1,480;f0;c26;h150;w170;d0,30;<ETX>\r\n");
            strLabel.Append("<STX>H1;o1,0;f0;h28;w48;c25;r0;b3;d3, TSA SHIPPING LABEL ;<ETX>\r\n");
            strLabel.Append("<STX>B2;o1,467;c0,0;h100;w8;i1;d0,10;<ETX>\r\n");
            strLabel.Append("<STX>H3;o1,70;c26,0;h40;w35;d0,10;<ETX>\r\n");
            strLabel.Append("<STX>H4;o400,70;c26,0;h40;w35;d0,20;<ETX>\r\n");
            strLabel.Append("<STX>H5;o1,190;c26,0;h40;w35;d0,17;<ETX>\r\n");
            strLabel.Append("<STX>H6;o1,250;c26,0;h90;w35;d0,20;<ETX>\r\n");
            strLabel.Append("<STX>W7;o700,280;f0;l450;h160;w4;<ETX>\r\n");
            strLabel.Append("<STX>H8;o740,240;c26,0;h90;w35;d0,20;<ETX>\r\n");
            strLabel.Append("<STX>R;<ETX>\r\n");
            strLabel.Append("<STX><ESC>E4<ETX>\r\n");
            strLabel.Append("<STX><CAN><ETX>\r\n");
            strLabel.Append("<STX>" + bolID + "<CR><ETX>\r\n");
            strLabel.Append("<STX>" + bolID + "<CR><ETX>\r\n");   
            strLabel.Append("<STX>" + dtShip + "<CR><ETX>\r\n");
            strLabel.Append("<STX>" + strCust + "<CR><ETX>\r\n");
            strLabel.Append("<STX>PO: " + strPO + "<CR><ETX>\r\n");
            strLabel.Append("<STX>" + tagID + "<CR><ETX>\r\n");
            strLabel.Append("<STX>" + currCnt.ToString() + " of " + totCnt.ToString() + "<CR><ETX>\r\n");
            strLabel.Append("<STX><ETB><ETX>\r\n");

            SendToPrinter(strLabel, strPrinter);

        }


        private void SendToPrinter(StringBuilder sb,string strprinter)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //ssageBox.Show(printer);

                if (printer.Equals(strprinter))
                {
                    string s = sb.ToString();
                    
                    PrintDocument p = new PrintDocument();
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = strprinter;

                    p.PrinterSettings = printerSettings;

                    

                    p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                    {
                        e1.Graphics.DrawString(s, new System.Drawing.Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                    };
                    
                    try
                    {
                        p.Print();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Exception Occured While Printing", ex);
                    }
                    return;
                }
            }
        }


        
    }
}

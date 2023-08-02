using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    class PrintLabels
    {

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
        }


        public coilLabelInfo CoilLabelInfo = new coilLabelInfo();

        public class skidLabelInfo
        {
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

        public skidLabelInfo SkidLabelInfo = new skidLabelInfo();

        public void SkidLabel(string strPrinter)
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
            sb.Append("<STX>Order: " + SkidLabelInfo.OrderID + "<CR><ETX>\r\n");
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
            //sb.Append("<STX>H18;o960,80;f0;c26;h15;w14;d0,32;<ETX>\r\n");


            //    'add damage if needed
            //cntr = 19
            //nSpaceDamage = 110
            //ntmp = 1
            //Set rsDamage = getCoilDamage(lTagIDNew)


            //bdamage = False
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
   
    














        //*******************stop*******************



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
                        e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));



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

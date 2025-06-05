using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    public partial class History : Form
    {
        private int coilTagID;
        private string coilTagSuffix;
        private string skidLetter;
        private string fullTagID;
        private string poNum = "";
        private string millNumber = "";
        private class TagInfo
        {
            public int coilTagID;
            public string coilTagSuffix;
            public string skidLetter;
            public string fullTagID;
        }
        private List<TagInfo> tags; 

        public void setPO(string PO)
        {
            poNum = PO;
        }

        public void setMillNum(string millNum)
        {
            millNumber = millNum;
        }
        public int setTagID(string[] tagID)
        {


            tags = new List<TagInfo>();

            for (int i = 0; i < tagID.Count(); i++)
            {
                TagParser tp = new TagParser();
                tp.TagToBeParsed = tagID[i];
                tp.ParseTag();

                TagInfo ti = new TagInfo();


                ti.coilTagID = tp.TagID;
                
                ti.coilTagSuffix = tp.CoilTagSuffix;
                ti.skidLetter = tp.SkidLetter;
                ti.fullTagID = tagID[i];

                tags.Add(ti);
            }


            return tags.Count;

        }
        public History()
        {
            InitializeComponent();
            
        }

        public List<string> getMillTags()
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            List<string> tagsToFind = db.getMilltags(millNumber);

            return tagsToFind;

        }
        public List<string> getPOTags()
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            List<string> tagsToFind = db.getPOtags(poNum);

            return tagsToFind;

        }
        private void LoadData()
        {

            if (!poNum.Equals(""))
            {
                List<string> tagsToFind = getPOTags();
                setTagID(tagsToFind.ToArray());
            }
            else
            {
                if (!millNumber.Equals(""))
                {
                    List<string> tagsToFind = getMillTags();
                    setTagID(tagsToFind.ToArray());
                }
            }

            for (int b = 0; b < tags.Count; b++)
            {


                coilTagID = tags[b].coilTagID;
                coilTagSuffix = tags[b].coilTagSuffix;
                skidLetter = tags[b].skidLetter;
                fullTagID = tags[b].fullTagID;


                TreeNode parent = tvwHistory.Nodes.Add(fullTagID);
                parent.Expand();

                DBUtils db = new DBUtils();

                db.OpenSQLConn();

                //receiving



                using (DbDataReader reader = db.GetCoilReceiveData(0, coilTagID))
                {
                    if (reader.HasRows)
                    {
                        TreeNode receiving = parent.Nodes.Add("Receiving of coil " + coilTagID.ToString());
                        receiving.Expand();
                        bool firstRec = true;
                        while (reader.Read())
                        {
                            string suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix"));
                            TreeNode trSuffix = receiving.Nodes.Add(coilTagID + suffix);

                            string custName = reader.GetString(reader.GetOrdinal("longCustomerName")).Trim();
                            trSuffix.Nodes.Add("Recieved under Customer: " + custName);
                            string coilCust = reader.GetString(reader.GetOrdinal("coilCust")).Trim();
                            trSuffix.Nodes.Add("Currently belongs to: " + coilCust);


                            int recID = reader.GetInt32(reader.GetOrdinal("receiveID"));
                            trSuffix.Nodes.Add("Receiver: " + recID.ToString());
                            string PO = reader.GetString(reader.GetOrdinal("dtlPO")).Trim();
                            trSuffix.Nodes.Add("Purchase Order: " + PO);
                            string container = reader.GetString(reader.GetOrdinal("container")).Trim();
                            if (container.Length > 0)
                            {
                                trSuffix.Nodes.Add("Container: " + container);
                            }
                            string millnum = reader.GetString(reader.GetOrdinal("millNum"));
                            trSuffix.Nodes.Add("Mill: " + millnum);
                            string heat = reader.GetString(reader.GetOrdinal("heat"));
                            trSuffix.Nodes.Add("Heat: " + heat);
                            DateTime dtRec = reader.GetDateTime(reader.GetOrdinal("receiveDate"));
                            trSuffix.Nodes.Add("Date: " + dtRec.ToString("d"));
                            string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                            string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                            trSuffix.Nodes.Add("Alloy: " + alloy + " " + finish);
                            int weight = reader.GetInt32(reader.GetOrdinal("weight"));
                            trSuffix.Nodes.Add("Received Weight: " + weight.ToString("G29"));
                            int currWeight = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("currWeight")));
                            trSuffix.Nodes.Add("Current Weight: " + currWeight.ToString());
                            decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));
                            trSuffix.Nodes.Add("Thickness: " + thk.ToString("G29"));
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                            trSuffix.Nodes.Add("Width: " + width.ToString("G29"));
                            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                            trSuffix.Nodes.Add("Length: " + length.ToString("G29"));
                            
                            string vendor = reader.GetString(reader.GetOrdinal("vendor")).Trim();
                            trSuffix.Nodes.Add("Vendor: " + vendor);
                            string location = reader.GetString(reader.GetOrdinal("location")).Trim();
                            trSuffix.Nodes.Add("Location: " + location);
                            int coilCnt = reader.GetInt32(reader.GetOrdinal("coilCount"));
                            trSuffix.Nodes.Add("Coil Count: " + coilCnt.ToString());
                            
                            db.OpenSQLConn1();
                            using (DbDataReader reader1 = db.GetCoilDamage(coilTagID, true))
                            {
                                if (reader.HasRows)
                                {
                                    TreeNode damage = trSuffix.Nodes.Add("Damage:");
                                    while (reader1.Read())
                                    {
                                        damage.Nodes.Add(reader1.GetString(reader1.GetOrdinal("damageDescription")));
                                    }
                                    damage.ExpandAll();
                                }
                            }

                            if (firstRec)
                            {
                                trSuffix.Expand();
                                firstRec = false;
                            }
                        }
                        receiving.Expand();
                    }
                    else
                    {
                        TreeNode receiving = parent.Nodes.Add("Receiving of coil " + coilTagID.ToString());

                        receiving.Nodes.Add("Unable to find receiving record.");

                        receiving.Expand();
                    }
                    reader.Close();
                }

                //Ownership



                using (DbDataReader reader = db.GetTransferInfo(coilTagID, coilTagSuffix, skidLetter))
                {
                    if (reader.HasRows)
                    {
                        TreeNode ownership = parent.Nodes.Add("Ownership");

                        while (reader.Read())
                        {
                            string origCust = reader.GetString(reader.GetOrdinal("origCust"));
                            string newCust = reader.GetString(reader.GetOrdinal("newCust"));
                            DateTime dtTransfer = reader.GetDateTime(reader.GetOrdinal("transferDate"));
                            string purchaseOrder = reader.GetString(reader.GetOrdinal("purchaseOrder")).Trim();
                            int transID = reader.GetInt32(reader.GetOrdinal("transferID"));
                            string display = "Transferred from " + origCust + " to " + newCust + " on " +
                                                dtTransfer.ToString("d") + " PO# " + purchaseOrder + " : Transfer ID (" + transID.ToString() + ")" ;
                            ownership.Nodes.Add(display);
                        }
                        ownership.Expand();
                    }
                    reader.Close();
                }

                // weight changes

                using (DbDataReader reader = db.GetCoilWeightChange(coilTagID, coilTagSuffix))
                {
                    if (reader.HasRows)
                    {
                        TreeNode weightChange = parent.Nodes.Add("Weight Changes");
                        while (reader.Read())
                        {
                            int prevWeight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
                            int currWeight = reader.GetInt32(reader.GetOrdinal("currentWeight"));
                            string changeDate = reader.GetDateTime(reader.GetOrdinal("changeDate")).ToString("d");
                            string comments = reader.GetString(reader.GetOrdinal("comments")).Trim();
                            int refNum = reader.GetInt32(reader.GetOrdinal("referenceNumber"));


                            TreeNode tr = weightChange.Nodes.Add("Changed from " + prevWeight.ToString() + " to " + currWeight.ToString() + " on " + changeDate);
                            tr.Nodes.Add("Reference #" + refNum.ToString() + ": " + comments);

                        }
                        weightChange.Expand();
                    }
                    reader.Close();
                }
                //work orders

                TreeNode orders = parent.Nodes.Add("Orders");

                //Coil Polishing CoilCoilSame
                using (DbDataReader reader = db.getCoilPolishHistory(coilTagID, ""))
                {
                    if (reader.HasRows)
                    {
                        int prevOrd = -1;
                        TreeNode coilPolish = orders.Nodes.Add("Coil Polish");
                        TreeNode ord = null;
                        bool firstrecord = true;
                        int orderStatus = -1;
                        int orderID = -1;
                        while (reader.Read())
                        {
                            if (firstrecord)
                            {
                                orderStatus = reader.GetInt32(reader.GetOrdinal("status"));
                                string PO = reader.GetString(reader.GetOrdinal("customerPO"));
                                coilPolish.Nodes.Add("Purchase Order: " + PO);
                                DateTime ordDate = reader.GetDateTime(reader.GetOrdinal("orderDate"));
                                DateTime promiseDate = reader.GetDateTime(reader.GetOrdinal("promiseDate"));
                                string comments = reader.GetString(reader.GetOrdinal("comments"));
                                coilPolish.Nodes.Add("Order Date: " + ordDate.ToString("d"));
                                coilPolish.Nodes.Add("Promise Date: " + promiseDate.ToString("d"));
                                coilPolish.Nodes.Add("Comments: " + comments.Trim());
                                firstrecord = false;




                                orderID = reader.GetInt32(reader.GetOrdinal("orderID"));

                                using (DbDataReader reader1 = db.GetOrderTimes(orderID, true))
                                {
                                    if (reader1.HasRows)
                                    {
                                        double min = 0;
                                        while (reader1.Read())
                                        {
                                            DateTime start = reader1.GetDateTime(reader1.GetOrdinal("startDate"));
                                            DateTime end = reader1.GetDateTime(reader1.GetOrdinal("endDate"));

                                            min += end.Subtract(start).TotalMinutes;

                                            coilPolish.Nodes.Add("Start: " + start.ToString("f"));
                                            coilPolish.Nodes.Add("End: " + end.ToString("f"));


                                        }
                                        coilPolish.Nodes.Add("Total Time " + min.ToString() + " minutes.");
                                    }
                                }
                            }

                            int polishWeight = reader.GetInt32(reader.GetOrdinal("polishWeight"));
                            string newSuffix = reader.GetString(reader.GetOrdinal("coilTagNewSuffix")).Trim();
                            string prevFinish = reader.GetString(reader.GetOrdinal("prevFinish")).Trim();
                            string newFinish = reader.GetString(reader.GetOrdinal("newFinish")).Trim();

                            int pWeight = reader.GetInt32(reader.GetOrdinal("pWeight"));
                            int nWeight = reader.GetInt32(reader.GetOrdinal("nWeight"));

                            string nodeInfo = "";
                            if (orderStatus == 0)
                            {
                                nodeInfo = "Closed";
                            }
                            else
                            {
                                if (orderStatus < 0)
                                {
                                    nodeInfo = "Cancelled";
                                }
                                else
                                {
                                    nodeInfo = "Open";
                                }
                            }

                            if (prevOrd == -1)
                            {
                                prevOrd = orderID;
                                ord = coilPolish.Nodes.Add("Order " + orderID.ToString() + " (" + nodeInfo + ")");
                            }
                            else
                            {
                                if (prevOrd != orderID)
                                {
                                    ord = coilPolish.Nodes.Add("Order " + orderID.ToString());
                                    prevOrd = orderID;
                                }
                            }

                            if (coilTagSuffix.Equals(newSuffix))
                            {
                                nodeInfo = "*- " + polishWeight.ToString() + " lbs from "
                                            + prevFinish + " to " + newFinish + " assigned tag " + coilTagID.ToString() + newSuffix;
                            }
                            else
                            {
                                nodeInfo = polishWeight.ToString() + " lbs from "
                                            + prevFinish + " to " + newFinish + " assigned tag " + coilTagID.ToString() + newSuffix;
                            }




                            ord.Nodes.Add(nodeInfo);

                        }
                        coilPolish.Expand();

                    }
                    reader.Close();
                }

                using (DbDataReader reader = db.GetCTLDetails(-1, coilTagID, coilTagSuffix))
                {
                    if (reader.HasRows)
                    {
                        TreeNode CTLOrder = orders.Nodes.Add("Cut To Length");
                        TreeNode tnCTL = null;
                        int orderID = -1;
                        int prevOrdID = -2;


                        while (reader.Read())
                        {


                            orderID = reader.GetInt32(reader.GetOrdinal("orderID"));

                            if (orderID != prevOrdID)
                            {

                                tnCTL = CTLOrder.Nodes.Add("Order: " + orderID.ToString());
                                prevOrdID = orderID;
                                tnCTL.Nodes.Add(reader.GetString(reader.GetOrdinal("CustomerPO")));

                                DateTime ordDate = reader.GetDateTime(reader.GetOrdinal("orderDate"));
                                DateTime promiseDate = reader.GetDateTime(reader.GetOrdinal("promiseDate"));
                                string skComments = reader.GetString(reader.GetOrdinal("comments"));
                                tnCTL.Nodes.Add("Order Date: " + ordDate.ToString("d"));
                                tnCTL.Nodes.Add("Promise Date: " + promiseDate.ToString("d"));
                                tnCTL.Nodes.Add("Comments: " + skComments.Trim());




                                using (DbDataReader reader1 = db.GetOrderTimes(orderID, true))
                                {
                                    if (reader1.HasRows)
                                    {
                                        double min = 0;
                                        while (reader1.Read())
                                        {
                                            DateTime start = reader1.GetDateTime(reader1.GetOrdinal("startDate"));
                                            DateTime end = reader1.GetDateTime(reader1.GetOrdinal("endDate"));

                                            min += end.Subtract(start).TotalMinutes;

                                            tnCTL.Nodes.Add("Start: " + start.ToString("f"));
                                            tnCTL.Nodes.Add("End: " + end.ToString("f"));


                                        }
                                        tnCTL.Nodes.Add("Total Time " + min.ToString() + " minutes.");
                                    }
                                }


                            }
                            int skidCnt = reader.GetInt32(reader.GetOrdinal("skidCount"));
                            int pieceCnt = reader.GetInt32(reader.GetOrdinal("pieceCount"));
                            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                            string alloyDesc = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                            string finishDesc = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();
                            string comments = reader.GetString(reader.GetOrdinal("comments")).Trim();

                            TreeNode skid = tnCTL.Nodes.Add(skidCnt.ToString() + " skids of " + pieceCnt.ToString() + " pieces");
                            skid.Nodes.Add(alloyDesc + " " + finishDesc);
                            skid.Nodes.Add(length.ToString("G29"));
                            skid.Nodes.Add(comments);

                        }
                        CTLOrder.Expand();
                    }
                }

                //skid polish

                using (DbDataReader reader = db.getShShHistory(coilTagID))
                {
                    if (reader.HasRows)
                    {

                        TreeNode ShShOrder = orders.Nodes.Add("Sheet Polish");
                        TreeNode tnShSh = null;
                        int orderID = -1;
                        int prevOrderID = -1;
                        while (reader.Read())
                        {
                            int status = reader.GetInt32(reader.GetOrdinal("status"));
                            string stat = "Open";
                            if (status == -1)
                            {
                                stat = "Closed";
                            }
                            if (orderID == -1)
                            {
                                orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                                tnShSh = ShShOrder.Nodes.Add("Order: " + orderID.ToString() + "(" + stat + ")");

                                prevOrderID = orderID;
                            }
                            else
                            {
                                orderID = reader.GetInt32(reader.GetOrdinal("orderID"));
                                if (orderID != prevOrderID)
                                {
                                    tnShSh = ShShOrder.Nodes.Add("Order: " + orderID.ToString() + "(" + stat + ")");
                                    prevOrderID = orderID;

                                }
                            }
                            int skidID = reader.GetInt32(reader.GetOrdinal("skidID"));

                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                            string skidLetter = reader.GetString(reader.GetOrdinal("skidLetter")).Trim();
                            string orderLetter = reader.GetString(reader.GetOrdinal("orderLetter")).Trim();
                            string oldFinish = reader.GetString(reader.GetOrdinal("oldFinish")).Trim();
                            string newFinish = reader.GetString(reader.GetOrdinal("newFinish")).Trim();
                            string branchDesc = reader.GetString(reader.GetOrdinal("branchDescShort"));
                            int orderPieceCount = reader.GetInt32(reader.GetOrdinal("orderPieceCount"));
                            int breakSkid = reader.GetInt32(reader.GetOrdinal("breakSkid"));
                            string precurs = "";
                            if (skidID == coilTagID)
                            {
                                precurs = "*-";
                            }

                            TreeNode t2 = tnShSh.Nodes.Add(precurs + "Skid " + skidID.ToString() + coilTagSuffix + "." + skidLetter + "." + orderLetter);
                            if (skidID == coilTagID)
                            {
                                t2.ForeColor = Color.Blue;
                            }
                            t2.Nodes.Add("From " + oldFinish + " to " + newFinish);
                            if (breakSkid > 0)
                            {
                                t2.Nodes.Add("Break Skid: " + orderPieceCount.ToString() + " (of " + breakSkid.ToString() + ")");
                            }
                            else
                            {
                                t2.Nodes.Add("Pieces: " + orderPieceCount.ToString());
                            }

                        }
                        ShShOrder.Expand();
                    }

                    reader.Close();
                }
                orders.Expand();

                //skids

                using (DbDataReader reader = db.GetSkidHistory(coilTagID))
                {
                    if (reader.HasRows)
                    {
                        TreeNode skids = parent.Nodes.Add("Skids");
                        while (reader.Read())
                        {
                            int skidID = reader.GetInt32(reader.GetOrdinal("skidID"));
                            string skidLetter = reader.GetString(reader.GetOrdinal("Letter")).Trim();
                            string coilTagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                            string branch = reader.GetString(reader.GetOrdinal("branchDescShort")).Trim();

                            string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                            string finish = reader.GetString(reader.GetOrdinal("finishDesc")).Trim();

                            int orderID = reader.GetInt32(reader.GetOrdinal("orderID"));

                            decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetweight"));
                            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));

                            decimal diag1 = reader.GetDecimal(reader.GetOrdinal("diagnol1"));
                            decimal diag2 = reader.GetDecimal(reader.GetOrdinal("diagnol2"));

                            decimal mic1 = reader.GetDecimal(reader.GetOrdinal("mic1"));
                            decimal mic2 = reader.GetDecimal(reader.GetOrdinal("mic2"));
                            decimal mic3 = reader.GetDecimal(reader.GetOrdinal("mic3"));

                            int pieces = reader.GetInt32(reader.GetOrdinal("pieceCount"));

                            string comments = reader.GetString(reader.GetOrdinal("comments")).Trim();

                            int notprime = reader.GetInt32(reader.GetOrdinal("notPrime"));

                            int status = reader.GetInt32(reader.GetOrdinal("skidStatus"));

                            int skidWeight = Convert.ToInt32(sheetWeight * pieces);
                            if (skidWeight == 0)
                            {
                                MetalFormula met = new MetalFormula();

                                decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                                decimal thk = reader.GetDecimal(reader.GetOrdinal("thickness"));

                                skidWeight = Convert.ToInt32(met.MetFormula(density, thk, length, width, pieces, 0));



                            }

                            TreeNode sk1 = skids.Nodes.Add(skidID.ToString() + coilTagSuffix + "." + skidLetter);
                            sk1.Nodes.Add("Branch: " + branch);
                            sk1.Nodes.Add(alloy + " " + finish);
                            sk1.Nodes.Add("Order: " + orderID.ToString());
                            sk1.Nodes.Add("Weight: " + skidWeight.ToString());
                            sk1.Nodes.Add("Pieces: " + pieces.ToString());
                            sk1.Nodes.Add("Length: " + length.ToString("G29"));
                            sk1.Nodes.Add("Width: " + width.ToString("G29"));
                            sk1.Nodes.Add("Diags: " + diag1.ToString("G29") + " & " + diag2.ToString("G29"));
                            sk1.Nodes.Add("Mic: " + mic1.ToString("G29") + " & " + mic2.ToString("G29") + " & " + mic3.ToString("G29"));
                            sk1.Nodes.Add("Comments: " + comments);
                            if (notprime > 0)
                            {
                                TreeNode t = sk1.Nodes.Add("NOT PRIME");
                                t.ForeColor = Color.Red;
                            }
                            if (status < 0)
                            {
                                sk1.ForeColor = Color.Red;
                                if (status == -4)
                                {
                                    sk1.Text += " (Out of stock - Used on a work order)";
                                }
                                else
                                {
                                    sk1.Text += " (Out of stock)";
                                }

                            }
                        }
                        skids.Expand();
                    }
                }


                //shipping

                using (DbDataReader reader = db.getShipHistory(coilTagID))
                {
                    if (reader.HasRows)
                    {
                        TreeNode shipNode = parent.Nodes.Add("Shipping");
                        int shipid = -1;
                        int prevShipID = -1;
                        TreeNode ship1 = null;
                        TreeNode ship2 = null;
                        bool firstcoil = true;
                        bool firstskid = true;
                        while (reader.Read())
                        {

                            if (shipid == -1)
                            {
                                shipid = reader.GetInt32(reader.GetOrdinal("shipID"));
                                prevShipID = shipid;

                                ship1 = shipNode.Nodes.Add("BOL#: " + shipid.ToString().Trim());

                                int status = reader.GetInt32(reader.GetOrdinal("hdrStatus"));
                                if (status <= 0)
                                {
                                    ship1.Text += " (Closed)";
                                }
                                else
                                {
                                    ship1.Text += " (Open)";
                                }

                                string custName = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim();
                                ship1.Nodes.Add(custName);
                                string CustPO = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                                ship1.Nodes.Add("PO#: " + CustPO);
                                DateTime relDate = reader.GetDateTime(reader.GetOrdinal("releaseDate"));
                                ship1.Nodes.Add("Released on " + relDate.ToString("d"));
                                string relNum = reader.GetString(reader.GetOrdinal("releaseNUM"));
                                ship1.Nodes.Add("Reference: " + relNum);
                                DateTime dtMod = reader.GetDateTime(reader.GetOrdinal("dateModified"));

                                ship1.Nodes.Add("Last Modifed on " + dtMod.ToString("d"));
                            }
                            else
                            {
                                shipid = reader.GetInt32(reader.GetOrdinal("shipID"));
                                if (shipid != prevShipID)
                                {
                                    prevShipID = shipid;
                                    firstskid = true;
                                    firstcoil = true;
                                    ship1 = shipNode.Nodes.Add("BOL#: " + shipid.ToString().Trim());

                                    int status = reader.GetInt32(reader.GetOrdinal("hdrStatus"));
                                    if (status == -1)
                                    {
                                        ship1.Text += " (Closed)";
                                    }
                                    else
                                    {
                                        ship1.Text += " (Open)";
                                    }

                                    string custName = reader.GetString(reader.GetOrdinal("LongCustomerName")).Trim();
                                    ship1.Nodes.Add(custName);
                                    string CustPO = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                                    ship1.Nodes.Add("PO#: " + CustPO);
                                    DateTime relDate = reader.GetDateTime(reader.GetOrdinal("releaseDate"));
                                    ship1.Nodes.Add("Released on " + relDate.ToString("d"));
                                    string relNum = reader.GetString(reader.GetOrdinal("releaseNUM"));
                                    ship1.Nodes.Add("Reference: " + relNum);
                                    DateTime dtMod = reader.GetDateTime(reader.GetOrdinal("dateModified"));

                                    ship1.Nodes.Add("Last Modifed on " + dtMod.ToString("d"));
                                }
                            }

                            int tagID = reader.GetInt32(reader.GetOrdinal("id"));
                            string suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                            string letter = reader.GetString(reader.GetOrdinal("letter")).Trim();

                            //0=coil 1=skid
                            int type = reader.GetInt32(reader.GetOrdinal("type"));


                            TreeNode tempNode = null;
                            if (type == 0)
                            {
                                if (firstcoil)
                                {
                                    firstcoil = false;
                                    ship2 = ship1.Nodes.Add("Coils");

                                }
                                tempNode = ship2.Nodes.Add(tagID + suffix);
                                if (tagID == coilTagID)
                                {
                                    tempNode.ForeColor = Color.Blue;
                                }
                            }
                            else
                            {
                                if (firstskid)
                                {
                                    ship2 = ship1.Nodes.Add("Skids");
                                    firstskid = false;
                                }
                                tempNode = ship2.Nodes.Add(tagID + suffix + "." + letter);
                                if (tagID == coilTagID)
                                {
                                    tempNode.ForeColor = Color.Blue;
                                }
                            }



                        }
                        shipNode.Expand();
                    }
                }
                parent.Expand();
            }
 
        }

        private void History_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (skidLetter == "")
            this.Text = "History for " +fullTagID;
            LoadData();
            Cursor.Current = Cursors.Default;
        }
    }
}

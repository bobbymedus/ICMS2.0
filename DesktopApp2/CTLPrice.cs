using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DesktopApp2.FormICMSMain;
using static ICMS.CTLPrice;

namespace ICMS
{
    internal class CTLPrice
    {
        public class adderPrices
        {
            public string adderDesc = "";
            public decimal charge;
            public decimal total;
            public int amount;
            public int ordBy;

        }

        private class AdderCalcLBS
        {
            public string desc = "";
            public decimal price;
            public int totWeight;
            public int skidWeight;
            public int tagID;
            public string suffix = "";
            public decimal minPrice;
            public decimal lbsPerInch;
        }
        private class AdderCalcSQFT
        {
            public string desc = "";
            public decimal price;
            public int totWeight;
            public decimal totSQFT;
            public int tagID;
            public string suffix = "";
            public decimal minPrice;
        }
        private class AdderCalcLINFT
        {
            public string desc = "";
            public decimal price;
            public int totWeight;
            public decimal totLINFT;
            public int tagID;
            public string suffix = "";
            public decimal minPrice;
        }

        private class AdderCalcLININ
        {
            public string desc = "";
            public decimal price;
            public int totWeight;
            public decimal totLININ;
            public int tagID;
            public string suffix = "";
            public decimal minPrice;
        }

        private List<AdderCalcLBS> adderCalcLBS = new List<AdderCalcLBS>();
        private List<AdderCalcSQFT> adderCalcSQFT = new List<AdderCalcSQFT>();
        private List<AdderCalcLINFT> adderCalcLINFT = new List<AdderCalcLINFT>();
        private List<AdderCalcLININ> adderCalcLININ = new List<AdderCalcLININ>();


        private List<adderPrices> adders = new List<adderPrices>();
        private List<adderPrices> finalAdders = new List<adderPrices>();

        

        public List<adderPrices> Adders
        {
            get { return finalAdders; }
        }
        

        private int orderID = 0;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        private decimal baseCharge = 0;
        public decimal baseChargeAmount
        {
            get { return baseCharge; }
            
        }

        private decimal pvcCharge = 0;
        public decimal PVCCharge
        {
            get { return pvcCharge; }

        }
        private decimal paperCharge = 0;
        public decimal PaperCharge
        {
            get { return paperCharge; }

        }
        private int totSkidWeight = 0;
        private int totCoilWeight = 0;

        
        public void GetCTLPrices()
        {
            if (orderID > 0)
            {
                DBUtils db = new DBUtils();
                db.OpenSQLConn();
                
                int prevTagID = -1;
                string prevTagSuffix = "NOPE";
                int cntr = 2;
                using (DbDataReader reader = db.GetCTLPricing(orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int tagID = reader.GetInt32(reader.GetOrdinal("skidID"));
                            string tagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                            if (prevTagID != tagID || !prevTagSuffix.Equals(tagSuffix))
                            {
                                //public class adderPrices
                                //{
                                //    public string adderDesc = "";
                                //    public decimal charge;
                                //    public decimal total;
                                //    public int amount;
                                //    public int ordBy;
                                //}
                                

                                adderPrices ap = new adderPrices();
                                ap.adderDesc = "CTL Charge";
                                ap.total = reader.GetDecimal(reader.GetOrdinal("ProcTotal"));
                                ap.charge = reader.GetDecimal(reader.GetOrdinal("procPrice"));
                                ap.amount = reader.GetInt32(reader.GetOrdinal("previousWeight"));
                                int currWeight = reader.GetInt32(reader.GetOrdinal("currentWeight"));
                                ap.amount -= currWeight;
                                ap.ordBy = 1;
                                finalAdders.Add(ap);
                                prevTagID = tagID;
                                prevTagSuffix = tagSuffix;

                                //I think I need to add scrap credit here.
                                adderPrices ap1 = new adderPrices();

                                db.OpenSQLConn1();
                                using (DbDataReader reader1 = db.GetScrapLBS(orderID, tagID, tagSuffix))
                                {
                                    if (reader1.HasRows)
                                    {
                                        while (reader1.Read())
                                        {
                                            if (!reader1.IsDBNull(reader1.GetOrdinal("scrapPrice")))
                                            {
                                                ap1.charge = reader1.GetDecimal(reader1.GetOrdinal("scrapPrice"));
                                            }
                                            else
                                            {
                                                ap1.charge = 0;
                                            }
                                            if (!reader1.IsDBNull(reader1.GetOrdinal("LBS")))
                                            {
                                                ap1.amount = reader1.GetInt32(reader1.GetOrdinal("LBS"));
                                            }
                                            else
                                            {
                                                ap1.amount = 0;
                                            }
                                                
                                        }
                                    }
                                    ap1.charge *= -1;
                                    ap1.adderDesc = "SCRAP LBS";
                                    ap1.total = ap1.charge * ap1.amount;
                                    
                                    ap1.ordBy = 99999999;
                                    finalAdders.Add(ap1);
                                }

                                db.CloseSQLConn1();



                            }
                            adderPrices adderp = new adderPrices();
                            adderp.adderDesc = reader.GetString(reader.GetOrdinal("TotType"));
                            if (reader.IsDBNull(reader.GetOrdinal("TypeTotal")))
                            {
                                adderp.total = 0;
                                adderp.charge = 0;
                            }
                            else
                            {
                                adderp.total = reader.GetDecimal(reader.GetOrdinal("TypeTotal"));
                                adderp.charge = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
                            }
                            
                            
                            adderp.amount = Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("sqft")));
                            adderp.ordBy = cntr;
                            finalAdders.Add(adderp);



                            cntr++;
                        }
                        
                    }
                }

                adders.Clear();

                bool firstLBS = true;
                using (DbDataReader reader = db.GetPricingAdders(orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int calcType = reader.GetInt32(reader.GetOrdinal("calcType"));

                            //0 = lbs; 1 = sqft; 2 = linear footage

                            switch (calcType)
                            {
                                case 0: //LBS
                                    CalcLBS(reader, firstLBS);
                                    firstLBS = false;
                                    break;
                                case 1://SQFT
                                    CalcSQFT(reader, firstLBS);
                                    firstLBS = false;
                                    break;
                                case 2://LinearFootage
                                    CalcLINFT(reader, firstLBS);
                                    firstLBS = false;
                                    break;
                                case 3:
                                    CalcLININ(reader, firstLBS);
                                    firstLBS = false;
                                    break;
                            }
                        }
                    }

                    //private class AdderCalcLBS
                    //{
                    //    public string desc = "";
                    //    public decimal price;
                    //    public int totWeight;
                    //    public int skidWeight;
                    //    public int tagID;
                    //    public string suffix = "";
                    //}

                } 
                    
                string prevAdderDesc = "NOPE";
                int totAdderWeight = 0;
                int prevTotWeight = 0;
                decimal prevPrice = 0;
                for (int i = 0; i < adderCalcLBS.Count; i++)
                {
                        
                    if (!prevAdderDesc.Equals(adderCalcLBS[i].desc))
                    {
                        if (totAdderWeight > prevTotWeight)
                        {
                            totAdderWeight = prevTotWeight;

                        }
                        if (i > 0)
                        {
                            adderPrices ap = new adderPrices();
                            ap.adderDesc = prevAdderDesc;
                            ap.total = totAdderWeight * prevPrice;
                            ap.charge = prevPrice;
                            ap.amount = totAdderWeight;
                            ap.ordBy = cntr;
                            cntr++;
                            finalAdders.Add(ap);
                            totAdderWeight = 0;
                        }
                        prevTotWeight = adderCalcLBS[i].totWeight;
                        prevAdderDesc = adderCalcLBS[i].desc;
                        prevPrice = adderCalcLBS[i].price;
                    }
                    totAdderWeight += adderCalcLBS[i].skidWeight;
                }
                if (totAdderWeight > prevTotWeight)
                {
                    totAdderWeight = prevTotWeight;

                }
                if (adderCalcLBS.Count > 0)
                {
                    finalAdders.Add(new adderPrices { adderDesc = prevAdderDesc, charge = prevPrice, total = totAdderWeight * prevPrice, amount = totAdderWeight, ordBy = cntr });
                    cntr++;
                }


                prevAdderDesc = "NOPE";
                decimal totSQFT = 0;
                for (int i = 0; i < adderCalcSQFT.Count; i++)
                {
                    if (!prevAdderDesc.Equals(adderCalcSQFT[i].desc))
                    {
                        if (i > 0)
                        {
                            adderPrices ap = new adderPrices();
                            ap.adderDesc = prevAdderDesc;
                            ap.amount = Convert.ToInt32(totSQFT);
                            ap.total = totSQFT * prevPrice;
                            ap.charge = prevPrice;
                            ap.ordBy = cntr;
                            cntr++;
                            finalAdders.Add(ap);
                            totSQFT = 0;
                        }
                        prevPrice = adderCalcSQFT[i].price;
                        prevAdderDesc = adderCalcSQFT[i].desc;
                    }
                    totSQFT += adderCalcSQFT[i].totSQFT;
                }
                if (adderCalcSQFT.Count > 0)
                {
                    finalAdders.Add(new adderPrices { adderDesc = prevAdderDesc, charge = prevPrice, total = totSQFT * prevPrice, amount = Convert.ToInt32(totSQFT), ordBy = cntr });
                    cntr++;
                }

                prevAdderDesc = "NOPE";
                decimal totLINFT = 0;

                for (int i = 0; i < adderCalcLINFT.Count; i++)
                {
                    if (!prevAdderDesc.Equals(adderCalcLINFT[i].desc))
                    {
                        if (i > 0)
                        {
                            adderPrices ap = new adderPrices();
                            ap.adderDesc = prevAdderDesc;
                            ap.amount = Convert.ToInt32(totLINFT);
                            ap.total = totLINFT * prevPrice;
                            ap.charge = prevPrice;
                            ap.ordBy = cntr;
                            cntr++;
                            finalAdders.Add(ap);
                            totLINFT = 0;
                        }
                        prevPrice = adderCalcLINFT[i].price;
                        prevAdderDesc = adderCalcLINFT[i].desc;
                    }
                    totLINFT += adderCalcLINFT[i].totLINFT;
                }
                if (adderCalcLINFT.Count > 0)
                {
                    finalAdders.Add(new adderPrices { adderDesc = prevAdderDesc, charge = prevPrice, total = totLINFT * prevPrice, amount = Convert.ToInt32(totLINFT), ordBy = cntr });
                    cntr++;
                }

                prevAdderDesc = "NOPE";
                decimal totLININ = 0;

                for (int i = 0; i < adderCalcLININ.Count; i++)
                {
                    if (!prevAdderDesc.Equals(adderCalcLININ[i].desc))
                    {
                        if (i > 0)
                        {
                            adderPrices ap = new adderPrices();
                            ap.adderDesc = prevAdderDesc;
                            ap.amount = Convert.ToInt32(totLININ);
                            ap.total = totLININ * prevPrice;
                            ap.charge = prevPrice;
                            ap.ordBy = cntr;
                            cntr++;
                            finalAdders.Add(ap);
                            totLININ = 0;
                        }
                        prevPrice = adderCalcLININ[i].price;
                        prevAdderDesc = adderCalcLININ[i].desc;
                    }
                    totLININ += adderCalcLININ[i].totLININ;
                }
                if (adderCalcLININ.Count > 0)
                {
                    finalAdders.Add(new adderPrices { adderDesc = prevAdderDesc, charge = prevPrice, total = totLININ * prevPrice, amount = Convert.ToInt32(totLININ), ordBy = cntr });
                    cntr++;
                }







                using (DbDataReader reader = db.getSkidCharges(orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            adderPrices ap = new adderPrices();
                            ap.adderDesc = reader.GetString(reader.GetOrdinal("skidDescription")).Trim();
                            ap.amount = reader.GetInt32(reader.GetOrdinal("skidCnt"));
                            ap.charge = reader.GetDecimal(reader.GetOrdinal("skidPrice"));
                            ap.total = reader.GetDecimal(reader.GetOrdinal("total"));
                            ap.ordBy = cntr;
                            cntr++;
                            finalAdders.Add(ap);
                        }
                    }
                }


                

                finalAdders = finalAdders.OrderBy(o => o.ordBy).ToList();


            }
        }

        private void CalcLBS(DbDataReader reader, bool firstLBS)
        {
            decimal sheetWeight = reader.GetDecimal(reader.GetOrdinal("sheetWeight"));
            int pieceCnt = reader.GetInt32(reader.GetOrdinal("pieceCount"));
            if (sheetWeight > 0)
            {
               
                totSkidWeight += Convert.ToInt32(pieceCnt * sheetWeight);
            }
            else
            {
                decimal density = reader.GetDecimal(reader.GetOrdinal("densityFactor"));
                decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
                decimal width = reader.GetDecimal(reader.GetOrdinal("width"));
                decimal thickness = reader.GetDecimal(reader.GetOrdinal("thickness"));

                MetalFormula mt = new MetalFormula();
                totSkidWeight = Convert.ToInt32(mt.MetFormula(density, thickness, length, width, pieceCnt, 0));

            }
            if (firstLBS)
            {
                totCoilWeight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
            }
            AdderCalcLBS ac = new AdderCalcLBS();

            ac.price = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
            ac.desc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
            ac.tagID = reader.GetInt32(reader.GetOrdinal("skidID"));
            ac.suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            ac.totWeight = totCoilWeight;
            ac.skidWeight = totSkidWeight;
            ac.minPrice = reader.GetDecimal(reader.GetOrdinal("adderMin"));

            adderCalcLBS.Add(ac);



        }
        private void CalcSQFT(DbDataReader reader, bool firstLBS)
        {
            
            int pieceCnt = reader.GetInt32(reader.GetOrdinal("pieceCount"));
            
       
            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
            decimal width = reader.GetDecimal(reader.GetOrdinal("width"));

            decimal totSQFT = (length * width * pieceCnt) / 144;
            
            if (firstLBS)
            {
                totCoilWeight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
            }
            AdderCalcSQFT ac = new AdderCalcSQFT();

            ac.price = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
            ac.desc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
            ac.tagID = reader.GetInt32(reader.GetOrdinal("skidID"));
            ac.suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            ac.totWeight = totCoilWeight;
            ac.totSQFT = totSQFT;
            ac.minPrice = reader.GetDecimal(reader.GetOrdinal("adderMin"));

            adderCalcSQFT.Add(ac);



        }
        private void CalcLINFT(DbDataReader reader, bool firstLBS)
        {

            int pieceCnt = reader.GetInt32(reader.GetOrdinal("pieceCount"));


            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));
            

            decimal totLINFT = (length * pieceCnt) / 12;

            if (firstLBS)
            {
                totCoilWeight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
            }
            AdderCalcLINFT ac = new AdderCalcLINFT();

            ac.price = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
            ac.desc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
            ac.tagID = reader.GetInt32(reader.GetOrdinal("skidID"));
            ac.suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            ac.totWeight = totCoilWeight;
            ac.totLINFT = totLINFT;
            ac.minPrice = reader.GetDecimal(reader.GetOrdinal("adderMin"));

            adderCalcLINFT.Add(ac);



        }

        private void CalcLININ(DbDataReader reader, bool firstLBS)
        {

            int pieceCnt = reader.GetInt32(reader.GetOrdinal("pieceCount"));


            decimal length = reader.GetDecimal(reader.GetOrdinal("length"));


            decimal totLININ = (length * pieceCnt);

            if (firstLBS)
            {
                totCoilWeight = reader.GetInt32(reader.GetOrdinal("previousWeight"));
            }
            AdderCalcLININ ac = new AdderCalcLININ();

            ac.price = reader.GetDecimal(reader.GetOrdinal("adderPrice"));
            ac.desc = reader.GetString(reader.GetOrdinal("adderDesc")).Trim();
            ac.tagID = reader.GetInt32(reader.GetOrdinal("skidID"));
            ac.suffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
            ac.totWeight = totCoilWeight;
            ac.totLININ = totLININ;
            ac.minPrice = reader.GetDecimal(reader.GetOrdinal("adderMin"));

            adderCalcLININ.Add(ac);



        }
    }
}

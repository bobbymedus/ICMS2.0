using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ICMS
{
    internal class SheetSheetSamePricing
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

        public void GetShShPrices()
        {
            if (orderID > 0)
            {
                DBUtils db = new DBUtils();
                db.OpenSQLConn();
                
                
                int cntr = 2;
                int totWeight = 0;
                int totPVCSQFT = 0;
                int totPaperSQFT = 0;
                int pvcID = -1;
                decimal prevPVCPrice = 0;
                string prevPVCName = "";
                decimal paperPrice = 0;
                List<int> pvcSQFT = new List<int>();
                List<decimal> pvcPrice = new List<decimal>();
                List<string> pvcName = new List<string>();
                decimal procprice = 0;
                using (DbDataReader reader = db.GetShShSmProcPrice(orderID))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            int skidWeight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("skidWeight")));
                            totWeight += skidWeight;
                            procprice = reader.GetDecimal(reader.GetOrdinal("procPrice"));
                            int sqft = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("sqft")));
                            
                            int pvc = reader.GetInt32(reader.GetOrdinal("pvc"));
                            if (pvc > 0)
                            {
                                totPVCSQFT += sqft;
                            }
                            decimal pvcPr = reader.GetDecimal(reader.GetOrdinal("pvcPrice"));
                            string pvcDesc = "None";
                            if (!reader.IsDBNull(reader.GetOrdinal("groupName")))
                            {
                                pvcDesc = reader.GetString(reader.GetOrdinal("groupName")).Trim();
                            }
                            
                            int paper = reader.GetInt32(reader.GetOrdinal("paper"));
                            

                            if (paper > 0)
                            {
                                totPaperSQFT += sqft;
                                paperPrice = reader.GetDecimal(reader.GetOrdinal("paperPrice"));
                            }
                            if (pvc != pvcID && pvc > 0)
                            {
                                if (pvcID == -1)
                                {
                                    pvcID = pvc;
                                    prevPVCName = pvcDesc;
                                    prevPVCPrice = pvcPr;
                                }
                                else
                                {
                                    pvcSQFT.Add(totPVCSQFT);
                                    pvcPrice.Add(pvcPr);
                                    pvcName.Add(pvcDesc);
                                    pvcID = pvc;
                                    prevPVCName = pvcDesc;
                                    prevPVCPrice = pvcPr;
                                    totPVCSQFT = 0;
                                }
                               

                                
                            }

                            
                        }

                    }
                    else
                    {
                        return;
                    }
                    adderPrices adderp = new adderPrices();
                    adderp.adderDesc = "Polish Charge";
                    adderp.total = totWeight * procprice;
                    adderp.charge = procprice;
                    adderp.amount = totWeight;
                    adderp.ordBy = cntr;
                    finalAdders.Add(adderp);
                    cntr++;
                    if (pvcID > 0)
                    {
                        pvcSQFT.Add(totPVCSQFT);
                        pvcPrice.Add(prevPVCPrice);
                        pvcName.Add(prevPVCName);
                    }
                    for (int i = 0;i < pvcName.Count; i++)
                    {
                        adderPrices PVCadderp = new adderPrices();
                        PVCadderp.adderDesc = pvcName[i];
                        PVCadderp.charge = pvcPrice[i];
                        PVCadderp.amount = totPVCSQFT;
                        PVCadderp.total = adderp.charge * adderp.amount;
                        PVCadderp.ordBy = cntr;
                        finalAdders.Add(PVCadderp);
                        cntr++;
                    }
                    if (paperPrice > 0 && totPaperSQFT > 0)
                    {
                        adderPrices Paperadderp = new adderPrices();
                        Paperadderp.adderDesc = "Paper";
                        Paperadderp.charge = paperPrice;
                        Paperadderp.amount = totPaperSQFT;
                        Paperadderp.total = adderp.charge * adderp.amount;
                        Paperadderp.ordBy = cntr;
                        finalAdders.Add(Paperadderp);
                        cntr++;
                    }
                }

                adders.Clear();

                bool firstLBS = true;
                using (DbDataReader reader = db.GetPricingAdders(orderID,true))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int calcType = reader.GetInt32(reader.GetOrdinal("calcType"));

                            //0 = lbs; 1 = sqft; 2 = linear footage

                            switch (calcType)
                            {
                                case 0:
                                    CalcLbs(reader, firstLBS);
                                    break;
                                case 1:
                                    CalcSQFT(reader, firstLBS);
                                    break;
                                case 2:
                                    CalcLINFT(reader, firstLBS);
                                    break;
                                case 3:
                                    CalcLININ(reader, firstLBS);
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

        private void CalcLbs(DbDataReader reader, bool firstLBS)
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

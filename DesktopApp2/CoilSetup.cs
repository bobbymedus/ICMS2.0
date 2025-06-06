using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    class CoilSetup
    {

        public int coilTagID { get; set; }

        public string coilTagSuffix { get; set; }

        public int MaxNum = 1;

        public bool firstOne = false;

        private Boolean IsNumber(String s)
        {
            return decimal.TryParse(s, out decimal r) ? true : false;

        }

        public string NewMaxSuffix(string MaxCoilTagSuffix, string currentSuffix)
        {

            string stret = "";

            //is the current and Max both equal to ""
            if (currentSuffix.Equals(stret) && MaxCoilTagSuffix.Equals(stret))
            {
                return "." + MaxNum.ToString().Trim();
            }
            
            else
            {
                //is the current suffix "" but max is some value get next base number
                if (currentSuffix.Equals(stret))
                {

                    string[] parser = MaxCoilTagSuffix.Split('.');

                    for (int i = 0; i < parser.Count(); i++)
                    {
                        if (IsNumber(parser[i]))
                        {
                            stret = NextNumberInSequence("." + parser[i]);
                            i = parser.Count() + 1;
                        }
                    }
                }
                else
                {
                    //the max and the current are not blank.
                    
                    //is the current suffix the max?
                    if (currentSuffix.Equals(MaxCoilTagSuffix))
                    {
                        stret = currentSuffix + ".1";
                    }
                    else
                    {
                        string[] MaxParser = MaxCoilTagSuffix.Split('.');
                        string[] CurParser = currentSuffix.Split('.');

                        int curNum = -1;
                        int curLen = -1;
                        if (IsNumber(CurParser[CurParser.Length - 1]))
                        {
                            curNum = Convert.ToInt32(CurParser[CurParser.Length - 1]);
                            curLen = CurParser.Length - 1;
                        }
                        else
                        {
                            return "UNK";
                        }
                        MaxNum = -1;
                        int maxLen = MaxParser.Length - 1;
                        if (maxLen > curLen)
                        {
                            if (IsNumber(MaxParser[curLen + 1]))
                            {
                                MaxNum = Convert.ToInt32(MaxParser[curLen + 1]);

                                MaxNum++;

                                return currentSuffix + "." + MaxNum;


                            }
                            else
                            {
                                return "UNK";
                            }
                        }
                                                







                    }
                    
                    
                }
            }
            

            return stret;

        }
        public string NextNumberInSequence(string strCoilTagSuffix)
        {

            string[] parser = strCoilTagSuffix.Split('.');

            

            if (IsNumber(parser[parser.Length - 1]))
            {
                MaxNum = Convert.ToInt32(parser[parser.Length - 1]);
                MaxNum++;

                StringBuilder sb = new StringBuilder();
                //sb.Append(".");
                for (int i =0;i<parser.Length - 1; i++)
                {
                    //MessageBox.Show(sb.ToString());
                    sb.Append(parser[i]);
                    sb.Append(".");
                }
                sb.Append(MaxNum.ToString());

                string stret = sb.ToString();
                return stret;
            }
            else
            {
                return strCoilTagSuffix;
            }

        }

        public void SetStartPoint(string startPoint)
        {
            
            if (startPoint.Equals(""))
            {
                MaxNum = 1;
                return;
            }
            string[] parser = startPoint.Split('.');

            string suffix = "";
            for (int i = 1; i < parser.Length -1; i++)
            {
                suffix += "." + parser[i];
            }
            firstOne = true;

            if (parser.Length > 0)
            {
                MaxNum = Convert.ToInt32(parser[parser.Length-1]);
            }
            coilTagSuffix = suffix;
        }

        public void resetTag()
        {
            firstOne = false;
        }
        
        public string getNextSuffix()
        {
            if (!firstOne)
            {
                MaxNum = 1;
                DBUtils db = new DBUtils();

                db.OpenSQLConn1();


                string retVal = db.getMaxCoilSuffix(coilTagID, coilTagSuffix);


               

                retVal = NewMaxSuffix(retVal, coilTagSuffix);

                firstOne = true;

                db.CloseSQLConn1();

                return retVal;
                
            }
            else
            {
                MaxNum++;
                return coilTagSuffix + "." + MaxNum.ToString().Trim();
            }

        }
    }
}

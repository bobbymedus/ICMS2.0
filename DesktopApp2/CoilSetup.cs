using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    class CoilSetup
    {
        private Boolean IsNumber(String s)
        {
            return decimal.TryParse(s, out decimal r) ? true : false;

        }

        public string NextNumber(string strCoilTagSuffix)
        {

            string[] parser = strCoilTagSuffix.Split('.');

            if (IsNumber(parser[parser.Length - 1]))
            {
                int nn = Convert.ToInt32(parser[parser.Length - 1]);
                nn++;

                StringBuilder sb = new StringBuilder();
                //sb.Append(".");
                for (int i =0;i<parser.Length - 1; i++)
                {
                    //MessageBox.Show(sb.ToString());
                    sb.Append(parser[i]);
                    sb.Append(".");
                }
                sb.Append(nn.ToString());

                string stret = sb.ToString();
                return stret;
            }
            else
            {
                return strCoilTagSuffix;
            }


            
            
        }
    }
}

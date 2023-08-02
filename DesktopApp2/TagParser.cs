using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    internal class TagParser
    {

        public string TagToBeParsed { get; set; }
        public int TagID { get; set; }
        public string CoilTagSuffix { get; set; }
        public string SkidLetter { get; set; }

        public bool HasLetter { get; set; }

        private Boolean IsNumber(String s)
        {
            Boolean value = true;
            foreach (Char c in s.ToCharArray())
            {
                value = value && Char.IsDigit(c);
            }

            return value;
        }
        public int ParseTag()
        {
            string[] tagparts = TagToBeParsed.Split('.');

            int skCntr = 0;
            int ctCntr = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder cb = new StringBuilder();

            for (int j = 1; j < tagparts.Length; j++)
            {
                if (!IsNumber(tagparts[j].Trim()))
                {
                    if (skCntr == 0)
                    {
                        sb.Append(tagparts[j].Trim());
                        skCntr++;
                    }
                    else
                    {
                        sb.Append("." + tagparts[j].Trim());
                        skCntr++;
                    }
                }
                else
                {

                    cb.Append("." + tagparts[j].Trim());
                    ctCntr++;

                }

            }
            if (IsNumber(tagparts[0].Trim()))
            {
                TagID = Convert.ToInt32(tagparts[0].Trim());
            }
            else
            {
                MessageBox.Show("Must be a valid tag number");
                TagID = -999;
               
            }
            if (sb.ToString().Trim().Length > 0)
            {
                HasLetter = true;
            }
            else
            { 
                HasLetter = false; 
            }
            SkidLetter = sb.ToString().Trim();
            CoilTagSuffix = cb.ToString().Trim();
            return TagID;
        }
    }
}

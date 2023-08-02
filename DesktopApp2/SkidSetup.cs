using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMS
{
    class SkidSetup
    {

        public string currentMaxLetter;

        public string SetFirstLetter(string firstLetter = "A")
        {
            currentMaxLetter = firstLetter;
            return currentMaxLetter;
        }


        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }
        static int ColumnToInt(string StartLetter)
        {
            int sum = 0;

            for (int i = 0; i < StartLetter.Length; i++)
            {
                sum *= 26;
                sum += (StartLetter[i] - 'A' + 1);
            }

            return sum;
        }
        public string GetPreviousLetter(string StartLetter)
        {


            

            if (string.IsNullOrEmpty(StartLetter)) throw new ArgumentNullException("columnName");

            StartLetter = StartLetter.ToUpperInvariant();

            int sum = ColumnToInt(StartLetter);

            string PrevLetter = ColumnIndexToColumnLetter(sum - 1);

            return PrevLetter;


        }
        public string GetNextLetter()
        {

            if (NextLetter().Equals("A"))
            {
                string stepper;
                if (currentMaxLetter.Length > 1)
                {
                    stepper = NextLetter(currentMaxLetter.Substring(currentMaxLetter.Length - 2, 1));
                    if (stepper.Equals("A"))
                    {
                        bool allZ = true;
                        string tempA = "";
                        for (int i = 0; i < currentMaxLetter.Length; i++)
                        {
                            if (!currentMaxLetter.Substring(i, 1).Equals("Z"))
                            {
                                allZ = false;
                                i = currentMaxLetter.Length;


                            }
                            tempA += "A";
                        }
                        if (allZ)
                        {
                            currentMaxLetter = tempA + "A";
                        }

                    }
                    else
                    {
                        currentMaxLetter = currentMaxLetter.Substring(0, currentMaxLetter.Length - 2) + stepper + NextLetter();
                    }
                }
                else
                {
                    currentMaxLetter = "AA";
                }
                
               
                
            }
            else
            {
                currentMaxLetter = currentMaxLetter.Substring(0, currentMaxLetter.Length - 1) + NextLetter();
            }
            

            return currentMaxLetter;
        }
        private string PreviousLetter(string currLetter = "")
        {

            if (currLetter.Equals(""))
            {
                currLetter = currentMaxLetter;
            }
            char letter = 'a';

            if (currLetter.Length > 1)
            {
                letter = Convert.ToChar(currLetter.Substring(currLetter.Length - 1));
            }
            else
            {
                letter = Convert.ToChar(currLetter);
            }


            char nextChar = ' ';

            if (letter == 'a')
                nextChar = 'z';
            else if (letter == 'A')
                nextChar = 'Z';

            else
                nextChar = (char)(((int)letter) - 1);

            return Convert.ToString(nextChar);
        }
        private string NextLetter(string currLetter = "")
        {
            
            if (currLetter.Equals(""))
            {
                currLetter = currentMaxLetter;
            }
            char letter = 'a';

            if (currLetter.Length > 1)
            {
                letter = Convert.ToChar(currLetter.Substring(currLetter.Length - 1));
            }
            else
            {
                letter = Convert.ToChar(currLetter);
            }

            
            char nextChar = ' ';

            if (letter == 'z')
                nextChar = 'a';
            else if (letter == 'Z')
                nextChar = 'A';

            else
                nextChar = (char)(((int)letter) + 1);

            return Convert.ToString(nextChar);
        }
        public bool LetterInSeries(string letterToCheck, string firstLetter, string LastLetter)
        {



            int ltc = ColumnToInt(letterToCheck);
            int fl = ColumnToInt(firstLetter);
            int ll = ColumnToInt(LastLetter);

            if (fl <= ltc && ll >= ltc)
            {
                return true;
            }else
            {
                return false;
            }

        }

    }
}

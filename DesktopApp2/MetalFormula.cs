using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMS
{
    class MetalFormula
    {

        public decimal MetFormula(decimal metFactor, decimal gauge, decimal length, decimal width, int piececount, int weight, bool bRoundOff = true)
        {

            decimal retVal = 0;





            if (gauge == 0)
            {
                if (length == 0 || width == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (piececount * length * width * metFactor)), 4);
                return retVal;
            }

            if (length == 0)
            {
                if (gauge == 0 || width == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * piececount * width * metFactor)), 3);
                return retVal;

            }

            if (width == 0)
            {
                if (gauge == 0 || length == 0 || piececount == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * length * piececount * metFactor)), 1);
                return retVal;

            }

            if (piececount == 0)
            {
                if (gauge == 0 || length == 0 || width == 0 || weight == 0)
                {
                    return -1;
                }
                retVal = Math.Round((weight / (gauge * length * width * metFactor)), 0);
                return retVal;
            }

            if (weight == 0)
            {
                if (gauge == 0 || length == 0 || width == 0 || piececount == 0)
                {
                    return -1;
                }
                if (bRoundOff)
                {

                    retVal = Math.Round((piececount * gauge * length * width * metFactor), 0);
                }
                else
                {
                    retVal = piececount * gauge * length * width * metFactor;
                }
                return retVal;
            }
            //something went wrong.  Shouldn't get to this point.
            return -1;
        }
    }
}

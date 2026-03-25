using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class RosszKosarKalkulator
    {
        public double ArSzamitas(string vevoTipus,double ar)
        {
            if (vevoTipus == "uj")
            {
                return ar * 0.9;
            } else if(vevoTipus == "regi")
            {
                return ar * 0.8;
            }

            return ar;
        }
    }
}

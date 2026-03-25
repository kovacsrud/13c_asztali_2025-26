using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class RegiVevo : IKosar
    {
        public double ArSzamitas(double ar)
        {
            return ar * 0.8;
        }
    }
}

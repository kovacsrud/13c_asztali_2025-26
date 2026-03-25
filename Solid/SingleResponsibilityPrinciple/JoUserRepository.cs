using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class JoUserRepository
    {
        public void DbMentes(JoUser joUser)
        {
            Console.WriteLine("User adat mentése");
        }

        public void DbUjUser(JoUser joUser)
        {
            Console.WriteLine("Új user felvitele");
        }
    }
}

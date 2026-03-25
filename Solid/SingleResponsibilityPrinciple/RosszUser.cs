using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class RosszUser
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }


        public void DbMentes(string user)
        {
            Console.WriteLine("Mentés az adatbázisba");
        }

        public void DbUjAdat(string user) 
        {
            Console.WriteLine("Új user felvitele");
        }
    }
}

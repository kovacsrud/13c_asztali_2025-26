using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class OracleDB : IDatabase
    {
        public void Mentes(string data)
        {
            Console.WriteLine("Mentés az adatbázisba");
        }
    }
}

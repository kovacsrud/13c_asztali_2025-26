using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class RosszFeketeNyomtato : IMultiPrinter
    {
        public void FeketeFeherNyomtatas()
        {
            Console.WriteLine("Fekete-fehér nyomtatás");
        }

        public void SzinesNyomtatas()
        {
            Console.WriteLine("Ilyet sajnos nem tudok");
        }

        public void Szkenneles()
        {
            Console.WriteLine("Szkennelni sem tudok sajnos...");
        }
    }
}

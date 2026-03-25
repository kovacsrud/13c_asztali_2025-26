using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class JoPingvin : JoMadar
    {
        public override void Eszik()
        {
            Console.WriteLine("A pingvin eszik");
        }
    }
}

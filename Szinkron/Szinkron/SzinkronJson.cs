using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkron
{


    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int szinkid { get; set; }
        public string szinesz { get; set; }
        public string szerep { get; set; }
        public string magyarhang { get; set; }
        public Film film { get; set; }
    }

    public class Filmjs
    {
        public int filmaz { get; set; }
        public string cim { get; set; }
        public int ev { get; set; }
        public int korhataros { get; set; }
        public string magyarszoveg { get; set; }
        public string szinkronrendezo { get; set; }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Szinkron
{
    public static class SzinkronBetolt
    {
        public static List<Szinkronhang> LoadFromJson(string fajl)
        {
            List<Szinkronhang> szinkronhangok=new List<Szinkronhang>();
            var jsonFajl = File.ReadAllText(fajl);

            szinkronhangok = JsonConvert.DeserializeObject<List<Szinkronhang>>(jsonFajl);


            return szinkronhangok;

        }
        public static List<Szinkronhang> LoadFromCsv(string fajl)
        {
            List<Szinkronhang> szinkronhangok = new List<Szinkronhang>();
            



            return szinkronhangok;

        }
    }
}

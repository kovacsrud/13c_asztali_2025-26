using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkron
{
    public class Film
    {
        public int FilmAz { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public bool Korhataros { get; set; }
        public string MagyarSzoveg { get; set; }
        public string SzinkronRendezo { get; set; }

        public Film()
        {
            
        }

        public Film(string sor,char hatarolo)
        {
            var adatok = sor.Split(hatarolo);
            FilmAz = Convert.ToInt32(adatok[4]);
            Cim = adatok[5];
            Ev=Convert.ToInt32(adatok[6]);
            Korhataros=Convert.ToBoolean(adatok[7]);
            MagyarSzoveg=adatok[8];
            SzinkronRendezo=adatok[9];
        }

    }
}

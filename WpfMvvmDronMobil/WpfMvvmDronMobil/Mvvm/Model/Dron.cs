using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmDronMobil.Mvvm.Model
{
    public class Dron
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public int GyartasiEv { get; set; }
        public int MaxSebesseg { get; set; }
        public int AkkuKapacitas { get; set; }
        public int RepulesiIdo { get; set; }

        public Dron()
        {
            
        }

        public Dron(string sor, char hatarolo)
        {
            var adatok = sor.Split(hatarolo);

            Nev = adatok[0];
            Tipus = adatok[1];
            GyartasiEv = Convert.ToInt32(adatok[2]);
            MaxSebesseg = Convert.ToInt32(adatok[3]);
            AkkuKapacitas = Convert.ToInt32(adatok[4]);
            RepulesiIdo = Convert.ToInt32(adatok[5]);
        }
    }
}

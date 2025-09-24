using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmDronMobil.Mvvm.Model
{
    public class Mobil
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Gyarto { get; set; }
        public string Modell { get; set; }
        public string OS { get; set; }
        public string GyartasiEv { get; set; }

        public Mobil()
        {
            
        }

        public Mobil(string sor, char hatarolo)
        {
            var adatok = sor.Split(hatarolo);

            Id = Convert.ToInt32(adatok[0]);
            Nev = adatok[1];
            Gyarto = adatok[2];
            Modell = adatok[3];
            OS = adatok[4];
            GyartasiEv = (adatok[5]);
        }
    }
}

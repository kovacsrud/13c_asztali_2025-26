using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmDronMobil
{
    public static class Config
    {
        public static char MobilHatarolo { get; set; } = ';';
        public static char DronHatarolo { get; set; } = ';';
        public static string MobilFajl { get; set; } = "mobil_adatok_win_pv.csv";
        public static string DronFajl { get; set; } = "dronok.csv";
        public static int DronStart { get; set; } = 1;
        public static int MobilStart { get; set; } = 1;

    }
}

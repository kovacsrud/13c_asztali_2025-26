using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkron
{
    public class Szinkronhang
    {
        public int SzinkId { get; set; }
        public string Szinesz { get; set; }
        public string Szerep { get; set; }
        public string Magyarhang { get; set; }
        public Film Film { get; set; }

        public Szinkronhang()
        {
            
        }

        public Szinkronhang(string adatsor,char hatarolo)
        {
            var adatok = adatsor.Split(hatarolo);

            SzinkId = Convert.ToInt32(adatok[0]);
            Szinesz=adatok[1];
            Szerep = adatok[2];
            Magyarhang = adatok[3];
            Film= new Film(adatsor,hatarolo);
        }
    }
}

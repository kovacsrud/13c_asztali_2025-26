using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maratonvalto
{
    public static class LoadData
    {
        public static List<Eredmeny> LoadFromCsv(string fajl)
        {
            List<Eredmeny> eredmenyek= new List<Eredmeny>();

            var sorok=File.ReadAllLines(fajl,Encoding.UTF8);

            for (int i = 1; i < sorok.Length; i++)
            {
                var adatok = sorok[i].Split(';');
                Futo futo = new Futo {
                    Fid=Convert.ToInt32(adatok[0]),
                    Fnev=adatok[1],
                    Szulev=Convert.ToInt32(adatok[2]),
                    Szulho=Convert.ToInt32(adatok[3]),
                    Csapat=Convert.ToInt32(adatok[4]),
                    Ffi=Convert.ToInt32(adatok[5])

                };

                eredmenyek.Add(new Eredmeny
                {
                    Kor = Convert.ToInt32(adatok[6]),
                    Ido = Convert.ToInt32(adatok[7]),
                    Versenyzo = futo

                });
                
            }


            return eredmenyek;
        }
    }
}

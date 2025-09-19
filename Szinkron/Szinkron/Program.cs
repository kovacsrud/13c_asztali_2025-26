using System.Text;

namespace Szinkron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Szinkronhang> szinkronhangok=new List<Szinkronhang>();
            try
            {
                szinkronhangok = SzinkronBetolt.LoadFromJson("szinkronhangok.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.WriteLine(szinkronhangok.Count);

            var korhatarosDB = szinkronhangok.Count(x => x.Film.Korhataros == true);
            var nemkorhatarosDB = szinkronhangok.Count(x => x.Film.Korhataros == false);

            Console.WriteLine($"Korhatáros:{korhatarosDB},nem korhatáros:{nemkorhatarosDB}");

            //Statisztika
            var stat = szinkronhangok.ToLookup(x=>new {x.Film.FilmAz,x.Film.Cim});

            try
            {
                FileStream fajl = new FileStream("szinkronstat.txt",FileMode.Create);
                using (StreamWriter writer=new StreamWriter(fajl,Encoding.UTF8))
                {
                    foreach (var i in stat)
                    {
                        writer.WriteLine($"{i.Key.FilmAz}-{i.Key.Cim}-{i.Count()} db");
                    }
                }
                Console.WriteLine("Fájlba írás kész!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.Write("Szinkronszínész neve:");
            var szineszNeve=Console.ReadLine();

            var szineszAdatok = szinkronhangok.FindAll(x=>x.Magyarhang==szineszNeve);

            if (szineszAdatok.Count>0)
            {
                foreach (var i in szineszAdatok)
                {
                    Console.WriteLine($"{i.Szinesz},{i.Film.Cim},{i.Szerep},{i.Film.Ev}");
                }

            } else
            {
                Console.WriteLine("Nincs ilyen szinkronszínész!");
            }


                Console.ReadLine();
        }
    }
}

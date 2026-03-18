using System.Diagnostics;

namespace Rekurzio
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Rekurzió: amikor egy függvény saját magát hívja meg

            Stopwatch stopper=new Stopwatch();
            stopper.Start();
            Kiir(10000);
            stopper.Stop();
            Console.WriteLine($"Rekurzió végrehajtási idő:{stopper.ElapsedTicks}");

            stopper.Start();
            KiirFor(10000);
            stopper.Stop();
            Console.WriteLine($"Rekurzió nélküli végrehajtási idő:{stopper.ElapsedTicks}");


        }

        private static void KiirFor(int szamlalo)
        {
            for (int i = 0; i < szamlalo; i++)
            {
                //Console.WriteLine($"Számláló:{i}");
            }
        }

        //Rekurzív függvény
        private static void Kiir(int szamlalo)
        {
            //Console.WriteLine($"Számláló(r):{szamlalo}");
            szamlalo--;
            if (szamlalo>0)
            {
                Kiir(szamlalo);
            }
        }
    }
}

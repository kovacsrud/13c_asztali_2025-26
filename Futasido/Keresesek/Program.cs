using System.Diagnostics;

namespace Keresesek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10000;
            Random rand= new Random();
            Stopwatch stopper = new Stopwatch();
            int[] szamok=new int[n];

            for(int i=0; i<szamok.Length; i++)
            {
                szamok[i] = rand.Next(0, 1000 + 1);
            }
            int keresett= 131;
            stopper.Start();
            Console.WriteLine($"A keresett elem indexe:{LinearisKereses(keresett, szamok)}");
            stopper.Stop();
            Console.WriteLine($"Lineáris keresés végrehajtási idő:{stopper.ElapsedTicks}");
            stopper.Reset();
            stopper.Start();
            Console.WriteLine($"A keresett elem indexe:{BinarisKereses(keresett,szamok)}");
            stopper.Stop();
            Console.WriteLine($"Bináris keresés végrehajtási idő:{stopper.ElapsedTicks}");

        }

        private static int BinarisKereses(int keresett, int[] tomb)
        {
            Array.Sort(tomb);
            int bal = 0;
            int jobb = tomb.Length - 1;

            while (bal<=jobb)
            {
                int kozep=bal+(jobb-bal)/2;

                if (tomb[kozep] == keresett)
                {
                    return kozep;
                }
                else if (tomb[kozep] < keresett)
                {
                    bal = kozep + 1;
                }
                else {
                    jobb = kozep - 1;
                }
            }
            return -1;
        }

        private static int LinearisKereses(int keresett, int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++) {

                if (tomb[i] == keresett) { 

                    return i;
                }
            
            }
            return -1;
        }
    }
}

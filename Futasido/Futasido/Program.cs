using System.Diagnostics;

namespace Futasido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10000;
            int[] szamok= new int[n];
            int[,] szamok2d = new int[n, n];

            Stopwatch stopper = new Stopwatch();
            stopper.Start();
            for (int i = 0; i < szamok.Length; i++) {
                szamok[i] = 1;
            }
            stopper.Stop();
            Console.WriteLine($"Egy dimenziós tömb:{stopper.ElapsedTicks}");
            
            stopper.Reset();
            stopper.Start();
            for (int i = 0; i < szamok2d.GetLength(0); i++)
            {
                for (int j = 0; j < szamok2d.GetLength(1); j++)
                {
                    szamok2d[i, j] = 1;
                }
            }
            stopper.Stop();
            Console.WriteLine($"Két dimenziós tömb:{stopper.ElapsedTicks}");
        }
    }
}

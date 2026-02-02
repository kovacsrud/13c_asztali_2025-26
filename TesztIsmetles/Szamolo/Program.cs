using TesztIsmetles;
namespace Szamolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dll kipróbálása");
            Alapmuveletek alapmuveletek = new Alapmuveletek();

            Console.WriteLine(alapmuveletek.Osszead(101,102));
            Console.WriteLine(alapmuveletek.Kivon(101, 102));
            Console.WriteLine(alapmuveletek.Szoroz(101, 102));
            Console.WriteLine(alapmuveletek.Oszt(101, 102));


        }
    }
}

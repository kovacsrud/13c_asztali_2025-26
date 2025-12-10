namespace Bitmuveletek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitenkénti műveletek!");
            byte a = 14;
            Console.WriteLine($"A:{Convert.ToString(a,2).PadLeft(8,'0')}");

            byte b = 12;
            Console.WriteLine($"B:{Convert.ToString(b, 2).PadLeft(8, '0')}");

            byte c = 9;
            Console.WriteLine($"C:{Convert.ToString(c, 2).PadLeft(8, '0')}");

            byte d = 5;
            Console.WriteLine($"D:{Convert.ToString(d, 2).PadLeft(8, '0')}");

            ushort tomoritett = 0;
            Console.WriteLine($"Tomoritett:{Convert.ToString(tomoritett, 2).PadLeft(16, '0')}");

            tomoritett = (ushort)(a << 12);

            Console.WriteLine($"Tomoritett:{Convert.ToString(tomoritett, 2).PadLeft(16, '0')}");

            tomoritett |= (ushort)(b << 8);

            Console.WriteLine($"Tomoritett:{Convert.ToString(tomoritett, 2).PadLeft(16, '0')}");

            tomoritett |= (ushort)(c << 4);

            Console.WriteLine($"Tomoritett:{Convert.ToString(tomoritett, 2).PadLeft(16, '0')}");

            tomoritett |= (ushort)(d);
            Console.WriteLine($"Tomoritett:{Convert.ToString(tomoritett, 2).PadLeft(16, '0')}");

            //Egy sorban is lehet
            //tomoritett=(ushort)(a<<12 | b<<8 | c<<4 | d);

            byte visszaA=(byte)((tomoritett>>12) & 0b_0000_0000_0000_1111);
            Console.WriteLine(visszaA);

            byte visszaB = (byte)((tomoritett >> 8) & 0b_0000_0000_0000_1111);
            Console.WriteLine(visszaB);

            byte visszaC = (byte)((tomoritett >> 4) & 0b_0000_0000_0000_1111);
            Console.WriteLine(visszaC);

            byte visszaD = (byte)((tomoritett) & 0b_0000_0000_0000_1111);
            Console.WriteLine(visszaD);



        }
    }
}

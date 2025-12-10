using System.Text;

namespace BinarisFajlkezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bináris fájlkezelés");

            var szovegFajl = File.ReadAllBytes("szinek.txt");

            foreach (var bajt in szovegFajl) {
                //Console.Write(bajt+" ");
                //Binárisan
                //Console.Write(Convert.ToString(bajt,2).PadLeft(8,'0')+" ");

            }

            //Console.WriteLine(Encoding.UTF8.GetString(szovegFajl));

            var zipFajl = File.ReadAllBytes("MonthyHallGame.zip");

            foreach (var bajt in zipFajl) {
                //Console.Write(Convert.ToString(bajt, 2).PadLeft(8, '0') + " ");
            }

            //Console.WriteLine(Encoding.UTF8.GetString(zipFajl));

            using (MemoryStream ms=new MemoryStream(zipFajl))
            {
                using (BinaryReader br=new BinaryReader(ms))
                {
                    var signature = br.ReadBytes(4);
                    Console.WriteLine($"Signature:{BitConverter.ToString(signature)}");
                    var version = br.ReadBytes(2);
                    Console.WriteLine($"Version:{BitConverter.ToInt16(version)}");
                    var flags=br.ReadBytes(2);
                    Console.WriteLine($"Flags:{BitConverter.ToInt16(flags)}");
                    var compression = br.ReadBytes(2);
                    Console.WriteLine($"compression:{BitConverter.ToInt16(compression)}");
                    var modtime = br.ReadBytes(2);
                    Console.WriteLine($"Mod time:{BitConverter.ToInt16(modtime)}");
                    var moddate = br.ReadBytes(2);
                    Console.WriteLine($"Mod date:{BitConverter.ToInt16(moddate)}");
                    var crc=br.ReadBytes(4);
                    Console.WriteLine($"Crc:{BitConverter.ToInt16(crc)}");
                    var compressed = br.ReadBytes(4);
                    Console.WriteLine($"Compressed:{BitConverter.ToInt16(compressed)}");
                    var uncompressed = br.ReadBytes(4);
                    Console.WriteLine($"Compressed:{BitConverter.ToInt16(uncompressed)}");
                    var fileNameLength=br.ReadBytes(2);
                    Console.WriteLine($"File name length:{BitConverter.ToInt16(fileNameLength)}");
                    var extraFieldLength = br.ReadBytes(2);
                    Console.WriteLine($"File name length:{BitConverter.ToInt16(extraFieldLength)}");
                    var fileName = br.ReadBytes(BitConverter.ToInt16(fileNameLength));
                    Console.WriteLine($"File name:{Encoding.UTF8.GetString(fileName)}");

                    Console.WriteLine($"File name:{BitConverter.ToString(fileName)}");

                }
            }


        }
    }
}

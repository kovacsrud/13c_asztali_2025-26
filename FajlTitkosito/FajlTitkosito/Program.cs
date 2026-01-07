using System.Text;
using System.Security.Cryptography;

namespace FajlTitkosito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fájl titkosítás");

            string fajlnev = "titkos.txt";
            string titkositando = "Szigorúan titkos tartalom!";
            string kulcs = "Titok_12";

            //Elég-e pusztán a titkosított adatokat tárolni?

            //Titkosító algoritmus
            Aes aes=Aes.Create();

            //Hash
            SHA256 sha256 = SHA256.Create();

            byte[] binKulcs = sha256.ComputeHash(Encoding.UTF8.GetBytes(kulcs));
            byte[] tartalomHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(titkositando));
            byte[] fajlnevBin=Encoding.UTF8.GetBytes(fajlnev);
            byte[] titkositandoBin = Encoding.UTF8.GetBytes(titkositando);
            int fajlnevHossz=fajlnevBin.Length;

            aes.Key = binKulcs;
            aes.GenerateIV();

            ICryptoTransform titkosito=aes.CreateEncryptor(binKulcs,aes.IV);
            byte[] titkositott = titkosito.TransformFinalBlock(titkositandoBin,0,titkositandoBin.Length);

            string kodoltSzoveg = Encoding.UTF8.GetString(titkositott);
            Console.WriteLine(kodoltSzoveg);

            //Fájl formátum

        }
    }
}

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
            int tartalomHossz=titkositott.Length;

            string kodoltSzoveg = Encoding.UTF8.GetString(titkositott);
            Console.WriteLine(kodoltSzoveg);

            //Fájl formátum
            //IV - 16 byte//fájlnév hossza 4 byte//fájlnév - változó/tartalom hash - 32 byte//tartalom hossza - 4 byte// titkosított tartalom

            var kodoltAdatok = new byte[aes.IV.Length+fajlnevHossz+fajlnevBin.Length+tartalomHash.Length+tartalomHossz+titkositott.Length];

            using (MemoryStream ms=new MemoryStream(kodoltAdatok))
            {
                using(BinaryWriter writer=new BinaryWriter(ms))
                {
                    writer.Write(aes.IV);
                    writer.Write(fajlnevHossz);
                    writer.Write(fajlnevBin);
                    writer.Write(tartalomHash);
                    writer.Write(tartalomHossz);
                    writer.Write(titkositott);
                }
                File.WriteAllBytes("titkositott.bin",kodoltAdatok);
                Console.WriteLine("Fájl kiírva");
            }

            //Visszafejtés
            byte[] fajl = File.ReadAllBytes("titkositott.bin");
            int fajlLength=fajl.Length;
            byte[] initVektor;
            byte[] visszaFajlnev;
            byte[] visszaTartalomHash;
            byte[] visszaTartalom;
            string jelszo = "Titok_12";
            byte[] visszaKulcs = sha256.ComputeHash(Encoding.UTF8.GetBytes(jelszo));

            using (MemoryStream ms=new MemoryStream(fajl))
            {
                using (BinaryReader reader=new BinaryReader(ms))
                {
                    initVektor = reader.ReadBytes(16);
                    int fajlnevMeret = BitConverter.ToInt32(reader.ReadBytes(4));
                    visszaFajlnev=reader.ReadBytes(fajlnevMeret);
                    visszaTartalomHash = reader.ReadBytes(32);
                    int visszaTartalomHossz=BitConverter.ToInt32(reader.ReadBytes(4));
                    visszaTartalom = reader.ReadBytes(visszaTartalomHossz);
                }
            }

            ICryptoTransform dekodolo=aes.CreateDecryptor(visszaKulcs,initVektor);
            byte[] dekodolt = dekodolo.TransformFinalBlock(visszaTartalom,0,visszaTartalom.Length);

            //Hash készítés a visszaolvasott tartalomról
            byte[] ellenorzoHash = sha256.ComputeHash(dekodolt);

            if (Encoding.UTF8.GetString(ellenorzoHash)==Encoding.UTF8.GetString(visszaTartalomHash))
            {
                Console.WriteLine("A jelszó megfelelő!");
                File.WriteAllBytes(Encoding.UTF8.GetString(visszaFajlnev),dekodolt);
            } else
            {
                Console.WriteLine("A jelszó nem megfelelő!");
            }



        }
    }
}

using KRHash;

namespace DllTeszt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dll használata");
            CreateHash hash = new CreateHash();

            var md5Hash = hash.MakeHash(HashType.MD5, "valami");
            var md5HashUpper = hash.MakeHash(HashType.MD5, "valami",true);

            Console.WriteLine(md5Hash);
            Console.WriteLine(md5HashUpper);


        }
    }
}

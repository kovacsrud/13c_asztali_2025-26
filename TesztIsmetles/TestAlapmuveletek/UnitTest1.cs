using TesztIsmetles;

namespace TestAlapmuveletek
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(20,10,10)]
        [TestCase(40, 20, 20)]
        [TestCase(30, 20, 10)]
        [TestCase(100, 20, 80)]
        public void TestOsszead(int elvart,int a,int b)
        {
            //AAA -- Arrange, Act, Assert
            var alapmuveletek=new Alapmuveletek();
            var eredmeny = alapmuveletek.Osszead(a, b);
            Assert.AreEqual(elvart, eredmeny);
        }

        [Test]
        [TestCase(10,30,20)]
        public void TestKivonas(int elvart,int a,int b)
        {
            var alapmuveletek = new Alapmuveletek();
            var eredmeny = alapmuveletek.Kivon(a, b);
            Assert.AreEqual(elvart, eredmeny);
        }

        [Test]
        [TestCaseSource("GetOsztasAdatok")]
        public void TesztOsztas(double a,double b,double elvart)
        {
            var alapmuveletek = new Alapmuveletek();
            var eredmeny = alapmuveletek.Oszt(a, b);
            Assert.AreEqual(elvart, eredmeny,0.000001);
        }

        public static IEnumerable<double[]> GetOsztasAdatok()
        {
            var sorok = File.ReadAllLines("tesztesetek_osztas.csv");
            for (int i = 0; i < sorok.Length; i++)
            {
                var adatok = sorok[i].Split(';');
                double a=Convert.ToDouble(adatok[0]);
                double b=Convert.ToDouble(adatok[1]);
                double elvart=Convert.ToDouble(adatok[2]);

                yield return new[] { a, b, elvart };

            }
        }

    }
}
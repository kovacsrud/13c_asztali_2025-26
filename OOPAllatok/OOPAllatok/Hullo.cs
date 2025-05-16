using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAllatok
{
    public class Hullo:Allat
    {
        public bool Mergezo { get; set; }
        public Hullo(string nev, string faj, int kor,bool mergezo) : base(nev, faj, kor)
        {
            Mergezo = mergezo;
        }

        public override void Hang()
        {
            Console.WriteLine("A hüllő sziszeg.");
        }

        public override string ToString()
        {
            return base.ToString()+$" Mérges:{(Mergezo ? "igen":"nem")}";
        }
    }
}

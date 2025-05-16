using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAllatok
{
    public class Emlos:Allat
    {

        public bool IsSzoros { get; set; }
        public Emlos(string nev, string faj, int kor,bool iSszoros) : base(nev, faj, kor)
        {
            IsSzoros = iSszoros;
        }
                

        public override void Hang()
        {
            Console.WriteLine("Az emlős morgást hallat");
        }

        public override string ToString()
        {
            return base.ToString()+$"Szőrös?{(IsSzoros ? "igen" :"nem")}";
        }


    }
}

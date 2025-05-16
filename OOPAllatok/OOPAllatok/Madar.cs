using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAllatok
{
    public class Madar:Allat
    {
        public int Szarnyfesztav { get; set; }

        public Madar(string nev, string faj, int kor,int szarnyfesztav) : base(nev, faj, kor)
        {
            Szarnyfesztav = szarnyfesztav;
        }

        
        public override void Hang()
        {
            Console.WriteLine("A madár csiripel"); 
        }

        public override string ToString()
        {
            return base.ToString()+$" Szárnyfesztáv:{Szarnyfesztav}";
        }
    }
}

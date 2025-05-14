using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutok.model
{
    public class Autolista
    {
        public List<Auto> Autok { get; set; } = new List<Auto>();

        public Autolista(string fajl,char hatarolo,int start=1)
        {
            var sorok=File.ReadAllLines(fajl,Encoding.UTF7);

            for (int i = start; i < sorok.Length; i++)
            {
                Autok.Add(new Auto(sorok[i], hatarolo));
            }
        }
    }
}

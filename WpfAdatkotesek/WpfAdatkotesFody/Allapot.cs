using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace WpfAdatkotesFody
{
    [AddINotifyPropertyChangedInterface]
    public class Allapot
    {
        public int Ertek { get; set; }

        public Allapot(int ertek)
        {
            Ertek= ertek;    
        }
    }
}

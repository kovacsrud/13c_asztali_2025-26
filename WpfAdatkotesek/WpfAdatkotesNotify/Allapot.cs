using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAdatkotesNotify
{
    public class Allapot:INotifyPropertyChanged
    {
        private int ertek;
        public int Ertek { 
            get {  return ertek; }
            set
            {
                ertek = value;
                Prop_Changed("Ertek");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Prop_Changed(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

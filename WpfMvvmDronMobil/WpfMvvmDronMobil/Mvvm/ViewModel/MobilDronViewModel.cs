using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMvvmDronMobil.Mvvm.Model;
using PropertyChanged;

namespace WpfMvvmDronMobil.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MobilDronViewModel
    {
        public List<Dron> Dronok { get; set; }=new List<Dron>();
        public List<Mobil> Mobilok { get; set; } = new List<Mobil>();

        public Dron SelectedDron { get; set; } = new Dron();
        public Mobil SelectedMobil { get; set; } = new Mobil();

        public MobilDronViewModel()
        {
            try
            {
                var dronAdatok = File.ReadAllLines(Config.DronFajl, Encoding.Default);
                for (int i = Config.DronStart; i < dronAdatok.Length; i++)
                {
                    Dronok.Add(new Dron(dronAdatok[i], Config.DronHatarolo));
                }

                var mobilAdatok=File.ReadAllLines(Config.MobilFajl,Encoding.Default);
                for (int i = Config.MobilStart; i < mobilAdatok.Length; i++)
                {
                    Mobilok.Add(new Mobil(mobilAdatok[i], Config.MobilHatarolo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }   
        }
    }
}

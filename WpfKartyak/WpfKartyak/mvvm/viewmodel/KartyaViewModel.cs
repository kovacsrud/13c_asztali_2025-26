using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfKartyak.mvvm.model;

namespace WpfKartyak.mvvm.viewmodel
{
    [AddINotifyPropertyChangedInterface]
    public class KartyaViewModel
    {
        public List<Kartya> Pakli { get; set; } = new List<Kartya>();
        public List<BitmapImage> Hatterek { get; set; }=new List<BitmapImage>();
        public Kartya SelectedKartya { get; set; } = new Kartya();

        public BitmapImage SelectedHatter { get; set; } = new BitmapImage();

        public int Kassza { get; set; } = 1000;
        public int Tet { get; set; } = 100;

        public bool JatekVege { get; set; } = false;

        ResourceManager cardManager = new ResourceManager("WpfKartyak.Kartyak", Assembly.GetExecutingAssembly());
        ResourceManager cardBackManager = new ResourceManager("WpfKartyak.KartyaBack",Assembly.GetExecutingAssembly());

        public KartyaViewModel()
        {
                
        }

        public void InitPakli()
        {
            ResourceSet kartyaRs=cardManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture,true,true);

            ResourceSet kartyaBackRs = cardBackManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture,true,true);

            foreach (System.Collections.DictionaryEntry kartya in kartyaRs)
            {
                string kartyanev = kartya.Key.ToString();
                var kartyakepBin = (byte[])kartya.Value;

                Pakli.Add(new Kartya(kartyanev, kartyakepBin));
            }

            foreach(System.Collections.DictionaryEntry kartya in kartyaBackRs)
            {
                var kartyakepBin= (byte[])kartya.Value;
                //??
                Hatterek.Add(GetKartyaImage(kartyakepBin));
            }

            Kassza = 1000;
            Tet = 100;
            SelectedHatter = Hatterek[1];
            SelectedKartya = new Kartya();



            
        }

        public Kartya GetRandomKartya()
        {
            Kartya kartya = new Kartya();
            Random rnd=new Random();

            if (Pakli.Count>0)
            {
                var veletlenSzam = rnd.Next(0, Pakli.Count);
                kartya = Pakli[veletlenSzam];
                Pakli.RemoveAt(veletlenSzam);
            } else
            {
                JatekVege = true;
                MessageBox.Show($"Elfogytak a kártyák! Pontszámod:{Kassza}");
            }

            return kartya;
        }


        private BitmapImage GetKartyaImage(byte[] kepadat)
        {
            using (MemoryStream ms = new MemoryStream(kepadat))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();

                return image;
            }


        }

    }
}

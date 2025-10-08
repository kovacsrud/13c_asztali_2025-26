using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PropertyChanged;
using WpfMvvmKutyakDb.Mvvm.Model;

namespace WpfMvvmKutyakDb.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class RendeloViewModel
    {
        public List<Kutyanev> Kutyanevek { get; set; } = new List<Kutyanev>();
        public Kutyanev SelectedKutyanev { get; set; } =new Kutyanev();
        public List<Rendeles> Rendelesek { get; set; } = new List<Rendeles>();
        public Rendeles SelectedRendeles { get; set; } = new Rendeles();

        public List<Kutyafajta> Kutyafajtak { get; set; } = new List<Kutyafajta>();
        public Kutyafajta SelectedKutyafajta { get; set; } = new Kutyafajta();

        public RendeloViewModel()
        {
            GetKutyanevek();
            GetRendelesek();
            GetKutyafajtak();
        }

        public void GetKutyanevek()
        {
            Kutyanevek = DbRepo.GetKutyanevek();
        }
        public void GetKutyafajtak()
        {
            Kutyafajtak=DbRepo.GetKutyafajtak();
        }

        public void UjKutyanev(Kutyanev kutyanev)
        {
            var valasz = MessageBox.Show("Biztosan rögzíti?", "Új adat", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (valasz==MessageBoxResult.OK)
            {
                DbRepo.UjKutyanev(kutyanev);
            }
        }

        public void ModositKutyanev(Kutyanev kutyanev)
        {
            var valasz = MessageBox.Show("Biztosan módosítja?", "Módosítás", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (valasz == MessageBoxResult.OK)
            {
                DbRepo.ModositKutyanev(kutyanev);
            }
        }

        public void TorolKutyanev(Kutyanev kutyanev)
        {
            var valasz = MessageBox.Show("Biztosan törli?", "Törlés", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (valasz == MessageBoxResult.OK)
            {
                DbRepo.TorolKutyanev(kutyanev);
            }
        }

        public void GetRendelesek()
        {
            Rendelesek=DbRepo.GetRendelesek();
        }

        public void UjRendeles(Rendeles rendeles)
        {
            var valasz=MessageBox.Show("Biztosan menti?","Új rendelési adat",MessageBoxButton.OKCancel,MessageBoxImage.Question);
            if (valasz==MessageBoxResult.OK)
            {
                DbRepo.UjRendeles(rendeles);
            }
        }

        public void ModositRendeles(Rendeles rendeles)
        {
            var valasz = MessageBox.Show("Biztosan módosítja?", "Módosítás", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (valasz == MessageBoxResult.OK)
            {
                DbRepo.ModositRendeles(rendeles);
            }
        }

        public void TorolRendeles(Rendeles rendeles)
        {
            var valasz = MessageBox.Show("Biztosan törli?", "Törlés", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (valasz == MessageBoxResult.OK)
            {
                DbRepo.TorolRendeles(rendeles);
            }
        }


    }
}

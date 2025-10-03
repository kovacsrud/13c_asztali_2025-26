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

        public RendeloViewModel()
        {
            GetKutyanevek();
        }

        public void GetKutyanevek()
        {
            Kutyanevek = DbRepo.GetKutyanevek();
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


    }
}

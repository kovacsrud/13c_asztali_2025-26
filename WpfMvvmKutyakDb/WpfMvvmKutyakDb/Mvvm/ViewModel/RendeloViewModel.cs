using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using WpfMvvmKutyakDb.Mvvm.Model;

namespace WpfMvvmKutyakDb.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class RendeloViewModel
    {
        public List<Kutyanev> Kutyanevek { get; set; } = new List<Kutyanev>();
        public Kutyanev SelectedKutyanev { get; set; } = new Kutyanev();

        public RendeloViewModel()
        {
            Kutyanevek = DbRepo.GetKutyanevek();
        }
    }
}

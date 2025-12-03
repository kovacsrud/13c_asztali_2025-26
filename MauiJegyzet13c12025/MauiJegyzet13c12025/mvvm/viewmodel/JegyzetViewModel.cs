using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiJegyzet13c12025.mvvm.model;
using PropertyChanged;

namespace MauiJegyzet13c12025.mvvm.viewmodel
{
    [AddINotifyPropertyChangedInterface]
    public class JegyzetViewModel
    {
        public List<Jegyzet> Jegyzetek { get; set; } = new List<Jegyzet>();
        public Jegyzet AktualisJegyzet { get; set; }

        public ICommand DeleteCommand { get; set; }

        public JegyzetViewModel()
        {
            GetJegyzetek();
            DeleteCommand = new Command(async () =>
            {
                var result = await Application.Current.MainPage.DisplayAlert("Törlés","Biztosan törli?","Igen","Nem");
                if (result)
                {
                    App.JegyzetRepo.DeleteItem(AktualisJegyzet);
                    await Application.Current.MainPage.DisplayAlert("Törlés",App.JegyzetRepo.StatusMsg,"Ok");
                    GetJegyzetek();
                }
            });
        }

        public void GetJegyzetek()
        {
            Jegyzetek = App.JegyzetRepo.GetItems();
        }

    }
}

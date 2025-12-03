

using MauiJegyzet13c12025.mvvm.model;
using MauiJegyzet13c12025.mvvm.viewmodel;

namespace MauiJegyzet13c12025.mvvm.view;

public partial class JegyzetInput : ContentPage
{
	bool modosit = false;
	public JegyzetInput()
	{
		InitializeComponent();
	}

    public JegyzetInput(bool modosit,JegyzetViewModel vm)
    {
        InitializeComponent();
        this.modosit = modosit;
        BindingContext = vm;
    }

    private async void buttonInput_Clicked(object sender, EventArgs e)
    {
        var vm=BindingContext as JegyzetViewModel;

        if (modosit)
        {
            labelCim.Text = "Jegyzet módosítása";
            var result = await DisplayAlert("Módosítás","Biztosan módosítja?","Igen","Nem");
            if (result)
            {
                App.JegyzetRepo.UpdateItem(vm.AktualisJegyzet);
                await DisplayAlert("Módosítás",App.JegyzetRepo.StatusMsg,"Ok");
                vm.GetJegyzetek();
            }

        } else
        {
            var ujJegyzet = new Jegyzet { Cim=entryCim.Text,Szoveg=entrySzoveg.Text};
            App.JegyzetRepo.NewItem(ujJegyzet);
            await DisplayAlert("Új jegyzet", App.JegyzetRepo.StatusMsg, "Ok");
            vm.GetJegyzetek();
        }
    }
}
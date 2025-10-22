using MauiMvvm13c1.Mvvm.ViewModel;

namespace MauiMvvm13c1.Mvvm.View;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		BindingContext = new PageViewModel();
	}

    private void buttonTovabb_Clicked(object sender, EventArgs e)
    {
		var vm=BindingContext as PageViewModel;
		Navigation.PushAsync(new MiddlePage { BindingContext=vm });
    }
}
namespace MauiMvvm13c1.Mvvm.View;

public partial class EndPage : ContentPage
{
	public EndPage()
	{
		InitializeComponent();
	}

 
    private void buttonVissza_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

 
    private void buttonToRoot_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}
namespace MauiNavigacio.mvvm.view;

public partial class MiddlePage : ContentPage
{
	public MiddlePage()
	{
		InitializeComponent();
	}

    private void buttonVissza_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void buttonTovabb_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EndPage());
    }
}
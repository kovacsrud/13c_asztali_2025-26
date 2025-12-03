using MauiJegyzet13c12025.mvvm.viewmodel;

namespace MauiJegyzet13c12025.mvvm.view;

public partial class JegyzetView : ContentPage
{
	public JegyzetView()
	{
		InitializeComponent();
        BindingContext = new JegyzetViewModel();
	}

    private void buttonUj_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonModosit_Clicked(object sender, EventArgs e)
    {

    }

    private void buttonTorol_Clicked(object sender, EventArgs e)
    {

    }
}
namespace MauiStart;

public partial class SzamolasPage : ContentPage
{
	public SzamolasPage()
	{
		InitializeComponent();
	}

    private void buttonSzamol_Clicked(object sender, EventArgs e)
    {
		try
		{
            var sebessegKmh = Convert.ToInt32(entrySebessegKmh.Text);
            labelEredmeny.Text = Convert.ToString((double)sebessegKmh / 3.6);
        }
		catch (Exception ex)
		{
			DisplayAlert("Hiba",ex.Message,"Ok");			
		}
		
    }
}
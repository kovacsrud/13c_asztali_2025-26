using MauiRandomuser13c12025.Model;
using System.Text.Json;

namespace MauiRandomuser13c12025.Views;

public partial class ListPage : ContentPage
{

	HttpClient client;
	JsonSerializerOptions serializerOptions;
	string baseurl = "https://randomuser.me/api";

	public ListPage()
	{
		InitializeComponent();
		client = new HttpClient();
		serializerOptions = new JsonSerializerOptions { WriteIndented=true };
	}

    private async void buttonLetolt_Clicked(object sender, EventArgs e)
    {
		var url = $"{baseurl}/?results=50";

        if (Connectivity.Current.NetworkAccess==NetworkAccess.Internet)
        {
			//lekérjük az adatokat
			try
			{
				var response= await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					using (var responseStream=await response.Content.ReadAsStreamAsync())
					{
						var data = await JsonSerializer.DeserializeAsync<RandomUsers>(responseStream, serializerOptions);
						collectionUsers.ItemsSource = data.results;
					}
				} else
				{
					collectionUsers.EmptyView = "No data";
				}
			}
			catch (Exception ex)
			{
				DisplayAlert("Hiba", ex.Message, "Ok");
			}
            
        } else
		{
			collectionUsers.EmptyView = "Nincs internet kapcsolat!";
		}

    }

    private void collectionUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var selectedUser=collectionUsers.SelectedItem as Result;
		Navigation.PushAsync(new DetailPage { BindingContext=selectedUser });
    }
}
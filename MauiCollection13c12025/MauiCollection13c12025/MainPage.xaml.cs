
using System.Collections.ObjectModel;

namespace MauiCollection13c12025
{
    public partial class MainPage : ContentPage
    {
       ObservableCollection<Hegy> Hegyek= new ObservableCollection<Hegy>();        
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
            BindingContext = Hegyek;
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("hegyekMo.txt");
            using var reader = new StreamReader(stream);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                Hegyek.Add(new Hegy(reader.ReadLine()));
            }
        }
        
    }

}

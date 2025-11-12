using MauiRandomuser13c12025.Views;

namespace MauiRandomuser13c12025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }
    }
}

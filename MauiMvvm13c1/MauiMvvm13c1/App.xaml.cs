using MauiMvvm13c1.Mvvm.View;

namespace MauiMvvm13c1
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

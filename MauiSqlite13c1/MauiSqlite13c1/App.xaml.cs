using MauiSqlite13c1.Mvvm.View;

namespace MauiSqlite13c1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new JegyzetView();
        }
    }
}

using MauiJegyzet13c12025.mvvm.model;
using MauiJegyzet13c12025.mvvm.view;
using MauiJegyzet13c12025.repository;

namespace MauiJegyzet13c12025
{
    public partial class App : Application
    {
        public static BaseRepository<Jegyzet> JegyzetRepo { get; private set; }
        public App(BaseRepository<Jegyzet> repo)
        {
            InitializeComponent();
            JegyzetRepo = repo;
            MainPage = new NavigationPage(new JegyzetView());
        }
    }
}

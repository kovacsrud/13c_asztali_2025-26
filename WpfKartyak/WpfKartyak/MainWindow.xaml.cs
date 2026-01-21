using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfKartyak.mvvm.viewmodel;

namespace WpfKartyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new KartyaViewModel();
            DataContext= vm;
        }

        private void minGomb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }

        private void maxGomb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState==WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            } else
            {
                WindowState = WindowState.Maximized;
            }

        }

        private void closeGomb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void rectHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void buttonPiros_Click(object sender, RoutedEventArgs e)
        {
            var vm=DataContext as KartyaViewModel;
            vm.SelectedKartya = vm.GetRandomKartya();
        }

        private void buttonFekete_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as KartyaViewModel;
            vm.SelectedKartya = vm.GetRandomKartya();
        }
    }
}
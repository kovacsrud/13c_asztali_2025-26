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
using WpfMvvmKutyakDb.Mvvm.View;
using WpfMvvmKutyakDb.Mvvm.ViewModel;

namespace WpfMvvmKutyakDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new RendeloViewModel();
        }

        private void menuitemKutyanevek_Click(object sender, RoutedEventArgs e)
        {
            ViewKutyanevek kutyanevek=new ViewKutyanevek();
            kutyanevek.DataContext = DataContext as RendeloViewModel;
            kutyanevek.ShowDialog();
        }

        private void menuitemRendelesek_Click(object sender, RoutedEventArgs e)
        {
            ViewRendelesek rendelesek=new ViewRendelesek();
            rendelesek.DataContext = DataContext as RendeloViewModel;
            rendelesek.ShowDialog();
        }
    }
}
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
using WpfKutyakEF.mvvm.view;
using WpfKutyakEF.mvvm.viewmodel;

namespace WpfKutyakEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new KutyaViewModel();
        }

        private void menuitemRendeles_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as KutyaViewModel;
            RendelesView rendelesek = new RendelesView { DataContext=vm};
            rendelesek.ShowDialog();

        }

        private void menuitemKutyanevek_Click(object sender, RoutedEventArgs e)
        {
            var vm=DataContext as KutyaViewModel;
            KutyanevView kutyanevek = new KutyanevView { DataContext=vm };
            kutyanevek.ShowDialog();
        }

        private void menuitemKutyafajtak_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as KutyaViewModel;
            KutyafajtaView kutyafajtak = new KutyafajtaView { DataContext = vm };
            kutyafajtak.ShowDialog();
        }
    }
}
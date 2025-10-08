using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMvvmKutyakDb.Mvvm.ViewModel;

namespace WpfMvvmKutyakDb.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ViewRendelesek.xaml
    /// </summary>
    public partial class ViewRendelesek : Window
    {
        public ViewRendelesek()
        {
            InitializeComponent();
        }

        private void buttonUjRendeles_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RendeloViewModel;
            ViewRendelesekInput rendelesInput = new ViewRendelesekInput(vm);
            rendelesInput.ShowDialog();
        }

        private void buttonTorolRendeles_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

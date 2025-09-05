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
using WpfMobilok.Model;

namespace WpfMobilok.Views
{
    /// <summary>
    /// Interaction logic for GyartoView.xaml
    /// </summary>
    public partial class GyartoView : Window
    {
        public List<Mobil> Mobilok { get; set; } = new List<Mobil>();
        public GyartoView(List<Mobil> mobilok)
        {
            InitializeComponent();
            Mobilok = mobilok;
            datagridMobilok.ItemsSource = mobilok;
            var gyartoLista=Mobilok.OrderBy(x=>x.Gyarto).Select(x=>x.Gyarto).Distinct().ToList();
            comboGyarto.ItemsSource = gyartoLista;
        }

        private void comboGyarto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztottGyarto=comboGyarto.SelectedItem as string;

            var result = Mobilok.FindAll(x => x.Gyarto == kivalasztottGyarto);

            datagridMobilok.ItemsSource= result;
        }

        private void buttonVissza_Click(object sender, RoutedEventArgs e)
        {
            datagridMobilok.ItemsSource = Mobilok;
        }
    }
}

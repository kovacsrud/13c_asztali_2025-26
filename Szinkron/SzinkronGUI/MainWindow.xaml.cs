using Microsoft.Win32;
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
using Szinkron;

namespace SzinkronGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szinkronhang> szinkronhangok=new List<Szinkronhang>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuitemMegnyitas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            dialog.Filter = ".json|*.json";

            if (dialog.ShowDialog()==true)
            {
                try
                {
                    szinkronhangok = SzinkronBetolt.LoadFromJson(dialog.FileName);
                    listboxSzineszek.ItemsSource = szinkronhangok.Select(x => x.Szinesz).ToList();
                    
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
            }

        }

        private void menuitemKilepes_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void listboxSzineszek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSzinesz=listboxSzineszek.SelectedItem as string;

            var szinkronAdat = szinkronhangok.Find(x=>x.Szinesz==selectedSzinesz);

            if (szinkronAdat != null) {
                textboxSzineszneve.Text = szinkronAdat.Szinesz;
                textboxSzerep.Text=szinkronAdat.Szerep;
                textboxFilmcime.Text = szinkronAdat.Film.Cim;
                textboxMagyarhangja.Text = szinkronAdat.Magyarhang;
            }
            textblockKorhatarosDb.Text = $"0 db";

        }

        private void buttonKorhataros_Click(object sender, RoutedEventArgs e)
        {
            var selectedSzinesz = listboxSzineszek.SelectedItem as string;

            if (selectedSzinesz != null) { 
                var korhatarosDB=szinkronhangok.FindAll(x=>x.Szinesz== selectedSzinesz && x.Film.Korhataros==true).Count();

                textblockKorhatarosDb.Text = $"{korhatarosDB} db";

            } else
            {
                MessageBox.Show("Nincs kiválasztva színész");
            }
        }
    }
}
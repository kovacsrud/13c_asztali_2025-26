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
using WpfMobilok.Model;
using WpfMobilok.Views;

namespace WpfMobilok;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Mobil> Mobilok { get; set; } = new List<Mobil>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void menuItemKilepes_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
        
    }

    private void menuitemNevjegy_Click(object sender, RoutedEventArgs e)
    {
        NevjegyView nevjegyView = new NevjegyView();
        nevjegyView.ShowDialog();
    }

    private void menuitemMegnyitas_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = ".csv fájlok|*.csv|minden fájl|*.*";

        if (dialog.ShowDialog()==true)
        {
            try
            {
                Mobilok = new MobilLista(dialog.FileName, ';').Mobilok;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
    }

    private void menuitemGyarto_Click(object sender, RoutedEventArgs e)
    {
        GyartoView gyarto = new GyartoView(Mobilok);
        gyarto.ShowDialog();
    }
}
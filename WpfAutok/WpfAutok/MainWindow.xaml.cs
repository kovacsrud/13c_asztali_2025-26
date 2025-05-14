using Microsoft.Win32;
using System.IO;
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
using WpfAutok.model;

namespace WpfAutok;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    List<Auto> Autok=new List<Auto>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void buttonBetoltes_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = ".csv|*.csv|minden fájl|*.*";

        if (dialog.ShowDialog() == true) {
            try
            {
                Autolista autolista = new Autolista(dialog.FileName,';');
                datagridAutok.ItemsSource = autolista.Autok;
                Autok=autolista.Autok;
                var markak=Autok.Select(x=>x.Marka).Distinct();
                comboMarka.ItemsSource = markak;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!");                
            }
        }
    }

    private void buttonKeres_Click(object sender, RoutedEventArgs e)
    {
        //Pontos egyezés vizsgálata
        //var eredmeny=Autok.FindAll(x=>x.Marka.ToLower()==textboxMarka.Text.ToLower());
        //Tartalmazás vizsgálata
        var eredmeny = Autok.FindAll(x => x.Marka.ToLower().Contains(textboxMarka.Text.ToLower()));
        if (eredmeny.Count < 1)
        {
            MessageBox.Show("Nincs ilyen márka!");
        } else
        {
            datagridAutok.ItemsSource= eredmeny;
        }
    }

    private void buttonVissza_Click(object sender, RoutedEventArgs e)
    {
        datagridAutok.ItemsSource = Autok;
    }

    private void comboMarka_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var eredmeny=Autok.FindAll(x=>x.Marka==comboMarka.SelectedItem.ToString());
        datagridAutok.ItemsSource=eredmeny;
    }

    private void buttonMentes_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = ".csv|*.csv|.txt|*.txt|minden fájl|*.*";
        if (dialog.ShowDialog()==true)
        {
            try
            {
                FileStream file = new FileStream(dialog.FileName, FileMode.Create);
                using (StreamWriter writer=new StreamWriter(file,Encoding.UTF8))
                {
                    writer.WriteLine($"Id;Marka;Tipus;Evjarat;Uzem;Hengerurtartalom;Teljesitmeny;FutottKm;Ar");

                    foreach (var i in datagridAutok.ItemsSource as List<Auto>)
                    {
                        writer.WriteLine($"{i.Id};{i.Marka};{i.Tipus};{i.Evjarat};{i.Uzem};{i.Hengerurtartalom};{i.Teljesitmeny};{i.FutottKm};{i.Ar}");
                    }
                    MessageBox.Show("Fájlba írás kész!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!");                
            }
        }
    }
}
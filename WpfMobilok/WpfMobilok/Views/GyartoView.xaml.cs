using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void buttonKeres_Click(object sender, RoutedEventArgs e)
        {
            var keresettModell = textboxKeresettModell.Text;
            var result=Mobilok.FindAll(x=>x.Modell.ToLower().Contains(keresettModell.ToLower()));

            if (result.Count > 0)
            {
                datagridMobilok.ItemsSource = result;
            } else
            {
                datagridMobilok.ItemsSource= null;
                MessageBox.Show("Nincs ilyen modell!");
                datagridMobilok.ItemsSource = Mobilok;
            }
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog=new SaveFileDialog();
            dialog.Filter = ".csv fájlok|*.csv|.txt fájlok|*.txt";
            if (dialog.ShowDialog()==true)
            {
                try
                {
                    FileStream fajl = new FileStream(dialog.FileName, FileMode.Create);
                                        

                    using (StreamWriter writer = new StreamWriter(fajl, Encoding.UTF8))
                    {
                        writer.WriteLine("Id;Nev;Gyarto;Modell;Oprendszer;Datum");

                        foreach (var i in datagridMobilok.ItemsSource as List<Mobil>)
                        {
                            writer.WriteLine($"{i.Id};{i.Nev};{i.Gyarto};{i.Modell};{i.Oprendszer};{i.Datum}");
                        }
                    }
                                      
                    
                    
                    MessageBox.Show("Fájlba írás kész!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

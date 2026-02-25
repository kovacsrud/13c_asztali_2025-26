using Maratonvalto;
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

namespace MaratonvaltoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Eredmeny> Eredmenyek { get; set; }=new List<Eredmeny>();
        public Eredmeny KivalasztottEredmeny { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void menuitemMegnyitas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();

            if (dialog.ShowDialog()==true)
            {
                try
                {
                    Eredmenyek = LoadData.LoadFromCsv(dialog.FileName);
                    listboxFutok.ItemsSource=Eredmenyek.OrderBy(x=>x.Versenyzo.Fnev).Select(x=>x.Versenyzo.Fnev).Distinct().ToList();   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
            }
         }

        private void listboxFutok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kivalasztottNev = listboxFutok.SelectedItem as string;
            var kivalasztott=Eredmenyek.Find(x=>x.Versenyzo.Fnev==kivalasztottNev);

            KivalasztottEredmeny = kivalasztott;

            if (kivalasztott != null)
            {
                textboxNev.Text = kivalasztott.Versenyzo.Fnev;
                textboxRajtszam.Text = kivalasztott.Versenyzo.Fid.ToString();
                textboxSzulEvHo.Text = $"{kivalasztott.Versenyzo.Szulev} - {kivalasztott.Versenyzo.Szulho}";
                textboxKor.Text=kivalasztott.Kor.ToString();
                textboxIdo.Text=kivalasztott.Ido.ToString();
                textboxCsapatSzam.Text=kivalasztott.Versenyzo.Csapat.ToString();
            }

        }

        private void buttonCsapattarsak_Click(object sender, RoutedEventArgs e)
        {
            var csapattarsak = Eredmenyek.FindAll(x=>x.Versenyzo.Csapat==KivalasztottEredmeny.Versenyzo.Csapat);

            if (KivalasztottEredmeny!=null)
            {
                foreach (var i in csapattarsak)
                {
                    textblockCsapatTagok.Text += $"{i.Versenyzo.Csapat} - {i.Versenyzo.Fnev} /n";
                }
            } else
            {
                MessageBox.Show("Nincs versenyző kiválasztva!");
            }


            
        }
    }
}
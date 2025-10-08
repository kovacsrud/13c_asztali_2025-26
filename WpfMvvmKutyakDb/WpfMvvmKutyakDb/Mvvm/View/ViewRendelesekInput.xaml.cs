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
using WpfMvvmKutyakDb.Mvvm.Model;
using WpfMvvmKutyakDb.Mvvm.ViewModel;

namespace WpfMvvmKutyakDb.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ViewRendelesekInput.xaml
    /// </summary>
    public partial class ViewRendelesekInput : Window
    {
        bool modosit=false;
        RendeloViewModel vm;
        public ViewRendelesekInput(RendeloViewModel vm)
        {
            InitializeComponent();
            this.vm=vm;
            DataContext = vm;
            comboKutyafajtak.SelectedIndex = 0;
            comboKutyanevek.SelectedIndex = 0;
        }

        public ViewRendelesekInput(bool modosit,RendeloViewModel vm)
        {
            InitializeComponent();
            this.modosit=modosit;
            this.vm=vm;
            DataContext = vm;
            textblockCim.Text = "Rendelési adat módosítása";
            Title = textblockCim.Text;
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            if (textboxEletkor.Text.Length>0 && textboxUtolsoEll.Text.Length==10) {
                if (modosit) {

                } else
                {
                    try
                    {
                        Rendeles rendeles = new Rendeles
                        {
                            FajtaId = (int)comboKutyafajtak.SelectedValue,
                            NevId=(int)comboKutyanevek.SelectedValue,
                            Eletkor=Convert.ToInt32(textboxEletkor.Text),
                            UtolsoEll=textboxUtolsoEll.Text
                        };
                        vm.UjRendeles(rendeles);
                        vm.GetRendelesek();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Az életkornál számot kell megadni!");                        
                    }
                }

            } else
            {
                MessageBox.Show("Helyes adatokat adjon meg!");
            }

        }
    }
}

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
    /// Interaction logic for ViewKutyanevekInput.xaml
    /// </summary>
    public partial class ViewKutyanevekInput : Window
    {
        bool modosit = false;
        RendeloViewModel vm;
        public ViewKutyanevekInput(RendeloViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            vm.SelectedKutyanev.KutyaNev = "";
        }

        public ViewKutyanevekInput(bool modosit,RendeloViewModel vm)
        {
            InitializeComponent();
            this.modosit = modosit;
            textblockCim.Text = "Kutyanév módosítása";
            Title = "Kutyanév módosítása";
            this.vm = vm;
            DataContext= vm;
        }

        private void buttonRogzit_Click(object sender, RoutedEventArgs e)
        {
            if (textboxKutyanev.Text.Length>1)
            {
                if (modosit)
                {
                    vm.ModositKutyanev(vm.SelectedKutyanev);
                    vm.GetKutyanevek();
                }
                else
                {
                    
                    Kutyanev ujkutyanev = new Kutyanev { KutyaNev = textboxKutyanev.Text };
                    vm.UjKutyanev(ujkutyanev);
                    vm.GetKutyanevek();
                }
            }
            else
            {
                MessageBox.Show("Adjon meg legalább két karaktert!");
            }
        }
    }
}

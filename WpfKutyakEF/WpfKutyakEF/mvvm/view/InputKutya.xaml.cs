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
using WpfKutyakEF.mvvm.model;
using WpfKutyakEF.mvvm.viewmodel;

namespace WpfKutyakEF.mvvm.view
{
    /// <summary>
    /// Interaction logic for InputKutya.xaml
    /// </summary>
    public partial class InputKutya : Window
    {
        bool modosit=false;
        public Kutya AktKutya { get; set; } = new Kutya { Nevid = 1,Fajtaid=1 };
        public KutyaViewModel VM { get; set; }
        public InputKutya(KutyaViewModel vm,bool modosit=false)
        {
            InitializeComponent();
            this.Title = "Új adat felvitele";
            DataContext = this;
            if (modosit)
            {
                AktKutya = VM.SelectedKutya;
                this.Title = "Rendelési adat módosítása";
            }
        }

        private void buttonMentes_Click(object sender, RoutedEventArgs e)
        {
            if (modosit)
            {
                VM.DbMentes();
            } else
            {
                VM.Kutyak.Add(AktKutya);
                VM.DbMentes();
            }
        }
    }
}

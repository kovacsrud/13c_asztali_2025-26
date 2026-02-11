using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKutyakEF.mvvm.model;
using PropertyChanged;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace WpfKutyakEF.mvvm.viewmodel
{
    [AddINotifyPropertyChangedInterface]
    public class KutyaViewModel
    {
        KutyakGoodUniqueContext context;
        public ObservableCollection<Kutya> Kutyak { get; set; }
        public ObservableCollection<Kutyanevek> Kutyanevek { get; set; }
        public ObservableCollection<Kutyafajtak> Kutyafajtak { get; set; }

        public Kutya SelectedKutya { get; set; }

        public KutyaViewModel()
        {
            context= new KutyakGoodUniqueContext();
            context.Kutyas.Load();
            context.Kutyaneveks.Load();
            context.Kutyafajtaks.Load();

            Kutyak = context.Kutyas.Local.ToObservableCollection();
            Kutyafajtak=context.Kutyafajtaks.Local.ToObservableCollection();
            Kutyanevek=context.Kutyaneveks.Local.ToObservableCollection();

        }

        public void DbMentes()
        {
            try
            {
                var result = context.SaveChanges();
                if (result>0)
                {
                    MessageBox.Show("Adatok mentve!");
                } else
                {
                    MessageBox.Show("Nem változtak az adatok.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

    }
}

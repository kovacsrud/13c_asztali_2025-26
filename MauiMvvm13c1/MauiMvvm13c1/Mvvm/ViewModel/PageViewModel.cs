using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiMvvm13c1.Mvvm.Model;
using PropertyChanged;

namespace MauiMvvm13c1.Mvvm.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class PageViewModel
    {
        public Nev Nev { get; set; }=new Nev();
    }
}

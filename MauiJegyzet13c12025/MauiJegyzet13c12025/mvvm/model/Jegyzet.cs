using MauiJegyzet13c12025.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace MauiJegyzet13c12025.mvvm.model
{
    [System.ComponentModel.DataAnnotations.Schema.Table("jegyzetek")]
    public class Jegyzet:TableData
    {
        [NotNull]
        public string Cim { get; set; }
        [NotNull]
        public string Szoveg { get; set; }
        [NotNull]
        public DateTime Datum { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiJegyzet13c12025.interfaces
{
    public class TableData
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Crama_Dacia_Xamarin.Forms.Models
{
    public class ListaVinuri
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        public DateTime Data { get; set; }
    }
}

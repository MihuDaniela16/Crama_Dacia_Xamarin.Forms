using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Crama_Dacia_Xamarin.Forms.Models
{
    public class ListaProdus
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ListaVinuri))]
        public int ListaVinuriID { get; set; }
        public int ProdusID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Crama_Dacia_Xamarin.Forms.Models
{
    public class Produs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<ListaProdus> ListaProduse { get; set; }
    }
}

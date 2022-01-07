using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crama_Dacia_Xamarin.Forms.Data;
using System.IO;

namespace Crama_Dacia_Xamarin.Forms
{
    public partial class App : Application
    {
        static ListaVinuriDatabase database;
        public static ListaVinuriDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ListaVinuriDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ListaVinuri.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PaginaIntrare());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

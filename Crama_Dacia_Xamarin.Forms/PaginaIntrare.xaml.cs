using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crama_Dacia_Xamarin.Forms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;

namespace Crama_Dacia_Xamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaIntrare : ContentPage
    {
        public PaginaIntrare()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetListeVinuriAsync();
        }
        async void OnListaVinuriAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPagina
            {
                BindingContext = new ListaVinuri()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListaPagina
                {
                    BindingContext = e.SelectedItem as ListaVinuri
                });
            }
        }
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crama_Dacia_Xamarin.Forms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crama_Dacia_Xamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaProdus : ContentPage
    {
        ListaVinuri vl;
        public PaginaProdus(ListaVinuri vlista)
        {
            InitializeComponent();
            vl = vlista;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var produs = (Produs)BindingContext;
            await App.Database.SaveProdusAsync(produs);
            listView.ItemsSource = await App.Database.GetProduseAsync();
            
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var produs = (Produs)BindingContext;
            await App.Database.DeleteProdusAsync(produs);
            listView.ItemsSource = await App.Database.GetProduseAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProduseAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Produs p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Produs;
                var lp = new ListaProdus()
                {
                    ListaVinuriID = vl.ID,
                    ProdusID = p.ID
                };
                await App.Database.SaveListaProdusAsync(lp);
                p.ListaProduse = new List<ListaProdus> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crama_Dacia_Xamarin.Forms.Models;

namespace Crama_Dacia_Xamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPagina : ContentPage
    {
        public ListaPagina()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (ListaVinuri)BindingContext;
            slist.Data = DateTime.UtcNow;
            await App.Database.SaveListaVinuriAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (ListaVinuri)BindingContext;
            await App.Database.DeleteShopListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaProdus((ListaVinuri)
           this.BindingContext)
            {
                BindingContext = new Produs()
            });

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vinl = (ListaVinuri)BindingContext;

            listView.ItemsSource = await App.Database.GetListaProduseAsync(vinl.ID);
        }
    }

    
}
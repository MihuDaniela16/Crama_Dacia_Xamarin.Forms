using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Crama_Dacia_Xamarin.Forms.Models;

namespace Crama_Dacia_Xamarin.Forms.Data
{
    public class ListaVinuriDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ListaVinuriDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaVinuri>().Wait();
            _database.CreateTableAsync<Produs>().Wait();
            _database.CreateTableAsync<ListaProdus>().Wait();
        }
        public Task<int> SaveProdusAsync(Produs produs)
        {
            if (produs.ID != 0)
            {
                return _database.UpdateAsync(produs);
            }
            else
            {
                return _database.InsertAsync(produs);
            }
        }
        public Task<int> DeleteProdusAsync(Produs produs)
        {
            return _database.DeleteAsync(produs);
        }
        public Task<List<Produs>> GetProduseAsync()
        {
            return _database.Table<Produs>().ToListAsync();
        }
    
    public Task<List<ListaVinuri>> GetListeVinuriAsync()
        {
            return _database.Table<ListaVinuri>().ToListAsync();
        }
        public Task<ListaVinuri> GetListaVinuriAsync(int id)
        {
            return _database.Table<ListaVinuri>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveListaVinuriAsync(ListaVinuri vlista)
        {
            if (vlista.ID != 0)
            {
                return _database.UpdateAsync(vlista);
            }
            else
            {
                return _database.InsertAsync(vlista);
            }
        }
        internal Task SaveListaProdusAsync(ListaProdus lp)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteShopListAsync(ListaVinuri vlista)
        {
            return _database.DeleteAsync(vlista);
        }
        public Task<List<Produs>> GetListaProduseAsync(int listavinuriid)
        {
            return _database.QueryAsync<Produs>(
            "select P.ID, P.Descriere from Produs P"
            + " inner join ListaProdus LP"
            + " on P.ID = LP.ProdusID where LP.ListaVinuriID = ?",
            listavinuriid);
        }
    }
}

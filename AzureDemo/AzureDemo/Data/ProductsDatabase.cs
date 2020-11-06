using AzureDemo.Constants;
using AzureDemo.Helpers;
using AzureDemo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace AzureDemo.Data
//{
//    public class ProductsDatabase
//    {
//        readonly SQLiteAsyncConnection dataBase;
//        public ProductsDatabase()
//        {
//            dataBase = new SQLiteAsyncConnection(ConnectionConstants.DataBasePath, ConnectionConstants.Flags);
//            dataBase.CreateTableAsync<Product>().Wait();
//        }

//        public async Task<List<Product>> GetProductsAsync()
//        {
//            var data = await dataBase.Table<Product>().ToListAsync();
//            return data;
//        }

//        //public async Task<ObservableCollection<>>

//        public async Task<ObservableCollection<Grouping<string,Product>>> GetItemsGroupedAsync()
//        {
//            IList<Product> products = await App.ProductDatabase.GetProductsAsync();
//            IEnumerable<Grouping<string, Product>> sorted =
//                new Grouping<string, Product>[0];
//            if (products!=null)
//            {
//                sorted = from p in products
//                         orderby p.Name
//                         group p by p.Name[0].ToString()
//                         into theGroup
//                         select new Grouping<string, Product>(theGroup.Key, theGroup);
//            }

//            return new ObservableCollection<Grouping<string, Product>>(sorted);
//        }



//        public async Task<Product> GetProduct(int productId)
//        {
//            var product = await dataBase.Table<Product>().Where(p => p.Id == productId).FirstOrDefaultAsync();
//            return product;
//        }

//        public Task<int> SaveItemAsync (Product item)
//        {
//            if (item.Id != 0)
//            {
//                return dataBase.UpdateAsync(item);
//            }
//            else
//            {
//                return dataBase.InsertAsync(item);
//            }
//        }

//        public Task<int> DeleteAsync (Product item)
//        {
//            return dataBase.DeleteAsync(item);
//        }


//    }
//}

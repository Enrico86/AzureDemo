using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureDemo.Helpers;
using AzureDemo.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace AzureDemo.Data
{
    public class ProductsManager
    {
        static ProductsManager defaultInstance =
            new ProductsManager();
        private IMobileServiceClient client;
        private IMobileServiceTable<Product> productsTable;
        private ProductsManager()
        {
            client = new MobileServiceClient("https://xamproductsdemo.azurewebsites.net");
            productsTable = client.GetTable<Product>();
        }

        public static ProductsManager DefaultManager 
        {
            get { return defaultInstance; }
            private set { defaultInstance = value; } 
        }

        public async Task<ObservableCollection<Product>> GetProductsAsync()
        {
            try
            {
                IEnumerable<Product> items = await productsTable.ToEnumerableAsync();
                return new ObservableCollection<Product>(items);
            }
            catch(MobileServiceInvalidOperationException mobileExeption)
            {
                Debug.WriteLine($"Excpeción: {mobileExeption.Message}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Excpeción: {ex.Message}");
            }
            return null;
        }

        public async Task<ObservableCollection<Grouping<string, Product>>> GetItemsGroupedAsync()
        {
            var products = await GetProductsAsync();
            IEnumerable<Grouping<string, Product>> sorted =
                new Grouping<string, Product>[0];
            if (products!=null)
            {
                sorted = from p in products
                         orderby p.Name
                         group p by p.Name[0].ToString()
                         into theGroup
                         select new Grouping<string, Product>(theGroup.Key, theGroup);
            }
            return new ObservableCollection<Grouping<string, Product>>(sorted);
        }

        public async Task<Product> GetProduct(string productId)
        {
            var product = await productsTable.Where(p => p.Id == productId).ToListAsync();
            return product.FirstOrDefault();
        }

        public Task SaveItemAsync(Product item)
        {
            try
            {
                if (item.Id != null)
                {
                    return productsTable.UpdateAsync(item);
                }
                else
                {
                    return productsTable.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción: {ex.Message}");
            }
            return null;
        }

        public Task DeleteAsync(Product item)
        {
            try
            {
                return productsTable.DeleteAsync(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción: {ex.Message}");
            }
            return null;
        }
    }
}

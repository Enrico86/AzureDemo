using AzureDemo.Helpers;
using AzureDemo.Models;
using AzureDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureDemo.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<Grouping<string, Product>> Products { get; set; }
        public ICommand AddProductCommand { get; set; }
        public Product CurrentProduct { get; set; }
        public ICommand ItemTappedCommand { get; set; }

        INavigation navigation;
        public ProductsViewModel(INavigation nav)
        {
            navigation = nav;
            Task.Run(async () => Products = await App.ProductDatabase.GetItemsGroupedAsync()).Wait();
            AddProductCommand = new Command(async() => await GoToProductDetailsPage());
            ItemTappedCommand = new Command(async () => await GoToProductDetailsPage(CurrentProduct));

        }

        private async Task GoToProductDetailsPage(Product currentProduct = null)
        {
            if (currentProduct == null)
            {
                await navigation.PushAsync(new ProductDetailsPage());
            }
            else await navigation.PushAsync(new ProductDetailsPage(currentProduct));
        }
    }
}

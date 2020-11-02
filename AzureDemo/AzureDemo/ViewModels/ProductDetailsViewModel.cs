using AzureDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureDemo.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product CurrentProduct { get; set; }
        public ICommand SaveCommand { get; set; }
        INavigation navigation;
        public ProductDetailsViewModel(INavigation nav, Product product = null)
        {
            navigation = nav;
            if (product == null)
            {
                CurrentProduct = new Product();
            }
            else CurrentProduct = product;
            SaveCommand = new Command(async () => await SaveProduct());
        }

        private async Task SaveProduct()
        {
            await App.ProductDatabase.SaveItemAsync(CurrentProduct);
            await navigation.PopAsync();
        }
    }
}

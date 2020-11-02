using AzureDemo.Models;
using AzureDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        ProductDetailsViewModel vm { get; set; }
        public ProductDetailsPage(Product product = null)
        {
            InitializeComponent();
            if (product == null)
            {
                vm = new ProductDetailsViewModel(Navigation);
            }
            else vm = new ProductDetailsViewModel(Navigation, product);
             
            BindingContext = vm;
        }
    }
}
using AzureDemo.Data;
using AzureDemo.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureDemo
{
    public partial class App : Application
    {
        private static ProductsDatabase _productDatabase;

        public static ProductsDatabase ProductDatabase
        {
            get 
            {
                if (_productDatabase==null)
                {
                    try
                    {
                        _productDatabase = new ProductsDatabase();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                return _productDatabase; 
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProductsPage());
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

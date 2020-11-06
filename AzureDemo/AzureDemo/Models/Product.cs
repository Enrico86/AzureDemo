//using SQLite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDemo.Models
{
    //[DataTable("Products")]
    public class Product
    {
        //[PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("measures")]
        public string Measures { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}

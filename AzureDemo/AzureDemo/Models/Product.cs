using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDemo.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string Measures { get; set; }
        public decimal Price { get; set; }
    }
}

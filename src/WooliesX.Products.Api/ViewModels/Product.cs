using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WooliesX.Products.Api.ViewModels
{
    public class Product
    {
        public Product(string name, decimal price, decimal quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}

using System.Collections.Generic;

namespace WooliesX.Products.Domain.Entities
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

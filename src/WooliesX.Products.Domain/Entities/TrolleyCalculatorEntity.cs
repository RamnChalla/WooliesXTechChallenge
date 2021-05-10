using System.Collections.Generic;

namespace WooliesX.Products.Domain.Entities
{
    public class TrolleyCalculatorEntity
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Special> Specials { get; set; }
        public IEnumerable<ProductQuantity> Quantities { get; set; }
    }
}

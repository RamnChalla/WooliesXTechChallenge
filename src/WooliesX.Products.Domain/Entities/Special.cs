using System.Collections.Generic;

namespace WooliesX.Products.Domain.Entities
{
    public class Special
    {
        public List<ProductQuantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}

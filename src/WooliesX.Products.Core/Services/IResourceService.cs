using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    /// <summary>
    /// Retrieves the product data.
    /// </summary>
    public interface IResourceService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<List<ShopperHistory>> GetShopperHistoryAsync();       
        //public Task<decimal> GetTrolleyTotalAsync(TrolleyCalculatorEntity trolleyTotalQuery);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    public class PopularProductsService : IPopularProductsService
    {
        private readonly IResourceService _resourceApi;
        public PopularProductsService(IResourceService resourceApi)
        {
            _resourceApi = resourceApi;
        }

        public async Task<IEnumerable<ProductPopularity>> GetProductPopularityAsync()
        {
            var shoppingHistories = await _resourceApi.GetShopperHistoryAsync();
            var shopperHistoryProducts = shoppingHistories.SelectMany(s => s.Products).ToList();

            var orderedProducts = shopperHistoryProducts
                       .GroupBy(
                           p => p.Name,
                           p => p.Quantity,
                           (key, group) => new
                           {
                               Name = key,
                               Quantity = group.Sum(),
                               Price = shopperHistoryProducts.Find(l => l.Name == key).Price
                           }
                       )
                       .OrderByDescending(o => o.Quantity)
                       .Select(s => new Product { Name = s.Name, Price = s.Price })
                       .ToList();

            var productPopularity = new List<ProductPopularity>();
            for (int i = 0; i < orderedProducts.Count; i++)
            {
                var product = orderedProducts.ElementAt(i);
                productPopularity.Add(new ProductPopularity() { ProductName = product.Name, Rank = i });
            }

            return productPopularity;
        }
    }
}

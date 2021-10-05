using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Contants;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly IPopularProductsService _popularProductService;

        public OrderingService(IPopularProductsService popularProductService)
        {
            _popularProductService = popularProductService;
        }

        public async Task<IEnumerable<Product>> OrderProductsAsync(IEnumerable<Product> products, SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return products.OrderBy(p => p.Price);

                case SortOption.High:
                    return products.OrderByDescending(p => p.Price);

                case SortOption.Ascending:
                    return products.OrderBy(p => p.Name);

                case SortOption.Descending:
                    return products.OrderByDescending(p => p.Name);

                case SortOption.Recommended:
                    var productPopularity = await _popularProductService.GetProductPopularityAsync();             
                    return products.OrderBy(o => productPopularity.SingleOrDefault(p => p.ProductName == o.Name)?.Rank ?? int.MaxValue).ThenBy(o => o.Name);

                case SortOption.None:
                default:
                    break;
            }

            return products;
        }
    }
}

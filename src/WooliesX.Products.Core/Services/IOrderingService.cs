using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Contants;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    public interface IOrderingService
    {
        Task<IEnumerable<Product>> OrderProductsAsync(IEnumerable<Product> products, SortOption sortOption);

    }
}

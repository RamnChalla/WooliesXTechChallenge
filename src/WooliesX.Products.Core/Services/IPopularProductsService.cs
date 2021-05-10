using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Services
{
    public interface IPopularProductsService
    {
        Task<IEnumerable<ProductPopularity>> GetProductPopularityAsync();
    }
}

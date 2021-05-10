using MediatR;
using System.Collections.Generic;
using WooliesX.Products.Domain.Contants;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Queries
{
    public class GetProducts : IRequest<List<Product>>
    {
        public GetProducts(SortOption sortOption)
        {
            SortOption = sortOption;
        }
        public SortOption SortOption { get; set; }
    }
}

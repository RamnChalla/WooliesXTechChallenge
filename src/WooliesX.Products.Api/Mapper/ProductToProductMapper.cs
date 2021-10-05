using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Api.ViewModels;
using Entities = WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api.Mapper
{
    public class ProductToProductMapper : IMapper<List<Entities.Product>, List<Product>>
    {
        public void Map(List<Entities.Product> source, List<Product> destination)
        {
            if (source is null || source.Count == 0)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            source.ForEach(s => destination.Add(new Product(s.Name, s.Price, s.Quantity)));

        }

        void IMapper<List<Entities.Product>, List<Product>>.Map(Entities.User source, Entities.User destination)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api.Mapper
{
    public interface IMapper<in TSource, in TDestination>
    {
        /// <summary>
        /// Maps an object of type TSource to TDestination.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        void Map(TSource source, TDestination destination);
        void Map(User source, User destination);
    }
}

using MediatR;
using System.Collections.Generic;
using WooliesX.Products.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using WooliesX.Products.Core.Services;
using System.Linq;

namespace WooliesX.Products.Core.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProducts, List<Product>>
    {
        private readonly IResourceService _resourceApi;
        private readonly IOrderingService _productOrderingService;
      
        public GetProductsHandler(IResourceService resourceApi, IOrderingService productOrderingService)
        {
            _resourceApi = resourceApi;
            _productOrderingService = productOrderingService;
        }

        public async Task<List<Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {

            var products = await _resourceApi.GetProductsAsync();

            var orderedProducts = await _productOrderingService.OrderProductsAsync(products, request.SortOption);

            return orderedProducts.ToList();
        }
      
    }
}

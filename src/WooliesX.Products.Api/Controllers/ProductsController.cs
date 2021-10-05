using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Core.Queries;
using WooliesX.Products.Domain.Configuration;
using WooliesX.Products.Domain.Contants;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api.Controllers
{
    [Route("sort")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    [Produces("application/json")]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Gets the sorted product list.
        /// </summary>
        /// <param name="sortOption"></param>
        /// <returns>A 200 OK response containing the User or a 404 Not Found if a User with the specified unique
        /// identifier was not found.</returns>//"{sortOption}", 
        [HttpGet]
        [SwaggerOperation(Summary = "Get Sorted Products", OperationId = "GetProducts")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Product>>> Sort(SortOption sortOption)
        {
            var result = await Mediator.Send(new GetProducts(sortOption));

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}

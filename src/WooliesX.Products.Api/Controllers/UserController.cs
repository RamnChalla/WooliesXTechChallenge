using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using WooliesX.Products.Core.Queries;
using WooliesX.Products.Domain.Configuration;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api.Controllers
{
    [Route("api/wooliesx/[controller]")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    [Produces("application/json")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Gets the User with the specified unique identifier.
        /// </summary>
        /// <returns>A 200 OK response containing the User or a 404 Not Found if a User with the specified unique
        /// identifier was not found.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Get User", OperationId = "GetUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUser()
        {
            var result = await Mediator.Send(new GetUser());

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

    }
}

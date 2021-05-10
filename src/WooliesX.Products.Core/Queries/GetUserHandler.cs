using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WooliesX.Products.Data.Contexts;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Queries
{
    public class GetUserHandler : IRequestHandler<GetUser, User>
    {
        private readonly IDbContext _dbContext;

        public GetUserHandler(IDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
       
        public async Task<User> Handle(GetUser request, CancellationToken cancellationToken)
        {
            return await _dbContext.GetUserAsync();
        }
    }
}

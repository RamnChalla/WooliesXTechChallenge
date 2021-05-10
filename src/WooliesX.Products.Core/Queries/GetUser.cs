using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Core.Queries
{
    public class GetUser : IRequest<User>
    {
    }
}

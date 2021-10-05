using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Data.Contexts
{
    public interface IDbContext
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(string token = null);
    }
}

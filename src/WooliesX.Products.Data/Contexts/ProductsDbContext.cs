using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Data.Contexts
{
    public class ProductsDbContext : IDbContext
    {
        private readonly List<User> _users;

        public ProductsDbContext(List<User> users)
        {
            _users = users;
        }

        public async Task<User> GetUserAsync(string token = null)
        {
            // For challenge purposes if no token is passed in
            // Just default to the first user
            if (string.IsNullOrEmpty(token))
            {
                return _users.First();
            }

            return  _users.Single(s => s.Token == token);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return _users.ToList();
        }
    }
}

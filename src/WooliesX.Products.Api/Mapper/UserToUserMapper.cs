using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Products.Api.ViewModels;
using WooliesX.Products.Domain.Entities;

namespace WooliesX.Products.Api.Mapper
{
    public class UserToUserMapper : IMapper<Domain.Entities.User, ViewModels.User>
    {

        void IMapper<Domain.Entities.User, ViewModels.User>.Map(Domain.Entities.User source, ViewModels.User destination)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.Name = source.Name;
            destination.Token = source.Token;
        }

        void IMapper<Domain.Entities.User, ViewModels.User>.Map(Domain.Entities.User source, Domain.Entities.User destination)
        {
            throw new NotImplementedException();
        }
    }
}

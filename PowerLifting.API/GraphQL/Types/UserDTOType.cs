using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using PowerLifting.API.GraphQL.Resolvers;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.API.GraphQL.Types
{
    public class UserDTOType : ObjectType<UserDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDTO> descriptor)
        {
            descriptor.Include<AccountResolvers>();
        }
    }
}

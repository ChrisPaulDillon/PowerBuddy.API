using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using PowerLifting.API.GraphQL.Types;

namespace PowerLifting.API.GraphQL
{
    public static class ServicesConfiguration
    {
        public static void AddGraphQLServices(this IServiceCollection services)
        {
            services.AddGraphQL(s => SchemaBuilder.New()
                    .BindClrType<int, IntType>()
                    .AddQueryType<QueryType>()
                    .AddType<UserDTOType>()
                    .AddType(new PaginationAmountType(50))
                    .Create(),
                new QueryExecutionOptions
                {
                    ForceSerialExecution = true, // Used to make EF thread safe
                    TracingPreference = TracingPreference.Always
                });

        }
    }
}

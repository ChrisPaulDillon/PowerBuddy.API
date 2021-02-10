using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PowerBuddy.Data.Util;

namespace PowerBuddy.Data.Context
{
    public class PowerLiftingContextFactory : IDesignTimeDbContextFactory<PowerLiftingContext>
    {
        private readonly ContextConfig _config;

        public PowerLiftingContextFactory()
        {
            
        }

        public PowerLiftingContextFactory(ContextConfig config)
        {
            _config = config;
        }

        public PowerLiftingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PowerLiftingContext>();
            optionsBuilder.UseSqlServer(_config.DbContextStr);

            return new PowerLiftingContext(optionsBuilder.Options);
        }
    }
}
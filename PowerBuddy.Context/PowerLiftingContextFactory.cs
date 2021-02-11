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
            optionsBuilder.UseSqlServer("Server=161.35.32.66,1433;Database=PowerBuddy-livev3;User Id=sa;Password=Pizza123@");

            return new PowerLiftingContext(optionsBuilder.Options);
        }
    }
}
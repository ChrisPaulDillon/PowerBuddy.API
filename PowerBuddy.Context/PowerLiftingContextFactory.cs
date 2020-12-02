using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PowerBuddy.Context;

namespace PowerBuddy.Data.Context
{
    public class PowerLiftingContextFactory : IDesignTimeDbContextFactory<PowerLiftingContext>
    {
        public PowerLiftingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PowerLiftingContext>();
            optionsBuilder.UseSqlServer("Server=161.35.32.66,1433;Database=PowerBuddy-live;User Id=sa;Password=Pizza123@");

            return new PowerLiftingContext(optionsBuilder.Options);
        }
    }
}
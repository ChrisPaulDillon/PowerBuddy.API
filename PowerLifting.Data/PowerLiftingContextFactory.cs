using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PowerLifting.Data.Entities
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
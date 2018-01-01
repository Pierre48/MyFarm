using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFarm.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyFarmContext>
    {
        public MyFarmContext CreateDbContext(string[] args)
        {
            var sqlConnectionString = GetConfiguration().GetConnectionString("DataAccessPostgreSqlProvider");

            var optionsBuilder = new DbContextOptions<MyFarmContext>();

            var context = new MyFarmContext(optionsBuilder);
            //context. UseNpgsql(sqlConnectionString);
            return new MyFarmContext(optionsBuilder);
        }
        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}

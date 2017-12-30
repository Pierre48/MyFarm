using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{

    public class MyFarmContext : DbContext
    {
        private IConfiguration _configuration;


        public MyFarmContext(DbContextOptions<MyFarmContext> options, IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        public DbSet<Farm> Farms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Farm>(ConfigureFarm);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionString = _configuration.GetConnectionString("DataAccessPostgreSqlProvider");

            optionsBuilder.UseNpgsql(
                sqlConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        private void ConfigureFarm(EntityTypeBuilder<Farm> builder)
        {
            builder.ToTable("Farm");

            builder.Property(ci => ci.Id)
                .ForNpgsqlUseSequenceHiLo("catalog_hilo");

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);
        }

    }
}

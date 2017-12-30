﻿using MyFarm.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace MyFarm.Infrastructure.Data
{

    public class MyFarmContext : DbContext
    {
        private IConfiguration _configuration;


        public MyFarmContext(DbContextOptions<MyFarmContext> options, IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionString = _configuration.GetConnectionString("DataAccessPostgreSqlProvider");

            optionsBuilder.UseNpgsql(
                sqlConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}

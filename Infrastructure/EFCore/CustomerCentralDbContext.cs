using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EFCore
{
    public class CustomerCentralDbContext
        : DbContext
    {
        public CustomerCentralDbContext() { }

        public CustomerCentralDbContext(DbContextOptions<CustomerCentralDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TP8UCJ9;Database=CustomerCentral;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }
    }
}

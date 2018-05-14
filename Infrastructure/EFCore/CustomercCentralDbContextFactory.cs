using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EFCore
{
    class CustomercCentralDbContextFactory
        : IDesignTimeDbContextFactory<CustomerCentralDbContext>
    {
        public CustomerCentralDbContext CreateDbContext(string[] args)
        {
            return new CustomerCentralDbContext();
        }
    }
}

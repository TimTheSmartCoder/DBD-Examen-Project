using CustomerCentral.Menues;
using Domain.Entities;
using Infrastructure;
using Infrastructure.EFCore;
using Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Infrastructure.Dapper.Repositories;

namespace CustomerCentral
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // Use EntityFrameworkCore.
            serviceCollection.AddSingleton<DbContext, CustomerCentralDbContext>();

            //serviceCollection.AddTransient<IRepository<Customer>, CustomerRepository>();

            serviceCollection.AddTransient<IRepository<Customer>, CustomerDapperRepository>();

            IServiceProvider serviceProvider = serviceCollection
                .BuildServiceProvider();

            IMenu mainMenu = new MainMenu(serviceProvider);

            mainMenu.Execute();
        }
    }
}

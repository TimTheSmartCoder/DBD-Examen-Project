using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class GetAllCustomerMenu 
        : Menu
    {
        public GetAllCustomerMenu(
            IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {           
        }

        protected override void Run()
        {
            var repo = this.ServiceProvider.
                GetRequiredService<IRepository<Customer>>();

            var customers = repo.All().Result;

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer information: ");
                Console.WriteLine($"Id: {customer.Id}");
                Console.WriteLine($"First name: {customer.FirstName}");
                Console.WriteLine($"Last name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone number: {customer.PhoneNumber}");
                Console.WriteLine($"Street name: {customer.Address.Street}");
                Console.WriteLine($"City name: {customer.Address.City}");
                Console.WriteLine($"ZipCode: {customer.Address.ZipCode}");
                Console.WriteLine("");
            }

            Console.ReadLine();

            this.Exit = true;
        }
    }
}

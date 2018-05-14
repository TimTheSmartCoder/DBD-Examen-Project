using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class GetCustomerMenu
        : Menu
    {
        public GetCustomerMenu(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Run()
        {
            Console.WriteLine("Please type in id of customer: ");

            var customerId = 0;
            while (customerId == 0)
            {
                var input = int.TryParse(Console.ReadLine(), out customerId);
            }

            Console.WriteLine("Please wait loading customer information.");

            var customerRepository = this.ServiceProvider
                .GetRequiredService<IRepository<Customer>>();

            var customer = customerRepository.Get(customerId).Result;

            if (customer == null)
            {
                Console.WriteLine("Failed to get customer, please try again.");
                return;
            }

            Console.WriteLine("Customer information: ");
            Console.WriteLine($"Id: {customer.Id}");
            Console.WriteLine($"First name: {customer.FirstName}");
            Console.WriteLine($"Last name: {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone number: {customer.PhoneNumber}");

            Console.WriteLine("Press any key to continue...");
            Console.Read();

            this.Exit = true;
        }
    }
}

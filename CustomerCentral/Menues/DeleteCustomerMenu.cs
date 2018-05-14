using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class DeleteCustomerMenu
        : Menu
    {
        public DeleteCustomerMenu(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Run()
        {
            Console.WriteLine("Please type in id of customer to delete: ");

            var customerId = 0;
            while (customerId == 0)
            {
                var input = int.TryParse(Console.ReadLine(), out customerId);
            }

            var customerRepository = this.ServiceProvider
                .GetRequiredService<IRepository<Customer>>();

            Console.WriteLine("Please wait, deleting customer...");

            var customer = customerRepository.Get(customerId).Result;
            customerRepository.Delete(customer);

            Console.WriteLine("Customer is deleted.");

            this.Exit = true;
        }
    }
}

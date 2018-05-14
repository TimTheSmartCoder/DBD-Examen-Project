using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class UpdateCustomerMenu
        : Menu
    {
        public UpdateCustomerMenu(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        protected override void Run()
        {
            Console.WriteLine("Please type in the id of the customer to update: ");

            var customerId = 0;
            while (customerId == 0)
            {
                var input = int.TryParse(Console.ReadLine(), out customerId);
            }

            var customerRepository = this.ServiceProvider
                .GetRequiredService<IRepository<Customer>>();

            var customer = customerRepository.Get(customerId).Result;

            Console.WriteLine("Please fill out the following information for updating a customer.");

            Console.Write($"First name({customer.FirstName}): ");
            var firstName = Console.ReadLine();

            Console.Write($"Last name({customer.LastName}): ");
            var lastName = Console.ReadLine();

            Console.Write($"Email({customer.Email}): ");
            var email = Console.ReadLine();

            Console.Write($"Phone number: {customer.PhoneNumber}");
            var phoneNumber = Console.ReadLine();

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.PhoneNumber = phoneNumber;

            customer = customerRepository.Update(customer).Result;

            Console.WriteLine($"Customer has been updated, id: {customer.Id}");
            Console.ReadLine();

            this.Exit = true;
        }
    }
}

using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class CreateCustomerMenu
        : Menu
    {
        public CreateCustomerMenu(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        protected override void Run()
        {
            Console.WriteLine("Please fill out the following information for creating a new customer.");

            Console.Write("First name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine();

            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            var repository = this.ServiceProvider
                .GetRequiredService<IRepository<Customer>>();

            customer = repository.Create(customer).Result;

            Console.WriteLine($"Customer has been created with id: {customer.Id}");
            Console.ReadLine();

            this.Exit = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public class MainMenu
        : Menu
    {

        public  MainMenu(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        protected override void Run()
        {
            Console.WriteLine("Welcome to the Customer Central, here can you manage your'e customers.");
            Console.Write("Please type in your name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Please select one of the following selections to continue: ");
            Console.WriteLine("1. Create Customer.");
            Console.WriteLine("2. Update Customer.");
            Console.WriteLine("3. Delete Customer.");
            Console.WriteLine("4. Get Customer.");
            Console.WriteLine("5. Get all Customers.");
            Console.WriteLine("6. Exit.");

            var selection = 0;
            while(selection == 0)
            {
                Console.WriteLine("Type the selection here: ");
                var input = int.TryParse(Console.ReadLine(), out selection);
            }

            switch(selection)
            {
                case 1:
                    var createCustomerMenu = new CreateCustomerMenu(this.ServiceProvider);
                    createCustomerMenu.Execute();
                    break;
                case 2:
                    var updateCustomerMenu = new UpdateCustomerMenu(this.ServiceProvider);
                    updateCustomerMenu.Execute();
                    break;
                case 3:
                    var deleteCustomerMenu = new DeleteCustomerMenu(this.ServiceProvider);
                    deleteCustomerMenu.Execute();
                    break;
                case 4:
                    var getCustomerMenu = new GetCustomerMenu(this.ServiceProvider);
                    getCustomerMenu.Execute();
                    break;
                case 5:
                    break;
                case 6:
                    this.Exit = true;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCentral.Menues
{
    public abstract class Menu
        : IMenu
    {
        protected bool Exit = false;

        protected IServiceProvider ServiceProvider;

        protected Menu(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            this.ServiceProvider = serviceProvider;
        }

        public void Execute()
        {
            this.Loop();
        }

        protected abstract void Run();

        private void Loop()
        {
            while(!this.Exit)
            {
                this.Run();
            }
        }
    }
}

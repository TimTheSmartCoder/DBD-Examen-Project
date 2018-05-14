using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCentral.Menues
{
    public interface IMenu
    {
        /// <summary>
        /// Executes the menu. Returns when the menu
        /// is finish and closed.
        /// </summary>
        void Execute();
    }
}

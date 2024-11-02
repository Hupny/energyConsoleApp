using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpointsConsoleApp.Views
{
    public class BaseView
    {
        public BaseView()
        {
            ConsoleView = true;
        }

        protected bool ConsoleView { get; set; }

        protected void InvalidInput()
        {
            throw new Exception("Invalid input");
        }
    }
}

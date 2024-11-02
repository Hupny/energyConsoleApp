using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpointsConsoleApp.Views
{
    public class BaseItemView : BaseView
    {
        public BaseItemView() { }

        protected string? Name { get; set; }
        protected string? PluralName { get; set; }

        protected void ShowBaseOptions()
        {
            if (Name == null || PluralName == null)
                return;

            Console.WriteLine("---Accessing " + PluralName + "---");
            Console.WriteLine("Options:");
            Console.WriteLine("1 - List " + PluralName);
            Console.WriteLine("2 - Create " + Name);
            Console.WriteLine("3 - Update " + Name);
            Console.WriteLine("4 - Delete " + Name);
            Console.WriteLine("5 - View " + Name + " details");
            Console.WriteLine("6 - Exit");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpointsConsoleApp.Views
{
    public class BaseItemView : BaseView
    {
        public BaseItemView(string name, string namePlural, int numberOptions)
        {
            Name = name;
            NamePlural = namePlural;
            NumberOptions = numberOptions;
        }

        protected string? Name { get; set; }
        protected string? NamePlural { get; set; }
        protected int NumberOptions { get; set; }

        protected void ShowBaseOptions()
        {
            if (Name == null || NamePlural == null)
                return;

            Console.WriteLine("---Accessing " + NamePlural + "---");
            Console.WriteLine("Options:");
            Console.WriteLine("1 - List " + NamePlural);
            Console.WriteLine("2 - Create " + Name);
            Console.WriteLine("3 - Update " + Name);
            Console.WriteLine("4 - Delete " + Name);
            Console.WriteLine("5 - View " + Name + " details");
            Console.WriteLine("6 - Clear");
            Console.WriteLine("7 - Exit");
        }
    }
}

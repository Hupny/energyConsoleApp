using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpointsConsoleApp.Views
{
    internal class StartView : BaseView
    {
        public StartView()
        {
            Services = new List<string> {
                "Endpoints",
            };
        }

        private List<string> Services { get; set; }
        private EndpointView? EndpointView { get; set; }

        public void StartInterface()
        {
            Console.Write(
                "------------------------------\n" +
                "-----------Welcome!-----------\n" +
                "------------------------------\n"
                );

            Thread.Sleep(3000);

            Console.Clear();

            while (ConsoleView)
            {
                try
                {
                    this.SelectOptions();
                }
                catch (Exception e)
                {
                    ConsoleView = false;
                    Console.WriteLine(e.Message);
                    Thread.Sleep(5000);
                }
                finally
                {
                    if (ConsoleView == false)
                        Console.WriteLine("System shutting down....");
                }        
            }
        }

        public void SelectOptions()
        {
            Console.WriteLine("Please select one of the options: ");

            for (int i = 0; i < Services.Count(); i++)
            {
                int displayValue = i + 1;
                Console.WriteLine(displayValue + " - " + Services[i]);
            }

            int displayExit = Services.Count() + 1;
            Console.WriteLine(displayExit + " - Exit");

            var userResponse = Console.Read();

            Console.Clear();

            if (userResponse < 1 || userResponse > (Services.Count() + 1))
            {
                Console.Write("Invalid input\n\n\n\n");
                return;
            }

            switch (userResponse)
            {
                case 1:

                    this.EndpointView = new EndpointView();
                    this.EndpointView.Start();

                    break;

                default:

                    ConsoleView = false;
                    
                    break;
            }
            
        }
    }
}

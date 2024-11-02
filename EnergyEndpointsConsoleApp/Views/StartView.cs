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

            Thread.Sleep(1000);

            Console.Clear();

            while (ConsoleView)
            {
                try
                {
                    this.SelectOptions();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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

            for (int i = 0; i < Services.Count; i++)
            {
                int displayValue = i + 1;
                Console.WriteLine(displayValue + " - " + Services[i]);
            }

            int displayExit = Services.Count + 1;
            Console.WriteLine(displayExit + " - Exit");

            string? userResponse = Console.ReadLine() ?? throw new Exception("No input found");

            bool ok = int.TryParse(userResponse, out int optionSelected);
            if (!ok || optionSelected < 1 || optionSelected > (Services.Count() + 1))
            {
                InvalidInput();
                return;
            }

            Console.Clear();

            switch (optionSelected)
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

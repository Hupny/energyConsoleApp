using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpointsConsoleApp.Views
{
    internal class StartView
    {
        public StartView()
        {
            Services = new List<string> {
                "Endpoints"
            };
        }

        private List<string> Services { get; set; }
        private EndpointView EndpointView { get; set; }

        public void StartInterface()
        {
            Console.Write(
                "------------------------------\n" +
                "-----------Welcome!-----------\n" +
                "------------------------------\n"
                );

            Thread.Sleep(3000);

            Console.Clear();

            bool consoleView = true;
            while (consoleView)
            {
                this.SelectOptions();
            }
        }

        public void SelectOptions()
        {
            Console.WriteLine("Please select one of the options: ");

            for (int i = 0; i < Services.Count(); i++)
            {
                Console.WriteLine(i + " - " + Services[i]);
            }

            int totalElements = Services.Count() + 1;
            Console.WriteLine(totalElements + " - Exit");

            try
            {
                var userResponse = Console.Read();

                Console.Clear();

                if (userResponse < 0 || userResponse > Services.Count() + 1)
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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
            }
            finally
            {
                Console.WriteLine("System shutting down....");
            }
        }
    }
}

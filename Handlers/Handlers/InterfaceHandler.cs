namespace EnergyEndpointsConsoleApp.Handlers
{
    public class InterfaceHandler
    {
        public InterfaceHandler()
        {
            Services = new List<string> {
                "Endpoints"
            };
        }

        private List<string> Services { get; set; }

        public void StartInterface()
        {
            Console.Write(
                "------------------------------\n" +
                "-----------Welcome!-----------\n" +
                "------------------------------\n"
                );

            Thread.Sleep(3000);

            Console.Clear();

            Console.Write("Please select one of the options: \n\n");

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

                if (userResponse < 0 || userResponse > totalElements)
                {
                    throw new ArgumentException("Invalid input");    
                }

                switch (userResponse)
                {
                    case 1:

                        EndpointHandler handler = new EndpointHandler();

                        handler.Start();

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
                Console.WriteLine("System shutting down");
            }
            
        }
    }
}

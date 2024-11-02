using EnergyEndpointsConsoleApp.Handlers;
using Structures.Enums;
using Structures.Interefaces;
using Structures.Models;

namespace EnergyEndpointsConsoleApp.Views
{
    public class EndpointView : BaseItemView, IUserInterfaceItem<EndpointModel>
    {
        public EndpointView(List<EndpointModel>? endpoints = null) : base("endpoint", "endpoints", 7)
        {
            if (endpoints != null)
                EndpointHandler = new EndpointHandler(endpoints);
            else
            {
                //EndpointHandler = new EndpointHandler();
                EndpointHandler = new EndpointHandler(MockedSystemData);
            }
        }

        private EndpointHandler EndpointHandler { get; set; }

        public void Start()
        {
            this.ConsoleView = true;
            while (ConsoleView)
            {
                try
                {
                    ShowOptions();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        public void ShowOptions()
        {
            ShowBaseOptions();

            string? userResponse = Console.ReadLine() ?? throw new Exception("No input found");

            bool ok = int.TryParse(userResponse, out int optionSelected);
            if (!ok || optionSelected < 1 || optionSelected > NumberOptions)
            {
                InvalidInput();
                return;
            }

            Console.WriteLine();

            switch (optionSelected)
            {
                case 1:

                    NoDataForOperation();
                    ListItems();
                    break;
                case 2:

                    CreateItem();
                    break;
                case 3:

                    NoDataForOperation();
                    UpdateItem();
                    break;
                case 4:

                    NoDataForOperation();
                    DeleteItem();
                    break;
                case 5:

                    NoDataForOperation();
                    ShowItemDetails();
                    break;
                case 6:

                    Console.Clear();
                    break;
                case 7:

                    Exit();
                    break;
            }
        }

        public void CreateItem()
        {

            Console.WriteLine("Input the endpoint serial number:");
            string? serialNumber = Console.ReadLine() ?? throw new Exception("No input found");
            if (serialNumber == string.Empty)
                EmptyInput();

            Console.WriteLine("Input the endpoint number:");
            string? numberString = Console.ReadLine();
            bool ok = int.TryParse(numberString, out int number);
            if (!ok)
                InvalidInput();

            Console.WriteLine("Input the endpoint firmware version:");
            string? firmwareVersion = Console.ReadLine() ?? throw new Exception("No input found");


            Console.WriteLine("Input the endpoint state (using the code):");

            IEnumerable<EndpointStateEnum> stateValues = Enum.GetValues(typeof(EndpointStateEnum)).Cast<EndpointStateEnum>();
            foreach (var stateValue in stateValues)
            {
                Console.WriteLine(stateValue + " - " + (int)stateValue);
            }

            string? stateString = Console.ReadLine();
            ok = int.TryParse(stateString, out int state);
            if (!ok)
                InvalidInput();

            string response = EndpointHandler.CreateEndpoint(serialNumber, number, firmwareVersion, state);
            Console.WriteLine(response);
        }

        public void DeleteItem()
        {
            Console.WriteLine("Input the endpoint serial number:");
            string? serialNumber = Console.ReadLine() ?? throw new Exception("No input found");
            if (serialNumber == string.Empty)
                EmptyInput();

            (_, bool ok, string response) = EndpointHandler.FindEndpoint(serialNumber);
            if (!ok)
            {
                Console.WriteLine(response);
                return;
            }

            Console.WriteLine("Do you really want to delete this endpoint?");
            Console.Write("type 'y' to confirm: ");
            char confirmation = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (confirmation == 'y')
            {
                response = EndpointHandler.DeleteEndpoint(serialNumber);
                Console.WriteLine(response);
            } else
            {
                Console.WriteLine("Cancelling deletion");
            }
        }

        public void ListItems()
        {
            List<EndpointModel> endpointList = EndpointHandler.GetItemList();
            if (endpointList.Count == 0)
            {
                Console.WriteLine("There are no registered endpoints");
                return;
            }


            Console.WriteLine(" * Serial number | Model Id | Number | Firmwawre Version | State ");

            for (int i = 0; i < endpointList.Count(); i++)
            {
                Console.WriteLine(" * " + endpointList[i].SerialNumber + " | " + endpointList[i].ModelId + " | " +
                    endpointList[i].Number + " | " + endpointList[i].FirmwareVersion + " | " +
                    (EndpointStateEnum)endpointList[i].State);
            }

            Console.WriteLine();
            Console.Write("Press enter to return ");
            Console.ReadLine();
        }

        public void UpdateItem()
        {
            Console.WriteLine("Input the endpoint serial number:");
            string? serialNumber = Console.ReadLine() ?? throw new Exception("No input found");
            if (serialNumber == string.Empty)
                EmptyInput();

            (EndpointModel? endpoint, bool ok, string response) = EndpointHandler.FindEndpoint(serialNumber);
            if (!ok || endpoint == null)
            {
                Console.WriteLine(response);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Endpoint " + endpoint.SerialNumber + " is " + (EndpointStateEnum)endpoint.State);
            Console.WriteLine();

            Console.WriteLine("Input the endpoint new state (using the code):");

            IEnumerable<EndpointStateEnum> stateValues = Enum.GetValues(typeof(EndpointStateEnum)).Cast<EndpointStateEnum>();
            foreach (var stateValue in stateValues)
            {
                Console.WriteLine(stateValue + " - " + (int)stateValue);
            }

            string? stateString = Console.ReadLine();
            ok = int.TryParse(stateString, out int state);
            if (!ok)
                InvalidInput();

            response = EndpointHandler.UpdateEndpoint(serialNumber, state);
            Console.WriteLine(response);
        }

        public void ShowItemDetails()
        {
            Console.WriteLine("Input the endpoint serial number:");
            string? serialNumber = Console.ReadLine() ?? throw new Exception("No input found");
            if (serialNumber == string.Empty)
                EmptyInput();

            (EndpointModel? endpoint, bool ok, string response) = EndpointHandler.FindEndpoint(serialNumber);
            if (!ok || endpoint == null)
            {
                Console.WriteLine(response);
                return;
            }

            string lastModifiedString = (endpoint.LastModified == DateTime.MinValue) ? "-" : endpoint.LastModified.ToString();

            Console.WriteLine("Serial number   : " + endpoint.SerialNumber);
            Console.WriteLine("Model Id        : " + endpoint.ModelId);
            Console.WriteLine("Number          : " + endpoint.Number);
            Console.WriteLine("Firmware version: " + endpoint.FirmwareVersion);
            Console.WriteLine("State           : " + (EndpointStateEnum)endpoint.State);
            Console.WriteLine("Creation date   : " + endpoint.Creation);
            Console.WriteLine("Last modified   : " + lastModifiedString);

            Console.WriteLine();
            Console.Write("Press enter to return ");
            Console.ReadLine();
        }

        private void NoDataForOperation()
        {
            if (EndpointHandler.ListEmpty())
            {
                throw new Exception("There are no registered endpoints");
            }
        }

        public List<EndpointModel> MockedSystemData = new List<EndpointModel>()
        {
            new EndpointModel("NSX1P2W-123", 16, 11, "4.0.2", 1),
            new EndpointModel("NSX1P2W-321", 16, 12, "4.0.2", 1),
            new EndpointModel("NSX1P3W-123", 17, 13, "4.0.3", 1),
            new EndpointModel("NSX1P3W-321", 17, 14, "4.0.2", 2),
            new EndpointModel("NSX2P3W-111", 18, 15, "4.0.3", 0),
            new EndpointModel("NSX2P3W-122", 18, 16, "4.0.3", 2),
            new EndpointModel("NSX3P4W-222", 19, 17, "4.0.2", 1),
            new EndpointModel("NSX3P4W-233", 19, 18, "4.0.3", 1),
        };
    }
}

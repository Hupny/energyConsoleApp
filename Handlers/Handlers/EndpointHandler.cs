using Handlers.Handlers;
using Structures.Enums;
using Structures.Models;

namespace EnergyEndpointsConsoleApp.Handlers
{
    public class EndpointHandler : BaseHandler<EndpointModel>
    {
        public EndpointHandler(List<EndpointModel>? itemsList = null) : base(itemsList) { }

        public string CreateEndpoint(string serialNumber, int number, string firmwareVersion, int state)
        {
            serialNumber = serialNumber.ToUpper();
            if (ItemList.Count > 0)
            {
                var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
                if (existItem != null)
                    return Fail("Endpoint already exists");
            }

            if (Enum.IsDefined(typeof(EndpointStateEnum), state) == false)
                return Fail("State code " + state + " is not valid");

            if (serialNumber.Length <= 7)
                return Fail("Invalid serial, no model was found for this serial type");
 
            string serialType = serialNumber[..7];

            IEnumerable<EndpointSerialModelEnum> modelValues = Enum.GetValues(typeof(EndpointSerialModelEnum)).Cast<EndpointSerialModelEnum>();
            EndpointSerialModelEnum? model = null;
            foreach (var modelValue in modelValues)
            {
                if (modelValue.ToString() == serialType)
                    model = modelValue;
            }

            if (model == null)
                return Fail("Invalid serial, no model was found for this serial type");

            EndpointModel newEndpoint = new EndpointModel(serialNumber, (int)model, number, firmwareVersion, state);
            this.ItemList.Add(newEndpoint);

            return Success();
        }

        public string UpdateEndpoint(string serialNumber, int state)
        {
            serialNumber = serialNumber.ToUpper();

            var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
            if (existItem == null)
                return Fail("Endpoint not found");

            if (Enum.IsDefined(typeof(EndpointStateEnum), state))
                existItem.UpdateEndpoint(state);
            else
                return Fail("State code " + state + " is not valid");

            return Success();
        }

        public string DeleteEndpoint(string serialNumber)
        {
            serialNumber = serialNumber.ToUpper();

            var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
            if (existItem == null)
                return Fail("Endpoint not found");

            this.ItemList.Remove(existItem);

            return Success();
        }

        public (EndpointModel?, bool, string) FindEndpoint(string serialNumber)
        {
            serialNumber = serialNumber.ToUpper();

            var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
            if (existItem == null)
                return (existItem, false, Fail("Endpoint not found"));

            return (existItem, true, "Item found");
        }
    }
}

using Handlers.Handlers;
using Structures.Enums;
using Structures.Interefaces;
using Structures.Models;

namespace EnergyEndpointsConsoleApp.Handlers
{
    public class EndpointHandler : BaseHandler<EndpointModel>
    {
        public EndpointHandler(List<EndpointModel>? itemsList = null) : base(itemsList) { }

        public string CreateEndpoint(string serialNumber, int modelId, int number, string firmwareVersion, int state)
        {
            if (ItemList.Count > 0)
            {
                var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
                if (existItem != null)
                    return Fail("Endpoint already exists");
            }

            if (Enum.IsDefined(typeof(EndpointStateEnum), state) == false)
                return Fail("State code " + state + " is not valid");

            EndpointModel newEndpoint = new EndpointModel(serialNumber, modelId, number, firmwareVersion, state);
            this.ItemList.Add(newEndpoint);

            return Success();
        }

        public string UpdateEndpoint(string serialNumber, int state)
        {
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
            var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
            if (existItem == null)
                return Fail("Endpoint not found");

            this.ItemList.Remove(existItem);

            return Success();
        }

        public (EndpointModel?, bool, string) FindEndpoint(string serialNumber)
        {
            var existItem = this.ItemList.FirstOrDefault(i => i.SerialNumber == serialNumber);
            if (existItem == null)
                return (existItem, false, Fail("Endpoint not found"));

            return (existItem, true, "Item found");
        }
    }
}

using Structures.Interefaces;
using Structures.Models;

namespace EnergyEndpointsConsoleApp.Handlers
{
    public class EndpointHandler : IUserInterfaceItem<EndpointModel>
    {
        public EndpointHandler(List<EndpointModel>? endpoints = null)
        {
            if (endpoints != null)
                Endpoints = endpoints;
            else
            {
                Endpoints = new List<EndpointModel>();
            }
        }

        private List<EndpointModel> Endpoints { get; set; }

        public void Start()
        {
            try
            {
                ShowOptions();


            }
            catch (Exception e)
            {

            }
        }

        public void ShowOptions()
        {

        }

        public void CreateItem()
        {

        }

        public void DeleteItem(string id)
        {
            EndpointModel itemToRemove = Endpoints.Where(x => x.SerialNumber == id).First();
            Endpoints.Remove(itemToRemove);
        }

        public void ListItems()
        {
            for (int i = 0; i < Endpoints.Count(); i++) {
                Console.WriteLine(i + " - " + Endpoints[i].SerialNumber);
            }

            throw new NotImplementedException();
        }

        public void UpdateItem()
        {
            throw new NotImplementedException();
        }

        public void ShowItem(int index)
        {
            throw new NotImplementedException();
        }

    }
}

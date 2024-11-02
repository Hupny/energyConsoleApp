using Structures.Enums;

namespace Structures.Models
{
    public class EndpointModel : BaseModel
    {
        public EndpointModel(string serialNumber, int modelId, int number, string firmwareVersion, int state)
        {

            SerialNumber = serialNumber;
            ModelId = modelId;
            Number = number;
            FirmwareVersion = firmwareVersion;
            State = state;
        }

        public string SerialNumber { get; private set; }
        public int ModelId { get; private set; }
        public int Number { get; private set; }
        public string FirmwareVersion { get; private set; }
        public int State { get; private set; }

        public void UpdateEndpoint(int state)
        {
            State = state;
            LastModified = DateTime.Now;
        }
    }


}

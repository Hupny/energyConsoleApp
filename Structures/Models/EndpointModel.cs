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

        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public int State { get; set; }
    }


}

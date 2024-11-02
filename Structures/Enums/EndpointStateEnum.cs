using System.ComponentModel;

namespace Structures.Enums
{
    public enum EndpointStateEnum
    {
        [Description("Disconnected")]
        Disconnected = 0,
        [Description("Connected")]
        Connected = 1,
        [Description("Armed")]
        Armed = 2,
    }
}

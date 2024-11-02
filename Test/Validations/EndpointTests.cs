using EnergyEndpointsConsoleApp.Handlers;
using FluentAssertions;
using Structures.Models;

namespace Test.Validations
{
    public class EndpointTests
    {
        public EndpointTests()
        {
            EndpointHandlerMock = new EndpointHandler(new List<EndpointModel>()
                {
                    new EndpointModel("NSX1P2W-123", 16, 11, "4.0.2", 1),
                    new EndpointModel("NSX1P2W-321", 16, 12, "4.0.2", 1),
                    new EndpointModel("NSX1P3W-123", 17, 13, "4.0.3", 1),
                    new EndpointModel("NSX1P3W-321", 17, 14, "4.0.2", 2),
                    new EndpointModel("NSX2P3W-111", 18, 15, "4.0.3", 0),
                    new EndpointModel("NSX2P3W-122", 18, 16, "4.0.3", 2),
                    new EndpointModel("NSX3P4W-222", 19, 17, "4.0.2", 1),
                    new EndpointModel("NSX3P4W-233", 19, 18, "4.0.3", 1),
                }
            );
        }

        private EndpointHandler EndpointHandlerMock { get; set; }

        [Fact]
        public void CreateEndpoint_Success()
        {
            //Arrange
            string serialNumber = "NSX1P2W-124";
            int number = 19;
            string firmwareVersion = "4.0.3";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Success");
        }

        [Fact]
        public void CreateEndpoint_Fail_AlreadyExists()
        {
            //Arrange
            string serialNumber = "NSX1P2W-123";
            int number = 19;
            string firmwareVersion = "4.0.3";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - Endpoint already exists");
        }

        [Fact]
        public void CreateEndpoint_Fail_InvalidSerial_Lenght()
        {
            //Arrange
            string serialNumber = "NSX1-2";
            int number = 19;
            string firmwareVersion = "4.0.3";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - Invalid serial, no model was found for this serial type");
        }

        [Fact]
        public void CreateEndpoint_Fail_InvalidSerial_NoModelForSerial()
        {
            //Arrange
            string serialNumber = "NSX5P9W-111";
            int number = 19;
            string firmwareVersion = "4.0.3";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - Invalid serial, no model was found for this serial type");
        }

        [Fact]
        public void CreateEndpoint_Fail_InvalidState()
        {
            //Arrange
            string serialNumber = "NSX1P2W-124";
            int number = 19;
            string firmwareVersion = "4.0.3";
            int state = 5;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - State code " + state + " is not valid");
        }

        [Fact]
        public void UpdateEndpoint_Success()
        {
            //Arrange
            string serialNumber = "NSX3P4W-222";
            int state = 2;

            //Act
            var result = EndpointHandlerMock.UpdateEndpoint(serialNumber, state);

            //Assert
            result.Should().Be("Success");
        }

        [Fact]
        public void UpdateEndpoint_Fail_EndpointNotFound()
        {
            //Arrange
            string serialNumber = "NSX3P4W-999";
            int state = 2;

            //Act
            var result = EndpointHandlerMock.UpdateEndpoint(serialNumber, state);

            //Assert
            result.Should().Be("Fail - Endpoint not found");
        }

        [Fact]
        public void UpdateEndpoint_Fail_InvalidState()
        {
            //Arrange
            string serialNumber = "NSX3P4W-222";
            int state = 5;

            //Act
            var result = EndpointHandlerMock.UpdateEndpoint(serialNumber, state);

            //Assert
            result.Should().Be("Fail - State code " + state + " is not valid");
        }

        [Fact]
        public void DeleteEndpoint_Success()
        {
            //Arrange
            string serialNumber = "NSX3P4W-222";

            //Act
            var result = EndpointHandlerMock.DeleteEndpoint(serialNumber);

            //Assert
            result.Should().Be("Success");
        }

        [Fact]
        public void DeleteEndpoint_Fail_EndpointNotFound()
        {
            //Arrange
            string serialNumber = "NSX3P4W-999";

            //Act
            var result = EndpointHandlerMock.DeleteEndpoint(serialNumber);

            //Assert
            result.Should().Be("Fail - Endpoint not found");
        }
    }
}

using EnergyEndpointsConsoleApp.Handlers;
using Structures.Models;
using FluentAssertions;

namespace Test.Validations
{
    public class EndpointTests
    {
        public EndpointTests()
        {
            EndpointHandlerMock = new EndpointHandler(new List<EndpointModel>()
                {
                    new EndpointModel("ser-321", 62, 18, "4.0.2", 1),
                    new EndpointModel("ser-123", 62, 19, "4.0.3", 2),
                    new EndpointModel("ser-111", 65, 20, "4.0.3", 0),
                    new EndpointModel("ser-222", 65, 21, "4.0.3", 0),
                    new EndpointModel("ser-333", 65, 23, "4.0.4", 1),
                }
            );
        }

        private EndpointHandler EndpointHandlerMock { get; set; }

        [Fact]
        public void CreateEndpoint_Success()
        {
            //Arrange
            string serialNumber = "ser-444";
            int modelId = 65;
            int number = 24;
            string firmwareVersion = "4.0.4";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, modelId, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Success");
        }

        [Fact]
        public void CreateEndpoint_Fail_AlreadyExists()
        {
            //Arrange
            string serialNumber = "ser-333";
            int modelId = 65;
            int number = 24;
            string firmwareVersion = "4.0.4";
            int state = 0;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, modelId, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - Endpoint already exists");
        }

        [Fact]
        public void CreateEndpoint_Fail_InvalidState()
        {
            //Arrange
            string serialNumber = "ser-444";
            int modelId = 65;
            int number = 24;
            string firmwareVersion = "4.0.4";
            int state = 5;

            //Act
            var result = EndpointHandlerMock.CreateEndpoint(serialNumber, modelId, number, firmwareVersion, state);

            //Assert
            result.Should().Be("Fail - State code " + state + " is not valid");
        }

        [Fact]
        public void UpdateEndpoint_Success()
        {
            //Arrange
            string serialNumber = "ser-333";
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
            string serialNumber = "ser-999";
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
            string serialNumber = "ser-333";
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
            string serialNumber = "ser-333";

            //Act
            var result = EndpointHandlerMock.DeleteEndpoint(serialNumber);

            //Assert
            result.Should().Be("Success");
        }

        [Fact]
        public void DeleteEndpoint_Fail_EndpointNotFound()
        {
            //Arrange
            string serialNumber = "ser-999";

            //Act
            var result = EndpointHandlerMock.DeleteEndpoint(serialNumber);

            //Assert
            result.Should().Be("Fail - Endpoint not found");
        }
    }
}

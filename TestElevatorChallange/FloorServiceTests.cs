using ElevatorChallange.Models;
using ElevatorChallange.Services;

namespace TestElevator
{
    public class FloorServiceTests
    {
        [Fact]
        public void AddRequest_Should_Add_Request_To_Building_Queue()
        {
            // Arrange
            var floorService = new FloorService();
            var building = new Building();
            int requestedFloor = 3;
            Direction direction = Direction.Up;

            // Act
            floorService.AddRequest(building, requestedFloor, direction);

            // Assert
            Assert.Contains((requestedFloor, direction), building.Queue);
        }

       
    }

    // Helper class to capture console output during tests
    public class FakeConsoleOutput : IDisposable
    {
        private readonly System.IO.StringWriter _stringWriter;
        private readonly System.IO.TextWriter _originalOutput;

        public FakeConsoleOutput()
        {
            _stringWriter = new System.IO.StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString().Trim();
        }

        public void Dispose()
        {
            _stringWriter.Dispose();
            Console.SetOut(_originalOutput);
        }
    }
}
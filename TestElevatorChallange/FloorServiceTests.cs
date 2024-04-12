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

        [Fact]
        public void UpdateFloorStatus_Should_Update_Floor_Status()
        {
            // Arrange
            var floorService = new FloorService();
            var floor = new Floor(1);
            bool hasPeopleWaiting = true;

            // Act
            floorService.UpdateFloorStatus(floor, hasPeopleWaiting);

            // Assert
            Assert.True(floor.HasPeopleWaiting);
        }

        [Fact]
        public void CheckElevatorAvailability_Should_Return_True_If_Available_Elevator_Found()
        {
            // Arrange
            var floorService = new FloorService();
            var elevators = new List<Elevator>
            {
                 new Elevator { IsStopped = true, AreDoorsOpen = false },
                 new Elevator { IsStopped = false, AreDoorsOpen = true },
                 new Elevator { IsStopped = true, AreDoorsOpen = true }
            };

            // Act
            var isAvailable = floorService.CheckElevatorAvailability(elevators) != null;

            // Assert
            Assert.True(isAvailable);
        }

        [Fact]
        public void HandleFloorEvents_Should_Update_Floor_Status_If_People_Entered_Or_Exited_Elevator()
        {
            // Arrange
            var floorService = new FloorService();
            var floor = new Floor(1);

            // Act
            floorService.HandleFloorEvents(floor, peopleEntered: true, peopleExited: false);

            // Assert
            Assert.False(floor.HasPeopleWaiting);
        }

        [Fact]
        public void UpdateFloorDisplay_Should_Display_Elevator_Position_For_The_Current_Floor()
        {
            // Arrange
            var floorService = new FloorService();
            var floor = new Floor(1);
            var elevators = new List<Elevator>
            {
                 new Elevator { CurrentFloor = 1, Id = 1 }, 
                 new Elevator { CurrentFloor = 2, Id = 2 },
                 new Elevator { CurrentFloor = 1, Id = 3 }
            };
            var consoleOutput = new FakeConsoleOutput();

            // Act
            floorService.UpdateFloorDisplay(floor, elevators);

            // Assert
            Assert.Contains($"Elevator 1 is currently at floor {floor.FloorNumber}", consoleOutput.GetOutput());
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
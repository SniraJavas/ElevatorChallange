using ElevatorChallange.Models;
using ElevatorChallange.Services;

namespace TestElevator
{
    public class ElevatorServiceTests
    {
            [Fact]
            public void MoveElevator_Should_Move_To_Target_Floor()
            {
                // Arrange
                var elevatorService = new ElevatorService();
                var elevator = new Elevator();
                elevator.CurrentFloor = 2; // Assume elevator is currently at floor 2
                int targetFloor = 5;

                // Act
                elevatorService.MoveElevator(elevator, targetFloor);

                // Assert
                Assert.Equal(targetFloor, elevator.CurrentFloor);

            }

            [Fact]
            public void AddRequest_Should_Add_Request_To_Elevator_Queue()
            {
                // Arrange
                var elevatorService = new ElevatorService();
                var elevator = new Elevator();
                int requestedFloor = 3;

                // Act
                elevatorService.AddRequest(elevator, requestedFloor);

                // Assert
                Assert.Contains(requestedFloor, elevator.Queue);

            }

            [Fact]
            public void UpdateElevatorState_Should_Update_Elevator_State()
            {
                // Arrange
                var elevatorService = new ElevatorService();
                var elevator = new Elevator();
                int currentFloor = 3;
                Direction direction = Direction.Up;

                // Act
                elevatorService.UpdateElevatorState(elevator, currentFloor, direction);

                // Assert
                Assert.Equal(currentFloor, elevator.CurrentFloor);
                Assert.Equal(direction, elevator.Direction);

            }

            [Fact]
            public void CheckFloorRequests_Should_Prioritize_Requests_Based_On_Direction()
            {
                // Arrange
                var elevatorService = new ElevatorService();
                var elevator = new Elevator();
                elevator.CurrentFloor = 3; // Assume elevator is currently at floor 3
                elevator.Queue = new List<int> { 1, 5, 2, 4 }; // Queue with requests
                elevator.Direction = Direction.Up;

                // Act
                var prioritizedQueue = elevatorService.CheckFloorRequests(elevator);

                // Assert
                Assert.Equal(new List<int> { 4, 5 }, prioritizedQueue); // Expected prioritized queue

            }

            [Fact]
            public void HandleEmergency_Should_Stop_Elevator_And_Open_Doors()
            {
                // Arrange
                var elevatorService = new ElevatorService();
                var elevator = new Elevator();
                elevator.IsEmergency = true;

                // Act
                elevatorService.HandleEmergency(elevator);

                // Assert
                Assert.True(elevator.IsStopped);
                Assert.True(elevator.AreDoorsOpen);

            }
        }
}
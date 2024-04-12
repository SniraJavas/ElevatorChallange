// See https://aka.ms/new-console-template for more information
// Initialize building, elevators, and floor service
using ElevatorChallange.Helpers;
using ElevatorChallange.Models;
using ElevatorChallange.Services;
using Direction = ElevatorChallange.Models.Direction;

List<(int Floor, Direction Direction)> Queue = new List<(int, Direction)>();
List<Floor> Floors = Enumerable.Range(1, 5) // There will be 5 floors
                       .Select(floorNumber => new Floor(floorNumber))
                       .ToList<Floor>();

List<Elevator> Elevators = Enumerable.Range(1, 2)  // There will be 2 Elevators
                          .Select(id => new Elevator
                          {
                              Id = id,
                              CurrentFloor = 1,
                              Direction = Direction.Up,
                              Queue = new List<int>(),
                              IsStopped = true,
                              AreDoorsOpen = false,
                              IsEmergency = false
                          })
                          .ToList<Elevator>();

Building building = new Building(Queue, Elevators, Floors);


FloorService floorService = new FloorService();
ElevatorHelper elevatorHelper = new ElevatorHelper(floorService);
FloorHelper floorHelper = new FloorHelper();

Console.WriteLine("Welcome to the DVT Elevator ");
Console.WriteLine("The building has {0} floors , {1} Elevators ", Floors.Count, Elevators.Count);
Console.WriteLine("All elevators are at floor 1, Ground floor ");



// Which floor are you in, multiple floors can trigger the elevator ?

// Which floor are you going to, you can accept multiple requests ?
while (true) 
{
    elevatorHelper.RequestElevator(building, building.Elevators);

}

// Which lift is the nearest to your floor and coming towards your floor ?
// Update the user which lift is coming to their floor.
// Update the user if the lift have arrived and heading to their destination
// Arrived and indicate where it stopped.

// See https://aka.ms/new-console-template for more information
// Initialize building, elevators, and floor service
using ElevatorChallange.Models;
using ElevatorChallange.Services;

List<(int Floor, Direction Direction)> Queue = new List<(int, Direction)>();
Queue.Add((1, Direction.Up));
Queue.Add((3, Direction.Down));
Queue.Add((5, Direction.Down));

List<Floor> Floors = Enumerable.Range(1, 5) // There will be 5 floors
                       .Select(floorNumber => new Floor(floorNumber))
                       .ToList<Floor>();

List<Elevator> Elevators = Enumerable.Range(1, 3)  // There will be 3 Elevators
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

ElevatorService elevatorService = new ElevatorService();
FloorService floorService = new FloorService();

Console.WriteLine("Welcome to the DVT Elevator ");

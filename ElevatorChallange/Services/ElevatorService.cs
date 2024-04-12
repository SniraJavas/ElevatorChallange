using ElevatorChallange.Interfaces;
using ElevatorChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Services
{
    public class ElevatorService : IElevator
    {
        private readonly IFloor _floorService;

        public ElevatorService(IFloor floorService)
        {
            _floorService = floorService;
        }
        /// <summary>
        /// Moving the elevator to the target floor
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="targetFloor"></param>
        public void MoveElevator(Elevator elevator,int original ,int target)
        {
            if (elevator.CurrentFloor != original) 
            {
                if (elevator.CurrentFloor > original)
                {
                    elevator.Direction = Direction.Down;
                }
                else
                {
                    elevator.Direction = Direction.Up;
                }

                Console.WriteLine("Elevator {0} is moving  {1} ", elevator.Id, elevator.Direction);
                elevator.CurrentFloor = original;
                elevator.AreDoorsOpen = true;
                Console.WriteLine("Elevator {0} have arrived at floor {1} to fetch people ", elevator.Id, elevator.CurrentFloor);
            }
            

            if (elevator.CurrentFloor > target)
            {
                elevator.Direction = Direction.Down;
            }
            else {
                elevator.Direction = Direction.Up;
            }
            Console.WriteLine("Elevator {0} is moving  {1}", elevator.Id, elevator.Direction);
            elevator.CurrentFloor = target;
            Console.WriteLine("Elevator {0} have arrived at floor {1} to deliver ", elevator.Id, elevator.CurrentFloor);
            elevator.Queue.Remove(elevator.CurrentFloor);
            elevator.AreDoorsOpen = false;
        }

        /// <summary>
        /// Adding a floor request to the elevator's queue
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="requestedFloor"></param>
        public void AddRequest(Elevator elevator, int requestedFloor)
        {
            if (!elevator.Queue.Contains(requestedFloor)) 
            {
                elevator.Queue.Add(requestedFloor);
            }  
        }

        /// <summary>
        /// updating the state of the elevator
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="currentFloor"></param>
        /// <param name="direction"></param>
        public void UpdateElevatorState(Elevator elevator, int currentFloor, Direction direction)
        {
            elevator.CurrentFloor = currentFloor;
            elevator.Direction = direction;
        }

        /// <summary>
        /// Prioritizing floor requests based on elevator's direction
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        public List<int> CheckFloorRequests(Elevator elevator)
        {
            var prioritizedQueue = new List<int>();
            if (elevator.Direction == Direction.Up)
            {
                foreach (var request in elevator.Queue)
                {
                    if (request > elevator.CurrentFloor)
                        prioritizedQueue.Add(request);
                }
                prioritizedQueue.Sort();
            }
            else if (elevator.Direction == Direction.Down)
            {
                foreach (var request in elevator.Queue)
                {
                    if (request < elevator.CurrentFloor)
                        prioritizedQueue.Add(request);
                }
                prioritizedQueue.Sort((a, b) => b.CompareTo(a));
            }
          
            return prioritizedQueue;
        }

        public void SimulateElevatorOperation(Building building, Floor requestFloor, Floor targetFloor)
        {
            // Simulate elevator operation
            foreach (var floor in building.Floors)
            {
                if (floor.HasPeopleWaiting)
                {
                    // If people are waiting on the floor, add their requests to the building's queue
                    foreach (var request in building.Queue)
                    {
                        _floorService.AddRequest(building, request.Item1, request.Item2);
                    }
                }
                Elevator elevator = _floorService.CheckElevatorAvailability(building.Elevators);
                // Check if elevator is available
                if (elevator != null)
                {
                    // If elevator is available, handle the floor events
                    _floorService.HandleFloorEvents(floor, peopleEntered: true, peopleExited: false);

                    // Update elevator state and move elevator
                    var requests = CheckFloorRequests(elevator);
                    if (requests.Count > 0)
                    {
                        for (int i = 0; i < requests.Count; i++)
                        {
                            MoveElevator(elevator, requests[i],targetFloor.FloorNumber);
                        }
                    }
                    
                }

                // Update floor display
                _floorService.UpdateFloorDisplay(targetFloor, building.Elevators);
            }
        }

        /// <summary>
        /// Handling emergency situations
        /// </summary>
        /// <param name="elevator"></param>
        public void HandleEmergency(Elevator elevator)
        {
            elevator.IsStopped = true;
            elevator.AreDoorsOpen = true;
        }
    }
}

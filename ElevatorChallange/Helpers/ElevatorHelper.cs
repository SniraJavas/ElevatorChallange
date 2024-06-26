﻿using ElevatorChallange.Interfaces;
using ElevatorChallange.Models;
using ElevatorChallange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Helpers
{
    internal class ElevatorHelper
    {
        private readonly IFloor _floorService;

        public ElevatorHelper(IFloor floorService) {
            _floorService = floorService;
        }

        /// <summary>
        /// Request an elevator to pick and drop people
        /// </summary>
        /// <param name="building"></param>
        /// <param name="elevators"></param>
        public void RequestElevator(Building building, List<Elevator> elevators)
        {
            ElevatorService elevatorService = new ElevatorService(_floorService);

            // Simulate a person requesting an elevator to their current floor
            Console.WriteLine("Enter your current floor:");
            int currentFloor;
            if (!int.TryParse(Console.ReadLine(), out currentFloor) || currentFloor <= 0 || currentFloor > building.Floors.Count)
            {
                Console.WriteLine("Invalid floor number. Please try again.");
                return;
            }

            Console.WriteLine("Enter your destination floor:");
            int destinationFloor;
            if (!int.TryParse(Console.ReadLine(), out destinationFloor) || destinationFloor <= 0 || destinationFloor > building.Floors.Count)
            {
                Console.WriteLine("Invalid floor number. Please try again.");
                return;
            }

            // Add request to building's queue

            if (building.Elevators[0].CurrentFloor > currentFloor)
            {
                building.Queue.Add(((int Floor, Models.Direction Direction))(1, Direction.Down));
                building.Elevators[0].Direction = Models.Direction.Down;
            }
            else {
                building.Queue.Add(((int Floor, Models.Direction Direction))(1, Direction.Up));
                building.Elevators[0].Direction = Models.Direction.Up;
            }

            Floor requestFloor = new Floor(currentFloor);
            elevatorService.AddRequest(elevators[0], requestFloor.FloorNumber);
            requestFloor.HasPeopleWaiting = true;

            Floor finalFloor = new Floor(destinationFloor);

           
            elevatorService.SimulateElevatorOperation(building, requestFloor, finalFloor);
        }
    }
}

using ElevatorChallange.Interfaces;
using ElevatorChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Services
{
    public class FloorService : IFloor
    {

        /// <summary>
        /// This method adds a floor request to the building's queue
        /// </summary>
        /// <param name="building"></param>
        /// <param name="requestedFloor"></param>
        /// <param name="direction"></param>
        public void AddRequest(Building building, int requestedFloor, Direction direction)
        {
            building.Queue.Add((requestedFloor, direction));
        }

        /// <summary>
        /// This method updates the status of a floor
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="hasPeopleWaiting"></param>
        public void UpdateFloorStatus(Floor floor, bool hasPeopleWaiting)
        {
            floor.HasPeopleWaiting = hasPeopleWaiting;
        }

        /// <summary>
        /// This method checks if any elevator is available to serve a floor request
        /// </summary>
        /// <param name="elevators"></param>
        /// <returns></returns>
        public Elevator? CheckElevatorAvailability(List<Elevator> elevators)
        {
            // Check if any elevator is not currently in use (e.g., not moving and doors are closed)
            foreach (var elevator in elevators)
            {
                if (elevator.IsStopped && !elevator.AreDoorsOpen)
                {
                    return elevator;
                }
            }
            return null;
        }

        /// <summary>
        ///  This method handles events on a floor, such as when people enter or exit the elevator
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="peopleEntered"></param>
        /// <param name="peopleExited"></param>
        public void HandleFloorEvents(Floor floor, bool peopleEntered, bool peopleExited)
        {
            // Handle events like people entering or exiting the elevator
            if (peopleEntered)
            {
                floor.HasPeopleWaiting = false;
            }
        }

        /// <summary>
        /// This method updates any display or indicator on the floor
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="elevators"></param>
        public void UpdateFloorDisplay(Floor floor, List<Elevator> elevators)
        {
            bool sameFloor = false;
            // Update display based on elevator positions or statuses
            foreach (var elevator in elevators)
            {
                if (elevator.CurrentFloor == floor.FloorNumber)
                {
                    Console.WriteLine($"Elevator {elevator.Id} is currently at floor {floor.FloorNumber}");
                }
            }
        }
    }
}

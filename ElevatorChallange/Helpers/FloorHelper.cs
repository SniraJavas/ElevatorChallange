using ElevatorChallange.Models;
using ElevatorChallange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Helpers
{
    public class FloorHelper
    {
        public void AddFloorRequest(Building building, FloorService floorService)
        {
            // Simulate a person adding a floor request to the building's queue
            Console.WriteLine("Enter the floor you want to go to:");
            int requestedFloor;
            if (!int.TryParse(Console.ReadLine(), out requestedFloor) || requestedFloor <= 0 || requestedFloor > building.Floors.Count)
            {
                Console.WriteLine("Invalid floor number. Please try again.");
                return;
            }

            Console.WriteLine("Enter the direction (up/down):");
            string directionInput = Console.ReadLine().ToLower();
            Direction direction;
            if (directionInput == "up")
            {
                direction = Direction.Up;
            }
            else if (directionInput == "down")
            {
                direction = Direction.Down;
            }
            else
            {
                Console.WriteLine("Invalid direction. Please enter 'up' or 'down'.");
                return;
            }

            // Add request to building's queue
         
        }
    }
}

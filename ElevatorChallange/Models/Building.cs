using ElevatorChallange.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Models
{
    public class Building
    {
        public List<(int Floor, Direction Direction)> Queue { get; set; } // Queue of floor requests with direction
        public List<Elevator> Elevators { get; set; } // List of elevators in the building
        public List<Floor> Floors { get; set; } // List of floors in the building

        public Building()
        {
            Queue = new List<(int Floor, Direction Direction)>();
            Elevators = new List<Elevator>();
            Floors = new List<Floor>();
        }

        public Building(List<(int Floor, Direction Direction)> Queue,List<Elevator> Elevators, List<Floor> Floors)
        {
            this.Queue = Queue;
            this.Elevators = Elevators;
            this.Floors = Floors;
        }
    }
}

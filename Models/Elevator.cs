using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Models
{
    public enum Direction
    {
        Up,
        Down
    }

    public class Elevator
    { 
        public int CurrentFloor { get; set; } // Where the lift is currently at
        public Direction Direction { get; set; } // Indicate whether it is going up or down
        public List<int> Queue { get; set; } // floor requests
        public bool IsStopped { get; set; } // Indicates motion whether it stopped or not
        public bool AreDoorsOpen { get; set; } // Indicates if the elevator doors are open
        public bool IsEmergency { get; set; } // Indicates if the elevator is in emergency mode

        public Elevator()
        {
            Queue = new List<int>();
        }
    }
}

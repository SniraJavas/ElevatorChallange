using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Models
{
    public class Floor
    {
        public int FloorNumber { get; set; }
        public bool HasPeopleWaiting { get; set; } 

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            HasPeopleWaiting = false;
        }
    }
}

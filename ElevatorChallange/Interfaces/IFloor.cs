using ElevatorChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Interfaces
{
    public interface IFloor
    {
        public void AddRequest(Building building, int requestedFloor, Direction direction);
        public void UpdateFloorStatus(Floor floor, bool hasPeopleWaiting);
        public Elevator CheckElevatorAvailability(List<Elevator> elevators);
        public void HandleFloorEvents(Floor floor, bool peopleEntered, bool peopleExited);
        public void UpdateFloorDisplay(Floor floor, List<Elevator> elevators);


    }
}

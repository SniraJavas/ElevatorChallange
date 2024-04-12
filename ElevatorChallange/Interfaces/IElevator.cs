using ElevatorChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Interfaces
{
    public interface IElevator
    {
        public void MoveElevator(Elevator elevator, int target, int original);
        public void AddRequest(Elevator elevator, int requestedFloor);
        public void UpdateElevatorState(Elevator elevator, int currentFloor, Direction direction);
        public List<int> CheckFloorRequests(Elevator elevator);
        public void HandleEmergency(Elevator elevator);
    }
}

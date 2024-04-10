﻿using ElevatorChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallange.Services
{
    public class ElevatorService 
    {

        /// <summary>
        /// Moving the elevator to the target floor
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="targetFloor"></param>
        public void MoveElevator(Elevator elevator, int targetFloor)
        {
            elevator.CurrentFloor = targetFloor;
            // Might have to update direction
        }

        /// <summary>
        /// Adding a floor request to the elevator's queue
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="requestedFloor"></param>
        public void AddRequest(Elevator elevator, int requestedFloor)
        {
            elevator.Queue.Add(requestedFloor);
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

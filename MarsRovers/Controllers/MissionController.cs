using MarsRovers.Controllers.Abstract;
using MarsRovers.Models;
using MarsRovers.Repositories;
using MarsRovers.Repositories.Abstract;
using MarsRovers.Services;
using MarsRovers.Services.Abstract;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Models;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Controllers
{
    internal class MissionController : IMissionController
    {
        protected IMissionService _missionService = new MissionService();
        
        public string CreatePlateau(string payload)
        {
            try
            {
                var data = payload.Split(' ');
                _missionService.CreatePlateau(int.Parse(data[0]), int.Parse(data[1]));
            }
            catch(Exception e)
            {
                return ControllerCodes.ERROR_CODE + " " + e.Message;
            }

            return ControllerCodes.OK_CODE;
        }

        public string CreateRover(string payload)
        {
            try
            {
                var data = payload.Split(' ');
                _missionService.CreateRover(int.Parse(data[0]), int.Parse(data[1]), data[2]);
            }
            catch(Exception e)
            {
                return ControllerCodes.ERROR_CODE + " " + e.Message;
            }

            return ControllerCodes.OK_CODE;
        }

        public string GetRoversPositions()
        {
            try
            {
                return _missionService.GetRoversPositions(); ;
            }
            catch(Exception e)
            {
                return ControllerCodes.ERROR_CODE + " " + e.Message;
            }
        }

        public string Reset()
        {
            try
            {
                _missionService.Reset();
            }
            catch(Exception e)
            {
                return ControllerCodes.ERROR_CODE + " " + e.Message;
            }

            return ControllerCodes.OK_CODE;
        }

        public string SetMovementInstructions(string instructions)
        {
            try
            {
                _missionService.SetMovementInstructions(instructions);
            }
            catch(Exception e)
            {
                return ControllerCodes.ERROR_CODE + " " + e.Message;
            }

            return ControllerCodes.OK_CODE;
        }
    }
}

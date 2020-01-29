using MarsRovers.Models;
using MarsRovers.Repositories;
using MarsRovers.Repositories.Abstract;
using MarsRovers.Services.Abstract;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services
{
    internal class MissionService : IMissionService
    {
        protected IModelRepository _plateauRepository = new PlateauRepository();
        protected IRoversRepository _roversRepository = new RoversRepository();

        public void CreatePlateau(int x, int y)
        {
            _plateauRepository.AddModel(new PlateauModel(x, y));
        }

        public void CreateRover(int x, int y, string direction)
        {
            _roversRepository.AddModel(new RoverModel(x, y, direction));
        }

        public string GetRoversPositions()
        {
            _roversRepository.GetModels();

            //todo

            return "";
        }

        public void Reset()
        {
            _plateauRepository.Reset();
            _roversRepository.Reset();
        }

        public void SetMovementInstructions(string instructions)
        {
            _roversRepository.UpdateRoverMovementInstructions(instructions);
        }
    }
}
}

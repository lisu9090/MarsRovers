using MarsRovers.Controllers.Abstract;
using MarsRovers.Models;
using MarsRovers.Repositories;
using MarsRovers.Repositories.Abstract;
using MarsRoversInfrastructure.Models;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Controllers
{
    internal class MissionController : IMissionController
    {
        protected IModelRepository _plateauRepository = new PlateauRepository();
        protected IRoversRepository _roversRepository = new RoversRepository();
        public int CreatePlateau(int x, int y)
        {
            _plateauRepository.AddModel(new PlateauModel(x, y));
            return 0;
        }

        public int CreateRover(int x, int y, string direction)
        {
            _roversRepository.AddModel(new RoverModel(x, y, direction));
            
            return 0;
        }

        public IEnumerable<BaseModel> GetRoversPositions()
        {
            return _roversRepository.GetModels();
        }

        public int Reset()
        {
            _plateauRepository.Reset();
            _roversRepository.Reset();

            return 0;
        }

        public int SetMovementInstructons(string instructions)
        {
            _roversRepository.UpdateRoverMovementInstructions(instructions);

            return 0;
        }
    }
}

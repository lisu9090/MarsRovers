using MarsRovers.Models;
using MarsRovers.Repositories.Abstract;
using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Repositories
{
    internal class RoversRepository : IRoversRepository
    {
        protected Stack<RoverModel> _roverStack = new Stack<RoverModel>();
        public void AddModel(BaseModel model)
        {
            if (model.GetType().Name.Contains("RoverModel"))
                _roverStack.Push((RoverModel)model);
        }

        public IEnumerable<BaseModel> GetModels()
        {
            return _roverStack;
        }

        public void Reset()
        {
            _roverStack = new Stack<RoverModel>();
        }

        public void UpdateRoverMovementInstructions(string data)
        {
            _roverStack.Peek().MovementInstructions = data;
        }
    }
}

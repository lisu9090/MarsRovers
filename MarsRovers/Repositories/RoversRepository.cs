﻿using MarsRovers.Models;
using MarsRovers.Repositories.Abstract;
using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Repositories
{
    public class RoversRepository : IRoversRepository
    {
        protected Stack<RoverModel> _roverStack = new Stack<RoverModel>();

        // RoversRepository provides access to rovers data
        // The number of contained elements is not restricted
        // provides method to update last item's movement instruciotns  

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

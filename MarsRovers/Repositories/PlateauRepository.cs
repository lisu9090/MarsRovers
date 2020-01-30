using MarsRoversInfrastructure.Models;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Repositories
{
    public class PlateauRepository : IModelRepository
    {
        protected Stack<BaseModel> _plateauStack = new Stack<BaseModel>();

        // Plateau repository provides access to Plateau data
        // It is restricted to contain only one item

        public void AddModel(BaseModel model)
        {
            if (_plateauStack.Count > 0 && !model.GetType().Name.Contains("PlateauModel"))
                return;

            _plateauStack.Push(model);
        }

        public IEnumerable<BaseModel> GetModels()
        {
            return _plateauStack;
        }

        public void Reset()
        {
            _plateauStack = new Stack<BaseModel>();
        }
    }
}

using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoversInfrastructure.Repositories
{
    public interface IModelRepository
    {
        void AddModel(BaseModel model);
        IEnumerable<BaseModel> GetModels();
        void Reset();
    }
}

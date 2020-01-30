using MarsRovers.Models;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Repositories.Abstract
{
    public interface IRoversRepository: IModelRepository
    {
        void UpdateRoverMovementInstructions(string data);
    }
}

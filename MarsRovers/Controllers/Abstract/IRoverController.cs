using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Controllers.Abstract
{
    interface IRoversController
    {
        int CreatePlateau(int x, int y);
        int CreateRover(int x, int y, string direction);
        int SetMovementInstructons(string instructions);
        IEnumerable<BaseModel> GetRoversPositions();
    }
}

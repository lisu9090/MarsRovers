using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Controllers.Abstract
{
    interface IMissionController
    {
        string CreatePlateau(string payload);
        string CreateRover(string payload);
        string SetMovementInstructions(string instructions);
        string Reset();
        string GetRoversPositions();
    }
}

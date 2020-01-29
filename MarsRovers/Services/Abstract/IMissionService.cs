using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services.Abstract
{
    interface IMissionService
    {
        void CreatePlateau(int x, int y);
        void CreateRover(int x, int y, string direction);
        void SetMovementInstructions(string instructions);
        void Reset();
        string GetRoversPositions();
    }
}

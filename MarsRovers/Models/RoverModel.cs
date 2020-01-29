using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Models
{
    internal class RoverModel : BaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public string MovementInstructions { get; set; }

        public RoverModel(int x = 0, int y = 0, string direction = "")
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction);
        }
    }
}

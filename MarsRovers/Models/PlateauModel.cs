using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Models
{
    public class PlateauModel : BaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PlateauModel(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }
}

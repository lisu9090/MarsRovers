using MarsRovers.Models;
using MarsRovers.Repositories.Abstract;
using MarsRoversInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.UnitTests.Mockups
{
    public class RoversRepositoryMockup: IRoversRepository
    {
        public List<RoverModel> Contents { get; set; }

        public RoversRepositoryMockup(bool shouldAddItem = false)
        {
            Contents = new List<RoverModel>();
            if (shouldAddItem)
            {
                var item = new RoverModel(1, 2, "N");
                item.MovementInstructions = "LMLMLMLMM";
                Contents.Add(item);
            }
        }

        public void AddModel(BaseModel model)
        {
            Contents.Add((RoverModel)model);
        }

        public IEnumerable<BaseModel> GetModels()
        {
            return Contents;
        }

        public void Reset()
        {
            Contents = new List<RoverModel>();
        }

        public void UpdateRoverMovementInstructions(string data)
        {
            Contents[Contents.Count - 1].MovementInstructions = data;
        }
    }
}

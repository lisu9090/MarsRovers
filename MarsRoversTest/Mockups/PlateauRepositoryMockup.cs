using MarsRovers.Models;
using MarsRoversInfrastructure.Models;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.UnitTests.Mockups
{
    public class PlateauRepositoryMockup : IModelRepository
    {
        public List<BaseModel> Contents { get; set; }

        public PlateauRepositoryMockup(bool shouldAddItem = false)
        {
            Contents = new List<BaseModel>();
            if (shouldAddItem)
                Contents.Add(new PlateauModel(5, 5));
        }

        public void AddModel(BaseModel model)
        {
            Contents.Add(model);
        }

        public IEnumerable<BaseModel> GetModels()
        {
            return Contents;
        }

        public void Reset()
        {
            Contents = new List<BaseModel>();
        }
    }
}

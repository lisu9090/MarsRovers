using MarsRovers.Models;
using MarsRovers.Repositories.Abstract;
using MarsRovers.Services;
using MarsRoversInfrastructure.Models;
using MarsRoversInfrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoversTest.Services
{
    public class MissionServiceTest
    {
        [Fact]
        public void CreatePlateau_Input55_UpdatesRepo() {
            //Arange
            var pRepo = new PlateauRepositoryMock();
            var rRepo = new RoversRepostiroryMock();
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = new PlateauModel(5, 5);

            //Act
            missionService.CreatePlateau(5, 5);
            var actualData = pRepo.Contents[0];

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void CreateRover_Input12N_UpdatesRepo()
        {
            //Arange
            var pRepo = new PlateauRepositoryMock();
            var rRepo = new RoversRepostiroryMock();
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = new RoverModel(1, 2, "N");

            //Act
            missionService.CreateRover(1, 2, "N");
            var actualData = rRepo.Contents[0];

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetRoversPositions_GetsItemsFromRopo_Returns13N() 
        {
            //Arange
            var pRepo = new PlateauRepositoryMock();
            var rRepo = new RoversRepostiroryMock(true);
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = "1 3 N";

            //Act
            var actualData = missionService.GetRoversPositions();

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Reset_ClearsRepos_EmptyReposLists()
        {
            //Arange
            var pRepo = new PlateauRepositoryMock(true);
            var rRepo = new RoversRepostiroryMock(true);
            var missionService = new MissionService(pRepo, rRepo);
            int expectedData = 0;

            //Act
            missionService.Reset();
            int actualData = pRepo.Contents.Count + rRepo.Contents.Count;

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void SetMovementInstructions_setsExpectedValue_UpdatesRepos()
        {
            //Arange
            var pRepo = new PlateauRepositoryMock();
            var rRepo = new RoversRepostiroryMock(true);
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = "RMMRMMRRMR";

            //Act
            missionService.SetMovementInstructions(expectedData);
            var actualData = rRepo.Contents[rRepo.Contents.Count - 1].MovementInstructions;

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        protected class RoversRepostiroryMock : IRoversRepository
        {
            public List<RoverModel> Contents { get; set; }

            public RoversRepostiroryMock(bool shouldAddItem = false)
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

        protected class PlateauRepositoryMock: IModelRepository
        {
            public List<BaseModel> Contents { get; set; }

            public PlateauRepositoryMock(bool shouldAddItem = false)
            {
                Contents = new List<BaseModel>();
                if(shouldAddItem)
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
}

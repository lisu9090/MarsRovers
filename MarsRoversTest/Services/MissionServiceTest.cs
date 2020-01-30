using MarsRovers.Models;
using MarsRovers.Repositories.Abstract;
using MarsRovers.Services;
using MarsRovers.UnitTests.Mockups;
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
            var pRepo = new PlateauRepositoryMockup();
            var rRepo = new RoversRepositoryMockup();
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = new PlateauModel(5, 5).ToString();

            //Act
            missionService.CreatePlateau(5, 5);
            var actualData = pRepo.Contents[0].ToString();

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void CreateRover_Input12N_UpdatesRepo()
        {
            //Arange
            var pRepo = new PlateauRepositoryMockup();
            var rRepo = new RoversRepositoryMockup();
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = new RoverModel(1, 2, "N").ToString();

            //Act
            missionService.CreateRover(1, 2, "N");
            var actualData = rRepo.Contents[0].ToString();

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void GetRoversPositions_GetsItemsFromRopo_Returns13N() 
        {
            //Arange
            var pRepo = new PlateauRepositoryMockup();
            var rRepo = new RoversRepositoryMockup(true);
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = "1 3 N\n";

            //Act
            var actualData = missionService.GetRoversPositions();

            //Assert
            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Reset_ClearsRepos_EmptyReposLists()
        {
            //Arange
            var pRepo = new PlateauRepositoryMockup(true);
            var rRepo = new RoversRepositoryMockup(true);
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
            var pRepo = new PlateauRepositoryMockup();
            var rRepo = new RoversRepositoryMockup(true);
            var missionService = new MissionService(pRepo, rRepo);
            var expectedData = "RMMRMMRRMR";

            //Act
            missionService.SetMovementInstructions(expectedData);
            var actualData = rRepo.Contents[rRepo.Contents.Count - 1].MovementInstructions;

            //Assert
            Assert.Equal(expectedData, actualData);
        }
    }
}

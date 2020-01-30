using MarsRovers.Controllers;
using MarsRovers.Models;
using MarsRovers.Services;
using MarsRovers.UnitTests.Mockups;
using MarsRoversInfrastructure.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRovers.UnitTests.Controllers
{
    public class MissionControllerTest
    {
        [Fact]
        public void CreatePlateau_GetsValidData_ReturnsOk()
        {
            var missionController = new MissionController();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionController.CreatePlateau("5 5");

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void CreatePlateau_GetsInvalidData_ReturnsError()
        {
            var missionController = new MissionController();
            var expectedData = ControllerCodes.ERROR_CODE;

            var actualData = missionController.CreatePlateau("a b c");

            Assert.Contains(expectedData, actualData);
        }

        [Fact]
        public void CreateRover_GetsValidData_ReturnsOk()
        {
            var missionController = new MissionController();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionController.CreateRover("5 5 S");

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void CreateRover_GetsInvalidData_ReturnsError()
        {
            var missionController = new MissionController();
            var expectedData = ControllerCodes.ERROR_CODE;

            var actualData = missionController.CreateRover("a b c");

            Assert.Contains(expectedData, actualData);
        }

        [Fact]
        public void GetRoversPosition_CallsService_Returns13N_51E()
        {
            var rMock = new RoversRepositoryMockup(true);
            rMock.Contents.Add(new RoverModel(3, 3, "E") { MovementInstructions = "MMRMMRMRRM" });
            var missionController = new MissionController(new MissionService(new PlateauRepositoryMockup(), rMock));
            var expectedData = "5 1 E\n1 3 N\n";

            var actualData = missionController.GetRoversPositions();

            Assert.Contains(expectedData, actualData);
        }

        [Fact]
        public void Reset_InvokesReset_ReturnsOk()
        {
            var missionController = new MissionController();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionController.Reset();

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void SetMovementInstructions_InvokesSetMovementInstructions_ReturnsOk()
        {
            var rMock = new RoversRepositoryMockup();
            rMock.Contents.Add(new RoverModel(3, 3, "E") { MovementInstructions = "MMRMMRMRRM" });
            var missionController = new MissionController(new MissionService(new PlateauRepositoryMockup(), rMock));
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionController.SetMovementInstructions("LMLMLMLMM");

            Assert.Equal(expectedData, actualData);
        }
    }
}

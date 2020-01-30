using MarsRovers.Controllers;
using MarsRovers.Services;
using MarsRovers.UnitTests.Mockups;
using MarsRovers.Views;
using MarsRoversInfrastructure.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRovers.UnitTests.Views
{
    public class MissionViewTest
    {
        [Fact]
        public void Process_ReceivePlateauData_ReturnsOk()
        {
            var missionView = new MissionView();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionView.Process("5 5");

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceiveRoverData_ReturnsOk()
        {
            var missionView = new MissionView();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionView.Process("5 5 n");

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceiveMovementData_ReturnsOk()
        {
            var missionView = new MissionView(
                new MissionController(
                    new MissionService(
                        new PlateauRepositoryMockup(), new RoversRepositoryMockup(true))));
            
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionView.Process("lmlmlmlmm");

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceivePrintCode_ReturnsEmptyString()
        {
            var missionView = new MissionView();
            var expectedData = "";

            var actualData = missionView.Process(ViewCodes.PRINT_CODE);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceiveResetCode_ReturnsOk()
        {
            var missionView = new MissionView();
            var expectedData = ControllerCodes.OK_CODE;

            var actualData = missionView.Process(ViewCodes.RESET_CODE);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceiveExitCode_ReturnsExitCode()
        {
            var missionView = new MissionView();
            var expectedData = ViewCodes.EXIT_CODE;

            var actualData = missionView.Process(ViewCodes.EXIT_CODE);

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void Process_ReceiveWeridData_ReturnsUnrecognizedCode()
        {
            var missionView = new MissionView();
            var expectedData = ViewCodes.UNRECOGNIZED_CODE;

            var actualData = missionView.Process("-5 a 22");

            Assert.Equal(expectedData, actualData);
        }
    }
}

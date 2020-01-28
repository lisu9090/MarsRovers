using System;
using System.Collections.Generic;
using System.Text;
using MarsRovers.Controllers;
using MarsRovers.Controllers.Abstract;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Views;

namespace MarsRovers.Views
{
    internal class MissionView : IView
    {
        protected IMissionController _controller = new MissionController();
        public string Process(string input)
        {
            string output = "";

            switch (input)
            {
                case "5 5":
                    _controller.CreatePlateau(5, 5);
                    break;
                case "1 2 N":
                    _controller.CreateRover(1, 2, "n");
                    break;
                case "LMLML":
                    _controller.SetMovementInstructons(input);
                    break;
                case ViewCodes.RESET_CODE:
                    _controller.Reset();
                    output = ViewCodes.RESET_CODE;
                    break;
                case ViewCodes.EXIT_CODE:
                    output = ViewCodes.EXIT_CODE;
                    break;
                default:
                    output = ViewCodes.UNRECOGNIZED_CODE;
                    break;
            }

            return output;
        }
    }
}

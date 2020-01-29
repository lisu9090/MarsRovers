using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MarsRovers.Controllers;
using MarsRovers.Controllers.Abstract;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Views;

namespace MarsRovers.Views
{
    internal class MissionView : IView
    {
        protected IMissionController _controller = new MissionController();
        protected readonly Regex _plateauRegex = new Regex(@"^\d \d$", RegexOptions.IgnoreCase);
        protected readonly Regex _roverRegex = new Regex(@"^\d \d [NESW]$", RegexOptions.IgnoreCase);
        protected readonly Regex _instructionsRegex = new Regex(@"^[LRM]+ $", RegexOptions.IgnoreCase);
       
        public string Process(string input)
        {
            string output = "";

            switch (input.Trim().ToUpper())
            {
                case var value when _plateauRegex.IsMatch(value):
                    output = _controller.CreatePlateau(value);
                    break;
                case var value when _roverRegex.IsMatch(value):
                    output = _controller.CreateRover(value);
                    break;
                case var value when _instructionsRegex.IsMatch(value):
                    output = _controller.SetMovementInstructions(input);
                    break;
                case ViewCodes.PRINT_CODE:
                    output = _controller.GetRoversPositions();
                    break;
                case ViewCodes.RESET_CODE:
                    output = _controller.Reset();
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

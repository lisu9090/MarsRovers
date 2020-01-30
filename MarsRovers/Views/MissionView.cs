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
    public class MissionView : IView
    {
        protected IMissionController _controller;

        // Nubers used to crate Plateau have to contains up to 3 digits e.g. 123 
        protected readonly Regex _plateauRegex = new Regex(@"^\d{1,3} \d{1,3}$", RegexOptions.IgnoreCase);

        // Nubers used to crate Rover have to contains up to 3 digits e.g. 123. Direction is one of {N, E, S, W}
        protected readonly Regex _roverRegex = new Regex(@"^\d{1,3} \d{1,3} [NESW]$", RegexOptions.IgnoreCase);

        // Instructions consists of one or more {L, R, M} signs
        protected readonly Regex _instructionsRegex = new Regex(@"^[LRM]+$", RegexOptions.IgnoreCase);

        public MissionView() : this(new MissionController()) { }

        public MissionView(IMissionController controller)
        {
            _controller = controller;
        }

        // View maps user input to propper controller actions

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

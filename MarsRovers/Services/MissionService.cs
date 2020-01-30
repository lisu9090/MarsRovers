using MarsRovers.Models;
using MarsRovers.Repositories;
using MarsRovers.Repositories.Abstract;
using MarsRovers.Services.Abstract;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Services
{
    public class MissionService : IMissionService
    {
        protected IModelRepository _plateauRepository;
        protected IRoversRepository _roversRepository;
        protected readonly List<string> _compasPositions = new List<string>() {"N", "E", "S", "W" };

        // Service contains bussiness logic
        // It receives data from controller and process it

        public MissionService() : this(new PlateauRepository(), new RoversRepository()) { }

        public MissionService(IModelRepository plateauRepository, IRoversRepository roversRepository)
        {
            _plateauRepository = plateauRepository;
            _roversRepository = roversRepository;
        }

        public void CreatePlateau(int x, int y)
        {
            _plateauRepository.AddModel(new PlateauModel(x, y));
        }

        public void CreateRover(int x, int y, string direction)
        {
            _roversRepository.AddModel(new RoverModel(x, y, direction));
        }

        public string GetRoversPositions()
        {
            var rovers = _roversRepository.GetModels();
            StringBuilder output = new StringBuilder();

            foreach(var item in rovers)
            {
                // Using Insert insead of Append because collection is stack
                output.Insert(0, CalculateRoverFinalPosition((RoverModel)item) + "\n");
            }

            return output.ToString();
        }

        public void Reset()
        {
            _plateauRepository.Reset();
            _roversRepository.Reset();
        }

        public void SetMovementInstructions(string instructions)
        {
            _roversRepository.UpdateRoverMovementInstructions(instructions);
        }

        // Calculates and returns rovers final position
        protected string CalculateRoverFinalPosition(RoverModel rover)
        {
            //Coppy rover
            var tmp = (RoverModel)rover.Clone();
            //Get instructions and split by M. Received array contains only spin instructions
            var instructionsArray = tmp.MovementInstructions.ToUpper().Split("M");

            for (int i = 0; i < instructionsArray.Length; i++)
            {
                if (!string.IsNullOrEmpty(instructionsArray[i]))
                {
                    // If element is not empty spin it
                    SpinRover(ref tmp, instructionsArray[i]);
                }
                if (i == instructionsArray.Length - 1)
                {
                    // Prevent from moving forward in last iteration (side effect of Split method)
                    break;
                }

                // Move in forward in current direcion
                MoveRover(ref tmp);
            }

            return tmp.ToString();
        }

        protected void SpinRover(ref RoverModel rover, string spinInstructions)
        {
            var directionIndex = 0;

            // Find index of current direction in _compasPositions
            // Loop through instructuions
            // If spin left then use decremented direction index to set rovers direction
            // If spin right then use incremented direction index to set rovers direction
            // Don't forget about arrays edges (Index out of range)

            foreach (var instruction in spinInstructions.ToUpper())
            {
                directionIndex = _compasPositions.IndexOf(rover.Direction.ToUpper());

                if(("" + instruction).Equals("L"))
                    rover.Direction = _compasPositions[--directionIndex < 0 ? _compasPositions.Count - 1 : directionIndex];
                else if (("" + instruction).Equals("R"))
                    rover.Direction = _compasPositions[++directionIndex == _compasPositions.Count ? 0 : directionIndex];
            }
        }

        protected void MoveRover(ref RoverModel rover)
        {
            switch (rover.Direction.ToUpper())
            {
                case "N":
                    rover.Y++;
                    break;
                case "E":
                    rover.X++;
                    break;
                case "S":
                    rover.Y--;
                    break;
                case "W":
                    rover.X--;
                    break;
            }
        }
    }
}

using MarsRovers.Views;
using MarsRoversInfrastructure.Facade;
using MarsRoversInfrastructure.Views;
using System;

namespace MarsRovers
{
    public class Program
    {
        static void Main(string[] args)
        {
            IView view = new MissionView();

            Console.WriteLine("Program has started! Waiting for data... Type {0} to reset or {1} to exit program.\n", ViewCodes.RESET_CODE, ViewCodes.EXIT_CODE);
            string userInput = "", programOutput = "";

            while(true)
            {
                userInput = Console.ReadLine();
                programOutput = view.Process(userInput);

                if (programOutput.Equals(ViewCodes.EXIT_CODE))
                    return;

                Console.WriteLine(programOutput);
            }
        }
    }
}

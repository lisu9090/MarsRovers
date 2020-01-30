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
            // This application is split up into four leyers:
            // Views acts alike to "User Itefrace" - routes user input to proper controllers actions
            // Controllers mediate between presentation layer and bussines logic layer -
            // - preprocess data for Services and response with operation staus to Views
            // Services contains bussines logic of the application
            // Repositories provides access to the data

            // Data shared between all items in project is located in MarsRoversInfrastructure class library project

            IView view = new MissionView(); 

            Console.WriteLine("Program has started! Waiting for data... Type {0} to reset or {1} to exit program.\n", ViewCodes.RESET_CODE, ViewCodes.EXIT_CODE);
            string userInput = "", programOutput = "";

            while(true)
            {
                // Main method passes all user's input to view and displays to user returned by View output
                userInput = Console.ReadLine();
                programOutput = view.Process(userInput);

                if (programOutput.Equals(ViewCodes.EXIT_CODE))
                    return;

                Console.WriteLine(programOutput);
            }
        }
    }
}

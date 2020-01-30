# MarsRovers
Sample .NET Core application

This application is split up into four leyers:
- Views acts alike to "User Itefrace" - routes user input to proper controllers actions
- Controllers mediate between presentation layer and bussines logic layer - preprocess data for Services and response with operation staus to Views
- Services contains bussines logic of the application
- Repositories provides access to the data

Data shared between all items in project is located in MarsRoversInfrastructure class library project

Unit test are stored in MarsRovers.UnitTests project

Usage:
- The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0.
- The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input. The first line gives the rover's position, and the second line is a series of instructions telling the rover how to explore the plateau.
- Position input consists of two numbers (x, y) and letter direction letter {N, E, S, W}
- Movement instructions are L - spin left, R- spin right, M - move forward

example:
- input
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

- expected output:
1 3 N
5 1 E

commands:
- PRINT - prints rovers positions
- RESET - clear all data
- EXIT - exit the program

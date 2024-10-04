// Written by: Henrik Henriksson (AQ7150)


using ConsoleAppAss2.Classes;
using ConsoleAppAss2.Classes.Assignment2A;
using ConsoleAppAss2.Classes.Assignment2B;
using ConsoleAppAss2.Classes.Assignment2C;
using ConsoleAppAss2.Classes.Assignment2D;

Console.WriteLine("Starting Application");

TemperatureConverter temperatureConverter = new();
temperatureConverter.Start();
Utility.AwaitUserInput();


StringFunctions stringFunctions = new();
stringFunctions.Start();
Utility.AwaitUserInput();

MathWork mathWork = new();
mathWork.Start();
Utility.AwaitUserInput();

//Scheduler scheduler = new();
//scheduler.Run();
//Utility.AwaitUserInput();
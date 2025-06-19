using System;
using System.Collections.Generic;

namespace TrainStationUFV
{
    public class Program
    {
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("┌─────────────────────────────────────────┐");
            Console.WriteLine("│┼┼┼┼┼┼┼┼┼┼┼┼ UFV Train Station ┼┼┼┼┼┼┼┼┼┼┼│");
            Console.WriteLine("│┼───────────────────────────────────────┼┤");
            Console.WriteLine("││                                       ││");
            Console.WriteLine("││    1. Load trains from file.          ││");
            Console.WriteLine("││    2. Start simulation.               ││");
            Console.WriteLine("││    3. Display system state.           ││");
            Console.WriteLine("││    4. Exit.                           ││");
            Console.WriteLine("││                                       ││");
            Console.WriteLine("│┼───────────────────────────────────────┼┤");
            Console.WriteLine("│┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼│");
            Console.WriteLine("└─────────────────────────────────────────┘");
            Console.Write("Choose an option: ");
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter the number of platforms to initialize: ");
            int numPlatforms = int.Parse(Console.ReadLine() ?? "3");

            Station station = new Station(numPlatforms);
            int option = 0;

            while (option != 4)
            {
                DisplayMenu();
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ReadLine();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        List<Train> loadedTrains = TrainLoader.LoadTrainsFromFile();
                        foreach (var train in loadedTrains)
                            station.AddTrain(train);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Starting simulation...");
                        Console.ReadLine();

                        while (!station.AllTrainsDocked())
                        {
                            station.AdvanceTick();
                            station.DisplayStatus();
                            Console.WriteLine("\nPress any key to continue to next tick...");
                            Console.ReadKey();
                        }

                        Console.WriteLine("\nAll trains are docked. Simulation complete.");
                        Console.ReadLine();
                        break;

                    case 3:
                        station.DisplayStatus();
                        Console.WriteLine("\nPress any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

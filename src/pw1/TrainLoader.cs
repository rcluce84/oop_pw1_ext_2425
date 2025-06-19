using System;
using System.Collections.Generic;
using System.IO;

namespace TrainStationUFV
{
    public static class TrainLoader
    {
        public static List<Train> LoadTrainsFromFile()
        {
            List<Train> loadedTrains = new List<Train>();

            try
            {
                Console.Write("Enter the path to the train CSV file: ");
                string? filePath = Console.ReadLine(); //train.csv

                if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                {
                    Console.WriteLine("File not found or invalid path.");
                    Console.ReadLine();
                    return loadedTrains;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length < 5)
                    {
                        Console.WriteLine("Invalid line format. Skipping.");
                        continue;
                    }

                    string id = fields[0];
                    int arrivalTime = int.Parse(fields[1]);
                    string type = fields[2].ToLower();

                    if (type == "passenger")
                    {
                        int numberOfCarriages = int.Parse(fields[3]);
                        int capacity = int.Parse(fields[4]);

                        loadedTrains.Add(new PassengerTrain(
                            id,
                            Train.TrainStatus.EnRoute,
                            arrivalTime,
                            type,
                            numberOfCarriages,
                            capacity));
                    }
                    else if (type == "freight")
                    {
                        int maxWeight = int.Parse(fields[3]);
                        string freightType = fields[4];

                        loadedTrains.Add(new FreightTrain(
                            id,
                            Train.TrainStatus.EnRoute,
                            arrivalTime,
                            type,
                            maxWeight,
                            freightType));
                    }
                    else
                    {
                        Console.WriteLine($"Unknown train type '{type}' in line: {line}");
                    }
                }

                Console.WriteLine("\n Trains loaded successfully.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                Console.ReadLine();
            }

            return loadedTrains;
        }
    }
}

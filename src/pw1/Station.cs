using System;
using System.Collections.Generic;

namespace TrainStationUFV
{
    public class Station
    {
        private List<Platform> platforms;
        private List<Train> trains;

        public Station(int numberOfPlatforms)
        {
            platforms = new List<Platform>();
            for (int i = 1; i <= numberOfPlatforms; i++)
                platforms.Add(new Platform($"Platform {i}"));

            trains = new List<Train>();
        }

        public void AddTrain(Train train)
        {
            trains.Add(train);
        }

        public void AdvanceTick()
        {
            Console.WriteLine("\nAdvancing 15 minutes...\n");

            foreach (Train train in trains)
            {
                if (train.GetStatus() == Train.TrainStatus.EnRoute)
                {
                    int newTime = train.GetArrivalTime() - 15;
                    train.SetArrivalTime(newTime <= 0 ? 0 : newTime);

                    if (train.GetArrivalTime() <= 0)
                        train.SetStatus(Train.TrainStatus.Waiting);
                }
            }

            foreach (Platform platform in platforms)
                platform.AdvanceTick();

            AssignTrainsToPlatforms();
        }

        private void AssignTrainsToPlatforms()
        {
            foreach (Train train in trains)
            {
                if (train.GetStatus() == Train.TrainStatus.Waiting)
                {
                    foreach (Platform platform in platforms)
                    {
                        if (platform.GetStatus() == Platform.PlatformStatus.Free)
                        {
                            if (platform.RequestPlatform(train))
                            {
                                train.SetStatus(Train.TrainStatus.Docking);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool AllTrainsDocked()
        {
            foreach (Train train in trains)
                if (train.GetStatus() != Train.TrainStatus.Docked)
                    return false;

            return true;
        }

        public void DisplayStatus()
        {
            Console.Clear();
            Console.WriteLine("=== STATION STATUS ===\n");

            Console.WriteLine("Platforms:");
            foreach (Platform p in platforms)
                p.Display();

            Console.WriteLine("\nTrains:");
            foreach (Train t in trains)
                t.Display();
        }

        public List<Train> GetTrainList() => trains;
    }
}

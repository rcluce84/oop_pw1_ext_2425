using System;

namespace TrainStationUFV
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        public PassengerTrain(string id, TrainStatus status, int arrivalTime, string type, int numberOfCarriages, int capacity)
            : base(id, status, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public override void Display()
        {
            Console.Write("[Passenger Train] --> ");
            base.Display();
        }

        public int GetCarriages() { return this.numberOfCarriages; }
        public int GetCapacity() { return this.capacity; }
    }
}

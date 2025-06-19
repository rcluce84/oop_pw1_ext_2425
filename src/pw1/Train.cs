using System;

namespace TrainStationUFV
{
    public abstract class Train
    {
        protected string id;
        protected TrainStatus status;
        protected int arrivalTime; // in minutes
        protected string type;

        public enum TrainStatus : ushort
        {
            EnRoute = 0,
            Waiting = 1,
            Docking = 2,
            Docked = 3
        }

        public Train(string id, TrainStatus status, int arrivalTime, string type)
        {
            this.id = id;
            this.status = status;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{GetId()} - Status: {GetStatus()}, Arrival in: {GetArrivalTime()} min");
        }

        // Getters and Setters
        public string GetId() { return this.id; }
        public TrainStatus GetStatus() { return this.status; }
        public void SetStatus(TrainStatus status) { this.status = status; }
        public int GetArrivalTime() { return this.arrivalTime; }
        public void SetArrivalTime(int time) { this.arrivalTime = time; }
        public string GetTrainType() { return this.type; }
    }
}

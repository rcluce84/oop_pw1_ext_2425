//This is going to be almost a copy from my last pw1 simply because i really know how it works and im confident working with it.
using System;

namespace TrainStationUFV
{
    public class Platform
    {
        private string id;
        private PlatformStatus status;
        private Train? currentTrain;
        private int ticksRemaining;
        private const int defaultDockingTime = 2;

        public enum PlatformStatus : ushort
        {
            Free = 0,
            Occupied = 1
        }

        public Platform(string id)
        {
            this.id = id;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.ticksRemaining = 0;
        }

        // Getters and Setters
        public string GetId() { return this.id; }
        public PlatformStatus GetStatus() { return this.status; }
        public void SetStatus(PlatformStatus status) { this.status = status; }
        public Train? GetCurrentTrain() { return this.currentTrain; }
        public int GetTicksRemaining() { return this.ticksRemaining; }

        public bool RequestPlatform(Train train)
        {
            if (this.status == PlatformStatus.Free)
            {
                this.status = PlatformStatus.Occupied;
                this.currentTrain = train;
                this.ticksRemaining = defaultDockingTime;
                return true;
            }
            return false;
        }

        public void AdvanceTick()
        {
            if (this.status == PlatformStatus.Occupied && this.ticksRemaining > 0)
            {
                ticksRemaining--;
                if (ticksRemaining == 0 && currentTrain != null)
                {
                    currentTrain.SetStatus(Train.TrainStatus.Docked);
                    ReleasePlatform();
                }
            }
        }

        public void ReleasePlatform()
        {
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
        }

        public void Display()
        {
            string trainInfo = currentTrain != null ? currentTrain.GetId() : "None";
            Console.WriteLine($"- {id}: {status}; Train: {trainInfo}; Ticks left: {ticksRemaining}");
        }
    }
}


using System;

namespace TrainStationUFV
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(string id, TrainStatus status, int arrivalTime, string type, int maxWeight, string freightType)
            : base(id, status, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public override void Display()
        {
            Console.Write("[Freight Train] --> ");
            base.Display();
        }

        public int GetMaxWeight() { return this.maxWeight; }
        public string GetFreightType() { return this.freightType; }
    }
}

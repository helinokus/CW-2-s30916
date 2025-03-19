using Project1_APBD.Exceptions;
using Project1_APBD.Interfaces;

namespace Project1_APBD.Containers
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; }

        public LiquidContainer(bool isHazardous, double height, double depth, double maxLoad)
            : base("L", height, 100, depth, maxLoad)
        {
            IsHazardous = isHazardous;
        }

        public override void LoadContainer(double mass)
        {
            double maxAllowedLoad;
            if (IsHazardous)
            {
                maxAllowedLoad = MaxLoad / 2;
            }
            else
            {
                maxAllowedLoad = MaxLoad * 0.9;
            }

            if (MassOfProducts + mass > maxAllowedLoad)
            {
                NotifyHazard($"this container is overloaded {SerialNumber}. Max: {maxAllowedLoad} kg.");
                throw new OverfillException($"Container {SerialNumber} is overloaded.");
            }

            MassOfProducts += mass;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine(message);
        }
    }
}
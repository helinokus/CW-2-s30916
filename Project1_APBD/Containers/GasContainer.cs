using Project1_APBD.Exceptions;
using Project1_APBD.Interfaces;

namespace Project1_APBD.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; } 
    public GasContainer( double pressure,double height, double depth, double maxLoad) : base("G", height, 125, depth, maxLoad)
    {
        Pressure = pressure;
    }
    

    public override void UnloadContainer()
    {
        MassOfProducts = Math.Round(MassOfProducts * 0.05 , 4);
    }

    public override void LoadContainer(double mass)
    {
        if (MassOfProducts + mass > MaxLoad)
        {
            NotifyHazard($"[ALERT] Container is overloaded {SerialNumber}. max: {MaxLoad} kg.");
            throw new OverfillException($"Container {SerialNumber} is overloaded.");
        }

        MassOfProducts += mass;
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine(message);
    }
}
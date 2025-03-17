namespace Project1_APBD.Containers;

public abstract class Container
{
    private static int _id = 0;
    public double MassOfProducts { get; set; }
    public double Height { get; set; }
    public double OwnMass { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    public string CreateSerialNumber(String s)
    {
        int id = _id + 1;
        _id = id;
        return "KON-" + s + "-" + id;
    }

    protected Container(string s, double height, double ownMass, double depth, double maxLoad)
    {
        SerialNumber = CreateSerialNumber(s);
        Height = height;
        OwnMass = ownMass;
        Depth = depth;
        MassOfProducts = 0;
        MaxLoad = maxLoad;
    }

    public virtual void LoadContainer(double mass)
    {
        if (MassOfProducts + mass > MaxLoad)
        {
            throw new OverflowException("Too much products for this container");
        }
        MassOfProducts += mass;
    }

    public virtual void UnloadContainer()
    {
        MassOfProducts = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber}:  {MassOfProducts} inside";
    }
}
namespace Project1_APBD.Containers;

public abstract class Container
{
    private static Dictionary<string, int>
        _idCounters = new Dictionary<string, int>(); // Отдельный счетчик для каждого типа

    public double MassOfProducts { get; set; }
    public double Height { get; set; }
    public double OwnMass { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    private string CreateSerialNumber(string type)
    {
        if (!_idCounters.ContainsKey(type))
        {
            _idCounters[type] = 0;
        }

        _idCounters[type]++;

        return $"KON-{type}-{_idCounters[type]}";
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
        return
            $"{SerialNumber}:  {MassOfProducts} inside, {Height}m height, {OwnMass}kg own mass, with depth {Depth}m and max load {MaxLoad}";
    }
}
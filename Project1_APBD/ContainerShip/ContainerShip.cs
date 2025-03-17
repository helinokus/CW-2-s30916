using Microsoft.VisualBasic.CompilerServices;
using Project1_APBD.Containers;

namespace Project1_APBD.ContainerShip;

public class ContainerShip
{
    public List<Container> _Containers { get; set; } = new List<Container>();
    public double Speed { get; set; }
    public int MaxCountOfContainers { get; set; }
    public double MaxWeightOfContaines { get; set; }

    public ContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContaines)
    {
        Speed = speed;
        MaxCountOfContainers = maxCountOfContainers;
        MaxWeightOfContaines = maxWeightOfContaines;
    }


    public void addContainer(Container container)
    {
        _Containers.Add(container);
    }

    public void removeContainer(Container container)
    {
        _Containers.Remove(container);
    }

    public List<Container> allContainers()
    {
        return _Containers;
    }
}
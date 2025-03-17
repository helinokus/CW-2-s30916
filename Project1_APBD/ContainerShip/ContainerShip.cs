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


    public void AddContainer(Container container)
    {
        _Containers.Add(container);
    }

    public void RemoveContainer(Container container)
    {
        _Containers.Remove(container);
    }

    public void SwapContainers(string from, string to, List<Container> containers)
    {
        int idFrom = _Containers.FindIndex(s=> s.SerialNumber.EndsWith(from));
        Container? c = containers.Find(s=> s.SerialNumber.EndsWith(to));
        if (c != null)
        {
            _Containers.RemoveAt(idFrom);
            _Containers.Insert(idFrom, c);
        }
        else
        {
            Console.WriteLine($"No such container for {from} or {to}");
        }
        
    }

    public void SwapShips(string to, List<Container> containers)
    {
        
    }

    public List<Container> AllContainers()
    {
        return _Containers;
    }
}
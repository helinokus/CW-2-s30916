using Microsoft.VisualBasic.CompilerServices;
using Project1_APBD.Containers;

namespace Project1_APBD.ContainerShip;

public class ContainerShip
{
    private static int _Id = 0;
    public List<Container> Containers { get; set; } = new List<Container>();
    public double Speed { get; set; }
    public int MaxCountOfContainers { get; set; }
    public double MaxWeightOfContainers { get; set; }

    public ContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContainers)
    {
        Speed = speed;
        MaxCountOfContainers = maxCountOfContainers;
        MaxWeightOfContainers = maxWeightOfContainers;
    }


    public void AddContainer(Container container)
    {
        if (!Containers.Contains(container))
        { 
            Containers.Add(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void SwapContainers(string from, string to, List<Container> containers)
    {
        int idFrom = Containers.FindIndex(s=> s.SerialNumber.EndsWith(from));
        Container? c = containers.Find(s=> s.SerialNumber.EndsWith(to));
        if (c != null)
        {
            Containers.RemoveAt(idFrom);
            Containers.Insert(idFrom, c);
        }
        else
        {
            Console.WriteLine($"No such container for {from} or {to}");
        }
        
    }
    

    public string SwapShips(string cont, ContainerShip to)
    {
        Container? c = Containers.Find(s=> s.SerialNumber.EndsWith(cont));
        if (c == null)
        {
            return $"No such container for {cont} or {to}";
        }
        to.AddContainer(c);
        Containers.Remove(c);
        return null;
    }

    public List<Container> AllContainers()
    {
        return Containers;
    }

    private void IncrementId()
    {
        _Id = ++_Id;
    }

    public override string ToString()
    {
        IncrementId();
        return "Ship " + _Id;
    }
}
using Microsoft.VisualBasic.CompilerServices;
using Project1_APBD.Containers;

namespace Project1_APBD.ContainerShip;

public class ContainerShip
{
    private static int _lastId = 1;
    private int _id;
    public List<Container> Containers { get; set; } = new List<Container>();
    public double Speed { get; set; }
    public int MaxCountOfContainers { get; set; }
    public double MaxWeightOfContainers { get; set; }

    public ContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContainers)
    {
        _id = _lastId++;
        Speed = speed;
        MaxCountOfContainers = maxCountOfContainers;
        MaxWeightOfContainers = maxWeightOfContainers;
    }


    public void AddContainer(Container container)
    {
        double totalWeight = Containers.Sum(c => c.MassOfProducts);
        if (Containers.Count >= MaxCountOfContainers || totalWeight + container.MassOfProducts > MaxWeightOfContainers)
        {
            Console.WriteLine("Cannot add container: ship capacity exceeded.");
            return;
        }

        if (!Containers.Contains(container))
        {
            Containers.Add(container);
        }
        else
        {
            Console.WriteLine($"Container {container.SerialNumber} is already on the ship.");
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void SwapContainers(int which)
    {
        Containers.RemoveAt(which-1);
    }


    public string SwapShips(int index, ContainerShip to)
    {
        Container? c = Containers[index-1];
        if (c == null)
        {
            return $"No such container for {index} or {to}";
        }


        to.AddContainer(c);
        Containers.Remove(c);
        return null;
    }

    public void LoadListOfContainers(List<Container> container)
    {
        if (IsAddList(container))
        {
            foreach (var c in container)
            {
                AddContainer(c);
            }
        }
    }

    public bool IsAddList(List<Container> container)
    {
        double totalWeight = Containers.Sum(c => c.MassOfProducts);
        double totalWeightOfContainers = Containers.Sum(c => c.MassOfProducts);
        int countOfContainers = container.Count;
        int countExistedContainers = Containers.Count;
        if (MaxWeightOfContainers > totalWeight + totalWeightOfContainers
            && MaxCountOfContainers >= countOfContainers + countExistedContainers)
        {
            return true;
        }
        return false;
    }

    public void AllContainers()
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Containers[i]}");
        }
    }

    public bool IsContainers()
    {
        if (Containers.Count>0)
        {
            return true;
        }
        return false;
    }
    
    


    public override string ToString()
    {
        return $"Ship {_id} with containers count: {Containers.Count} "; //TODO: сделать какие именно конты
    }
}
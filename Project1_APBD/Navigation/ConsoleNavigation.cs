using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public class ConsoleNavigation : IConsoleNavigation
{
    protected List<Container> Containers { get; set; } = new List<Container>();
    protected List<ContainerShip.ContainerShip> ContainerShips { get; set; } = new List<ContainerShip.ContainerShip>();
    public List<Container> FreeContainers { get; set; } = new List<Container>();

    public ContainerShip.ContainerShip CreateContainerShip(double speed, int maxCountOfContainers,
        double maxWeightOfContainers)
    {
        ContainerShips.Add(new ContainerShip.ContainerShip(speed, maxCountOfContainers, maxWeightOfContainers));
        return ContainerShips.Last();
    }

    public LiquidContainer CreateLiquidContainer(bool isHazardous, double height, double depth,
        double maxLoad)
    {
        LiquidContainer liquidContainer = new LiquidContainer(isHazardous, height, depth, maxLoad);
        Containers.Add(liquidContainer);
        FreeContainers.Add(liquidContainer);
        return (LiquidContainer)Containers.Last();
    }

    public GasContainer CreateGasContainer(double pressure, double height, double depth, double maxLoad)
    {
        GasContainer gasContainer = new GasContainer(pressure, height, depth, maxLoad);
        Containers.Add(gasContainer);
        FreeContainers.Add(gasContainer);
        return (GasContainer)Containers.Last();
    }

    public FridgeContainer CreateFridgeContainer(double height, double depth, double maxLoad,
        string typeOfProduct)
    {
        FridgeContainer fridgeContainer = new FridgeContainer(height, depth, maxLoad, typeOfProduct);
        Containers.Add(fridgeContainer);
        FreeContainers.Add(fridgeContainer);
        return (FridgeContainer)Containers.Last();
    }

    public void LoadContainer(int containerNumber, double mass)
    {
        Container container = Containers[containerNumber - 1];
        container.LoadContainer(mass);
    }

    public void UnloadContainer(int containerNumber)
    {
        Container container = Containers[containerNumber - 1];
        container.UnloadContainer();
    }

    public void LoadContainerToShip(int containerIndex, int shipNumber)
    {
        if (containerIndex < 0 || containerIndex - 1 >= FreeContainers.Count)
        {
            Console.WriteLine("Invalid container index.");
            return;
        }

        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container container = FreeContainers[containerIndex - 1];

        ship.AddContainer(container);

        if (ship.Containers.Contains(container))
        {
            FreeContainers.RemoveAt(containerIndex - 1);
        }
        else
        {
            Console.WriteLine($"Failed to add container {container.SerialNumber} to the ship.");
        }
    }

    public void RemoveContainerFromShip(int containerNumber, int shipNumber)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container container = Containers[containerNumber - 1];
        ship.RemoveContainer(container);
        FreeContainers.Add(container);
    }

    public void SwapContainer(int shipNumber, int containerNumber1, int containerNumber2)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container containerWhich = Containers[containerNumber1 - 1];
        Container containerToSwap = Containers[containerNumber2 - 1];
        ship.SwapContainers(containerWhich.SerialNumber, containerToSwap.SerialNumber,
            Containers);
    }

    public void SwapShips(int shipFrom, int shipTo, int contNumber)
    {
        ContainerShip.ContainerShip ship1 = ContainerShips[shipFrom];
        ContainerShip.ContainerShip ship2 = ContainerShips[shipTo];
        Container container = Containers[contNumber];
        ship1.SwapShips(container.SerialNumber, ship2);
    }

    public void GetAllContainers()
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Containers[i]}");
        }
    }

    public void GetAllShips()
    {
        for (int i = 0; i < ContainerShips.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {ContainerShips[i]}");
        }
    }

    public bool IsContainers()
    {
        if (Containers.Count > 0)
        {
            return true;
        }

        return false;
    }

    public bool IsShips()
    {
        if (ContainerShips.Count > 0)
        {
            return true;
        }

        return false;
    }

    public bool IsFree()
    {
        if (FreeContainers.Count > 0)
        {
            return true;
        }

        return false;
    }

    public ContainerShip.ContainerShip GetShipById(int shipId)
    {
        return ContainerShips[shipId - 1];
    }

    public Container GetContainerById(int shipId)
    {
        return Containers[shipId - 1];
    }

    public void AllFreeContainers()
    {
        for (int i = 0; i < FreeContainers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {FreeContainers[i]}");
        }
    }

    public void LoadListOfContainers(int shipId, List<Container> containers)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipId - 1];
        if (ship.IsAddList(containers))
        {
            ship.LoadListOfContainers(containers);
            FreeContainers.RemoveAll(container => containers.Contains(container));
        }
        else
        {
            Console.WriteLine("Cannot load container: ship capacity exceeded.");
        }
    }
}
using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public class ConsoleNavigation : IConsoleNavigation
{
    protected List<Container> Containers { get; set; } = new List<Container>();
    protected List<ContainerShip.ContainerShip> ContainerShips { get; set; } = new List<ContainerShip.ContainerShip>();
    protected List<Container> FreeContainers { get; set; } = new List<Container>();

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

    public void LoadContainerToShip(int containerNumber, int shipNumber)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container container = Containers[containerNumber - 1];
        if (FreeContainers.Contains(container))
        {
            ship.AddContainer(container);
            FreeContainers.Remove(container);
        }
        else
        {
            Console.WriteLine($"Container {container} already loaded ");
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
        Container containerWhich = Containers[containerNumber1];
        Container containerToSwap = Containers[containerNumber2];
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
        foreach (Container container in Containers)
        {
            Console.WriteLine("     " + container);
        }
    }

    public void GetAllShips()
    {
        foreach (ContainerShip.ContainerShip ship in ContainerShips)
        {
            Console.WriteLine("     " + ship);
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

    public bool IsShips()
    {
        if (ContainerShips.Count>0)
        {
            return true;
        }
        return false;
    }

    public bool IsFree()
    {
        if (FreeContainers.Count>0)
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

    public void AllFreeConteiners()
    {
        foreach (Container container in FreeContainers)
        {
            Console.WriteLine("    " + container);
            
        }
    }

    public void LoadListOfContainers(List<Container> containers)
    {
        throw new NotImplementedException();
    }
}
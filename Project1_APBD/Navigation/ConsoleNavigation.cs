using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public class ConsoleNavigation : IConsoleNavigation
{
    protected List<Container> Containers { get; set; } = new List<Container>();
    protected List<ContainerShip.ContainerShip> ContainerShips { get; set; } = new List<ContainerShip.ContainerShip>();

    public ContainerShip.ContainerShip CreateContainerShip(double speed, int maxCountOfContainers,
        double maxWeightOfContainers)
    {
        ContainerShips.Add(new ContainerShip.ContainerShip(speed, maxCountOfContainers, maxWeightOfContainers));
        return ContainerShips.Last();
    }

    public LiquidContainer CreateLiquidContainer(bool isHazardous, double height, double ownMass, double depth,
        double maxLoad)
    {
        Containers.Add(new LiquidContainer(isHazardous, height, ownMass, depth, maxLoad));
        return (LiquidContainer)Containers.Last();
    }

    public GasContainer CreateGasContainer(double pressure, double height, double ownMass, double depth, double maxLoad)
    {
        Containers.Add(new GasContainer(pressure, height, ownMass, depth, maxLoad));
        return (GasContainer)Containers.Last();
    }

    public FridgeContainer CreateFridgeContainer(double height, double ownMass, double depth, double maxLoad,
        string typeOfProduct)
    {
        Containers.Add(new FridgeContainer(height, ownMass, depth, maxLoad, typeOfProduct));
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
        ship.AddContainer(container);
    }

    public void RemoveContainerFromShip(int containerNumber, int shipNumber)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container container = Containers[containerNumber - 1];
        ship.RemoveContainer(container);
    }

    public void SwapContainer(int shipNumber, int containerNumber1, int containerNumber2)
    {
        ContainerShip.ContainerShip ship = ContainerShips[shipNumber - 1];
        Container containerWhich = Containers[containerNumber1];
        Container containerToSwap = Containers[containerNumber2];
        ship.SwapContainers(containerWhich.SerialNumber, containerToSwap.SerialNumber,
            Containers); //TODO: Change part serial to ALL
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
            Console.WriteLine(container);
        }
    }

    public void GetAllShips()
    {
        foreach (ContainerShip.ContainerShip ship in ContainerShips)
        {
            Console.WriteLine(ship);
        }
    }

    public void LoadListOfContainers(List<Container> containers)
    {
        throw new NotImplementedException();
    }
}
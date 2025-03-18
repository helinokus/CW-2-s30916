using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;
public class ConsoleNavigation : IConsoleNavigation 
{

    public List<Container> Containers { get; set; } = new List<Container>();
    public List<ContainerShip.ContainerShip> ContainerShips { get; set; } = new List<ContainerShip.ContainerShip>();
    public ContainerShip.ContainerShip CreateContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContainers)
    {
        ContainerShips.Add(new ContainerShip.ContainerShip(speed, maxCountOfContainers, maxWeightOfContainers));
        return ContainerShips.Last();
    }

    public LiquidContainer CreateContainer(bool isHazardous, double height, double ownMass, double depth, double maxLoad)
    {
        throw new NotImplementedException();
    }

    public GasContainer CreateGasContainer(double pressure, double height, double ownMass, double depth, double maxLoad)
    {
        throw new NotImplementedException();
    }

    public FridgeContainer CreateFridgeContainer(double height, double ownMass, double depth, double maxLoad,
        string typeOfProduct)
    {
        throw new NotImplementedException();
    }
}
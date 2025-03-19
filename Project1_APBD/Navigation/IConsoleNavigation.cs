using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public interface IConsoleNavigation
{
    ContainerShip.ContainerShip CreateContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContainers);
    LiquidContainer CreateLiquidContainer(bool isHazardous, double height, double depth, double maxLoad);
    GasContainer CreateGasContainer(double pressure,double height, double depth, double maxLoad);
    FridgeContainer CreateFridgeContainer(double height, double depth, double maxLoad,
        string typeOfProduct);
    
    
    
    
}
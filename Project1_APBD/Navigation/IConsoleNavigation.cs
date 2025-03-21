using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public interface IConsoleNavigation
{
    ContainerShip.ContainerShip CreateContainerShip(double speed, int maxCountOfContainers, double maxWeightOfContainers);
    LiquidContainer CreateLiquidContainer(bool isHazardous, double height, double depth, double maxLoad);
    GasContainer CreateGasContainer(double pressure,double height, double depth, double maxLoad);
    FridgeContainer CreateFridgeContainer(double height, double depth, double maxLoad,
        string typeOfProduct);

    void LoadContainer(int containerNumber, double mass);
    void UnloadContainer(int containerNumber);
    void LoadContainerToShip(int containerIndex, int shipNumber);
    void RemoveContainerFromShip(int containerNumber, int shipNumber);
    void SwapContainer(int shipNumber, int containerNumber1, int containerNumber2);
    void SwapShips(int shipFrom, int shipTo, int contNumber);
    void GetAllContainers();
    void GetAllShips();
    bool IsContainers();
    bool IsShips();
    bool IsFree();
    ContainerShip.ContainerShip GetShipById(int shipId);
    Container GetContainerById(int shipId);
    void AllFreeContainers();
    void LoadListOfContainers(int shipId, List<Container> containers);




}
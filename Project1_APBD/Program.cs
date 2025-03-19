using System.IO.MemoryMappedFiles;
using Project1_APBD.Containers;
using Project1_APBD.ContainerShip;
using Project1_APBD.Navigation;


// ConsoleNavigation navigation = new ConsoleNavigation();
//
// navigation.CreateContainerShip(1, 5, 1000);
// navigation.CreateContainerShip(1, 5, 1000);
// navigation.CreateContainerShip(1, 5, 1000);
// navigation.CreateContainerShip(1, 5, 1000);
//
// navigation.CreateLiquidContainer(true, 1, 5, 5, 10);
// navigation.CreateLiquidContainer(true, 1, 5, 5, 10);
// navigation.CreateGasContainer(2, 1, 5, 5, 10);
// navigation.CreateFridgeContainer(4, 1, 5, 5, "Fish");
//
// navigation.LoadContainerToShip(2, 3);
//
// navigation.GetAllShips();
//
// navigation.GetAllContainers();
CommandNavigation commandNavigation = new CommandNavigation();
while (true)
{
    commandNavigation.StartNavigation();
    
}

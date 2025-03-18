
using Project1_APBD.Containers;
using Project1_APBD.ContainerShip;
using Project1_APBD.Navigation;


ConsoleNavigation navigation = new ConsoleNavigation();

navigation.CreateContainerShip(1, 5, 1000);
navigation.CreateContainerShip(1, 5, 1000);
navigation.CreateContainerShip(1, 5, 1000);
navigation.CreateContainerShip(1, 5, 1000);

foreach (var navigationContainer in navigation.ContainerShips)
{
    Console.WriteLine(navigationContainer);
}



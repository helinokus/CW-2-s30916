
using Project1_APBD.Containers;
using Project1_APBD.ContainerShip;

LiquidContainer liquidContainer = new LiquidContainer(true, 2, 500,2, 1000);
liquidContainer.LoadContainer(400);
GasContainer gasContainer = new GasContainer(5, 2, 500, 1000, 1000);
gasContainer.LoadContainer(200);

FridgeContainer fridgeContainer = new FridgeContainer(10, 200, 500, 1000, "Meat", 2);
fridgeContainer.LoadContainer(100);

ContainerShip containerShip = new ContainerShip(10,8,10);
containerShip.addContainer(liquidContainer);
containerShip.addContainer(gasContainer);
foreach (var allContainer in containerShip.allContainers())
{
    Console.WriteLine(allContainer);
}
containerShip.removeContainer(liquidContainer);

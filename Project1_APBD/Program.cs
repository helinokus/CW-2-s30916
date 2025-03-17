
using Project1_APBD.Containers;
using Project1_APBD.ContainerShip;

List<Container> containers = new List<Container>();

LiquidContainer liquidContainer = new LiquidContainer(true, 2, 500,2, 1000);
liquidContainer.LoadContainer(400);
containers.Add(liquidContainer);
GasContainer gasContainer = new GasContainer(5, 2, 500, 1000, 1000);
containers.Add(gasContainer);
gasContainer.LoadContainer(200);
gasContainer.LoadContainer(300);


FridgeContainer fridgeContainer = new FridgeContainer(10, 200, 500, 1000, "Meat", 2);
containers.Add(fridgeContainer);
fridgeContainer.LoadContainer(100);

LiquidContainer liquidContainer2 = new LiquidContainer(true, 2, 500, 1000, 1000);
containers.Add(liquidContainer2);
liquidContainer2.LoadContainer(100);
LiquidContainer liquidContainer3 = new LiquidContainer(true, 2, 500, 1000, 1000);
containers.Add(liquidContainer3);
liquidContainer3.LoadContainer(100);

ContainerShip containerShip = new ContainerShip(10,8,10);
containerShip.AddContainer(liquidContainer);
containerShip.AddContainer(gasContainer);

foreach (var allContainer in containerShip.AllContainers())
{
    Console.WriteLine(allContainer.ToString());
}

Console.WriteLine("");
containers.ForEach(s=>Console.WriteLine(s.ToString()));

containerShip.SwapContainers("L-1", "C-1", containers);

Console.WriteLine("");

foreach (var allContainer in containerShip.AllContainers())
{
    Console.WriteLine(allContainer.ToString());
}
containerShip.RemoveContainer(liquidContainer);


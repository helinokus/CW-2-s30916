using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Project1_APBD.Containers;

namespace Project1_APBD.Navigation;

public class CommandNavigation
{
    private ConsoleNavigation navigation = new ConsoleNavigation();
    

    public void StartNavigation()
    {
        Console.WriteLine("Starting navigation");
        Console.WriteLine("1.Create a Ship");
        string? val = Console.ReadLine();
        if (val == "1")
        {
            CreateNewShip();
            Console.WriteLine("New ship created");
        }
    }


    private void EnterNavigation()
    {
        Console.WriteLine("List of ships");
        navigation.GetAllShips();
        Console.WriteLine("List of containers");
        navigation.GetAllContainers();
        Console.WriteLine("List of commands: ");
        if (navigation.IsContainers() && navigation.IsShips())
        {
            Console.WriteLine("1. Add a Ship");
            Console.WriteLine("2. Modify ship");
            Console.WriteLine("3. Add a container");
            Console.WriteLine("4. Modify container");
            string? val = Console.ReadLine();
            if (val == "1")
            {
                CreateNewShip();
            }
            else if (val == "2")
            {
                ModifyShips();
            }
            else if (val == "3")
            {
                AddContainer();
            }
            else if (val == "4")
            {
                ModifyContainer();
            }
            else
            {
                Console.WriteLine("Invalid input");
                EnterNavigation();
            }
        }
        else if (navigation.IsShips() && !navigation.IsContainers())
        {
            Console.WriteLine("1. Add a Ship");
            Console.WriteLine("2. Modify ship");
            Console.WriteLine("3. Add a container");
            int val = Convert.ToInt32(Console.ReadLine());
            if (val == 1)
            {
                CreateNewShip();
            }

            else if (val == 2)
            {
                ModifyShips();
            }
            else if (val == 3)
            {
                AddContainer();
            }
        }
    }

    private void ModifyContainer()
    {
        Console.WriteLine("List of containers");
        navigation.GetAllContainers();
        Console.WriteLine("Choose container");
        int valCont = Convert.ToInt32(Console.ReadLine());
        Container container = navigation.GetContainerById(valCont);
        Console.WriteLine("1. Load container");
        Console.WriteLine("2. Unload container");
        int val = Convert.ToInt32(Console.ReadLine());
        if (val == 1)
        {
            Console.WriteLine("Enter mass");
            double mass = Convert.ToInt32(Console.ReadLine());
            container.LoadContainer(mass);
        }else if (val == 2)
        {
            container.UnloadContainer();
        }
        EnterNavigation();

        
    }


    private void ModifyShips()
    {
        Console.WriteLine("Choose a ship to modify");
        navigation.GetAllShips();
        int value = Convert.ToInt32(Console.ReadLine());
        ContainerShip.ContainerShip findShip = navigation.GetShipById(value);
        if (findShip.Containers.Count > 0)
        {
            Console.WriteLine("1. Add container");
            Console.WriteLine("2. Remove container");
            Console.WriteLine("3. Swap container");
            int value2 = Convert.ToInt32(Console.ReadLine());
            if (value2 == 1)
            {
                navigation.GetAllContainers();
                Console.WriteLine("Choose a container");
                int value3 = Convert.ToInt32(Console.ReadLine());
                Container findContainer = navigation.GetContainerById(value3);
                findShip.AddContainer(findContainer);
            }
            else if (value2 == 2)
            {
                foreach (Container container in findShip.Containers)
                {
                    Console.WriteLine(container);
                }

                Console.WriteLine("Choose a container");
                int value4 = Convert.ToInt32(Console.ReadLine());
                findShip.Containers.Remove(findShip.Containers.ElementAt(value4 - 1));
                findShip.RemoveContainer(findShip.Containers.ElementAt(value4 - 1));
            }
        }
        else
        {
            Console.WriteLine("You can only add a container, choose which one");
            if (navigation.IsFree())
            {
                navigation.AllFreeConteiners();
                int valueCont = Convert.ToInt32(Console.ReadLine());
                Container findContainer = navigation.GetContainerById(valueCont);
                findShip.AddContainer(findContainer);
                EnterNavigation();
            }
            else
            {
                AddContainer();
            }
        }
    }


    private void CreateNewShip()
    {
        Console.WriteLine("Write parametrs for new ship ");
        Console.Write("Enter ships speed: ");
        double speed = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter ships max amount of containers: ");
        int maxCountOfContainers = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter max weight of containers: ");
        double MaxWeight = Convert.ToDouble(Console.ReadLine());
        navigation.CreateContainerShip(speed, maxCountOfContainers, MaxWeight);
        EnterNavigation();
    }

    private void AddContainer()
    {
        Console.WriteLine("Choose a type of container");
        Console.WriteLine("1. Liquid Container");
        Console.WriteLine("2. Gas Container");
        Console.WriteLine("3. Fridge Container");
        int type = Convert.ToInt32(Console.ReadLine());
        if (type == 1)
        {
            Console.WriteLine("Is hazardous? (1-yes, 0 - no)");
            bool value = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Height");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Depth");
            double d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max Load");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            navigation.CreateLiquidContainer(value, h, d, maxLoad);
        }
        else if (type == 2)
        {
            Console.WriteLine("Pressure amount?");
            double pressure = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Height");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Depth");
            double d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max Load");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            navigation.CreateGasContainer(pressure, h, d, maxLoad);
        }
        else if (type == 3)
        {
            Console.WriteLine("Height");
            double h = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Depth");
            double d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max Load");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Type");
            string productType = Console.ReadLine();
            navigation.CreateFridgeContainer(h, d, maxLoad, productType);
        }

        EnterNavigation();
    }
}
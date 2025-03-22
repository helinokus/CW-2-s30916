using Project1_APBD.Containers;

namespace Project1_APBD.Navigation
{
    public class CommandNavigation
    {
        private ConsoleNavigation _navigation = new ConsoleNavigation();

        public void StartNavigation()
        {
            Console.WriteLine("Starting Navigation");
            EnterNavigation();
        }
        private void EnterNavigation()
        {
            while (true)
            {
                Console.WriteLine("===============================================================");
                Console.WriteLine("");
                Console.WriteLine("List of ships:");
                _navigation.GetAllShips();
                Console.WriteLine("");
                Console.WriteLine("List of all containers:");
                _navigation.GetAllContainers();
                Console.WriteLine("");
                Console.WriteLine("List of Free containers:");
                _navigation.AllFreeContainers();
                
                Console.WriteLine("\nList of commands:");
                Console.WriteLine("1. Add a Ship");
                Console.WriteLine("2. Add a Container");
                if (_navigation.IsShips() && _navigation.IsContainers())
                {
                    Console.WriteLine("3. Load container to ship");
                    Console.WriteLine("4. Remove container from ship");
                    Console.WriteLine("5. Swap containers on ship");
                    Console.WriteLine("6. Swap containers between ships");
                    Console.WriteLine("7. Show all containers on a ship");
                    Console.WriteLine("8. Modify container");
                    Console.WriteLine("9. Add list of containers");
                    Console.WriteLine("10. Exit");
                }
                else
                {
                    Console.WriteLine("3. Exit");
                }

                string? val = Console.ReadLine();
                if (val == "1")
                {
                    CreateNewShip();
                }
                else if (val == "2")
                {
                    AddContainer();
                }
                else if (val == "3" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    LoadContainerToShip();
                }
                else if (val == "4" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    RemoveContainerFromShip();
                }
                else if (val == "5" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    SwapContainersOnShip();
                }
                else if (val == "6" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    SwapContainersBetweenShips();
                }
                else if (val == "7" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    ShowContainersOnShip();
                }
                else if (val == "8" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    ModifyContainer();
                }
                else if (val == "9" && _navigation.IsShips() && _navigation.IsContainers())
                {
                    LoadListContainers();
                }
                else if (val == "10" || val == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input or not enough ships/containers.");
                }
            }
        }

        private void CreateNewShip()
        {
            Console.WriteLine("Write parameters for new ship:");
            Console.Write("Enter ship's speed: ");
            double speed = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter ship's max amount of containers: ");
            int maxCountOfContainers = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter max weight of containers: ");
            double maxWeight = Convert.ToDouble(Console.ReadLine());
            _navigation.CreateContainerShip(speed, maxCountOfContainers, maxWeight);
            Console.WriteLine("New ship created.");
        }

        private void AddContainer()
        {
            Console.WriteLine("Choose a type of container:");
            Console.WriteLine("1. Liquid Container");
            Console.WriteLine("2. Gas Container");
            Console.WriteLine("3. Fridge Container");
            int type = Convert.ToInt32(Console.ReadLine());
            if (type == 1)
            {
                Console.WriteLine("Is hazardous? (1-yes, 0-no)");
                bool isHazardous = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Height:");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Depth:");
                double depth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Max Load:");
                double maxLoad = Convert.ToDouble(Console.ReadLine());
                _navigation.CreateLiquidContainer(isHazardous, height, depth, maxLoad);
            }
            else if (type == 2)
            {
                Console.WriteLine("Pressure amount:");
                double pressure = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Height:");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Depth:");
                double depth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Max Load:");
                double maxLoad = Convert.ToDouble(Console.ReadLine());
                _navigation.CreateGasContainer(pressure, height, depth, maxLoad);
            }
            else if (type == 3)
            {
                Console.WriteLine("Height:");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Depth:");
                double depth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Max Load:");
                double maxLoad = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Type of product:");
                string productType = Console.ReadLine();
                _navigation.CreateFridgeContainer(height, depth, maxLoad, productType);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void LoadContainerToShip()
        {
            Console.WriteLine("Choose a container to load:");
            _navigation.AllFreeContainers();
            int containerIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a ship to load the container to:");
            _navigation.GetAllShips();
            int shipNumber = Convert.ToInt32(Console.ReadLine());
            _navigation.LoadContainerToShip(containerIndex, shipNumber);
        }

        private void RemoveContainerFromShip()
        {
            Console.WriteLine("Choose a ship to remove container from:");
            _navigation.GetAllShips();
            int shipId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a container to remove:");
            _navigation.GetShipById(shipId).AllContainers();
            int containerId = Convert.ToInt32(Console.ReadLine());
            _navigation.RemoveContainerFromShip(containerId, shipId);
        }

        private void SwapContainersOnShip()
        {
            Console.WriteLine("Choose a ship to swap containers on:");
            _navigation.GetAllShips();
            int shipId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose first container to swap:");
            _navigation.GetShipById(shipId).AllContainers();
            int containerId1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose second container to swap:");
            _navigation.AllFreeContainers();
            int containerId2 = Convert.ToInt32(Console.ReadLine());
            _navigation.SwapContainer(shipId, containerId1, containerId2);
        }

        private void SwapContainersBetweenShips()
        {
            Console.WriteLine("Choose ship to swap container FROM:");
            _navigation.GetAllShips();
            int shipId1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose ship to swap containers TO:");
            _navigation.GetAllShips();
            int shipId2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose container to swap:");
            _navigation.GetShipById(shipId1).AllContainers();
            int containerId = Convert.ToInt32(Console.ReadLine());
            _navigation.SwapShips(shipId1, shipId2, containerId);
        }

        private void ShowContainersOnShip()
        {
            Console.WriteLine("Choose a ship to show containers:");
            _navigation.GetAllShips();
            int shipId = Convert.ToInt32(Console.ReadLine());
            ContainerShip.ContainerShip ship = _navigation.GetShipById(shipId);
            Console.WriteLine($"Containers on ship {shipId}:");
            ship.AllContainers();
        }

        private void ModifyContainer()
        {
            Console.WriteLine("Choose a container to modify:");
            _navigation.GetAllContainers();
            int containerId = Convert.ToInt32(Console.ReadLine());
            Container container = _navigation.GetContainerById(containerId);

            Console.WriteLine("1. Load container");
            Console.WriteLine("2. Unload container");
            string? val = Console.ReadLine();

            if (val == "1")
            {
                Console.WriteLine("Enter mass to load:");
                double mass = Convert.ToDouble(Console.ReadLine());
                container.LoadContainer(mass);
            }
            else if (val == "2")
            {
                container.UnloadContainer();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void LoadListContainers()
        {
            Console.WriteLine("Choose containers to load, separated by spaces:");
            _navigation.AllFreeContainers();
            string containerIndexesInput = Console.ReadLine();
            int[] indexes = containerIndexesInput.Split(' ').Select(int.Parse).ToArray();

            List<Container> containersToLoad = new List<Container>();
            foreach (int index in indexes)
            {
                if (index > 0 && index <= _navigation.FreeContainers.Count)
                {
                    containersToLoad.Add(_navigation.FreeContainers[index - 1]);
                }
                else
                {
                    Console.WriteLine($"Invalid container index: {index}");
                    return;
                }
            }

            Console.WriteLine("Choose a ship to load the containers to:");
            _navigation.GetAllShips();
            int shipNumber = Convert.ToInt32(Console.ReadLine());


            _navigation.LoadListOfContainers(shipNumber, containersToLoad);
        }
    }
}
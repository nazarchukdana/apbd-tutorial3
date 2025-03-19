namespace apbd_tutorial3;


class Program
{
    static void Main()
    {
        try
        {
            ContainerShip ship1 = new ContainerShip(25, 10, 7);
            ContainerShip ship2 = new ContainerShip(30, 2, 60000);

            Console.WriteLine("Created two container ships.\n");

            GasContainer gasContainer = new GasContainer(5, 200, 1000, 250, 5000);
            LiquidContainer liquidContainer = new LiquidContainer(true, 180, 800, 200, 4000);
            LiquidContainer liquidContainer2 = new LiquidContainer(false, 180, 800, 200, 4000);
            RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer("Bananas", 15,220, 900, 240, 4500);
            Console.WriteLine("Created gas, liquid, and refrigerated containers.\n");
            
            //emtying gas container
            Console.WriteLine("Loading the gas container");
            gasContainer.Load(2000);
            gasContainer.Print();
            Console.WriteLine($"\nEmptying the gas container, in the container there should be {2000*0.05}");
            gasContainer.Emptying();
            gasContainer.Print();
            Console.WriteLine();
            //load over the maxPayload
            try
            {
                Console.WriteLine("Trying to load the gas container over maxPayload");
                gasContainer.Load(5000);
                Console.WriteLine("Successful loading the gas container over maxPayload");
            }
            catch (OverfillException ex)
            {
                Console.WriteLine("Error while loading the gas container: "+ ex.Message);
            }
            gasContainer.Print();
            Console.WriteLine();
            
            //loading hazardous liquid
            Console.WriteLine("Loading the liquid container");
            liquidContainer.Load(2000);
            liquidContainer.Print();
            Console.WriteLine("\nLoading hazardous liquid container over allowed load");
            liquidContainer.Load(1000);
            liquidContainer.Print();
            Console.WriteLine("\nLoading another liquid container over allowed load");
            liquidContainer2.Load(3700);
            liquidContainer2.Print();
            Console.WriteLine();
            
            //creating illegal refrigerated containers
            try
            {
                Console.WriteLine("Trying to create a refrigerated container with illegal product");
                RefrigeratedContainer refrigeratedContainer2 =
                    new RefrigeratedContainer("Cookies", 15, 220, 900, 240, 4500);
                Console.WriteLine("Successful creating a refrigerated container with illegal product");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while creating a refrigerated container: "+ ex.Message);
            }
            Console.WriteLine();
            try
            {
                Console.WriteLine("Trying to create a refrigerated container with illegal temperature");
                RefrigeratedContainer refrigeratedContainer2 =
                    new RefrigeratedContainer("Bananas", 10, 220, 900, 240, 4500);
                Console.WriteLine("Successful creating a refrigerated container with illegal temperature");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while creating a refrigerated container: "+ ex.Message);
            }
            Console.WriteLine();
            
            //loading the refrigerated container 
            Console.WriteLine("Loading the refrigerated container");
            refrigeratedContainer.Load(1000);
            refrigeratedContainer.Print();
            Console.WriteLine();
            
            //loading containers onto ship1
            ship1.LoadContainer(gasContainer);
            ship1.LoadContainer(liquidContainer);
            ship1.LoadContainer(refrigeratedContainer);
            Console.WriteLine("Loaded containers onto ship1.");
            Console.WriteLine("Ship 1 Info:");
            ship1.PrintShipInfo();
            Console.WriteLine();
            // removing containers 
            ship1.RemoveContainer(gasContainer);
            ship1.RemoveContainer(liquidContainer);
            ship1.RemoveContainer(refrigeratedContainer);
            Console.WriteLine("Removed containers onto ship1.");
            Console.WriteLine("Ship 1 Info:");
            ship1.PrintShipInfo();
            Console.WriteLine();
            //adding list of containers
            var containers = new List<Container>();
            containers.Add(gasContainer);
            containers.Add(liquidContainer);
            containers.Add(refrigeratedContainer);
            ship1.LoadContainers(containers);
            Console.WriteLine("Loaded the list of containers");
            Console.WriteLine("Ship 1 Info:");
            ship1.PrintShipInfo();
            Console.WriteLine();
            
            //loading container that is over the max weight
            try
            {
                Console.WriteLine("Trying load the container that is over max weight");
                ship1.LoadContainer(liquidContainer2);
                Console.WriteLine("Successful loading the container onto ship1.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading the container that is over max weight: " + ex.Message);
            }
            
            Console.WriteLine("Ship 1 Info:");
            ship1.PrintShipInfo();
            Console.WriteLine();
            
            //loading to ship 2
            Console.WriteLine("Loading the container onto ship2");
            ship2.LoadContainer(liquidContainer2);
            Console.WriteLine("Ship 2 Info:");
            ship2.PrintShipInfo();
            Console.WriteLine();
            //remove of non-existent container
            try
            {
                Console.WriteLine("Trying remove container with non-existent serial number");
                ship1.RemoveContainer("KON-X-999");
                Console.WriteLine("Successful remove container with non-existent serial number");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while removing a non-existent container: "+ex.Message);
            }

            Console.WriteLine();
            try
            {
                Console.WriteLine("Trying remove non-existent container");
                ship1.RemoveContainer(liquidContainer2);
                Console.WriteLine("Successful remove non-existent container");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while removing a non-existent container: " + ex.Message);
            }
            Console.WriteLine();
            
            //transfering container 
            
            ship1.TransferContainer(ship2, gasContainer);
            Console.WriteLine("Transferred a gas container from ship1 to ship2.");

            Console.WriteLine("Ship 1 Info After Transfer:");
            ship1.PrintShipInfo();
            Console.WriteLine("\nShip 2 Info After Receiving Transfer:");
            ship2.PrintShipInfo();
            Console.WriteLine();
            
            //transfering container over the max number of containers
            try
            {
                Console.WriteLine("Trying transfer a container over the max number of containers");
                ship1.TransferContainer(ship2, "KON-C-4");
                Console.WriteLine("Successful transfer a container over the max number of containers");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while transfering a container over the max number of containers: " + ex.Message);
            }
            //replacing container 
            RefrigeratedContainer replacementContainer = new RefrigeratedContainer("Cheese", 8, 200, 950, 250, 4600);
            Console.WriteLine("\nCreated a new refrigerated container for replacement.\n");
            
            string containerToReplaceSerial = ship2.Containers[0].SerialNumber;
            ship2.ReplaceContainer(containerToReplaceSerial, replacementContainer);
            Console.WriteLine($"Replaced container {containerToReplaceSerial} in ship2 with the new container.");
            
            Console.WriteLine("\nFinal Ship 1 Info:");
            ship1.PrintShipInfo();
            Console.WriteLine("\nFinal Ship 2 Info:");
            ship2.PrintShipInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: "+ex.Message);
        }
    }
}

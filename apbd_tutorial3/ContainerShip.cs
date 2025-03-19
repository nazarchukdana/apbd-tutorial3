namespace apbd_tutorial3;

public class ContainerShip
{
    public int MaxSpeed { get; set; }
    public int MaxContainerNum { get; set; }
    public double MaxWeight { get; set; }
    public  List<Container> Containers { get; set; }

    public ContainerShip(int maxSpeed, int maxContainerNum, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerNum = maxContainerNum;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerNum || GetTotalWeight() + (container.Weight + container.MassCargo)/1000 > MaxWeight)
            throw new Exception("Cannot load: Ship capacity exceeded.");
        Containers.Add(container);
    }
    public void LoadContainers(List<Container> containers)
    {
        containers.ForEach(container => LoadContainer(container));
    }
    
    public void RemoveContainer(string serialNumber)
    {
        var containerToRemove = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (containerToRemove == null)
        {
            throw new Exception($"Container with serial number {serialNumber} not found.");
        }
        RemoveContainer(containerToRemove);
    }
    public void RemoveContainer(Container container)
    {
        if (!Containers.Contains(container))
        {
            throw new Exception("The container is not part of the ship.");
        }
        Containers.Remove(container);
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index >= 0)
        {
            Containers[index] = newContainer;
        }
        else
        {
            throw new Exception($"Container with serial number {serialNumber} not found.");
        }
    }
    public void TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        TransferContainer(targetShip, container);
    }

    public void TransferContainer(ContainerShip targetShip, Container container)
    {
        if (!Containers.Contains(container))
        {
            throw new Exception("The container is not part of the ship.");
        }
        targetShip.LoadContainer(container);
        RemoveContainer(container);
    }

    public double GetTotalWeight()
    {
        return Containers.Sum(c => c.Weight + c.MassCargo)/1000;
        
    }
    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship (Speed: {MaxSpeed} knots, Containers: {Containers.Count}/{MaxContainerNum}, Total Weight: {GetTotalWeight()}/{MaxWeight} tons)" );
        Containers.ForEach(c => c.Print());
    }
}

namespace apbd_tutorial3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure{get;set;}

    public GasContainer(double pressure, double mass, double height, double weight, double depth, double maxPayload) :
        base(mass, height, weight, depth, maxPayload, "G")
    {
        Pressure = pressure;
    }
    public GasContainer(double pressure, double height, double depth, double weight, double maxPayload)
        : this(pressure, 0, height, weight, depth, maxPayload) { }

    public void Notify()
    {
        Console.WriteLine($"Hazardous Situation in Container No. {SerialNumber}");
    }

    public override void Emptying()
    {
        MassCargo *= 0.05;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($", pressure: {Pressure} atmospheres");
    }
    
    
    
}
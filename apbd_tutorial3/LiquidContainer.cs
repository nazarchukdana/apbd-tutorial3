namespace apbd_tutorial3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(bool isHazardous, double mass, double height, double weight, double depth, double maxPayload)
        : base(mass, height, weight, depth, maxPayload, "L")
    {
        IsHazardous = isHazardous;
    }
    public LiquidContainer(bool isHazardous, double height, double weight, double depth, double maxPayload)
        : this(isHazardous, 0, height, weight, depth, maxPayload) { }
    public void Notify()
    {
        Console.WriteLine($"Hazardous Situation in Container No. {SerialNumber}");
    }

    public override void Load(double mass)
    {
        double maxAllowedLoad = IsHazardous ? MaxPayload * 0.50 : MaxPayload * 0.90;
        if (MassCargo + mass > maxAllowedLoad) Notify();
        base.Load(mass);
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine();
    }
}
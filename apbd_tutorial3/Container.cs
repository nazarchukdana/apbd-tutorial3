namespace apbd_tutorial3;
public abstract class Container
{
    private static int _nextId = 1;
    public double MassCargo {get;set;}
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }

    public string SerialNumber{ get; set; }
    public double MaxPayload { get; set; }

    public Container(double mass, double height, double weight, double depth, double maxPayload, string type )
    {
        MassCargo = mass;
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxPayload = maxPayload;
        SerialNumber = $"KON-{type}-{_nextId++}";
    }

    public Container(double height, double weight, double depth, double maxPayload, string type)
     : this(0, height, weight, depth, maxPayload, type) { }
    public virtual void Emptying()
    {
        MassCargo = 0;
    }

    public virtual void Load(double mass)
    {
        if (MassCargo + mass > MaxPayload) throw new OverfillException($"Cannot load Container No. {SerialNumber} beyond the allowed limit.");
        MassCargo += mass;
    }

    public virtual void Print()
    {
        Console.Write($"CONTAINER {SerialNumber}, Mass Cargo: {MassCargo}/{MaxPayload} kg, height: {Height} cm, weight: {Weight} kg, depth: {Depth} cm");
    }
    
}
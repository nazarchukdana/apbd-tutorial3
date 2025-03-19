namespace apbd_tutorial3;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }

    private static Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice Cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    private double _requiredTemperature;
    public double CurrentTemperature { get; set; }

    public RefrigeratedContainer(string productType, double currentTemp, double mass, double height, double weight, double depth, double maxPayload)
        : base(mass, height, weight, depth, maxPayload, "C")
    {
        if (!ProductTemperatures.ContainsKey(productType))
            throw new Exception("Unknown product type for refrigeration.");

        ProductType = productType;
        _requiredTemperature = ProductTemperatures[productType];
        CurrentTemperature = currentTemp;

        if (CurrentTemperature < _requiredTemperature)
        {
            throw new Exception($"Temperature is too low for {productType}. Required: {_requiredTemperature}°C, Current: {CurrentTemperature}°C");
        }
    }

    public RefrigeratedContainer(string productType, double currentTemp, double height, double weight, double depth,
        double maxPayload) : this(productType, currentTemp, 0, height, weight, depth, maxPayload) { }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($", product: {ProductType}, temperature: {CurrentTemperature}");
    }
}
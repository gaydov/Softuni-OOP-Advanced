public class Ferrari : ICar
{
    private const string DefaultModel = "488-Spider";

    public Ferrari(string driverName)
    {
        this.Driver = driverName;
        this.Model = DefaultModel;
    }

    public string Driver { get; private set; }

    public string Model { get; private set; }

    public string PushBrakes()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.PushBrakes()}/{this.PushGas()}/{this.Driver}";
    }
}
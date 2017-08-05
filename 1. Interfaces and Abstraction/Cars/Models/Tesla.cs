using System.Text;

public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int batteriesCount)
        : base(model, color)
    {
        this.Battery = batteriesCount;
    }

    public int Battery { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(base.ToString());

        return sb.ToString().Trim();
    }
}
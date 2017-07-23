
public class Box<T>
{
    public Box(T value)
    {
        this.Value = value;
    }

    private T Value { get; }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

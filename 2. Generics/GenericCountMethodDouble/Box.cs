
using System;

public class Box<T> : IComparable<Box<T>>
    where T : IComparable<T>
{
    public Box(T value)
    {
        this.Value = value;
    }

    private T Value { get; }

    public int CompareTo(Box<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }
}

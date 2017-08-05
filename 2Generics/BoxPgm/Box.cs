using System.Collections.Generic;

public class Box<T>
{
    public Box()
    {
        this.Data = new Stack<T>();
    }

    public int Count
    {
        get { return this.Data.Count; }
    }

    private Stack<T> Data { get; }

    public void Add(T element)
    {
        this.Data.Push(element);
    }

    public T Remove()
    {
        T element = this.Data.Pop();
        return element;
    }
}

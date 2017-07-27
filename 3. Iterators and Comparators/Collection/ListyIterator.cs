using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> elements;
    private int currentIndex;

    public ListyIterator(IEnumerable<T> inputElements)
    {
        this.elements = new List<T>(inputElements);
    }

    public bool Move()
    {
        if (HasNext())
        {
            this.currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (this.currentIndex < this.elements.Count - 1)
        {
            return true;
        }

        return false;
    }

    public T Print()
    {
        if (this.elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        return this.elements[this.currentIndex];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in this.elements)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


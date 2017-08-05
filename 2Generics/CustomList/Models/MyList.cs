using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MyList<T> : IMyList<T>
    where T : IComparable<T>
{
    private const int InitialCapacity = 5;
    private T[] items;
    private int arrayLength;

    public MyList()
    {
        this.items = new T[InitialCapacity];
        this.arrayLength = 0;
    }

    public void Add(T element)
    {
        // If the current array is full we double it in size
        if (this.items.Length == this.arrayLength)
        {
            this.items = this.items.Concat(new T[this.items.Length]).ToArray();
        }

        this.items[this.arrayLength] = element;
        this.arrayLength++;
    }

    public T Remove(int index)
    {
        T item = this.items[index];
        this.items = this.items.Take(index).Concat(this.items.Skip(index + 1)).ToArray();
        this.arrayLength--;

        return item;
    }

    public bool Contains(T element)
    {
        foreach (T item in this.items)
        {
            if (EqualityComparer<T>.Default.Equals(item, element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        T tmp = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = tmp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        for (int i = 0; i < this.arrayLength; i++)
        {
            if (this.items[i].CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxValue = this.items[0];

        for (int i = 0; i < this.arrayLength; i++)
        {
            if (this.items[i].CompareTo(maxValue) == 1)
            {
                maxValue = this.items[i];
            }
        }

        return maxValue;
    }

    public T Min()
    {
        T minValue = this.items[0];

        for (int i = 0; i < this.arrayLength; i++)
        {
            if (this.items[i].CompareTo(minValue) == -1)
            {
                minValue = this.items[i];
            }
        }

        return minValue;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (T item in this.items.Where(i => i != null))
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString().Trim();
    }
}

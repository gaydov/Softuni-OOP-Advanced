using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : IEnumerable<T>
{
    private const int InitialCapacity = 8;
    private T[] elements;
    private int currentIndex;

    public CustomStack()
    {
        this.elements = new T[InitialCapacity];
        this.currentIndex = 0;
    }

    public void Push(IEnumerable<T> inputElements)
    {
        foreach (T element in inputElements)
        {
            // If our stack is full:
            if (this.currentIndex == this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }
    }

    public T Pop()
    {
        // If the stack is empty:
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        T popedElement = this.elements[this.currentIndex - 1];
        this.elements[this.currentIndex - 1] = default(T);
        this.currentIndex--;
        return popedElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.currentIndex - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void Resize()
    {
        Array.Resize(ref this.elements, this.elements.Length * 2);
    }
}
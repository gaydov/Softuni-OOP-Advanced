using System;

public class Scale<T>
        where T : IComparable<T>
{
    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    private T Left { get; }

    private T Right { get; }

    public T GetHavier() // wrong name due to wrong name in the Softuni's judge system
    {
        if (this.Left.CompareTo(this.Right) == 1)
        {
            return this.Left;
        }
        else if (this.Left.CompareTo(this.Right) == -1)
        {
            return this.Right;
        }
        else
        {
            return default(T);
        }
    }
}

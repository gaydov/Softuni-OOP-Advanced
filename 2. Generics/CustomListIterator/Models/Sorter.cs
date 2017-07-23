using System;
using System.Linq;

public static class Sorter<T>
    where T : IComparable<T>
{
    public static IMyList<T> Sort(IMyList<T> inputList)
    {
        T[] sortedItemsArr = inputList.ListElements.Where(i => i != null).OrderBy(i => i).ToArray();
        return new MyList<T>(sortedItemsArr);
    }
}

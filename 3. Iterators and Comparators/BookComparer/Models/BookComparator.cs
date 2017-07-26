using System.Collections;
using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int compareResult = x.Title.CompareTo(y.Title);

        if (compareResult == 0)
        {
            compareResult = y.Year.CompareTo(x.Year);
        }

        return compareResult;
    }
}

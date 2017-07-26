using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get; }
    public int Year { get; }
    public IList<string> Authors { get; }

    public int CompareTo(Book otherBook)
    {
        if (this.Year - otherBook.Year != 0)
        {
            return this.Year.CompareTo(otherBook.Year);
        }

        return this.Title.CompareTo(otherBook.Title);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}

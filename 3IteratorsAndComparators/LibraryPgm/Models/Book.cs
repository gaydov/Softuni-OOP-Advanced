using System.Collections.Generic;

public class Book
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
}

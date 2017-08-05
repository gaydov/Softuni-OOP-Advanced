using System.Collections.Generic;
using System.Linq;

public class MyList : IMyList
{
    public MyList()
    {
        this.Items = new List<string>();
    }

    public int Used
    {
        get { return this.Items.Count; }
    }

    private List<string> Items { get; }

    public int Add(string item)
    {
        this.Items.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        string toBeRemoved = this.Items.First();
        this.Items.Remove(toBeRemoved);
        return toBeRemoved;
    }
}
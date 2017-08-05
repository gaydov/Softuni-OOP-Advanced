using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection : IAddRemoveCollection
{
    public AddRemoveCollection()
    {
        this.Items = new List<string>();
    }

    private List<string> Items { get; }

    public int Add(string item)
    {
        this.Items.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        string toBeRemoved = this.Items.Last();
        this.Items.Remove(toBeRemoved);
        return toBeRemoved;
    }
}

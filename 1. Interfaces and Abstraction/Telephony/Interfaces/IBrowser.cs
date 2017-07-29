using System.Collections.Generic;

public interface IBrowser
{
    ICollection<string> URLs { get; }

    string Browse(string url);
}


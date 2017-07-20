using System.Collections.Generic;

interface IBrowser
{
    ICollection<string> URLs { get; }

    string Browse(string url);
}


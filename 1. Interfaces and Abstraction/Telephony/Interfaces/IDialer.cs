using System.Collections.Generic;

public interface IDialer
{
    ICollection<string> Numbers { get; }

    string Call(string number);
}


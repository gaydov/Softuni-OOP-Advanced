using System.Collections;
using System.Collections.Generic;

interface IDialer
{
    ICollection<string> Numbers { get; }

    string Call(string number);
}


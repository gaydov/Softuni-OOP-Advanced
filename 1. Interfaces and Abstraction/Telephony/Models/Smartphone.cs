using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : IDialer, IBrowser
{
    public Smartphone(ICollection<string> numbers, ICollection<string> URLs)
    {
        this.Numbers = numbers;
        this.URLs = URLs;
    }

    public ICollection<string> Numbers { get; private set; }

    public ICollection<string> URLs { get; private set; }

    public string Browse(string url)
    {
        if (url.Any(c => char.IsDigit(c)))
        {
            return "Invalid URL!";
        }
        else
        {
            return $"Browsing: {url}!";
        }
    }

    public string Call(string number)
    {
        if (!number.All(c => char.IsDigit(c)))
        {
            return "Invalid number!";
        }
        else
        {
            return $"Calling... {number}";
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string number in this.Numbers)
        {
            sb.AppendLine(this.Call(number));
        }

        foreach (string url in this.URLs)
        {
            sb.AppendLine(this.Browse(url));
        }

        return sb.ToString().Trim();
    }
}


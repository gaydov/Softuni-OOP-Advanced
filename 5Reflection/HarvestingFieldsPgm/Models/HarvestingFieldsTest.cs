using System;
using HarvestingFieldsPgm.Engine;

class HarvestingFieldsTest
{
    static void Main(string[] args)
    {
        string command = Console.ReadLine();
        while (!command.Equals("HARVEST"))
        {
            string result = Engine.GetFields(command);
            Console.WriteLine(result.Replace("family", "protected"));
            command = Console.ReadLine();
        }
    }
}


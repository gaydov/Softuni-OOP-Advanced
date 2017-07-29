using System;

public class CommandInterpreter
{
    private IMyList<string> list;

    public CommandInterpreter()
    {
        this.list = new MyList<string>();
    }

    public void TryExecuteCommand(string command)
    {
        string[] cmdArgs = command.Split();
        string cmd = cmdArgs[0];

        switch (cmd)
        {
            case "Add":
                list.Add(cmdArgs[1]);
                break;

            case "Remove":
                list.Remove(int.Parse(cmdArgs[1]));
                break;

            case "Contains":
                Console.WriteLine(list.Contains(cmdArgs[1]));
                break;

            case "Swap":
                list.Swap(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                break;

            case "Greater":
                Console.WriteLine(list.CountGreaterThan(cmdArgs[1]));
                break;

            case "Max":
                Console.WriteLine(list.Max());
                break;

            case "Min":
                Console.WriteLine(list.Min());
                break;

            case "Sort":
                list = Sorter<string>.Sort(list);
                break;

            case "Print":
                Console.WriteLine(list);
                break;
        }
    }
}

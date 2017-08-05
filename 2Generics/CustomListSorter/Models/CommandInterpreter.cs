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
                this.list.Add(cmdArgs[1]);
                break;

            case "Remove":
                this.list.Remove(int.Parse(cmdArgs[1]));
                break;

            case "Contains":
                Console.WriteLine(this.list.Contains(cmdArgs[1]));
                break;

            case "Swap":
                this.list.Swap(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                break;

            case "Greater":
                Console.WriteLine(this.list.CountGreaterThan(cmdArgs[1]));
                break;

            case "Max":
                Console.WriteLine(this.list.Max());
                break;

            case "Min":
                Console.WriteLine(this.list.Min());
                break;

            case "Sort":
                this.list = Sorter<string>.Sort(this.list);
                break;

            case "Print":
                Console.WriteLine(this.list);
                break;
        }
    }
}

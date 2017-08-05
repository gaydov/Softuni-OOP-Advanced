using System;

namespace CustomListIterator
{
    public class Launcher
    {
        public static void Main()
        {
            CommandInterpreter engine = new CommandInterpreter();
            string command = Console.ReadLine();

            while (!command.Equals("END"))
            {
                engine.TryExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}

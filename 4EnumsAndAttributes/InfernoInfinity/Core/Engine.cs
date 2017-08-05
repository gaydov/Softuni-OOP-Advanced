using System;
using System.Collections.Generic;
using InfernoInfinity.CommandInterpreterItems;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Core
{
    public class Engine
    {
        public void Start()
        {
            IList<IWeapon> weapons = new List<IWeapon>();
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                try
                {
                    string[] args = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    ICommand currentCommand = commandInterpreter.GenerateCommand(args, weapons);
                    currentCommand.Execute();
                }
                catch (Exception ex)
                {
                    OutputHandler.WriteMessageInConsole(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
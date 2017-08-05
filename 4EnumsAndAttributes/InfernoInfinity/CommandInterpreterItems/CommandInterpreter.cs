using System;
using System.Collections.Generic;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.CommandInterpreterItems
{
    public class CommandInterpreter
    {
        public ICommand GenerateCommand(string[] args, IList<IWeapon> weapons)
        {
            string commandName = args[0];

            switch (commandName)
            {
                case "Create":
                    return new CreateWeaponCommand(args, weapons);

                case "Add":
                    return new AddGemCommand(args, weapons);

                case "Remove":
                    return new RemoveGemCommand(args, weapons);

                case "Print":
                    return new PrintWeaponCommand(args, weapons);
            }

            throw new ArgumentException("Invalid input command name.");
        }
    }
}
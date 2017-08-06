using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using BarrackWarsTasks.Contracts;
using BarrackWarsTasks.Core.Commands;

namespace BarrackWarsTasks.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandClassSuffix = "Command";

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string fullCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandClassSuffix;

            Type commandNameType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == fullCommandName);

            IExecutable command = (Command)Activator.CreateInstance(commandNameType, new object[] { data });
            return command;
        }
    }
}
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
        private const string FolderWithCommands = "Commands";

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            // Getting the namespace where the commands reside
            string commandsNamespace = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Select(t => t.Namespace)
                .Distinct()
                .Where(n => n != null)
                .FirstOrDefault(n => n.Contains(FolderWithCommands));

            string actualCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandClassSuffix;
            Type classType = Type.GetType($"{commandsNamespace}.{actualCommandName}");
            IExecutable command = (Command)Activator.CreateInstance(classType, new object[] { data });

            return command;
        }
    }
}
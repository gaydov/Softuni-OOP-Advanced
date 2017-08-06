using System;
using System.Linq;
using System.Reflection;
using BarrackWarsTasks.Contracts;
using BarrackWarsTasks.Core.Commands;

namespace BarrackWarsTasks.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            // Getting the namespace where the commands reside
            string commandsNamespace = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Select(t => t.Namespace)
                .Distinct()
                .Where(n => n != null)
                .FirstOrDefault(n => n.Contains("Commands"));

            string actualCommandName = char.ToUpper(commandName[0]) + commandName.Substring(1) + "Command";
            Type classType = Type.GetType($"{commandsNamespace}.{actualCommandName}");
            IExecutable command = (Command)Activator.CreateInstance(classType, new object[] { data });

            return command;
        }
    }
}
using System;
using System.Linq;
using System.Reflection;
using BarrackWarsTasks.Attributes;
using BarrackWarsTasks.Contracts;
using BarrackWarsTasks.Core.Commands;

namespace BarrackWarsTasks.Core
{
    public class Engine : IRunnable
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    IExecutable currentCommand = this.InterpredCommand(data);
                    this.InjectDependencies(currentCommand);
                    Console.WriteLine(currentCommand.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private IExecutable InterpredCommand(string[] data)
        {
            // Getting the namespace where the commands reside
            string commandsNamespace = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Select(t => t.Namespace)
                .Distinct()
                .Where(n => n != null)
                .FirstOrDefault(n => n.Contains("Commands"));

            string inputCommandName = data[0];
            string commandName = char.ToUpper(inputCommandName[0]) + inputCommandName.Substring(1) + "Command";
            Type classType = Type.GetType($"{commandsNamespace}.{commandName}");
            IExecutable command = (Command)Activator.CreateInstance(classType, new object[] { data });

            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo[] commandFields = command.GetType().GetFields(flags);
            FieldInfo[] engineFields = this.GetType().GetFields(flags);

            foreach (FieldInfo fieldOfCommand in commandFields.Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null))
            {
                if (engineFields.Any(f => f.FieldType == fieldOfCommand.FieldType))
                {
                    fieldOfCommand.SetValue(command, engineFields.First(f => f.FieldType == fieldOfCommand.FieldType).GetValue(this));
                }
            }
        }
    }
}
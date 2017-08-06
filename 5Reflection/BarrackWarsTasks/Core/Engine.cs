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
                    CommandInterpreter cmdInterpreter = new CommandInterpreter();
                    IExecutable currentCommand = cmdInterpreter.InterpretCommand(data, data[0]);
                    this.InjectDependencies(currentCommand);
                    Console.WriteLine(currentCommand.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
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
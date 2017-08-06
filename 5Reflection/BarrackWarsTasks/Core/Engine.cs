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
                    CommandInterpreter cmdInterpreter = new CommandInterpreter(this.repository, this.unitFactory);
                    IExecutable currentCommand = cmdInterpreter.InterpretCommand(data, data[0]);
                    Console.WriteLine(currentCommand.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
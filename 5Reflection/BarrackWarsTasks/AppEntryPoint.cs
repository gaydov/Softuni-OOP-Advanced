﻿using BarrackWarsTasks.Contracts;
using BarrackWarsTasks.Core;
using BarrackWarsTasks.Core.Factories;
using BarrackWarsTasks.Data;

namespace BarrackWarsTasks
{
    public class AppEntryPoint
    {
        public static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
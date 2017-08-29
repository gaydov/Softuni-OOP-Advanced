using System;
using System.Linq;
using System.Reflection;
using BarrackWarsTasks.Contracts;

namespace BarrackWarsTasks.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private const string UnitsFolder = "Units";

        public IUnit CreateUnit(string unitType)
        {
            // Getting the namespace where the units reside
            string unitsNamespace = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Select(t => t.Namespace)
                .Distinct()
                .Where(n => n != null)
                .FirstOrDefault(n => n.Contains(UnitsFolder));

            Type typeOfUnit = Type.GetType($"{unitsNamespace}.{unitType}");
            IUnit instanceOfUnit = (IUnit)Activator.CreateInstance(typeOfUnit);

            return instanceOfUnit;
        }
    }
}
using System;
using System.Linq;
using System.Reflection;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Core.Factories
{
    public class LayoutFactory
    {
        public static ILayout CreateLayout(string layoutType)
        {
            Type layout = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutType));

            return (ILayout)Activator.CreateInstance(layout);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using LoggerPgm.Interfaces;
using LoggerPgm.Models;
using LoggerPgm.Models.Appenders;

namespace LoggerPgm.Core.Factories
{
    public class AppenderFactory
    {
        public static IAppender CreateAppender(string appenderKind, ILayout layout)
        {
            Type appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(appenderKind));

            switch (appenderKind)
            {
                case nameof(ConsoleAppender):
                    return (IAppender)Activator.CreateInstance(appenderType, layout);

                case nameof(FileAppender):
                    return (IAppender)Activator.CreateInstance(appenderType, layout, new LogFile());
            }

            throw new ArgumentException("Invalid kind of appender provided.");
        }
    }
}
using System;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Core.IO
{
    public class ConsoleReader : IReader
    {
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        string IReader.ReadLine()
        {
            return ReadLine();
        }
    }
}
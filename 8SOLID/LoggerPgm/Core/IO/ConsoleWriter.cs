using System;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public static void WriteLine(object textLine)
        {
            Console.WriteLine(textLine);
        }

        void IWriter.WriteLine(string textLine)
        {
            WriteLine(textLine);
        }
    }
}
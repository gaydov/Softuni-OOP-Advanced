using System;
using EventImplementation.Models;

namespace EventImplementation
{
    public class Launcher
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                dispatcher.Name = name;
                name = Console.ReadLine();
            }
        }
    }
}

using System;

namespace GenericBox
{
    public class Launcher
    {
        public static void Main()
        {
            Box<string> boxInt = new Box<string>(Console.ReadLine());
            Console.WriteLine(boxInt);
        }
    }
}

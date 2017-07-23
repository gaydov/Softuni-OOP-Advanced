using System;

namespace GenericBoxOfInteger
{
    public class Launcher
    {
        public static void Main()
        {
            int inputNumbersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNumbersCount; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
        }
    }
}

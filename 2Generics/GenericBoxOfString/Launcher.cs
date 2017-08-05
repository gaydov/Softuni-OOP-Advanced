using System;

namespace GenericBoxOfString
{
    public class Launcher
    {
        public static void Main()
        {
            int inputStringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputStringsCount; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}

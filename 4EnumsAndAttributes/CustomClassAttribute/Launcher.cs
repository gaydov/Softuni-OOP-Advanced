using System;
using System.Linq;
using CustomClassAttribute.Attributes;

namespace CustomClassAttribute
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Launcher
    {
        public static void Main()
        {
            CustomAttribute attribute = (CustomAttribute)typeof(Launcher).GetCustomAttributes(false).FirstOrDefault();

            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Console.WriteLine(attribute.Print(input));

                input = Console.ReadLine();
            }
        }
    }
}

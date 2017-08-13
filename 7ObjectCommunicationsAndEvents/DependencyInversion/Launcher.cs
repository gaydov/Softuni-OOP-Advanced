using System;
using DependencyInversion.Models;

namespace DependencyInversion
{
    public class Launcher
    {
        public static void Main()
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            string[] input = Console.ReadLine().Split();

            while (!input[0].Equals("End"))
            {
                if (input[0].Equals("mode"))
                {
                    calculator.ChangeStrategy(char.Parse(input[1]));
                }
                else
                {
                    int firstNum = int.Parse(input[0]);
                    int secondNum = int.Parse(input[1]);

                    Console.WriteLine(calculator.PerformCalculation(firstNum, secondNum));
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}

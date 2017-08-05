using System;
using System.Linq;
using System.Reflection;

namespace BlackBoxInteger
{
    public class Launcher
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInt);
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(classType, true);

            string command = Console.ReadLine();

            while (!command.Equals("END"))
            {
                string[] args = command.Split('_');
                string methodName = args[0];
                int passedValue = int.Parse(args[1]);

                MethodInfo currentMethod = classType.GetMethod(methodName, flags);

                currentMethod.Invoke(blackBox, new object[] { passedValue });

                string innerValue = classType.GetFields(flags).First().GetValue(blackBox).ToString();
                Console.WriteLine(innerValue);

                command = Console.ReadLine();
            }
        }
    }
}

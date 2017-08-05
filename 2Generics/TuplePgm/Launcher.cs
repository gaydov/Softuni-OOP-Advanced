using System;

namespace TuplePgm
{
    public class Launcher
    {
        public static void Main()
        {
            string[] nameAndAddress = Console.ReadLine().Split();
            string name = nameAndAddress[0] + " " + nameAndAddress[1];
            string address = nameAndAddress[2];
            CustomTuple<string, string> nameAndAddressTupple = new CustomTuple<string, string>(name, address);
            Console.WriteLine(nameAndAddressTupple);

            string[] nameAndLiters = Console.ReadLine().Split();
            name = nameAndLiters[0];
            int liters = int.Parse(nameAndLiters[1]);
            CustomTuple<string, int> nameAndLitersTuple = new CustomTuple<string, int>(name, liters);
            Console.WriteLine(nameAndLitersTuple);

            string[] intAndDoubleNums = Console.ReadLine().Split();
            int intNum = int.Parse(intAndDoubleNums[0]);
            double doubleNum = double.Parse(intAndDoubleNums[1]);
            CustomTuple<int, double> intAndDoubleTuple = new CustomTuple<int, double>(intNum, doubleNum);
            Console.WriteLine(intAndDoubleTuple);
        }
    }
}

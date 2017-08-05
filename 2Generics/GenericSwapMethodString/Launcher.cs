using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Launcher
    {
        public static void Main()
        {
            int inputStringsCount = int.Parse(Console.ReadLine());
            IList<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < inputStringsCount; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                list.Add(box);
            }

            int[] indexesToBeSwapped = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, indexesToBeSwapped[0], indexesToBeSwapped[1]);

            foreach (Box<string> box in list)
            {
                Console.WriteLine(box);
            }
        }

        private static void Swap<T>(IList<T> inputList, int index1, int index2)
        {
            T tmp = inputList[index1];

            inputList[index1] = inputList[index2];
            inputList[index2] = tmp;
        }
    }
}

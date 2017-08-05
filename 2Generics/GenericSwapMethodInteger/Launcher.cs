using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Launcher
    {
        public static void Main()
        {
            int inputStringsCount = int.Parse(Console.ReadLine());
            IList<Box<int>> list = new List<Box<int>>();

            for (int i = 0; i < inputStringsCount; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(box);
            }

            int[] indexesToBeSwapped = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, indexesToBeSwapped[0], indexesToBeSwapped[1]);

            foreach (Box<int> box in list)
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

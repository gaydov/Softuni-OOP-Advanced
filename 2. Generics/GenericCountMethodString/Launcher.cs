using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Launcher
    {
        public static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());
            IList<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < elementsCount; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                list.Add(box);
            }

            Box<string> boxToBeCompared = new Box<string>(Console.ReadLine());
            Console.WriteLine(GetCountOfElementsGreaterThanGivenElement(list, boxToBeCompared));
        }

        public static int GetCountOfElementsGreaterThanGivenElement<T>(IList<T> inputList, T givenElement)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (T item in inputList)
            {
                if (item.CompareTo(givenElement) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

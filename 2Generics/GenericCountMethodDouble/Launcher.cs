using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDouble
{
    public class Launcher
    {
        public static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());
            IList<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < elementsCount; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                list.Add(box);
            }

            Box<double> boxToBeCompared = new Box<double>(double.Parse(Console.ReadLine()));
            Console.WriteLine(GetCountOfElementsGreaterThanGivenElement(list, boxToBeCompared));
        }

        public static int GetCountOfElementsGreaterThanGivenElement<T>(IList<T> inputList, T givenElement)
            where T : IComparable<T>
        {
            return inputList.Count(x => x.CompareTo(givenElement) == 1);
        }
    }
}

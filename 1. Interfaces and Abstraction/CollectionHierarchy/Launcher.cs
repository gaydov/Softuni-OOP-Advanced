using System;
using CollectionHierarchy.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class Launcher
    {
        public static void Main()
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] input = Console.ReadLine().Split();

            string addCollectionOutput = string.Empty;
            string addRemoveCollectionOutput = string.Empty;
            string myListOutput = string.Empty;

            foreach (string item in input)
            {
                addCollectionOutput += $"{addCollection.Add(item)} ";
                addRemoveCollectionOutput += $"{addRemoveCollection.Add(item)} ";
                myListOutput += $"{myList.Add(item)} ";
            }

            Console.WriteLine(addCollectionOutput.TrimEnd());
            Console.WriteLine(addRemoveCollectionOutput.TrimEnd());
            Console.WriteLine(myListOutput.TrimEnd());

            int removeOpsCount = int.Parse(Console.ReadLine());
            addRemoveCollectionOutput = string.Empty;
            myListOutput = string.Empty;

            for (int i = 0; i < removeOpsCount; i++)
            {
                addRemoveCollectionOutput += $"{addRemoveCollection.Remove()} ";
                myListOutput += $"{myList.Remove()} ";
            }

            Console.WriteLine(addRemoveCollectionOutput.TrimEnd());
            Console.WriteLine(myListOutput.TrimEnd());
        }
    }
}

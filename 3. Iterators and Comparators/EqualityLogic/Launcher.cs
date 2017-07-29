using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Launcher
    {
        public static void Main()
        {
            SortedSet<Person> sortedSetPeople = new SortedSet<Person>();
            HashSet<Person> hashSetPeople = new HashSet<Person>();
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person currentPerson = new Person(input[0], int.Parse(input[1]));

                sortedSetPeople.Add(currentPerson);
                hashSetPeople.Add(currentPerson);
            }

            Console.WriteLine(sortedSetPeople.Count);
            Console.WriteLine(hashSetPeople.Count);
        }
    }
}

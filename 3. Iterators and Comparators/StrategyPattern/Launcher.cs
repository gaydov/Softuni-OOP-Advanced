using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Comparators;

namespace StrategyPattern
{
    public class Launcher
    {
        public static void Main()
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new CompareByName());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new CompareByAge());

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string personName = args[0];
                int personAge = int.Parse(args[1]);

                Person currentPerson = new Person(personName, personAge);
                sortedByName.Add(currentPerson);
                sortedByAge.Add(currentPerson);
            }

            sortedByName.ToList().ForEach(p => Console.WriteLine(p));
            sortedByAge.ToList().ForEach(p => Console.WriteLine(p));
        }
    }
}

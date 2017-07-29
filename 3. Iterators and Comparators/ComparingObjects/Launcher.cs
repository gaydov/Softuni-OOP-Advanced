using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Launcher
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                string[] args = input.Split();
                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                Person currentPerson = new Person(name, age, town);
                people.Add(currentPerson);

                input = Console.ReadLine();
            }

            int personToBeComparedNumber = int.Parse(Console.ReadLine());
            Person personToBeCompared = people[personToBeComparedNumber - 1];
            int equalPeople = 0;
            int notEqualPeople = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(personToBeCompared) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople != 1)
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}

using System.Collections.Generic;

namespace StrategyPattern.Comparators
{
    public class CompareByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}

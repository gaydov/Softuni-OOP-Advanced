using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Comparators
{
    public class CompareByName : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if(result == 0)
            {
                char firstPersonFirstLetter = char.ToLower(firstPerson.Name[0]);
                char secondPersonFirstLetter = char.ToLower(secondPerson.Name[0]);
                result = firstPersonFirstLetter.CompareTo(secondPersonFirstLetter);
            }

            return result;
        }
    }
}

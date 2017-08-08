using System.Collections.Generic;
using ExtendedDatabase.Models;

namespace ExtendedDb.Tests
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Username.Equals(secondPerson.Username) && firstPerson.Id == secondPerson.Id;
        }

        public int GetHashCode(Person person)
        {
            return new { person.Username, person.Id }.GetHashCode();
        }
    }
}

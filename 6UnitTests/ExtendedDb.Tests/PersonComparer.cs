using System;
using System.Collections.Generic;
using ExtendedDatabase.Models;

namespace ExtendedDb.Tests
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Username.Equals(y.Username) && x.Id == y.Id;
        }

        public int GetHashCode(Person obj)
        {
            return Tuple.Create(obj.Username, obj.Id).GetHashCode();
        }
    }
}

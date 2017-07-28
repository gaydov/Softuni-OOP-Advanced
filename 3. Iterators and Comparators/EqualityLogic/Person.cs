using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            Person otherPerson = obj as Person;

            return this.Name.Equals(otherPerson.Name) && this.Age.Equals(otherPerson.Age);
        }

        public override int GetHashCode()
        {
            int sumOfCharsInName = 0;

            for (int i = 0; i < this.Name.Length; i++)
            {
                sumOfCharsInName += this.Name[i];
            }

            return this.Age + sumOfCharsInName;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }
    }
}

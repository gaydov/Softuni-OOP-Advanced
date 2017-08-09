using System.Collections;
using System.Collections.Generic;
using ExtendedDatabase.Models;
using NUnit.Framework;

namespace ExtendedDb.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private readonly IEqualityComparer<Person> personComparer = new PersonComparer();

        [Test]
        public void ConstructorCreatesPersonWithTheProvidedUsernameAndId()
        {
            // Arrange
            Person person = new Person("Rocky", 2121);

            // Assert
            Assert.IsTrue(this.personComparer.Equals(new Person("Rocky", 2121), person), "The constructor is not creating the person properly.");
        }
    }
}

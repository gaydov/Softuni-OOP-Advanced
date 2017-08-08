using System;
using ExtendedDatabase.Models;
using NUnit.Framework;

namespace ExtendedDb.Tests
{
    [TestFixture]
    public class DbTests
    {
        private static readonly Person ExpectedPerson = new Person("Arnold", 3434);
        private readonly PersonComparer personComparer = new PersonComparer();
        private Db db;

        [SetUp]
        public void CreateSampleDb()
        {
            // Arrange
            this.db = new Db(new Person("Gandalf", 2121), new Person("Arnold", 3434));
        }

        [Test]
        public void ConstructorShouldAddPeopleToTheDb()
        {
            // Assert
            Assert.IsTrue(this.personComparer.Equals(ExpectedPerson, this.db[1]), "The Db is not created correctly.");
        }

        [Test]
        public void AddShouldThrowExceptionIfPersonWithTheSameNameAlreadyExists()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person("Gandalf", 11)), "Person with the same username of an already existing one can be added.");
        }

        [Test]
        public void AddShouldThrowExceptionIfPersonWithTheSameIdAlreadyExists()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person("Rocky", 2121)), "Person with the same ID of an already existing one can be added.");
        }

        [Test]
        public void AddShouldAddThePersonToTheDb()
        {
            // Arrange
            Person personToBeAdded = new Person("Rocky", 5454);

            // Act
            this.db.Add(personToBeAdded);

            // Assert
            Assert.IsTrue(this.personComparer.Equals(personToBeAdded, this.db[2]), "Person is not added to the DB.");
        }

        [Test]
        public void RemoveShouldThrowExceptionIfTheDatabaseIsEmpty()
        {
            // Arrange
            this.db = new Db();

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.db.Remove(), "Exception is not thrown.");
        }

        [Test]
        public void RemoveShouldRemoveTheLastPersonFromTheDatabase()
        {
            // Act
            this.db.Remove();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Person person = this.db[1]; }, "The last person is not removed");
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfEmptyUsernameIsEntered()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.db.FindByUsername(null), "No exception is thrown.");
            Assert.Throws<ArgumentNullException>(() => this.db.FindByUsername(string.Empty), "No exception is thrown.");
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNoSuchUserExistsInTheDb()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.db.FindByUsername("Rocky"), "No exception is thrown.");
        }

        [Test]
        public void FindByUsernameReturnsTheFirstUserWithThatName()
        {
            // Act
            Person person = this.db.FindByUsername("Arnold");

            // Assert
            Assert.IsTrue(this.personComparer.Equals(ExpectedPerson, person), "The person is not correctly returned.");
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfNegativeIdIsProvided()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.db.FindById(-1), "No exception is thrown.");
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfThereIsNoUserWithThisId()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.db.FindById(1), "No exception is thrown.");
        }

        [Test]
        public void FindByIdReturnsThePersonWithThisId()
        {
            // Assert
            Assert.IsTrue(this.personComparer.Equals(ExpectedPerson, this.db.FindById(3434)), "The person is not returned correctly.");
        }
    }
}
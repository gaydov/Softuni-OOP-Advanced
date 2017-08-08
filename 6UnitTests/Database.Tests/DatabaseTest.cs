using System;
using System.Linq;
using DatabasePgm;
using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTest
    {
        private const int Capacity = 16;

        [Test]
        public void IfMoreElementsThanTheCapacityArePassedToTheConstructorAnExceptionIsThrown()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => new Db(Enumerable.Repeat(5, Capacity + 1).ToArray()), "More items than the collection's capacity can be added.");
        }

        [Test]
        public void IfElementsArePassedUsingTheConstructorTheyShouldBeAddedToTheDatabase()
        {
            // Arrange
            Db db = new Db(1, 2, 3);

            // Assert
            Assert.AreEqual(1, db[0], "The element is not added in the database.");
        }

        [Test]
        public void AddElementShouldAddItToTheDatabase()
        {
            // Arrange
            Db db = new Db(1);

            // Act
            db.Add(3);

            // Assert
            Assert.AreEqual(3, db[1], "The element is not being added to the database.");
        }

        [Test]
        public void AddElementShouldThrowExceptionIfTheDatabaseIsFullAlready()
        {
            // Arrange
            Db db = new Db(Enumerable.Repeat(5, Capacity).ToArray());

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(10), "More elements can be added even when the database is full.");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementFromTheDatabaseIfThereIsAny()
        {
            // Arrange
            Db db = new Db(Enumerable.Repeat(5, 2).ToArray());

            // Act
            db.Remove();

            // Assert
            Assert.AreEqual(0, db[1], "The last element is not removed from the database.");
        }

        [Test]
        public void RemoveShouldThrowExceptionIfTheDatabaseIsEmpty()
        {
            // Arrange
            Db db = new Db();

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove(), "No exception is thrown.");
        }

        [Test]
        public void FetchShouldReturnTheElementsOfTheDatabase()
        {
            // Arrange
            Db db = new Db(Enumerable.Repeat(5, 3).ToArray());
            int[] sampleCollection = new[] { 5, 5, 5 };

            // Assert
            CollectionAssert.AreEqual(sampleCollection, db.Fetch(), "The method does not return the elements of the database.");
        }
    }
}

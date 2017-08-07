using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasePgm;

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
        public void AddElementShouldThrowExceptionIfTheCollectionIsFullAlready()
        {
            // Arrange
            Db db = new Db(Enumerable.Repeat(5, Capacity).ToArray());

            // Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(10), "More elements can be added even when the collection is full.");
        }
    }
}

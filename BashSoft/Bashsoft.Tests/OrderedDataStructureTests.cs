using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;

namespace Bashsoft.Tests
{
    [TestFixture]
    public class OrderedDataStructureTests
    {
        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0;
        private readonly IList<string> itemsToBeAdded = new List<string>() { "Rocky", "Gandalf", "Asterix", "Merilyn" };
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            // Assert
            Assert.AreEqual(this.names.Capacity, DefaultCapacity, "The capacity is not the default one.");
            Assert.AreEqual(this.names.Size, DefaultSize, "The size is not correct.");
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(20);

            // Assert
            Assert.AreEqual(this.names.Capacity, 20, "The capacity is not correct.");
            Assert.AreEqual(this.names.Size, DefaultSize, "The size is not correct.");
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            // Assert
            Assert.AreEqual(this.names.Capacity, 30, "The capacity is not correct.");
            Assert.AreEqual(this.names.Size, DefaultSize, "The size is not correct.");
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            // Arrange
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.AreEqual(this.names.Capacity, DefaultCapacity, "The capacity is not the default one.");
            Assert.AreEqual(this.names.Size, DefaultSize, "The size is not correct.");
        }

        [Test]
        public void AddShouldIncreaseTheSize()
        {
            // Act
            this.names.Add("Gandalf");

            // Assert
            Assert.AreEqual(1, this.names.Size, "The size is not being increased.");
        }

        [Test]
        public void AddNullShouldThrowException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null), "Exception is not thrown and NULL is added to the collection.");
        }

        [Test]
        public void AddUnsortedDataIsHeldSorted()
        {
            // Arrange
            string[] expectedNames = new[] { "Balkan", "Georgi", "Rosen" };
            string[] enteredNames = new[] { "Rosen", "Georgi", "Balkan" };

            // Act
            this.names.AddAll(enteredNames);

            // Assert
            for (int i = 0; i < this.names.Size; i++)
            {
                Assert.AreEqual(expectedNames[i], this.names[i], "The collection is not ordered properly.");
            }
        }

        [Test]
        public void AddingMoreThanInitialCapacityShouldAdjustTheSize()
        {
            // Act
            this.names.AddAll(Enumerable.Repeat("item", 17).ToArray());

            // Assert
            Assert.AreNotEqual(DefaultCapacity, this.names.Size, "The collection's resizing is not working.");
        }

        [Test]
        public void AddAllFromCollectionIncreasesSize()
        {
            // Act
            this.names.AddAll(this.itemsToBeAdded);

            // Assert
            Assert.AreEqual(this.itemsToBeAdded.Count, this.names.Size, "The elements are not added to the collection.");
        }

        [Test]
        public void AddingAllFromNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null), "NULL can be added to the collection.");
        }

        [Test]
        public void AddAllKeepsSorted()
        {
            // Arrange
            List<string> itemsSorted = this.itemsToBeAdded.OrderBy(i => i).ToList();

            // Act
            this.names.AddAll(this.itemsToBeAdded);

            // Assert
            CollectionAssert.AreEqual(itemsSorted, this.names, "The collection is not sorted.");
        }

        [Test]
        public void RemoveValidElementDecreasesSize()
        {
            // Arrange
            this.names.AddAll(this.itemsToBeAdded);

            // Act
            this.names.Remove("Rocky");

            // Assert
            Assert.AreEqual(this.itemsToBeAdded.Count - 1, this.names.Size, "Removing an element does not decrease the size.");
        }

        [Test]
        public void RemoveValidElementRemovesSelectedOne()
        {
            // Arrange
            this.names.AddAll(this.itemsToBeAdded);

            // Act
            this.names.Remove("Rocky");

            // Assert
            Assert.IsFalse(this.names.Contains("Rocky"), "The removed element is not the correct one.");
        }

        [Test]
        public void RemovingNullShouldThrowsException()
        {
            // Assert 
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null),
                "Trying to remove null from the collection does not throw an exception.");
        }

        [Test]
        public void JoinWithNullShouldThrowException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null),
                "The collection can be joined with NULL.");
        }

        [Test]
        public void JoinWorksFine()
        {
            // Arrange
            this.names.AddAll(this.itemsToBeAdded);
            string expectedOutput = "Asterix, Gandalf, Merilyn, Rocky";

            // Act
            string output = this.names.JoinWith(", ");

            // Assert
            Assert.AreEqual(expectedOutput, output, "The join is not working properly.");
        }
    }
}

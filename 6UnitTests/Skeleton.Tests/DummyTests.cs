using System;
using Moq;
using NUnit.Framework;
using Skeleton.Interfaces;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DummyDefaultHealth = 5;
        private const int DummyDefaultExperience = 10;
        private const int AxeDefaultAttack = 5;
        private const int AxeDefaultDurability = 15;
        private const string HeroName = "Gandalf";

        private Hero hero;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateHeroAxeAndDummy()
        {
            this.dummy = new Dummy(DummyDefaultHealth, DummyDefaultExperience); // (health, experince)
            this.axe = new Axe(AxeDefaultAttack, AxeDefaultDurability);         // (attack, durability)
            this.hero = new Hero(HeroName, this.axe);
        }

        [Test]
        public void DummyShouldLoseHealthAfterItWasAttacked()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.AreEqual(0, this.dummy.Health, "Dummy does not lose health after it is attacked.");
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Dead dummy does not throw exception if attacked.");
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            // Act
            this.hero.Attack(this.dummy);

            // Assert
            Assert.AreEqual(10, this.hero.Experience, "The dummy does not give experience when killed.");
        }

        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            // Arrange
            this.dummy = new Dummy(15, 10);

            // Act
            this.hero.Attack(this.dummy);

            // Assert
            Assert.AreEqual(0, this.hero.Experience, "The dummy gives experience even when it is still alive.");
        }
    }
}

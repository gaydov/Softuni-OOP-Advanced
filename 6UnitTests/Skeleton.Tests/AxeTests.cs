using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeDefaultAttack = 10;
        private const int AxeDefaultDurability = 1;
        private const int DummyDefaultHealth = 10;
        private const int DummyDefaultExperience = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateSampleAxeAndDummy()
        {
            this.axe = new Axe(AxeDefaultAttack, AxeDefaultDurability);        // (attack, durability)
            this.dummy = new Dummy(DummyDefaultHealth, DummyDefaultExperience);   // (health, experince)
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            // Act
            this.axe.Attack(this.dummy);

            // Assert
            Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe does not lose durability after attack.");
        }

        [Test]
        public void AxeShouldNotBeAbleToAttackIfItIsBroken()
        {
            // Act
            this.axe.Attack(this.dummy); // After the attack the durability is 0

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy), "Axe is able to attack even when it's broken.");
        }
    }
}
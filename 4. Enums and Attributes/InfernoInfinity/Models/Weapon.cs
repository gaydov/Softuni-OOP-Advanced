using System.Linq;
using InfernoInfinity.Core;
using InfernoInfinity.Enums;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Models
{
    public abstract class Weapon : IWeapon
    {
        private const int StrengthMultiplierMinDamage = 2;
        private const int StrengthMultiplierMaxDamage = 3;

        private const int AgilityMultiplierMinDamage = 1;
        private const int AgilityMultiplierMaxDamage = 4;

        protected Weapon(string name, string rarity)
        {
            this.Name = name;
            this.Rarity = Validator.TryParseRarity(rarity);
        }

        public string Name { get; protected set; }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public int SocketsCount { get; protected set; }

        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public IGem[] Gems { get; protected set; }

        public WeaponRarity Rarity { get; protected set; }

        public void AddGemToSocket(int socketIndex, IGem gemType)
        {
            if (Validator.IsIndexInArray(socketIndex, this.Gems.Length))
            {
                this.Gems[socketIndex] = gemType;
            }

            // The task's requirement is not to log any messages in that case and this part is commented because it affects the tests
            // else
            // {
            //     throw new ArgumentException("Invalid socket entered");
            // }
        }

        public void RemoveGemFromSocket(int socketIndex)
        {
            if (Validator.IsIndexInArray(socketIndex, this.Gems.Length))
            {
                this.Gems[socketIndex] = null;
            }

            // The task's requirement is not to log any messages in that case and this part is commented because it affects the tests
            // else
            // {
            //     throw new ArgumentException("Invalid socket entered");
            // }
        }

        public void CalculateStats()
        {
            this.IncreaseStatsByRarity();
            this.IncreaseStatsByGems();
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }

        protected void IncreaseStatsByRarity()
        {
            this.MinDamage *= (int)this.Rarity;
            this.MaxDamage *= (int)this.Rarity;
        }

        protected void IncreaseStatsByGems()
        {
            foreach (IGem gem in this.Gems.Where(g => g != null))
            {
                this.Strength += gem.StrengthIncrease;
                this.Agility += gem.AgilityIncrease;
                this.Vitality += gem.VitalityIncrease;

                int strengthToBeAddedToMinDamage = StrengthMultiplierMinDamage * gem.StrengthIncrease;
                int strengthToBeAddedToMaxDamage = StrengthMultiplierMaxDamage * gem.StrengthIncrease;

                int agilityToBeAddedToMinDamage = AgilityMultiplierMinDamage * gem.AgilityIncrease;
                int agilityToBeAddedToMaxDamage = AgilityMultiplierMaxDamage * gem.AgilityIncrease;

                this.MinDamage += strengthToBeAddedToMinDamage + agilityToBeAddedToMinDamage;
                this.MaxDamage += strengthToBeAddedToMaxDamage + agilityToBeAddedToMaxDamage;
            }
        }
    }
}
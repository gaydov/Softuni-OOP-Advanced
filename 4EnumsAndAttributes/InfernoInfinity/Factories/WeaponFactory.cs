using System;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Models;

namespace InfernoInfinity.Factories
{
    public class WeaponFactory
    {
        public static IWeapon GenerateWeapon(string weaponType, string weaponName, string weaponRarity)
        {
            switch (weaponType)
            {
                case "Axe":
                    return new Axe(weaponName, weaponRarity);

                case "Sword":
                    return new Sword(weaponName, weaponRarity);

                case "Knife":
                    return new Knife(weaponName, weaponRarity);
            }

            throw new ArgumentException("Invalid input weapon type.");
        }
    }
}
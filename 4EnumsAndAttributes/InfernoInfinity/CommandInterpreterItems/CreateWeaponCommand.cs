using System.Collections.Generic;
using InfernoInfinity.Factories;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.CommandInterpreterItems
{
    public class CreateWeaponCommand : Command
    {
        public CreateWeaponCommand(string[] args, IList<IWeapon> weapons)
            : base(args, weapons)
        {
        }

        public override void Execute()
        {
            string[] currentWeaponArgs = this.args[1].Split();
            string weaponRarity = currentWeaponArgs[0];
            string weaponType = currentWeaponArgs[1];
            string weaponName = this.args[2];
            IWeapon newWeapon = WeaponFactory.GenerateWeapon(weaponType, weaponName, weaponRarity);
            this.weapons.Add(newWeapon);
        }
    }
}
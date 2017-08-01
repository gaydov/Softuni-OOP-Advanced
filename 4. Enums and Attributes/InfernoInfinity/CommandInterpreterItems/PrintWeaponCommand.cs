using System;
using System.Collections.Generic;
using System.Linq;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Core;

namespace InfernoInfinity.CommandInterpreterItems
{
    public class PrintWeaponCommand : Command
    {
        public PrintWeaponCommand(string[] args, IList<IWeapon> weapons)
            : base(args, weapons)
        {
        }

        public override void Execute()
        {
            string weaponName = this.args[1];
            IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name.Equals(weaponName));

            if (!Validator.IsNull(currentWeapon))
            {
                currentWeapon.CalculateStats();
                OutputHandler.WriteMessageInConsole(currentWeapon.ToString());
            }
            else
            {
                throw new ArgumentException("Weapon not found.");
            }
        }
    }
}
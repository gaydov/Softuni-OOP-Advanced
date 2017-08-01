using System;
using System.Collections.Generic;
using System.Linq;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Core;

namespace InfernoInfinity.CommandInterpreterItems
{
    public class RemoveGemCommand : Command
    {
        public RemoveGemCommand(string[] args, IList<IWeapon> weapons)
            : base(args, weapons)
        {
        }

        public override void Execute()
        {
            string weaponName = this.args[1];
            IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name.Equals(weaponName));

            if (!Validator.IsNull(currentWeapon))
            {
                currentWeapon.RemoveGemFromSocket(int.Parse(this.args[2]));
            }
            else
            {
                throw new ArgumentException("Weapon not found.");
            }
        }
    }
}
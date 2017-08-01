using System.Collections.Generic;
using System.Linq;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Factories;
using InfernoInfinity.Core;
using System;

namespace InfernoInfinity.CommandInterpreterItems
{
    public class AddGemCommand : Command
    {
        public AddGemCommand(string[] args, IList<IWeapon> weapons)
            : base(args, weapons)
        {
        }

        public override void Execute()
        {
            string weaponName = this.args[1];
            int socketIndex = int.Parse(this.args[2]);

            string[] gemArgs = this.args[3].Split();
            string gemClarity = gemArgs[0];
            string gemType = gemArgs[1];

            IGem currentGem = GemFactory.GenerateGem(gemType, gemClarity);
            IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name.Equals(weaponName));

            if (!Validator.IsNull(currentWeapon))
            {
                currentWeapon.AddGemToSocket(socketIndex, currentGem);
            }
            else
            {
                throw new ArgumentException("Weapon not found.");
            }
        }
    }
}
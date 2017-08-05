using System.Collections.Generic;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.CommandInterpreterItems
{
    public abstract class Command : ICommand
    {
        protected string[] args;
        protected IList<IWeapon> weapons;

        protected Command(string[] args, IList<IWeapon> weapons)
        {
            this.args = args;
            this.weapons = weapons;
        }

        public abstract void Execute();
    }
}
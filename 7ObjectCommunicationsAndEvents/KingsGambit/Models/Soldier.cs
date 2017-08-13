using System;
using KingsGambit.Interfaces;

namespace KingsGambit.Models
{
    public abstract class Soldier : INameable
    {
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void OnKingBeingAttacked(object source, EventArgs args);
    }
}
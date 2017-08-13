using System;
using KingsGambit.Interfaces;

namespace KingsGambit.Models
{
    public class King : INameable
    {
        public King(string name)
        {
            this.Name = name;
        }

        public event EventHandler BeingAttacked;

        public string Name { get; set; }

        public void OnBeingAttacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if (this.BeingAttacked != null)
            {
                this.BeingAttacked(this, EventArgs.Empty);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using KingsGambit.Models;

namespace KingsGambit
{
    public class Launcher
    {
        public static void Main()
        {
            IList<Soldier> soldiers = new List<Soldier>();
            King king = new King(Console.ReadLine());
            string[] royalGuardsNames = Console.ReadLine().Split();

            foreach (string guardName in royalGuardsNames)
            {
                RoyalGuard currentRoyalGuard = new RoyalGuard(guardName);
                soldiers.Add(currentRoyalGuard);
                king.BeingAttacked += currentRoyalGuard.OnKingBeingAttacked;
            }

            string[] footmenNames = Console.ReadLine().Split();

            foreach (string footManName in footmenNames)
            {
                Footman footMan = new Footman(footManName);
                soldiers.Add(footMan);
                king.BeingAttacked += footMan.OnKingBeingAttacked;
            }

            string[] command = Console.ReadLine().Split();

            while (!command[0].Equals("End"))
            {
                switch (command[0])
                {
                    case "Kill":

                        Soldier deadSoldier = soldiers.FirstOrDefault(s => s.Name.Equals(command[1]));
                        king.BeingAttacked -= deadSoldier.OnKingBeingAttacked;
                        soldiers.Remove(deadSoldier);
                        break;

                    case "Attack":

                        king.OnBeingAttacked();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}

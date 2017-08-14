using System;
using System.Linq;
using KingsGambitExtended.Models;

namespace KingsGambitExtended
{
    public class Launcher
    {
        public static void Main()
        {
            SoldiersList soldiers = new SoldiersList();
            King king = new King(Console.ReadLine());
            string[] royalGuardsNames = Console.ReadLine().Split();

            foreach (string guardName in royalGuardsNames)
            {
                RoyalGuard currentRoyalGuard = new RoyalGuard(guardName, king);
                soldiers.Add(currentRoyalGuard);
                king.BeingAttacked += currentRoyalGuard.OnKingBeingAttacked;
            }

            string[] footmenNames = Console.ReadLine().Split();

            foreach (string footManName in footmenNames)
            {
                Footman footMan = new Footman(footManName, king);
                soldiers.Add(footMan);
                king.BeingAttacked += footMan.OnKingBeingAttacked;
            }

            soldiers.ForEach(s => s.SoldierKilled += soldiers.OnSoldierKilled);

            string[] command = Console.ReadLine().Split();

            while (!command[0].Equals("End"))
            {
                switch (command[0])
                {
                    case "Kill":

                        Soldier attackedSoldier = soldiers.FirstOrDefault(s => s.Name.Equals(command[1]));
                        attackedSoldier.TakeAttack();
                        break;

                    case "Attack":

                        king.TakeAttack();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Launcher
    {
        private static IList<ISoldier> army;

        public static void Main()
        {
            army = new List<ISoldier>();
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] args = input.Split();
                string soldierType = args[0];
                int id = int.Parse(args[1]);
                string firstName = args[2];
                string lastName = args[3];

                switch (soldierType)
                {
                    case "Private":

                        army.Add(new Private(id, firstName, lastName, decimal.Parse(args[4])));
                        break;

                    case "LeutenantGeneral":

                        IList<ISoldier> privates = GetPrivates(args.Skip(5).ToList());
                        army.Add(new LeutenantGeneral(id, firstName, lastName, decimal.Parse(args[4]), privates));
                        break;

                    case "Engineer":

                        string corpse = args[5];
                        if (!IsCorpseValid(corpse))
                        {
                            break;
                        }

                        IList<IRepair> repairs = GetRepairs(args.Skip(6).ToList());
                        army.Add(new Engineer(id, firstName, lastName, decimal.Parse(args[4]), corpse, repairs));
                        break;

                    case "Commando":

                        corpse = args[5];
                        if (!IsCorpseValid(corpse))
                        {
                            break;
                        }

                        IList<IMission> missions = GetMissions(args.Skip(6).ToList());
                        army.Add(new Commando(id, firstName, lastName, decimal.Parse(args[4]), corpse, missions));
                        break;

                    case "Spy":

                        army.Add(new Spy(id, firstName, lastName, int.Parse(args[4])));
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (ISoldier soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }

        private static bool IsCorpseValid(string corpse)
        {
            string[] validCorpses = { "Airforces", "Marines" };
            return validCorpses.Contains(corpse);
        }

        private static IList<IMission> GetMissions(List<string> missionsInfo)
        {
            IList<IMission> missions = new List<IMission>();

            for (int i = 0; i < missionsInfo.Count - 1; i += 2)
            {
                string name = missionsInfo[i];
                string state = missionsInfo[i + 1];

                if (!state.Equals("inProgress") && !state.Equals("Finished"))
                {
                    continue;
                }

                missions.Add(new Mission(name, state));
            }

            return missions;
        }

        private static IList<IRepair> GetRepairs(List<string> repairsInfo)
        {
            IList<IRepair> repairs = new List<IRepair>();

            for (int i = 0; i < repairsInfo.Count - 1; i += 2)
            {
                string repairedPart = repairsInfo[i];
                int hours = int.Parse(repairsInfo[i + 1]);

                IRepair currentRepair = new Repair(repairedPart, hours);
                repairs.Add(currentRepair);
            }

            return repairs;
        }

        private static IList<ISoldier> GetPrivates(IList<string> privatesIDs)
        {
            IList<ISoldier> privates = new List<ISoldier>();

            foreach (string id in privatesIDs)
            {
                privates.Add(army.FirstOrDefault(s => s.Id.Equals(int.Parse(id))));
            }

            return privates;
        }
    }
}

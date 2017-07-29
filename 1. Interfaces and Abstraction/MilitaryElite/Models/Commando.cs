using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, IList<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public IList<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine(base.ToString());
            sb.AppendLine($"{nameof(this.Missions)}:");

            foreach (IMission mission in this.Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }

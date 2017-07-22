using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary, IList<ISoldier> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IList<ISoldier> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"{nameof(this.Privates)}:");

            foreach (ISoldier soldier in this.Privates)
            {
                sb.AppendLine($"  {soldier}");
            }

            return sb.ToString().Trim();
        }
    }
}
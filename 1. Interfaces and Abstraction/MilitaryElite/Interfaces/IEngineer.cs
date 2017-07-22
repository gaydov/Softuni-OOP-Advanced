using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IList<IRepair> Repairs { get; }
    }
}
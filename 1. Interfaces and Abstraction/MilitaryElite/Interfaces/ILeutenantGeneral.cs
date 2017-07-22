using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Privates { get; }
    }
}
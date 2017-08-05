﻿namespace BarrackWarsTasks.Contracts
{
    public interface IRepository
    {
        string Statistics { get; }

        void RemoveUnit(string unitType);

        void AddUnit(IUnit unit);
    }
}
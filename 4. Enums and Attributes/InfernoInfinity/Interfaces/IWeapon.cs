using InfernoInfinity.Enums;

namespace InfernoInfinity.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        int SocketsCount { get; }
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        IGem[] Gems { get; }
        WeaponRarity Rarity { get; }
        void AddGemToSocket(int socketIndex, IGem gemType);
        void RemoveGemFromSocket(int socketIndex);
        void CalculateStats();
    }
}
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Models
{
    public class Sword : Weapon
    {
        private const int MinDamageValue = 4;
        private const int MaxDamageValue = 6;
        private const int SocketsCountValue = 3;

        public Sword(string name, string rarity)
            : base(name, rarity)
        {
            this.MinDamage = MinDamageValue;
            this.MaxDamage = MaxDamageValue;
            this.SocketsCount = SocketsCountValue;
            this.Gems = new IGem[this.SocketsCount];
        }
    }
}
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Models
{
    public class Knife : Weapon
    {
        private const int MinDamageValue = 3;
        private const int MaxDamageValue = 4;
        private const int SocketsCountValue = 2;

        public Knife(string name, string rarity)
            : base(name, rarity)
        {
            this.MinDamage = MinDamageValue;
            this.MaxDamage = MaxDamageValue;
            this.SocketsCount = SocketsCountValue;
            this.Gems = new IGem[this.SocketsCount];
        }
    }
}
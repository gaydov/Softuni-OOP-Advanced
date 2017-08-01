using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Models
{
    public class Axe : Weapon
    {
        private const int MinDamageValue = 5;
        private const int MaxDamageValue = 10;
        private const int SocketsCountValue = 4;

        public Axe(string name, string rarity)
            : base(name, rarity)
        {
            this.MinDamage = MinDamageValue;
            this.MaxDamage = MaxDamageValue;
            this.SocketsCount = SocketsCountValue;
            this.Gems = new IGem[this.SocketsCount];
        }
    }
}
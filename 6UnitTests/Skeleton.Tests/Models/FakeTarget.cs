using Skeleton.Interfaces;

namespace Skeleton.Tests.Models
{
    public class FakeTarget : ITarget
    {
        public int Health
        {
            get { return 0; }
        }

        public void TakeAttack(int attackPoints)
        {
        }

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }
    }
}
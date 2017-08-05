namespace InfernoInfinity.Models
{
    public class Amethyst : Gem
    {
        private const int StrengthIncreaseValue = 2;
        private const int AgilityIncreaseValue = 8;
        private const int VitalityIncreaseValue = 4;

        public Amethyst(string clarity)
            : base(clarity)
        {
            this.StrengthIncrease += StrengthIncreaseValue;
            this.AgilityIncrease += AgilityIncreaseValue;
            this.VitalityIncrease += VitalityIncreaseValue;
        }
    }
}
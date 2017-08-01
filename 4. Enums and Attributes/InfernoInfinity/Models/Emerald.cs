namespace InfernoInfinity.Models
{
    public class Emerald : Gem
    {
        private const int StrengthIncreaseValue = 1;
        private const int AgilityIncreaseValue = 4;
        private const int VitalityIncreaseValue = 9;

        public Emerald(string clarity)
            : base(clarity)
        {
            this.StrengthIncrease += StrengthIncreaseValue;
            this.AgilityIncrease += AgilityIncreaseValue;
            this.VitalityIncrease += VitalityIncreaseValue;
        }
    }
}
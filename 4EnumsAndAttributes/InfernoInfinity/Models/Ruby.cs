namespace InfernoInfinity.Models
{
    public class Ruby : Gem
    {
        private const int StrengthIncreaseValue = 7;
        private const int AgilityIncreaseValue = 2;
        private const int VitalityIncreaseValue = 5;

        public Ruby(string clarity)
            : base(clarity)
        {
            this.StrengthIncrease += StrengthIncreaseValue;
            this.AgilityIncrease += AgilityIncreaseValue;
            this.VitalityIncrease += VitalityIncreaseValue;
        }
    }
}
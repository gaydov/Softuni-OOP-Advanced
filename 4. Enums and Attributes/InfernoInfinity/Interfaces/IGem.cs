using InfernoInfinity.Enums;

namespace InfernoInfinity.Interfaces
{
    public interface IGem
    {
        int StrengthIncrease { get; }
        int AgilityIncrease { get; }
        int VitalityIncrease { get; }
        GemClarity Clarity { get; }
    }
}
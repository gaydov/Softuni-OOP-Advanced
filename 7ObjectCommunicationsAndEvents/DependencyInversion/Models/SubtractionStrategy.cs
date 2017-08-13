using DependencyInversion.Interfaces;

namespace DependencyInversion.Models
{
    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}

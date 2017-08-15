using DetailPrinter.Interfaces;
using DetailPrinter.Unitilies;

namespace DetailPrinter.Models
{
    public class Engineer : IEmployee
    {
        public Engineer(string name, int partsRepairedCount)
        {
            this.Name = name;
            this.PartsRepairedCount = partsRepairedCount;
        }

        public string Name { get; }

        public int PartsRepairedCount { get; }

        public void Print()
        {
            Writer.WriteLine($"Engineer {this.Name} repaired {this.PartsRepairedCount} parts today.");
        }
    }
}
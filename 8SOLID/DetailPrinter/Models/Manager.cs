using System;
using System.Collections.Generic;
using DetailPrinter.Interfaces;
using DetailPrinter.Unitilies;

namespace DetailPrinter.Models
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; }

        public void Print()
        {
            Writer.WriteLine(this.Name);
            Writer.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }
    }
}

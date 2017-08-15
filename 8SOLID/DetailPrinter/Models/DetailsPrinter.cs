using System.Collections.Generic;
using DetailPrinter.Interfaces;

namespace DetailPrinter.Models
{
    public class DetailsPrinter
    {
        private readonly IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                employee.Print();
            }
        }
    }
}
using System.Collections.Generic;
using DetailPrinter.Interfaces;
using DetailPrinter.Models;

namespace DetailPrinter
{
    public class Launcher
    {
        public static void Main()
        {
            ICollection<string> docs = new List<string>() { "report.txt", "overtimehours.txt" };
            Manager manager = new Manager("Mark", docs);
            Engineer engineer = new Engineer("Roger", 8);
            DetailsPrinter printer = new DetailsPrinter(new List<IEmployee>() { manager, engineer });

            printer.PrintDetails();
        }
    }
}

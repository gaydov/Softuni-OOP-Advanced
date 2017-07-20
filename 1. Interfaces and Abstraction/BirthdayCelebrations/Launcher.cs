using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Launcher
    {
        public static void Main()
        {
            ICollection<ILiving> livingBeings = new List<ILiving>();
            ICollection<IIndividual> robots = new List<IIndividual>();

            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                string[] args = input.Split();
                string entityType = args[0];

                switch (entityType)
                {
                    case "Citizen":
                        livingBeings.Add(new Citizen(args[1], int.Parse(args[2]), args[3], args[4]));
                        break;

                    case "Robot":
                        robots.Add(new Robot(args[1], args[2]));
                        break;

                    case "Pet":
                        livingBeings.Add(new Pet(args[1], args[2]));
                        break;
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            livingBeings.Where(b => b.Birthday.EndsWith(year)).Select(b => b.Birthday).ToList().ForEach(d => Console.WriteLine(d));
        }
    }
}

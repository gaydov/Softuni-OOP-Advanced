using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Launcher
    {
        public static void Main()
        {
            ICollection<IIndividual> population = new List<IIndividual>();
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] args = input.Split();

                if (args.Length == 3)
                {
                    population.Add(new Citizen(args[0], int.Parse(args[1]), args[2]));
                }
                else if (args.Length == 2)
                {
                    population.Add(new Robot(args[0], args[1]));
                }

                input = Console.ReadLine();
            }

            string lastDigitsFakeId = Console.ReadLine();

            population.Where(i => i.Id.EndsWith(lastDigitsFakeId)).Select(i => i.Id).ToList().ForEach(i => Console.WriteLine(i));
        }
    }
}

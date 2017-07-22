using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Launcher
    {
        public static void Main()
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            ICollection<IPerson> buyers = new List<IPerson>();

            for (int i = 0; i < countOfPeople; i++)
            {
                string[] buyerInfo = Console.ReadLine().Split();

                if (buyerInfo.Length == 4)
                {
                    buyers.Add(new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]));
                }
                else if (buyerInfo.Length == 3)
                {
                    buyers.Add(new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]));
                }
            }

            string name = Console.ReadLine();

            while (!name.Equals("End"))
            {
               if(buyers.Any(b => b.Name.Equals(name)))
                {
                    IPerson currentBuyer = buyers.FirstOrDefault(b => b.Name.Equals(name));
                    currentBuyer.BuyFood();
                }

                name = Console.ReadLine();
            }

            int totalFood = buyers.Sum(b => b.Food);
            Console.WriteLine(totalFood);
        }
    }
}

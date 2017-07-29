using System;
using System.Linq;

namespace CustomEnumAttribute
{
    public class Launcher
    {
        public static void Main()
        {
            string enumType = Console.ReadLine();

            Type currentType = null;

            if (enumType.Equals("Rank"))
            {
                currentType = typeof(CardRank);
            }
            else if (enumType.Equals("Suit"))
            {
                currentType = typeof(CardSuit);
            }

            foreach (object attribute in currentType.GetCustomAttributes(false))
            {
                Console.WriteLine(attribute);
            }
        }
    }
}

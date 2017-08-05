using System;

namespace CardRankPgm
{
    public class Launcher
    {
        public static void Main()
        {
            Array ranks = Enum.GetValues(typeof(CardRank));

            Console.WriteLine("Card Ranks:");
            foreach (object suit in ranks)
            {
                Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
            }
        }
    }
}

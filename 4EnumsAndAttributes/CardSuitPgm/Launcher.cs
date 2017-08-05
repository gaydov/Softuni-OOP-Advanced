using System;

namespace CardSuitPgm
{
    public class Launcher
    {
        public static void Main()
        {
            Array suits = Enum.GetValues(typeof(CardSuit));

            Console.WriteLine("Card Suits:");
            foreach (object suit in suits)
            {
                Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
            }
        }
    }
}

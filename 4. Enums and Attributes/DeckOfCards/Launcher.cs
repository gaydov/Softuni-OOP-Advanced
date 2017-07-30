using System;

namespace DeckOfCards
{
    public class Launcher
    {
        public static void Main()
        {
            Array suits = Enum.GetValues(typeof(CardSuit));
            Array ranks = Enum.GetValues(typeof(CardRank));

            foreach (object suit in suits)
            {
                foreach (object rank in ranks)
                {
                    Card currentCard = new Card(rank.ToString(), suit.ToString());
                    Console.WriteLine(currentCard);
                }
            }
        }
    }
}

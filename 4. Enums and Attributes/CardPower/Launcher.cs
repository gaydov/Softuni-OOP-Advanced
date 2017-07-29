using System;

namespace CardPower
{
    public class Launcher
    {
        public static void Main()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            try
            {
                Card card = new Card(rank, suit);
                Console.WriteLine(card);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

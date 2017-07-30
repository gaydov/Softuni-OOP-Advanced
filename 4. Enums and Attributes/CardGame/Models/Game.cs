using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Models
{
    public class Game
    {
        private string winner;

        public void StartGame()
        {
            IList<Card> deck = GenerateDeck();
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();

            Player firstPlayer = new Player(firstPlayerName);
            Player secondPlayer = new Player(secondPlayerName);

            while (firstPlayer.Cards.Count < 5 || secondPlayer.Cards.Count < 5)
            {
                string[] cardInfo = Console.ReadLine().Split();
                string rank = cardInfo[0];
                string suit = cardInfo[2];
                Card currentCard = null;

                try
                {
                    currentCard = new Card(rank, suit);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }

                if (!deck.Contains(currentCard))
                {
                    Console.WriteLine("Card is not in the deck.");
                    continue;
                }

                if (firstPlayer.Cards.Count < 5)
                {
                    firstPlayer.Cards.Add(currentCard);
                }
                else
                {
                    secondPlayer.Cards.Add(currentCard);
                }

                deck.Remove(currentCard);
            }

            this.winner = this.FindWinner(firstPlayer, secondPlayer);
        }

        public void PrintWinner()
        {
            Console.WriteLine(this.winner);
        }

        private string FindWinner(Player firstPlayer, Player secondPlayer)
        {
            Card firstPlayerStrongestCard = firstPlayer.Cards.Max();
            Card secondPlayerStrongestCard = secondPlayer.Cards.Max();

            if (firstPlayerStrongestCard.CompareTo(secondPlayerStrongestCard) == 1)
            {
                return $"{firstPlayer.Name} wins with {firstPlayerStrongestCard}.";
            }

            if (firstPlayerStrongestCard.CompareTo(secondPlayerStrongestCard) == -1)
            {
                return $"{secondPlayer.Name} wins with {secondPlayerStrongestCard}.";
            }

            return "No winner";
        }

        private IList<Card> GenerateDeck()
        {
            IList<Card> deck = new List<Card>();
            Array suits = Enum.GetNames(typeof(CardSuit));
            Array ranks = Enum.GetNames(typeof(CardRank));

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card currentCard = new Card(rank, suit);
                    deck.Add(currentCard);
                }
            }

            return deck;
        }
    }
}

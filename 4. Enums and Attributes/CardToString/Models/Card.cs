using System;

public class Card
{
    private CardRank rank;
    private CardSuit suit;

    public Card(string rank, string suit)
    {
        this.Rank = this.IsRankValid(rank);
        this.Suit = this.IsSuitValid(suit);
    }

    public CardRank Rank
    {
        get { return this.rank; }

        private set
        {
            // In case invalid rank is entered the first item from the enum is returned - "None"
            if (value == CardRank.None)
            {
                throw new ArgumentException("Invalid rank.");
            }

            this.rank = value;
        }
    }

    public CardSuit Suit
    {
        get { return this.suit; }

        private set
        {
            // In case invalid suit is entered the first item from the enum is returned - "None"
            if (value == CardSuit.None)
            {
                throw new ArgumentException("Invalid suit.");
            }

            this.suit = value;
        }
    }

    public int Power
    {
        get { return (int)this.Rank + (int)this.Suit; }
    }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
    }

    private CardSuit IsSuitValid(string inputSuit)
    {
        CardSuit resultSuit;
        Enum.TryParse(inputSuit, true, out resultSuit); // If the parse is not successfull the first item in the enum is reurned
        return resultSuit;
    }

    private CardRank IsRankValid(string inputRank)
    {
        CardRank resultRank;
        Enum.TryParse(inputRank, true, out resultRank); // If the parse is not successfull the first item in the enum is reurned
        return resultRank;
    }
}

using System;

public class Card : IComparable<Card>, IEquatable<Card>
{
    private readonly CardRank rank;
    private readonly CardSuit suit;

    public Card(string rank, string suit)
    {
        this.rank = this.GetRankIfValid(rank);
        this.suit = this.GetSuitIfValid(suit);
    }

    public int Power
    {
        get { return (int)this.rank + (int)this.suit; }
    }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }

    public bool Equals(Card other)
    {
        return this.Power == other.Power;
    }

    public override string ToString()
    {
        return $"{this.rank} of {this.suit}";
    }

    private CardRank GetRankIfValid(string rankToBeChecked)
    {
        try
        {
            CardRank result = (CardRank)Enum.Parse(typeof(CardRank), rankToBeChecked);
            return result;
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("No such card exists.");
        }
    }

    private CardSuit GetSuitIfValid(string suitToBeChecked)
    {
        try
        {
            CardSuit result = (CardSuit)Enum.Parse(typeof(CardSuit), suitToBeChecked);
            return result;
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("No such card exists.");
        }
    }
}
using System.Collections.Generic;

public class Player
{
    public Player(string name)
    {
        this.Name = name;
        this.Cards = new List<Card>();
    }

    public string Name { get; set; }

    public IList<Card> Cards { get; set; }
}

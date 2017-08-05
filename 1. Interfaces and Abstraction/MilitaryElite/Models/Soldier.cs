using System.Text;

public abstract class Soldier : ISoldier
{
    protected Soldier(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
        return sb.ToString().Trim();
    }
}

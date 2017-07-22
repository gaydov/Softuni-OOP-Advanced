namespace ExplicitInterfaces.Interfaces
{
    public interface IPerson : INameable
    {
        int Age { get; }
        string GetName();
    }
}
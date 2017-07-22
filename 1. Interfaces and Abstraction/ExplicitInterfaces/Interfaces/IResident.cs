namespace ExplicitInterfaces.Interfaces
{
    public interface IResident : INameable
    {
        string Country { get; }
        string GetName();
    }
}
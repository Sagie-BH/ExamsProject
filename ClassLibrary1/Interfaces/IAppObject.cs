namespace Domain.Interfaces
{
    public interface IAppObject
    {
        long Id { get; }
        string Title { get; set; }
    }
}
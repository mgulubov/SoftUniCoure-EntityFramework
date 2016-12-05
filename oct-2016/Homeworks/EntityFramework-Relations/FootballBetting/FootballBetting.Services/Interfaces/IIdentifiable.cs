namespace FootballBetting.Services.Interfaces
{
    public interface IIdentifiable<out TKey>
    {
        TKey Id { get; }
    }
}

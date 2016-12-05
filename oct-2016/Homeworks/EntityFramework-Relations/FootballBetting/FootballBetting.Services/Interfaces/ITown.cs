namespace FootballBetting.Services.Interfaces
{
    public interface ITown : IIdentifiable<int>, INameable
    {
        string CountryId { get; }
    }
}

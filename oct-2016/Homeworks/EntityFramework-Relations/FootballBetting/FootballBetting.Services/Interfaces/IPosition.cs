namespace FootballBetting.Services.Interfaces
{
    public interface IPosition : IIdentifiable<string>
    {
        string PositionDescription { get; }
    }
}

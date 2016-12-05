namespace FootballBetting.Services.Interfaces
{
    public interface IPlayer : IIdentifiable<int>, INameable
    {
        int SquadNumber { get; }

        int TeamId { get; }

        string PositionId { get; }
    }
}

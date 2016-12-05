namespace FootballBetting.Services.Interfaces
{
    public interface ITeam : IIdentifiable<int>, INameable
    {
        string Initials { get; }

        byte[] Logo { get; }

        decimal Budget { get; }

        int PrimaryKitColorId { get; }

        int SecondaryKitColorId { get; }

        int TownId { get; }
    }
}

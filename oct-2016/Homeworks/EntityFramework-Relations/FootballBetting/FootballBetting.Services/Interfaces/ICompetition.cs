namespace FootballBetting.Services.Interfaces
{
    public interface ICompetition : IIdentifiable<int>, INameable
    {
        int CompetitionTypeId { get; }
    }
}

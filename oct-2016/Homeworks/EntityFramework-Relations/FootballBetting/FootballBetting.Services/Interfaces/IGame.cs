namespace FootballBetting.Services.Interfaces
{
    using System;

    public interface IGame : IIdentifiable<int>
    {
        int HomeTeamId { get; }

        int AwayTeamId { get; }

        int HomeTeamGoals { get; }

        int AwayTeamGoals { get; }

        int RoundId { get; }

        int CompetitionId { get; }

        double HomeTeamWinBetRate { get; }

        double AwayTeamWinBetRate { get; }

        double DrawGameBetRate { get; }

        DateTime GameDateTime { get; }
    }
}

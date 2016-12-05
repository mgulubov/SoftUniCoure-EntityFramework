namespace FootballBetting.Services.DataTransferObjects
{
    using System;

    using Interfaces;

    public class GameDto : IGame
    {
        public GameDto(
            int id,
            int homeTeamId,
            int awayTeamId,
            int homeTeamGoals,
            int awayTeamGoals,
            int roundId,
            int competitionId,
            double homeTeamWinBetRate,
            double awayTeamWinBetRate,
            double drawGameBetRate,
            DateTime gameDateTime)
        {
            this.Id = id;
            this.HomeTeamId = homeTeamId;
            this.AwayTeamId = awayTeamId;
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
            this.RoundId = roundId;
            this.CompetitionId = competitionId;
            this.HomeTeamWinBetRate = homeTeamWinBetRate;
            this.AwayTeamWinBetRate = awayTeamWinBetRate;
            this.DrawGameBetRate = drawGameBetRate;
            this.GameDateTime = gameDateTime;
        }

        public int Id { get; }

        public int HomeTeamId { get; }

        public int AwayTeamId { get; }

        public int HomeTeamGoals { get; }

        public int AwayTeamGoals { get; }

        public int RoundId { get; }

        public int CompetitionId { get; }

        public double HomeTeamWinBetRate { get; }

        public double AwayTeamWinBetRate { get; }

        public double DrawGameBetRate { get; }

        public DateTime GameDateTime { get; }
    }
}

namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class BetGameDto : IBetGame
    {
        public BetGameDto(int gameId, int betId, int resultPredictionId)
        {
            this.GameId = gameId;
            this.BetId = betId;
            this.ResultPredictionId = resultPredictionId;
        }

        public int GameId { get; }

        public int BetId { get; }

        public int ResultPredictionId { get; }
    }
}

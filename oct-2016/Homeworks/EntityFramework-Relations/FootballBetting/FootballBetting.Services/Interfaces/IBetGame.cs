namespace FootballBetting.Services.Interfaces
{
    public interface IBetGame
    {
        int GameId { get; }

        int BetId { get; }

        int ResultPredictionId { get; }
    }
}

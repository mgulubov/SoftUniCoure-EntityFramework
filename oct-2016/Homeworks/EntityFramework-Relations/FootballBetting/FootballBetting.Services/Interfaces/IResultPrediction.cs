namespace FootballBetting.Services.Interfaces
{
    using Enums;

    public interface IResultPrediction : IIdentifiable<int>
    {
        ResultPreditionType Prediction { get; }
    }
}

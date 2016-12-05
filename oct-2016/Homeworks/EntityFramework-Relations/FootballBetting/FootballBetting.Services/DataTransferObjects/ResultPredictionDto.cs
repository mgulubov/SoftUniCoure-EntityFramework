namespace FootballBetting.Services.DataTransferObjects
{
    using Enums;
    using Interfaces;

    public class ResultPredictionDto : IResultPrediction
    {
        public ResultPredictionDto(int id, ResultPreditionType prediction)
        {
            this.Id = id;
            this.Prediction = prediction;
        }

        public int Id { get; }

        public ResultPreditionType Prediction { get; }
    }
}

namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class PositionDto : IPosition
    {
        public PositionDto(string id, string positionDescription)
        {
            this.Id = id;
            this.PositionDescription = positionDescription;
        }

        public string Id { get; }

        public string PositionDescription { get; }
    }
}

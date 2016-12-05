namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class PlayerDto : IPlayer
    {
        public PlayerDto(int id, int squadNumber, int teamId, string positionId, string name)
        {
            this.Id = id;
            this.SquadNumber = squadNumber;
            this.TeamId = teamId;
            this.PositionId = positionId;
            this.Name = name;
        }

        public int Id { get; }

        public int SquadNumber { get; }

        public int TeamId { get; }

        public string PositionId { get; }

        public string Name { get; }
    }
}

namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class CompetitionDto : ICompetition
    {
        public CompetitionDto(int id, int competitionTypeId, string name)
        {
            this.Id = id;
            this.CompetitionTypeId = competitionTypeId;
            this.Name = name;
        }

        public int Id { get; }

        public int CompetitionTypeId { get; }

        public string Name { get; }
    }
}

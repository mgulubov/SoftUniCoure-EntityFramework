namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class CompetitionTypeDto : ICompetitionType
    {
        public CompetitionTypeDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}

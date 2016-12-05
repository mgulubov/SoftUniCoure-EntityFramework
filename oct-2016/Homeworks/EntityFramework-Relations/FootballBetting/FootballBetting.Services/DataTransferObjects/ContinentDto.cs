namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class ContinentDto : IContinent
    {
        public ContinentDto(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}

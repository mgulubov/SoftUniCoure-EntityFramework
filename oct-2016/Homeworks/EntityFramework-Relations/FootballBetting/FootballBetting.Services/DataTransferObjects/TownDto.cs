namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class TownDto : ITown
    {
        public TownDto(int id, string countryId, string name)
        {
            this.Id = id;
            this.CountryId = countryId;
            this.Name = name;
        }

        public int Id { get; }

        public string CountryId { get; }

        public string Name { get; }
    }
}

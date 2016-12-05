namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class CountryDto : ICountry
    {
        public CountryDto(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}

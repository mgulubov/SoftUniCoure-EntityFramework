namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class RoundDto : IRound
    {
        public RoundDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}

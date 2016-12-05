namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class TeamDto : ITeam
    {
        public TeamDto(
            int id, 
            int primaryKitColorId, 
            int secondaryKitColorId, 
            int townId, 
            decimal budget,
            string name, 
            string initials,
            byte[] logo)
        {
            this.Id = id;
            this.PrimaryKitColorId = primaryKitColorId;
            this.SecondaryKitColorId = secondaryKitColorId;
            this.TownId = townId;
            this.Budget = budget;
            this.Name = name;
            this.Initials = initials;
            this.Logo = logo;
        }

        public int Id { get; }

        public int PrimaryKitColorId { get; }

        public int SecondaryKitColorId { get; }

        public int TownId { get; }

        public decimal Budget { get; }

        public string Name { get; }

        public string Initials { get; }

        public byte[] Logo { get; }
    }
}

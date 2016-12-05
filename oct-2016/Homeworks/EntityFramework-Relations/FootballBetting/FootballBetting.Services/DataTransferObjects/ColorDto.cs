namespace FootballBetting.Services.DataTransferObjects
{
    using Interfaces;

    public class ColorDto : IColor
    {
        public ColorDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}

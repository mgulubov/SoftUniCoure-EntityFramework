namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class PersonDto : IPersonDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string HomePlanet { get; set; }

        public int? HomePlanetId { get; set; }
    }
}

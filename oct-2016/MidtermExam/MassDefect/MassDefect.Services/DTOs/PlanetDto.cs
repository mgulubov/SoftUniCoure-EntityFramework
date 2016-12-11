namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class PlanetDto : IPlanetDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Sun { get; set; }

        public string SolarSystem { get; set; }

        public int? SunId { get; set; }

        public int? SolarSystemId { get; set; }
    }
}

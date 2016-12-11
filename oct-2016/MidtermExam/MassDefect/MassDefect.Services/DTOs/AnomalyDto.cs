namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class AnomalyDto : IAnomalyDto
    {
        public int? Id { get; set; }

        public int? OriginPlanetId { get; set; }

        public int? TeleportPlanetId { get; set; }

        public string OriginPlanet { get; set; }

        public string TeleportPlanet { get; set; }
    }
}

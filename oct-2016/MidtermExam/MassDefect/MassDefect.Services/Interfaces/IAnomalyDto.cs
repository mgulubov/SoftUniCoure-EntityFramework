namespace MassDefect.Services.Interfaces
{
    public interface IAnomalyDto
    {
        int? Id { get; set; }

        int? OriginPlanetId { get; set; }

        int? TeleportPlanetId { get; set; }

        string OriginPlanet { get; set; }

        string TeleportPlanet { get; set; }
    }
}

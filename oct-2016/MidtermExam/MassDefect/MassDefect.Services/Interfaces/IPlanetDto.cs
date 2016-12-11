namespace MassDefect.Services.Interfaces
{
    public interface IPlanetDto
    {
        int? Id { get; set; }

        string Name { get; set; }

        string Sun { get; set; }

        string SolarSystem { get; set; }

        int? SunId { get; set; }

        int? SolarSystemId { get; set; }
    }
}

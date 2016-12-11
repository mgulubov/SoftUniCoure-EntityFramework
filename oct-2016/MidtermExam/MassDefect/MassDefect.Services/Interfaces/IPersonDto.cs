namespace MassDefect.Services.Interfaces
{
    public interface IPersonDto
    {
        int? Id { get; set; }

        string Name { get; set; }

        string HomePlanet { get; set; }

        int? HomePlanetId { get; set; }
    }
}

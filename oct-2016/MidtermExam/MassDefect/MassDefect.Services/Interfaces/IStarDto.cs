namespace MassDefect.Services.Interfaces
{
    public interface IStarDto
    {
        int? Id { get; set; }

        int? SollarSystemId { get; set; }

        string Name { get; set; }

        string SolarSystem { get; set; }
    }
}

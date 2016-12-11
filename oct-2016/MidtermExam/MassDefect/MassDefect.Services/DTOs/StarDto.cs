namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class StarDto : IStarDto
    {
        public int? Id { get; set; }

        public int? SollarSystemId { get; set; }

        public string Name { get; set; }

        public string SolarSystem { get; set; }
    }
}

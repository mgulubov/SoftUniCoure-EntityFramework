namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class AnomaliesVictimsDto : IAnomaliesVictimsDto
    {
        public int Id { get; set; }

        public string Person { get; set; }
    }
}

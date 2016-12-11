namespace MassDefect.Services.DTOs
{
    using Interfaces;

    public class SollarSystemDto : ISollarSystemDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}

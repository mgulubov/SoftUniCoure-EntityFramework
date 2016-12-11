namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Anomalies")]
    public class Anomaly
    {
        [Column("Id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("OriginPlanetId")]
        public int OriginPlanetId { get; set; }

        [Column("TeleportPlanetId")]
        public int TeleportPlanetId { get; set; }

        [ForeignKey("OriginPlanetId")]
        [InverseProperty("HomePlanetAnomalies")]
        public virtual Planet OriginPlanet { get; set; }

        [ForeignKey("TeleportPlanetId")]
        [InverseProperty("TeleportedAnomalies")]
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; } = new HashSet<Person>();
    }
}

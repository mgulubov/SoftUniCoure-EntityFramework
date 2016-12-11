namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Planets")]
    public class Planet
    {
        [Column("Id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name"), Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [Column("SunId")]
        public int? SunId { get; set; }

        [Column("SollarSystemId")]
        public int? SollarSystemId { get; set; }

        [ForeignKey("SunId")]
        public virtual Star Sun { get; set; }

        [ForeignKey("SollarSystemId")]
        public virtual SolarSystem SollarSolarSystem { get; set; }

        public virtual ICollection<Person> Persons { get; set; } = new HashSet<Person>();

        public virtual ICollection<Anomaly> HomePlanetAnomalies { get; set; } = new HashSet<Anomaly>();

        public virtual ICollection<Anomaly> TeleportedAnomalies { get; set; } = new HashSet<Anomaly>();
    }
}

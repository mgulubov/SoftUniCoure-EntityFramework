namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SolarSystems")]
    public class SolarSystem
    {
        [Column("Id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name"), Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; } = new HashSet<Star>();

        public virtual ICollection<Planet> Planets { get; set; } = new HashSet<Planet>();
    }
}

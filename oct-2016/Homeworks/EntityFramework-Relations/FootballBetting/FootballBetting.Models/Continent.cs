namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Continent")]
    public class Continent : IContinent
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [RegularExpression(@"^(Europe|Africa|Asia|Australia|North\sAmerica|South\sAmerica|Antarctica)$")]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; } = new HashSet<Country>();
    }
}

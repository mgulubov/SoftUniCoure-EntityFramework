namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Colors")]
    public class Color : IColor
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

        [InverseProperty("SecondaryKitColor")]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();
    }
}

namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Teams")]
    public class Team
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [Column("Initials")]
        [RegularExpression(@"^([A-Z]{3})$")]
        public char[] Initials { get; set; }

        [Column("Logo")]
        [MaxLength(1000000, ErrorMessage = "Logo cannot be longer than 1000000 bytes.")]
        public byte[] Logo { get; set; }

        [Column("Budget")]
        public decimal Budget { get; set; }

        [Column("PrimaryKitColorId")]
        [Required]
        public int PrimaryKitColorId { get; set; }

        [Column("SecondaryKitColorId")]
        public int? SecondaryKitColorId { get; set; }

        [Column("TownId")]
        [Required]
        public int TownId { get; set; }

        [ForeignKey("PrimaryKitColorId")]
        public virtual Color PrimaryKitColor { get; set; }

        [ForeignKey("SecondaryKitColorId")]
        public virtual Color SecondaryKitColor { get; set; }

        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeTeamGames { get; set; } = new HashSet<Game>();

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayTeamGames { get; set; } = new HashSet<Game>();
    }
}

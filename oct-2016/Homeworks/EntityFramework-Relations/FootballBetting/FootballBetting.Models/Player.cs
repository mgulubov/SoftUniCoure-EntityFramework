namespace FootballBetting.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Players")]
    public class Player
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SquadNumber")]
        [Required]
        [Range(minimum: 0, maximum: 99, ErrorMessage = "Squad number cannot be negative or > 99")]
        public int SquadNumber { get; set; }

        [Column("TeamId")]
        public int TeamId { get; set; }

        [Column("PositionId")]
        [Required]
        public string PositionId { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [Column("IsCurrentlyInjured")]
        [Required]
        public bool IsCurrentlyInjured { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}

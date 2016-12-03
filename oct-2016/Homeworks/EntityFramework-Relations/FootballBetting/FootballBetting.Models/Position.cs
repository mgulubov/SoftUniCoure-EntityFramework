namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Positions")]
    public class Position
    {
        [Column("Id")]
        [Key]
        [MaxLength(2, ErrorMessage = "Id cannot be longer than 2 characters.")]
        [RegularExpression(@"^([A-Z]{2})$")]
        public string Id { get; set; }

        [Column("PositionDescription")]
        [Required]
        [MaxLength(100, ErrorMessage = "Position Description cannot be longer than 100 characters.")]
        public string PositionDescription { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}

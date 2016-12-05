namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Rounds")]
    public class Round : IRound
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(500, ErrorMessage = "Name cannot be longer than 500 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}

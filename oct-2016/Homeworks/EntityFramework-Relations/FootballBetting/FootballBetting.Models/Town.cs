namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Towns")]
    public class Town : ITown
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("CountryId")]
        public string CountryId { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}

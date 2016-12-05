namespace FootballBetting.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Countries")]
    public class Country : ICountry
    {
        [Column("Id")]
        [Key]
        [MaxLength(3)]
        [RegularExpression(@"^([A-Z]{3})$")]
        public string Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(300, ErrorMessage = "Name cannot be longer than 300 characters.")]
        public string Name { get; set; }

        public virtual Continent Continent { get; set; }
    }
}

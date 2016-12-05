namespace FootballBetting.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    using Services.Enums;

    [Table("ResultPredictions")]
    public class ResultPrediction : IResultPrediction
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("Prediction")]
        [Required]
        [Index(IsUnique = true)]
        public ResultPreditionType Prediction { get; set; }

        public virtual ICollection<BetGame> BetsGames { get; set; } = new HashSet<BetGame>();
    }
}

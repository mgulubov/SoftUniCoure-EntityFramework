namespace FootballBetting.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BetsGames")]
    public class BetGame
    {
        [Column("GameId", Order = 0)]
        [Key]
        public int GameId { get; set; }

        [Column("BetId", Order = 1), Key]
        public int BetId { get; set; }

        [Column("ResultPredictionId")]
        public int ResultPredictionId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

        [ForeignKey("BetId")]
        public virtual Bet Bet { get; set; }

        [ForeignKey("ResultPredictionId")]
        public virtual ResultPrediction ResultPrediction { get; set; }
    }
}

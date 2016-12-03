namespace FootballBetting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bets")]
    public class Bet
    {
        [Column("Id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UserId"), Required]
        public int UserId { get; set; }

        [Column("BetMoney")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "BetMoneyCannot be negative")]
        public decimal BetMoney { get; set; }

        [Column("BetDateTime")]
        public DateTime BetDateTime { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<BetGame> BetsGames { get; set; } = new HashSet<BetGame>();
    }
}

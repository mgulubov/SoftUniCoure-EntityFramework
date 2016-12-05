namespace FootballBetting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Services.Interfaces;

    [Table("Games")]
    public class Game : IGame
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("HomeTeamId")]
        public int HomeTeamId { get; set; }

        [Column("AwayTeamId")]
        public int AwayTeamId { get; set; }

        [Column("HomeTeamGoals")]
        [Range(minimum: 0, maximum: 99, ErrorMessage = "HomeTeamGoals cannot be less than 0 or > 99")]
        public int HomeTeamGoals { get; set; }

        [Column("AwayTeamGoals")]
        [Range(minimum: 0, maximum: 99, ErrorMessage = "AwayTeamGoals cannot be less than 0 or > 99")]
        public int AwayTeamGoals { get; set; }

        [Column("RoundId")]
        public int RoundId { get; set; }

        [Column("CompetitionId")]
        public int CompetitionId { get; set; }

        [Column("HomeTeamWinBetRate")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "HomeTeamWinBetRate cannot be negative.")]
        public double HomeTeamWinBetRate { get; set; }

        [Column("AwayTeamWinBetRate")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "AwayTeamWinBetRate cannot be negative.")]
        public double AwayTeamWinBetRate { get; set; }

        [Column("DrawGameBetRate")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "DrawGameBetRate cannot be negative.")]
        public double DrawGameBetRate { get; set; }

        [Column("GameDateTime"), Required]
        public DateTime GameDateTime { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        [ForeignKey("RoundId")]
        public virtual Round Round { get; set; }

        [ForeignKey("CompetitionId")]
        public virtual Competition Competition { get; set; }

        public virtual ICollection<BetGame> BetsGames { get; set; } = new HashSet<BetGame>();
    }
}

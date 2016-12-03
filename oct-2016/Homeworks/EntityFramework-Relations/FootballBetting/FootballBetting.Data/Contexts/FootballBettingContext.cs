namespace FootballBetting.Data.Contexts
{
    using System.Data.Entity;

    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        
        public virtual DbSet<BetGame> BetsGames { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<ResultPrediction> ResultPredictions { get; set; }

        public virtual DbSet<Round> Rounds { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                        .HasRequired<Color>(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                        .HasRequired<Color>(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                        .HasRequired<Team>(g => g.HomeTeam)
                        .WithMany(t => t.HomeTeamGames)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Game>()
                        .HasRequired<Team>(g => g.AwayTeam)
                        .WithMany(t => t.AwayTeamGames)
                        .WillCascadeOnDelete(false);
        }
    }
}
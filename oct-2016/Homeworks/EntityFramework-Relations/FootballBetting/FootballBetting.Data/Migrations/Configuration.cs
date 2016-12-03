namespace FootballBetting.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Contexts;

    internal sealed class Configuration : DbMigrationsConfiguration<FootballBettingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "FootballBettingContext";
        }

        protected override void Seed(FootballBettingContext context)
        {
        }
    }
}

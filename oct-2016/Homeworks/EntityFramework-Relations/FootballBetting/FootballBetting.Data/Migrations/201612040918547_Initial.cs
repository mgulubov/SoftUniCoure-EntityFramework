namespace FootballBetting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BetMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BetDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BetsGames",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        BetId = c.Int(nullable: false),
                        ResultPredictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.BetId })
                .ForeignKey("dbo.Bets", t => t.BetId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.ResultPredictions", t => t.ResultPredictionId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.BetId)
                .Index(t => t.ResultPredictionId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        RoundId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        HomeTeamWinBetRate = c.Double(nullable: false),
                        AwayTeamWinBetRate = c.Double(nullable: false),
                        DrawGameBetRate = c.Double(nullable: false),
                        GameDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .ForeignKey("dbo.Rounds", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.RoundId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Logo = c.Binary(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrimaryKitColorId = c.Int(nullable: false),
                        SecondaryKitColorId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.PrimaryKitColorId)
                .ForeignKey("dbo.Colors", t => t.SecondaryKitColorId)
                .ForeignKey("dbo.Towns", t => t.TownId, cascadeDelete: true)
                .Index(t => t.PrimaryKitColorId)
                .Index(t => t.SecondaryKitColorId)
                .Index(t => t.TownId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SquadNumber = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        PositionId = c.String(nullable: false, maxLength: 2),
                        Name = c.String(nullable: false, maxLength: 200),
                        IsCurrentlyInjured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 2),
                        PositionDescription = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.String(maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 300),
                        Continent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continent", t => t.Continent_Id)
                .Index(t => t.Continent_Id);
            
            CreateTable(
                "dbo.Continent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        CompetitionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompetitionTypes", t => t.CompetitionTypeId, cascadeDelete: true)
                .Index(t => t.CompetitionTypeId);
            
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultPredictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prediction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Prediction, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 200),
                        FullName = c.String(maxLength: 500),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropForeignKey("dbo.BetsGames", "ResultPredictionId", "dbo.ResultPredictions");
            DropForeignKey("dbo.Games", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.Games", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Competitions", "CompetitionTypeId", "dbo.CompetitionTypes");
            DropForeignKey("dbo.BetsGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Towns", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Continent_Id", "dbo.Continent");
            DropForeignKey("dbo.Teams", "SecondaryKitColorId", "dbo.Colors");
            DropForeignKey("dbo.Teams", "PrimaryKitColorId", "dbo.Colors");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.BetsGames", "BetId", "dbo.Bets");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.ResultPredictions", new[] { "Prediction" });
            DropIndex("dbo.Competitions", new[] { "CompetitionTypeId" });
            DropIndex("dbo.Countries", new[] { "Continent_Id" });
            DropIndex("dbo.Towns", new[] { "CountryId" });
            DropIndex("dbo.Players", new[] { "PositionId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "TownId" });
            DropIndex("dbo.Teams", new[] { "SecondaryKitColorId" });
            DropIndex("dbo.Teams", new[] { "PrimaryKitColorId" });
            DropIndex("dbo.Games", new[] { "CompetitionId" });
            DropIndex("dbo.Games", new[] { "RoundId" });
            DropIndex("dbo.Games", new[] { "AwayTeamId" });
            DropIndex("dbo.Games", new[] { "HomeTeamId" });
            DropIndex("dbo.BetsGames", new[] { "ResultPredictionId" });
            DropIndex("dbo.BetsGames", new[] { "BetId" });
            DropIndex("dbo.BetsGames", new[] { "GameId" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.ResultPredictions");
            DropTable("dbo.Rounds");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.Competitions");
            DropTable("dbo.Continent");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Colors");
            DropTable("dbo.Positions");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.BetsGames");
            DropTable("dbo.Bets");
        }
    }
}

namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anomalies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginPlanetId = c.Int(nullable: false),
                        TeleportPlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.OriginPlanetId)
                .ForeignKey("dbo.Planets", t => t.TeleportPlanetId)
                .Index(t => t.OriginPlanetId)
                .Index(t => t.TeleportPlanetId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        SunId = c.Int(nullable: false),
                        SollarSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SollarSystemId, cascadeDelete: true)
                .ForeignKey("dbo.Stars", t => t.SunId, cascadeDelete: true)
                .Index(t => t.SunId)
                .Index(t => t.SollarSystemId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        HomePlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.HomePlanetId, cascadeDelete: true)
                .Index(t => t.HomePlanetId);
            
            CreateTable(
                "dbo.SolarSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        SollarSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SollarSystemId)
                .Index(t => t.SollarSystemId);
            
            CreateTable(
                "dbo.AnomalyVictims",
                c => new
                    {
                        AnomalyId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnomalyId, t.PersonId })
                .ForeignKey("dbo.Anomalies", t => t.AnomalyId, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.AnomalyId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnomalyVictims", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.AnomalyVictims", "AnomalyId", "dbo.Anomalies");
            DropForeignKey("dbo.Anomalies", "TeleportPlanetId", "dbo.Planets");
            DropForeignKey("dbo.Anomalies", "OriginPlanetId", "dbo.Planets");
            DropForeignKey("dbo.Stars", "SollarSystemId", "dbo.SolarSystems");
            DropForeignKey("dbo.Planets", "SunId", "dbo.Stars");
            DropForeignKey("dbo.Planets", "SollarSystemId", "dbo.SolarSystems");
            DropForeignKey("dbo.Persons", "HomePlanetId", "dbo.Planets");
            DropIndex("dbo.AnomalyVictims", new[] { "PersonId" });
            DropIndex("dbo.AnomalyVictims", new[] { "AnomalyId" });
            DropIndex("dbo.Stars", new[] { "SollarSystemId" });
            DropIndex("dbo.Persons", new[] { "HomePlanetId" });
            DropIndex("dbo.Planets", new[] { "SollarSystemId" });
            DropIndex("dbo.Planets", new[] { "SunId" });
            DropIndex("dbo.Anomalies", new[] { "TeleportPlanetId" });
            DropIndex("dbo.Anomalies", new[] { "OriginPlanetId" });
            DropTable("dbo.AnomalyVictims");
            DropTable("dbo.Stars");
            DropTable("dbo.SolarSystems");
            DropTable("dbo.Persons");
            DropTable("dbo.Planets");
            DropTable("dbo.Anomalies");
        }
    }
}

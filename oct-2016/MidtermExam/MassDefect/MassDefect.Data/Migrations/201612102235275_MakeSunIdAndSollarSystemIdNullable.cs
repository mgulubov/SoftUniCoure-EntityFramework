namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSunIdAndSollarSystemIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Planets", "SollarSystemId", "dbo.SolarSystems");
            DropForeignKey("dbo.Planets", "SunId", "dbo.Stars");
            DropIndex("dbo.Planets", new[] { "SunId" });
            DropIndex("dbo.Planets", new[] { "SollarSystemId" });
            AlterColumn("dbo.Planets", "SunId", c => c.Int());
            AlterColumn("dbo.Planets", "SollarSystemId", c => c.Int());
            CreateIndex("dbo.Planets", "SunId");
            CreateIndex("dbo.Planets", "SollarSystemId");
            AddForeignKey("dbo.Planets", "SollarSystemId", "dbo.SolarSystems", "Id");
            AddForeignKey("dbo.Planets", "SunId", "dbo.Stars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planets", "SunId", "dbo.Stars");
            DropForeignKey("dbo.Planets", "SollarSystemId", "dbo.SolarSystems");
            DropIndex("dbo.Planets", new[] { "SollarSystemId" });
            DropIndex("dbo.Planets", new[] { "SunId" });
            AlterColumn("dbo.Planets", "SollarSystemId", c => c.Int(nullable: false));
            AlterColumn("dbo.Planets", "SunId", c => c.Int(nullable: false));
            CreateIndex("dbo.Planets", "SollarSystemId");
            CreateIndex("dbo.Planets", "SunId");
            AddForeignKey("dbo.Planets", "SunId", "dbo.Stars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Planets", "SollarSystemId", "dbo.SolarSystems", "Id", cascadeDelete: true);
        }
    }
}

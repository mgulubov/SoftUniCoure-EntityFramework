namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SollarSystemIdNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Stars", new[] { "SollarSystemId" });
            AlterColumn("dbo.Stars", "SollarSystemId", c => c.Int());
            CreateIndex("dbo.Stars", "SollarSystemId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stars", new[] { "SollarSystemId" });
            AlterColumn("dbo.Stars", "SollarSystemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stars", "SollarSystemId");
        }
    }
}

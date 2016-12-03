namespace StudentSystemApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicensesTableAndRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicenseResources",
                c => new
                    {
                        License_Id = c.Int(nullable: false),
                        Resource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.License_Id, t.Resource_Id })
                .ForeignKey("dbo.Licenses", t => t.License_Id, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.License_Id)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LicenseResources", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.LicenseResources", "License_Id", "dbo.Licenses");
            DropIndex("dbo.LicenseResources", new[] { "Resource_Id" });
            DropIndex("dbo.LicenseResources", new[] { "License_Id" });
            DropTable("dbo.LicenseResources");
            DropTable("dbo.Licenses");
        }
    }
}

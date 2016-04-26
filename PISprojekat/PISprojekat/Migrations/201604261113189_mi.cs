namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncidentAdministrators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IncidentId = c.Int(),
                        IncidentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Incidents", t => t.IncidentId)
                .ForeignKey("dbo.IncidentCategories", t => t.IncidentCategoryId)
                .Index(t => t.IncidentId)
                .Index(t => t.IncidentCategoryId);
            
            AddColumn("dbo.IncidentCategories", "Class", c => c.String());
            DropColumn("dbo.IncidentCategories", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IncidentCategories", "Category", c => c.String());
            DropForeignKey("dbo.IncidentAdministrators", "IncidentCategoryId", "dbo.IncidentCategories");
            DropForeignKey("dbo.IncidentAdministrators", "IncidentId", "dbo.Incidents");
            DropIndex("dbo.IncidentAdministrators", new[] { "IncidentCategoryId" });
            DropIndex("dbo.IncidentAdministrators", new[] { "IncidentId" });
            DropColumn("dbo.IncidentCategories", "Class");
            DropTable("dbo.IncidentAdministrators");
        }
    }
}

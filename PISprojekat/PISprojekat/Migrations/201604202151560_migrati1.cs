namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncidentClassifications", "ID", "dbo.Incidents");
            DropForeignKey("dbo.IncidentClassifications", "ID", "dbo.IncidentCategories");
            DropIndex("dbo.IncidentClassifications", new[] { "ID" });
            DropTable("dbo.IncidentCategories");
            DropTable("dbo.IncidentClassifications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IncidentClassifications",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IncidentCategoryID = c.Int(),
                        IncidentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IncidentCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.IncidentClassifications", "ID");
            AddForeignKey("dbo.IncidentClassifications", "ID", "dbo.IncidentCategories", "ID");
            AddForeignKey("dbo.IncidentClassifications", "ID", "dbo.Incidents", "ID");
        }
    }
}

namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncidentCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IncidentClassification_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IncidentClassifications", t => t.IncidentClassification_ID)
                .Index(t => t.IncidentClassification_ID);
            
            CreateTable(
                "dbo.IncidentClassifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Describe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncidentCategories", "IncidentClassification_ID", "dbo.IncidentClassifications");
            DropIndex("dbo.IncidentCategories", new[] { "IncidentClassification_ID" });
            DropTable("dbo.IncidentClassifications");
            DropTable("dbo.IncidentCategories");
        }
    }
}

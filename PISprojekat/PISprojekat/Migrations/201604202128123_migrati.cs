namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncidentCategories", "IncidentClassification_ID", "dbo.IncidentClassifications");
            DropIndex("dbo.IncidentCategories", new[] { "IncidentClassification_ID" });
            DropPrimaryKey("dbo.IncidentClassifications");
            AddColumn("dbo.IncidentClassifications", "IncidentCategoryID", c => c.Int());
            AddColumn("dbo.IncidentClassifications", "IncidentID", c => c.Int());
            AlterColumn("dbo.IncidentClassifications", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IncidentClassifications", "ID");
            CreateIndex("dbo.IncidentClassifications", "ID");
            AddForeignKey("dbo.IncidentClassifications", "ID", "dbo.Incidents", "ID");
            AddForeignKey("dbo.IncidentClassifications", "ID", "dbo.IncidentCategories", "ID");
            DropColumn("dbo.IncidentCategories", "IncidentClassification_ID");
            DropColumn("dbo.IncidentClassifications", "Title");
            DropColumn("dbo.IncidentClassifications", "Describe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IncidentClassifications", "Describe", c => c.String(nullable: false));
            AddColumn("dbo.IncidentClassifications", "Title", c => c.String(nullable: false));
            AddColumn("dbo.IncidentCategories", "IncidentClassification_ID", c => c.Int());
            DropForeignKey("dbo.IncidentClassifications", "ID", "dbo.IncidentCategories");
            DropForeignKey("dbo.IncidentClassifications", "ID", "dbo.Incidents");
            DropIndex("dbo.IncidentClassifications", new[] { "ID" });
            DropPrimaryKey("dbo.IncidentClassifications");
            AlterColumn("dbo.IncidentClassifications", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.IncidentClassifications", "IncidentID");
            DropColumn("dbo.IncidentClassifications", "IncidentCategoryID");
            AddPrimaryKey("dbo.IncidentClassifications", "ID");
            CreateIndex("dbo.IncidentCategories", "IncidentClassification_ID");
            AddForeignKey("dbo.IncidentCategories", "IncidentClassification_ID", "dbo.IncidentClassifications", "ID");
        }
    }
}

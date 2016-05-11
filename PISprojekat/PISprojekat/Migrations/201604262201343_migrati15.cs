namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncidentStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Incidents", "IncidentStatusId", c => c.Int());
            CreateIndex("dbo.Incidents", "IncidentStatusId");
            AddForeignKey("dbo.Incidents", "IncidentStatusId", "dbo.IncidentStatus", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "IncidentStatusId", "dbo.IncidentStatus");
            DropIndex("dbo.Incidents", new[] { "IncidentStatusId" });
            DropColumn("dbo.Incidents", "IncidentStatusId");
            DropTable("dbo.IncidentStatus");
        }
    }
}

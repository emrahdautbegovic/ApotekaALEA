namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IncidentId", c => c.Int());
            CreateIndex("dbo.Messages", "IncidentId");
            AddForeignKey("dbo.Messages", "IncidentId", "dbo.Incidents", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "IncidentId", "dbo.Incidents");
            DropIndex("dbo.Messages", new[] { "IncidentId" });
            DropColumn("dbo.Messages", "IncidentId");
        }
    }
}

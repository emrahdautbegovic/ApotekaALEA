namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PriorityType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Incidents", "PriorityId", c => c.Int());
            CreateIndex("dbo.Incidents", "PriorityId");
            AddForeignKey("dbo.Incidents", "PriorityId", "dbo.Priorities", "ID");
            DropColumn("dbo.Incidents", "Priority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidents", "Priority", c => c.String());
            DropForeignKey("dbo.Incidents", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.Incidents", new[] { "PriorityId" });
            DropColumn("dbo.Incidents", "PriorityId");
            DropTable("dbo.Priorities");
        }
    }
}

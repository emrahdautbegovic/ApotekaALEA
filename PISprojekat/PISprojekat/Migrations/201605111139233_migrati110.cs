namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati110 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectPlans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Describe = c.String(nullable: false),
                        PlanDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Risks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        RiskLevel = c.Int(nullable: false),
                        ProjectPlanId = c.Int(),
                        ThreatId = c.Int(),
                        VulnerabilityId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectPlans", t => t.ProjectPlanId)
                .ForeignKey("dbo.Threats", t => t.ThreatId)
                .ForeignKey("dbo.Vulnerabilities", t => t.VulnerabilityId)
                .Index(t => t.ProjectPlanId)
                .Index(t => t.ThreatId)
                .Index(t => t.VulnerabilityId);
            
            CreateTable(
                "dbo.Threats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Describe = c.String(nullable: false),
                        ProjectPlanId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectPlans", t => t.ProjectPlanId)
                .Index(t => t.ProjectPlanId);
            
            CreateTable(
                "dbo.Vulnerabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Describe = c.String(nullable: false),
                        ProjectPlanId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectPlans", t => t.ProjectPlanId)
                .Index(t => t.ProjectPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Risks", "VulnerabilityId", "dbo.Vulnerabilities");
            DropForeignKey("dbo.Vulnerabilities", "ProjectPlanId", "dbo.ProjectPlans");
            DropForeignKey("dbo.Risks", "ThreatId", "dbo.Threats");
            DropForeignKey("dbo.Threats", "ProjectPlanId", "dbo.ProjectPlans");
            DropForeignKey("dbo.Risks", "ProjectPlanId", "dbo.ProjectPlans");
            DropIndex("dbo.Vulnerabilities", new[] { "ProjectPlanId" });
            DropIndex("dbo.Threats", new[] { "ProjectPlanId" });
            DropIndex("dbo.Risks", new[] { "VulnerabilityId" });
            DropIndex("dbo.Risks", new[] { "ThreatId" });
            DropIndex("dbo.Risks", new[] { "ProjectPlanId" });
            DropTable("dbo.Vulnerabilities");
            DropTable("dbo.Threats");
            DropTable("dbo.Risks");
            DropTable("dbo.ProjectPlans");
        }
    }
}

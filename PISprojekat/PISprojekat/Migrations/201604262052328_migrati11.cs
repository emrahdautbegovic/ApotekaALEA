namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidents", "CreateTime");
        }
    }
}

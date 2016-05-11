namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incidents", "Priority", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incidents", "Priority");
        }
    }
}

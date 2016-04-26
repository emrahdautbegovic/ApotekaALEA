namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncidentCategories", "Category", c => c.String());
            DropColumn("dbo.IncidentCategories", "Class");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IncidentCategories", "Class", c => c.String());
            DropColumn("dbo.IncidentCategories", "Category");
        }
    }
}

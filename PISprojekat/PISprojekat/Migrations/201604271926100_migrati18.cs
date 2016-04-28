namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Parrent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "Parrent");
        }
    }
}

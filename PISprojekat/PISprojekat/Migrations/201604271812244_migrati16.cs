namespace PISprojekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrati16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        AuthorId = c.Int(),
                        StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MessageAuthors", t => t.AuthorId)
                .ForeignKey("dbo.MessageStatus", t => t.StatusId)
                .Index(t => t.AuthorId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.MessageAuthors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MessageStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "StatusId", "dbo.MessageStatus");
            DropForeignKey("dbo.Messages", "AuthorId", "dbo.MessageAuthors");
            DropIndex("dbo.Messages", new[] { "StatusId" });
            DropIndex("dbo.Messages", new[] { "AuthorId" });
            DropTable("dbo.MessageStatus");
            DropTable("dbo.MessageAuthors");
            DropTable("dbo.Messages");
        }
    }
}

namespace EventHub.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        OtherDetails = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Invitation",
                c => new
                    {
                        InvitationID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationID)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "UserID", "dbo.User");
            DropForeignKey("dbo.Invitation", "EventID", "dbo.Event");
            DropIndex("dbo.Invitation", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Invitation");
            DropTable("dbo.Event");
        }
    }
}

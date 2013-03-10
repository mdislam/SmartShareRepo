namespace SmartShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        AdvertisementsID = c.Int(nullable: false),
                        MessageBody = c.String(nullable: false),
                        SendTo = c.Int(nullable: false),
                        SendFrom = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        HaveSeen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}

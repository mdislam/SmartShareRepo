namespace SmartShareV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification1 : DbMigration
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
            
            //DropTable("dbo.Advertisements");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Advertisements",
            //    c => new
            //        {
            //            AdvertisementID = c.Int(nullable: false, identity: true),
            //            AdvertisementTitle = c.String(nullable: false),
            //            AdvertisementDesc = c.String(nullable: false),
            //            AdvertisementImage = c.Binary(),
            //            UserId = c.Int(nullable: false),
            //            CreatedOn = c.DateTime(nullable: false),
            //            CategoryType = c.String(nullable: false),
            //            Price = c.Double(nullable: false),
            //            AdvertisementType = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AdvertisementID);
            
            DropTable("dbo.Notifications");
        }
    }
}

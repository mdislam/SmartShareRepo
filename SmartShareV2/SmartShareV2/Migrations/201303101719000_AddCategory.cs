namespace SmartShareV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            //DropTable("dbo.Notifications");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Notifications",
            //    c => new
            //        {
            //            NotificationID = c.Int(nullable: false, identity: true),
            //            AdvertisementsID = c.Int(nullable: false),
            //            MessageBody = c.String(nullable: false),
            //            SendTo = c.Int(nullable: false),
            //            SendFrom = c.Int(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            HaveSeen = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.NotificationID);
            
            DropTable("dbo.Categories");
        }
    }
}

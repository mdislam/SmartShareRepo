namespace SmartShareV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        AdvertisementID = c.Int(nullable: false, identity: true),
                        AdvertisementTitle = c.String(nullable: false),
                        AdvertisementDesc = c.String(nullable: false),
                        AdvertisementImage = c.Binary(),
                        UserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CategoryType = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        AdvertisementType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdvertisementID);
            
            //DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            CategoryID = c.Int(nullable: false, identity: true),
            //            CategoryName = c.String(nullable: false),
            //            CategoryDescription = c.String(),
            //        })
            //    .PrimaryKey(t => t.CategoryID);
            
            DropTable("dbo.Advertisements");
        }
    }
}

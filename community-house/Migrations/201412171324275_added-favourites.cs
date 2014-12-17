namespace community_house.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfavourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        FavouriteID = c.Int(nullable: false, identity: true),
                        HouseID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FavouriteID)
                .ForeignKey("dbo.Houses", t => t.HouseID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.HouseID)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favourites", "HouseID", "dbo.Houses");
            DropIndex("dbo.Favourites", new[] { "UserId" });
            DropIndex("dbo.Favourites", new[] { "HouseID" });
            DropTable("dbo.Favourites");
        }
    }
}

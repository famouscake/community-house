namespace community_house.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class housestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        HouseID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Price = c.Double(nullable: false),
                        Area = c.Double(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.HouseID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Pictures", "House_HouseID", c => c.Int());
            CreateIndex("dbo.Pictures", "House_HouseID");
            AddForeignKey("dbo.Pictures", "House_HouseID", "dbo.Houses", "HouseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pictures", "House_HouseID", "dbo.Houses");
            DropIndex("dbo.Pictures", new[] { "House_HouseID" });
            DropIndex("dbo.Houses", new[] { "UserId" });
            DropColumn("dbo.Pictures", "House_HouseID");
            DropTable("dbo.Houses");
        }
    }
}

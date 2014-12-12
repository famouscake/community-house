namespace community_house.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pircutetohouserel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "House_HouseID", "dbo.Houses");
            DropIndex("dbo.Pictures", new[] { "House_HouseID" });
            RenameColumn(table: "dbo.Pictures", name: "House_HouseID", newName: "HouseID");
            AlterColumn("dbo.Pictures", "HouseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "HouseID");
            AddForeignKey("dbo.Pictures", "HouseID", "dbo.Houses", "HouseID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "HouseID", "dbo.Houses");
            DropIndex("dbo.Pictures", new[] { "HouseID" });
            AlterColumn("dbo.Pictures", "HouseID", c => c.Int());
            RenameColumn(table: "dbo.Pictures", name: "HouseID", newName: "House_HouseID");
            CreateIndex("dbo.Pictures", "House_HouseID");
            AddForeignKey("dbo.Pictures", "House_HouseID", "dbo.Houses", "HouseID");
        }
    }
}

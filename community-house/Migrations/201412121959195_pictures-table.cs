namespace community_house.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picturestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.PictureID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pictures");
        }
    }
}

namespace ListMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToItemnav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WatchedItems",
                c => new
                    {
                        WatchedItemId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WatchedItemId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.WatchedItems", new[] { "UserId" });
            DropForeignKey("dbo.WatchedItems", "UserId", "dbo.UserProfile");
            DropTable("dbo.WatchedItems");
        }
    }
}

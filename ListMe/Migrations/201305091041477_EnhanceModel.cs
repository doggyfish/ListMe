namespace ListMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnhanceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.UserProfile", "ContactNumber", c => c.String());
            AddForeignKey("dbo.ListItems", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            CreateIndex("dbo.ListItems", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropIndex("dbo.ListItems", new[] { "UserId" });
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ListItems", "UserId", "dbo.UserProfile");
            DropColumn("dbo.UserProfile", "ContactNumber");
            DropTable("dbo.UserAddresses");
        }
    }
}

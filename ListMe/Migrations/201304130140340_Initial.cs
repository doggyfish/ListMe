namespace ListMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ListItems",
                c => new
                    {
                        ListItemId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Icon = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemComments",
                c => new
                    {
                        ItemCommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ListItemId = c.Int(nullable: false),
                        ListItem_ListItemId = c.Int(),
                        ListItem_ListItemId1 = c.Int(),
                        ListItem_ListItemId2 = c.Int(),
                    })
                .PrimaryKey(t => t.ItemCommentId)
                .ForeignKey("dbo.ListItems", t => t.ListItemId, cascadeDelete: true)
                .ForeignKey("dbo.ListItems", t => t.ListItem_ListItemId)
                .ForeignKey("dbo.ListItems", t => t.ListItem_ListItemId1)
                .ForeignKey("dbo.ListItems", t => t.ListItem_ListItemId2)
                .Index(t => t.ListItemId)
                .Index(t => t.ListItem_ListItemId)
                .Index(t => t.ListItem_ListItemId1)
                .Index(t => t.ListItem_ListItemId2);
            
            CreateTable(
                "dbo.ItemDetails",
                c => new
                    {
                        ItemDetailId = c.Int(nullable: false, identity: true),
                        ListItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDetailId)
                .ForeignKey("dbo.ListItems", t => t.ListItemId, cascadeDelete: true)
                .Index(t => t.ListItemId);
            
            CreateTable(
                "dbo.ItemImages",
                c => new
                    {
                        ItemImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(),
                        ListItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemImageId)
                .ForeignKey("dbo.ListItems", t => t.ListItemId, cascadeDelete: true)
                .Index(t => t.ListItemId);
            
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        TodoItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        TodoListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TodoItemId)
                .ForeignKey("dbo.TodoLists", t => t.TodoListId, cascadeDelete: true)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        TodoListId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TodoListId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoItems", new[] { "TodoListId" });
            DropIndex("dbo.ItemImages", new[] { "ListItemId" });
            DropIndex("dbo.ItemDetails", new[] { "ListItemId" });
            DropIndex("dbo.ItemComments", new[] { "ListItem_ListItemId2" });
            DropIndex("dbo.ItemComments", new[] { "ListItem_ListItemId1" });
            DropIndex("dbo.ItemComments", new[] { "ListItem_ListItemId" });
            DropIndex("dbo.ItemComments", new[] { "ListItemId" });
            DropIndex("dbo.ListItems", new[] { "CategoryId" });
            DropForeignKey("dbo.TodoItems", "TodoListId", "dbo.TodoLists");
            DropForeignKey("dbo.ItemImages", "ListItemId", "dbo.ListItems");
            DropForeignKey("dbo.ItemDetails", "ListItemId", "dbo.ListItems");
            DropForeignKey("dbo.ItemComments", "ListItem_ListItemId2", "dbo.ListItems");
            DropForeignKey("dbo.ItemComments", "ListItem_ListItemId1", "dbo.ListItems");
            DropForeignKey("dbo.ItemComments", "ListItem_ListItemId", "dbo.ListItems");
            DropForeignKey("dbo.ItemComments", "ListItemId", "dbo.ListItems");
            DropForeignKey("dbo.ListItems", "CategoryId", "dbo.Categories");
            DropTable("dbo.UserProfile");
            DropTable("dbo.TodoLists");
            DropTable("dbo.TodoItems");
            DropTable("dbo.ItemImages");
            DropTable("dbo.ItemDetails");
            DropTable("dbo.ItemComments");
            DropTable("dbo.ListItems");
            DropTable("dbo.Categories");
        }
    }
}

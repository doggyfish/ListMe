using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	// You can add custom code to this file. Changes will not be overwritten.
	// 
	// If you want Entity Framework to drop and regenerate your database
	// automatically whenever you change your model schema, add the following
	// code to the Application_Start method in your Global.asax file.
	// Note: this will destroy and re-create your database with every model change.
	// 
	// System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<ListMe.Models.TodoItemContext>());
	public class ListMeContext : DbContext {
		public ListMeContext()
			: base("DefaultConnection") {
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ListItem> ListItems { get; set; }
		public DbSet<ItemDetail> ItemDetails { get; set; }
		public DbSet<ItemComment> ItemComments { get; set; }
		public DbSet<ItemImage> ItemImages { get; set; }
		public DbSet<WatchedItem> WatchedItems { get; set; }
		public DbSet<UserAddress> UserAddresses { get; set; }

		//example
		public DbSet<TodoItem> TodoItems { get; set; }
		public DbSet<TodoList> TodoLists { get; set; }

	}
}
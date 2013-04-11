using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class ListMeContext : DbContext {
		public ListMeContext()
			: base("DefaultConnection") {
		}

		//public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ListItem> ListItems { get; set; }
		public DbSet<ItemDetail> ItemDetails { get; set; }
		public DbSet<ItemComment> ItemComments { get; set; }
		public DbSet<ItemImage> ItemImages { get; set; }
	}
}
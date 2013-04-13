using ListMe.Models;

namespace ListMe.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ListMe.Models.ListMeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ListMe.Models.ListMeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

			context.Categories.AddOrUpdate(
			  c => c.Title,
			  new Category { Title = "Andrew Peters" },
			  new Category { Title = "Brice Lambson" },
			  new Category { Title = "Rowan Miller" }
			);

			context.ListItems.AddOrUpdate(
			  li => li.Title,
			  new ListItem {
				  Title = "List Item 1",
				  Description = "Description 1",
				  Icon = "/Images/icon1.png",
				  CategoryId = 1,
				  UserName = "Test1"
			  },
			  new ListItem {
				  Title = "List Item 2",
				  Description = "Description 2",
				  Icon = "/Images/icon2.png",
				  CategoryId = 1,
				  UserName = "Test1"
			  },
			  new ListItem {
				  Title = "List Item 3",
				  Description = "Description 3",
				  Icon = "/Images/icon3.png",
				  CategoryId = 2,
				  UserName = "Test2"
			  },
			  new ListItem {
				  Title = "List Item 4",
				  Description = "Description 4",
				  Icon = "/Images/icon4.png",
				  CategoryId = 3,
				  UserName = "Test1"
			  }
			);
			
        }
    }
}

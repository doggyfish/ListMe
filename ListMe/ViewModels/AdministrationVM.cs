using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListMe.Models;

namespace ListMe.ViewModels {
	public class AdministrationVM {

		public AdministrationVM(Category category)
		{
			Category = category;
			ListItems = category.ListItems;
		}

		public Category Category { get; set; }
		public List<ListItem> ListItems { get; set; }
	}
}
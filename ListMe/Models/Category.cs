using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class Category {
		public int CategoryId { get; set; }

		public string Title { get; set; }

		public virtual List<ListItem> ListItems { get; set; } 
	}
}
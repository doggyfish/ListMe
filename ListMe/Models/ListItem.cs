using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListMe.Models {

	/// <summary>
	/// ListItem Entity
	/// </summary>
	public class ListItem {
		public int ListItemId { get; set; }

		//Use id?
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Title { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }

		public virtual List<ItemComment> ItemDetails { get; set; }
		public virtual List<ItemComment> ItemImages { get; set; }
		public virtual List<ItemComment> ItemComments { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; } 
	}
}
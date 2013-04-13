using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class Category {
		public int CategoryId { get; set; }

		[Required]
		public string Title { get; set; }

		public virtual List<ListItem> ListItems { get; set; } 
	}
}
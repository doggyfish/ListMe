using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class ItemImage {

		public int ItemImageId { get; set; }

		public string ImageLink { get; set; }

		[ForeignKey("ListItem")]
		public int ListItemId { get; set; }
		public virtual ListItem ListItem { get; set; }

	}
}
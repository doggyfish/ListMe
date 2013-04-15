using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class WatchedItem {
		public int WatchedItemId { get; set; }

		[ForeignKey("UserProfile")]
		public int UserId { get; set; }
		public UserProfile UserProfile { get; set; }

		[Required]
		public int ItemId { get; set; }

		//[ForeignKey("ListItem")]
		//public int ItemId { get; set; }
		//public ListItem ListItem { get; set; }
	}
}
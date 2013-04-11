using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListMe.Models
{
	/// <summary>
	/// Todo:
	/// </summary>
	public class ItemComment
	{
		public int ItemCommentId { get; set; }

		public string Content { get; set; }

		[ForeignKey("ListItem")]
		public int ListItemId { get; set; }
		public virtual ListItem ListItem { get; set; }
	}
}
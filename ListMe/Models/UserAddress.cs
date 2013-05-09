using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListMe.Models {
	public class UserAddress {
		public int UserAddressId { get; set; }

		public string Address { get; set; }

		[ForeignKey("UserProfile")]
		public int UserId { get; set; }
		public UserProfile UserProfile { get; set; }
	}
}
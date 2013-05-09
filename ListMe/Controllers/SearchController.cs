using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ListMe.Filters;
using ListMe.Models;
using ListMe.Helper;

namespace ListMe.Controllers
{
	[ValidateHttpAntiForgeryToken]
	public class SearchController : ApiController
	{
		private ListMeContext db = new ListMeContext();

		// GET api/Search?r=&c=&k=
		public IEnumerable<ListItem> GetListItems(GlobalEnum.Region region = GlobalEnum.Region.NewZealand, string category = "", string keyword = "")
		{
			IEnumerable<ListItem> listitems = null;

			if (region != GlobalEnum.Region.NewZealand && !String.IsNullOrEmpty(category) && !String.IsNullOrEmpty(keyword)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.UserProfile.Region == region && l.Category.Title == category && l.Title.Contains(keyword) && l.Description.Contains(keyword))
					.AsEnumerable();
			} else if (region != GlobalEnum.Region.NewZealand && String.IsNullOrEmpty(category)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.UserProfile.Region == region && l.Category.Title == category)
					.AsEnumerable();
			} else if (region != GlobalEnum.Region.NewZealand && String.IsNullOrEmpty(keyword)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.UserProfile.Region == region && l.Title.Contains(keyword) && l.Description.Contains(keyword))
					.AsEnumerable();
			} else if (String.IsNullOrEmpty(category) && String.IsNullOrEmpty(keyword)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.Category.Title == category && l.Title.Contains(keyword) && l.Description.Contains(keyword))
					.AsEnumerable();
			} else if (String.IsNullOrEmpty(category)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.Category.Title == category)
					.AsEnumerable();
			} else if (String.IsNullOrEmpty(keyword)) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.Title.Contains(keyword) && l.Description.Contains(keyword))
					.AsEnumerable();
			} else if (region != GlobalEnum.Region.NewZealand) {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.Where(l => l.UserProfile.Region == region)
					.AsEnumerable();
			} else {
				listitems = db.ListItems
					.Include(l => l.Category)
					.Include(l => l.UserProfile)
					.AsEnumerable();
			}
		   
			return listitems;
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}
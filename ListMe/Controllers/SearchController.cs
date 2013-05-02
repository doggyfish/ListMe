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

namespace ListMe.Controllers
{
	[ValidateHttpAntiForgeryToken]
    public class SearchController : ApiController
    {
        private ListMeContext db = new ListMeContext();

        // GET api/Search
        public IEnumerable<ListItem> GetListItems(string category = "", string keyword = "")
        {
	        bool hasCategory = false;
			var listitems = db.ListItems.Include(l => l.Category).Where(i => i.Category.Title == category && i.Title.Contains(keyword) && i.Description.Contains(keyword));
            return listitems.AsEnumerable();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
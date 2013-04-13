using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListMe.Models;
using ListMe.ViewModels;

namespace ListMe.Controllers.Admin
{
    public class AdministrationController : Controller
    {
		private ListMeContext db = new ListMeContext();

        //
        // GET: /Administration/
		public ActionResult Index()
        {
	        return View(db.Categories.Include("ListItems")
	                      .Where(c => c.ListItems.Any(item => item.UserName == User.Identity.Name))
	                      .OrderByDescending(u => u.CategoryId)
	                      .AsEnumerable()
	                      .Select(category => new AdministrationVM(category)));
        }		

		protected override void Dispose(bool disposing) {
			db.Dispose();
			base.Dispose(disposing);
		}
    }
}

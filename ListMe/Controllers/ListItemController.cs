using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ListMe.Filters;
using ListMe.Models;
using WebMatrix.WebData;

namespace ListMe.Controllers
{
	[Authorize]
	[ValidateHttpAntiForgeryToken]
    public class ListItemController : ApiController
    {
		private ListMeContext db = new ListMeContext();

		// GET api/ListItem
		public IEnumerable<ListItem> GetListItems()
		{
			return db.ListItems
			         .Where(u => u.UserId == WebSecurity.CurrentUserId)
			         .OrderByDescending(u => u.ListItemId)
			         .AsEnumerable();
		}

		// PUT api/ListItem/5
		public HttpResponseMessage PutListItem(int id, ListItem listItem) {
			if (!ModelState.IsValid) {
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			if (id != listItem.ListItemId) {
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			if (listItem.UserId != WebSecurity.CurrentUserId) {
				// Trying to modify a record that does not belong to the user
				return Request.CreateResponse(HttpStatusCode.Unauthorized);
			}

			// Need to detach to avoid duplicate primary key exception when SaveChanges is called
			db.Entry(listItem).State = EntityState.Modified;

			try {
				db.SaveChanges();
			} catch (DbUpdateConcurrencyException) {
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		// POST api/ListItem
		public HttpResponseMessage PostListItem(ListItem listItem) {
			if (!ModelState.IsValid) {
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			Category category = db.Categories.Find(listItem.CategoryId);
			if (category == null) {
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			if (listItem.UserId != WebSecurity.CurrentUserId) {
				// Trying to add a record that does not belong to the user
				return Request.CreateResponse(HttpStatusCode.Unauthorized);
			}

			// Need to detach to avoid loop reference exception during JSON serialization
			db.ListItems.Add(listItem);
			db.SaveChanges();

			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, listItem);
			response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = listItem.ListItemId }));
			return response;
		}

		// DELETE api/ListItem/5
		public HttpResponseMessage DeleteTodoItem(int id) {
			ListItem listItem = db.ListItems.Find(id);
			if (listItem == null) {
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			if (listItem.UserId != WebSecurity.CurrentUserId) {
				// Trying to delete a record that does not belong to the user
				return Request.CreateResponse(HttpStatusCode.Unauthorized);
			}

			//Todo: set isDeleted flag
			db.ListItems.Remove(listItem);

			try {
				db.SaveChanges();
			} catch (DbUpdateConcurrencyException) {
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}

			return Request.CreateResponse(HttpStatusCode.OK, listItem);
		}

		protected override void Dispose(bool disposing) {
			db.Dispose();
			base.Dispose(disposing);
		}
    }
}

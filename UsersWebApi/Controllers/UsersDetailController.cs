using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UsersWebApi.Models;

namespace UsersWebApi.Controllers
{
    public class UsersDetailController : ApiController
    {
        private UsersModel db = new UsersModel();

        // GET: api/UsersDetail
        public IQueryable<Users_Details> GetUsers_Details()
        {
            return db.Users_Details;
        }

        // PUT: api/UsersDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers_Details(int id, Users_Details users_Details)
        {
            if (id != users_Details.UserId)
            {
                return BadRequest();
            }

            db.Entry(users_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Users_DetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UsersDetail
        [ResponseType(typeof(Users_Details))]
        public IHttpActionResult PostUsers_Details(Users_Details users_Details)
        {
            db.Users_Details.Add(users_Details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users_Details.UserId }, users_Details);
        }

        // DELETE: api/UsersDetail/5
        [ResponseType(typeof(Users_Details))]
        public IHttpActionResult DeleteUsers_Details(int id)
        {
            Users_Details users_Details = db.Users_Details.Find(id);
            if (users_Details == null)
            {
                return NotFound();
            }

            db.Users_Details.Remove(users_Details);
            db.SaveChanges();

            return Ok(users_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Users_DetailsExists(int id)
        {
            return db.Users_Details.Count(e => e.UserId == id) > 0;
        }
    }
}
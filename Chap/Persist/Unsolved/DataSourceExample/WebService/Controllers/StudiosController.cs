using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class StudiosController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: api/Studios
        public IQueryable<Studio> GetStudios()
        {
            return db.Studios;
        }

        // GET: api/Studios/5
        [ResponseType(typeof(Studio))]
        public IHttpActionResult GetStudio(int id)
        {
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return NotFound();
            }

            return Ok(studio);
        }

        // PUT: api/Studios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudio(int id, Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studio.Id)
            {
                return BadRequest();
            }

            db.Entry(studio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(id))
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

        // POST: api/Studios
        [ResponseType(typeof(Studio))]
        public IHttpActionResult PostStudio(Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Studios.Add(studio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudioExists(studio.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studio.Id }, studio);
        }

        // DELETE: api/Studios/5
        [ResponseType(typeof(Studio))]
        public IHttpActionResult DeleteStudio(int id)
        {
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return NotFound();
            }

            db.Studios.Remove(studio);
            db.SaveChanges();

            return Ok(studio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudioExists(int id)
        {
            return db.Studios.Count(e => e.Id == id) > 0;
        }
    }
}
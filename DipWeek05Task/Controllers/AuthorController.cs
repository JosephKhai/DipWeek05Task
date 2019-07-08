using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using DipWeek05Task.Models;


namespace DipWeek05Task.Controllers
{
    public class AuthorController : ApiController
    {
        private DipWeek5Entities db = new DipWeek5Entities();

        //GET: api/Author
        public IQueryable<Author> GetAuthors()
        {
            return db.Authors;
        }

        //GET: api/Author/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(string id)
        {
            Author author = await db.Authors.FindAsync(id);
            if(author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        //PUT: api/Author
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PutAuthor(string id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != author.AuthorID)
            {
                return BadRequest();
            }
            db.Entry(author).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExist(id))
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


        //POST: api/Author
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = author.AuthorID }, author);
        }


        //DELETE: api/Author/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(string id)
        {
            Author author = await db.Authors.FindAsync(id);
            if(author == null)
            {
                return NotFound();
            }
            db.Authors.Remove(author);
            await db.SaveChangesAsync();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool AuthorExist(string id)
        {
            return db.Authors.Count(e => e.AuthorID == id) > 0;
        }
    }
}

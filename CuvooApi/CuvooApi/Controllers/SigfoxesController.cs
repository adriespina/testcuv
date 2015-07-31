using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CuvooApi.Models;

namespace CuvooApi.Controllers
{
    public class SigfoxesController : ApiController
    {
        private CuvooApiContext db = new CuvooApiContext();

        // GET: api/Sigfoxes
        public IQueryable<Sigfox> GetSigfoxes()
        {
            return db.Sigfoxes;
        }

        // GET: api/Sigfoxes/5
        [ResponseType(typeof(Sigfox))]
        public async Task<IHttpActionResult> GetSigfox(int id)
        {
            Sigfox sigfox = await db.Sigfoxes.FindAsync(id);
            if (sigfox == null)
            {
                return NotFound();
            }

            return Ok(sigfox);
        }

        // PUT: api/Sigfoxes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSigfox(int id, Sigfox sigfox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sigfox.Id)
            {
                return BadRequest();
            }

            db.Entry(sigfox).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SigfoxExists(id))
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

        // POST: api/Sigfoxes
        [ResponseType(typeof(Sigfox))]
        public async Task<IHttpActionResult> PostSigfox(Sigfox sigfox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sigfoxes.Add(sigfox);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sigfox.Id }, sigfox);
        }

        // DELETE: api/Sigfoxes/5
        [ResponseType(typeof(Sigfox))]
        public async Task<IHttpActionResult> DeleteSigfox(int id)
        {
            Sigfox sigfox = await db.Sigfoxes.FindAsync(id);
            if (sigfox == null)
            {
                return NotFound();
            }

            db.Sigfoxes.Remove(sigfox);
            await db.SaveChangesAsync();

            return Ok(sigfox);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SigfoxExists(int id)
        {
            return db.Sigfoxes.Count(e => e.Id == id) > 0;
        }
    }
}
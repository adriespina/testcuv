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
    public class MedidasController : ApiController
    {
        private CuvooApiContext db = new CuvooApiContext();

        // GET: api/Medidas
        public IQueryable<Medidas> GetMedidas()
        {
            return db.Medidas;
        }

        // GET: api/Medidas/5
        [ResponseType(typeof(Medidas))]
        public async Task<IHttpActionResult> GetMedidas(int id)
        {
            Medidas medidas = await db.Medidas.FindAsync(id);
            if (medidas == null)
            {
                return NotFound();
            }

            return Ok(medidas);
        }

        // PUT: api/Medidas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedidas(int id, Medidas medidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medidas.Id)
            {
                return BadRequest();
            }

            db.Entry(medidas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidasExists(id))
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

        // POST: api/Medidas
        [ResponseType(typeof(Medidas))]
        public async Task<IHttpActionResult> PostMedidas(Medidas medidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medidas.Add(medidas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medidas.Id }, medidas);
        }

        // DELETE: api/Medidas/5
        [ResponseType(typeof(Medidas))]
        public async Task<IHttpActionResult> DeleteMedidas(int id)
        {
            Medidas medidas = await db.Medidas.FindAsync(id);
            if (medidas == null)
            {
                return NotFound();
            }

            db.Medidas.Remove(medidas);
            await db.SaveChangesAsync();

            return Ok(medidas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedidasExists(int id)
        {
            return db.Medidas.Count(e => e.Id == id) > 0;
        }
    }
}
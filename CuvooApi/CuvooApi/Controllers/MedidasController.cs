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
using CuvooApi.Models.DTO;

namespace CuvooApi.Controllers
{
    [RoutePrefix("api/Medidas")]
    public class MedidasController : ApiController
    {
        private CuvooApiContext db = new CuvooApiContext();

        // GET: api/Medidas
        /// <summary>
        /// devulve todas las 50 ultimas medidas de un sensor
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IQueryable<MedidasPosicionDTO> GetMedidas()
        {

            var medidas = from m in db.Medidas
                           join s in db.Sensors on m.SensorId equals s.Id
                           join d in db.Devices on s.DeviceId equals d.Id
                           select new MedidasPosicionDTO { HoraMsg = m.HoraMsg, Latitud = (double)m.ValorMsgPosition.Latitude, Longitud = (double)m.ValorMsgPosition.Longitude, NombreDispositivo = d.Nombre, Hexadecimal = m.ValorMsgHex };

            if (medidas.Count() > 50) medidas=medidas.Take(50);

            return medidas;
        }

        // GET: api/Medidas/5
        //devulve las ultimas 50 medidas de un dispositivo
        [ResponseType(typeof(MedidasPosicionDTO))]
        public async Task<IHttpActionResult> GetMedidas(int id)
        {
            var medidas = await (from m in db.Medidas
                                 join s in db.Sensors on m.SensorId equals s.Id
                                 join d in db.Devices on s.DeviceId equals d.Id
                                 where d.Id==id
                                 select new MedidasPosicionDTO { HoraMsg = m.HoraMsg, Latitud = (double)m.ValorMsgPosition.Latitude, Longitud = (double)m.ValorMsgPosition.Longitude, NombreDispositivo = d.Nombre, Hexadecimal = m.ValorMsgHex }).ToListAsync();
                                
            if (medidas == null)
            {
                return NotFound();
            }

            if (medidas.Count() > 50) return Ok(medidas.Take(50));
            else return Ok(medidas);
        }

        //// PUT: api/Medidas/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutMedidas(int id, Medidas medidas)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != medidas.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(medidas).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MedidasExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Medidas
        //[ResponseType(typeof(Medidas))]
        //public async Task<IHttpActionResult> PostMedidas(Medidas medidas)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Medidas.Add(medidas);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = medidas.Id }, medidas);
        //}

        //// DELETE: api/Medidas/5
        //[ResponseType(typeof(Medidas))]
        //public async Task<IHttpActionResult> DeleteMedidas(int id)
        //{
        //    Medidas medidas = await db.Medidas.FindAsync(id);
        //    if (medidas == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Medidas.Remove(medidas);
        //    await db.SaveChangesAsync();

        //    return Ok(medidas);
        //}

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
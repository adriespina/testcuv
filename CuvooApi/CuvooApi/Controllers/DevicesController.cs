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
using System.Linq.Expressions;

namespace CuvooApi.Controllers
{
    [RoutePrefix("api/Devices")]
    public class DevicesController : ApiController
    {
        private CuvooApiContext db = new CuvooApiContext();

        private static readonly Expression<Func<Device, DeviceDTO>> AsDeviceDto =
            x => new DeviceDTO
            {
                Nombre = x.Nombre,
                Bateria = x.Bateria,
                Estado = x.Estado,
                FechaAlta = x.FechaAlta,
                FechaValidez = x.FechaValidez,
                Perfil=x.Perfil,
                Configuracion = x.Configuracion,
                ID = x.Id
            };
        // GET: api/Devices
        [Route("")]
        public IQueryable<DeviceDTO> GetDevices()
        {
            return db.Devices.Select(AsDeviceDto).Take(50);
        }

        // GET: api/Devices/5
        /// <summary>
        /// Devuelve los dispositivos de un usuario Dado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(DeviceDTO))]
        public async Task<IHttpActionResult> GetDevice(int id)
        {
            var devices = await (from x in db.Devices
                                 join u in db.Usuarios on x.UsuarioId equals u.Id
                                 where x.UsuarioId == id
                                 select (new DeviceDTO
                                 {
                                     Nombre = x.Nombre,
                                     Bateria = x.Bateria,
                                     Estado = x.Estado,
                                     FechaAlta = x.FechaAlta,
                                     FechaValidez = x.FechaValidez,
                                     Perfil = x.Perfil,
                                     Configuracion = x.Configuracion,
                                     ID=x.Id
                                 })).ToListAsync();

            if (devices == null)
            {
                return NotFound();
            }
            else return Ok(devices);
        }

        //// PUT: api/Devices/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutDevice(int id, Device device)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != device.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(device).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceExists(id))
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

        //// POST: api/Devices
        //[ResponseType(typeof(Device))]
        //public async Task<IHttpActionResult> PostDevice(Device device)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Devices.Add(device);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = device.Id }, device);
        //}

        //// DELETE: api/Devices/5
        //[ResponseType(typeof(Device))]
        //public async Task<IHttpActionResult> DeleteDevice(int id)
        //{
        //    Device device = await db.Devices.FindAsync(id);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Devices.Remove(device);
        //    await db.SaveChangesAsync();

        //    return Ok(device);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(int id)
        {
            return db.Devices.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class UsuariosController : ApiController
    {
        private CuvooApiContext db = new CuvooApiContext();

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Usuario, UsuarioDTO>> AsUsuarioDto =
            x => new UsuarioDTO
            {
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Email = x.Email,
                ID=x.Id
               
            };
       
        // GET: api/Usuarios
        public IQueryable<UsuarioDTO> GetUsuarios()
        {
            return db.Usuarios.Select(AsUsuarioDto).Take(50);
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(UsuarioDTO))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            UsuarioDTO usuario = await db.Usuarios.Where(b => b.Id == id).Select(AsUsuarioDto).SingleOrDefaultAsync();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //// PUT: api/Usuarios/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != usuario.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(usuario).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuarioExists(id))
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

        //// POST: api/Usuarios
        //[ResponseType(typeof(Usuario))]
        //public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Usuarios.Add(usuario);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        //}

        //// DELETE: api/Usuarios/5
        //[ResponseType(typeof(Usuario))]
        //public async Task<IHttpActionResult> DeleteUsuario(int id)
        //{
        //    Usuario usuario = await db.Usuarios.FindAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Usuarios.Remove(usuario);
        //    await db.SaveChangesAsync();

        //    return Ok(usuario);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}
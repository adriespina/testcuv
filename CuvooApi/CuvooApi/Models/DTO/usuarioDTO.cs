using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models.DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }        
    }
}
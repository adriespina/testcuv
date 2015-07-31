using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime UltimoAcceso { get; set; }
        public Bitmap Imagen { get; set; }
    }
}
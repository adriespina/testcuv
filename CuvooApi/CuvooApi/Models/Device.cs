using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CuvooApi.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaValidez { get; set; }
        public int Bateria { get; set; }    
        public string URLCallback { get; set; }
        public Perfil Perfil { get; set; }
        public Configuracion Configuracion { get; set; }  
        public Estado Estado { get; set; }

        // Foreign Key
        public int UsuarioId { get; set; }
         
        ////Collection navigation property
        //public  IList<Sensor> Sensors { get; set; }
        
    }
}
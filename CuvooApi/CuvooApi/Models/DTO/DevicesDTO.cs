using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models.DTO
{
    public class DevicesDTO
    {
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaValidez { get; set; }
        public int Bateria { get; set; }       
        public Perfil Perfil { get; set; }
        public Configuracion Configuracion { get; set; }
        public Estado Estado { get; set; }
        public Sensor[] Sensores { get; set; }

    }
}
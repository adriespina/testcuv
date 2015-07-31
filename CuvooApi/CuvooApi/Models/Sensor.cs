using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public class Sensor
    {
        public int Id { get; set; }   
        public DateTime HoraMsg { get; set; }
        public Configuracion Configuracion { get; set; }
        public string URLCallback { get; set; }
        public double ValorMsgDouble { get; set; }
        public string ValorMsgString { get; set; }
        public  System.Data.Entity.Spatial.DbGeography ValorMsgPosition { get; set; }
        public TipoSensor TipoSensor { get; set; }
        public Perfil Perfil { get; set; }

        // Foreign Key
        public int DeviceId { get; set; }
        // Navigation property
        public virtual Device Device { get; set; }
        
        // Foreign Key
        public int SigFoxId { get; set; }
        // Navigation property
        public virtual Sigfox Sigfox { get; set; }
    }
}
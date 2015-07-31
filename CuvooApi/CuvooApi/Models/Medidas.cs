using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public class Medidas
    {
        public int Id { get; set; }    
        public DateTime HoraMsg { get; set; }
        public double ValorMsgDouble { get; set; }
        public string ValorMsgString { get; set; }
        public System.Data.Entity.Spatial.DbGeography ValorMsgPosition { get; set; }

        // Foreign Key
        public int SigFoxId { get; set; }
        // Navigation property
        public virtual Sigfox Sigfox { get; set; }

        // Foreign Key
        public int SensorId { get; set; }
        // Navigation property
        public virtual Sensor Sensor { get; set; }
    }
}
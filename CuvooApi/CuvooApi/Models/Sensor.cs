using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public class Sensor
    {
        public int Id { get; set; } 
        public TipoSensor TipoSensor { get; set; } 
        // Foreign Key
        public int DeviceId { get; set; }
       
       
        
       
    }
}
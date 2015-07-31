﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public class CuvooApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CuvooApiContext() : base("name=CuvooApiContext")
        {
        }

        public System.Data.Entity.DbSet<CuvooApi.Models.Device> Devices { get; set; }

        public System.Data.Entity.DbSet<CuvooApi.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<CuvooApi.Models.Sensor> Sensors { get; set; }

        public System.Data.Entity.DbSet<CuvooApi.Models.Sigfox> Sigfoxes { get; set; }

        public System.Data.Entity.DbSet<CuvooApi.Models.Medidas> Medidas { get; set; }
    
    }
}

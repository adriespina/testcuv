﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ValorMsgHex { get; set; }
        public System.Data.Entity.Spatial.DbGeography ValorMsgPosition { get; set; }

       
        public int SigFoxId { get; set; }   
        public int DeviceId { get; set; }
       
       
    }
}
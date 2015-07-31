using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models.DTO
{
    public class MedidasPosicionDTO
    {
       
        public DateTime HoraMsg { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
        public string NombreDispositivo { get; set; }
        public string Hexadecimal { get; set; }
       
    }
}
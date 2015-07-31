using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    public enum Estado { NotSet = 0, SinAlta , OK, Caducado };
    public enum Configuracion { NotSet = 0, Callback , DiezMin, TreintaMin, UnaHora, TresHoras, DoceHoras, UnDia };
    public enum TipoSensor { NotSet = 0, Temperatura, Humedad, Posicion, Movimiento, String, Double };
    public enum Perfil { NotSet = 0, Mascota, Equipaje, Mochila, Coche, Moto, Bici, Persona, General };
}
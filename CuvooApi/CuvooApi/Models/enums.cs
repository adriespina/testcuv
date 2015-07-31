using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuvooApi.Models
{
    enum Estado { NotSet = 0, SinAlta , OK, Caducado };
    enum Configuracion { NotSet = 0, Callback , DiezMin, TreintaMin, UnaHora, TresHoras, DoceHoras, UnDia };
    enum TipoSensor { NotSet = 0, Temperatura , Humedad, Posicion, Movimiento, String, Double };
    enum Perfil { NotSet = 0, Mascota, Equipaje, Mochila, Coche, Moto, Bici, Persona, General };
}
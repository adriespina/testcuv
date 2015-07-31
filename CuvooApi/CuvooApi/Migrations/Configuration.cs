namespace CuvooApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CuvooApi.Models;
    using CuvooApi.Tools;
    using System.Data.Entity.Spatial;

    internal sealed class Configuration : DbMigrationsConfiguration<CuvooApi.Models.CuvooApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CuvooApi.Models.CuvooApiContext context)
        {
            //Inicializo un usuario
            context.Usuarios.AddOrUpdate(x => x.Id,
                new Usuario() { Id = 1, Nombre = "Adrian", Apellidos = "Espina Viella", Email = "adrian.espina@cuvoo.es", Contraseña = "mafalda", UltimoAcceso = DateTime.Now.AddMonths(-1) });

            //Inicializo un dispositivo
            context.Devices.AddOrUpdate(x => x.Id,
                new Device() { Id = 1, Nombre = "Cuvoo de Adrian", UsuarioId = 1, FechaAlta = DateTime.Now.AddMonths(-1).AddDays(-1), FechaValidez = DateTime.Now.AddYears(1).AddMonths(-1).AddDays(-1), Bateria = 90, Configuracion = Configuracion.DiezMin, Perfil = Perfil.Coche, Estado = Estado.OK });

            //Inicializo un  sensor
            context.Sensors.AddOrUpdate(x => x.Id,
               new Sensor() { Id = 1, TipoSensor= TipoSensor.Posicion, DeviceId=1 });

            //Inicializo unas Medidas
            context.Medidas.AddOrUpdate(x => x.Id,
                new Medidas() { Id = 1, SigFoxId = 1, HoraMsg = DateTime.Now.AddHours(-1), ValorMsgDouble = 29101980, ValorMsgHex = "a389b4dd", ValorMsgPosition = Tools.CreatePoint(43.539199, -5.650143), SensorId = 1, ValorMsgString = "mi casa gijon" },
                new Medidas() { Id = 2, SigFoxId = 1, HoraMsg = DateTime.Now.AddHours(-1).AddMinutes(1), ValorMsgHex="a389b4dd", ValorMsgDouble = 29101981, ValorMsgPosition = Tools.CreatePoint(43.541108, -6.720897), SensorId = 1, ValorMsgString = "mi casa navia" },
                new Medidas() { Id = 3, SigFoxId = 1, HoraMsg = DateTime.Now.AddHours(-1).AddMinutes(2), ValorMsgHex = "a389b4dd", ValorMsgDouble = 29101982, ValorMsgPosition = Tools.CreatePoint(43.552441, -5.912780), SensorId = 1, ValorMsgString = "cdt" },
                new Medidas() { Id = 4, SigFoxId = 1, HoraMsg = DateTime.Now.AddHours(-1).AddMinutes(3), ValorMsgHex = "a389b4dd", ValorMsgDouble = 29101983, ValorMsgPosition = Tools.CreatePoint(43.559716, -6.676070), SensorId = 1, ValorMsgString = "frejulfe" }              
                
                );

            //Inicializo un  Sigfox
            context.Sigfoxes.AddOrUpdate(x => x.Id,
               new Sigfox() { Id = 1 });

        }
    }
}
